using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xIMU_API
{
    /// <summary>
    /// Digital I/O data class.
    /// </summary>
    public class DigitalIOdata : xIMUdata
    {
        #region Nested PortData class

        /// <summary>
        /// Port data class.
        /// </summary>
        public class PortData
        {
            #region Variables

            private bool[] privPortBits;

            #endregion

            #region Properties

            /// <summary>
            /// Channel AX0.  lsb of 8-bit port.
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
            /// Channel AX1.  2nd lsb of 8-bit port.
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
            /// Channel AX2.  3rd lsb of 8-bit port.
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
            /// Channel AX3.  4th lsb of 8-bit port.
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
            /// Channel AX4.  5th lsb of 8-bit port.
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
            /// Channel AX5.  6th lsb of 8-bit port.
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
            /// Channel AX6.  7th lsb of 8-bit port.
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
            /// Channel AX7.  msb of 8-bit port.
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
            /// 8-bit port value.  bits[0] = AX0 (lsb), bits[7] = AX7 (msb).
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
            /// 8-bit port value.  lsb = AX0, msb = AX7.
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
            /// Initializes a new instance of the <see cref="PortData"/> class.
            /// </summary>
            public PortData()
                : this(0)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="PortData"/> class.
            /// </summary>
            /// <param name="portByte">
            /// 8-bit port value.  lsb = AX0, msb = AX7.
            /// </param>
            public PortData(byte portByte)
            {
                privPortBits = new bool[8];
                PortByte = portByte;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="PortData"/> class.
            /// </summary>
            /// <param name="portBits">
            /// 8-bit port value.  bits[0] = AX0 (lsb), bits[7] = AX7 (msb).
            /// </param>
            public PortData(bool[] portBits)
            {
                privPortBits = portBits;
            }

            #endregion
        }

        #endregion

        #region Variables

        private PortData privDirection;
        private PortData privState;

        #endregion

        #region Properties

        /// <summary>
        /// Direction of the digital I/O port.  true (1) = input, false (0) = output.
        /// </summary>
        public PortData Direction
        {
            get
            {
                return privDirection;
            }
        }

        /// <summary>
        /// State of the digital I/O port.  true (1) = logic high, false (0) = logic low.
        /// </summary>
        public PortData State
        {
            get
            {
                return privState;
            }
            set
            {
                privState = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="DigitalIOdata"/> class.
        /// </summary>
        public DigitalIOdata()
            : this(new PortData(), new PortData())
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="DigitalIOdata"/> class.
        /// </summary>
        /// <param name="state">
        /// State of the digital I/O port.  true (1) = logic high, false (0) = logic low.
        /// </param>
        public DigitalIOdata(PortData state)
            : this(new PortData(), state)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="DigitalIOdata"/> class.
        /// </summary>     
        /// <param name="direction">
        /// Direction of the digital I/O port.  true (1) = input, false (0) = output.
        /// </param>
        /// <param name="state">
        /// State of the digital I/O port.  true (1) = logic high, false (0) = logic low.
        /// </param>
        internal DigitalIOdata(PortData direction, PortData state)
        {
            privDirection = direction;
            privState = state;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts data to string of Comma Separated Variables.
        /// </summary>
        public string ConvertToCSV()
        {
            string CSVline = "";
            for (int i = 0; i < 8; i++)
            {
                CSVline += (privDirection.PortBits[i] ? "1" : "0") + ",";
            }
            for (int i = 0; i < 8; i++)
            {
                CSVline += privState.PortBits[i] ? "1" : "0";
                if (i < 7) CSVline += ",";
            }
            return CSVline;
        }

        #endregion
    }
}
