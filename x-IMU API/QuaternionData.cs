using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xIMU_API
{
    /// <summary>
    /// Quaternion data class.
    /// </summary>
    /// <remarks>
    /// See http://www.x-io.co.uk/res/doc/quaternions.pdf for more information on quaternions.
    /// </remarks>
    public class QuaternionData : xIMUdata
    {
        #region Variables

        private float[] privQuaternion;

        #endregion

        #region Properties

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
                return privQuaternion;
            }
            set
            {
                if (value.Length != 4)
                {
                    throw new Exception("Quaternion vector must be of 4 elements.");
                }
                float norm = (float)Math.Sqrt(value[0] * value[0] + value[1] * value[1] + value[2] * value[2] + value[3] * value[3]);
                privQuaternion = value;
                privQuaternion[0] /= norm;
                privQuaternion[1] /= norm;
                privQuaternion[2] /= norm;
                privQuaternion[3] /= norm;
            }
        }

        #endregion

        #region Constructors

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

        #endregion

        #region Private methods

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

        #endregion

        #region Public methods

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
        /// Elements 0 to 2 represent columns 1 to 3 of row 1.
        /// Elements 3 to 5 represent columns 1 to 3 of row 2.
        /// Elements 6 to 8 represent columns 1 to 3 of row 3.
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
            return new float[] { R11, R21, R31,
                                 R12, R22, R32,
                                 R13, R23, R33 };
        }

        /// <summary>
        /// Converts data to XYZ Euler angles (in degrees).
        /// </summary>
        public float[] ConvertToEulerAngles()
        {
            float phi = (float)Math.Atan2(2 * (Quaternion[2] * Quaternion[3] - Quaternion[0] * Quaternion[1]), 2 * Quaternion[0] * Quaternion[0] - 1 + 2 * Quaternion[3] * Quaternion[3]);
            float theta = (float)-Math.Atan((2.0 * (Quaternion[1] * Quaternion[3] + Quaternion[0] * Quaternion[2])) / Math.Sqrt(1.0 - Math.Pow((2.0 * Quaternion[1] * Quaternion[3] + 2.0 * Quaternion[0] * Quaternion[2]), 2.0)));
            float psi = (float)Math.Atan2(2 * (Quaternion[1] * Quaternion[2] - Quaternion[0] * Quaternion[3]), 2 * Quaternion[0] * Quaternion[0] - 1 + 2 * Quaternion[1] * Quaternion[1]);
            return new float[] { Rad2Deg(phi), Rad2Deg(theta), Rad2Deg(psi) };
        }

        /// <summary>
        /// Converts data to string of Comma Separated Variables.
        /// </summary>
        public string ConvertToCSV()
        {
            return Convert.ToString(Quaternion[0]) + "," + Convert.ToString(Quaternion[1]) + "," + Convert.ToString(Quaternion[2]) + "," + Convert.ToString(Quaternion[3]);
        }

        /// <summary>
        /// Converts data to string of Comma Separated Variables representaing the elements of a rotation matrix.
        /// </summary>
        /// <remarks>
        /// First to third values represent columns 1 to 3 of row 1.
        /// Forth to fifth values represent columns 1 to 3 of row 2.
        /// Sixth to eighth values represent columns 1 to 3 of row 3.
        /// </remarks>
        public string ConvertToRotationMatrixCSV()
        {
            float[] R = ConvertToRotationMatrix();
            return Convert.ToString(R[0]) + "," + Convert.ToString(R[1]) + "," + Convert.ToString(R[2]) + "," +
                   Convert.ToString(R[3]) + "," + Convert.ToString(R[4]) + "," + Convert.ToString(R[5]) + "," +
                   Convert.ToString(R[6]) + "," + Convert.ToString(R[7]) + "," + Convert.ToString(R[8]);
        }

        /// <summary>
        /// Converts data to string of Comma Separated Variables representaing the XYZ Euler angles (in degrees).
        /// </summary>
        public string ConvertToEulerAnglesCSV()
        {
            float[] euler = ConvertToEulerAngles();
            return Convert.ToString(euler[0]) + "," + Convert.ToString(euler[1]) + "," + Convert.ToString(euler[2]);
        }

        #endregion
    }
}
