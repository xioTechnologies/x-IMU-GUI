using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// 16-bit fixed-point / floating-point conversion class.
    /// </summary>
    internal class FixedFloat
    {
        /// <summary>
        /// Returns floating-point value from specified 16-bit fixed-point.
        /// </summary>
        /// <param name="fixedValue">
        /// 16-bit fixed-point value.
        /// </param>
        /// <param name="q">
        /// Number of fraction bits. See <see cref="Qvals"/>.
        /// </param>
        /// <returns>
        /// Floating-point number.
        /// </returns>
        public static float FixedToFloat(short fixedValue, Qvals q)
        {
            return ((float)(fixedValue) / (float)(1 << ((int)q)));
        }

        /// <summary>
        /// Returns 16-bit fixed-point value from specified floating-point value with saturation.
        /// </summary>
        /// <param name="floatValue">
        /// Floating-point representation of 16-bit fixed-point value.
        /// </param>
        /// <param name="q">
        /// Number of fraction bits. See <see cref="Qvals"/>.
        /// </param>
        /// <returns>
        /// 16-bit fixed-point value.
        /// </returns>
        public static short FloatToFixed(float floatValue, Qvals q)
        {
            int temp = (int)((floatValue) * (int)(1 << ((int)q)));
            if (temp > 32767) temp = 32767;
            else if (temp < -32768) temp = -32768;
            return (short)temp;
        }
    }
}
