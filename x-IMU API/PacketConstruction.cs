using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Packet construction class. Contains static methods for packet construction and deconstruction.
    /// </summary>
    internal class PacketConstruction
    {
        #region Packet construction

        /// <summary>
        /// Constructs an encoded command packet.
        /// </summary>
        /// <param name="commandCode">
        /// Command code. See <see cref="CommandCodes"/>.
        /// </param> 
        /// <returns>
        /// Constructed and encoded command packet.
        /// </returns> 
        public static byte[] ConstructCommandPacket(CommandCodes commandCode)
        {
            byte[] decodedPacket = new byte[] { (byte)PacketHeaders.Command,
                                                (byte)((ushort)commandCode >> 8),
                                                (byte)commandCode,
                                                0};
            decodedPacket = InsertChecksum(decodedPacket);
            return PacketEncoding.EncodePacket(decodedPacket);
        }

        /// <summary>
        /// Constructs a read register packet.
        /// </summary>
        /// <param name="registerData">
        /// <see cref="RegisterData"/> instance containing register address to be read.
        /// </param>
        /// <returns>
        /// Constructed and encoded read register packet
        /// </returns> 
        public static byte[] ConstructReadRegisterPacket(RegisterData registerData)
        {
            byte[] decodedPacket = new byte[] { (byte)PacketHeaders.ReadRegister,
                                                (byte)(registerData.Address >> 8),
                                                (byte)registerData.Address,
                                                0};
            decodedPacket = InsertChecksum(decodedPacket);
            return PacketEncoding.EncodePacket(decodedPacket);
        }

        /// <summary>
        /// Constructs a write register packet.
        /// </summary>
        /// <param name="registerData">
        /// <see cref="RegisterData"/> instance containing register address and value to be written.
        /// </param>
        /// <returns>
        /// Constructed and encoded write register packet
        /// </returns> 
        public static byte[] ConstructWriteRegisterPacket(RegisterData registerData)
        {
            byte[] decodedPacket = new byte[] { (byte)PacketHeaders.WriteRegister,
                                                (byte)(registerData.Address >> 8),
                                                (byte)registerData.Address,
                                                (byte)(registerData.Value >> 8),
                                                (byte)registerData.Value,
                                                0};
            decodedPacket = InsertChecksum(decodedPacket);
            return PacketEncoding.EncodePacket(decodedPacket);
        }

        /// <summary>
        /// Constructs a read date/time packet.
        /// </summary>
        /// <returns>
        /// Constructed and encoded read date/time packet
        /// </returns> 
        public static byte[] ConstructReadDateTimePacket()
        {
            byte[] decodedPacket = new byte[] { (byte)PacketHeaders.ReadDateTime,
                                                0};
            decodedPacket = InsertChecksum(decodedPacket);
            return PacketEncoding.EncodePacket(decodedPacket);
        }

        /// <summary>
        /// Constructs a write date/time packet.
        /// </summary>
        /// <param name="dateTimeData">
        /// <see cref="DateTimeData"/> instance containing data to be written.
        /// </param>
        /// <returns>
        /// Constructed and encoded write date/time packet
        /// </returns> 
        public static byte[] ConstructWriteDateTimePacket(DateTimeData dateTimeData)
        {
            byte[] decodedPacket = new byte[] { (byte)PacketHeaders.WriteDateTime,
                                                (byte)(((((dateTimeData.Year - 2000) % 100) / 10) << 4) | ((dateTimeData.Year - 2000) % 10)),
                                                (byte)(((((dateTimeData.Month) % 100) / 10) << 4) | (dateTimeData.Month % 10)),
                                                (byte)(((((dateTimeData.Date) % 100) / 10) << 4) | (dateTimeData.Date % 10)),
                                                (byte)(((((dateTimeData.Hours) % 100) / 10) << 4) | (dateTimeData.Hours % 10)),
                                                (byte)(((((dateTimeData.Minutes) % 100) / 10) << 4) | (dateTimeData.Minutes % 10)),
                                                (byte)(((((dateTimeData.Seconds) % 100) / 10) << 4) | (dateTimeData.Seconds % 10)),
                                                0};
            decodedPacket = InsertChecksum(decodedPacket);
            return PacketEncoding.EncodePacket(decodedPacket);
        }

        /// <summary>
        /// Constructs an encoded digital I/O packet.
        /// </summary>
        /// <param name="digitalIOdata">
        /// DigitalIOdata object containing output states to be set.
        /// </param> 
        /// <returns>
        /// Constructed and encoded digital I/O packet.
        /// </returns> 
        public static byte[] ConstructDigitalIOpacket(DigitalIOdata digitalIOdata)
        {
            byte[] decodedPacket = new byte[] { (byte)PacketHeaders.DigitalIOdata,
                                                0x00,
                                                digitalIOdata.State.PortByte,
                                                0};
            decodedPacket = InsertChecksum(decodedPacket);
            return PacketEncoding.EncodePacket(decodedPacket);
        }

        /// <summary>
        /// Constructs an encoded PWM output data packet.
        /// </summary>
        /// <param name="_PWMoutputData">
        /// PWM output data.
        /// </param>
        /// <returns>
        /// Constructed and encoded PWM output data packet.
        /// </returns>
        public static byte[] ConstructPWMoutputPacket(PWMoutputData _PWMoutputData)
        {
            short AX0short = FixedFloat.FloatToFixed(_PWMoutputData.AX0, Qvals.PWMoutput);
            short AX2short = FixedFloat.FloatToFixed(_PWMoutputData.AX2, Qvals.PWMoutput);
            short AX4short = FixedFloat.FloatToFixed(_PWMoutputData.AX4, Qvals.PWMoutput);
            short AX6short = FixedFloat.FloatToFixed(_PWMoutputData.AX6, Qvals.PWMoutput);
            byte[] decodedPacket = new byte[] { (byte)PacketHeaders.PWMoutputData,
                                                (byte)(AX0short >> 8),
                                                (byte)AX0short,
                                                (byte)(AX2short >> 8),
                                                (byte)AX2short,
                                                (byte)(AX4short >> 8),
                                                (byte)AX4short,
                                                (byte)(AX6short >> 8),
                                                (byte)AX6short,
                                                0};
            decodedPacket = InsertChecksum(decodedPacket);
            return PacketEncoding.EncodePacket(decodedPacket);
        }

        /// <summary>
        /// Inserts check sum at last position in array equal to the sum all of bytes preceding it.
        /// </summary>
        /// <param name="decodedPacket">
        /// Decoded packet byte array.
        /// </param>
        /// <returns>
        /// Decoded packet with checksum inserted at last position in array.
        /// </returns> 
        private static byte[] InsertChecksum(byte[] decodedPacket)
        {
            decodedPacket[decodedPacket.Length - 1] = 0;                        // zero current checksum
            for (int i = 0; i < (decodedPacket.Length - 1); i++)
            {
                decodedPacket[decodedPacket.Length - 1] += decodedPacket[i];    // acclimate checksum
            }
            return decodedPacket;
        }

        #endregion

        #region Packet deconstruction

        /// <summary>
        /// Deconstructs packet from and encoded byte array and return data object.
        /// </summary>
        /// <param name="encodedPacket">
        /// Byte array containing the encoded packet.
        /// </param>
        /// <returns>
        /// <see cref="xIMUdata"/> object deconstructed from packet.
        /// </returns>  
        /// <exception cref="System.Exception">
        /// Thrown when deconstruction of an invalid packet is attempted.
        /// </exception>
        public static xIMUdata DeconstructPacket(byte[] encodedPacket)
        {
            // Decode packet
            if (encodedPacket.Length < 4)
            {
                throw new Exception("Too few bytes in packet.");
            }
            if (encodedPacket.Length > 30)
            {
                throw new Exception("Too many bytes in packet.");
            }
            byte[] decodedPacket = PacketEncoding.DecodePacket(encodedPacket);

            // Confirm checksum
            byte checksum = 0;
            for (int i = 0; i < (decodedPacket.Length - 1); i++) checksum += decodedPacket[i];
            if (checksum != decodedPacket[decodedPacket.Length - 1])
            {
                throw new Exception("Invalid checksum.");
            }

            // Interpret packet according to header
            switch (decodedPacket[0])
            {
                case ((byte)PacketHeaders.ErrorMessage):
                    if (decodedPacket.Length != 4)
                    {
                        throw new Exception("Invalid number of bytes for packet header.");
                    }
                    return new ErrorData((ushort)Concat(decodedPacket[1], decodedPacket[2]));
                case ((byte)PacketHeaders.Command):
                    if (decodedPacket.Length != 4)
                    {
                        throw new Exception("Invalid number of bytes for packet header.");
                    }
                    return new CommandData((ushort)Concat(decodedPacket[1], decodedPacket[2]));
                case ((byte)PacketHeaders.WriteRegister):
                    if (decodedPacket.Length != 6)
                    {
                        throw new Exception("Invalid number of bytes for packet header.");
                    }
                    return new RegisterData((ushort)Concat(decodedPacket[1], decodedPacket[2]), (ushort)Concat(decodedPacket[3], decodedPacket[4]));
                case ((byte)PacketHeaders.WriteDateTime):
                    if (decodedPacket.Length != 8)
                    {
                        throw new Exception("Invalid number of bytes for packet header.");
                    }
                    return new DateTimeData((int)(10 * ((decodedPacket[1] & 0xF0) >> 4) + (decodedPacket[1] & 0x0F)) + 2000,
                                            (int)(10 * ((decodedPacket[2] & 0xF0) >> 4) + (decodedPacket[2] & 0x0F)),
                                            (int)(10 * ((decodedPacket[3] & 0xF0) >> 4) + (decodedPacket[3] & 0x0F)),
                                            (int)(10 * ((decodedPacket[4] & 0xF0) >> 4) + (decodedPacket[4] & 0x0F)),
                                            (int)(10 * ((decodedPacket[5] & 0xF0) >> 4) + (decodedPacket[5] & 0x0F)),
                                            (int)(10 * ((decodedPacket[6] & 0xF0) >> 4) + (decodedPacket[6] & 0x0F)));
                case ((byte)PacketHeaders.RawBattThermData):
                    if (decodedPacket.Length != 6)
                    {
                        throw new Exception("Invalid number of bytes for packet header.");
                    }
                    return new RawBattThermData(Concat(decodedPacket[1], decodedPacket[2]), Concat(decodedPacket[3], decodedPacket[4]));
                case ((byte)PacketHeaders.CalBattThermData):
                    if (decodedPacket.Length != 6)
                    {
                        throw new Exception("Invalid number of bytes for packet header.");
                    }
                    return new CalBattThermData(FixedFloat.FixedToFloat(Concat(decodedPacket[1], decodedPacket[2]), Qvals.CalibratedBatt),
                                                FixedFloat.FixedToFloat(Concat(decodedPacket[3], decodedPacket[4]), Qvals.CalibratedTherm));
                case ((byte)PacketHeaders.RawInertialMagData):
                    if (decodedPacket.Length != 20)
                    {
                        throw new Exception("Invalid number of bytes for packet header.");
                    }
                    return new RawInertialMagData(new short[] { Concat(decodedPacket[1], decodedPacket[2]), Concat(decodedPacket[3], decodedPacket[4]), Concat(decodedPacket[5], decodedPacket[6]) },
                                                  new short[] { Concat(decodedPacket[7], decodedPacket[8]), Concat(decodedPacket[9], decodedPacket[10]), Concat(decodedPacket[11], decodedPacket[12]) },
                                                  new short[] { Concat(decodedPacket[13], decodedPacket[14]), Concat(decodedPacket[15], decodedPacket[16]), Concat(decodedPacket[17], decodedPacket[18]) });
                case ((byte)PacketHeaders.CalInertialMagData):
                    if (decodedPacket.Length != 20)
                    {
                        throw new Exception("Invalid number of bytes for packet header.");
                    }
                    return new CalInertialMagData(new float[] { FixedFloat.FixedToFloat(Concat(decodedPacket[1], decodedPacket[2]), Qvals.CalibratedGyro), FixedFloat.FixedToFloat(Concat(decodedPacket[3], decodedPacket[4]), Qvals.CalibratedGyro), FixedFloat.FixedToFloat(Concat(decodedPacket[5], decodedPacket[6]), Qvals.CalibratedGyro) },
                                                  new float[] { FixedFloat.FixedToFloat(Concat(decodedPacket[7], decodedPacket[8]), Qvals.CalibratedAccel), FixedFloat.FixedToFloat(Concat(decodedPacket[9], decodedPacket[10]), Qvals.CalibratedAccel), FixedFloat.FixedToFloat(Concat(decodedPacket[11], decodedPacket[12]), Qvals.CalibratedAccel) },
                                                  new float[] { FixedFloat.FixedToFloat(Concat(decodedPacket[13], decodedPacket[14]), Qvals.CalibratedMag), FixedFloat.FixedToFloat(Concat(decodedPacket[15], decodedPacket[16]), Qvals.CalibratedMag), FixedFloat.FixedToFloat(Concat(decodedPacket[17], decodedPacket[18]), Qvals.CalibratedMag) });
                case ((byte)PacketHeaders.QuaternionData):
                    if (decodedPacket.Length != 10)
                    {
                        throw new Exception("Invalid number of bytes for packet header.");
                    }
                    return new QuaternionData(new float[] { FixedFloat.FixedToFloat(Concat(decodedPacket[1], decodedPacket[2]), Qvals.Quaternion), FixedFloat.FixedToFloat(Concat(decodedPacket[3], decodedPacket[4]), Qvals.Quaternion),
                                                            FixedFloat.FixedToFloat(Concat(decodedPacket[5], decodedPacket[6]), Qvals.Quaternion), FixedFloat.FixedToFloat(Concat(decodedPacket[7], decodedPacket[8]), Qvals.Quaternion)});
                case((byte)PacketHeaders.DigitalIOdata):
                    if (decodedPacket.Length != 4)
                    {
                        throw new Exception("Invalid number of bytes for packet header.");
                    }
                    return new DigitalIOdata(new DigitalPortBits(decodedPacket[1]), new DigitalPortBits(decodedPacket[2]));
                case ((byte)PacketHeaders.RawAnalogueInputData):
                    if (decodedPacket.Length != 18)
                    {
                        throw new Exception("Invalid number of bytes for packet header.");
                    }
                    return new RawAnalogueInputData(Concat(decodedPacket[1], decodedPacket[2]), Concat(decodedPacket[3], decodedPacket[4]), Concat(decodedPacket[5], decodedPacket[6]), Concat(decodedPacket[7], decodedPacket[8]),
                                                    Concat(decodedPacket[9], decodedPacket[10]), Concat(decodedPacket[11], decodedPacket[12]), Concat(decodedPacket[13], decodedPacket[14]), Concat(decodedPacket[15], decodedPacket[16]));
                case ((byte)PacketHeaders.CalAnalogueInputData):
                    if (decodedPacket.Length != 18)
                    {
                        throw new Exception("Invalid number of bytes for packet header.");
                    }
                    return new CalAnalogueInputData(FixedFloat.FixedToFloat(Concat(decodedPacket[1], decodedPacket[2]), Qvals.CalibratedAnalogueInput), FixedFloat.FixedToFloat(Concat(decodedPacket[3], decodedPacket[4]), Qvals.CalibratedAnalogueInput), FixedFloat.FixedToFloat(Concat(decodedPacket[5], decodedPacket[6]),Qvals.CalibratedAnalogueInput), FixedFloat.FixedToFloat(Concat(decodedPacket[7], decodedPacket[8]),Qvals.CalibratedAnalogueInput),
                                                    FixedFloat.FixedToFloat(Concat(decodedPacket[9], decodedPacket[10]),Qvals.CalibratedAnalogueInput), FixedFloat.FixedToFloat(Concat(decodedPacket[11], decodedPacket[12]), Qvals.CalibratedAnalogueInput), FixedFloat.FixedToFloat(Concat(decodedPacket[13], decodedPacket[14]),Qvals.CalibratedAnalogueInput), FixedFloat.FixedToFloat(Concat(decodedPacket[15], decodedPacket[16]),Qvals.CalibratedAnalogueInput));
                case ((byte)PacketHeaders.PWMoutputData):
                    if (decodedPacket.Length != 10)
                    {
                        throw new Exception("Invalid number of bytes for packet header.");
                    }
                    return new PWMoutputData(FixedFloat.FixedToFloat(Concat(decodedPacket[1], decodedPacket[2]), Qvals.PWMoutput), FixedFloat.FixedToFloat(Concat(decodedPacket[3], decodedPacket[4]), Qvals.PWMoutput),
                                             FixedFloat.FixedToFloat(Concat(decodedPacket[5], decodedPacket[6]), Qvals.PWMoutput), FixedFloat.FixedToFloat(Concat(decodedPacket[7], decodedPacket[8]), Qvals.PWMoutput));
                case ((byte)PacketHeaders.RawADXL345busData):
                    if (decodedPacket.Length != 26)
                    {
                        throw new Exception("Invalid number of bytes for packet header.");
                    }
                    return new RawADXL345busData(new short[] { Concat(decodedPacket[1], decodedPacket[2]), Concat(decodedPacket[3], decodedPacket[4]), Concat(decodedPacket[5], decodedPacket[6]) },
                                                 new short[] { Concat(decodedPacket[7], decodedPacket[8]), Concat(decodedPacket[9], decodedPacket[10]), Concat(decodedPacket[11], decodedPacket[12]) },
                                                 new short[] { Concat(decodedPacket[13], decodedPacket[14]), Concat(decodedPacket[15], decodedPacket[16]), Concat(decodedPacket[17], decodedPacket[18]) },
                                                 new short[] { Concat(decodedPacket[19], decodedPacket[20]), Concat(decodedPacket[21], decodedPacket[22]), Concat(decodedPacket[23], decodedPacket[24]) });
                case ((byte)PacketHeaders.CalADXL345busData):
                    if (decodedPacket.Length != 26)
                    {
                        throw new Exception("Invalid number of bytes for packet header.");
                    }
                    return new CalADXL345busData(new float[] { FixedFloat.FixedToFloat(Concat(decodedPacket[1], decodedPacket[2]), Qvals.CalibratedADXL345), FixedFloat.FixedToFloat(Concat(decodedPacket[3], decodedPacket[4]), Qvals.CalibratedADXL345), FixedFloat.FixedToFloat(Concat(decodedPacket[5], decodedPacket[6]), Qvals.CalibratedADXL345) },
                                                 new float[] { FixedFloat.FixedToFloat(Concat(decodedPacket[7], decodedPacket[8]), Qvals.CalibratedADXL345), FixedFloat.FixedToFloat(Concat(decodedPacket[9], decodedPacket[10]), Qvals.CalibratedADXL345), FixedFloat.FixedToFloat(Concat(decodedPacket[11], decodedPacket[12]), Qvals.CalibratedADXL345) },
                                                 new float[] { FixedFloat.FixedToFloat(Concat(decodedPacket[13], decodedPacket[14]), Qvals.CalibratedADXL345), FixedFloat.FixedToFloat(Concat(decodedPacket[15], decodedPacket[16]), Qvals.CalibratedADXL345), FixedFloat.FixedToFloat(Concat(decodedPacket[17], decodedPacket[18]), Qvals.CalibratedADXL345) },
                                                 new float[] { FixedFloat.FixedToFloat(Concat(decodedPacket[19], decodedPacket[20]), Qvals.CalibratedADXL345), FixedFloat.FixedToFloat(Concat(decodedPacket[21], decodedPacket[22]), Qvals.CalibratedADXL345), FixedFloat.FixedToFloat(Concat(decodedPacket[23], decodedPacket[24]), Qvals.CalibratedADXL345) });
                default:
                    throw new Exception("Unknown packet header.");
            }
        }

        /// <summary>
        /// Concatenates 2 bytes to return a short.
        /// </summary>
        /// <param name="MSB">
        /// Most Significant Byte.
        /// </param>
        /// <param name="LSB">
        /// Least Significant Byte.
        /// </param> 
        /// <returns>
        /// MSB and LSB concatenated to create a short.
        /// </returns>
        private static short Concat(byte MSB, byte LSB)
        {
            return (short)((short)((short)MSB << 8) | (short)LSB);
        }

        #endregion
    }
}