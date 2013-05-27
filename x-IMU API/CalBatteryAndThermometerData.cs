using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace x_IMU_API
{
    /// <summary>
    /// Calibrated battery voltage thermometer data class.
    /// </summary>
    public class CalBatteryAndThermometerData : xIMUdata
    {
        /// <summary>
        /// Gets or sets the calibrated battery voltage data in volts.
        /// </summary>
        public float BatteryVoltage { get; set; }

        /// <summary>
        /// Gets or sets the calibrated thermometer data degrees Celsius.
        /// </summary>
        public float Thermometer { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="CalBatteryAndThermometerData"/> class.
        /// </summary>
        public CalBatteryAndThermometerData()
            : this(0, 0)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="CalBatteryAndThermometerData"/> class.
        /// </summary>
        /// <param name="batteryVoltage">
        /// Calibrated battery voltage data in volts.
        /// </param>
        /// <param name="thermometer">
        /// Calibrated thermometer data degrees Celsius.
        /// </param>
        public CalBatteryAndThermometerData(float batteryVoltage, float thermometer)
        {
            BatteryVoltage = batteryVoltage;
            Thermometer = thermometer;
        }

        /// <summary>
        /// Converts data to string of Comma Separated Variables.
        /// </summary>
        /// <returns>
        /// CSV text line.
        /// </returns>
        public string ConvertToCSVstring()
        {
            return BatteryVoltage.ToString(CultureInfo.InvariantCulture) + "," + Thermometer.ToString(CultureInfo.InvariantCulture);
        }
    }
}
