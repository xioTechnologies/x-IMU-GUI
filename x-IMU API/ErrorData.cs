using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xIMU_API
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
        public string GetMessage()
        {
            string message = "Unknown error.";
            switch (ErrorCode)
            {
                case ((int)ErrorCodes.NoError): message = "No error."; break;
                case ((int)ErrorCodes.LowBattery): message = "Low battery."; break;
                case ((int)ErrorCodes.USBreceiveBufferOverrun): message = "USB receive buffer overrun."; break;
                case ((int)ErrorCodes.USBtransmitBufferOverrun): message = "USB transmit buffer overrun."; break;
                case ((int)ErrorCodes.BluetoothReceiveBufferOverrun): message = "Bluetooth receive buffer overrun."; break;
                case ((int)ErrorCodes.BluetoothTransmitBufferOverrun): message = "Bluetooth transmit buffer overrun."; break;
                case ((int)ErrorCodes.SDcardWriteBufferOverrun): message = "SD card write buffer overrun."; break;
                case ((int)ErrorCodes.TooFewBytesInPacket): message = "Too few bytes in packet."; break;
                case ((int)ErrorCodes.TooManyBytesInPacket): message = "Too many bytes in packet."; break;
                case ((int)ErrorCodes.InvalidChecksum): message = "Invalid checksum."; break;
                case ((int)ErrorCodes.UnknownHeader): message = "Unknown packet header."; break;
                case ((int)ErrorCodes.InvalidNumBytesForPacketHeader): message = "Invalid number of bytes for packet header."; break;
                case ((int)ErrorCodes.InvalidRegisterAddress): message = "Invalid register address."; break;
                case ((int)ErrorCodes.RegisterReadOnly): message = "Cannot write to read-only register."; break;
                case ((int)ErrorCodes.InvalidRegisterValue): message = "Invalid register value."; break;
                case ((int)ErrorCodes.InvalidCommand): message = "Invalid command."; break;
                case ((int)ErrorCodes.GyroscopeNotStationary): message = "Gyroscope not stationary. Calibration aborted."; break;
                case ((int)ErrorCodes.MagnetometerSaturation): message = "Magnetometer saturation occurred. Calibration aborted."; break;
                case ((int)ErrorCodes.IncorrectAuxillaryPortMode): message = "Auxiliary port in incorrect mode."; break;
                default: break;
            }
            return message;
        }

        #endregion
    }
}
