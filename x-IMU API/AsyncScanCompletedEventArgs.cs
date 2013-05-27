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
        /// <summary>
        /// Gets an array of <see cref="PortAssignments"/> found during the scan.
        /// </summary>
        public PortAssignment[] PortAssignments { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the asynchronous scan was cancelled.
        /// </summary>
        public bool Cancelled { get; private set; }

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
            PortAssignments = portAssignments;
            Cancelled = cancelled;
        }
    }
}