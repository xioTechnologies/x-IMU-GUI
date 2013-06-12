using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Compatible firmware versions. Only major number required.
    /// </summary>
    public enum CompatibleFirmwareVersions
    {
        v10_x = 10
    }

    /// <summary>
    /// Packet headers.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks>
    public enum PacketHeaders
    {
        Error,
        Command,
        ReadRegister,
        WriteRegister,
        ReadDateTime,
        WriteDateTime,
        RawBatteryAndThermometerData,
        CalBatteryAndThermometerData,
        RawInertialAndMagneticData,
        CalInertialAndMagneticData,
        QuaternionData,
        DigitalIOdata,
        RawAnalogueInputData,
        CalAnalogueInputData,
        PWMoutputData,
        RawADXL345busData,
        CalADXL345busData,
    }

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
        IncorrectAuxillaryPortMode,
        UARTreceiveBufferOverrun,
        UARTtransmitBufferOverrun
    }

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
        CalculateGyroscopeSensitivity,
        SampleGyroscopeBiasTemp1,
        SampleGyroscopeBiasTemp2,
        CalculateGyroscopeBiasParameters,
        SampleAccelerometerAxisAt1g,
        CalculateAccelerometerBiasAndSensitivity,
        MeasureMagnetometerBiasAndSensitivity,
        AlgorithmInitialise,
        AlgorithmTare,
        AlgorithmClearTare,
        AlgorithmInitialiseThenTare
    }

    /// <summary>
    /// Number of fractional bits used by fixed-point representations.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    internal enum Qvals
    {
        CalibratedBattery = 12,
        CalibratedThermometer = 8,
        CalibratedGyroscope = 4,
        CalibratedAccelerometer = 11,
        CalibratedMagnetometer = 11,
        Quaternion = 15,
        BatterySensitivity = 5,
        BatteryBias = 8,
        ThermometerSensitivity = 6,
        ThermometerBias = 0,
        GyroscopeSensitivity = 7,
        GyroscopeSampled200dps = 0,
        GyroscopeBiasAt25degC = 3,
        GyroscopeBiasTempSensitivity = 11,
        GyroscopeSampledBias = 3,
        AccelerometerSensitivity = 4,
        AccelerometerBias = 8,
        AccelerometerSampled1g = 4,
        MagnetometerSensitivity = 4,
        MagnetometerBias = 8,
        MagnetometerHardIronBias = 11,
        AlgorithmKp = 11,
        AlgorithmKi = 15,
        AlgorithmInitKp = 11,
        AlgorithmInitPeriod = 11,
        CalibratedAnalogueInput = 12,
        AnalogueInputSensitivity = 4,
        AnalogueInputBias = 8,
        CalibratedADXL345 = 10,
        ADXL345busSensitivity = 6,
        ADXL345busBias = 8,
    }

    /// <summary>
    /// Register addresses.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    public enum RegisterAddresses
    {
        FirmwareVersionMajorNum,
        FirmwareVersionMinorNum,
        DeviceID,
        ButtonMode,
        BatterySensitivity,
        BatteryBias,
        ThermometerSensitivity,
        ThermometerBias,
        GyroscopeFullScale,
        GyroscopeSensitivityX,
        GyroscopeSensitivityY,
        GyroscopeSensitivityZ,
        GyroscopeSampledPlus200dpsX,
        GyroscopeSampledPlus200dpsY,
        GyroscopeSampledPlus200dpsZ,
        GyroscopeSampledMinus200dpsX,
        GyroscopeSampledMinus200dpsY,
        GyroscopeSampledMinus200dpsZ,
        GyroscopeBiasAt25degCX,
        GyroscopeBiasAt25degCY,
        GyroscopeBiasAt25degCZ,
        GyroscopeBiasTempSensitivityX,
        GyroscopeBiasTempSensitivityY,
        GyroscopeBiasTempSensitivityZ,
        GyroscopeSample1Temp,
        GyroscopeSample1BiasX,
        GyroscopeSample1BiasY,
        GyroscopeSample1BiasZ,
        GyroscopeSample2Temp,
        GyroscopeSample2BiasX,
        GyroscopeSample2BiasY,
        GyroscopeSample2BiasZ,
        AccelerometerFullScale,
        AccelerometerSensitivityX,
        AccelerometerSensitivityY,
        AccelerometerSensitivityZ,
        AccelerometerBiasX,
        AccelerometerBiasY,
        AccelerometerBiasZ,
        AccelerometerSampledPlus1gX,
        AccelerometerSampledPlus1gY,
        AccelerometerSampledPlus1gZ,
        AccelerometerSampledMinus1gX,
        AccelerometerSampledMinus1gY,
        AccelerometerSampledMinus1gZ,
        MagnetometerFullScale,
        MagnetometerSensitivityX,
        MagnetometerSensitivityY,
        MagnetometerSensitivityZ,
        MagnetometerBiasX,
        MagnetometerBiasY,
        MagnetometerBiasZ,
        MagnetometerHardIronBiasX,
        MagnetometerHardIronBiasY,
        MagnetometerHardIronBiasZ,
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
        DateTimeDataRate,
        BatteryAndThermometerDataRate,
        InertialAndMagneticDataRate,
        QuaternionDataRate,
        SDcardNewFileName,
        BatteryShutdownVoltage,
        SleepTimer,
        MotionTrigWakeUp,
        BluetoothPower,
        AuxiliaryPortMode,
        DigitalIOdirection,
        DigitalIOdataRate,
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
        UARTbaudRate,
        UARThardwareFlowControl,
        NumRegisters
    }

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
        Rate256Hz,
        Rate512Hz
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
        ADXL345bus,
        SleepWake
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

    /// <summary>
    /// UART baud rate register values.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    public enum UARTbaudRates
    {
        UARTbaudRate2400,
        UARTbaudRate4800,
        UARTbaudRate7200,
        UARTbaudRate9600,
        UARTbaudRate14400,
        UARTbaudRate19200,
        UARTbaudRate38400,
        UARTbaudRate57600,
        UARTbaudRate115200,
        UARTbaudRate230400
    };

    /// <summary>
    /// UART hardware flow control register values.
    /// </summary>
    /// <remarks>
    /// A matching enumeration exists in firmware source.
    /// </remarks> 
    public enum UARThardwareFlowControl
    {
        Off,
        On,
    };

    #endregion
}
