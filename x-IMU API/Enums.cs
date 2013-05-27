using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xIMU_API
{
    #region Compatible firmware versions

    /// <summary>
    /// Compatible firmware versions.  Only major number required.
    /// </summary>
    public enum CompatibleFirmwareVersions
    {
        v4_x = 4
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
        DigitalIOData
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
        LowBattery,
        USBreceiveBufferOvun,
        USBtransmitBufferOvun,
        BluetoothReceiveBufferOvun,
        BluetoothTransmitBufferOvun,
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
        GyroscopeNotStationary,
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
        ResetDevice,
        Sleep,
        ResetSleepTimer,
        SampleGyroBiasTemp1,
        SampleGyroBiasTemp2,
        CalcGyroBiasParams,
        LookupAccelBiasAndSens,
        MeasureMagBiasAndSens,
        ResetAlgorithm,
        Tare,
        ClearTare
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
        GyroSensitivity = 10,
        GyroBias = 8,
        GyroBiasTempSens = 10,
        AccelSensitivity = 4,
        AccelBias = 8,
        MagSensitivity = 4,
        MagBias = 8,
        MagHardIronBias = 11,
        AlgorithmKp = 8,
        AlgorithmKi = 14,
        AlgorithmInitKp = 6,
        AlgorithmInitPeriod = 8,
        CalibratedAnalogueInput = 12
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
        GyroSensitivityX,
        GyroSensitivityY,
        GyroSensitivityZ,
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
        TareQuat0,
        TareQuat1,
        TareQuat2,
        TareQuat3,
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
        AlgorithmMinValidMag,
        AlgorithmMaxValidMag,
        numRegisters
    }

    #endregion

    #region Register values

    /// <summary>
    /// Button mode register values.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    enum ButtonModes
    {
        Disabled,
        ResetDevice,
        SleepWake,
        ResetAlgorithm,
        TareAlgorithm
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
    /// Date/time data output rate register values.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    enum DateTimeOutputRates
    {
        OnResetOnly,
        Rate1Hz,
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
    enum MotionTrigWakeUpModes
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
    enum BluetoothPowerModes
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
    enum auxiliaryPortModes
    {
        Disabled,
        DigitalIO
    }

    /// <summary>
    /// Digital I/O direction register values.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    enum DigitalIOdirections
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

    /// <summary>
    /// Digital I/O output rate register values.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    enum DigitalIOoutputRates
    {
        OnChangeOnly,
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

    #endregion
}
