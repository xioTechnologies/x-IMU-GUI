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
        /// <summary>
        /// Gets or sets the command code. See <see cref="CommandCodes"/>.
        /// </summary>
        public CommandCodes CommandCode { get; set; }

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
        /// 16-bit command code. Must be defined in <see cref="CommandCodes"/>.
        /// </param>
        public CommandData(ushort commandCode)
        {
            if (!Enum.IsDefined(typeof(CommandCodes), (int)commandCode))
            {
                throw new Exception("Invalid command code.");
            }
            CommandCode = (CommandCodes)commandCode;
        }

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
                case (CommandCodes.NullCommand): return "Null command.";
                case (CommandCodes.FactoryReset): return "Factory reset.";
                case (CommandCodes.Reset): return "Reset.";
                case (CommandCodes.Sleep): return "Sleep.";
                case (CommandCodes.ResetSleepTimer): return "Reset sleep timer.";
                case (CommandCodes.SampleGyroscopeAxisAt200dps): return "Sample gyroscope axis at ±200 dps.";
                case (CommandCodes.CalculateGyroscopeSensitivity): return "Calculate gyroscope sensitivity.";
                case (CommandCodes.SampleGyroscopeBiasTemp1): return "Sample gyroscope bias at temperature 1.";
                case (CommandCodes.SampleGyroscopeBiasTemp2): return "Sample gyroscope bias at temperature 2.";
                case (CommandCodes.CalculateGyroscopeBiasParameters): return "Calculate gyroscope bias parameters.";
                case (CommandCodes.SampleAccelerometerAxisAt1g): return "Sample accelerometer axis at ±1 g.";
                case (CommandCodes.CalculateAccelerometerBiasAndSensitivity): return "Calculate accelerometer bias and sensitivity";
                case (CommandCodes.MeasureMagnetometerBiasAndSensitivity): return "Measure magnetometer bias and sensitivity.";
                case (CommandCodes.AlgorithmInitialise): return "Algorithm initialise.";
                case (CommandCodes.AlgorithmTare): return "Algorithm tare.";
                case (CommandCodes.AlgorithmClearTare): return "Algorithm clear tare.";
                case (CommandCodes.AlgorithmInitialiseThenTare): return "Algorithm initialise then tare.";
                default: return "";
            }
        }
    }
}
