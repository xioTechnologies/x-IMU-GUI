using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xIMU_API
{
    /// <summary>
    /// Asynchronous read process changed event arguments class.
    /// </summary>
    public class AsyncReadProgressChangedEventArgs
    {
        private int privProgressPercentage;
        private string privProgressMessage;

        /// <summary>
        /// Gets the progress percentage.
        /// </summary>
        public int ProgressPercentage
        {
            get
            {
                return privProgressPercentage;
            }
        }

        /// <summary>
        /// Gets the progress message.
        /// </summary>
        public string ProgressMessage
        {
            get
            {
                return privProgressMessage;
            }
        }

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
            privProgressPercentage = progressPercentage;
            privProgressMessage = progressMessage;
        }
    }
}
