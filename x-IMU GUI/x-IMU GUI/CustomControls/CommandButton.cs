using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace x_IMU_GUI
{
    /// <summary>
    /// CommandButton class.
    /// </summary>
    public partial class CommandButton : Button
    {
        /// <summary>
        /// Gets or sets the command code of the button. See <see cref="x_IMU_API.CommandCodes"/>.
        /// </summary>
        public x_IMU_API.CommandCodes CommandCode { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="CommandButton"/> class.
        /// </summary>
        public CommandButton()
        {
            InitializeComponent();
        }
    }
}
