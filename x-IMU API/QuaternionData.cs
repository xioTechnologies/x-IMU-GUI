using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace x_IMU_API
{
    /// <summary>
    /// Quaternion data class.
    /// </summary>
    /// <remarks>
    /// See http://www.x-io.co.uk/res/doc/quaternions.pdf for more information on quaternions.
    /// </remarks>
    public class QuaternionData : xIMUdata
    {
        /// <summary>
        /// Private quaternion array.
        /// </summary>
        private float[] quaternion;

        /// <summary>
        /// Gets or sets the quaternion. Must of 4 elements. Vector will be normalised.
        /// </summary>
        /// <exception cref="System.Exception">
        /// Thrown if invalid quaternion specified.
        /// </exception>
        public float[] Quaternion
        {
            get
            {
                return quaternion;
            }
            set
            {
                if (value.Length != 4)
                {
                    throw new Exception("Quaternion vector must be of 4 elements.");
                }
                float norm = (float)Math.Sqrt(value[0] * value[0] + value[1] * value[1] + value[2] * value[2] + value[3] * value[3]);
                quaternion = value;
                quaternion[0] /= norm;
                quaternion[1] /= norm;
                quaternion[2] /= norm;
                quaternion[3] /= norm;
            }
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="QuaternionData"/> class.
        /// </summary>
        public QuaternionData()
            : this(new float[] { 1, 0, 0, 0 })
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="QuaternionData"/> class.
        /// </summary>
        /// <param name="quaternion">
        /// Quaternion. Must of 4 elements. Each element must be of value -1 to +1.
        /// </param>
        public QuaternionData(float[] quaternion)
        {
            Quaternion = quaternion;
        }

        /// <summary>
        /// Returns the quaternion conjugate.
        /// </summary>
        /// <returns>
        /// Quaternion conjugate.
        /// </returns>
        public QuaternionData ConvertToConjugate()
        {
            return new QuaternionData(new float[] { Quaternion[0], -Quaternion[1], -Quaternion[2], -Quaternion[3] });
        }

        /// <summary>
        /// Converts data to rotation matrix.
        /// </summary>
        /// <remarks>
        /// Index order is row major. See http://en.wikipedia.org/wiki/Row-major_order
        /// </remarks> 
        public float[] ConvertToRotationMatrix()
        {
            float R11 = 2 * Quaternion[0] * Quaternion[0] - 1 + 2 * Quaternion[1] * Quaternion[1];
            float R12 = 2 * (Quaternion[1] * Quaternion[2] + Quaternion[0] * Quaternion[3]);
            float R13 = 2 * (Quaternion[1] * Quaternion[3] - Quaternion[0] * Quaternion[2]);
            float R21 = 2 * (Quaternion[1] * Quaternion[2] - Quaternion[0] * Quaternion[3]);
            float R22 = 2 * Quaternion[0] * Quaternion[0] - 1 + 2 * Quaternion[2] * Quaternion[2];
            float R23 = 2 * (Quaternion[2] * Quaternion[3] + Quaternion[0] * Quaternion[1]);
            float R31 = 2 * (Quaternion[1] * Quaternion[3] + Quaternion[0] * Quaternion[2]);
            float R32 = 2 * (Quaternion[2] * Quaternion[3] - Quaternion[0] * Quaternion[1]);
            float R33 = 2 * Quaternion[0] * Quaternion[0] - 1 + 2 * Quaternion[3] * Quaternion[3];
            return new float[] { R11, R12, R13,
                                 R21, R22, R23,
                                 R31, R32, R33 };
        }

        /// <summary>
        /// Converts data to ZYX Euler angles (in degrees).
        /// </summary>
        public float[] ConvertToEulerAngles()
        {
            float phi = (float)Math.Atan2(2 * (Quaternion[2] * Quaternion[3] - Quaternion[0] * Quaternion[1]), 2 * Quaternion[0] * Quaternion[0] - 1 + 2 * Quaternion[3] * Quaternion[3]);
            float theta = (float)-Math.Atan((2.0 * (Quaternion[1] * Quaternion[3] + Quaternion[0] * Quaternion[2])) / Math.Sqrt(1.0 - Math.Pow((2.0 * Quaternion[1] * Quaternion[3] + 2.0 * Quaternion[0] * Quaternion[2]), 2.0)));
            float psi = (float)Math.Atan2(2 * (Quaternion[1] * Quaternion[2] - Quaternion[0] * Quaternion[3]), 2 * Quaternion[0] * Quaternion[0] - 1 + 2 * Quaternion[1] * Quaternion[1]);
            return new float[] { Rad2Deg(phi), Rad2Deg(theta), Rad2Deg(psi) };
        }

        /// <summary>
        /// Converts from radians to degrees.
        /// </summary>
        /// <param name="radians">
        /// Angular quantity in radians.
        /// </param> 
        /// <returns>
        /// Angular quantity in degrees.
        /// </returns>
        private float Rad2Deg(float radians)
        {
            return 57.2957795130823f * radians;
        }

        /// <summary>
        /// Converts data to string of Comma Separated Variables.
        /// </summary>
        /// <returns>
        /// CSV text line.
        /// </returns>
        public string ConvertToCSVstring()
        {
            return Quaternion[0].ToString(CultureInfo.InvariantCulture) + "," + Quaternion[1].ToString(CultureInfo.InvariantCulture) + "," +
                   Quaternion[2].ToString(CultureInfo.InvariantCulture) + "," + Quaternion[3].ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts data to string of Comma Separated Variables representaing the elements of a rotation matrix.
        /// </summary>
        /// <returns>
        /// CSV text line.
        /// </returns>
        /// <remarks>
        /// Index order is row major. See http://en.wikipedia.org/wiki/Row-major_order
        /// </remarks> 
        public string ConvertToRotationMatrixCSVstring()
        {
            float[] R = ConvertToRotationMatrix();
            return R[0].ToString(CultureInfo.InvariantCulture) + "," + R[1].ToString(CultureInfo.InvariantCulture) + "," + R[2].ToString(CultureInfo.InvariantCulture) + "," +
                   R[3].ToString(CultureInfo.InvariantCulture) + "," + R[4].ToString(CultureInfo.InvariantCulture) + "," + R[5].ToString(CultureInfo.InvariantCulture) + "," +
                   R[6].ToString(CultureInfo.InvariantCulture) + "," + R[7].ToString(CultureInfo.InvariantCulture) + "," + R[8].ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts data to string of Comma Separated Variables representing the ZYX Euler angles (in degrees).
        /// </summary>
        /// <returns>
        /// CSV text line.
        /// </returns>
        public string ConvertToEulerAnglesCSVstring()
        {
            float[] euler = ConvertToEulerAngles();
            return euler[0].ToString(CultureInfo.InvariantCulture) + "," + euler[1].ToString(CultureInfo.InvariantCulture) + "," + euler[2].ToString(CultureInfo.InvariantCulture);
        }
    }
}