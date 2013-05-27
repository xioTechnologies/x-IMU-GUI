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
        /// Gets or sets the AX0 duty cycle displayed in the TextBox.
        /// </summary>
        public float AX0 { get; set; }

        /// <summary>
        /// Gets or sets the AX2 duty cycle displayed in the TextBox.
        /// </summary>
        public float AX2 { get; set; }

        /// <summary>
        /// Gets or sets the AX4 duty cycle displayed in the TextBox.
        /// </summary>
        public float AX4 { get; set; }

        /// <summary>
        /// Gets or sets the AX6 duty cycle displayed in the TextBox.
        /// </summary>
        public float AX6 { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="Form_PWMoutputPanel"/> class.
        /// </summary>
        public Form_PWMoutputPanel()
        {
            InitializeComponent();
            AX0 = 0.0f;
            AX2 = 0.0f;
            AX4 = 0.0f;
            AX6 = 0.0f;
            formUpdateTimer = new Timer();
            formUpdateTimer.Interval = 20;
            formUpdateTimer.Tick += new EventHandler(formUpdateTimer_Tick);
        }

        /// <summary>
        /// Visible changed event to start/stop form update formUpdateTimer.
        /// </summary>
        private void Form_PWMoutputPanel_VisibleChanged(object sender, EventArgs e)
        {
             if(this.Visible) {
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
        private void Form_PWMoutputPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }

        /// <summary>
        /// TrackBar Scroll event to set flag.
        /// </summary>
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            trackBarsChanged = true;
        }

        /// <summary>
        /// Timer tick event to update form controls and parse TrackBar values if have changed.
        /// </summary>
        private void formUpdateTimer_Tick(object sender, EventArgs e)
        {
            textBox_AX0.Text = String.Format("{0:0.000}", AX0);
            textBox_AX2.Text = String.Format("{0:0.000}", AX2);
            textBox_AX4.Text = String.Format("{0:0.000}", AX4);
            textBox_AX6.Text = String.Format("{0:0.000}", AX6);
            if (trackBarsChanged)
            {
                trackBarsChanged = false;
                OnValuesChanged(new x_IMU_API.PWMoutputData(((float)trackBar_AX0.Value) / 1000.0f, ((float)trackBar_AX2.Value) / 1000.0f, ((float)trackBar_AX4.Value) / 1000.0f, ((float)trackBar_AX6.Value) / 1000.0f));
            }
        }

        public delegate void onValuesChanged(object sender, x_IMU_API.PWMoutputData e);
        public event onValuesChanged ValuesChanged;
        protected virtual void OnValuesChanged(x_IMU_API.PWMoutputData e) { if (ValuesChanged != null) ValuesChanged(this, e); }
    }
}
