using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace x_IMU_API
{
    /// <summary>
    /// Calibrated gyroscope, accelerometer and magnetometer data class.
    /// </summary>
    public class CalInertialAndMagneticData : xIMUdata
    {
        /// <summary>
        /// Gets or sets the calibrated gyroscope data in degrees per second. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public float[] Gyroscope { get; set; }

        /// <summary>
        /// Gets or sets the calibrated accelerometer data in 'g'. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public float[] Accelerometer { get; set; }

        /// <summary>
        /// Gets or sets the calibrated magnetometer data in Gauss. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public float[] Magnetometer { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="CalInertialAndMagneticData"/> class.
        /// </summary>
        public CalInertialAndMagneticData()
            : this(new float[3] { 0, 0, 0 }, new float[3] { 0, 0, 0 }, new float[3] { 0, 0, 0 })
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="CalInertialAndMagneticData"/> class.
        /// </summary>
        /// <param name="gyroscope">
        /// Calibrated gyroscope data in degrees per second. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        /// <param name="accelerometer">
        /// Calibrated accelerometer data in 'g'. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>  
        /// <param name="magnetometer">
        /// Calibrated magnetometer data in Gauss. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>  
        public CalInertialAndMagneticData(float[] gyroscope, float[] accelerometer, float[] magnetometer)
        {
            Gyroscope = gyroscope;
            Accelerometer = accelerometer;
            Magnetometer = magnetometer;
        }

        /// <summary>
        /// Converts data to string of Comma Separated Variables.
        /// </summary>
        /// <returns>
        /// CSV text line.
        /// </returns>
        public string ConvertToCSVstring()
        {
            return Gyroscope[0].ToString(CultureInfo.InvariantCulture) + "," + Gyroscope[1].ToString(CultureInfo.InvariantCulture) + "," + Gyroscope[2].ToString(CultureInfo.InvariantCulture) + "," +
                   Accelerometer[0].ToString(CultureInfo.InvariantCulture) + "," + Accelerometer[1].ToString(CultureInfo.InvariantCulture) + "," + Accelerometer[2].ToString(CultureInfo.InvariantCulture) + "," +
                   Magnetometer[0].ToString(CultureInfo.InvariantCulture) + "," + Magnetometer[1].ToString(CultureInfo.InvariantCulture) + "," + Magnetometer[2].ToString(CultureInfo.InvariantCulture);
        }
    }
}
