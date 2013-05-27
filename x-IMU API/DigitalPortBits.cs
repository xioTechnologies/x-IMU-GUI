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
        #region Variables

        private bool[] privPortBits;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets channel AX0.  lsb of 8-bit port.
        /// </summary>
        public bool AX0
        {
            get
            {
                return privPortBits[0];
            }
            set
            {
                privPortBits[0] = value;
            }
        }

        /// <summary>
        /// Gets or sets channel AX1.  2nd lsb of 8-bit port.
        /// </summary>
        public bool AX1
        {
            get
            {
                return privPortBits[1];
            }
            set
            {
                privPortBits[1] = value;
            }
        }

        /// <summary>
        /// Gets or sets channel AX2.  3rd lsb of 8-bit port.
        /// </summary>
        public bool AX2
        {
            get
            {
                return privPortBits[2];
            }
            set
            {
                privPortBits[2] = value;
            }
        }

        /// <summary>
        /// Gets or sets channel AX3.  4th lsb of 8-bit port.
        /// </summary>
        public bool AX3
        {
            get
            {
                return privPortBits[3];
            }
            set
            {
                privPortBits[3] = value;
            }
        }

        /// <summary>
        /// Gets or sets channel AX4.  5th lsb of 8-bit port.
        /// </summary>
        public bool AX4
        {
            get
            {
                return privPortBits[4];
            }
            set
            {
                privPortBits[4] = value;
            }
        }

        /// <summary>
        /// Gets or sets channel AX5.  6th lsb of 8-bit port.
        /// </summary>
        public bool AX5
        {
            get
            {
                return privPortBits[5];
            }
            set
            {
                privPortBits[5] = value;
            }
        }

        /// <summary>
        /// Gets or sets channel AX6.  7th lsb of 8-bit port.
        /// </summary>
        public bool AX6
        {
            get
            {
                return privPortBits[6];
            }
            set
            {
                privPortBits[6] = value;
            }
        }

        /// <summary>
        /// Gets or sets channel AX7.  msb of 8-bit port.
        /// </summary>
        public bool AX7
        {
            get
            {
                return privPortBits[7];
            }
            set
            {
                privPortBits[7] = value;
            }
        }

        /// <summary>
        /// Gets or sets 8-bit port value.  bits[0] = AX0 (lsb), bits[7] = AX7 (msb).
        /// </summary>
        public bool[] PortBits
        {
            get
            {
                return privPortBits;
            }
            set
            {
                if (value.Length != 8)
                {
                    throw new Exception("Array must be of length 8.");
                }
                privPortBits = value;
            }
        }

        /// <summary>
        /// Gets or sets 8-bit port value.  lsb = AX0, msb = AX7.
        /// </summary>
        public byte PortByte
        {
            get
            {
                return (byte)((privPortBits[7] ? 0x80 : 0x00) |
                              (privPortBits[6] ? 0x40 : 0x00) |
                              (privPortBits[5] ? 0x20 : 0x00) |
                              (privPortBits[4] ? 0x10 : 0x00) |
                              (privPortBits[3] ? 0x08 : 0x00) |
                              (privPortBits[2] ? 0x04 : 0x00) |
                              (privPortBits[1] ? 0x02 : 0x00) |
                              (privPortBits[0] ? 0x01 : 0x00));
            }
            set
            {
                privPortBits[7] = (value & 0x80) == 0x80;
                privPortBits[6] = (value & 0x40) == 0x40;
                privPortBits[5] = (value & 0x20) == 0x20;
                privPortBits[4] = (value & 0x10) == 0x10;
                privPortBits[3] = (value & 0x08) == 0x08;
                privPortBits[2] = (value & 0x04) == 0x04;
                privPortBits[1] = (value & 0x02) == 0x02;
                privPortBits[0] = (value & 0x01) == 0x01;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalPortBits"/> class.
        /// </summary>
        public DigitalPortBits()
            : this(0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalPortBits"/> class.
        /// </summary>
        /// <param name="portByte">
        /// 8-bit port value.  lsb = AX0, msb = AX7.
        /// </param>
        public DigitalPortBits(byte portByte)
        {
            privPortBits = new bool[8];
            PortByte = portByte;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DigitalPortBits"/> class.
        /// </summary>
        /// <param name="portBits">
        /// 8-bit port value.  bits[0] = AX0 (lsb), bits[7] = AX7 (msb).
        /// </param>
        public DigitalPortBits(bool[] portBits)
        {
            privPortBits = portBits;
        }

        #endregion
    }
}
