using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Packet count class to count number of packets read/written.
    /// </summary>
    public class PacketCount
    {
        /// <summary>
        /// Private array of packet counts.
        /// </summary>
        private int[] packetCounts;

        /// <summary>
        /// Gets or sets the total number of packet count.
        /// </summary>
        public int TotalPackets { get { return packetCounts.Sum(); } }

        /// <summary>
        /// Gets or sets the error Error packet count.
        /// </summary>
        public int ErrorPackets { get { return packetCounts[(int)PacketHeaders.Error]; } set { packetCounts[(int)PacketHeaders.Error] = value; } }

        /// <summary>
        /// Gets or sets the Command packet count.
        /// </summary>
        public int CommandPackets { get { return packetCounts[(int)PacketHeaders.Command]; } set { packetCounts[(int)PacketHeaders.Command] = value; } }

        /// <summary>
        /// Gets or sets the ReadRegister packet count.
        /// </summary>
        public int ReadRegisterPackets { get { return packetCounts[(int)PacketHeaders.ReadRegister]; } set { packetCounts[(int)PacketHeaders.ReadRegister] = value; } }

        /// <summary>
        /// Gets or sets the WriteRegister packet count.
        /// </summary>
        public int WriteRegisterPackets { get { return packetCounts[(int)PacketHeaders.WriteRegister]; } set { packetCounts[(int)PacketHeaders.WriteRegister] = value; } }

        /// <summary>
        /// Gets or sets the ReadDateTime packet count.
        /// </summary>
        public int ReadDateTimePackets { get { return packetCounts[(int)PacketHeaders.ReadDateTime]; } set { packetCounts[(int)PacketHeaders.ReadDateTime] = value; } }

        /// <summary>
        /// Gets or sets the WriteDateTime packet count.
        /// </summary>
        public int WriteDateTimePackets { get { return packetCounts[(int)PacketHeaders.WriteDateTime]; } set { packetCounts[(int)PacketHeaders.WriteDateTime] = value; } }

        /// <summary>
        /// Gets or sets the RawBatteryAndThermometerData packet count.
        /// </summary>
        public int RawBatteryAndThermometerDataPackets { get { return packetCounts[(int)PacketHeaders.RawBatteryAndThermometerData]; } set { packetCounts[(int)PacketHeaders.RawBatteryAndThermometerData] = value; } }

        /// <summary>
        /// Gets or sets the CalBatteryAndThermometerData packet count.
        /// </summary>
        public int CalBatteryAndThermometerDataPackets { get { return packetCounts[(int)PacketHeaders.CalBatteryAndThermometerData]; } set { packetCounts[(int)PacketHeaders.CalBatteryAndThermometerData] = value; } }

        /// <summary>
        /// Gets or sets the RawInertialAndMagneticData packet count.
        /// </summary>
        public int RawInertialAndMagneticDataPackets { get { return packetCounts[(int)PacketHeaders.RawInertialAndMagneticData]; } set { packetCounts[(int)PacketHeaders.RawInertialAndMagneticData] = value; } }

        /// <summary>
        /// Gets or sets the CalInertialAndMagneticData packet count.
        /// </summary>
        public int CalInertialAndMagneticDataPackets { get { return packetCounts[(int)PacketHeaders.CalInertialAndMagneticData]; } set { packetCounts[(int)PacketHeaders.CalInertialAndMagneticData] = value; } }

        /// <summary>
        /// Gets or sets the QuaternionData packet count.
        /// </summary>
        public int QuaternionDataPackets { get { return packetCounts[(int)PacketHeaders.QuaternionData]; } set { packetCounts[(int)PacketHeaders.QuaternionData] = value; } }

        /// <summary>
        /// Gets or sets the DigitalIOdata packet count.
        /// </summary>
        public int DigitalIOdataPackets { get { return packetCounts[(int)PacketHeaders.DigitalIOdata]; } set { packetCounts[(int)PacketHeaders.DigitalIOdata] = value; } }

        /// <summary>
        /// Gets or sets the RawAnalogueInputData packet count.
        /// </summary>
        public int RawAnalogueInputDataPackets { get { return packetCounts[(int)PacketHeaders.RawAnalogueInputData]; } set { packetCounts[(int)PacketHeaders.RawAnalogueInputData] = value; } }

        /// <summary>
        /// Gets or sets the CalAnalogueInputData packet count.
        /// </summary>
        public int CalAnalogueInputDataPackets { get { return packetCounts[(int)PacketHeaders.CalAnalogueInputData]; } set { packetCounts[(int)PacketHeaders.CalAnalogueInputData] = value; } }

        /// <summary>
        /// Gets or sets the PWMoutputData packet count.
        /// </summary>
        public int PWMoutputDataPackets { get { return packetCounts[(int)PacketHeaders.PWMoutputData]; } set { packetCounts[(int)PacketHeaders.PWMoutputData] = value; } }

        /// <summary>
        /// Gets or sets the RawADXL345busData packet count.
        /// </summary>
        public int RawADXL345busDataPackets { get { return packetCounts[(int)PacketHeaders.RawADXL345busData]; } set { packetCounts[(int)PacketHeaders.RawADXL345busData] = value; } }

        /// <summary>
        /// Gets or sets the CalADXL345busData packet count.
        /// </summary>
        public int CalADXL345busDataPackets { get { return packetCounts[(int)PacketHeaders.CalADXL345busData]; } set { packetCounts[(int)PacketHeaders.CalADXL345busData] = value; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="PacketCount"/> class.
        /// </summary>
        public PacketCount()
        {
            packetCounts = new int[Enum.GetValues(typeof(PacketHeaders)).Length];
            Reset();
        }

        /// <summary>
        /// Resets all packet counts to zero.
        /// </summary>
        internal void Reset()
        {
            Array.Clear(packetCounts, 0, packetCounts.Length);
        }
    }
}