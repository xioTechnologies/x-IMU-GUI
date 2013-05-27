using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace x_IMU_GUI
{
    /// <summary>
    /// Passive Message Box class.
    /// </summary>
    class PassiveMessageBox
    {
        /// <summary>
        /// Nested MessageBoxArgs class to parse arguments.
        /// </summary>
        private class MessageBoxArgs
        {
            public string Text { get; set; }
            public string Caption { get; set; }
            public MessageBoxIcon Icon { get; set; }
            public bool Equivalent(MessageBoxArgs messageBoxArgs) { return Text == messageBoxArgs.Text && Caption == messageBoxArgs.Caption && Icon == messageBoxArgs.Icon;}
        }

        /// <summary>
        /// List of existing messages
        /// </summary>
        private static List<MessageBoxArgs> ExistingMessages = new List<MessageBoxArgs>();

        /// <summary>
        /// Starts a <see cref="MessageBox"/> in a new thread.  Will not show new <see cref="MessageBox"/> if an identical <see cref="MessageBox"/> already exists.
        /// </summary>
        /// <param name="text">
        /// Text to display in <see cref="MessageBox"/>.
        /// </param>
        public static void Show(string text)
        {
            Show(text, "", MessageBoxIcon.None);
        }

        /// <summary>
        /// Starts a <see cref="MessageBox"/> in a new thread.  Will not show new <see cref="MessageBox"/> if an identical <see cref="MessageBox"/> already exists.
        /// </summary>
        /// <param name="text">
        /// Text to display in <see cref="MessageBox"/>.
        /// </param>
        /// <param name="caption">
        /// Caption text of <see cref="MessageBox"/>.
        /// </param>
        public static void Show(string text, string caption)
        {
            Show(text, caption, MessageBoxIcon.None);
        }

        /// <summary>
        /// Starts a <see cref="MessageBox"/> in a new thread.  Will not show new <see cref="MessageBox"/> if an identical <see cref="MessageBox"/> already exists.
        /// </summary>
        /// <param name="text">
        /// Text to display in <see cref="MessageBox"/>.
        /// </param>
        /// <param name="icon">
        /// <see cref="MessageBoxIcon"/> to display in <see cref="MessageBox"/>.
        /// </param>
        public static void Show(string text, MessageBoxIcon icon)
        {
            Show(text, "", icon);
        }

        /// <summary>
        /// Starts a <see cref="MessageBox"/> in a new thread.  Will not show new <see cref="MessageBox"/> if an identical <see cref="MessageBox"/> already exists.
        /// </summary>
        /// <param name="text">
        /// Text to display in <see cref="MessageBox"/>.
        /// </param>
        /// <param name="caption">
        /// Caption text of <see cref="MessageBox"/>.
        /// </param>
        /// <param name="icon">
        /// <see cref="MessageBoxIcon"/> to display in <see cref="MessageBox"/>.
        /// </param>
        public static void Show(string text, string caption, MessageBoxIcon icon)
        {
            MessageBoxArgs messageBoxArgs = new MessageBoxArgs { Text = text, Caption = caption, Icon = icon };
            for (int i = 0; i < ExistingMessages.Count; i++)
            {
                if (ExistingMessages[i].Equivalent(messageBoxArgs))
                {
                    switch (icon)
                    {
                        case (MessageBoxIcon.Asterisk): System.Media.SystemSounds.Asterisk.Play(); break;           // enum = Information
                        case (MessageBoxIcon.Exclamation): System.Media.SystemSounds.Exclamation.Play(); break;     // enum = Warning
                        case (MessageBoxIcon.Hand): System.Media.SystemSounds.Hand.Play(); break;                   // enum = Error = Stop
                        case (MessageBoxIcon.Question): System.Media.SystemSounds.Question.Play(); break;
                        default: break;
                    }
                    return;
                }
            }
            ExistingMessages.Add(messageBoxArgs);
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerAsync(new MessageBoxArgs { Text = text, Caption = caption, Icon = icon });
        }

        /// <summary>
        /// Background worker to display message box in new thread.
        /// </summary>
        private static void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MessageBoxArgs messageBoxArgs = e.Argument as MessageBoxArgs;
            MessageBox.Show(messageBoxArgs.Text, messageBoxArgs.Caption, MessageBoxButtons.OK, messageBoxArgs.Icon);
            for (int i = 0; i < ExistingMessages.Count; i++)
            {
                if (ExistingMessages[i].Equivalent(messageBoxArgs))
                {
                    ExistingMessages.Remove(ExistingMessages[i]);
                }
            }
        }
    }
}