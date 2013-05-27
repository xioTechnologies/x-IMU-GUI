using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xIMU_API
{
    /// <summary>
    /// Packet count class tracks number of packets set and received.
    /// </summary>
    public class PacketCount
    {
        #region Variables

        private enum index
        {
            PacketsReceivedErrors,
            TotalPacketsReceived,
            ErrorPacketsReceived,
            CommandPacketsReceived,
            RegisterDataPacketsReceived,
            DateTimeDataPacketsReceived,
            RawBattThermDataPacketsReceived,
            CalBattThermDataPacketsReceived,
            RawInertialMagDataPacketsReceived,
            CalInertialMagDataPacketsReceived,
            QuaternionDataPacketsReceived,
            DigitalIODataPacketsReceived,
            TotalPacketsSent,
            CommandPacketsSent,
            ReadRegisterPacketsSent,
            WriteRegisterPacketsSent,
            ReadDateTimePacketsSent,
            WriteDateTimePacketsSent,
            DigitalIODataPacketsSent,
            NumIndexes
        }

        private int[] array;

        #endregion

        #region Properties

        #region Packet received counters

        /// <summary>
        /// Gets or sets the number of packet received errors.
        /// </summary>
        public int PacketsReceivedErrors { get { return array[(int)index.PacketsReceivedErrors]; } set { array[(int)index.PacketsReceivedErrors] = value; } }

        /// <summary>
        /// Gets or sets the total number of packets received.
        /// </summary>
        public int TotalPacketsReceived { get { return array[(int)index.TotalPacketsReceived]; } set { array[(int)index.TotalPacketsReceived] = value; } }

        /// <summary>
        /// Gets or sets the number of error data packets received.
        /// </summary>
        public int ErrorPacketsReceived { get { return array[(int)index.ErrorPacketsReceived]; } set { array[(int)index.ErrorPacketsReceived] = value; } }

        /// <summary>
        /// Gets or sets the number of command data packets received.
        /// </summary>
        public int CommandPacketsReceived { get { return array[(int)index.CommandPacketsReceived]; } set { array[(int)index.CommandPacketsReceived] = value; } }

        /// <summary>
        /// Gets or sets the number of register data packets received.
        /// </summary>
        public int RegisterDataPacketsReceived { get { return array[(int)index.RegisterDataPacketsReceived]; } set { array[(int)index.RegisterDataPacketsReceived] = value; } }

        /// <summary>
        /// Gets or sets the number of date/time data packets received.
        /// </summary>
        public int DateTimeDataPacketsReceived { get { return array[(int)index.DateTimeDataPacketsReceived]; } set { array[(int)index.DateTimeDataPacketsReceived] = value; } }

        /// <summary>
        /// Gets or sets the number of raw battery and thermometer data packets received.
        /// </summary>
        public int RawBattThermDataPacketsReceived { get { return array[(int)index.RawBattThermDataPacketsReceived]; } set { array[(int)index.RawBattThermDataPacketsReceived] = value; } }

        /// <summary>
        /// Gets or sets the number of calibration battery and thermometer data packets received.
        /// </summary>
        public int CalBattThermDataPacketsReceived { get { return array[(int)index.CalBattThermDataPacketsReceived]; } set { array[(int)index.CalBattThermDataPacketsReceived] = value; } }

        /// <summary>
        /// Gets or sets the number of raw inertial/magnetic data packets received.
        /// </summary>
        public int RawInertialMagDataPacketsReceived { get { return array[(int)index.RawInertialMagDataPacketsReceived]; } set { array[(int)index.RawInertialMagDataPacketsReceived] = value; } }

        /// <summary>
        /// Gets or sets the number of calibrated inertial/magnetic data packets received.
        /// </summary>
        public int CalInertialMagDataPacketsReceived { get { return array[(int)index.CalInertialMagDataPacketsReceived]; } set { array[(int)index.CalInertialMagDataPacketsReceived] = value; } }

        /// <summary>
        /// Gets or sets the number of quaternion packets received.
        /// </summary>
        public int QuaternionDataPacketsReceived { get { return array[(int)index.QuaternionDataPacketsReceived]; } set { array[(int)index.QuaternionDataPacketsReceived] = value; } }

        /// <summary>
        /// Gets or sets the number of digital I/O data packets received.
        /// </summary>
        public int DigitalIODataPacketsReceived { get { return array[(int)index.DigitalIODataPacketsReceived]; } set { array[(int)index.DigitalIODataPacketsReceived] = value; } }

        #endregion

        #region Packet send counters

        /// <summary>
        /// Gets or sets the total number of packets sent.
        /// </summary>  
        public int TotalPacketsSent { get { return array[(int)index.TotalPacketsSent]; } set { array[(int)index.TotalPacketsSent] = value; } }

        /// <summary>
        /// Gets or sets the number of command packets sent.
        /// </summary>  
        public int CommandPacketsSent { get { return array[(int)index.CommandPacketsSent]; } set { array[(int)index.CommandPacketsSent] = value; } }

        /// <summary>
        /// Gets or sets the number of read register packets sent.
        /// </summary>  
        public int ReadRegisterPacketsSent { get { return array[(int)index.ReadRegisterPacketsSent]; } set { array[(int)index.ReadRegisterPacketsSent] = value; } }

        /// <summary>
        /// Gets or sets the number of write register packets sent.
        /// </summary>  
        public int WriteRegisterPacketsSent { get { return array[(int)index.WriteRegisterPacketsSent]; } set { array[(int)index.WriteRegisterPacketsSent] = value; } }

        /// <summary>
        /// Gets or sets the number of read date/time packets sent.
        /// </summary>  
        public int ReadDateTimePacketsSent { get { return array[(int)index.ReadDateTimePacketsSent]; } set { array[(int)index.ReadDateTimePacketsSent] = value; } }

        /// <summary>
        /// Gets or sets the number of write date/time packets sent.
        /// </summary>  
        public int WriteDateTimePacketsSent { get { return array[(int)index.WriteDateTimePacketsSent]; } set { array[(int)index.WriteDateTimePacketsSent] = value; } }

        /// <summary>
        /// Gets or sets the number of digital I/O data packets sent.
        /// </summary>
        public int DigitalIODataPacketsSent { get { return array[(int)index.DigitalIODataPacketsSent]; } set { array[(int)index.DigitalIODataPacketsSent] = value; } }

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
        /// Returns the difference in the number of packets between this and another specified <see cref="PacketCount"/> instance.
        /// </summary>
        /// <param name="packetCount">
        /// <see cref="PacketCount"/> instance that this instance will be subtracted from for the result.
        /// </param>
        /// <returns>
        /// Returns the difference in the number of packets between this specified <see cref="PacketCount"/> instance.
        /// </returns>
        public PacketCount Difference(PacketCount packetCount)
        {
            PacketCount packetCountDiff = new PacketCount(packetCount);
            for (int i = 0; i < array.Length; i++)
            {
                packetCountDiff.array[i] -= array[i];
            }
            return packetCountDiff;
        }

        #endregion
    }
}
