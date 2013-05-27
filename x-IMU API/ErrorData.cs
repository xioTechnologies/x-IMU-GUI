using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Error data class.
    /// </summary>
    public class ErrorData : xIMUdata
    {
        /// <summary>
        /// Gets or sets the error code. Must be defined in <see cref="ErrorCodes"/>.
        /// </summary>
        /// <exception cref="System.Exception">
        /// Thrown if invalid error code specifed.
        /// </exception>
        public ErrorCodes ErrorCode { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="ErrorData"/> class.
        /// </summary>
        public ErrorData()
            : this(ErrorCodes.NoError)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="ErrorData"/> class.
        /// </summary>
        /// <param name="errorCode">
        /// Error code. See <see cref="ErrorCodes"/>.
        /// </param>
        public ErrorData(ErrorCodes errorCode)
            : this((ushort)errorCode)
        {
        }

        /// <summary>
        /// Initialises a new instance of the ErrorData class.
        /// </summary>
        /// <param name="errorCode">
        /// Error code. Must be defined in <see cref="ErrorCodes"/>.
        /// </param>
        public ErrorData(ushort errorCode)
        {
            if (!Enum.IsDefined(typeof(ErrorCodes), (int)errorCode))
            {
                throw new Exception("Invalid error code.");
            }
            ErrorCode = (ErrorCodes)errorCode;
        }

        /// <summary>
        /// Message associated with error code.
        /// </summary>
        /// <returns>
        /// Message.
        /// </returns>
        public string GetMessage()
        {
            switch (ErrorCode)
            {
                case (ErrorCodes.NoError): return "No error.";
                case (ErrorCodes.FactoryResetFailed): return "Factory reset failed.";
                case (ErrorCodes.LowBattery): return "Low battery."; 
                case (ErrorCodes.USBreceiveBufferOverrun): return "USB receive buffer overrun."; 
                case (ErrorCodes.USBtransmitBufferOverrun): return "USB transmit buffer overrun."; 
                case (ErrorCodes.BluetoothReceiveBufferOverrun): return "Bluetooth receive buffer overrun."; 
                case (ErrorCodes.BluetoothTransmitBufferOverrun): return "Bluetooth transmit buffer overrun."; 
                case (ErrorCodes.SDcardWriteBufferOverrun): return "SD card write buffer overrun."; 
                case (ErrorCodes.TooFewBytesInPacket): return "Too few bytes in packet."; 
                case (ErrorCodes.TooManyBytesInPacket): return "Too many bytes in packet."; 
                case (ErrorCodes.InvalidChecksum): return "Invalid checksum."; 
                case (ErrorCodes.UnknownHeader): return "Unknown packet header."; 
                case (ErrorCodes.InvalidNumBytesForPacketHeader): return "Invalid number of bytes for packet header."; 
                case (ErrorCodes.InvalidRegisterAddress): return "Invalid register address."; 
                case (ErrorCodes.RegisterReadOnly): return "Cannot write to read-only register."; 
                case (ErrorCodes.InvalidRegisterValue): return "Invalid register value."; 
                case (ErrorCodes.InvalidCommand): return "Invalid command.";
                case (ErrorCodes.GyroscopeAxisNotAt200dps): return "Gyroscope axis not at 200 ˚/s. Operation aborted.";
                case (ErrorCodes.GyroscopeNotStationary): return "Gyroscope not stationary. Operation aborted.";
                case (ErrorCodes.AcceleroemterAxisNotAt1g): return "Acceleroemter axis not at ±1 g. Operation aborted.";
                case (ErrorCodes.MagnetometerSaturation): return "Magnetometer saturation occurred. Operation aborted."; 
                case (ErrorCodes.IncorrectAuxillaryPortMode): return "Auxiliary port in incorrect mode.";
                case (ErrorCodes.UARTreceiveBufferOverrun): return "UART receive buffer overrun.";
                case (ErrorCodes.UARTtransmitBufferOverrun): return "UART transmit buffer overrun."; 
                default: return "";
            }
        }
    }
}
