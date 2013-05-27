using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xIMU_API
{
    /// <summary>
    /// Command data class.
    /// </summary>
    public class CommandData : xIMUdata
    {
        #region Variables

        private ushort privCommandCode;

        #endregion

        #region Properties

        /// <summary>
        /// Command code.  Must be defined in <see cref="CommandCodes"/>.
        /// </summary>
        /// <exception cref="System.Exception">
        /// Thrown if invalid command code specifed.
        /// </exception>
        public ushort CommandCode
        {
            get
            {
                return privCommandCode;
            }
            set
            {
                if (!Enum.IsDefined(typeof(CommandCodes), (int)value))
                {
                    throw new Exception("Invalid command code.");
                }
                privCommandCode = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="CommandData"/> class.
        /// </summary>
        public CommandData()
            : this(CommandCodes.NullCommand)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="CommandData"/> class.
        /// </summary>
        /// <param name="commandCode">
        /// Command code. See <see cref="CommandCodes"/>.
        /// </param>
        public CommandData(CommandCodes commandCode)
            : this((ushort)commandCode)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="CommandData"/> class.
        /// </summary>
        /// <param name="commandCode">
        /// Command code. Must be defined in <see cref="CommandCodes"/>.
        /// </param>
        public CommandData(ushort commandCode)
        {
            privCommandCode = commandCode;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets message associated with command code.
        /// </summary>
        public string GetMessage()
        {
            string message = "Unknown command.";
            switch (CommandCode)
            {
                case ((int)CommandCodes.ResetDevice): message = "Device reset."; break;
                case ((int)CommandCodes.Sleep): message = "Device sleep."; break;
                case ((int)CommandCodes.ResetSleepTimer): message = "Reset sleep timer."; break;
                case ((int)CommandCodes.SampleGyroBiasTemp1): message = "Sample gyroscope bias at temperature 1 sucsesful."; break;
                case ((int)CommandCodes.SampleGyroBiasTemp2): message = "Sample gyroscope bias at temperature 2."; break;
                case ((int)CommandCodes.CalcGyroBiasParams): message = "Calculate gyroscope bias parameters."; break;
                case ((int)CommandCodes.MeasureMagBiasAndSens): message = "Measure magnetometer bias and sensitivity."; break;
                case ((int)CommandCodes.LookupAccelBiasAndSens): message = "Lookup accelerometer bias and sensitivity."; break;
                case ((int)CommandCodes.ResetAlgorithm): message = "Reset algorithm."; break;
                case ((int)CommandCodes.Tare): message = "Tare."; break;
                case ((int)CommandCodes.ClearTare): message = "Clear tare."; break;
                default: break;
            }
            return message;
        }

        #endregion
    }
}
