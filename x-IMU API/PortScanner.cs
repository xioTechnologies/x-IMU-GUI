using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;

namespace xIMU_API
{
    /// <summary>
    /// Port scanner class.
    /// </summary>
    public class PortScanner
    {
        #region Variables

        private bool privFirstResultOnly;
        private bool privDontGiveUp;
        private BackgroundWorker backgroundWorker;
        private string receivedDeviceID;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value that controls whether the scan will end on finding the first x-IMU.
        /// </summary>
        public bool FirstResultOnly
        {
            get
            {
                return privFirstResultOnly;
            }
            set
            {
                privFirstResultOnly = value;
            }
        }

        /// <summary>
        /// Gets or sets a value that controls whether the scan will continue indefinitely until at least one x-IMU has been found.
        /// </summary>
        public bool DontGiveUp
        {
            get
            {
                return privDontGiveUp;
            }
            set
            {
                privDontGiveUp = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the application has requested cancelation of asynchronous port scan process.
        /// </summary>
        public bool CancellationPending
        {
            get
            {
                return backgroundWorker.CancellationPending;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="PortScanner"/> is running an asynchronous scan.
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return backgroundWorker.IsBusy;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initialises a new instance of the <see cref="PortScanner"/> class.
        /// </summary>
        public PortScanner()
            : this(false, false)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="PortScanner"/> class.
        /// </summary>
        /// <param name="firstResultOnly">
        /// Value that controls whether the scan will end on finding the first x-IMU.
        /// </param>
        /// <param name="dontGiveUp">
        /// Value that controls whether the scan will continue indefinitely until at least one x-IMU has been found.
        /// </param>
        public PortScanner(bool firstResultOnly, bool dontGiveUp)
        {
            privFirstResultOnly = firstResultOnly;
            privDontGiveUp = dontGiveUp;
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Scans ports for x-IMUs.
        /// </summary>
        /// <returns>
        /// Array of <see cref="PortAssignments"/> found during the scan.
        /// </returns>
        public PortAssignment[] Scan()
        {
            return DoScan(false);
        }

        /// <summary>
        /// Runs asynchronous scans ports for x-IMUs.  Progress and results provided in OnAsyncScanProgressChanged and OnAsyncScanCompleted events.
        /// </summary>
        public void RunAsynsScan()
        {
            if (backgroundWorker.IsBusy)
            {
                throw new Exception("The PortScanner is currently busy and cannot run multiple scans concurrently.");
            }
            else
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Requests cancelation of pending background port scan process.
        /// </summary>
        public void CancelAnsycScan()
        {
            backgroundWorker.CancelAsync();
        }

        /// <summary>
        /// BackgroundWorker DoWork event to run DoScan as new process.
        /// </summary>
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            PortAssignment[] portAssignments;
            portAssignments = DoScan(true);
            OnAsyncScanCompleted(new AsyncScanCompletedEventArgs(portAssignments, CancellationPending));
        }

        /// <summary>
        /// Scans ports for x-IMUs.
        /// </summary>
        /// <param name="isAsync">
        /// Enables OnAsyncScanProgressChanged event for use when called within background worker.
        /// </param>
        /// <returns>
        /// Array of <see cref="PortAssignments"/> found during the scan.
        /// </returns>
        private PortAssignment[] DoScan(bool isAsync)
        {
            List<PortAssignment> portAssignmentsList = new List<PortAssignment>();
            do
            {
                // Get list of available port names
                List<string> portNames = xIMUserial.GetPortNames().ToList();
                if (portNames.Count == 0)
                {
                    if (DontGiveUp)
                    {
                        if (isAsync)
                        {
                            OnAsyncScanProgressChanged(new AsyncScanProgressChangedEventArgs(0, "No ports found. Retry in 1 second..."));
                        }
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        if (isAsync)
                        {
                            OnAsyncScanProgressChanged(new AsyncScanProgressChangedEventArgs(0, "No ports found."));
                        }
                        break;
                    }
                }
                else
                {
                    int progressPercent = 0;
                    string progressMessage;

                    // Augment list with other potential port names as Bluetooth port names may have an extra numerical character appended
                    int originalCount = portNames.Count;
                    for (int i = 0; i < originalCount; i++)
                    {
                        if (portNames[i].Length == "COMxx".Length)
                        {
                            string altPortName = portNames[i].Substring(0, "COMx".Length);
                            if (!portNames.Contains(altPortName))
                            {
                                portNames.Add(altPortName);
                            }
                        }
                        if (portNames[i].Length == "COMxxx".Length)
                        {
                            string altPortName = portNames[i].Substring(0, "COMxx".Length);
                            if (!portNames.Contains(altPortName))
                            {
                                portNames.Add(altPortName);
                            }
                        }
                    }

                    // Print port names
                    progressMessage = "Found ports: ";
                    for (int i = 0; i < portNames.Count; i++)
                    {
                        progressMessage += portNames[i] + (i < (portNames.Count - 1) ? ", " : ".");
                    }
                    if (isAsync)
                    {
                        progressPercent = (int)(Math.Round(100d * (1d / (1d + (3d * (portNames.Count + 1))))));
                        OnAsyncScanProgressChanged(new AsyncScanProgressChangedEventArgs(progressPercent, progressMessage));
                    }
                    // Scan for x-IMU on each port
                    for (int i = 0; i < portNames.Count; i++)
                    {
                        xIMUserial xIMUserialobj = null;
                        try
                        {
                            // Open serial port
                            if (CancellationPending)
                            {
                                break;
                            }
                            if (isAsync)
                            {
                                progressPercent = (int)(Math.Round(100d * ((1d + (i * 3d) + 1d) / (1d + (3d * (portNames.Count + 1))))));
                                OnAsyncScanProgressChanged(new AsyncScanProgressChangedEventArgs(progressPercent, "Opening " + portNames[i] + "..."));
                            }
                            xIMUserialobj = new xIMUserial(portNames[i]);
                            xIMUserialobj.RegisterDataReceived += new xIMU_API.xIMUserial.onRegisterDataReceived(xIMUserialobj_RegisterDataReceived);
                            xIMUserialobj.Open();

                            // Read device ID
                            if (CancellationPending)
                            {
                                break;
                            }
                            if (isAsync)
                            {
                                progressPercent = (int)(Math.Round(100d * ((1d + (i * 3d) + 2d) / (1d + (3d * (portNames.Count + 1))))));
                                OnAsyncScanProgressChanged(new AsyncScanProgressChangedEventArgs(progressPercent, "Reading device ID..."));
                            }
                            receivedDeviceID = null;
                            xIMUserialobj.SendReadRegisterPacket(new RegisterData(RegisterAddresses.DeviceID));
                            Thread.Sleep(500);
                            if (receivedDeviceID == null)
                            {
                                throw new Exception("No response.");
                            }

                            // Found x-IMU
                            if (CancellationPending)
                            {
                                break;
                            }
                            if (isAsync)
                            {
                                progressPercent = (int)(Math.Round(100d * ((1d + (i * 3d) + 3d) / (1d + (3d * (portNames.Count + 1))))));
                                OnAsyncScanProgressChanged(new AsyncScanProgressChangedEventArgs(progressPercent, "Found x-IMU " + receivedDeviceID + "."));
                            }
                            portAssignmentsList.Add(new PortAssignment(portNames[i], receivedDeviceID));
                            if (FirstResultOnly)
                            {
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            if (isAsync)
                            {
                                OnAsyncScanProgressChanged(new AsyncScanProgressChangedEventArgs(progressPercent, "Failed: " + ex.Message));
                            }
                        }
                        finally
                        {
                            if (xIMUserialobj != null)
                            {
                                xIMUserialobj.Close();
                            }
                        }
                    }
                }
            } while ((portAssignmentsList.Count == 0) && DontGiveUp && !CancellationPending);
            return portAssignmentsList.ToArray();
        }

        /// <summary>
        /// Register data received event to read x-IMU device ID.
        /// </summary>
        private void xIMUserialobj_RegisterDataReceived(object sender, RegisterData e)
        {
            if (e.Address == (ushort)RegisterAddresses.DeviceID)
            {
                receivedDeviceID = string.Format("{0:X4}", e.Value);
            }
        }

        public delegate void onAsyncScanProgressChanged(object sender, AsyncScanProgressChangedEventArgs e);
        public event onAsyncScanProgressChanged AsyncScanProgressChanged;
        protected virtual void OnAsyncScanProgressChanged(AsyncScanProgressChangedEventArgs e) { if (AsyncScanProgressChanged != null) AsyncScanProgressChanged(this, e); }

        public delegate void onAsyncScanCompleted(object sender, AsyncScanCompletedEventArgs e);
        public event onAsyncScanCompleted AsyncScanCompleted;
        protected virtual void OnAsyncScanCompleted(AsyncScanCompletedEventArgs e) { if (AsyncScanCompleted != null) AsyncScanCompleted(this, e); }

        #endregion
    }
}