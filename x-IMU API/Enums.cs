using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    #region Compatible firmware versions

    /// <summary>
    /// Compatible firmware versions.  Only major number required.
    /// </summary>
    public enum CompatibleFirmwareVersions
    {
        v6_x = 6
    }

    #endregion

    #region Packet headers

    /// <summary>
    /// Packet headers.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks>
    internal enum PacketHeaders
    {
        ErrorMessage,
        Command,
        ReadRegister,
        WriteRegister,
        ReadDateTime,
        WriteDateTime,
        RawBattThermData,
        CalBattThermData,
        RawInertialMagData,
        CalInertialMagData,
        QuaternionData,
        DigitalIOdata,
        RawAnalogueInputData,
        CalAnalogueInputData,
        PWMoutputData,
        RawADXL345busData,
        CalADXL345busData,
    }

    #endregion

    #region Error codes

    /// <summary>
    /// Error codes.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    public enum ErrorCodes
    {
        NoError,
        FactoryResetFailed,
        LowBattery,
        USBreceiveBufferOverrun,
        USBtransmitBufferOverrun,
        BluetoothReceiveBufferOverrun,
        BluetoothTransmitBufferOverrun,
        SDcardWriteBufferOverrun,
        TooFewBytesInPacket,
        TooManyBytesInPacket,
        InvalidChecksum,
        UnknownHeader,
        InvalidNumBytesForPacketHeader,
        InvalidRegisterAddress,
        RegisterReadOnly,
        InvalidRegisterValue,
        InvalidCommand,
        GyroscopeAxisNotAt200dps,
        GyroscopeNotStationary,
        AcceleroemterAxisNotAt1g,
        MagnetometerSaturation,
        IncorrectAuxillaryPortMode
    }

    #endregion

    #region Command codes

    /// <summary>
    /// Command codes.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    public enum CommandCodes
    {
        NullCommand,
        FactoryReset,
        Reset,
        Sleep,
        ResetSleepTimer,
        SampleGyroscopeAxisAt200dps,
        CalcGyroscopeSensitivity,
        SampleGyroscopeBiasTemp1,
        SampleGyroscopeBiasTemp2,
        CalcGyroscopeBiasParameters,
        SampleAccelerometerAxisAt1g,
        CalcAccelerometerBiasAndSens,
        MeasureMagnetometerBiasAndSens,
        AlgorithmInitialise,
        AlgorithmTare,
        AlgorithmClearTare,
        AlgorithmInitialiseThenTare
    }

    #endregion

    #region Fixed-point Q values

    /// <summary>
    /// Number of fractional bits used by fixed-point representations.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    internal enum Qvals
    {
        CalibratedBatt = 12,
        CalibratedTherm = 8,
        CalibratedGyro = 4,
        CalibratedAccel = 11,
        CalibratedMag = 11,
        Quaternion = 15,
        BattSensitivity = 5,
        BattBias = 8,
        ThermSensitivity = 6,
        ThermBias = 0,
        GyroSensitivity = 7,
        GyroSampled200dps = 0,
        GyroBias = 6,
        GyroBiasTempSens = 13,
        AccelSensitivity = 4,
        AccelBias = 8,
        AccelSampled1g = 4,
        MagSensitivity = 4,
        MagBias = 8,
        MagHardIronBias = 11,
        AlgorithmKp = 8,
        AlgorithmKi = 14,
        AlgorithmInitKp = 6,
        AlgorithmInitPeriod = 8,
        CalibratedAnalogueInput = 12,
        AnalogueInputSensitivity = 4,
        PWMoutput = 15,
        AnalogueInputBias = 8,
        CalibratedADXL345 = 10,
        ADXL345busSensitivity = 4,
        ADXL345busBias = 8,
    }

    #endregion

    #region Register addresses

    /// <summary>
    /// Register addresses.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    public enum RegisterAddresses
    {
        FirmVersionMajorNum,
        FirmVersionMinorNum,
        DeviceID,
        ButtonMode,
        BattSensitivity,
        BattBias,
        ThermSensitivity,
        ThermBias,
        GyroFullScale,
        GyroSensitivityX,
        GyroSensitivityY,
        GyroSensitivityZ,
        GyroSampledPlus200dpsX,
        GyroSampledPlus200dpsY,
        GyroSampledPlus200dpsZ,
        GyroSampledMinus200dpsX,
        GyroSampledMinus200dpsY,
        GyroSampledMinus200dpsZ,
        GyroBiasX,
        GyroBiasY,
        GyroBiasZ,
        GyroBiasTempSensX,
        GyroBiasTempSensY,
        GyroBiasTempSensZ,
        GyroSample1Temp,
        GyroSample1BiasX,
        GyroSample1BiasY,
        GyroSample1BiasZ,
        GyroSample2Temp,
        GyroSample2BiasX,
        GyroSample2BiasY,
        GyroSample2BiasZ,
        AccelFullScale,
        AccelSensitivityX,
        AccelSensitivityY,
        AccelSensitivityZ,
        AccelBiasX,
        AccelBiasY,
        AccelBiasZ,
        AccelSampledPlus1gX,
        AccelSampledPlus1gY,
        AccelSampledPlus1gZ,
        AccelSampledMinus1gX,
        AccelSampledMinus1gY,
        AccelSampledMinus1gZ,
        MagFullScale,
        MagSensitivityX,
        MagSensitivityY,
        MagSensitivityZ,
        MagBiasX,
        MagBiasY,
        MagBiasZ,
        MagHardIronBiasX,
        MagHardIronBiasY,
        MagHardIronBiasZ,
        AlgorithmMode,
        AlgorithmKp,
        AlgorithmKi,
        AlgorithmInitKp,
        AlgorithmInitPeriod,
        AlgorithmMinValidMag,
        AlgorithmMaxValidMag,
        AlgorithmTareQuat0,
        AlgorithmTareQuat1,
        AlgorithmTareQuat2,
        AlgorithmTareQuat3,
        SensorDataMode,
        DateTimeOutputRate,
        BattThermOutputRate,
        InertialMagOutputRate,
        QuatOutputRate,
        SDcardNewFileName,
        BattShutdownVoltage,
        SleepTimer,
        MotionTrigWakeUp,
        BluetoothPower,
        AuxiliaryPortMode,
        DigitalIOdirection,
        DigitalIOoutputRate,
        AnalogueInputDataMode,
        AnalogueInputDataRate,
        AnalogueInputSensitivity,
        AnalogueInputBias,
        PWMoutputFrequency,
        ADXL345busDataMode,
        ADXL345busDataRate,
        ADXL345AsensitivityX,
        ADXL345AsensitivityY,
        ADXL345AsensitivityZ,
        ADXL345AbiasX,
        ADXL345AbiasY,
        ADXL345AbiasZ,
        ADXL345BsensitivityX,
        ADXL345BsensitivityY,
        ADXL345BsensitivityZ,
        ADXL345BbiasX,
        ADXL345BbiasY,
        ADXL345BbiasZ,
        ADXL345CsensitivityX,
        ADXL345CsensitivityY,
        ADXL345CsensitivityZ,
        ADXL345CbiasX,
        ADXL345CbiasY,
        ADXL345CbiasZ,
        ADXL345DsensitivityX,
        ADXL345DsensitivityY,
        ADXL345DsensitivityZ,
        ADXL345DbiasX,
        ADXL345DbiasY,
        ADXL345DbiasZ,
        NumRegisters
    }

    #endregion

    #region Register values

    /// <summary>
    /// Button mode register values.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    public enum ButtonModes
    {
        Disabled,
        Reset,
        SleepWake,
        AlgorithmInitialise,
        AlgorithmTare,
        AlgorithmInitialiseThenTare
    }

    /// <summary>
    /// Accelerometer full-scale register values.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    public enum GyroscopeFullScales
    {
        FullScalePlusMinus250dps,
        FullScalePlusMinus500dps,
        FullScalePlusMinus1000dps,
        FullScalePlusMinus2000dps
    }

    /// <summary>
    /// Accelerometer full-scale register values.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    public enum AccelerometerFullScales
    {
        PlusMinus2g,
        PlusMinus4g,
        PlusMinus8g
    }

    /// <summary>
    /// Magnetometer full-scale register values.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    public enum MagnetometerFullScales
    {
        PlusMinus1p3G,
        PlusMinus1p9G,
        PlusMinus2p5G,
        PlusMinus4p0G,
        PlusMinus4p7G,
        PlusMinus5p6G,
        PlusMinus8p1G
    }

    /// <summary>
    /// Algorithm mode register values.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    public enum AlgorithmModes
    {
        Disabled,
        IMU,
        AHRS
    }

    /// <summary>
    /// Data mode register values.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    public enum SensorDataModes
    {
        Raw,
        Calibrated,
    }

    /// <summary>
    /// Data output rate register values.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    public enum DataOutputRates
    {
        Disabled,
        Rate1Hz,
        Rate2Hz,
        Rate4Hz,
        Rate8Hz,
        Rate16Hz,
        Rate32Hz,
        Rate64Hz,
        Rate128Hz,
        Rate256Hz
    }

    /// <summary>
    /// Motion triggered wake up mode register values.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    public enum MotionTrigWakeUpModes
    {
        Disabled,
        LowSensitivity,
        HighSensitivity
    }

    /// <summary>
    /// Bluetooth power mode register values.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    public enum BluetoothPowerModes
    {
        Disabled,
        Enabled
    }

    /// <summary>
    /// Auxiliary Port mode register values.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    public enum auxiliaryPortModes
    {
        Disabled,
        DigitalIO,
        AnalogueInput,
        PWMoutput,
        ADXL345bus
    }

    /// <summary>
    /// Digital I/O direction register values.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    public enum DigitalIOdirections
    {
        In01234567,
        In0123456Out7,
        In012345Out67,
        In01234Out567,
        In0123Out4567,
        In012Out34567,
        In01Out234567,
        In0Out1234567,
        Out01234567
    }

    #endregion
}
