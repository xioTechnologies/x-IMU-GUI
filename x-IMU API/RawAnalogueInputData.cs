using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Raw analogue input data class.
    /// </summary>
    public class RawAnalogueInputData : xIMUdata
    {
        /// <summary>
        /// Gets or sets raw channel AX0 voltage ADC data in lsb.
        /// </summary>
        public short AX0 { get; set; }

        /// <summary>
        /// Gets or sets raw channel AX1 voltage ADC data in lsb.
        /// </summary>
        public short AX1 { get; set; }

        /// <summary>
        /// Gets or sets raw channel AX2 voltage ADC data in lsb.
        /// </summary>
        public short AX2 { get; set; }

        /// <summary>
        /// Gets or sets raw channel AX3 voltage ADC data in lsb.
        /// </summary>
        public short AX3 { get; set; }

        /// <summary>
        /// Gets or sets raw channel AX4 voltage ADC data in lsb.
        /// </summary>
        public short AX4 { get; set; }

        /// <summary>
        /// Gets or sets raw channel AX5 voltage ADC data in lsb.
        /// </summary>
        public short AX5 { get; set; }

        /// <summary>
        /// Gets or sets raw channel AX6 voltage ADC data in lsb.
        /// </summary>
        public short AX6 { get; set; }

        /// <summary>
        /// Gets or sets raw channel AX7 voltage ADC data in lsb.
        /// </summary>
        public short AX7 { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="RawAnalogueInputData"/> class.
        /// </summary>
        public RawAnalogueInputData()
            : this(0, 0, 0, 0, 0, 0, 0, 0)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RawAnalogueInputData"/> class.
        /// </summary>
        /// <param name="AX0">
        /// Raw channel AX0 voltage ADC data in lsb.
        /// </param>
        /// <param name="AX1">
        /// Raw channel AX1 voltage ADC data in lsb.
        /// </param>
        /// <param name="AX2">
        /// Raw channel AX2 voltage ADC data in lsb.
        /// </param>
        /// <param name="AX3">
        /// Raw channel AX3 voltage ADC data in lsb.
        /// </param>
        /// <param name="AX4">
        /// Raw channel AX4 voltage ADC data in lsb.
        /// </param>
        /// <param name="AX5">
        /// Raw channel AX5 voltage ADC data in lsb.
        /// </param>
        /// <param name="AX6">
        /// Raw channel AX6 voltage ADC data in lsb.
        /// </param>
        /// <param name="AX7">
        /// Raw channel AX7 voltage ADC data in lsb.
        /// </param>
        public RawAnalogueInputData(short _AX0, short _AX1, short _AX2, short _AX3, short _AX4, short _AX5, short _AX6, short _AX7)
        {
            AX0 = _AX0;
            AX1 = _AX1;
            AX2 = _AX2;
            AX3 = _AX3;
            AX4 = _AX4;
            AX5 = _AX5;
            AX6 = _AX6;
            AX7 = _AX7;
        }

        /// <summary>
        /// Converts data to string of Comma Separated Variables.
        /// </summary>
        /// <returns>
        /// CSV text line.
        /// </returns>
        public string ConvertToCSVstring()
        {
            return AX0.ToString() + "," + AX1.ToString() + "," + AX2.ToString() + "," + AX3.ToString() + "," + AX4.ToString() + "," + AX5.ToString() + "," + AX6.ToString() + "," + AX7.ToString();
        }
    }
}
