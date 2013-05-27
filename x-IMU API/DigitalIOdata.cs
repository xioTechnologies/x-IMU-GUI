using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Digital I/O data class.
    /// </summary>
    public class DigitalIOdata : xIMUdata
    {
        /// <summary>
        /// Gets direction of the digital I/O port. true (1) = input, false (0) = output.
        /// </summary>
        public DigitalPortBits Direction { get; private set;}

        /// <summary>
        /// Gets or sets state of the digital I/O port. true (1) = logic high, false (0) = logic low.
        /// </summary>
        public DigitalPortBits State { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="DigitalIOdata"/> class.
        /// </summary>
        public DigitalIOdata()
            : this(0, 0)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="DigitalIOdata"/> class.
        /// </summary>
        /// <param name="state">
        /// State of the digital I/O port. true (1) = logic high, false (0) = logic low.
        /// </param>
        public DigitalIOdata(DigitalPortBits state)
            : this(0, state.ConvertToByte())
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="DigitalIOdata"/> class.
        /// </summary>     
        /// <param name="direction">
        /// Direction of the digital I/O port. true (1) = input, false (0) = output.
        /// </param>
        /// <param name="state">
        /// State of the digital I/O port. true (1) = logic high, false (0) = logic low.
        /// </param>
        internal DigitalIOdata(byte direction, byte state)
        {
            Direction = new DigitalPortBits();
            Direction.SetBitsFromByte(direction);
            State = new DigitalPortBits();
            State.SetBitsFromByte(state);
        }

        /// <summary>
        /// Converts data to string of Comma Separated Variables.
        /// </summary>
        /// <returns>
        /// CSV text line.
        /// </returns>
        public string ConvertToCSVstring()
        {
            return Direction.ConvertToCSVstring() + "," + State.ConvertToCSVstring();
        }
    }
}
