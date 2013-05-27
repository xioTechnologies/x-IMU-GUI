using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Port asignment class.
    /// </summary>
    public class PortAssignment
    {
        /// <summary>
        /// Gets the port name assigned the x-IMU.
        /// </summary>
        public string PortName { get; private set; }

        /// <summary>
        /// Gets the device ID of x-IMU.
        /// </summary>
        public string DeviceID { get; private set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="PortAssignment"/> class.
        /// </summary>
        /// <param name="portName">
        /// Port name assigned the x-IMU.
        /// </param>
        /// <param name="deviceID">
        /// Device ID of x-IMU.
        /// </param>
        public PortAssignment(string portName, string deviceID)
        {
            PortName = portName;
            DeviceID = deviceID;
        }
    }
}