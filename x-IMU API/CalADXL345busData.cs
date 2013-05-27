using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Calibrated ADXL345 bus data class.
    /// </summary>
    public class CalADXL345busData : xIMUdata
    {
        #region Variables

        private float[] privADXL345_A;
        private float[] privADXL345_B;
        private float[] privADXL345_C;
        private float[] privADXL345_D;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets calibrated accelerometer data in 'g'.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public float[] ADXL345_A
        {
            get
            {
                return privADXL345_A;
            }
            set
            {
                privADXL345_A = value;
            }
        }

        /// <summary>
        /// Gets or sets calibrated accelerometer data in 'g'.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public float[] ADXL345_B
        {
            get
            {
                return privADXL345_B;
            }
            set
            {
                privADXL345_B = value;
            }
        }

        /// <summary>
        /// Gets or sets calibrated accelerometer data in 'g'.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public float[] ADXL345_C
        {
            get
            {
                return privADXL345_C;
            }
            set
            {
                privADXL345_C = value;
            }
        }

        /// <summary>
        /// Gets or sets calibrated accelerometer data in 'g'.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public float[] ADXL345_D
        {
            get
            {
                return privADXL345_D;
            }
            set
            {
                privADXL345_D = value;
            }
        }

        #endregion

        #region Constructors

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
        /// <param name="_ADXL345_A">
        /// Calibrated accelerometer data in 'g'. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        /// <param name="_ADXL345_B">
        /// Calibrated accelerometer data in 'g'. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        /// <param name="_ADXL345_C">
        /// Calibrated accelerometer data in 'g'. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        /// <param name="_ADXL345_D">
        /// Calibrated accelerometer data in 'g'. Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        public CalADXL345busData(float[] _ADXL345_A, float[] _ADXL345_B, float[] _ADXL345_C, float[] _ADXL345_D)
        {
            ADXL345_A = _ADXL345_A;
            ADXL345_B = _ADXL345_B;
            ADXL345_C = _ADXL345_C;
            ADXL345_D = _ADXL345_D;
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
            return Convert.ToString(ADXL345_A[0]) + "," + Convert.ToString(ADXL345_A[1]) + "," + Convert.ToString(ADXL345_A[2]) + "," +
                   Convert.ToString(ADXL345_B[0]) + "," + Convert.ToString(ADXL345_B[1]) + "," + Convert.ToString(ADXL345_B[2]) + "," +
                   Convert.ToString(ADXL345_C[0]) + "," + Convert.ToString(ADXL345_C[1]) + "," + Convert.ToString(ADXL345_C[2]) + "," +
                   Convert.ToString(ADXL345_D[0]) + "," + Convert.ToString(ADXL345_D[1]) + "," + Convert.ToString(ADXL345_D[2]);
        }

        #endregion
    }
}
