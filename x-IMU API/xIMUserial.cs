using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace x_IMU_API
{
    /// <summary>
    /// x-IMU serial class.
    /// </summary>
    public class xIMUserial
    {
        /// <summary>
        /// Private SerialPort object.
        /// </summary>
        private SerialPort serialPort;

        /// <summary>
        /// Private receive buffer.
        /// </summary>
        private byte[] receiveBuffer = new byte[256];

        /// <summary>
        /// Private receive buffer index.
        /// </summary>
        private byte receiveBufferIndex = 0;

        /// <summary>
        /// Gets the number of reception errors.
        /// </summary>
        public int ReceptionErrors { get; private set; }

        /// <summary>
        /// Gets the number of packets read.
        /// </summary>
        public PacketCount PacketsReadCounter { get; private set; }

        /// <summary>
        /// Gets the number of packets written.
        /// </summary>
        public PacketCount PacketsWrittenCounter { get; private set; }

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
        /// Gets a value indicating the open or closed status of the serial port.
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return serialPort.IsOpen;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="xIMUserial"/> class.
        /// </summary>
        public xIMUserial()
            : this("COM1")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="xIMUserial"/> class.
        /// </summary>
        /// <param name="portName">
        /// Name of the port the x-IMU appears as (for example, COM1).
        /// </param>
        public xIMUserial(string portName)
        {
            serialPort = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
            serialPort.Handshake = Handshake.RequestToSend;
            serialPort.ReceivedBytesThreshold = 1;
            serialPort.WriteTimeout = 500;
            serialPort.ReadTimeout = 500;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            ReceptionErrors = 0;
            PacketsReadCounter = new PacketCount();
            PacketsWrittenCounter = new PacketCount();
        }

        /// <summary>
        /// Opens a new serial port communication and resets packet counters.
        /// </summary>
        public void Open()
        {
            PacketsReadCounter.Reset();
            PacketsWrittenCounter.Reset();
            ReceptionErrors = 0;
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
        /// Gets an array of serial port names for the current computer. Invalid characters are removed.
        /// </summary>
        public static string[] GetPortNames()
        {
            string[] portNames = SerialPort.GetPortNames();
            for (int i = 0; i < portNames.Length; i++)
            {
                portNames[i] = "COM" + new string(portNames[i].Where(ch => char.IsDigit(ch)).ToArray());
                if (portNames[i].Length > "COMxxx".Length)
                {
                    portNames[i] = portNames[i].Substring(0, "COMxxx".Length);
                }
            }
            return portNames;
        }

        #region Send methods

        /// <summary>
        /// Sends command packet.
        /// </summary>
        /// <param name="commandCode">
        /// Command data to be sent.
        /// </param> 
        public void SendCommandPacket(CommandCodes commandCode)
        {
            SendByteArray(PacketConstruction.ConstructCommandPacket(commandCode));
            PacketsWrittenCounter.CommandPackets++;
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
            PacketsWrittenCounter.ReadRegisterPackets++;
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
            PacketsWrittenCounter.WriteRegisterPackets++;
        }

        /// <summary>
        /// Sends read date/time packet.
        /// </summary>
        public void SendReadDateTimePacket()
        {
            SendByteArray(PacketConstruction.ConstructReadDateTimePacket());
            PacketsWrittenCounter.ReadDateTimePackets++;
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
            PacketsWrittenCounter.WriteDateTimePackets++;
        }

        /// <summary>
        /// Sends digital IO packet to set digital output states.
        /// </summary>
        /// <param name="digitalIOdata">
        /// Digital IO data representing digital output states to be set.
        /// </param>
        public void SendDigitalIOpacket(DigitalIOdata digitalIOdata)
        {
            SendByteArray(PacketConstruction.ConstructDigitalIOpacket(digitalIOdata));
            PacketsWrittenCounter.DigitalIOdataPackets++;
        }

        /// <summary>
        /// Sends PWM output packet to set PWM duty cycles.
        /// </summary>
        /// <param name="_PWMoutputData">
        /// PWM output data representing PWM duty cycles to be set.
        /// </param>
        public void SendPWMoutputPacket(PWMoutputData _PWMoutputData)
        {
            SendByteArray(PacketConstruction.ConstructPWMoutputPacket(_PWMoutputData));
            PacketsWrittenCounter.PWMoutputDataPackets++;
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
        }

        #endregion

        #region Reception methods

        /// <summary>
        /// Data received event to decode packet and call associated data object received event. Decoding exceptions handled and ignored.
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
                        ReceptionErrors++;                                          // invalid packet
                    }
                    if (dataObject != null)                                         // if packet successfully deconstructed
                    {
                        OnxIMUdataReceived(dataObject);
                        if (dataObject is ErrorData) { OnErrorDataReceived((ErrorData)dataObject); PacketsReadCounter.ErrorPackets++; }
                        else if (dataObject is CommandData) { OnCommandDataReceived((CommandData)dataObject); PacketsReadCounter.CommandPackets++; }
                        else if (dataObject is RegisterData) { OnRegisterDataReceived((RegisterData)dataObject); PacketsReadCounter.WriteRegisterPackets++; }
                        else if (dataObject is DateTimeData) { OnDateTimeDataReceived((DateTimeData)dataObject); PacketsReadCounter.WriteDateTimePackets++; }
                        else if (dataObject is RawBatteryAndThermometerData) { OnRawBatteryAndThermometerDataReceived((RawBatteryAndThermometerData)dataObject); PacketsReadCounter.RawBatteryAndThermometerDataPackets++; }
                        else if (dataObject is CalBatteryAndThermometerData) { OnCalBatteryAndThermometerDataReceived((CalBatteryAndThermometerData)dataObject); PacketsReadCounter.CalBatteryAndThermometerDataPackets++; }
                        else if (dataObject is RawInertialAndMagneticData) { OnRawInertialAndMagneticDataReceived((RawInertialAndMagneticData)dataObject); PacketsReadCounter.RawInertialAndMagneticDataPackets++; }
                        else if (dataObject is CalInertialAndMagneticData) { OnCalInertialAndMagneticDataReceived((CalInertialAndMagneticData)dataObject); PacketsReadCounter.CalInertialAndMagneticDataPackets++; }
                        else if (dataObject is QuaternionData) { OnQuaternionDataReceived((QuaternionData)dataObject); PacketsReadCounter.QuaternionDataPackets++; }
                        else if (dataObject is DigitalIOdata) { OnDigitalIODataReceived((DigitalIOdata)dataObject); PacketsReadCounter.DigitalIOdataPackets++; }
                        else if (dataObject is RawAnalogueInputData) { OnRawAnalogueInputDataReceived((RawAnalogueInputData)dataObject); PacketsReadCounter.RawInertialAndMagneticDataPackets++; }
                        else if (dataObject is CalAnalogueInputData) { OnCalAnalogueInputDataReceived((CalAnalogueInputData)dataObject); PacketsReadCounter.CalAnalogueInputDataPackets++; }
                        else if (dataObject is PWMoutputData) { OnPWMoutputDataReceived((PWMoutputData)dataObject); PacketsReadCounter.PWMoutputDataPackets++; }
                        else if (dataObject is RawADXL345busData) { OnRawADXL345busDataReceived((RawADXL345busData)dataObject); PacketsReadCounter.RawADXL345busDataPackets++; }
                        else if (dataObject is CalADXL345busData) { OnCalADXL345busDataReceived((CalADXL345busData)dataObject); PacketsReadCounter.CalADXL345busDataPackets++; }
                    }
                    receiveBufferIndex = 0;                                         // reset buffer.
                }
            }
        }

        public delegate void onxIMUdataReceived(object sender, xIMUdata e);
        public event onxIMUdataReceived xIMUdataReceived;
        protected virtual void OnxIMUdataReceived(xIMUdata e) { if (xIMUdataReceived != null) xIMUdataReceived(this, e); }

        public delegate void onErrorDataReceived(object sender, ErrorData e);
        public event onErrorDataReceived ErrorDataReceived;
        protected virtual void OnErrorDataReceived(ErrorData e) { if (ErrorDataReceived != null) ErrorDataReceived(this, e); }

        public delegate void onCommandDataReceived(object sender, CommandData e);
        public event onCommandDataReceived CommandDataReceived;
        protected virtual void OnCommandDataReceived(CommandData e) { if (CommandDataReceived != null) CommandDataReceived(this, e); }

        public delegate void onRegisterDataReceived(object sender, RegisterData e);
        public event onRegisterDataReceived RegisterDataReceived;
        protected virtual void OnRegisterDataReceived(RegisterData e) { if (RegisterDataReceived != null) RegisterDataReceived(this, e); }

        public delegate void onDateTimeDataReceived(object sender, DateTimeData e);
        public event onDateTimeDataReceived DateTimeDataReceived;
        protected virtual void OnDateTimeDataReceived(DateTimeData e) { if (DateTimeDataReceived != null) DateTimeDataReceived(this, e); }

        public delegate void onRawBatteryAndThermometerDataReceived(object sender, RawBatteryAndThermometerData e);
        public event onRawBatteryAndThermometerDataReceived RawBatteryAndThermometerDataReceived;
        protected virtual void OnRawBatteryAndThermometerDataReceived(RawBatteryAndThermometerData e) { if (RawBatteryAndThermometerDataReceived != null) RawBatteryAndThermometerDataReceived(this, e); }

        public delegate void onCalBatteryAndThermometerDataReceived(object sender, CalBatteryAndThermometerData e);
        public event onCalBatteryAndThermometerDataReceived CalBatteryAndThermometerDataReceived;
        protected virtual void OnCalBatteryAndThermometerDataReceived(CalBatteryAndThermometerData e) { if (CalBatteryAndThermometerDataReceived != null) CalBatteryAndThermometerDataReceived(this, e); }

        public delegate void onRawInertialAndMagneticDataReceived(object sender, RawInertialAndMagneticData e);
        public event onRawInertialAndMagneticDataReceived RawInertialAndMagneticDataReceived;
        protected virtual void OnRawInertialAndMagneticDataReceived(RawInertialAndMagneticData e) { if (RawInertialAndMagneticDataReceived != null) RawInertialAndMagneticDataReceived(this, e); }

        public delegate void onCalInertialAndMagneticDataReceived(object sender, CalInertialAndMagneticData e);
        public event onCalInertialAndMagneticDataReceived CalInertialAndMagneticDataReceived;
        protected virtual void OnCalInertialAndMagneticDataReceived(CalInertialAndMagneticData e) { if (CalInertialAndMagneticDataReceived != null) CalInertialAndMagneticDataReceived(this, e); }

        public delegate void onQuaternionDataReceived(object sender, QuaternionData e);
        public event onQuaternionDataReceived QuaternionDataReceived;
        protected virtual void OnQuaternionDataReceived(QuaternionData e) { if (QuaternionDataReceived != null) QuaternionDataReceived(this, e); }

        public delegate void onDigitalIODataReceived(object sender, DigitalIOdata e);
        public event onDigitalIODataReceived DigitalIODataReceived;
        protected virtual void OnDigitalIODataReceived(DigitalIOdata e) { if (DigitalIODataReceived != null) DigitalIODataReceived(this, e); }

        public delegate void onRawAnalogueInputDataReceived(object sender, RawAnalogueInputData e);
        public event onRawAnalogueInputDataReceived RawAnalogueInputDataReceived;
        protected virtual void OnRawAnalogueInputDataReceived(RawAnalogueInputData e) { if (RawAnalogueInputDataReceived != null) RawAnalogueInputDataReceived(this, e); }

        public delegate void onCalAnalogueInputDataReceived(object sender, CalAnalogueInputData e);
        public event onCalAnalogueInputDataReceived CalAnalogueInputDataReceived;
        protected virtual void OnCalAnalogueInputDataReceived(CalAnalogueInputData e) { if (CalAnalogueInputDataReceived != null) CalAnalogueInputDataReceived(this, e); }

        public delegate void onPWMoutputDataReceived(object sender, PWMoutputData e);
        public event onPWMoutputDataReceived PWMoutputDataReceived;
        protected virtual void OnPWMoutputDataReceived(PWMoutputData e) { if (PWMoutputDataReceived != null) PWMoutputDataReceived(this, e); }

        public delegate void onRawADXL345busDataReceived(object sender, RawADXL345busData e);
        public event onRawADXL345busDataReceived RawADXL345busDataReceived;
        protected virtual void OnRawADXL345busDataReceived(RawADXL345busData e) { if (RawADXL345busDataReceived != null) RawADXL345busDataReceived(this, e); }

        public delegate void onCalADXL345busDataReceived(object sender, CalADXL345busData e);
        public event onCalADXL345busDataReceived CalADXL345busDataReceived;
        protected virtual void OnCalADXL345busDataReceived(CalADXL345busData e) { if (CalADXL345busDataReceived != null) CalADXL345busDataReceived(this, e); }

        #endregion
    }
}