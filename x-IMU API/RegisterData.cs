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
        /// <summary>
        /// Gets or sets the register address. See <see cref="RegisterAddresses"/>.
        /// </summary>
        public RegisterAddresses Address { get; set; }

        /// <summary>
        /// Gets or sets 16-bit register value.
        /// </summary>
        public ushort Value { get; set; }

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
        /// <param name="registerAddress">
        /// Register address. See <see cref="RegisterAddresses"/>.
        /// </param>
        /// <param name="value">
        /// Register float value to be interpreted using fixed-point precision defined in <see cref="Qvals"/>.
        /// </param>
        public RegisterData(RegisterAddresses registerAddress, float value)
            : this((ushort)registerAddress, 0)
        {
            SetValueFromFloat(value);
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RegisterData"/> class.
        /// </summary>
        /// <param name="registerAddress">
        /// 16-bit register address. Must be defined in <see cref="RegisterAddresses"/>.
        /// </param>
        /// <param name="value">
        /// 16-bit register value.
        /// </param>
        public RegisterData(RegisterAddresses registerAddress, ushort value)
            : this((ushort)registerAddress, value)
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
            if (!Enum.IsDefined(typeof(RegisterAddresses), (int)address))
            {
                throw new Exception("Invalid register address");
            }
            Address = (RegisterAddresses)address;
            Value = value;
        }

        /// <summary>
        /// Converts 16-bit register value to float using fixed-point precision defined in <see cref="Qvals"/>.
        /// </summary>
        /// <returns>
        /// Register value represented as float.
        /// </returns>
        public float ConvertValueToFloat()
        {
            return FixedFloat.FixedToFloat((short)Value, LookupQval());
        }

        /// <summary>
        /// Sets 16-bit register value from float interpreted using fixed-point precision defined in <see cref="Qvals"/>.
        /// </summary>
        /// <param name="floatValue">
        /// Register value represented as float.
        /// </param>
        public void SetValueFromFloat(float floatValue)
        {
            Value = (ushort)FixedFloat.FloatToFixed(floatValue, LookupQval());
        }

        /// <summary>
        /// Returns <see cref="Qvals"/> associated with register address.
        /// </summary>
        /// <returns>
        /// <see cref="Qvals"/> associated with register address.
        /// </returns>
        private Qvals LookupQval()
        {
            switch (Address)
            {
                case (RegisterAddresses.BatterySensitivity): return Qvals.BatterySensitivity;
                case (RegisterAddresses.BatteryBias): return Qvals.BatteryBias;
                case (RegisterAddresses.ThermometerSensitivity): return Qvals.ThermometerSensitivity;
                case (RegisterAddresses.ThermometerBias): return Qvals.ThermometerBias;
                case (RegisterAddresses.GyroscopeSensitivityX): return Qvals.GyroscopeSensitivity;
                case (RegisterAddresses.GyroscopeSensitivityY): return Qvals.GyroscopeSensitivity;
                case (RegisterAddresses.GyroscopeSensitivityZ): return Qvals.GyroscopeSensitivity;
                case (RegisterAddresses.GyroscopeSampledPlus200dpsX): return Qvals.GyroscopeSampled200dps;
                case (RegisterAddresses.GyroscopeSampledPlus200dpsY): return Qvals.GyroscopeSampled200dps;
                case (RegisterAddresses.GyroscopeSampledPlus200dpsZ): return Qvals.GyroscopeSampled200dps;
                case (RegisterAddresses.GyroscopeSampledMinus200dpsX): return Qvals.GyroscopeSampled200dps;
                case (RegisterAddresses.GyroscopeSampledMinus200dpsY): return Qvals.GyroscopeSampled200dps;
                case (RegisterAddresses.GyroscopeSampledMinus200dpsZ): return Qvals.GyroscopeSampled200dps;
                case (RegisterAddresses.GyroscopeBiasAt25degCX): return Qvals.GyroscopeBiasAt25degC;
                case (RegisterAddresses.GyroscopeBiasAt25degCY): return Qvals.GyroscopeBiasAt25degC;
                case (RegisterAddresses.GyroscopeBiasAt25degCZ): return Qvals.GyroscopeBiasAt25degC;
                case (RegisterAddresses.GyroscopeBiasTempSensitivityX): return Qvals.GyroscopeBiasTempSensitivity;
                case (RegisterAddresses.GyroscopeBiasTempSensitivityY): return Qvals.GyroscopeBiasTempSensitivity;
                case (RegisterAddresses.GyroscopeBiasTempSensitivityZ): return Qvals.GyroscopeBiasTempSensitivity;
                case (RegisterAddresses.GyroscopeSample1Temp): return Qvals.CalibratedThermometer;
                case (RegisterAddresses.GyroscopeSample1BiasX): return Qvals.GyroscopeSampledBias;
                case (RegisterAddresses.GyroscopeSample1BiasY): return Qvals.GyroscopeSampledBias;
                case (RegisterAddresses.GyroscopeSample1BiasZ): return Qvals.GyroscopeSampledBias;
                case (RegisterAddresses.GyroscopeSample2Temp): return Qvals.CalibratedThermometer;
                case (RegisterAddresses.GyroscopeSample2BiasX): return Qvals.GyroscopeSampledBias;
                case (RegisterAddresses.GyroscopeSample2BiasY): return Qvals.GyroscopeSampledBias;
                case (RegisterAddresses.GyroscopeSample2BiasZ): return Qvals.GyroscopeSampledBias;
                case (RegisterAddresses.AccelerometerSensitivityX): return Qvals.AccelerometerSensitivity;
                case (RegisterAddresses.AccelerometerSensitivityY): return Qvals.AccelerometerSensitivity;
                case (RegisterAddresses.AccelerometerSensitivityZ): return Qvals.AccelerometerSensitivity;
                case (RegisterAddresses.AccelerometerBiasX): return Qvals.AccelerometerBias;
                case (RegisterAddresses.AccelerometerBiasY): return Qvals.AccelerometerBias;
                case (RegisterAddresses.AccelerometerBiasZ): return Qvals.AccelerometerBias;
                case (RegisterAddresses.AccelerometerSampledPlus1gX): return Qvals.AccelerometerSampled1g;
                case (RegisterAddresses.AccelerometerSampledPlus1gY): return Qvals.AccelerometerSampled1g;
                case (RegisterAddresses.AccelerometerSampledPlus1gZ): return Qvals.AccelerometerSampled1g;
                case (RegisterAddresses.AccelerometerSampledMinus1gX): return Qvals.AccelerometerSampled1g;
                case (RegisterAddresses.AccelerometerSampledMinus1gY): return Qvals.AccelerometerSampled1g;
                case (RegisterAddresses.AccelerometerSampledMinus1gZ): return Qvals.AccelerometerSampled1g;
                case (RegisterAddresses.MagnetometerSensitivityX): return Qvals.MagnetometerSensitivity;
                case (RegisterAddresses.MagnetometerSensitivityY): return Qvals.MagnetometerSensitivity;
                case (RegisterAddresses.MagnetometerSensitivityZ): return Qvals.MagnetometerSensitivity;
                case (RegisterAddresses.MagnetometerBiasX): return Qvals.MagnetometerBias;
                case (RegisterAddresses.MagnetometerBiasY): return Qvals.MagnetometerBias;
                case (RegisterAddresses.MagnetometerBiasZ): return Qvals.MagnetometerBias;
                case (RegisterAddresses.MagnetometerHardIronBiasX): return Qvals.MagnetometerHardIronBias;
                case (RegisterAddresses.MagnetometerHardIronBiasY): return Qvals.MagnetometerHardIronBias;
                case (RegisterAddresses.MagnetometerHardIronBiasZ): return Qvals.MagnetometerHardIronBias;
                case (RegisterAddresses.AlgorithmKp): return Qvals.AlgorithmKp;
                case (RegisterAddresses.AlgorithmKi): return Qvals.AlgorithmKi;
                case (RegisterAddresses.AlgorithmInitKp): return Qvals.AlgorithmInitKp;
                case (RegisterAddresses.AlgorithmInitPeriod): return Qvals.AlgorithmInitPeriod;
                case (RegisterAddresses.AlgorithmMinValidMag): return Qvals.CalibratedMagnetometer;
                case (RegisterAddresses.AlgorithmMaxValidMag): return Qvals.CalibratedMagnetometer;
                case (RegisterAddresses.AlgorithmTareQuat0): return Qvals.Quaternion;
                case (RegisterAddresses.AlgorithmTareQuat1): return Qvals.Quaternion;
                case (RegisterAddresses.AlgorithmTareQuat2): return Qvals.Quaternion;
                case (RegisterAddresses.AlgorithmTareQuat3): return Qvals.Quaternion;
                case (RegisterAddresses.BatteryShutdownVoltage): return Qvals.CalibratedBattery;
                case (RegisterAddresses.AnalogueInputSensitivity): return Qvals.AnalogueInputSensitivity;
                case (RegisterAddresses.AnalogueInputBias): return Qvals.AnalogueInputBias;
                case (RegisterAddresses.ADXL345AsensitivityX): return Qvals.ADXL345busSensitivity;
                case (RegisterAddresses.ADXL345AsensitivityY): return Qvals.ADXL345busSensitivity;
                case (RegisterAddresses.ADXL345AsensitivityZ): return Qvals.ADXL345busSensitivity;
                case (RegisterAddresses.ADXL345AbiasX): return Qvals.ADXL345busBias;
                case (RegisterAddresses.ADXL345AbiasY): return Qvals.ADXL345busBias;
                case (RegisterAddresses.ADXL345AbiasZ): return Qvals.ADXL345busBias;
                case (RegisterAddresses.ADXL345BsensitivityX): return Qvals.ADXL345busSensitivity;
                case (RegisterAddresses.ADXL345BsensitivityY): return Qvals.ADXL345busSensitivity;
                case (RegisterAddresses.ADXL345BsensitivityZ): return Qvals.ADXL345busSensitivity;
                case (RegisterAddresses.ADXL345BbiasX): return Qvals.ADXL345busBias;
                case (RegisterAddresses.ADXL345BbiasY): return Qvals.ADXL345busBias;
                case (RegisterAddresses.ADXL345BbiasZ): return Qvals.ADXL345busBias;
                case (RegisterAddresses.ADXL345CsensitivityX): return Qvals.ADXL345busSensitivity;
                case (RegisterAddresses.ADXL345CsensitivityY): return Qvals.ADXL345busSensitivity;
                case (RegisterAddresses.ADXL345CsensitivityZ): return Qvals.ADXL345busSensitivity;
                case (RegisterAddresses.ADXL345CbiasX): return Qvals.ADXL345busBias;
                case (RegisterAddresses.ADXL345CbiasY): return Qvals.ADXL345busBias;
                case (RegisterAddresses.ADXL345CbiasZ): return Qvals.ADXL345busBias;
                case (RegisterAddresses.ADXL345DsensitivityX): return Qvals.ADXL345busSensitivity;
                case (RegisterAddresses.ADXL345DsensitivityY): return Qvals.ADXL345busSensitivity;
                case (RegisterAddresses.ADXL345DsensitivityZ): return Qvals.ADXL345busSensitivity;
                case (RegisterAddresses.ADXL345DbiasX): return Qvals.ADXL345busBias;
                case (RegisterAddresses.ADXL345DbiasY): return Qvals.ADXL345busBias;
                case (RegisterAddresses.ADXL345DbiasZ): return Qvals.ADXL345busBias;
                default: throw new Exception("Register address does not have associated Qval.");
            }
        }
    }
}