using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Raw analogue input data class.
    /// </summary>
    public class RawAnalogueInputData : xIMUdata
    {
        #region Variables

        private short[] privAnaloguePort;

        #endregion

        #region Properties

        /// <summary>
        /// Raw analogue port ADC data in lsb.  Elements 0 to 7 correspond to channels AX0 to AX7.
        /// </summary>
        public short[] AnaloguePort
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
        /// Gets or sets raw channel AX0 voltage ADC data in lsb.
        /// </summary>
        public short AX0 { get { return AnaloguePort[0]; } set { AnaloguePort[0] = value; } }

        /// <summary>
        /// Gets or sets raw channel AX1 voltage ADC data in lsb.
        /// </summary>
        public short AX1 { get { return AnaloguePort[1]; } set { AnaloguePort[1] = value; } }

        /// <summary>
        /// Gets or sets raw channel AX2 voltage ADC data in lsb.
        /// </summary>
        public short AX2 { get { return AnaloguePort[2]; } set { AnaloguePort[2] = value; } }

        /// <summary>
        /// Gets or sets raw channel AX3 voltage ADC data in lsb.
        /// </summary>
        public short AX3 { get { return AnaloguePort[3]; } set { AnaloguePort[3] = value; } }

        /// <summary>
        /// Gets or sets raw channel AX4 voltage ADC data in lsb.
        /// </summary>
        public short AX4 { get { return AnaloguePort[4]; } set { AnaloguePort[4] = value; } }

        /// <summary>
        /// Gets or sets raw channel AX5 voltage ADC data in lsb.
        /// </summary>
        public short AX5 { get { return AnaloguePort[5]; } set { AnaloguePort[5] = value; } }

        /// <summary>
        /// Gets or sets raw channel AX6 voltage ADC data in lsb.
        /// </summary>
        public short AX6 { get { return AnaloguePort[6]; } set { AnaloguePort[6] = value; } }

        /// <summary>
        /// Gets or sets raw channel AX7 voltage ADC data in lsb.
        /// </summary>
        public short AX7 { get { return AnaloguePort[7]; } set { AnaloguePort[7] = value; } }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="RawAnalogueInputData"/> class.
        /// </summary>
        public RawAnalogueInputData()
            : this(new short[8] { 0, 0, 0, 0, 0, 0, 0, 0 })
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RawAnalogueInputData"/> class.
        /// </summary>
        /// <param name="AX0">
        /// Raw channel AX0 voltage ADC data in lsb.
        /// </param>
        /// <param name="AX1">
        /// Raw channel AX1 voltage ADC data in lsb.
        /// </param>
        /// <param name="AX2">
        /// Raw channel AX2 voltage ADC data in lsb.
        /// </param>
        /// <param name="AX3">
        /// Raw channel AX3 voltage ADC data in lsb.
        /// </param>
        /// <param name="AX4">
        /// Raw channel AX4 voltage ADC data in lsb.
        /// </param>
        /// <param name="AX5">
        /// Raw channel AX5 voltage ADC data in lsb.
        /// </param>
        /// <param name="AX6">
        /// Raw channel AX6 voltage ADC data in lsb.
        /// </param>
        /// <param name="AX7">
        /// Raw channel AX7 voltage ADC data in lsb.
        /// </param>
        public RawAnalogueInputData(short AX0, short AX1, short AX2, short AX3, short AX4, short AX5, short AX6, short AX7)
            : this(new short[8] { AX0, AX1, AX2, AX3, AX4, AX5, AX6, AX7 })
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RawAnalogueInputData"/> class.
        /// </summary>
        /// <param name="analoguePort">
        /// Raw analogue port ADC data in lsb.  Elements 0 to 7 correspond to channels AX0 to AX7.
        /// </param>
        public RawAnalogueInputData(short[] analoguePort)
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
