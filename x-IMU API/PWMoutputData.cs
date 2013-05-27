using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// PWM output data class.
    /// </summary>
    public class PWMoutputData : xIMUdata
    {       
        /// <summary>
        /// Gets or sets PWM channel AX0 duty cycle. 0 to 65535 = 0% to 100%.
        /// </summary>
        public ushort AX0 { get; set; }

        /// <summary>
        /// Gets or sets PWM channel AX2 duty cycle. 0 to 65535 = 0% to 100%.
        /// </summary>
        public ushort AX2 { get; set; }

        /// <summary>
        /// Gets or sets PWM channel AX4 duty cycle. 0 to 65535 = 0% to 100%.
        /// </summary>
        public ushort AX4 { get; set; }

        /// <summary>
        /// Gets or sets PWM channel AX6 duty cycle. 0 to 65535 = 0% to 100%.
        /// </summary>
        public ushort AX6 { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="PWMoutputData"/> class.
        /// </summary>
        public PWMoutputData()
            : this(0, 0, 0, 0)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="PWMoutputData"/> class.
        /// </summary>
        /// <param name="AX0">
        /// Gets or sets PWM channel AX0 duty cycle. 0 to 65535 = 0% to 100%.
        /// </param>
        /// <param name="AX2">
        /// Gets or sets PWM channel AX2 duty cycle. 0 to 65535 = 0% to 100%.
        /// </param>
        /// <param name="AX4">
        /// Gets or sets PWM channel AX4 duty cycle. 0 to 65535 = 0% to 100%.
        /// </param>
        /// <param name="AX6">
        /// Gets or sets PWM channel AX6 duty cycle. 0 to 65535 = 0% to 100%.
        /// </param>
        public PWMoutputData(ushort AX0, ushort AX2, ushort AX4, ushort AX6)
        {
            this.AX0 = AX0;
            this.AX2 = AX2;
            this.AX4 = AX4;
            this.AX6 = AX6;
        }

        /// <summary>
        /// Converts data to string of Comma Separated Variables.
        /// </summary>
        /// <returns>
        /// CSV text line.
        /// </returns>
        public string ConvertToCSVstring()
        {
            return AX0.ToString() + "," + AX2.ToString() + "," + AX4.ToString() + "," + AX6.ToString();
        }
    }
}
