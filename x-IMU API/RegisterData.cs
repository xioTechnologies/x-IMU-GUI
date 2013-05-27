using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Register data class.
    /// </summary>
    public class RegisterData : xIMUdata
    {
        #region Variables

        private ushort privAddress;
        private ushort privValue;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the 16-bit register address.  Must be defined in <see cref="RegisterAddresses"/>.
        /// </summary>
        public ushort Address
        {
            get
            {
                return privAddress;
            }
            set
            {
                if (!Enum.IsDefined(typeof(RegisterAddresses), (int)value)) throw new Exception("Invalid register address");
                privAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets the 16-bit register value.
        /// </summary>
        public ushort Value
        {
            get
            {
                return privValue;
            }
            set
            {
                privValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the floating-point representation of 16-bit register value when interpreted as fixed-point.
        /// </summary>
        public float floatValue
        {
            get
            {
                return FixedFloat.FixedToFloat((short)Value, LookupQval());
            }
            set
            {
                privValue = (ushort)FixedFloat.FloatToFixed(value, LookupQval());
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="RegisterData"/> class.
        /// </summary>
        public RegisterData()
            : this(0, 0)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RegisterData"/> class.
        /// </summary>
        /// <param name="address">
        /// 16-bit register address. Must be defined in <see cref="RegisterAddresses"/>.
        /// </param>
        public RegisterData(ushort address)
            : this(address, 0)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RegisterData"/> class.
        /// </summary>
        /// <param name="registerAddress">
        /// Register address. See <see cref="RegisterAddresses"/>.
        /// </param>
        public RegisterData(RegisterAddresses registerAddress)
            : this((ushort)registerAddress, 0)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RegisterData"/> class.
        /// </summary>
        /// <param name="address">
        /// 16-bit register address. Must be defined in <see cref="RegisterAddresses"/>.
        /// </param>
        /// <param name="floatValue">
        /// Floating-point representation of 16-bit fixed-point value.
        /// </param>
        public RegisterData(ushort address, float floatValue)
            : this(address, (ushort)FixedFloat.FloatToFixed(floatValue, LookupQval(address)))
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RegisterData"/> class.
        /// </summary>
        /// <param name="registerAddress">
        /// Register address. See <see cref="RegisterAddresses"/>.
        /// </param>
        /// <param name="floatValue">
        /// Floating-point representation of 16-bit fixed-point value.
        /// </param>
        public RegisterData(RegisterAddresses registerAddress, float floatValue)
            : this((ushort)registerAddress, (ushort)FixedFloat.FloatToFixed(floatValue, LookupQval((ushort)registerAddress)))
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RegisterData"/> class.
        /// </summary>
        /// <param name="address">
        /// 16-bit register address. Must be defined in <see cref="RegisterAddresses"/>.
        /// </param>
        /// <param name="value">
        /// 16-bit register value.
        /// </param>
        public RegisterData(ushort address, ushort value)
        {
            Address = address;
            Value = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns <see cref="Qvals"/> associated with register address.
        /// </summary>
        /// <returns>
        /// <see cref="Qvals"/> associated with register address.
        /// </returns>
        private Qvals LookupQval()
        {
            return LookupQval(Address);
        }

        /// <summary>
        /// Returns <see cref="Qvals"/> associated with specified register address.
        /// </summary>
        /// <param name="address">
        /// Register address.
        /// </param>
        /// <returns>
        /// <see cref="Qvals"/> associated with register address.
        /// </returns>
        /// <exception cref="System.Exception">
        /// Thrown if register address does not have associated <see cref="Qvals"/>.
        /// </exception>
        private static Qvals LookupQval(ushort address)
        {
            switch (address)
            {
                case ((ushort)RegisterAddresses.BattSensitivity): return Qvals.BattSensitivity;
                case ((ushort)RegisterAddresses.BattBias): return Qvals.BattBias;
                case ((ushort)RegisterAddresses.ThermSensitivity): return Qvals.ThermSensitivity;
                case ((ushort)RegisterAddresses.ThermBias): return Qvals.ThermBias;
                case ((ushort)RegisterAddresses.GyroSensitivityX): return Qvals.GyroSensitivity;
                case ((ushort)RegisterAddresses.GyroSensitivityY): return Qvals.GyroSensitivity;
                case ((ushort)RegisterAddresses.GyroSensitivityZ): return Qvals.GyroSensitivity;
                case ((ushort)RegisterAddresses.GyroSampledPlus200dpsX): return Qvals.GyroSampled200dps;
                case ((ushort)RegisterAddresses.GyroSampledPlus200dpsY): return Qvals.GyroSampled200dps;
                case ((ushort)RegisterAddresses.GyroSampledPlus200dpsZ): return Qvals.GyroSampled200dps;
                case ((ushort)RegisterAddresses.GyroSampledMinus200dpsX): return Qvals.GyroSampled200dps;
                case ((ushort)RegisterAddresses.GyroSampledMinus200dpsY): return Qvals.GyroSampled200dps;
                case ((ushort)RegisterAddresses.GyroSampledMinus200dpsZ): return Qvals.GyroSampled200dps;
                case ((ushort)RegisterAddresses.GyroBiasX): return Qvals.GyroBias;
                case ((ushort)RegisterAddresses.GyroBiasY): return Qvals.GyroBias;
                case ((ushort)RegisterAddresses.GyroBiasZ): return Qvals.GyroBias;
                case ((ushort)RegisterAddresses.GyroBiasTempSensX): return Qvals.GyroBiasTempSens;
                case ((ushort)RegisterAddresses.GyroBiasTempSensY): return Qvals.GyroBiasTempSens;
                case ((ushort)RegisterAddresses.GyroBiasTempSensZ): return Qvals.GyroBiasTempSens;
                case ((ushort)RegisterAddresses.GyroSample1Temp): return Qvals.CalibratedTherm;
                case ((ushort)RegisterAddresses.GyroSample1BiasX): return Qvals.GyroBias;
                case ((ushort)RegisterAddresses.GyroSample1BiasY): return Qvals.GyroBias;
                case ((ushort)RegisterAddresses.GyroSample1BiasZ): return Qvals.GyroBias;
                case ((ushort)RegisterAddresses.GyroSample2Temp): return Qvals.CalibratedTherm;
                case ((ushort)RegisterAddresses.GyroSample2BiasX): return Qvals.GyroBias;
                case ((ushort)RegisterAddresses.GyroSample2BiasY): return Qvals.GyroBias;
                case ((ushort)RegisterAddresses.GyroSample2BiasZ): return Qvals.GyroBias;
                case ((ushort)RegisterAddresses.AccelSensitivityX): return Qvals.AccelSensitivity;
                case ((ushort)RegisterAddresses.AccelSensitivityY): return Qvals.AccelSensitivity;
                case ((ushort)RegisterAddresses.AccelSensitivityZ): return Qvals.AccelSensitivity;
                case ((ushort)RegisterAddresses.AccelBiasX): return Qvals.AccelBias;
                case ((ushort)RegisterAddresses.AccelBiasY): return Qvals.AccelBias;
                case ((ushort)RegisterAddresses.AccelBiasZ): return Qvals.AccelBias;
                case ((ushort)RegisterAddresses.AccelSampledPlus1gX): return Qvals.AccelSampled1g;
                case ((ushort)RegisterAddresses.AccelSampledPlus1gY): return Qvals.AccelSampled1g;
                case ((ushort)RegisterAddresses.AccelSampledPlus1gZ): return Qvals.AccelSampled1g;
                case ((ushort)RegisterAddresses.AccelSampledMinus1gX): return Qvals.AccelSampled1g;
                case ((ushort)RegisterAddresses.AccelSampledMinus1gY): return Qvals.AccelSampled1g;
                case ((ushort)RegisterAddresses.AccelSampledMinus1gZ): return Qvals.AccelSampled1g;
                case ((ushort)RegisterAddresses.MagSensitivityX): return Qvals.MagSensitivity;
                case ((ushort)RegisterAddresses.MagSensitivityY): return Qvals.MagSensitivity;
                case ((ushort)RegisterAddresses.MagSensitivityZ): return Qvals.MagSensitivity;
                case ((ushort)RegisterAddresses.MagBiasX): return Qvals.MagBias;
                case ((ushort)RegisterAddresses.MagBiasY): return Qvals.MagBias;
                case ((ushort)RegisterAddresses.MagBiasZ): return Qvals.MagBias;
                case ((ushort)RegisterAddresses.MagHardIronBiasX): return Qvals.MagHardIronBias;
                case ((ushort)RegisterAddresses.MagHardIronBiasY): return Qvals.MagHardIronBias;
                case ((ushort)RegisterAddresses.MagHardIronBiasZ): return Qvals.MagHardIronBias;
                case ((ushort)RegisterAddresses.AlgorithmKp): return Qvals.AlgorithmKp;
                case ((ushort)RegisterAddresses.AlgorithmKi): return Qvals.AlgorithmKi;
                case ((ushort)RegisterAddresses.AlgorithmInitKp): return Qvals.AlgorithmInitKp;
                case ((ushort)RegisterAddresses.AlgorithmInitPeriod): return Qvals.AlgorithmInitPeriod;
                case ((ushort)RegisterAddresses.AlgorithmMinValidMag): return Qvals.CalibratedMag;
                case ((ushort)RegisterAddresses.AlgorithmMaxValidMag): return Qvals.CalibratedMag;
                case ((ushort)RegisterAddresses.AlgorithmTareQuat0): return Qvals.Quaternion;
                case ((ushort)RegisterAddresses.AlgorithmTareQuat1): return Qvals.Quaternion;
                case ((ushort)RegisterAddresses.AlgorithmTareQuat2): return Qvals.Quaternion;
                case ((ushort)RegisterAddresses.AlgorithmTareQuat3): return Qvals.Quaternion;
                case ((ushort)RegisterAddresses.BattShutdownVoltage): return Qvals.CalibratedBatt;
                case ((ushort)RegisterAddresses.AnalogueInputSensitivity): return Qvals.AnalogueInputSensitivity;
                case ((ushort)RegisterAddresses.AnalogueInputBias): return Qvals.AnalogueInputBias;
                case ((ushort)RegisterAddresses.ADXL345AsensitivityX): return Qvals.ADXL345busSensitivity;
                case ((ushort)RegisterAddresses.ADXL345AsensitivityY): return Qvals.ADXL345busSensitivity;
                case ((ushort)RegisterAddresses.ADXL345AsensitivityZ): return Qvals.ADXL345busSensitivity;
                case ((ushort)RegisterAddresses.ADXL345AbiasX): return Qvals.ADXL345busBias;
                case ((ushort)RegisterAddresses.ADXL345AbiasY): return Qvals.ADXL345busBias;
                case ((ushort)RegisterAddresses.ADXL345AbiasZ): return Qvals.ADXL345busBias;
                case ((ushort)RegisterAddresses.ADXL345BsensitivityX): return Qvals.ADXL345busSensitivity;
                case ((ushort)RegisterAddresses.ADXL345BsensitivityY): return Qvals.ADXL345busSensitivity;
                case ((ushort)RegisterAddresses.ADXL345BsensitivityZ): return Qvals.ADXL345busSensitivity;
                case ((ushort)RegisterAddresses.ADXL345BbiasX): return Qvals.ADXL345busBias;
                case ((ushort)RegisterAddresses.ADXL345BbiasY): return Qvals.ADXL345busBias;
                case ((ushort)RegisterAddresses.ADXL345BbiasZ): return Qvals.ADXL345busBias;
                case ((ushort)RegisterAddresses.ADXL345CsensitivityX): return Qvals.ADXL345busSensitivity;
                case ((ushort)RegisterAddresses.ADXL345CsensitivityY): return Qvals.ADXL345busSensitivity;
                case ((ushort)RegisterAddresses.ADXL345CsensitivityZ): return Qvals.ADXL345busSensitivity;
                case ((ushort)RegisterAddresses.ADXL345CbiasX): return Qvals.ADXL345busBias;
                case ((ushort)RegisterAddresses.ADXL345CbiasY): return Qvals.ADXL345busBias;
                case ((ushort)RegisterAddresses.ADXL345CbiasZ): return Qvals.ADXL345busBias;
                case ((ushort)RegisterAddresses.ADXL345DsensitivityX): return Qvals.ADXL345busSensitivity;
                case ((ushort)RegisterAddresses.ADXL345DsensitivityY): return Qvals.ADXL345busSensitivity;
                case ((ushort)RegisterAddresses.ADXL345DsensitivityZ): return Qvals.ADXL345busSensitivity;
                case ((ushort)RegisterAddresses.ADXL345DbiasX): return Qvals.ADXL345busBias;
                case ((ushort)RegisterAddresses.ADXL345DbiasY): return Qvals.ADXL345busBias;
                case ((ushort)RegisterAddresses.ADXL345DbiasZ): return Qvals.ADXL345busBias;
                default: throw new Exception("Register address does not have associated Qval");
            }
        }

        #endregion
    }
}
