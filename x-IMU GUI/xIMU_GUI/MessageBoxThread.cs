using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using System.ComponentModel;

namespace xIMU_GUI
{
    /// <summary>
    /// MessageBoxThread class.  Contains static functions to display a <see cref="MessageBox"/> in a new thread.
    /// </summary>
    class MessageBoxThread
    {
        /// <summary>
        /// Nested MessageBoxArgs class to parse arguments to BackgroundWorker.
        /// </summary>
        private class MessageBoxArgs
        {
            public string Text { get; set; }
            public string Caption { get; set; }
        }

        /// <summary>
        /// Starts a <see cref="MessageBox"/> in a new thread.
        /// </summary>
        /// <param name="text">
        /// Text to display in <see cref="MessageBox"/>.
        /// </param>
        public static void Show(string text)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerAsync(new MessageBoxArgs { Text = text, Caption = "" });
        }

        /// <summary>
        /// Starts a <see cref="MessageBox"/> in a new thread.
        /// </summary>
        /// <param name="text">
        /// Text to display in <see cref="MessageBox"/>.
        /// </param>
        /// <param name="caption">
        /// Caption text of <see cref="MessageBox"/>.
        /// </param>
        public static void Show(string text, string caption)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerAsync(new MessageBoxArgs { Text = text, Caption = caption });
        }

        /// <summary>
        /// Background worker do work method to display message box in new thread.
        /// </summary>
        private static void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MessageBoxArgs messageBoxArgs = e.Argument as MessageBoxArgs;
            MessageBox.Show(messageBoxArgs.Text, messageBoxArgs.Caption);
        }
    }
}