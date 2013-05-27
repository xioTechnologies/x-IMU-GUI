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
        #region Variables

        private ushort privErrorCode;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the error code. Must be defined in <see cref="ErrorCodes"/>.
        /// </summary>
        /// <exception cref="System.Exception">
        /// Thrown if invalid error code specifed.
        /// </exception>
        public ushort ErrorCode
        {
            get
            {
                return privErrorCode;
            }
            set
            {
                if (!Enum.IsDefined(typeof(ErrorCodes), (int)value))
                {
                    throw new Exception("Invalid error code.");
                }
                privErrorCode = value;
            }
        }

        #endregion

        #region Constructors

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
            ErrorCode = errorCode;
        }

        #endregion

        #region Methods

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
                case ((int)ErrorCodes.NoError): return "No error.";
                case ((int)ErrorCodes.FactoryResetFailed): return "Factory reset failed.";
                case ((int)ErrorCodes.LowBattery): return "Low battery."; 
                case ((int)ErrorCodes.USBreceiveBufferOverrun): return "USB receive buffer overrun."; 
                case ((int)ErrorCodes.USBtransmitBufferOverrun): return "USB transmit buffer overrun."; 
                case ((int)ErrorCodes.BluetoothReceiveBufferOverrun): return "Bluetooth receive buffer overrun."; 
                case ((int)ErrorCodes.BluetoothTransmitBufferOverrun): return "Bluetooth transmit buffer overrun."; 
                case ((int)ErrorCodes.SDcardWriteBufferOverrun): return "SD card write buffer overrun."; 
                case ((int)ErrorCodes.TooFewBytesInPacket): return "Too few bytes in packet."; 
                case ((int)ErrorCodes.TooManyBytesInPacket): return "Too many bytes in packet."; 
                case ((int)ErrorCodes.InvalidChecksum): return "Invalid checksum."; 
                case ((int)ErrorCodes.UnknownHeader): return "Unknown packet header."; 
                case ((int)ErrorCodes.InvalidNumBytesForPacketHeader): return "Invalid number of bytes for packet header."; 
                case ((int)ErrorCodes.InvalidRegisterAddress): return "Invalid register address."; 
                case ((int)ErrorCodes.RegisterReadOnly): return "Cannot write to read-only register."; 
                case ((int)ErrorCodes.InvalidRegisterValue): return "Invalid register value."; 
                case ((int)ErrorCodes.InvalidCommand): return "Invalid command.";
                case ((int)ErrorCodes.GyroscopeAxisNotAt200dps): return "Gyroscope axis not at 200 ˚/s. Operation aborted.";
                case ((int)ErrorCodes.GyroscopeNotStationary): return "Gyroscope not stationary. Operation aborted.";
                case ((int)ErrorCodes.AcceleroemterAxisNotAt1g): return "Acceleroemter axis not at ±1 g. Operation aborted.";
                case ((int)ErrorCodes.MagnetometerSaturation): return "Magnetometer saturation occurred. Operation aborted."; 
                case ((int)ErrorCodes.IncorrectAuxillaryPortMode): return "Auxiliary port in incorrect mode.";
                default: return "";
            }
        }

        #endregion
    }
}
