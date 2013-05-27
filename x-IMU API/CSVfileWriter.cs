using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace x_IMU_API
{
    /// <summary>
    /// CSV file writer class.
    /// </summary>
    public class CSVfileWriter
    {
        /// <summary>
        /// Gets the file base path. This name is automatically extended to create the name of each CSV file.
        /// </summary>
        public string FileBasePath { get; private set; }

        /// <summary>
        /// Gets the number of packets written.
        /// </summary>
        public PacketCount PacketsWrittenCounter { get; private set; }

        /// <summary>
        /// Gets the names of files created.
        /// </summary>
        public string[] FilesCreated { get; private set; }

        /// <summary>
        /// Writes enabled flag.
        /// </summary>
        private bool writesEnabled;

        /// <summary>
        /// Array of StreamWriter.
        /// </summary>
        private StreamWriter[] streamWriters;

        /// <summary>
        /// CSV column headings for each file type.
        /// </summary>
        private string[] CSVheadings;

        /// <summary>
        /// Index of each file within array. Labels used to create file names.
        /// </summary>
        private enum FileIndexes
        {
            Errors,
            Commands,
            Registers,
            DateTime,
            RawBattAndTherm,
            CalBattAndTherm,
            RawInertialAndMag,
            CalInertialAndMag,
            Quaternion,
            RotationMatrix,
            EulerAngles,
            DigitalIO,
            RawAnalogueInput,
            CalAnalogueInput,
            PWMoutput,
            CalADXL345bus,
            RawADXL345bus,
            NumberOfFiles
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVfileWriter"/> class.
        /// </summary>
        /// <param name="fileBasePath">
        /// Base path of file. File name automatically extended with appropriate identifier and file extension.
        /// </param>
        public CSVfileWriter(string fileBasePath)
        {
            if (Directory.Exists(Path.GetDirectoryName(fileBasePath)) && (Path.GetFileName(fileBasePath) != ""))
            {
                FileBasePath = fileBasePath;
            }
            else
            {
                throw new Exception("Invalid file path.");
            }
            PacketsWrittenCounter = new PacketCount();
            FilesCreated = null;
            writesEnabled = true;
            streamWriters = new StreamWriter[(int)FileIndexes.NumberOfFiles];
            CSVheadings = new string[(int)FileIndexes.NumberOfFiles];
            CSVheadings[(int)FileIndexes.Errors] = "Packet number,Error code,Error message";
            CSVheadings[(int)FileIndexes.Commands] = "Packet number,Command code,Command message";
            CSVheadings[(int)FileIndexes.Registers] = "Packet number,Address,Value,Fixed-point value,Name";
            CSVheadings[(int)FileIndexes.DateTime] = "Packet number,Year,Month,Day,Hours,Minutes,Seconds";
            CSVheadings[(int)FileIndexes.RawBattAndTherm] = "Packet number,Battery voltage (lsb),Thermometer (lsb)";
            CSVheadings[(int)FileIndexes.CalBattAndTherm] = "Packet number,Battery voltage (V),Thermometer (degrees C)";
            CSVheadings[(int)FileIndexes.RawInertialAndMag] = "Packet number,Gyroscope X (lsb),Gyroscope Y (lsb),Gyroscope Z (lsb),Accelerometer X (lsb),Accelerometer Y (lsb),Accelerometer Z (lsb),Magnetometer X (lsb),Magnetometer Y (lsb),Magnetometer Z (lsb)";
            CSVheadings[(int)FileIndexes.CalInertialAndMag] = "Packet number,Gyroscope X (deg/s),Gyroscope Y (deg/s),Gyroscope Z (deg/s),Accelerometer X (g),Accelerometer Y (g),Accelerometer Z (g),Magnetometer X (G),Magnetometer Y (G),Magnetometer Z (G)";
            CSVheadings[(int)FileIndexes.Quaternion] = "Packet number,Element 1, Element 2, Element 3, Element 4";
            CSVheadings[(int)FileIndexes.RotationMatrix] = "Packet number,Element 11, Element 12, Element 13, Element 21, Element 22, Element 23, Element 31, Element 32, Element 33";
            CSVheadings[(int)FileIndexes.EulerAngles] = "Packet number,Roll | Phi | X (degrees), Pitch | Theta | Y (degrees), Yaw | Psi | Z (degrees)";
            CSVheadings[(int)FileIndexes.DigitalIO] = "Packet number,AX0 direction, AX1 direction, AX2 direction, AX3 direction, AX4 direction, AX5 direction, AX6 direction, AX7 direction, AX0 state, AX1 state, AX2 state, AX3 state, AX4 state, AX5 state, AX6 state, AX7 state,";
            CSVheadings[(int)FileIndexes.RawAnalogueInput] = "Packet number,AX0 (lsb),AX1 (lsb),AX2 (lsb),AX3 (lsb),AX4 (lsb),AX5 (lsb),AX6 (lsb),AX7 (lsb)";
            CSVheadings[(int)FileIndexes.CalAnalogueInput] = "Packet number,AX0 (V),AX1 (V),AX2 (V),AX3 (V),AX4 (V),AX5 (V),AX6 (V),AX7 (V)";
            CSVheadings[(int)FileIndexes.PWMoutput] = "Packet number,AX0,AX2,AX4,AX6";
            CSVheadings[(int)FileIndexes.RawADXL345bus] = "Packet number,ADXL345 A X (lsb), ADXL345 A Y (lsb), ADXL345 A Z (lsb),ADXL345 B X (lsb), ADXL345 B Y (lsb), ADXL345 B Z (lsb),ADXL345 C X (lsb), ADXL345 C Y (lsb), ADXL345 C Z (lsb),ADXL345 D X (lsb), ADXL345 D Y (lsb), ADXL345 D Z (lsb)";
            CSVheadings[(int)FileIndexes.CalADXL345bus] = "Packet number,ADXL345 A X (g), ADXL345 A Y (g), ADXL345 A Z (g),ADXL345 B X (g), ADXL345 B Y (g), ADXL345 B Z (g),ADXL345 C X (g), ADXL345 C Y (g), ADXL345 C Z (g),ADXL345 D X (g), ADXL345 D Y (g), ADXL345 D Z (g)";
        }

        /// <summary>
        /// Closes all open CSV files and returns file names of files created.
        /// </summary>
        public void CloseFiles()
        {
            List<string> fileNames = new List<string>();
            writesEnabled = false;
            for (int i = 0; i < (int)FileIndexes.NumberOfFiles; i++)
            {
                if (streamWriters[i] != null)
                {
                    fileNames.Add(Path.GetFileName(((FileStream)streamWriters[i].BaseStream).Name));
                    streamWriters[i].Close();
                    streamWriters[i] = null;
                }
            }
            FilesCreated = fileNames.ToArray();
        }

        /// <summary>
        /// Write <see cref="xIMUdata"/>  object to appropriate CSV file. Will create new file if required.
        /// </summary>
        /// <param name="xIMUdataObject">
        /// x-IMU data object.
        /// </param>
        public void WriteData(xIMUdata xIMUdataObject)
        {
            if (xIMUdataObject is ErrorData) WriteErrorData((ErrorData)xIMUdataObject);
            else if (xIMUdataObject is CommandData) WriteCommandData((CommandData)xIMUdataObject);
            else if (xIMUdataObject is RegisterData) WriteRegisterData((RegisterData)xIMUdataObject);
            else if (xIMUdataObject is DateTimeData) WriteDateTimeData((DateTimeData)xIMUdataObject);
            else if (xIMUdataObject is RawBatteryAndThermometerData) WriteRawBatteryAndThermometerData((RawBatteryAndThermometerData)xIMUdataObject);
            else if (xIMUdataObject is CalBatteryAndThermometerData) WriteCalBatteryAndThermometerData((CalBatteryAndThermometerData)xIMUdataObject);
            else if (xIMUdataObject is RawInertialAndMagneticData) WriteRawInertialAndMagneticData((RawInertialAndMagneticData)xIMUdataObject);
            else if (xIMUdataObject is CalInertialAndMagneticData) WriteCalInertialAndMagneticData((CalInertialAndMagneticData)xIMUdataObject);
            else if (xIMUdataObject is QuaternionData) WriteQuaternionData((QuaternionData)xIMUdataObject);
            else if (xIMUdataObject is DigitalIOdata) WriteDigitalIOdata((DigitalIOdata)xIMUdataObject);
            else if (xIMUdataObject is RawAnalogueInputData) WriteRawAnalogueInputData((RawAnalogueInputData)xIMUdataObject);
            else if (xIMUdataObject is CalAnalogueInputData) WriteCalAnalogueInputData((CalAnalogueInputData)xIMUdataObject);
            else if (xIMUdataObject is PWMoutputData) WritePWMoutputData((PWMoutputData)xIMUdataObject);
            else if (xIMUdataObject is RawADXL345busData) WriteRawADXL345busData((RawADXL345busData)xIMUdataObject);
            else if (xIMUdataObject is CalADXL345busData) WriteCalADXL345busData((CalADXL345busData)xIMUdataObject);
            else
            {
                throw new Exception("xIMUdata object unhandled.");
            }
        }

        /// <summary>
        /// Write <see cref="ErrorData"/> to CSV file. Will create new file if required.
        /// </summary>
        /// <param name="errorData">
        /// x-IMU error data.
        /// </param>
        public void WriteErrorData(ErrorData errorData)
        {
            WriteCSVlineAtFileIndex(((ushort)errorData.ErrorCode).ToString() + "," + errorData.GetMessage(), FileIndexes.Errors);
            PacketsWrittenCounter.ErrorPackets++;
        }

        /// <summary>
        /// Write <see cref="CommandData"/> to CSV file. Will create new file if required.
        /// </summary>
        /// <param name="commandData">
        /// x-IMU command data.
        /// </param>
        public void WriteCommandData(CommandData commandData)
        {
            WriteCSVlineAtFileIndex(((ushort)commandData.CommandCode).ToString() + "," + commandData.GetMessage(), FileIndexes.Commands);
            PacketsWrittenCounter.CommandPackets++;
        }

        /// <summary>
        /// Write <see cref="RegisterData"/> to CSV file. Will create new file if required.
        /// </summary>
        /// <param name="registerData">
        /// x-IMU register data.
        /// </param>
        public void WriteRegisterData(RegisterData registerData)
        {
            string fixedPointValue = "NaN";
            try
            {
                fixedPointValue = registerData.ConvertValueToFloat().ToString();
            }
            catch { }
            WriteCSVlineAtFileIndex(((ushort)registerData.Address).ToString() + "," + registerData.Value.ToString() + "," + fixedPointValue + "," + Enum.GetName(typeof(RegisterAddresses), registerData.Address), FileIndexes.Registers);
            PacketsWrittenCounter.WriteRegisterPackets++;
        }

        /// <summary>
        /// Write <see cref="DateTimeData"/> to CSV file. Will create new file if required.
        /// </summary>
        /// <param name="dateTimeData">
        /// x-IMU data/time data.
        /// </param>
        public void WriteDateTimeData(DateTimeData dateTimeData)
        {
            WriteCSVlineAtFileIndex(dateTimeData.ConvertToCSVstring(), FileIndexes.DateTime);
            PacketsWrittenCounter.WriteDateTimePackets++;
        }

        /// <summary>
        /// Writes <see cref="RawBatteryAndThermometerData"/> to CSV file. Will create new file if required.
        /// </summary>
        /// <param name="rawBatteryAndThermometerData">
        /// x-IMU raw battery and thermometer data.
        /// </param>
        public void WriteRawBatteryAndThermometerData(RawBatteryAndThermometerData rawBatteryAndThermometerData)
        {
            WriteCSVlineAtFileIndex(rawBatteryAndThermometerData.ConvertToCSVstring(), FileIndexes.RawBattAndTherm);
            PacketsWrittenCounter.RawBatteryAndThermometerDataPackets++;
        }

        /// <summary>
        /// Writes <see cref="CalBatteryAndThermometerData"/> to CSV file. Will create new file if required.
        /// </summary>
        /// <param name="calBatteryAndThermometerData">
        /// x-IMU calibrated battery and thermometer data.
        /// </param>
        public void WriteCalBatteryAndThermometerData(CalBatteryAndThermometerData calBatteryAndThermometerData)
        {
            WriteCSVlineAtFileIndex(calBatteryAndThermometerData.ConvertToCSVstring(), FileIndexes.CalBattAndTherm);
            PacketsWrittenCounter.CalBatteryAndThermometerDataPackets++;
        }

        /// <summary>
        /// Writes <see cref="RawInertialAndMagneticData"/> to CSV file. Will create new file if required.
        /// </summary>
        /// <param name="rawInertialAndMagneticData">
        /// x-IMU raw inertial/magnetic data.
        /// </param>
        public void WriteRawInertialAndMagneticData(RawInertialAndMagneticData rawInertialAndMagneticData)
        {
            WriteCSVlineAtFileIndex(rawInertialAndMagneticData.ConvertToCSVstring(), FileIndexes.RawInertialAndMag);
            PacketsWrittenCounter.RawInertialAndMagneticDataPackets++;
        }

        /// <summary>
        /// Writes <see cref="CalInertialAndMagneticData"/> to CSV file. Will create new file if required.
        /// </summary>
        /// <param name="calInertialAndMagneticData">
        /// x-IMU calibrated inertial/magnetic data.
        /// </param>
        public void WriteCalInertialAndMagneticData(CalInertialAndMagneticData calInertialAndMagneticData)
        {
            WriteCSVlineAtFileIndex(calInertialAndMagneticData.ConvertToCSVstring(), FileIndexes.CalInertialAndMag);
            PacketsWrittenCounter.CalInertialAndMagneticDataPackets++;
        }

        /// <summary>
        /// Writes <see cref="QuaternionData"/> to quaternion, rotation matrix and Euler angles CSV files. Will create new files if required.
        /// </summary>
        /// <param name="quaternionData">
        /// x-IMU quaternion data.
        /// </param>
        public void WriteQuaternionData(QuaternionData quaternionData)
        {
            WriteCSVlineAtFileIndex(quaternionData.ConvertToCSVstring(), FileIndexes.Quaternion);
            WriteCSVlineAtFileIndex(quaternionData.ConvertToRotationMatrixCSVstring(), FileIndexes.RotationMatrix);
            WriteCSVlineAtFileIndex(quaternionData.ConvertToEulerAnglesCSVstring(), FileIndexes.EulerAngles);
            PacketsWrittenCounter.QuaternionDataPackets++;
        }

        /// <summary>
        /// Writes <see cref="DigitalIOdata"/> to CSV file. Will create new file if required.
        /// </summary>
        /// <param name="digitalIOdata">
        /// x-IMU digital I/O data.
        /// </param>
        public void WriteDigitalIOdata(DigitalIOdata digitalIOdata)
        {
            WriteCSVlineAtFileIndex(digitalIOdata.ConvertToCSVstring(), FileIndexes.DigitalIO);
            PacketsWrittenCounter.DigitalIOdataPackets++;
        }

        /// <summary>
        /// Writes <see cref="RawAnalogueInputData"/> to CSV file. Will create new file if required.
        /// </summary>
        /// <param name="rawAnalogueInputData">
        /// Raw analogue input data.
        /// </param>
        public void WriteRawAnalogueInputData(RawAnalogueInputData rawAnalogueInputData)
        {
            WriteCSVlineAtFileIndex(rawAnalogueInputData.ConvertToCSVstring(), FileIndexes.RawAnalogueInput);
            PacketsWrittenCounter.RawAnalogueInputDataPackets++;
        }

        /// <summary>
        /// Writes <see cref="CalAnalogueInputData"/> to CSV file. Will create new file if required.
        /// </summary>
        /// <param name="calAnalogueInputData">
        /// Calibrated analogue input data.
        /// </param>
        public void WriteCalAnalogueInputData(CalAnalogueInputData calAnalogueInputData)
        {
            WriteCSVlineAtFileIndex(calAnalogueInputData.ConvertToCSVstring(), FileIndexes.CalAnalogueInput);
            PacketsWrittenCounter.CalAnalogueInputDataPackets++;
        }

        /// <summary>
        /// Writes <see cref="PWMoutputData"/> to CSV file. Will create new file if required.
        /// </summary>
        /// <param name="PWMoutputData">
        /// Calibrated analogue input data.
        /// </param>
        public void WritePWMoutputData(PWMoutputData PWMoutputData)
        {
            WriteCSVlineAtFileIndex(PWMoutputData.ConvertToCSVstring(), FileIndexes.PWMoutput);
            PacketsWrittenCounter.PWMoutputDataPackets++;
        }

        /// <summary>
        /// Writes <see cref="RawADXL345busData"/> to CSV file. Will create new file if required.
        /// </summary>
        /// <param name="rawADXL345busData">
        /// Raw ADXL345 bus data.
        /// </param>
        public void WriteRawADXL345busData(RawADXL345busData rawADXL345busData)
        {
            WriteCSVlineAtFileIndex(rawADXL345busData.ConvertToCSVstring(), FileIndexes.RawADXL345bus);
            PacketsWrittenCounter.RawADXL345busDataPackets++;
        }

        /// <summary>
        /// Writes <see cref="CalADXL345busData"/> to CSV file. Will create new file if required.
        /// </summary>
        /// <param name="calADXL345busData">
        /// Cal ADXL345 bus data.
        /// </param>
        public void WriteCalADXL345busData(CalADXL345busData calADXL345busData)
        {
            WriteCSVlineAtFileIndex(calADXL345busData.ConvertToCSVstring(), FileIndexes.CalADXL345bus);
            PacketsWrittenCounter.CalADXL345busDataPackets++;
        }

        /// <summary>
        /// Writes CSV line to file according to specfied fileIndex.
        /// </summary>
        /// <param name="CSVline">
        /// CSV text line. First CSV is packet number.
        /// </param>
        /// <param name="fileIndex">
        /// file index.
        /// </param>
        private void WriteCSVlineAtFileIndex(string CSVline, FileIndexes fileIndex)
        {
            if (writesEnabled)
            {
                if (streamWriters[(int)fileIndex] == null)
                {
                    streamWriters[(int)fileIndex] = new System.IO.StreamWriter(FileBasePath + "_" + fileIndex.ToString() + ".csv", false);
                    streamWriters[(int)fileIndex].WriteLine(CSVheadings[(int)fileIndex]);
                }
                streamWriters[(int)fileIndex].WriteLine(PacketsWrittenCounter.TotalPackets.ToString() + "," + CSVline);
            }
        }
    }
}