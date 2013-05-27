using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace x_IMU_API
{
    /// <summary>
    /// Calibrated ADXL345 bus data class.
    /// </summary>
    public class CalADXL345busData : xIMUdata
    {
        /// <summary>
        /// Gets or sets calibrated accelerometer data in 'g'. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public float[] ADXL345_A { get; set; }

        /// <summary>
        /// Gets or sets calibrated accelerometer data in 'g'. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public float[] ADXL345_B { get; set; }

        /// <summary>
        /// Gets or sets calibrated accelerometer data in 'g'. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public float[] ADXL345_C { get; set; }

        /// <summary>
        /// Gets or sets calibrated accelerometer data in 'g'. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public float[] ADXL345_D { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="CalADXL345busData"/> class.
        /// </summary>
        public CalADXL345busData()
            : this(new float[3] { 0, 0, 0 }, new float[3] { 0, 0, 0 }, new float[3] { 0, 0, 0 }, new float[3] { 0, 0, 0 })
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="CalADXL345busData"/> class.
        /// </summary>
        /// <param name="ADXL345_A">
        /// Calibrated accelerometer data in 'g'. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        /// <param name="ADXL345_B">
        /// Calibrated accelerometer data in 'g'. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        /// <param name="ADXL345_C">
        /// Calibrated accelerometer data in 'g'. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        /// <param name="ADXL345_D">
        /// Calibrated accelerometer data in 'g'. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        public CalADXL345busData(float[] ADXL345_A, float[] ADXL345_B, float[] ADXL345_C, float[] ADXL345_D)
        {
            this.ADXL345_A = ADXL345_A;
            this.ADXL345_B = ADXL345_B;
            this.ADXL345_C = ADXL345_C;
            this.ADXL345_D = ADXL345_D;
        }

        /// <summary>
        /// Converts data to string of Comma Separated Variables.
        /// </summary>
        /// <returns>
        /// CSV text line.
        /// </returns>
        public string ConvertToCSVstring()
        {
            return ADXL345_A[0].ToString(CultureInfo.InvariantCulture) + "," + ADXL345_A[1].ToString(CultureInfo.InvariantCulture) + "," + ADXL345_A[2].ToString(CultureInfo.InvariantCulture) + "," +
                   ADXL345_B[0].ToString(CultureInfo.InvariantCulture) + "," + ADXL345_B[1].ToString(CultureInfo.InvariantCulture) + "," + ADXL345_B[2].ToString(CultureInfo.InvariantCulture) + "," +
                   ADXL345_C[0].ToString(CultureInfo.InvariantCulture) + "," + ADXL345_C[1].ToString(CultureInfo.InvariantCulture) + "," + ADXL345_C[2].ToString(CultureInfo.InvariantCulture) + "," +
                   ADXL345_D[0].ToString(CultureInfo.InvariantCulture) + "," + ADXL345_D[1].ToString(CultureInfo.InvariantCulture) + "," + ADXL345_D[2].ToString(CultureInfo.InvariantCulture);
        }
    }
}
