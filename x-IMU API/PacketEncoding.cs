using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Packet encoding class.  Contains static methods for packet encoding and decoding.
    /// </summary>
    internal class PacketEncoding
    {
        #region Packet encoding

        /// <summary>
        /// Encodes packet with consecutive right shifts so that the msb of each encoded byte is clear. The msb of the final byte is set to indicate the end of the packet.
        /// </summary>
        /// <param name="decodedPacket">
        /// The decoded packet contents to be encoded.
        /// </param>
        /// <returns>
        /// The encoded packet.
        /// </returns> 
        public static byte[] EncodePacket(byte[] decodedPacket)
        {
            byte[] encodedPacket = new byte[(int)(Math.Ceiling((((float)decodedPacket.Length * 1.125f)) + 0.125f))];
            byte[] shiftRegister = new byte[encodedPacket.Length];
            Array.Copy(decodedPacket, shiftRegister, decodedPacket.Length);     // copy encoded packet to shift register
            for (int i = 0; i < encodedPacket.Length; i++)
            {
                shiftRegister = RightShiftByteArray(shiftRegister);             // right shift to clear msb of byte i
                encodedPacket[i] = shiftRegister[i];                            // store encoded byte i
                shiftRegister[i] = 0;                                           // clear byte i in shift register
            }
            encodedPacket[encodedPacket.Length - 1] |= 0x80;                    // set msb of framing byte
            return encodedPacket;
        }

        /// <summary>
        /// Right shifts a byte array by 1 bit.  The lsb of byte x becomes the msb of byte x+1.
        /// </summary>
        /// <param name="byteArray">
        /// The byte array to be right shifted.
        /// </param>
        /// <returns>
        /// The right shifted byte array.
        /// </returns> 
        private static byte[] RightShiftByteArray(byte[] byteArray)
        {
            byteArray[byteArray.Length - 1] >>= 1;
            for (int i = byteArray.Length - 2; i >= 0; i--)
            {
                if ((byteArray[i] & 0x01) == 0x01) byteArray[i + 1] |= 0x80;
                byteArray[i] >>= 1;
            }
            return byteArray;
        }

        #endregion

        #region Packet decoding

        /// <summary>
        /// Decodes a packet with consecutive left shifts so that the msb of each encoded byte is removed.
        /// </summary>
        /// <param name="encodedPacket">
        /// The endcoded packet to be decoded.
        /// </param>
        /// <returns>
        /// The decoded packet.
        /// </returns> 
        public static byte[] DecodePacket(byte[] encodedPacket)
        {
            byte[] decodedPacket = new byte[(int)(Math.Floor(((float)encodedPacket.Length - 0.125f) / 1.125f))];
            byte[] shiftRegister = new byte[encodedPacket.Length];
            for (int i = shiftRegister.Length - 1; i >= 0; i--)
            {
                shiftRegister[i] = encodedPacket[i];
                shiftRegister = LeftShiftByteArray(shiftRegister);
            }
            Array.Copy(shiftRegister, decodedPacket, decodedPacket.Length);
            return decodedPacket;
        }

        /// <summary>
        /// Left shifts a byte array by 1 bit.  The msb of byte x becomes the lsb of byte x-1.
        /// </summary>
        /// <param name="byteArray">
        /// The byte array to be left shifted.
        /// </param>
        /// <returns>
        /// The left shifted byte array.
        /// </returns> 
        private static byte[] LeftShiftByteArray(byte[] byteArray)
        {
            byteArray[0] <<= 1;
            for (int i = 1; i < byteArray.Length; i++)
            {
                if ((byteArray[i] & 0x80) == 0x80) byteArray[i - 1] |= 0x01;
                byteArray[i] <<= 1;
            }
            return byteArray;
        }

        #endregion
    }
}
