using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace x_IMU_API
{
    /// <summary>
    /// CSV files class.
    /// </summary>
    public class CSVfileWriter
    {
        #region Variables

        /// <summary>
        /// Packet number.
        /// </summary>
        private uint packetNumber;

        /// <summary>
        /// Writes enabled flag.
        /// </summary>
        private bool writesEnabled;

        /// <summary>
        /// File base path.
        /// </summary>
        private string privFileBasePath;

        /// <summary>
        /// Array of StreamWriter.
        /// </summary>
        private StreamWriter[] streamWriters;

        /// <summary>
        /// CSV column headings for each file type.
        /// </summary>
        private string[] CSVheadings;

        /// <summary>
        /// Index of each file within array.  Each label is used as part of file name.
        /// </summary>
        private enum FileIndexes
        {
            Errors,
            Commands,
            Registers,
            DateTime,
            RawBattTherm,
            CalBattTherm,
            RawInertialMagnetic,
            CalInertialMagnetic,
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

        #endregion

        #region Properties

        /// <summary>
        /// Gets the file base path. This name is automatically extended to create the name of each CSV file.
        /// </summary>
        public string FileBasePath
        {
            get
            {
                return privFileBasePath;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVfileWriter"/> class.
        /// </summary>
        /// <param name="fileBasePath">
        /// Base path of file.  File name automatically extended with appropriate identifier and file extension.
        /// </param>
        public CSVfileWriter(string fileBasePath)
        {
            if (Directory.Exists(Path.GetDirectoryName(fileBasePath)) && (Path.GetFileName(fileBasePath) != ""))
            {
                privFileBasePath = fileBasePath;
            }
            else
            {
                throw new Exception("Invalid file path.");
            }
            packetNumber = 0;
            writesEnabled = true;
            streamWriters = new StreamWriter[(int)FileIndexes.NumberOfFiles];
            CSVheadings = new string[(int)FileIndexes.NumberOfFiles];
            CSVheadings[(int)FileIndexes.Errors] = "Packet Number,Error Code,Error Message";
            CSVheadings[(int)FileIndexes.Commands] = "Packet Number,Command Code,Command Message";
            CSVheadings[(int)FileIndexes.Registers] = "Packet Number,Address,Value,Float Value,Name";
            CSVheadings[(int)FileIndexes.DateTime] = "Packet Number,Date/Time";
            CSVheadings[(int)FileIndexes.RawBattTherm] = "Packet Number,Battery voltage (lsb),Thermometer (lsb)";
            CSVheadings[(int)FileIndexes.CalBattTherm] = "Packet Number,Battery voltage (V),Thermometer (˚C)";
            CSVheadings[(int)FileIndexes.RawInertialMagnetic] = "Packet Number,Gyroscope X (lsb),Gyroscope Y (lsb),Gyroscope Z (lsb),Accelerometer X (lsb),Accelerometer Y (lsb),Accelerometer Z (lsb),Magnetometer X (lsb),Magnetometer Y (lsb),Magnetometer Z (lsb)";
            CSVheadings[(int)FileIndexes.CalInertialMagnetic] = "Packet Number,Gyroscope X (deg/s),Gyroscope Y (deg/s),Gyroscope Z (deg/s),Accelerometer X (g),Accelerometer Y (g),Accelerometer Z (g),Magnetometer X (G),Magnetometer Y (G),Magnetometer Z (G)";
            CSVheadings[(int)FileIndexes.Quaternion] = "Packet Number,Element 1, Element 2, Element 3, Element 4";
            CSVheadings[(int)FileIndexes.RotationMatrix] = "Packet Number,Element 11, Element 12, Element 13, Element 21, Element 22, Element 23, Element 31, Element 32, Element 33";
            CSVheadings[(int)FileIndexes.EulerAngles] = "Packet Number,Roll | Phi | X (degrees), Pitch | Theta | Y (degrees), Yaw | Psi | Z (degrees)";
            CSVheadings[(int)FileIndexes.DigitalIO] = "Packet Number,AX0 Direction, AX1 Direction, AX2 Direction, AX3 Direction, AX4 Direction, AX5 Direction, AX6 Direction, AX7 Direction, AX0 State, AX1 State, AX2 State, AX3 State, AX4 State, AX5 State, AX6 State, AX7 State,";
            CSVheadings[(int)FileIndexes.RawAnalogueInput] = "Packet Number,AX0 (lsb),AX1 (lsb),AX2 (lsb),AX3 (lsb),AX4 (lsb),AX5 (lsb),AX6 (lsb),AX7 (lsb)";
            CSVheadings[(int)FileIndexes.CalAnalogueInput] = "Packet Number,AX0 (V),AX1 (V),AX2 (V),AX3 (V),AX4 (V),AX5 (V),AX6 (V),AX7 (V)";
            CSVheadings[(int)FileIndexes.PWMoutput] = "Packet Number,AX0,AX2,AX4,AX6";
            CSVheadings[(int)FileIndexes.RawADXL345bus] = "Packet Number,ADXL345 A X (lsb), ADXL345 A Y (lsb), ADXL345 A Z (lsb),ADXL345 B X (lsb), ADXL345 B Y (lsb), ADXL345 B Z (lsb),ADXL345 C X (lsb), ADXL345 C Y (lsb), ADXL345 C Z (lsb),ADXL345 D X (lsb), ADXL345 D Y (lsb), ADXL345 D Z (lsb)";
            CSVheadings[(int)FileIndexes.CalADXL345bus] = "Packet Number,ADXL345 A X (g), ADXL345 A Y (g), ADXL345 A Z (g),ADXL345 B X (g), ADXL345 B Y (g), ADXL345 B Z (g),ADXL345 C X (g), ADXL345 C Y (g), ADXL345 C Z (g),ADXL345 D X (g), ADXL345 D Y (g), ADXL345 D Z (g)";
        }

        #endregion

        #region Methods

        /// <summary>
        /// Write xIMUdata object to appropriate CSV file.  Will create new file if required.
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
            else if (xIMUdataObject is RawBattThermData) WriteRawBattThermData((RawBattThermData)xIMUdataObject);
            else if (xIMUdataObject is CalBattThermData) WriteCalBattThermData((CalBattThermData)xIMUdataObject);
            else if (xIMUdataObject is RawInertialMagneticData) WriteRawInertialMagneticData((RawInertialMagneticData)xIMUdataObject);
            else if (xIMUdataObject is CalInertialMagneticData) WriteCalInertialMagneticData((CalInertialMagneticData)xIMUdataObject);
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
        /// Write error message to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="errorData">
        /// x-IMU error data.
        /// </param>
        public void WriteErrorData(ErrorData errorData)
        {
            WriteCSVlineAtFileIndex(errorData.ErrorCode.ToString() + "," + errorData.GetMessage(), FileIndexes.Errors);
        }

        /// <summary>
        /// Write command message to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="commandData">
        /// x-IMU command data.
        /// </param>
        public void WriteCommandData(CommandData commandData)
        {
            WriteCSVlineAtFileIndex(commandData.CommandCode.ToString() + "," + commandData.GetMessage(), FileIndexes.Commands);
        }

        /// <summary>
        /// Write register data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="registerData">
        /// x-IMU register data.
        /// </param>
        public void WriteRegisterData(RegisterData registerData)
        {
            float floatValue = (float)registerData.Value;
            try
            {
                floatValue = registerData.floatValue;
            }
            catch { }
            WriteCSVlineAtFileIndex(registerData.Address.ToString() + "," + registerData.Value.ToString() + "," + floatValue.ToString() + "," + Enum.GetName(typeof(RegisterAddresses), registerData.Address), FileIndexes.Registers);
        }

        /// <summary>
        /// Write date/time data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="dateTimeData">
        /// x-IMU data/time data.
        /// </param>
        public void WriteDateTimeData(DateTimeData dateTimeData)
        {
            WriteCSVlineAtFileIndex(dateTimeData.ConvertToString(), FileIndexes.DateTime);
        }

        /// <summary>
        /// Writes raw battery and thermometer data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="rawBattThermData">
        /// x-IMU raw battery and thermometer data.
        /// </param>
        public void WriteRawBattThermData(RawBattThermData rawBattThermData)
        {
            WriteCSVlineAtFileIndex(rawBattThermData.ConvertToCSV(), FileIndexes.RawBattTherm);
        }

        /// <summary>
        /// Writes calibrated battery and thermometer data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="calBattThermData">
        /// x-IMU calibrated battery and thermometer data.
        /// </param>
        public void WriteCalBattThermData(CalBattThermData calBattThermData)
        {
            WriteCSVlineAtFileIndex(calBattThermData.ConvertToCSV(), FileIndexes.CalBattTherm);
        }

        /// <summary>
        /// Writes raw inertial/magnetic data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="rawInertialMagneticData">
        /// x-IMU raw inertial/magnetic data.
        /// </param>
        public void WriteRawInertialMagneticData(RawInertialMagneticData rawInertialMagneticData)
        {
            WriteCSVlineAtFileIndex(rawInertialMagneticData.ConvertToCSV(), FileIndexes.RawInertialMagnetic);
        }

        /// <summary>
        /// Writes calibrated inertial/magnetic data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="calInertialMagneticData">
        /// x-IMU calibrated inertial/magnetic data.
        /// </param>
        public void WriteCalInertialMagneticData(CalInertialMagneticData calInertialMagneticData)
        {
            WriteCSVlineAtFileIndex(calInertialMagneticData.ConvertToCSV(), FileIndexes.CalInertialMagnetic);
        }

        /// <summary>
        /// Writes quaternion data to quaternion, rotation matrix and Euler angles CSV files.  Will create new files if required.
        /// </summary>
        /// <param name="quaternionData">
        /// x-IMU quaternion data.
        /// </param>
        public void WriteQuaternionData(QuaternionData quaternionData)
        {
            WriteCSVlineAtFileIndex(quaternionData.ConvertToCSV(), FileIndexes.Quaternion);
            WriteCSVlineAtFileIndex(quaternionData.ConvertToRotationMatrixCSV(), FileIndexes.RotationMatrix);
            WriteCSVlineAtFileIndex(quaternionData.ConvertToEulerAnglesCSV(), FileIndexes.EulerAngles);
        }

        /// <summary>
        /// Writes digital I/O data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="digitalIOdata">
        /// x-IMU digital I/O data.
        /// </param>
        public void WriteDigitalIOdata(DigitalIOdata digitalIOdata)
        {
            WriteCSVlineAtFileIndex(digitalIOdata.ConvertToCSV(), FileIndexes.DigitalIO);
        }

        /// <summary>
        /// Writes raw analogue input data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="rawAnalogueInputData">
        /// Raw analogue input data.
        /// </param>
        public void WriteRawAnalogueInputData(RawAnalogueInputData rawAnalogueInputData)
        {
            WriteCSVlineAtFileIndex(rawAnalogueInputData.ConvertToCSV(), FileIndexes.RawAnalogueInput);
        }

        /// <summary>
        /// Writes calibrated analogue input data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="calAnalogueInputData">
        /// Calibrated analogue input data.
        /// </param>
        public void WriteCalAnalogueInputData(CalAnalogueInputData calAnalogueInputData)
        {
            WriteCSVlineAtFileIndex(calAnalogueInputData.ConvertToCSV(), FileIndexes.CalAnalogueInput);
        }

        /// <summary>
        /// Writes PWMoutput data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="_PWMoutputData">
        /// Calibrated analogue input data.
        /// </param>
        public void WritePWMoutputData(PWMoutputData _PWMoutputData)
        {
            WriteCSVlineAtFileIndex(_PWMoutputData.ConvertToCSV(), FileIndexes.PWMoutput);
        }

        /// <summary>
        /// Writes raw ADXL345 bus data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="rawADXL345busData">
        /// Raw ADXL345 bus data.
        /// </param>
        public void WriteRawADXL345busData(RawADXL345busData rawADXL345busData)
        {
            WriteCSVlineAtFileIndex(rawADXL345busData.ConvertToCSV(), FileIndexes.RawADXL345bus);
        }

        /// <summary>
        /// Writes calibrate ADXL345 bus data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="calADXL345busData">
        /// Cal ADXL345 bus data.
        /// </param>
        public void WriteCalADXL345busData(CalADXL345busData calADXL345busData)
        {
            WriteCSVlineAtFileIndex(calADXL345busData.ConvertToCSV(), FileIndexes.CalADXL345bus);
        }

        /// <summary>
        /// Writes CSV line to file according to specfied fileIndex.
        /// </summary>
        /// <param name="CSVline">
        /// CSV line.  First CSV is packet number.
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
                streamWriters[(int)fileIndex].WriteLine(Convert.ToString(packetNumber) + "," + CSVline);
                packetNumber++;
            }
        }

        /// <summary>
        /// Closes all open CSV files and returns file names of files created.
        /// </summary>
        /// <returns>
        /// File names of files created.
        /// </returns>
        public string[] CloseFiles()
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
            return fileNames.ToArray();
        }

        #endregion
    }
}