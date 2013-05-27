using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace xIMU_API
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
        /// Initializes a new instance of the <see cref="T:xIMUfile"/> class. Opens or creates file.
        /// </summary>
        /// <param name="filePath">
        /// Path of file.
        /// </param>
        public xIMUfile(string filePath)
            : this(filePath, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:xIMUfile"/> class.
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
        /// Reads file.  Interpreted packets are provided in individual packet read events.
        /// </summary>
        public void Read()
        {
            byte[] readBuffer = new byte[256];
            byte readBufferIndex = 0;

            // Read the source file into a byte array.
            byte[] fileBuffer = new byte[fileStream.Length];
            int numBytesToRead = (int)fileStream.Length;
            int numBytesRead = 0;
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
                        if (dataObject is ErrorData) { OnErrorMessageRead((ErrorData)dataObject); privPacketCounter.ErrorPacketsRead++; }
                        else if (dataObject is CommandData) { OnCommandMessageRead((CommandData)dataObject); privPacketCounter.CommandPacketsRead++; }
                        else if (dataObject is RegisterData) { OnRegisterDataRead((RegisterData)dataObject); privPacketCounter.RegisterDataPacketsRead++; }
                        else if (dataObject is DateTimeData) { OnDateTimeDataRead((DateTimeData)dataObject); privPacketCounter.DateTimeDataPacketsRead++; }
                        else if (dataObject is RawBattThermData) { OnRawBattThermDataRead((RawBattThermData)dataObject); privPacketCounter.RawBattThermDataPacketsRead++; }
                        else if (dataObject is CalBattThermData) { OnCalBattThermDataRead((CalBattThermData)dataObject); privPacketCounter.CalBattThermDataPacketsRead++; }
                        else if (dataObject is RawInertialMagData) { OnRawInertialMagDataRead((RawInertialMagData)dataObject); privPacketCounter.RawInertialMagDataPacketsRead++; }
                        else if (dataObject is CalInertialMagData) { OnCalInertialMagDataRead((CalInertialMagData)dataObject); privPacketCounter.CalInertialMagDataPacketsRead++; }
                        else if (dataObject is QuaternionData) { OnQuaternionDataRead((QuaternionData)dataObject); privPacketCounter.QuaternionDataPacketsRead++; }
                        else if (dataObject is DigitalIOdata) { OnDigitalIODataRead((DigitalIOdata)dataObject); privPacketCounter.DigitalIODataPacketsRead++; }
                        privPacketCounter.TotalPacketsRead++;
                    }
                    readBufferIndex = 0;                                            // reset buffer.
                }
            }
        }

        public delegate void onxIMUdataRead(object sender, xIMUdata e);
        public event onxIMUdataRead xIMUdataRead;
        protected virtual void OnxIMUdataRead(xIMUdata e) { if (xIMUdataRead != null) xIMUdataRead(this, e); }

        public delegate void onErrorMessageRead(object sender, ErrorData e);
        public event onErrorMessageRead ErrorMessageRead;
        protected virtual void OnErrorMessageRead(ErrorData e) { if (ErrorMessageRead != null) ErrorMessageRead(this, e); }

        public delegate void onCommandMessageRead(object sender, CommandData e);
        public event onCommandMessageRead CommandMessageRead;
        protected virtual void OnCommandMessageRead(CommandData e) { if (CommandMessageRead != null) CommandMessageRead(this, e); }

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

        public delegate void onRawInertialMagDataRead(object sender, RawInertialMagData e);
        public event onRawInertialMagDataRead RawInertialMagDataRead;
        protected virtual void OnRawInertialMagDataRead(RawInertialMagData e) { if (RawInertialMagDataRead != null) RawInertialMagDataRead(this, e); }

        public delegate void onCalInertialMagDataRead(object sender, CalInertialMagData e);
        public event onCalInertialMagDataRead CalInertialMagDataRead;
        protected virtual void OnCalInertialMagDataRead(CalInertialMagData e) { if (CalInertialMagDataRead != null) CalInertialMagDataRead(this, e); }

        public delegate void onQuaternionDataRead(object sender, QuaternionData e);
        public event onQuaternionDataRead QuaternionDataRead;
        protected virtual void OnQuaternionDataRead(QuaternionData e) { if (QuaternionDataRead != null) QuaternionDataRead(this, e); }

        public delegate void onDigitalIODataRead(object sender, DigitalIOdata e);
        public event onDigitalIODataRead DigitalIODataRead;
        protected virtual void OnDigitalIODataRead(DigitalIOdata e) { if (DigitalIODataRead != null) DigitalIODataRead(this, e); }

        #endregion
    }
}