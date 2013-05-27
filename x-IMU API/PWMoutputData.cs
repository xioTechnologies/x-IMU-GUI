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
        #region Variables

        private float privAX0;
        private float privAX2;
        private float privAX4;
        private float privAX6;
        
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets PWM channel AX0 duty cycle as a percentage.  Value must be between 0 and 1.
        /// </summary>
        public float AX0 {
            get
            { 
                return privAX0; 
            }
            set 
            {
                ExceptionIfInvalidDutyCycle(value);
                privAX0 = value; 
            }
        }

        /// <summary>
        /// Gets or sets PWM channel AX2 duty cycle as a percentage.  Value must be between 0 and 1.
        /// </summary>
        public float AX2 {
            get
            { 
                return privAX2; 
            }
            set 
            {
                ExceptionIfInvalidDutyCycle(value);
                privAX2 = value; 
            }
        }

        /// <summary>
        /// Gets or sets PWM channel AX4 duty cycle as a percentage.  Value must be between 0 and 1.
        /// </summary>
        public float AX4 {
            get
            { 
                return privAX4; 
            }
            set 
            {
                ExceptionIfInvalidDutyCycle(value);
                privAX4 = value; 
            }
        }

        /// <summary>
        /// Gets or sets PWM channel AX6 duty cycle as a percentage.  Value must be between 0 and 1.
        /// </summary>
        public float AX6 {
            get
            { 
                return privAX6; 
            }
            set 
            {
                ExceptionIfInvalidDutyCycle(value);
                privAX6 = value; 
            }
        }

        /// <summary>
        /// Throws exception if duty cycle less than 0% or more than 100%.
        /// </summary>
        /// <param name="dutyCycle">
        /// Duty cycle value.
        /// </param>
        private void ExceptionIfInvalidDutyCycle(float dutyCycle) {
            if((dutyCycle < 0f) || (dutyCycle > 1f)) {
                throw new Exception("Invalid duty cycle value");
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="PWMoutputData"/> class.
        /// </summary>
        public PWMoutputData()
            : this(0f, 0f, 0f, 0f)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="PWMoutputData"/> class.
        /// </summary>
        /// <param name="AX0">
        /// PWM channel AX0 duty cycle as a percentage
        /// </param>
        /// <param name="AX2">
        /// PWM channel AX2 duty cycle as a percentage
        /// </param>
        /// <param name="AX4">
        /// PWM channel AX4 duty cycle as a percentage
        /// </param>
        /// <param name="AX6">
        /// PWM channel AX6 duty cycle as a percentage
        /// </param>
        public PWMoutputData(float _AX0, float _AX2, float _AX4, float _AX6)
        {
            AX0 = _AX0;
            AX2 = _AX2;
            AX4 = _AX4;
            AX6 = _AX6;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts data to string of Comma Separated Variables.
        /// </summary>
        /// <returns>
        /// CSV line.
        /// </returns>
        public string ConvertToCSV()
        {
            return Convert.ToString(AX0) + "," + Convert.ToString(AX2) + "," + Convert.ToString(AX4) + "," + Convert.ToString(AX6);
        }

        #endregion
    }
}
