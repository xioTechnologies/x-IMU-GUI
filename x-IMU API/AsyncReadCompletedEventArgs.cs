using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xIMU_API
{
    /// <summary>
    /// Asynchronous read completed event arguments class.
    /// </summary>
    public class AsyncReadCompletedEventArgs
    {
        private PacketCount privPacketCounter;
        private Exception privError;
        private bool privCancelled;

        /// <summary>
        /// Gets <see cref="PacketCount"/> data of read.
        /// </summary>
        public PacketCount PacketCounter
        {
            get
            {
                return privPacketCounter;
            }
        }

        /// <summary>
        /// Gets error <see cref="Exception"/> if occured.
        /// </summary>
        public Exception Error
        {
            get
            {
                return privError;
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
        /// Initialises a new instance of the <see cref="AsyncReadCompletedEventArgs"/> class.
        /// </summary>
        /// <param name="packetCounter">
        /// <see cref="PacketCount"/> data of read.
        /// <param name="error">
        /// Error <see cref="Exception"/> if occured
        /// </param>
        /// <param name="cancelled">
        /// Value indicating whether the asynchronous scan was cancelled.
        /// </param>
        public AsyncReadCompletedEventArgs(PacketCount packetCounter, Exception error, bool cancelled)
        {
            privPacketCounter = packetCounter;
            privError = error;
            privCancelled = cancelled;
        }
    }
}
