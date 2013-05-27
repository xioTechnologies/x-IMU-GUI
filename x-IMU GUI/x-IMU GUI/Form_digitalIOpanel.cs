using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace x_IMU_GUI
{
    /// <summary>
    /// Digital I/O panel class.
    /// </summary>
    public partial class Form_digitalIOpanel : Form
    {
        /// <summary>
        /// Form update timer.
        /// </summary>
        private Timer formUpdateTimer;

        /// Gets or sets the digital I/O direction indicated by panel.
        /// </summary>
        public x_IMU_API.DigitalPortBits Direction { get; set; }

        /// <summary>
        /// Gets or sets the digital I/O state indicated by panel.
        /// </summary>
        public x_IMU_API.DigitalPortBits State { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="Form_digitalIOpanel"/> class.
        /// </summary>
        public Form_digitalIOpanel()
        {
            InitializeComponent();
            Direction = new x_IMU_API.DigitalPortBits();
            State = new x_IMU_API.DigitalPortBits();
            formUpdateTimer = new Timer();
            formUpdateTimer.Interval = 20;
            formUpdateTimer.Tick += new EventHandler(formUpdateTimer_Tick);
        }

        /// <summary>
        /// Visible changed event to start/stop form update formUpdateTimer.
        /// </summary>
        private void Form_digitalIOpanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                formUpdateTimer.Start();
            }
            else
            {
                formUpdateTimer.Stop();
            }
        }

        /// <summary>
        /// Form closing event to minimise form instead of close.
        /// </summary>
        private void Form_digitalIOpanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }

        /// <summary>
        /// Timer tick event to update form controls.
        /// </summary>
        private void formUpdateTimer_Tick(object sender, EventArgs e)
        {
            checkBox_AX0.Enabled = !Direction.AX0;
            checkBox_AX1.Enabled = !Direction.AX1;
            checkBox_AX2.Enabled = !Direction.AX2;
            checkBox_AX3.Enabled = !Direction.AX3;
            checkBox_AX4.Enabled = !Direction.AX4;
            checkBox_AX5.Enabled = !Direction.AX5;
            checkBox_AX6.Enabled = !Direction.AX6;
            checkBox_AX7.Enabled = !Direction.AX7;
            if (Direction.AX0) checkBox_AX0.Checked = State.AX0;    // only set CheckBox if input else may enter continuous loop
            if (Direction.AX1) checkBox_AX1.Checked = State.AX1;
            if (Direction.AX2) checkBox_AX2.Checked = State.AX2;
            if (Direction.AX3) checkBox_AX3.Checked = State.AX3;
            if (Direction.AX4) checkBox_AX4.Checked = State.AX4;
            if (Direction.AX5) checkBox_AX5.Checked = State.AX5;
            if (Direction.AX6) checkBox_AX6.Checked = State.AX6;
            if (Direction.AX7) checkBox_AX7.Checked = State.AX7;
        }

        /// <summary>
        /// TrackBar Scroll event to parse data to parent via event.
        /// </summary>
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Enabled == true)     // only trigger event if output else may enter continuous loop
            {
                State.AX0 = checkBox_AX0.Checked;
                State.AX1 = checkBox_AX1.Checked;
                State.AX2 = checkBox_AX2.Checked;
                State.AX3 = checkBox_AX3.Checked;
                State.AX4 = checkBox_AX4.Checked;
                State.AX5 = checkBox_AX5.Checked;
                State.AX6 = checkBox_AX6.Checked;
                State.AX7 = checkBox_AX7.Checked;
                OnOutputChanged(State);
            }
        }

        public delegate void onOutputChanged(object sender, x_IMU_API.DigitalPortBits e);
        public event onOutputChanged OutputChanged;
        protected virtual void OnOutputChanged(x_IMU_API.DigitalPortBits e) { if (OutputChanged != null) OutputChanged(this, e); }
    }
}