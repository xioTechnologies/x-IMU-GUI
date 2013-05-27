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
        #region Variables

        private short[] privADXL345_A;
        private short[] privADXL345_B;
        private short[] privADXL345_C;
        private short[] privADXL345_D;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets raw accelerometer ADC data in LSBs.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public short[] ADXL345_A
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
        /// Gets or sets raw accelerometer ADC data in LSBs.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public short[] ADXL345_B
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
        /// Gets or sets raw accelerometer ADC data in LSBs.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public short[] ADXL345_C
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
        /// Gets or sets raw accelerometer ADC data in LSBs.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </summary>
        public short[] ADXL345_D
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
        /// Initialises a new instance of the <see cref="RawADXL345busData"/> class.
        /// </summary>
        public RawADXL345busData()
            : this(new short[3] { 0, 0, 0 }, new short[3] { 0, 0, 0 }, new short[3] { 0, 0, 0 }, new short[3] { 0, 0, 0 })
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RawADXL345busData"/> class.
        /// </summary>
        /// <param name="_ADXL345_A">
        /// Raw accelerometer ADC data in LSBs.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        /// <param name="_ADXL345_B">
        /// Raw accelerometer ADC data in LSBs.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        /// <param name="_ADXL345_C">
        /// Raw accelerometer ADC data in LSBs.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        /// <param name="_ADXL345_D">
        /// Raw accelerometer ADC data in LSBs.  Elements 0, 1 and 2 represent the sensor x, y and z axes respectively.
        /// </param>
        public RawADXL345busData(short[] _ADXL345_A, short[] _ADXL345_B, short[] _ADXL345_C, short[] _ADXL345_D)
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
