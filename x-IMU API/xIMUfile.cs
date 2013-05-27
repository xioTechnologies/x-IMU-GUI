using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace x_IMU_API
{
    /// <summary>
    /// x-IMU file class.
    /// </summary>
    public class xIMUfile
    {
        #region Variables

        private FileStream fileStream;
        private string privFilePath;
        private PacketCount privPacketCounter;
        private BackgroundWorker backgroundWorker;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the file path.
        /// </summary>
        public string FilePath
        {
            get
            {
                return privFilePath;
            }
        }

        /// <summary>
        /// Gets the packet count data object.
        /// </summary>
        public PacketCount PacketCounter
        {
            get
            {
                return privPacketCounter;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="xIMUfile"/> class. Opens or creates file.
        /// </summary>
        /// <param name="filePath">
        /// Path of file.
        /// </param>
        public xIMUfile(string filePath)
            : this(filePath, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="xIMUfile"/> class.
        /// </summary>
        /// <param name="filePath">
        /// Path of file.
        /// </param>
        /// <param name="overwrite">
        /// Enable overwrite. true = create or overwrite file, false = create or open file.
        /// </param>
        public xIMUfile(string filePath, bool overwrite)
        {
            privPacketCounter = new PacketCount();
            privFilePath = filePath;
            fileStream = new FileStream(FilePath, overwrite ? FileMode.Create : FileMode.OpenOrCreate, FileAccess.ReadWrite);
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Closes the file.
        /// </summary>
        public void Close()
        {
            fileStream.Close();
        }

        #endregion

        #region Packet write methods

        /// <summary>
        /// Writes write register packet.
        /// </summary>
        /// <param name="registerData">
        /// Register data containing register address and value.
        /// </param>
        public void WriteWriteRegisterPacket(RegisterData registerData)
        {
            WriteByteArray(PacketConstruction.ConstructWriteRegisterPacket(registerData));
        }

        /// <summary>
        /// Writes byte array to serial port and increments the sent packets counter.
        /// </summary>
        /// <param name="byteArray">
        /// Byte array to be sent to serial port.
        /// </param>
        private void WriteByteArray(byte[] byteArray)
        {
            fileStream.Write(byteArray, 0, byteArray.Length);
            privPacketCounter.WriteRegisterPacketsWritten++;
        }

        #endregion

        #region Packet read methods

        /// <summary>
        /// Reads file. Interpreted packets are provided in individual events.
        /// </summary>
        public void Read()
        {
            DoRead(false);
        }

        /// <summary>
        /// Run asynchronous read. Interpreted packets are provided in individual events.
        /// </summary>
        public void RunAnsycRead()
        {
            if (backgroundWorker.IsBusy)
            {
                throw new Exception("xIMUfile is currently busy and cannot run multiple reads concurrently.");
            }
            else
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Requests cancelation of pending read process.
        /// </summary>
        public void CancelAnsycRead()
        {
            backgroundWorker.CancelAsync();
        }

        /// <summary>
        /// BackgroundWorker DoWork event to run DoRead as new process.
        /// </summary>
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DoRead(true);
                OnAsyncReadCompleted(new AsyncReadCompletedEventArgs(PacketCounter, null, backgroundWorker.CancellationPending));
            }
            catch (Exception ex)
            {
                OnAsyncReadCompleted(new AsyncReadCompletedEventArgs(PacketCounter, ex, backgroundWorker.CancellationPending));
            }
        }

        /// <summary>
        /// Reads file. Interpreted packets are provided in individual events.
        /// </summary>
        /// <param name="isAsync">
        /// Enables OnAsyncReadProgressChanged event for use when called within background worker.
        /// </param>
        private void DoRead(bool isAsync)
        {
            int previousProgressPercentage = 0;
            byte[] readBuffer = new byte[256];
            byte readBufferIndex = 0;

            // Read the source file into a byte array.
            byte[] fileBuffer = new byte[fileStream.Length];
            int numBytesToRead = (int)fileStream.Length;
            int numBytesRead = 0;
            if (isAsync)
            {
                OnAsyncReadProgressChanged(new AsyncReadProgressChangedEventArgs(0, "Reading file..."));
            }
            while (numBytesToRead > 0)
            {
                int n = fileStream.Read(fileBuffer, numBytesRead, numBytesToRead);  // Read may return anything from 0 to numBytesToRead.
                if (n == 0) break;                                                  // Break when the end of the file is reached.
                numBytesRead += n;
                numBytesToRead -= n;
            }

            // Process each byte one-by-one
            for (int i = 0; i < numBytesRead; i++)
            {
                if (isAsync)
                {
                    int newProgressPercentage = (int)(Math.Round(100d * ((double)i / (double)numBytesRead)));
                    if (backgroundWorker.CancellationPending)
                    {
                        break;
                    }
                    if (newProgressPercentage != previousProgressPercentage)
                    {
                        OnAsyncReadProgressChanged(new AsyncReadProgressChangedEventArgs(newProgressPercentage, "Processed " + string.Format("{0:n0}", i / 1024) + " KB of " + string.Format("{0:n0}", numBytesRead / 1024) + " KB"));
                        previousProgressPercentage = newProgressPercentage;
                    }
                }

                // Process byte
                readBuffer[readBufferIndex++] = fileBuffer[i];                      // add to buffer
                if ((fileBuffer[i] & 0x80) == 0x80)                                 // if packet framing char 
                {
                    xIMUdata dataObject = null;
                    try
                    {
                        byte[] encodedPacket = new byte[readBufferIndex];
                        Array.Copy(readBuffer, encodedPacket, encodedPacket.Length);
                        dataObject = PacketConstruction.DeconstructPacket(encodedPacket);
                    }
                    catch
                    {
                        privPacketCounter.PacketsReadErrors++;
                    }
                    if (dataObject != null)                                         // if packet successfully deconstructed
                    {
                        OnxIMUdataRead(dataObject);
                        if (dataObject is ErrorData) { OnErrorDataRead((ErrorData)dataObject); privPacketCounter.ErrorPacketsRead++; }
                        else if (dataObject is CommandData) { OnCommandDataRead((CommandData)dataObject); privPacketCounter.CommandPacketsRead++; }
                        else if (dataObject is RegisterData) { OnRegisterDataRead((RegisterData)dataObject); privPacketCounter.RegisterPacketsRead++; }
                        else if (dataObject is DateTimeData) { OnDateTimeDataRead((DateTimeData)dataObject); privPacketCounter.DateTimePacketsRead++; }
                        else if (dataObject is RawBattThermData) { OnRawBattThermDataRead((RawBattThermData)dataObject); privPacketCounter.RawBattThermPacketsRead++; }
                        else if (dataObject is CalBattThermData) { OnCalBattThermDataRead((CalBattThermData)dataObject); privPacketCounter.CalBattThermPacketsRead++; }
                        else if (dataObject is RawInertialMagneticData) { OnRawInertialMagneticDataRead((RawInertialMagneticData)dataObject); privPacketCounter.RawInertialMagPacketsRead++; }
                        else if (dataObject is CalInertialMagneticData) { OnCalInertialMagneticDataRead((CalInertialMagneticData)dataObject); privPacketCounter.CalInertialMagPacketsRead++; }
                        else if (dataObject is QuaternionData) { OnQuaternionDataRead((QuaternionData)dataObject); privPacketCounter.QuaternionPacketsRead++; }
                        else if (dataObject is DigitalIOdata) { OnDigitalIODataRead((DigitalIOdata)dataObject); privPacketCounter.DigitalIOPacketsRead++; }
                        else if (dataObject is RawAnalogueInputData) { OnRawAnalogueInputDataReceived((RawAnalogueInputData)dataObject); privPacketCounter.RawAnalogueInputPacketsRead++; }
                        else if (dataObject is CalAnalogueInputData) { OnCalAnalogueInputDataReceived((CalAnalogueInputData)dataObject); privPacketCounter.CalAnalogueInputPacketsRead++; }
                        else if (dataObject is PWMoutputData) { OnPWMoutputDataRead((PWMoutputData)dataObject); privPacketCounter.PWMoutputPacketsRead++; }
                        else if (dataObject is RawADXL345busData) { OnRawADXL345busDataRead((RawADXL345busData)dataObject); privPacketCounter.RawADXL345busPacketsRead++; }
                        else if (dataObject is CalADXL345busData) { OnCalADXL345busDataRead((CalADXL345busData)dataObject); privPacketCounter.CalADXL345busPacketsRead++; }
                        privPacketCounter.TotalPacketsRead++;
                    }
                    readBufferIndex = 0;                                            // reset buffer.
                }
            }
        }

        public delegate void onAsyncReadProgressChanged(object sender, AsyncReadProgressChangedEventArgs e);
        public event onAsyncReadProgressChanged AsyncReadProgressChanged;
        protected virtual void OnAsyncReadProgressChanged(AsyncReadProgressChangedEventArgs e) { if (AsyncReadProgressChanged != null) AsyncReadProgressChanged(this, e); }

        public delegate void onAsyncReadCompleted(object sender, AsyncReadCompletedEventArgs e);
        public event onAsyncReadCompleted AsyncReadCompleted;
        protected virtual void OnAsyncReadCompleted(AsyncReadCompletedEventArgs e) { if (AsyncReadCompleted != null) AsyncReadCompleted(this, e); }

        public delegate void onxIMUdataRead(object sender, xIMUdata e);
        public event onxIMUdataRead xIMUdataRead;
        protected virtual void OnxIMUdataRead(xIMUdata e) { if (xIMUdataRead != null) xIMUdataRead(this, e); }

        public delegate void onErrorDataRead(object sender, ErrorData e);
        public event onErrorDataRead ErrorDataRead;
        protected virtual void OnErrorDataRead(ErrorData e) { if (ErrorDataRead != null) ErrorDataRead(this, e); }

        public delegate void onCommandDataRead(object sender, CommandData e);
        public event onCommandDataRead CommandDataRead;
        protected virtual void OnCommandDataRead(CommandData e) { if (CommandDataRead != null) CommandDataRead(this, e); }

        public delegate void onRegisterDataRead(object sender, RegisterData e);
        public event onRegisterDataRead RegisterDataRead;
        protected virtual void OnRegisterDataRead(RegisterData e) { if (RegisterDataRead != null) RegisterDataRead(this, e); }

        public delegate void onDateTimeDataRead(object sender, DateTimeData e);
        public event onDateTimeDataRead DateTimeDataRead;
        protected virtual void OnDateTimeDataRead(DateTimeData e) { if (DateTimeDataRead != null) DateTimeDataRead(this, e); }

        public delegate void onRawBattThermDataRead(object sender, RawBattThermData e);
        public event onRawBattThermDataRead RawBattThermDataRead;
        protected virtual void OnRawBattThermDataRead(RawBattThermData e) { if (RawBattThermDataRead != null) RawBattThermDataRead(this, e); }

        public delegate void onCalBattThermDataRead(object sender, CalBattThermData e);
        public event onCalBattThermDataRead CalBattThermDataRead;
        protected virtual void OnCalBattThermDataRead(CalBattThermData e) { if (CalBattThermDataRead != null) CalBattThermDataRead(this, e); }

        public delegate void onRawInertialMagneticDataRead(object sender, RawInertialMagneticData e);
        public event onRawInertialMagneticDataRead RawInertialMagneticDataRead;
        protected virtual void OnRawInertialMagneticDataRead(RawInertialMagneticData e) { if (RawInertialMagneticDataRead != null) RawInertialMagneticDataRead(this, e); }

        public delegate void onCalInertialMagneticDataRead(object sender, CalInertialMagneticData e);
        public event onCalInertialMagneticDataRead CalInertialMagneticDataRead;
        protected virtual void OnCalInertialMagneticDataRead(CalInertialMagneticData e) { if (CalInertialMagneticDataRead != null) CalInertialMagneticDataRead(this, e); }

        public delegate void onQuaternionDataRead(object sender, QuaternionData e);
        public event onQuaternionDataRead QuaternionDataRead;
        protected virtual void OnQuaternionDataRead(QuaternionData e) { if (QuaternionDataRead != null) QuaternionDataRead(this, e); }

        public delegate void onDigitalIODataRead(object sender, DigitalIOdata e);
        public event onDigitalIODataRead DigitalIODataRead;
        protected virtual void OnDigitalIODataRead(DigitalIOdata e) { if (DigitalIODataRead != null) DigitalIODataRead(this, e); }

        public delegate void onRawAnalogueInputDataReceived(object sender, RawAnalogueInputData e);
        public event onRawAnalogueInputDataReceived RawAnalogueInputDataReceived;
        protected virtual void OnRawAnalogueInputDataReceived(RawAnalogueInputData e) { if (RawAnalogueInputDataReceived != null) RawAnalogueInputDataReceived(this, e); }

        public delegate void onCalAnalogueInputDataReceived(object sender, CalAnalogueInputData e);
        public event onCalAnalogueInputDataReceived CalAnalogueInputDataReceived;
        protected virtual void OnCalAnalogueInputDataReceived(CalAnalogueInputData e) { if (CalAnalogueInputDataReceived != null) CalAnalogueInputDataReceived(this, e); }

        public delegate void onPWMoutputDataRead(object sender, PWMoutputData e);
        public event onPWMoutputDataRead PWMoutputDataRead;
        protected virtual void OnPWMoutputDataRead(PWMoutputData e) { if (PWMoutputDataRead != null) PWMoutputDataRead(this, e); }

        public delegate void onRawADXL345busDataRead(object sender, RawADXL345busData e);
        public event onRawADXL345busDataRead RawADXL345busDataRead;
        protected virtual void OnRawADXL345busDataRead(RawADXL345busData e) { if (RawADXL345busDataRead != null) RawADXL345busDataRead(this, e); }

        public delegate void onCalADXL345busDataRead(object sender, CalADXL345busData e);
        public event onCalADXL345busDataRead CalADXL345busDataRead;
        protected virtual void OnCalADXL345busDataRead(CalADXL345busData e) { if (CalADXL345busDataRead != null) CalADXL345busDataRead(this, e); }

        #endregion
    }
}