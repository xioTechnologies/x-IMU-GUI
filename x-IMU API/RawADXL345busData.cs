using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Raw ADXL345 bus data class.
    /// </summary>
    public class RawADXL345busData : xIMUdata
    {
        /// <summary>
        /// Gets or sets raw accelerometer ADC data in lsb. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public short[] ADXL345_A { get; set; }

        /// <summary>
        /// Gets or sets raw accelerometer ADC data in lsb. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public short[] ADXL345_B { get; set; }

        /// <summary>
        /// Gets or sets raw accelerometer ADC data in lsb. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public short[] ADXL345_C { get; set; }

        /// <summary>
        /// Gets or sets raw accelerometer ADC data in lsb. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public short[] ADXL345_D { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="RawADXL345busData"/> class.
        /// </summary>
        public RawADXL345busData()
            : this(new short[3] { 0, 0, 0 }, new short[3] { 0, 0, 0 }, new short[3] { 0, 0, 0 }, new short[3] { 0, 0, 0 })
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RawADXL345busData"/> class.
        /// </summary>
        /// <param name="ADXL345_A">
        /// Raw accelerometer ADC data in lsb. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        /// <param name="ADXL345_B">
        /// Raw accelerometer ADC data in lsb. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        /// <param name="ADXL345_C">
        /// Raw accelerometer ADC data in lsb. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        /// <param name="ADXL345_D">
        /// Raw accelerometer ADC data in lsb. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        public RawADXL345busData(short[] ADXL345_A, short[] ADXL345_B, short[] ADXL345_C, short[] ADXL345_D)
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
            return ADXL345_A[0].ToString() + "," + ADXL345_A[1].ToString() + "," + ADXL345_A[2].ToString() + "," +
                   ADXL345_B[0].ToString() + "," + ADXL345_B[1].ToString() + "," + ADXL345_B[2].ToString() + "," +
                   ADXL345_C[0].ToString() + "," + ADXL345_C[1].ToString() + "," + ADXL345_C[2].ToString() + "," +
                   ADXL345_D[0].ToString() + "," + ADXL345_D[1].ToString() + "," + ADXL345_D[2].ToString();
        }
    }
}