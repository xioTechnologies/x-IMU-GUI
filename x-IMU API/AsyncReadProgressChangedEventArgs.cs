using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Asynchronous read process changed event arguments class.
    /// </summary>
    public class AsyncReadProgressChangedEventArgs
    {
        /// <summary>
        /// Gets the progress percentage.
        /// </summary>
        public int ProgressPercentage { get; private set; }

        /// <summary>
        /// Gets the progress message.
        /// </summary>
        public string ProgressMessage { get; private set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="AsyncReadProgressChangedEventArgs"/> class.
        /// </summary>
        /// <param name="progressPercentage">
        /// Progress percentage.
        /// </param>
        /// <param name="progressMessage">
        /// Progress message.
        /// </param>
        public AsyncReadProgressChangedEventArgs(int progressPercentage, string progressMessage)
        {
            ProgressPercentage = progressPercentage;
            ProgressMessage = progressMessage;
        }
    }
}
