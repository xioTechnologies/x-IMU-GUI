using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Port data class.
    /// </summary>
    public class DigitalPortBits
    {
        /// <summary>
        /// Gets or sets channel AX0. lsb of 8-bit port.
        /// </summary>
        public bool AX0 { get; set; }

        /// <summary>
        /// Gets or sets channel AX1. 2nd lsb of 8-bit port.
        /// </summary>
        public bool AX1 { get; set; }

        /// <summary>
        /// Gets or sets channel AX2. 3rd lsb of 8-bit port.
        /// </summary>
        public bool AX2 { get; set; }

        /// <summary>
        /// Gets or sets channel AX3. 4th lsb of 8-bit port.
        /// </summary>
        public bool AX3 { get; set; }

        /// <summary>
        /// Gets or sets channel AX4. 5th lsb of 8-bit port.
        /// </summary>
        public bool AX4 { get; set; }

        /// <summary>
        /// Gets or sets channel AX5. 6th lsb of 8-bit port.
        /// </summary>
        public bool AX5 { get; set; }

        /// <summary>
        /// Gets or sets channel AX6. 7th lsb of 8-bit port.
        /// </summary>
        public bool AX6 { get; set; }

        /// <summary>
        /// Gets or sets channel AX7. msb of 8-bit port.
        /// </summary>
        public bool AX7 { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalPortBits"/> class.
        /// </summary>
        public DigitalPortBits()
            : this(false, false, false, false, false, false, false, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalPortBits"/> class.
        /// </summary>
        /// <param name="_AX0">
        /// Channel AX0. lsb of 8-bit port.
        /// </param>
        /// <param name="AX1">
        /// Channel AX1. 2nd lsb of 8-bit port.
        /// </param>
        /// <param name="AX2">
        /// Channel AX2. 3rd lsb of 8-bit port.
        /// </param>
        /// <param name="AX3">
        /// Channel AX3. 4th lsb of 8-bit port.
        /// </param>
        /// <param name="AX4">
        /// Channel AX4. 5th lsb of 8-bit port.
        /// </param>
        /// <param name="AX5">
        /// Channel AX5. 6th lsb of 8-bit port.
        /// </param>
        /// <param name="AX6">
        /// Channel AX6. 7th lsb of 8-bit port.
        /// </param>
        /// <param name="AX7">
        /// Channel AX7. msb of 8-bit port.
        /// </param>
        public DigitalPortBits(bool AX0, bool AX1, bool AX2, bool AX3, bool AX4, bool AX5, bool AX6, bool AX7)
        {
            this.AX0 = AX0;
            this.AX1 = AX1;
            this.AX2 = AX2;
            this.AX3 = AX3;
            this.AX4 = AX4;
            this.AX5 = AX5;
            this.AX6 = AX6;
            this.AX7 = AX7;
        }

        /// <summary>
        /// Convert 8 port bits to byte.
        /// </summary>
        /// <returns>
        /// Byte made up of 8 port bits.
        /// </returns>
        public byte ConvertToByte()
        {
            return (byte)((AX7 ? 0x80 : 0x00) | (AX6 ? 0x40 : 0x00) | (AX5 ? 0x20 : 0x00) | (AX4 ? 0x10 : 0x00) | (AX3 ? 0x08 : 0x00) | (AX2 ? 0x04 : 0x00) | (AX1 ? 0x02 : 0x00) | (AX0 ? 0x01 : 0x00));
        }

        /// <summary>
        /// Sets 8 port bits from byte.
        /// </summary>
        /// <param name="byteValue">
        /// Byte value.
        /// </param>
        public void SetBitsFromByte(byte byteValue)
        {
            AX7 = (byteValue & 0x80) == 0x80;
            AX6 = (byteValue & 0x40) == 0x40;
            AX5 = (byteValue & 0x20) == 0x20;
            AX4 = (byteValue & 0x10) == 0x10;
            AX3 = (byteValue & 0x08) == 0x08;
            AX2 = (byteValue & 0x04) == 0x04;
            AX1 = (byteValue & 0x02) == 0x02;
            AX0 = (byteValue & 0x01) == 0x01;
        }

        /// <summary>
        /// Converts data to string of Comma Separated Variables.
        /// </summary>
        /// <returns>
        /// CSV text line.
        /// </returns>
        public string ConvertToCSVstring()
        {
            return (AX0 ? "1," : "0,") + (AX1 ? "1," : "0,") + (AX2 ? "1," : "0,") + (AX3 ? "1," : "0,") + (AX4 ? "1," : "0,") + (AX5 ? "1," : "0,") + (AX6 ? "1," : "0,") + (AX7 ? "1" : "0");
        }
    }
}
