using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Run scan completed event arguments class.
    /// </summary>
    public class AsyncScanCompletedEventArgs
    {
        private PortAssignment[] privPortAssignments;
        private bool privCancelled;

        /// <summary>
        /// Gets an array of <see cref="PortAssignments"/> found during the scan.
        /// </summary>
        public PortAssignment[] PortAssignments
        {
            get
            {
                return privPortAssignments;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the asynchronous scan was cancelled.
        /// </summary>
        public bool Cancelled
        {
            get
            {
                return privCancelled;
            }
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="AsyncScanCompletedEventArgs"/> class.
        /// </summary>
        /// <param name="portAssignments">
        /// Array of <see cref="portAssignments"/> found during the scan.
        /// </param>
        /// <param name="cancelled">
        /// Value indicating whether the asynchronous scan was cancelled.
        /// </param>
        public AsyncScanCompletedEventArgs(PortAssignment[] portAssignments, bool cancelled)
        {
            privPortAssignments = portAssignments;
            privCancelled = cancelled;
        }
    }
}