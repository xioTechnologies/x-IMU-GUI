using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
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
        /// Gets or sets the command code.  Must be defined in <see cref="CommandCodes"/>.
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
        /// <returns>
        /// Message.
        /// </returns>
        public string GetMessage()
        {
            switch (CommandCode)
            {
                case ((int)CommandCodes.NullCommand): return "Null command.";
                case ((int)CommandCodes.FactoryReset): return "Factory reset.";
                case ((int)CommandCodes.Reset): return "Reset."; 
                case ((int)CommandCodes.Sleep): return "Sleep."; 
                case ((int)CommandCodes.ResetSleepTimer): return "Reset sleep timer.";
                case ((int)CommandCodes.SampleGyroscopeAxisAt200dps): return "Sample gyroscope axis at ±200 dps.";
                case ((int)CommandCodes.CalcGyroscopeSensitivity): return "Calculate gyroscope sensitivity."; 
                case ((int)CommandCodes.SampleGyroscopeBiasTemp1): return "Sample gyroscope bias at temperature 1."; 
                case ((int)CommandCodes.SampleGyroscopeBiasTemp2): return "Sample gyroscope bias at temperature 2."; 
                case ((int)CommandCodes.CalcGyroscopeBiasParameters): return "Calculate gyroscope bias parameters."; 
                case ((int)CommandCodes.SampleAccelerometerAxisAt1g): return "Sample accelerometer axis at ±1 g.";
                case ((int)CommandCodes.CalcAccelerometerBiasAndSens): return "Calculate accelerometer bias and sensitivity";
                case ((int)CommandCodes.MeasureMagnetometerBiasAndSens): return "Measure magnetometer bias and sensitivity.";
                case ((int)CommandCodes.AlgorithmInitialise): return "Algorithm initialise."; 
                case ((int)CommandCodes.AlgorithmTare): return "Algorithm tare."; 
                case ((int)CommandCodes.AlgorithmClearTare): return "Algorithm clear tare."; 
                case ((int)CommandCodes.AlgorithmInitialiseThenTare): return "Algorithm initialise then tare."; 
                default: return "";
            }
        }

        #endregion
    }
}
