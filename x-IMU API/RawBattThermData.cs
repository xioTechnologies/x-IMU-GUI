using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xIMU_API
{
    /// <summary>
    /// Raw battery voltage thermometer data class.
    /// </summary>
    public class RawBattThermData : xIMUdata
    {
        #region Variables

        private short privBatteryVoltage;
        private short privThermometer;

        #endregion

        #region Properties

        /// <summary>
        /// Raw battery voltage ADC data in LSBs.
        /// </summary>
        public short BatteryVoltage
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
        /// Raw Thermometer ADC data in LSBs.
        /// </summary>
        public short Thermometer
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
        /// Initialises a new instance of the <see cref="RawBattThermData"/> class.
        /// </summary>
        public RawBattThermData()
            : this(0, 0)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RawBattThermData"/> class.
        /// </summary>
        /// <param name="batteryVoltage">
        /// Raw battery voltage ADC data in LSBs.
        /// </param>
        /// <param name="thermometer">
        /// Raw Thermometer ADC data in LSBs.
        /// </param>        
        public RawBattThermData(short batteryVoltage, short thermometer)
        {
            privBatteryVoltage = batteryVoltage;
            privThermometer = thermometer;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts data to string of Comma Separated Variables.
        /// </summary>
        public string ConvertToCSV()
        {
            return Convert.ToString(BatteryVoltage) + "," + Convert.ToString(Thermometer);
        }

        #endregion
    }
}
