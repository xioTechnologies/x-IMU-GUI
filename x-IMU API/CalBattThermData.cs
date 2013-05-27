using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Calibrated battery voltage thermometer data class.
    /// </summary>
    public class CalBattThermData : xIMUdata
    {
        #region Variables

        private float privBatteryVoltage;
        private float privThermometer;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the calibrated battery voltage data in volts.
        /// </summary>
        public float BatteryVoltage
        {
            get
            {
                return privBatteryVoltage;
            }
            set
            {
                privBatteryVoltage = value;
            }
        }

        /// <summary>
        /// Gets or sets the calibrated thermometer data degrees Celsius.
        /// </summary>
        public float Thermometer
        {
            get
            {
                return privThermometer;
            }
            set
            {
                privThermometer = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="CalBattThermData"/> class.
        /// </summary>
        public CalBattThermData()
            : this(0, 0)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="CalBattThermData"/> class.
        /// </summary>
        /// <param name="batteryVoltage">
        /// Calibrated battery voltage data in volts.
        /// </param>
        /// <param name="thermometer">
        /// Calibrated thermometer data degrees Celsius.
        /// </param>
        public CalBattThermData(float batteryVoltage, float thermometer)
        {
            privBatteryVoltage = batteryVoltage;
            privThermometer = thermometer;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts data to string of Comma Separated Variables.
        /// </summary>
        /// <returns>
        /// CSV line.
        /// </returns>
        public string ConvertToCSV()
        {
            return Convert.ToString(BatteryVoltage) + "," + Convert.ToString(Thermometer);
        }

        #endregion
    }
}
