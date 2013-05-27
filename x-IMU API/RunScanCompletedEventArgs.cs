using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xIMU_API
{
    /// <summary>
    /// Run scan completed event arguments class.
    /// </summary>
    public class RunScanCompletedEventArgs
    {
        private PortAssignment[] privPortAssignments;
        private bool privCancelled;

        /// <summary>
        /// Gets an array of <see cref="PortAsignments"/> found during the scan.
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
        /// Initialises a new instance of the <see cref="RunScanCompletedEventArgs"/> class.
        /// </summary>
        /// <param name="portAsignments">
        /// Array of <see cref="portAsignments"/> found during the scan.
        /// </param>
        /// <param name="cancelled">
        /// Value indicating whether the asynchronous scan was cancelled.
        /// </param>
        public RunScanCompletedEventArgs(PortAssignment[] portAsignments, bool cancelled)
        {
            privPortAssignments = portAsignments;
            privCancelled = cancelled;
        }
    }
}
