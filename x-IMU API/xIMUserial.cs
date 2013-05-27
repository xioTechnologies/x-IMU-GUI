using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace xIMU_API
{
    /// <summary>
    /// x-IMU serial class.
    /// </summary>
    public class xIMUserial
    {
        #region Variables

        private SerialPort serialPort;
        private byte[] receiveBuffer = new byte[256];
        private byte receiveBufferIndex = 0;
        private PacketCount privPacketCounter;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the serial port.
        /// </summary>
        public string PortName
        {
            get
            {
                return serialPort.PortName;
            }
            set
            {
                serialPort.PortName = value;
            }
        }

        /// <summary>
        /// Gets a value indicated the open or closed value of the serial port.
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return serialPort.IsOpen;
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
        /// Initializes a new instance of the <see cref="T:xIMUserial"/> class.
        /// </summary>
        public xIMUserial()
            : this("COM1")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:xIMUserial"/> class.
        /// </summary>
        /// <param name="portName">
        /// Name of the port the x-IMU appears as (for example, COM1).
        /// </param>
        public xIMUserial(string portName)
        {
            privPacketCounter = new PacketCount();
            serialPort = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
            serialPort.Handshake = Handshake.RequestToSend;
            serialPort.ReceivedBytesThreshold = 1;
            serialPort.WriteTimeout = 500;
            serialPort.ReadTimeout = 500;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Opens a new serial port communication and resets statistics counters.
        /// </summary>
        public void Open()
        {
            privPacketCounter.Reset();
            receiveBufferIndex = 0;
            serialPort.Open();
            serialPort.DiscardInBuffer();
        }

        /// <summary>
        /// Closes the port connection.
        /// </summary>
        public void Close()
        {
            serialPort.Close();
        }

        /// <summary>
        /// Gets an array of serial port names for the current computer.  Invalid characters are removed.
        /// </summary>
        public static string[] GetPortNames()
        {
            string[] portNames = SerialPort.GetPortNames();
            for (int i = 0; i < portNames.Length; i++)
            {
                portNames[i] = "COM" + new string(portNames[i].Where(ch => char.IsDigit(ch)).ToArray());
            }
            return portNames;
        }

        #endregion

        #region Packet send methods

        /// <summary>
        /// Sends command packet.
        /// </summary>
        /// <param name="commandCode">
        /// Command data to be sent.
        /// </param> 
        public void SendCommandPacket(CommandCodes commandCode)
        {
            SendByteArray(PacketConstruction.ConstructCommandPacket(commandCode));
        }

        /// <summary>
        /// Sends read register packet.
        /// </summary>
        /// <param name="registerData">
        /// Register data containing register address.
        /// </param>
        public void SendReadRegisterPacket(RegisterData registerData)
        {
            SendByteArray(PacketConstruction.ConstructReadRegisterPacket(registerData));
        }

        /// <summary>
        /// Sends write register packet.
        /// </summary>
        /// <param name="registerData">
        /// Register data containing register address and value.
        /// </param>
        public void SendWriteRegisterPacket(RegisterData registerData)
        {
            SendByteArray(PacketConstruction.ConstructWriteRegisterPacket(registerData));
        }

        /// <summary>
        /// Sends read date/time packet.
        /// </summary>
        public void SendReadDateTimePacket()
        {
            SendByteArray(PacketConstruction.ConstructReadDateTimePacket());
        }

        /// <summary>
        /// Sends write date/time packet.
        /// </summary>
        /// <param name="dateTimeData">
        /// Date/time data to be written.
        /// </param>
        public void SendWriteDateTimePacket(DateTimeData dateTimeData)
        {
            SendByteArray(PacketConstruction.ConstructWriteDateTimePacket(dateTimeData));
        }

        /// <summary>
        /// Sends digital IO packet to set digital output states.
        /// </summary>
        /// <param name="digitalIOData">
        /// <see cref="DigitalIOData"/> instance containing output states to be set.
        /// </param>
        public void SendDigitalIOPacket(DigitalIOdata digitalIOData)
        {
            SendByteArray(PacketConstruction.ConstructDigitalIOPacket(digitalIOData));
        }

        /// <summary>
        /// Sends byte array to serial port and increments the sent packets counter.
        /// </summary>
        /// <param name="byteArray">
        /// Byte array to be sent to serial port.
        /// </param>
        private void SendByteArray(byte[] byteArray)
        {
            serialPort.Write(byteArray, 0, byteArray.Length);
            privPacketCounter.TotalPacketsSent++;
        }

        #endregion

        #region Packet reception methods

        /// <summary>
        /// Data received event to decode packet and call associated data object received event.  Decoding exceptions handled and ignored.
        /// </summary>
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int numBytesRead;
            byte[] serialBuffer;

            // Fetch bytes from serial buffer
            try
            {
                numBytesRead = serialPort.BytesToRead;                              // get the number of bytes in the serial buffer
                serialBuffer = new byte[numBytesRead];                              // local array to hold bytes in the serial buffer
                serialPort.Read(serialBuffer, 0, numBytesRead);                     // transfer bytes
            }
            catch
            {
                return;                                                             // return on exception; e.g. serial port closed unexpectedly
            }

            // Process each byte one-by-one
            for (int i = 0; i < numBytesRead; i++)
            {
                receiveBuffer[receiveBufferIndex++] = serialBuffer[i];              // add new byte to buffer
                if ((serialBuffer[i] & 0x80) == 0x80)                               // if new byte was packet framing char 
                {
                    xIMUdata dataObject = null;
                    try
                    {
                        byte[] encodedPacket = new byte[receiveBufferIndex];
                        Array.Copy(receiveBuffer, encodedPacket, encodedPacket.Length);
                        dataObject = PacketConstruction.DeconstructPacket(encodedPacket);
                    }
                    catch
                    {
                        privPacketCounter.PacketsReceivedErrors++;                  // invalid packet
                    }
                    if (dataObject != null)                                         // if packet successfully deconstructed
                    {
                        if (dataObject is ErrorData) { OnErrorMessageReceived((ErrorData)dataObject); privPacketCounter.ErrorPacketsReceived++; }
                        else if (dataObject is CommandData) { OnCommandMessageReceived((CommandData)dataObject); privPacketCounter.CommandPacketsReceived++; }
                        else if (dataObject is RegisterData) { OnRegisterDataReceived((RegisterData)dataObject); privPacketCounter.RegisterDataPacketsReceived++; }
                        else if (dataObject is DateTimeData) { OnDateTimeDataReceived((DateTimeData)dataObject); privPacketCounter.DateTimeDataPacketsReceived++; }
                        else if (dataObject is RawBattThermData) { OnRawBattThermDataReceived((RawBattThermData)dataObject); privPacketCounter.RawBattThermDataPacketsReceived++; }
                        else if (dataObject is CalBattThermData) { OnCalBattThermDataReceived((CalBattThermData)dataObject); privPacketCounter.CalBattThermDataPacketsReceived++; }
                        else if (dataObject is RawInertialMagData) { OnRawInertialMagDataReceived((RawInertialMagData)dataObject); privPacketCounter.RawInertialMagDataPacketsReceived++; }
                        else if (dataObject is CalInertialMagData) { OnCalInertialMagDataReceived((CalInertialMagData)dataObject); privPacketCounter.CalInertialMagDataPacketsReceived++; }
                        else if (dataObject is QuaternionData) { OnQuaternionDataReceived((QuaternionData)dataObject); privPacketCounter.QuaternionDataPacketsReceived++; }
                        else if (dataObject is DigitalIOdata) { OnDigitalIODataReceived((DigitalIOdata)dataObject); privPacketCounter.DigitalIODataPacketsReceived++; }
                        privPacketCounter.TotalPacketsReceived++;
                    }
                    receiveBufferIndex = 0;                                         // reset buffer.
                }
            }
        }

        public delegate void onErrorMessageReceived(object sender, ErrorData e);
        public event onErrorMessageReceived ErrorMessageReceived;
        protected virtual void OnErrorMessageReceived(ErrorData e) { if (ErrorMessageReceived != null) ErrorMessageReceived(this, e); }

        public delegate void onCommandMessageReceived(object sender, CommandData e);
        public event onCommandMessageReceived CommandMessageReceived;
        protected virtual void OnCommandMessageReceived(CommandData e) { if (CommandMessageReceived != null) CommandMessageReceived(this, e); }

        public delegate void onRegisterDataReceived(object sender, RegisterData e);
        public event onRegisterDataReceived RegisterDataReceived;
        protected virtual void OnRegisterDataReceived(RegisterData e) { if (RegisterDataReceived != null) RegisterDataReceived(this, e); }

        public delegate void onDateTimeDataReceived(object sender, DateTimeData e);
        public event onDateTimeDataReceived DateTimeDataReceived;
        protected virtual void OnDateTimeDataReceived(DateTimeData e) { if (DateTimeDataReceived != null) DateTimeDataReceived(this, e); }

        public delegate void onRawBattThermDataReceived(object sender, RawBattThermData e);
        public event onRawBattThermDataReceived RawBattThermDataReceived;
        protected virtual void OnRawBattThermDataReceived(RawBattThermData e) { if (RawBattThermDataReceived != null) RawBattThermDataReceived(this, e); }

        public delegate void onCalBattThermDataReceived(object sender, CalBattThermData e);
        public event onCalBattThermDataReceived CalBattThermDataReceived;
        protected virtual void OnCalBattThermDataReceived(CalBattThermData e) { if (CalBattThermDataReceived != null) CalBattThermDataReceived(this, e); }

        public delegate void onRawInertialMagDataReceived(object sender, RawInertialMagData e);
        public event onRawInertialMagDataReceived RawInertialMagDataReceived;
        protected virtual void OnRawInertialMagDataReceived(RawInertialMagData e) { if (RawInertialMagDataReceived != null) RawInertialMagDataReceived(this, e); }

        public delegate void onCalInertialMagDataReceived(object sender, CalInertialMagData e);
        public event onCalInertialMagDataReceived CalInertialMagDataReceived;
        protected virtual void OnCalInertialMagDataReceived(CalInertialMagData e) { if (CalInertialMagDataReceived != null) CalInertialMagDataReceived(this, e); }

        public delegate void onQuaternionDataReceived(object sender, QuaternionData e);
        public event onQuaternionDataReceived QuaternionDataReceived;
        protected virtual void OnQuaternionDataReceived(QuaternionData e) { if (QuaternionDataReceived != null) QuaternionDataReceived(this, e); }

        public delegate void onDigitalIODataReceived(object sender, DigitalIOdata e);
        public event onDigitalIODataReceived DigitalIODataReceived;
        protected virtual void OnDigitalIODataReceived(DigitalIOdata e) { if (DigitalIODataReceived != null) DigitalIODataReceived(this, e); }

        #endregion
    }
}