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
    public class xIMUfile : IDisposable
    {
        /// <summary>
        /// Private FileStream handles file read/writes.
        /// </summary>
        private FileStream fileStream;

        /// <summary>
        /// Private BackgroundWorker to run process in new thread.
        /// </summary>
        private BackgroundWorker backgroundWorker;

        /// <summary>
        /// Gets the file path.
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// Gets the number of read errors.
        /// </summary>
        public int ReadErrors { get; private set; }

        /// <summary>
        /// Gets the number of packets read.
        /// </summary>
        public PacketCount PacketsReadCounter { get; private set; }

        /// <summary>
        /// Gets the number of packets written.
        /// </summary>
        public PacketCount PacketsWrittenCounter { get; private set; }

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
            FilePath = filePath;
            fileStream = new FileStream(FilePath, overwrite ? FileMode.Create : FileMode.OpenOrCreate, FileAccess.ReadWrite);
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            ReadErrors = 0;
            PacketsReadCounter = new PacketCount();
            PacketsWrittenCounter = new PacketCount();
        }

        /// <summary>
        /// IDisposable method: closes the filestream.
        /// Allows xIMUfile to be used in a 'using' statement.
        /// </summary>
        public void Dispose()
        {
            Close();
        }

        /// <summary>
        /// Closes the file.
        /// </summary>
        public void Close()
        {
            fileStream.Close();
        }

        #region Write methods

        /// <summary>
        /// Writes write register packet.
        /// </summary>
        /// <param name="registerData">
        /// Register data containing register address and value.
        /// </param>
        public void WriteWriteRegisterPacket(RegisterData registerData)
        {
            WriteByteArray(PacketConstruction.ConstructWriteRegisterPacket(registerData));
            PacketsWrittenCounter.WriteRegisterPackets++;
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
        }

        #endregion

        #region Read methods

        /// <summary>
        /// Reads file. Interpreted packets are provided in individual events.
        /// </summary>
        public void Read()
        {
            DoIncrimentalRead(false);
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
                DoIncrimentalRead(true);
                OnAsyncReadCompleted(new AsyncReadCompletedEventArgs(PacketsReadCounter, null, backgroundWorker.CancellationPending));
            }
            catch (Exception ex)
            {
                OnAsyncReadCompleted(new AsyncReadCompletedEventArgs(PacketsReadCounter, ex, backgroundWorker.CancellationPending));
            }
        }

        /// <summary>
        /// Reads file. Interpreted packets are provided in individual events.
        /// </summary>
        /// <param name="isAsync">
        /// Enables OnAsyncReadProgressChanged event for use when called within background worker.
        /// </param>
        /// <remarks>
        /// Modified by Jon Robson to incrimentally splits a binary file into packets while decoded.
        /// </remarks>
        private void DoIncrimentalRead(bool isAsync)
        {
            int previousProgressPercentage = 0;
            int newProgressPercentage = 0;
            const int chunkSize = 100000;
            List<Byte> packets = new List<byte>();

            fileStream.Position = 0;

            

            if (isAsync)
            {
                OnAsyncReadProgressChanged(new AsyncReadProgressChangedEventArgs(0, "Reading file..."));
            }

            //until the end of the file
            while (fileStream.Length > fileStream.Position)
            {
                if (isAsync)
                {
                    if (backgroundWorker.CancellationPending)
                    {
                        break;
                    }

                }

                byte[] chunk = new byte[chunkSize];
                fileStream.Read(chunk, 0, chunkSize);

                var packetBoundaries = chunk.Select(x => new { Test = ((x & 0x80) == 0x80), ByteValue = x });

                foreach (var i in packetBoundaries)
                {
                    //stack up the byte values
                    packets.Add(i.ByteValue);

                    if (i.Test && packets.Count > 0)
                    {
                        DecodePacket(packets.ToArray());
                        packets.Clear();
                    }
                }

                newProgressPercentage = (int)(Math.Round(100d * ((double)fileStream.Position / (double)fileStream.Length)));
                if (newProgressPercentage != previousProgressPercentage)
                {
                    OnAsyncReadProgressChanged(new AsyncReadProgressChangedEventArgs(newProgressPercentage, "Processed " + string.Format("{0:n0}", (fileStream.Position) / 1024) + " KB of " + string.Format("{0:n0}", (fileStream.Length) / 1024) + " KB"));
                    previousProgressPercentage = newProgressPercentage;
                }
            }

        }

        /// <summary>
        /// Decodes a complete packet
        /// </summary>
        /// <param name="packet"></param>
        public void DecodePacket(byte[] packet)
        {
            xIMUdata dataObject = null;
            try
            {
                dataObject = PacketConstruction.DeconstructPacket(packet);
            }
            catch
            {
                ReadErrors++;                                               // invalid packet
            }
            if (dataObject != null)                                         // if packet successfully deconstructed
            {
                OnxIMUdataRead(dataObject);
                if (dataObject is ErrorData) { OnErrorDataRead((ErrorData)dataObject); PacketsReadCounter.ErrorPackets++; }
                else if (dataObject is CommandData) { OnCommandDataRead((CommandData)dataObject); PacketsReadCounter.CommandPackets++; }
                else if (dataObject is RegisterData) { OnRegisterDataRead((RegisterData)dataObject); PacketsReadCounter.WriteRegisterPackets++; }
                else if (dataObject is DateTimeData) { OnDateTimeDataRead((DateTimeData)dataObject); PacketsReadCounter.WriteDateTimePackets++; }
                else if (dataObject is RawBatteryAndThermometerData) { OnRawBatteryAndThermometerDataRead((RawBatteryAndThermometerData)dataObject); PacketsReadCounter.RawBatteryAndThermometerDataPackets++; }
                else if (dataObject is CalBatteryAndThermometerData) { OnCalBatteryAndThermometerDataRead((CalBatteryAndThermometerData)dataObject); PacketsReadCounter.CalBatteryAndThermometerDataPackets++; }
                else if (dataObject is RawInertialAndMagneticData) { OnRawInertialAndMagneticDataRead((RawInertialAndMagneticData)dataObject); PacketsReadCounter.RawInertialAndMagneticDataPackets++; }
                else if (dataObject is CalInertialAndMagneticData) { OnCalInertialAndMagneticDataRead((CalInertialAndMagneticData)dataObject); PacketsReadCounter.CalInertialAndMagneticDataPackets++; }
                else if (dataObject is QuaternionData) { OnQuaternionDataRead((QuaternionData)dataObject); PacketsReadCounter.QuaternionDataPackets++; }
                else if (dataObject is DigitalIOdata) { OnDigitalIODataRead((DigitalIOdata)dataObject); PacketsReadCounter.DigitalIOdataPackets++; }
                else if (dataObject is RawAnalogueInputData) { OnRawAnalogueInputDataRead((RawAnalogueInputData)dataObject); PacketsReadCounter.RawInertialAndMagneticDataPackets++; }
                else if (dataObject is CalAnalogueInputData) { OnCalAnalogueInputDataRead((CalAnalogueInputData)dataObject); PacketsReadCounter.CalAnalogueInputDataPackets++; }
                else if (dataObject is PWMoutputData) { OnPWMoutputDataRead((PWMoutputData)dataObject); PacketsReadCounter.PWMoutputDataPackets++; }
                else if (dataObject is RawADXL345busData) { OnRawADXL345busDataRead((RawADXL345busData)dataObject); PacketsReadCounter.RawADXL345busDataPackets++; }
                else if (dataObject is CalADXL345busData) { OnCalADXL345busDataRead((CalADXL345busData)dataObject); PacketsReadCounter.CalADXL345busDataPackets++; }
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

        public delegate void onRawBatteryAndThermometerDataRead(object sender, RawBatteryAndThermometerData e);
        public event onRawBatteryAndThermometerDataRead RawBatteryAndThermometerDataRead;
        protected virtual void OnRawBatteryAndThermometerDataRead(RawBatteryAndThermometerData e) { if (RawBatteryAndThermometerDataRead != null) RawBatteryAndThermometerDataRead(this, e); }

        public delegate void onCalBatteryAndThermometerDataRead(object sender, CalBatteryAndThermometerData e);
        public event onCalBatteryAndThermometerDataRead CalBatteryAndThermometerDataRead;
        protected virtual void OnCalBatteryAndThermometerDataRead(CalBatteryAndThermometerData e) { if (CalBatteryAndThermometerDataRead != null) CalBatteryAndThermometerDataRead(this, e); }

        public delegate void onRawInertialAndMagneticDataRead(object sender, RawInertialAndMagneticData e);
        public event onRawInertialAndMagneticDataRead RawInertialAndMagneticDataRead;
        protected virtual void OnRawInertialAndMagneticDataRead(RawInertialAndMagneticData e) { if (RawInertialAndMagneticDataRead != null) RawInertialAndMagneticDataRead(this, e); }

        public delegate void onCalInertialAndMagneticDataRead(object sender, CalInertialAndMagneticData e);
        public event onCalInertialAndMagneticDataRead CalInertialAndMagneticDataRead;
        protected virtual void OnCalInertialAndMagneticDataRead(CalInertialAndMagneticData e) { if (CalInertialAndMagneticDataRead != null) CalInertialAndMagneticDataRead(this, e); }

        public delegate void onQuaternionDataRead(object sender, QuaternionData e);
        public event onQuaternionDataRead QuaternionDataRead;
        protected virtual void OnQuaternionDataRead(QuaternionData e) { if (QuaternionDataRead != null) QuaternionDataRead(this, e); }

        public delegate void onDigitalIODataRead(object sender, DigitalIOdata e);
        public event onDigitalIODataRead DigitalIODataRead;
        protected virtual void OnDigitalIODataRead(DigitalIOdata e) { if (DigitalIODataRead != null) DigitalIODataRead(this, e); }

        public delegate void onRawAnalogueInputDataRead(object sender, RawAnalogueInputData e);
        public event onRawAnalogueInputDataRead RawAnalogueInputDataRead;
        protected virtual void OnRawAnalogueInputDataRead(RawAnalogueInputData e) { if (RawAnalogueInputDataRead != null) RawAnalogueInputDataRead(this, e); }

        public delegate void onCalAnalogueInputDataRead(object sender, CalAnalogueInputData e);
        public event onCalAnalogueInputDataRead CalAnalogueInputDataRead;
        protected virtual void OnCalAnalogueInputDataRead(CalAnalogueInputData e) { if (CalAnalogueInputDataRead != null) CalAnalogueInputDataRead(this, e); }

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