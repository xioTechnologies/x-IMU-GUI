using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xIMU_API
{
    /// <summary>
    /// Packet count class tracks number of packets read and written.
    /// </summary>
    public class PacketCount
    {
        #region Variables

        private enum index
        {
            PacketsReadErrors,
            TotalPacketsRead,
            ErrorPacketsRead,
            CommandPacketsRead,
            RegisterDataPacketsRead,
            DateTimeDataPacketsRead,
            RawBattThermDataPacketsRead,
            CalBattThermDataPacketsRead,
            RawInertialMagDataPacketsRead,
            CalInertialMagDataPacketsRead,
            QuaternionDataPacketsRead,
            DigitalIODataPacketsRead,
            TotalPacketsWritten,
            CommandPacketsWritten,
            ReadRegisterPacketsWritten,
            WriteRegisterPacketsWritten,
            ReadDateTimePacketsWritten,
            WriteDateTimePacketsWritten,
            DigitalIODataPacketsWritten,
            NumIndexes
        }

        private int[] array;

        #endregion

        #region Properties

        #region Packet read counters

        /// <summary>
        /// Gets or sets the number of packet read errors.
        /// </summary>
        public int PacketsReadErrors { get { return array[(int)index.PacketsReadErrors]; } set { array[(int)index.PacketsReadErrors] = value; } }

        /// <summary>
        /// Gets or sets the total number of packets read.
        /// </summary>
        public int TotalPacketsRead { get { return array[(int)index.TotalPacketsRead]; } set { array[(int)index.TotalPacketsRead] = value; } }

        /// <summary>
        /// Gets or sets the number of error data packets read.
        /// </summary>
        public int ErrorPacketsRead { get { return array[(int)index.ErrorPacketsRead]; } set { array[(int)index.ErrorPacketsRead] = value; } }

        /// <summary>
        /// Gets or sets the number of command data packets read.
        /// </summary>
        public int CommandPacketsRead { get { return array[(int)index.CommandPacketsRead]; } set { array[(int)index.CommandPacketsRead] = value; } }

        /// <summary>
        /// Gets or sets the number of register data packets read.
        /// </summary>
        public int RegisterDataPacketsRead { get { return array[(int)index.RegisterDataPacketsRead]; } set { array[(int)index.RegisterDataPacketsRead] = value; } }

        /// <summary>
        /// Gets or sets the number of date/time data packets read.
        /// </summary>
        public int DateTimeDataPacketsRead { get { return array[(int)index.DateTimeDataPacketsRead]; } set { array[(int)index.DateTimeDataPacketsRead] = value; } }

        /// <summary>
        /// Gets or sets the number of raw battery and thermometer data packets read.
        /// </summary>
        public int RawBattThermDataPacketsRead { get { return array[(int)index.RawBattThermDataPacketsRead]; } set { array[(int)index.RawBattThermDataPacketsRead] = value; } }

        /// <summary>
        /// Gets or sets the number of calibration battery and thermometer data packets read.
        /// </summary>
        public int CalBattThermDataPacketsRead { get { return array[(int)index.CalBattThermDataPacketsRead]; } set { array[(int)index.CalBattThermDataPacketsRead] = value; } }

        /// <summary>
        /// Gets or sets the number of raw inertial/magnetic data packets read.
        /// </summary>
        public int RawInertialMagDataPacketsRead { get { return array[(int)index.RawInertialMagDataPacketsRead]; } set { array[(int)index.RawInertialMagDataPacketsRead] = value; } }

        /// <summary>
        /// Gets or sets the number of calibrated inertial/magnetic data packets read.
        /// </summary>
        public int CalInertialMagDataPacketsRead { get { return array[(int)index.CalInertialMagDataPacketsRead]; } set { array[(int)index.CalInertialMagDataPacketsRead] = value; } }

        /// <summary>
        /// Gets or sets the number of quaternion packets read.
        /// </summary>
        public int QuaternionDataPacketsRead { get { return array[(int)index.QuaternionDataPacketsRead]; } set { array[(int)index.QuaternionDataPacketsRead] = value; } }

        /// <summary>
        /// Gets or sets the number of digital I/O data packets read.
        /// </summary>
        public int DigitalIODataPacketsRead { get { return array[(int)index.DigitalIODataPacketsRead]; } set { array[(int)index.DigitalIODataPacketsRead] = value; } }

        #endregion

        #region Packet write counters

        /// <summary>
        /// Gets or sets the total number of packets written.
        /// </summary>  
        public int TotalPacketsWritten { get { return array[(int)index.TotalPacketsWritten]; } set { array[(int)index.TotalPacketsWritten] = value; } }

        /// <summary>
        /// Gets or sets the number of command packets written.
        /// </summary>  
        public int CommandPacketsWritten { get { return array[(int)index.CommandPacketsWritten]; } set { array[(int)index.CommandPacketsWritten] = value; } }

        /// <summary>
        /// Gets or sets the number of read register packets written.
        /// </summary>  
        public int ReadRegisterPacketsWritten { get { return array[(int)index.ReadRegisterPacketsWritten]; } set { array[(int)index.ReadRegisterPacketsWritten] = value; } }

        /// <summary>
        /// Gets or sets the number of write register packets written.
        /// </summary>  
        public int WriteRegisterPacketsWritten { get { return array[(int)index.WriteRegisterPacketsWritten]; } set { array[(int)index.WriteRegisterPacketsWritten] = value; } }

        /// <summary>
        /// Gets or sets the number of read date/time packets written.
        /// </summary>  
        public int ReadDateTimePacketsWritten { get { return array[(int)index.ReadDateTimePacketsWritten]; } set { array[(int)index.ReadDateTimePacketsWritten] = value; } }

        /// <summary>
        /// Gets or sets the number of write date/time packets written.
        /// </summary>  
        public int WriteDateTimePacketsWritten { get { return array[(int)index.WriteDateTimePacketsWritten]; } set { array[(int)index.WriteDateTimePacketsWritten] = value; } }

        /// <summary>
        /// Gets or sets the number of digital I/O data packets written.
        /// </summary>
        public int DigitalIODataPacketsWritten { get { return array[(int)index.DigitalIODataPacketsWritten]; } set { array[(int)index.DigitalIODataPacketsWritten] = value; } }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PacketCount"/> class.
        /// </summary>
        public PacketCount()
        {
            array = new int[(int)index.NumIndexes];
            Reset();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PacketCount"/> class.
        /// </summary>
        /// <param name="packetCount">
        /// Existing instance of <see cref="PacketCount"/> to copy.
        /// </param>
        public PacketCount(PacketCount packetCount)
        {
            array = new int[(int)index.NumIndexes];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = packetCount.array[i];
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Resets all packet counts to zero.
        /// </summary>
        internal void Reset()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }

        /// <summary>
        /// Returns the difference between the current and previous packet count.
        /// </summary>
        /// <param name="previousPacketCount">
        /// Previous packet count.
        /// </param>
        /// <returns>
        /// Difference between the current and previous packet count.
        /// </returns>
        public PacketCount Difference(PacketCount previousPacketCount)
        {
            PacketCount packetCountDiff = new PacketCount(this);
            for (int i = 0; i < array.Length; i++)
            {
                packetCountDiff.array[i] -= previousPacketCount.array[i];
            }
            return packetCountDiff;
        }

        #endregion
    }
}
