using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace xIMU_API
{
    /// <summary>
    /// ASCII data files class.
    /// </summary>
    public class ASCIIdataFiles
    {
        #region Variables

        /// <summary>
        /// File base path.
        /// </summary>
        private string privFileBasePath;

        /// <summary>
        /// Array of files used by data logging functionality.  A non-null value is used to enable file writes in data received event.
        /// </summary>
        private StreamWriter[] ASCIIfiles;

        /// <summary>
        /// CSV column headings for each file type.
        /// </summary>
        private string[] CSVheadings;

        /// <summary>
        /// Index of each file within array.  Each label is used as part of file name.
        /// </summary>
        private enum FileIndexes
        {
            ErrorMessages,
            CommandConfirmations,
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
        /// Gets the file base path.
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
        /// Initializes a new instance of the <see cref="T:ASCIIdataFiles"/> class.
        /// </summary>
        /// <param name="fileBasePath">
        /// Base path of file.  File name automatically extended with appropriate identifier and file extension.
        /// </param>
        public ASCIIdataFiles(string fileBasePath)
        {
            if (Directory.Exists(Path.GetDirectoryName(fileBasePath)) && (Path.GetFileName(fileBasePath) != ""))
            {
                privFileBasePath = fileBasePath;
            }
            else
            {
                throw new Exception("Invalid file path.");
            }
            ASCIIfiles = new StreamWriter[(int)FileIndexes.NumberOfFiles];
            CSVheadings = new string[(int)FileIndexes.NumberOfFiles];
            CSVheadings[(int)FileIndexes.DateTime] = null;
            CSVheadings[(int)FileIndexes.RawBattTherm] = "Battery voltage (lsb),Thermometer (lsb)";
            CSVheadings[(int)FileIndexes.CalBattTherm] = "Battery voltage (V),Thermometer (degC)";
            CSVheadings[(int)FileIndexes.RawInertialMagnetic] = "Gyroscope X (lsb),Gyroscope Y (lsb),Gyroscope Z (lsb),Accelerometer X (lsb),Accelerometer Y (lsb),Accelerometer Z (lsb),Magnetometer X (lsb),Magnetometer Y (lsb),Magnetometer Z (lsb)";
            CSVheadings[(int)FileIndexes.CalInertialMagnetic] = "Gyroscope X (deg/s),Gyroscope Y (deg/s),Gyroscope Z (deg/s),Accelerometer X (g),Accelerometer Y (g),Accelerometer Z (g),Magnetometer X (G),Magnetometer Y (G),Magnetometer Z (G)";
            CSVheadings[(int)FileIndexes.Quaternion] = "Element 1, Element 2, Element 3, Element 4";
            CSVheadings[(int)FileIndexes.RotationMatrix] = "Element 11, Element 12, Element 13, Element 21, Element 22, Element 23, Element 31, Element 32, Element 33";
            CSVheadings[(int)FileIndexes.EulerAngles] = "Roll | Phi | X (deg), Pitch | Theta | Y (deg), Yaw | Psi | Z (deg)";
            CSVheadings[(int)FileIndexes.DigitalIO] = "AX0 Direction, AX1 Direction, AX2 Direction, AX3 Direction, AX4 Direction, AX5 Direction, AX6 Direction, AX7 Direction, AX0 State, AX1 State, AX2 State, AX3 State, AX4 State, AX5 State, AX6 State, AX7 State,";
        }

        #endregion

        #region Methods

        /// <summary>
        /// Write xIMUdata object to appropriate ASCII file.  Will create new file if required.
        /// </summary>
        /// <param name="xIMUdataObject">
        /// x-IMU data object.
        /// </param>
        public void WriteData(xIMUdata xIMUdataObject)
        {
            if (xIMUdataObject is ErrorData) WriteErrorData((ErrorData)(xIMUdataObject));
            else if (xIMUdataObject is CommandData) WriteCommandData((CommandData)(xIMUdataObject));
            else if (xIMUdataObject is DateTimeData) WriteDateTimeData((DateTimeData)(xIMUdataObject));
            else if (xIMUdataObject is RawBattThermData) WriteRawBattThermData((RawBattThermData)(xIMUdataObject));
            else if (xIMUdataObject is CalBattThermData) WriteCalBattThermData((CalBattThermData)(xIMUdataObject));
            else if (xIMUdataObject is RawInertialMagData) WriteRawInertialMagData((RawInertialMagData)(xIMUdataObject));
            else if (xIMUdataObject is CalInertialMagData) WriteCalInertialMagData((CalInertialMagData)(xIMUdataObject));
            else if (xIMUdataObject is QuaternionData) WriteQuaternionData((QuaternionData)(xIMUdataObject));
            else if (xIMUdataObject is DigitalIOdata) WriteDigitalIOdata((DigitalIOdata)(xIMUdataObject));
        }

        /// <summary>
        /// Write error message to .txt file.  Will create new file if required.
        /// </summary>
        /// <param name="errorData">
        /// x-IMU error data.
        /// </param>
        public void WriteErrorData(ErrorData errorData)
        {
            if (ASCIIfiles[(int)FileIndexes.ErrorMessages] == null)
            {
                ASCIIfiles[(int)FileIndexes.ErrorMessages] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.ErrorMessages.ToString() + ".txt", false);
            }
            ASCIIfiles[(int)FileIndexes.ErrorMessages].WriteLine(errorData.GetMessage());
        }

        /// <summary>
        /// Write command message to .txt file.  Will create new file if required.
        /// </summary>
        /// <param name="commandData">
        /// x-IMU command data.
        /// </param>
        public void WriteCommandData(CommandData commandData)
        {
            if (ASCIIfiles[(int)FileIndexes.CommandConfirmations] == null)
            {
                ASCIIfiles[(int)FileIndexes.CommandConfirmations] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.CommandConfirmations.ToString() + ".txt", false);
            }
            ASCIIfiles[(int)FileIndexes.CommandConfirmations].WriteLine(commandData.GetMessage());
        }

        /// <summary>
        /// Write date/time data to .txt file.  Will create new file if required.
        /// </summary>
        /// <param name="dateTimeData">
        /// x-IMU data/time data.
        /// </param>
        public void WriteDateTimeData(DateTimeData dateTimeData)
        {
            if (ASCIIfiles[(int)FileIndexes.DateTime] == null)
            {
                ASCIIfiles[(int)FileIndexes.DateTime] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.DateTime.ToString() + ".txt", false);
            }
            ASCIIfiles[(int)FileIndexes.DateTime].WriteLine(dateTimeData.ConvertToString());
        }

        /// <summary>
        /// Writes raw battery and thermometer data to .csv file.  Will create new file if required.
        /// </summary>
        /// <param name="rawBattThermData">
        /// x-IMU raw battery and thermometer data.
        /// </param>
        public void WriteRawBattThermData(RawBattThermData rawBattThermData)
        {
            if (ASCIIfiles[(int)FileIndexes.RawBattTherm] == null)
            {
                ASCIIfiles[(int)FileIndexes.RawBattTherm] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.RawBattTherm.ToString() + ".csv", false);
                ASCIIfiles[(int)FileIndexes.RawBattTherm].WriteLine(CSVheadings[(int)FileIndexes.RawBattTherm]);
            }
            ASCIIfiles[(int)FileIndexes.RawBattTherm].WriteLine(rawBattThermData.ConvertToCSV());
        }

        /// <summary>
        /// Writes calibrated battery and thermometer data to .csv file.  Will create new file if required.
        /// </summary>
        /// <param name="calBattThermData">
        /// x-IMU calibrated battery and thermometer data.
        /// </param>
        public void WriteCalBattThermData(CalBattThermData calBattThermData)
        {
            if (ASCIIfiles[(int)FileIndexes.CalBattTherm] == null)
            {
                ASCIIfiles[(int)FileIndexes.CalBattTherm] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.CalBattTherm.ToString() + ".csv", false);
                ASCIIfiles[(int)FileIndexes.CalBattTherm].WriteLine(CSVheadings[(int)FileIndexes.CalBattTherm]);
            }
            ASCIIfiles[(int)FileIndexes.CalBattTherm].WriteLine(calBattThermData.ConvertToCSV());
        }

        /// <summary>
        /// Writes raw inertial/magnetic data to .csv file.  Will create new file if required.
        /// </summary>
        /// <param name="rawInertialMagData">
        /// x-IMU raw inertial/magnetic data.
        /// </param>
        public void WriteRawInertialMagData(RawInertialMagData rawInertialMagData)
        {
            if (ASCIIfiles[(int)FileIndexes.RawInertialMagnetic] == null)
            {
                ASCIIfiles[(int)FileIndexes.RawInertialMagnetic] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.RawInertialMagnetic.ToString() + ".csv", false);
                ASCIIfiles[(int)FileIndexes.RawInertialMagnetic].WriteLine(CSVheadings[(int)FileIndexes.RawInertialMagnetic]);
            }
            ASCIIfiles[(int)FileIndexes.RawInertialMagnetic].WriteLine(rawInertialMagData.ConvertToCSV());
        }

        /// <summary>
        /// Writes calibrated inertial/magnetic data to .csv file.  Will create new file if required.
        /// </summary>
        /// <param name="calInertialMagData">
        /// x-IMU calibrated inertial/magnetic data.
        /// </param>
        public void WriteCalInertialMagData(CalInertialMagData calInertialMagData)
        {
            if (ASCIIfiles[(int)FileIndexes.CalInertialMagnetic] == null)
            {
                ASCIIfiles[(int)FileIndexes.CalInertialMagnetic] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.CalInertialMagnetic.ToString() + ".csv", false);
                ASCIIfiles[(int)FileIndexes.CalInertialMagnetic].WriteLine(CSVheadings[(int)FileIndexes.CalInertialMagnetic]);
            }
            ASCIIfiles[(int)FileIndexes.CalInertialMagnetic].WriteLine(calInertialMagData.ConvertToCSV());
        }

        /// <summary>
        /// Writes quaternion data to quaternion, rotation matrix and Euler angles .csv files.  Will create new files if required.
        /// </summary>
        /// <param name="quaternionData">
        /// x-IMU quaternion data.
        /// </param>
        public void WriteQuaternionData(QuaternionData quaternionData)
        {
            if (ASCIIfiles[(int)FileIndexes.Quaternion] == null)
            {
                ASCIIfiles[(int)FileIndexes.Quaternion] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.Quaternion.ToString() + ".csv", false);
                ASCIIfiles[(int)FileIndexes.Quaternion].WriteLine(CSVheadings[(int)FileIndexes.Quaternion]);
            }
            ASCIIfiles[(int)FileIndexes.Quaternion].WriteLine(quaternionData.ConvertToCSV());
            if (ASCIIfiles[(int)FileIndexes.RotationMatrix] == null)
            {
                ASCIIfiles[(int)FileIndexes.RotationMatrix] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.RotationMatrix.ToString() + ".csv", false);
                ASCIIfiles[(int)FileIndexes.RotationMatrix].WriteLine(CSVheadings[(int)FileIndexes.RotationMatrix]);
            }
            ASCIIfiles[(int)FileIndexes.RotationMatrix].WriteLine(quaternionData.ConvertToRotationMatrixCSV());
            if (ASCIIfiles[(int)FileIndexes.EulerAngles] == null)
            {
                ASCIIfiles[(int)FileIndexes.EulerAngles] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.EulerAngles.ToString() + ".csv", false);
                ASCIIfiles[(int)FileIndexes.EulerAngles].WriteLine(CSVheadings[(int)FileIndexes.EulerAngles]);
            }
            ASCIIfiles[(int)FileIndexes.EulerAngles].WriteLine(quaternionData.ConvertToEulerAnglesCSV());
        }

        /// <summary>
        /// Writes digital I/O data to .csv file.  Will create new file if required.
        /// </summary>
        /// <param name="digitalIOdata">
        /// x-IMU digital I/O data.
        /// </param>
        public void WriteDigitalIOdata(DigitalIOdata digitalIOdata)
        {
            if (ASCIIfiles[(int)FileIndexes.DigitalIO] == null)
            {
                ASCIIfiles[(int)FileIndexes.DigitalIO] = new System.IO.StreamWriter(FileBasePath + "_" + FileIndexes.DigitalIO.ToString() + ".csv", false);
                ASCIIfiles[(int)FileIndexes.DigitalIO].WriteLine(CSVheadings[(int)FileIndexes.DigitalIO]);
            }
            ASCIIfiles[(int)FileIndexes.DigitalIO].WriteLine(digitalIOdata.ConvertToCSV());
        }

        /// <summary>
        /// Closes all open ASCII files and returns file names of files created.
        /// </summary>
        /// <returns>
        /// File names of files created.
        /// </returns>
        public string[] CloseFiles()
        {
            List<string> fileNames = new List<string>();
            for (int i = 0; i < (int)FileIndexes.NumberOfFiles; i++)
            {
                if (ASCIIfiles[i] != null)
                {
                    fileNames.Add(Path.GetFileName(((FileStream)ASCIIfiles[i].BaseStream).Name));
                    ASCIIfiles[i].Close();
                    ASCIIfiles[i] = null;
                }
            }
            return fileNames.ToArray();
        }

        #endregion
    }
}