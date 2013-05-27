using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Raw gyroscope, accelerometer and magnetometer data class.
    /// </summary>
    public class RawInertialAndMagneticData : xIMUdata
    {
        /// <summary>
        /// Gets or sets the raw gyroscope ADC data in lsb. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public short[] Gyroscope { get; set; }

        /// <summary>
        /// Gets or sets the raw accelerometer ADC data in lsb. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public short[] Accelerometer { get; set; }

        /// <summary>
        /// Gets or sets the raw magnetometer ADC data in lsb. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public short[] Magnetometer { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="RawInertialAndMagneticData"/> class.
        /// </summary>
        public RawInertialAndMagneticData()
            : this(new short[3] { 0, 0, 0 }, new short[3] { 0, 0, 0 }, new short[3] { 0, 0, 0 })
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RawInertialAndMagneticData"/> class.
        /// </summary>
        /// <param name="gyroscope">
        /// Raw gyroscope ADC data in lsb. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        /// <param name="accelerometer">
        /// Raw accelerometer ADC data in lsb. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>  
        /// <param name="magnetometer">
        /// Raw magnetometer ADC data in lsb. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>  
        public RawInertialAndMagneticData(short[] gyroscope, short[] accelerometer, short[] magnetometer)
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
            return Gyroscope[0].ToString() + "," + Gyroscope[1].ToString() + "," + Gyroscope[2].ToString() + "," +
                   Accelerometer[0].ToString() + "," + Accelerometer[1].ToString() + "," + Accelerometer[2].ToString() + "," +
                   Magnetometer[0].ToString() + "," + Magnetometer[1].ToString() + "," + Magnetometer[2].ToString();
        }
    }
}
