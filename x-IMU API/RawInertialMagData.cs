using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Raw gyroscope, accelerometer and magnetometer data class.
    /// </summary>
    public class RawInertialMagneticData : xIMUdata
    {
        #region Variables

        private short[] privGyroscope;
        private short[] privAccelerometer;
        private short[] privMagnetometer;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the raw gyroscope ADC data in LSBs.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public short[] Gyroscope
        {
            get
            {
                return privGyroscope;
            }
            set
            {
                privGyroscope = value;
            }
        }

        /// <summary>
        /// Gets or sets the raw accelerometer ADC data in LSBs.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public short[] Accelerometer
        {
            get
            {
                return privAccelerometer;
            }
            set
            {
                privAccelerometer = value;
            }
        }

        /// <summary>
        /// Gets or sets the raw magnetometer ADC data in LSBs.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public short[] Magnetometer
        {
            get
            {
                return privMagnetometer;
            }
            set
            {
                privMagnetometer = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="RawInertialMagneticData"/> class.
        /// </summary>
        public RawInertialMagneticData()
            : this(new short[3] { 0, 0, 0 }, new short[3] { 0, 0, 0 }, new short[3] { 0, 0, 0 })
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RawInertialMagneticData"/> class.
        /// </summary>
        /// <param name="gyroscope">
        /// Raw gyroscope ADC data in LSBs.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        /// <param name="accelerometer">
        /// Raw accelerometer ADC data in LSBs.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>  
        /// <param name="magnetometer">
        /// Raw magnetometer ADC data in LSBs.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>  
        public RawInertialMagneticData(short[] gyroscope, short[] accelerometer, short[] magnetometer)
        {
            Gyroscope = gyroscope;
            Accelerometer = accelerometer;
            Magnetometer = magnetometer;
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
            return Convert.ToString(Gyroscope[0]) + "," + Convert.ToString(Gyroscope[1]) + "," + Convert.ToString(Gyroscope[2]) + "," +
                   Convert.ToString(Accelerometer[0]) + "," + Convert.ToString(Accelerometer[1]) + "," + Convert.ToString(Accelerometer[2]) + "," +
                   Convert.ToString(Magnetometer[0]) + "," + Convert.ToString(Magnetometer[1]) + "," + Convert.ToString(Magnetometer[2]);
        }

        #endregion
    }
}
