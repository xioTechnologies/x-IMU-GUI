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
    /// PWM output panel class.
    /// </summary>
    public partial class Form_PWMoutputPanel : Form
    {
        /// <summary>
        /// Form update timer.
        /// </summary>
        private Timer formUpdateTimer;

        /// <summary>
        /// Value to indicate if TrackBar values have changed since last form update.
        /// </summary>
        private bool trackBarsChanged = false;

        /// <summary>
        /// Gets or sets the displayed <see cref="PWMoutputData"/>.
        /// </summary>
        public x_IMU_API.PWMoutputData PWMoutputData { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="Form_PWMoutputPanel"/> class.
        /// </summary>
        public Form_PWMoutputPanel()
        {
            InitializeComponent();
            PWMoutputData = new x_IMU_API.PWMoutputData();
            formUpdateTimer = new Timer();
            formUpdateTimer.Interval = 20;
            formUpdateTimer.Tick += new EventHandler(formUpdateTimer_Tick);
        }

        /// <summary>
        /// Form VisibleChanged event starts/stops formUpdateTimer.
        /// </summary>
        private void Form_PWMoutputPanel_VisibleChanged(object sender, EventArgs e)
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
        /// FormClosing event minimises form instead of close.
        /// </summary>
        private void Form_PWMoutputPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }

        /// <summary>
        /// TrackBar Scroll event set flags.
        /// </summary>
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            trackBarsChanged = true;
        }

        /// <summary>
        /// Timer Tick event updates form controls and parse TrackBar values if have changed.
        /// </summary>
        private void formUpdateTimer_Tick(object sender, EventArgs e)
        {
            textBox_AX0.Text = PWMoutputData.AX0.ToString();
            textBox_AX2.Text = PWMoutputData.AX2.ToString();
            textBox_AX4.Text = PWMoutputData.AX4.ToString();
            textBox_AX6.Text = PWMoutputData.AX6.ToString();
            if (trackBarsChanged)
            {
                trackBarsChanged = false;
                OnValuesChanged(new x_IMU_API.PWMoutputData((ushort)trackBar_AX0.Value, (ushort)trackBar_AX2.Value, (ushort)trackBar_AX4.Value, (ushort)trackBar_AX6.Value));
            }
        }

        public delegate void onValuesChanged(object sender, x_IMU_API.PWMoutputData e);
        public event onValuesChanged ValuesChanged;
        protected virtual void OnValuesChanged(x_IMU_API.PWMoutputData e) { if (ValuesChanged != null) ValuesChanged(this, e); }
    }
}