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
        /// Runs asynchronous port scan.
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
        /// BackgroundWorker DoWork event to run port scan in new process.
        /// </summary>
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<PortAssignment> portAsignmentsList = new List<PortAssignment>();
            do
            {
                // Get list of available port names
                List<string> portNames = xIMUserial.GetPortNames().ToList();
                if (portNames.Count == 0)
                {
                    if (DontGiveUp)
                    {
                        OnProgressChanged(new ScanProgressChangedEventArgs(0, "No ports found. Retry in 1 second..."));
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        OnProgressChanged(new ScanProgressChangedEventArgs(100, "No ports found."));
                    }
                }
                else
                {
                    int progressPercent;
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
                    progressPercent = (int)(Math.Round(100d * (1d/ (1d + (3d * (portNames.Count + 1))))));
                    OnProgressChanged(new ScanProgressChangedEventArgs(progressPercent, progressMessage));

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
                            progressPercent = (int)(Math.Round(100d * ((1d + (i * 3d) + 1d) / (1d + (3d * (portNames.Count + 1))))));
                            OnProgressChanged(new ScanProgressChangedEventArgs(progressPercent, "Opening " + portNames[i] + "..."));
                            xIMUserialobj = new xIMUserial(portNames[i]);
                            xIMUserialobj.RegisterDataReceived += new xIMU_API.xIMUserial.onRegisterDataReceived(xIMUserialobj_RegisterDataReceived);
                            xIMUserialobj.Open();

                            // Read device ID
                            if (CancellationPending)
                            {
                                break;
                            }
                            progressPercent = (int)(Math.Round(100d * ((1d + (i * 3d) + 2d) / (1d + (3d* (portNames.Count + 1))))));
                            OnProgressChanged(new ScanProgressChangedEventArgs(progressPercent, "Reading device ID..."));
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
                            progressPercent = (int)(Math.Round(100d * ((1d + (i * 3d) + 3d) / (1d + (3d * (portNames.Count + 1))))));
                            OnProgressChanged(new ScanProgressChangedEventArgs(progressPercent, "Found x-IMU " + receivedDeviceID + "."));
                            portAsignmentsList.Add(new PortAssignment(portNames[i], receivedDeviceID));
                            if (FirstResultOnly)
                            {
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            OnProgressChanged(new ScanProgressChangedEventArgs(progressPercent, "Failed: " + ex.Message));
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
            } while ((portAsignmentsList.Count == 0) && DontGiveUp && !CancellationPending);
            OnProgressChanged(new ScanProgressChangedEventArgs(100, "Complete."));
            OnCompleted(new RunScanCompletedEventArgs(portAsignmentsList.ToArray(), CancellationPending));
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

        public delegate void onProgressChanged(object sender, ScanProgressChangedEventArgs e);
        public event onProgressChanged ProgressChanged;
        protected virtual void OnProgressChanged(ScanProgressChangedEventArgs e) { if (ProgressChanged != null) ProgressChanged(this, e); }

        public delegate void onCompleted(object sender, RunScanCompletedEventArgs e);
        public event onCompleted Completed;
        protected virtual void OnCompleted(RunScanCompletedEventArgs e) { if (Completed != null) Completed(this, e); }

        #endregion
    }
}