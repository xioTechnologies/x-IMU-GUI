using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Calibrated analogue input data class.
    /// </summary>
    public class CalAnalogueInputData : xIMUdata
    {
        #region Variables

        private float[] privAnaloguePort;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets calibrated analogue port data in V.  Elements 0 to 7 correspond to channels AX0 to AX7.
        /// </summary>
        public float[] AnaloguePort
        {
            get
            {
                return privAnaloguePort;
            }
            set
            {
                if (value.Length != 8)
                {
                    throw new Exception("Array must be of length 8.");
                }
                privAnaloguePort = value;
            }
        }

        /// <summary>
        /// Gets or sets calibrated channel AX0 voltage data in V.
        /// </summary>
        public float AX0 { get { return AnaloguePort[0]; } set { AnaloguePort[0] = value; } }

        /// <summary>
        /// Gets or sets calibrated channel AX1 voltage data in V.
        /// </summary>
        public float AX1 { get { return AnaloguePort[1]; } set { AnaloguePort[1] = value; } }

        /// <summary>
        /// Gets or sets calibrated channel AX2 voltage data in V.
        /// </summary>
        public float AX2 { get { return AnaloguePort[2]; } set { AnaloguePort[2] = value; } }

        /// <summary>
        /// Gets or sets calibrated channel AX3 voltage data in V.
        /// </summary>
        public float AX3 { get { return AnaloguePort[3]; } set { AnaloguePort[3] = value; } }

        /// <summary>
        /// Gets or sets calibrated channel AX4 voltage data in V.
        /// </summary>
        public float AX4 { get { return AnaloguePort[4]; } set { AnaloguePort[4] = value; } }

        /// <summary>
        /// Gets or sets calibrated channel AX5 voltage data in V.
        /// </summary>
        public float AX5 { get { return AnaloguePort[5]; } set { AnaloguePort[5] = value; } }

        /// <summary>
        /// Gets or sets calibrated channel AX6 voltage data in V.
        /// </summary>
        public float AX6 { get { return AnaloguePort[6]; } set { AnaloguePort[6] = value; } }

        /// <summary>
        /// Gets or sets calibrated channel AX7 voltage data in V.
        /// </summary>
        public float AX7 { get { return AnaloguePort[7]; } set { AnaloguePort[7] = value; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="CalAnalogueInputData"/> class.
        /// </summary>
        public CalAnalogueInputData()
            : this(new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 })
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="CalAnalogueInputData"/> class.
        /// </summary>
        /// <param name="AX0">
        /// Calibrated channel AX0 voltage ADC data in V.
        /// </param>
        /// <param name="AX1">
        /// Calibrated channel AX1 voltage ADC data in V.
        /// </param>
        /// <param name="AX2">
        /// Calibrated channel AX2 voltage ADC data in V.
        /// </param>
        /// <param name="AX3">
        /// Calibrated channel AX3 voltage ADC data in V.
        /// </param>
        /// <param name="AX4">
        /// Calibrated channel AX4 voltage ADC data in V.
        /// </param>
        /// <param name="AX5">
        /// Calibrated channel AX5 voltage ADC data in V.
        /// </param>
        /// <param name="AX6">
        /// Calibrated channel AX6 voltage ADC data in V.
        /// </param>
        /// <param name="AX7">
        /// Calibrated channel AX7 voltage ADC data in V.
        /// </param>
        public CalAnalogueInputData(float AX0, float AX1, float AX2, float AX3, float AX4, float AX5, float AX6, float AX7)
            : this(new float[8] { AX0, AX1, AX2, AX3, AX4, AX5, AX6, AX7 })
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="CalAnalogueInputData"/> class.
        /// </summary>
        /// <param name="analoguePort">
        /// Calibrated analogue port data in V.  Elements 0 to 7 correspond to channels AX0 to AX7.
        /// </param>
        public CalAnalogueInputData(float[] analoguePort)
        {
            AnaloguePort = analoguePort;
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
            return Convert.ToString(AnaloguePort[0]) + "," + Convert.ToString(AnaloguePort[1]) + "," + Convert.ToString(AnaloguePort[2]) + "," + Convert.ToString(AnaloguePort[3]) + "," +
                   Convert.ToString(AnaloguePort[4]) + "," + Convert.ToString(AnaloguePort[5]) + "," + Convert.ToString(AnaloguePort[6]) + "," + Convert.ToString(AnaloguePort[7]);
        }

        #endregion
    }
}
