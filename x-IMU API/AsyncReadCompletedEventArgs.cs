using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_API
{
    /// <summary>
    /// Asynchronous read completed event arguments class.
    /// </summary>
    public class AsyncReadCompletedEventArgs
    {
        /// <summary>
        /// Gets <see cref="PacketCount"/> data of read.
        /// </summary>
        public PacketCount PacketCounter { get; private set; }

        /// <summary>
        /// Gets error <see cref="Exception"/> if occurred.
        /// </summary>
        public Exception Error { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the asynchronous scan was cancelled.
        /// </summary>
        public bool Cancelled { get; private set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="AsyncReadCompletedEventArgs"/> class.
        /// </summary>
        /// <param name="packetCounter">
        /// <see cref="PacketCount"/> data of read.
        /// <param name="error">
        /// Error <see cref="Exception"/> if occurred.
        /// </param>
        /// <param name="cancelled">
        /// Value indicating whether the asynchronous scan was cancelled.
        /// </param>
        public AsyncReadCompletedEventArgs(PacketCount packetCounter, Exception error, bool cancelled)
        {
            PacketCounter = packetCounter;
            Error = error;
            Cancelled = cancelled;
        }
    }
}
