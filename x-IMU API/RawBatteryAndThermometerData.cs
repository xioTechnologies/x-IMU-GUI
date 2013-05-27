using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Raw battery voltage thermometer data class.
    /// </summary>
    public class RawBatteryAndThermometerData : xIMUdata
    {
        /// <summary>
        /// Gets or sets the raw battery voltage ADC data in lsb.
        /// </summary>
        public short BatteryVoltage { get; set; }

        /// <summary>
        /// Gets or sets the raw Thermometer ADC data in lsb.
        /// </summary>
        public short Thermometer { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="RawBatteryAndThermometerData"/> class.
        /// </summary>
        public RawBatteryAndThermometerData()
            : this(0, 0)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RawBatteryAndThermometerData"/> class.
        /// </summary>
        /// <param name="batteryVoltage">
        /// Raw battery voltage ADC data in lsb.
        /// </param>
        /// <param name="thermometer">
        /// Raw Thermometer ADC data in lsb.
        /// </param>        
        public RawBatteryAndThermometerData(short batteryVoltage, short thermometer)
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
            return BatteryVoltage.ToString() + "," + Thermometer.ToString();
        }
    }
}
