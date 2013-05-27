using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace x_IMU_API
{
    /// <summary>
    /// Calibrated analogue input data class.
    /// </summary>
    public class CalAnalogueInputData : xIMUdata
    {
        /// <summary>
        /// Gets or sets calibrated channel AX0 voltage data in V.
        /// </summary>
        public float AX0 { get; set; }

        /// <summary>
        /// Gets or sets calibrated channel AX1 voltage data in V.
        /// </summary>
        public float AX1 { get; set; }

        /// <summary>
        /// Gets or sets calibrated channel AX2 voltage data in V.
        /// </summary>
        public float AX2 { get; set; }

        /// <summary>
        /// Gets or sets calibrated channel AX3 voltage data in V.
        /// </summary>
        public float AX3 { get; set; }

        /// <summary>
        /// Gets or sets calibrated channel AX4 voltage data in V.
        /// </summary>
        public float AX4 { get; set; }

        /// <summary>
        /// Gets or sets calibrated channel AX5 voltage data in V.
        /// </summary>
        public float AX5 { get; set; }

        /// <summary>
        /// Gets or sets calibrated channel AX6 voltage data in V.
        /// </summary>
        public float AX6 { get; set; }

        /// <summary>
        /// Gets or sets calibrated channel AX7 voltage data in V.
        /// </summary>
        public float AX7 { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="CalAnalogueInputData"/> class.
        /// </summary>
        public CalAnalogueInputData()
            : this(0, 0, 0, 0, 0, 0, 0, 0)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="CalAnalogueInputData"/> class.
        /// </summary>
        /// <param name="AX0">
        /// Calibrated channel AX0 voltage ADC data in V.
        /// </param>
        /// <param name="AX1">
        /// Calibrated channel AX1 voltage ADC data in V.
        /// </param>
        /// <param name="AX2">
        /// Calibrated channel AX2 voltage ADC data in V.
        /// </param>
        /// <param name="AX3">
        /// Calibrated channel AX3 voltage ADC data in V.
        /// </param>
        /// <param name="AX4">
        /// Calibrated channel AX4 voltage ADC data in V.
        /// </param>
        /// <param name="AX5">
        /// Calibrated channel AX5 voltage ADC data in V.
        /// </param>
        /// <param name="AX6">
        /// Calibrated channel AX6 voltage ADC data in V.
        /// </param>
        /// <param name="AX7">
        /// Calibrated channel AX7 voltage ADC data in V.
        /// </param>
        public CalAnalogueInputData(float AX0, float AX1, float AX2, float AX3, float AX4, float AX5, float AX6, float AX7)
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
        /// Converts data to string of Comma Separated Variables.
        /// </summary>
        /// <returns>
        /// CSV text line.
        /// </returns>
        public string ConvertToCSVstring()
        {
            return AX0.ToString(CultureInfo.InvariantCulture) + "," + AX1.ToString(CultureInfo.InvariantCulture) + "," +
                   AX2.ToString(CultureInfo.InvariantCulture) + "," + AX3.ToString(CultureInfo.InvariantCulture) + "," +
                   AX4.ToString(CultureInfo.InvariantCulture) + "," + AX5.ToString(CultureInfo.InvariantCulture) + "," +
                   AX6.ToString(CultureInfo.InvariantCulture) + "," + AX7.ToString(CultureInfo.InvariantCulture);
        }
    }
}
