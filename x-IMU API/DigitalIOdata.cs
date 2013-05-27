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
        #region Variables

        private DigitalPortBits privDirection;
        private DigitalPortBits privState;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets direction of the digital I/O port.  true (1) = input, false (0) = output.
        /// </summary>
        public DigitalPortBits Direction
        {
            get
            {
                return privDirection;
            }
        }

        /// <summary>
        /// Gets or sets state of the digital I/O port.  true (1) = logic high, false (0) = logic low.
        /// </summary>
        public DigitalPortBits State
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
            : this(new DigitalPortBits(), new DigitalPortBits())
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="DigitalIOdata"/> class.
        /// </summary>
        /// <param name="state">
        /// State of the digital I/O port.  true (1) = logic high, false (0) = logic low.
        /// </param>
        public DigitalIOdata(DigitalPortBits state)
            : this(new DigitalPortBits(), state)
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
        internal DigitalIOdata(DigitalPortBits direction, DigitalPortBits state)
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
