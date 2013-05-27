using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace xIMU_API
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
        /// Initializes a new instance of the <see cref="T:CSVfileWriter"/> class.
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
            CSVheadings[(int)FileIndexes.Errors] = "Packet Number,Code,Message";
            CSVheadings[(int)FileIndexes.Commands] = "Packet Number,Code,Message";
            CSVheadings[(int)FileIndexes.Registers] = "Packet Number,Address,Value,Float Value,Name";
            CSVheadings[(int)FileIndexes.DateTime] = "Packet Number,Date/Time";
            CSVheadings[(int)FileIndexes.RawBattTherm] = "Packet Number,Battery voltage (lsb),Thermometer (lsb)";
            CSVheadings[(int)FileIndexes.CalBattTherm] = "Packet Number,Battery voltage (V),Thermometer (degC)";
            CSVheadings[(int)FileIndexes.RawInertialMagnetic] = "Packet Number,Gyroscope X (lsb),Gyroscope Y (lsb),Gyroscope Z (lsb),Accelerometer X (lsb),Accelerometer Y (lsb),Accelerometer Z (lsb),Magnetometer X (lsb),Magnetometer Y (lsb),Magnetometer Z (lsb)";
            CSVheadings[(int)FileIndexes.CalInertialMagnetic] = "Packet Number,Gyroscope X (deg/s),Gyroscope Y (deg/s),Gyroscope Z (deg/s),Accelerometer X (g),Accelerometer Y (g),Accelerometer Z (g),Magnetometer X (G),Magnetometer Y (G),Magnetometer Z (G)";
            CSVheadings[(int)FileIndexes.Quaternion] = "Packet Number,Element 1, Element 2, Element 3, Element 4";
            CSVheadings[(int)FileIndexes.RotationMatrix] = "Packet Number,Element 11, Element 12, Element 13, Element 21, Element 22, Element 23, Element 31, Element 32, Element 33";
            CSVheadings[(int)FileIndexes.EulerAngles] = "Packet Number,Roll | Phi | X (deg), Pitch | Theta | Y (deg), Yaw | Psi | Z (deg)";
            CSVheadings[(int)FileIndexes.DigitalIO] = "Packet Number,AX0 Direction, AX1 Direction, AX2 Direction, AX3 Direction, AX4 Direction, AX5 Direction, AX6 Direction, AX7 Direction, AX0 State, AX1 State, AX2 State, AX3 State, AX4 State, AX5 State, AX6 State, AX7 State,";
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
            else if (xIMUdataObject is RawInertialMagData) WriteRawInertialMagData((RawInertialMagData)xIMUdataObject);
            else if (xIMUdataObject is CalInertialMagData) WriteCalInertialMagData((CalInertialMagData)xIMUdataObject);
            else if (xIMUdataObject is QuaternionData) WriteQuaternionData((QuaternionData)xIMUdataObject);
            else if (xIMUdataObject is DigitalIOdata) WriteDigitalIOdata((DigitalIOdata)xIMUdataObject);
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
            if (writesEnabled)
            {
                if (streamWriters[(int)FileIndexes.Errors] == null)
                {
                    streamWriters[(int)FileIndexes.Errors] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.Errors.ToString() + ".csv", false);
                    streamWriters[(int)FileIndexes.Errors].WriteLine(CSVheadings[(int)FileIndexes.Errors]);
                }
                streamWriters[(int)FileIndexes.Errors].WriteLine(Convert.ToString(packetNumber) + "," + Convert.ToString(errorData.ErrorCode) + "," + errorData.GetMessage());
                packetNumber++;
            }
        }

        /// <summary>
        /// Write command message to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="commandData">
        /// x-IMU command data.
        /// </param>
        public void WriteCommandData(CommandData commandData)
        {
            if (writesEnabled)
            {
                if (streamWriters[(int)FileIndexes.Commands] == null)
                {
                    streamWriters[(int)FileIndexes.Commands] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.Commands.ToString() + ".csv", false);
                    streamWriters[(int)FileIndexes.Commands].WriteLine(CSVheadings[(int)FileIndexes.Commands]);
                }
                streamWriters[(int)FileIndexes.Commands].WriteLine(Convert.ToString(packetNumber) + "," + Convert.ToString(commandData.CommandCode) + "," + commandData.GetMessage());
                packetNumber++;
            }
        }

        /// <summary>
        /// Write register data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="registerData">
        /// x-IMU register data.
        /// </param>
        public void WriteRegisterData(RegisterData registerData)
        {
            if (writesEnabled)
            {
                if (streamWriters[(int)FileIndexes.Registers] == null)
                {
                    streamWriters[(int)FileIndexes.Registers] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.Registers.ToString() + ".csv", false);
                    streamWriters[(int)FileIndexes.Registers].WriteLine(CSVheadings[(int)FileIndexes.Registers]);
                }
                float floatValue = (float)registerData.Value;
                try
                {
                    floatValue = registerData.floatValue;
                }
                catch { }
                streamWriters[(int)FileIndexes.Registers].WriteLine(Convert.ToString(packetNumber) + "," + Convert.ToString(registerData.Address) + "," +
                                                                    Convert.ToString(registerData.Value) + "," + Convert.ToString(floatValue) + "," +
                                                                    Enum.GetName(typeof(RegisterAddresses), registerData.Address));
                packetNumber++;
            }
        }

        /// <summary>
        /// Write date/time data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="dateTimeData">
        /// x-IMU data/time data.
        /// </param>
        public void WriteDateTimeData(DateTimeData dateTimeData)
        {
            if (writesEnabled)
            {
                if (streamWriters[(int)FileIndexes.DateTime] == null)
                {
                    streamWriters[(int)FileIndexes.DateTime] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.DateTime.ToString() + ".csv", false);
                    streamWriters[(int)FileIndexes.DateTime].WriteLine(CSVheadings[(int)FileIndexes.DateTime]);
                }
                streamWriters[(int)FileIndexes.DateTime].WriteLine(Convert.ToString(packetNumber) + "," + dateTimeData.ConvertToString());
                packetNumber++;
            }
        }

        /// <summary>
        /// Writes raw battery and thermometer data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="rawBattThermData">
        /// x-IMU raw battery and thermometer data.
        /// </param>
        public void WriteRawBattThermData(RawBattThermData rawBattThermData)
        {
            if (writesEnabled)
            {
                if (streamWriters[(int)FileIndexes.RawBattTherm] == null)
                {
                    streamWriters[(int)FileIndexes.RawBattTherm] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.RawBattTherm.ToString() + ".csv", false);
                    streamWriters[(int)FileIndexes.RawBattTherm].WriteLine(CSVheadings[(int)FileIndexes.RawBattTherm]);
                }
                streamWriters[(int)FileIndexes.RawBattTherm].WriteLine(Convert.ToString(packetNumber) + "," + rawBattThermData.ConvertToCSV());
                packetNumber++;
            }
        }

        /// <summary>
        /// Writes calibrated battery and thermometer data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="calBattThermData">
        /// x-IMU calibrated battery and thermometer data.
        /// </param>
        public void WriteCalBattThermData(CalBattThermData calBattThermData)
        {
            if (writesEnabled)
            {
                if (streamWriters[(int)FileIndexes.CalBattTherm] == null)
                {
                    streamWriters[(int)FileIndexes.CalBattTherm] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.CalBattTherm.ToString() + ".csv", false);
                    streamWriters[(int)FileIndexes.CalBattTherm].WriteLine(CSVheadings[(int)FileIndexes.CalBattTherm]);
                }
                streamWriters[(int)FileIndexes.CalBattTherm].WriteLine(Convert.ToString(packetNumber) + "," + calBattThermData.ConvertToCSV());
                packetNumber++;
            }
        }

        /// <summary>
        /// Writes raw inertial/magnetic data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="rawInertialMagData">
        /// x-IMU raw inertial/magnetic data.
        /// </param>
        public void WriteRawInertialMagData(RawInertialMagData rawInertialMagData)
        {
            if (writesEnabled)
            {
                if (streamWriters[(int)FileIndexes.RawInertialMagnetic] == null)
                {
                    streamWriters[(int)FileIndexes.RawInertialMagnetic] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.RawInertialMagnetic.ToString() + ".csv", false);
                    streamWriters[(int)FileIndexes.RawInertialMagnetic].WriteLine(CSVheadings[(int)FileIndexes.RawInertialMagnetic]);
                }
                streamWriters[(int)FileIndexes.RawInertialMagnetic].WriteLine(Convert.ToString(packetNumber) + "," + rawInertialMagData.ConvertToCSV());
                packetNumber++;
            }
        }

        /// <summary>
        /// Writes calibrated inertial/magnetic data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="calInertialMagData">
        /// x-IMU calibrated inertial/magnetic data.
        /// </param>
        public void WriteCalInertialMagData(CalInertialMagData calInertialMagData)
        {
            if (writesEnabled)
            {
                if (streamWriters[(int)FileIndexes.CalInertialMagnetic] == null)
                {
                    streamWriters[(int)FileIndexes.CalInertialMagnetic] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.CalInertialMagnetic.ToString() + ".csv", false);
                    streamWriters[(int)FileIndexes.CalInertialMagnetic].WriteLine(CSVheadings[(int)FileIndexes.CalInertialMagnetic]);
                }
                streamWriters[(int)FileIndexes.CalInertialMagnetic].WriteLine(Convert.ToString(packetNumber) + "," + calInertialMagData.ConvertToCSV());
                packetNumber++;
            }
        }

        /// <summary>
        /// Writes quaternion data to quaternion, rotation matrix and Euler angles CSV files.  Will create new files if required.
        /// </summary>
        /// <param name="quaternionData">
        /// x-IMU quaternion data.
        /// </param>
        public void WriteQuaternionData(QuaternionData quaternionData)
        {
            if (writesEnabled)
            {
                if (streamWriters[(int)FileIndexes.Quaternion] == null)
                {
                    streamWriters[(int)FileIndexes.Quaternion] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.Quaternion.ToString() + ".csv", false);
                    streamWriters[(int)FileIndexes.Quaternion].WriteLine(CSVheadings[(int)FileIndexes.Quaternion]);
                }
                streamWriters[(int)FileIndexes.Quaternion].WriteLine(Convert.ToString(packetNumber) + "," + quaternionData.ConvertToCSV());
                if (streamWriters[(int)FileIndexes.RotationMatrix] == null)
                {
                    streamWriters[(int)FileIndexes.RotationMatrix] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.RotationMatrix.ToString() + ".csv", false);
                    streamWriters[(int)FileIndexes.RotationMatrix].WriteLine(CSVheadings[(int)FileIndexes.RotationMatrix]);
                }
                streamWriters[(int)FileIndexes.RotationMatrix].WriteLine(Convert.ToString(packetNumber) + "," + quaternionData.ConvertToRotationMatrixCSV());
                if (streamWriters[(int)FileIndexes.EulerAngles] == null)
                {
                    streamWriters[(int)FileIndexes.EulerAngles] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.EulerAngles.ToString() + ".csv", false);
                    streamWriters[(int)FileIndexes.EulerAngles].WriteLine(CSVheadings[(int)FileIndexes.EulerAngles]);
                }
                streamWriters[(int)FileIndexes.EulerAngles].WriteLine(Convert.ToString(packetNumber) + "," + quaternionData.ConvertToEulerAnglesCSV());
                packetNumber++;
            }
        }

        /// <summary>
        /// Writes digital I/O data to CSV file.  Will create new file if required.
        /// </summary>
        /// <param name="digitalIOdata">
        /// x-IMU digital I/O data.
        /// </param>
        public void WriteDigitalIOdata(DigitalIOdata digitalIOdata)
        {
            if (writesEnabled)
            {
                if (streamWriters[(int)FileIndexes.DigitalIO] == null)
                {
                    streamWriters[(int)FileIndexes.DigitalIO] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.DigitalIO.ToString() + ".csv", false);
                    streamWriters[(int)FileIndexes.DigitalIO].WriteLine(CSVheadings[(int)FileIndexes.DigitalIO]);
                }
                streamWriters[(int)FileIndexes.DigitalIO].WriteLine(Convert.ToString(packetNumber) + "," + digitalIOdata.ConvertToCSV());
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