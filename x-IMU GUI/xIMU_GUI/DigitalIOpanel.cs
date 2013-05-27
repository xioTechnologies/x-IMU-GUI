using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace xIMU_GUI
{
    /// <summary>
    /// Digital I/O panel class.
    /// </summary>
    class DigitalIOpanel
    {
        #region Variables

        private Form form;
        private Timer timer;
        private CheckBox checkBox_AX0;
        private CheckBox checkBox_AX1;
        private CheckBox checkBox_AX2;
        private CheckBox checkBox_AX3;
        private CheckBox checkBox_AX4;
        private CheckBox checkBox_AX5;
        private CheckBox checkBox_AX6;
        private CheckBox checkBox_AX7;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the digital I/O directions.
        /// </summary>
        public xIMU_API.DigitalIOdata.PortData IsInput { get; set; }

        /// <summary>
        /// Gets or sets the digital I/O states.
        /// </summary>
        /// <remarks>
        /// Will not apply states if channel is not an input.
        /// </remarks>
        public xIMU_API.DigitalIOdata.PortData State { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="DigitalIOpanel"/> class.
        /// </summary>
        public DigitalIOpanel()
        {
            #region Create check boxes

            checkBox_AX0 = new CheckBox();
            checkBox_AX1 = new CheckBox();
            checkBox_AX2 = new CheckBox();
            checkBox_AX3 = new CheckBox();
            checkBox_AX4 = new CheckBox();
            checkBox_AX5 = new CheckBox();
            checkBox_AX6 = new CheckBox();
            checkBox_AX7 = new CheckBox();
            checkBox_AX0.Location = new System.Drawing.Point(379, 14);
            checkBox_AX1.Location = new System.Drawing.Point(327, 14);
            checkBox_AX2.Location = new System.Drawing.Point(275, 14);
            checkBox_AX3.Location = new System.Drawing.Point(223, 14);
            checkBox_AX4.Location = new System.Drawing.Point(171, 14);
            checkBox_AX5.Location = new System.Drawing.Point(119, 14);
            checkBox_AX6.Location = new System.Drawing.Point(67, 14);
            checkBox_AX7.Location = new System.Drawing.Point(15, 14);
            checkBox_AX0.Text = "AX0";
            checkBox_AX1.Text = "AX1";
            checkBox_AX2.Text = "AX2";
            checkBox_AX3.Text = "AX3";
            checkBox_AX4.Text = "AX4";
            checkBox_AX5.Text = "AX5";
            checkBox_AX6.Text = "AX6";
            checkBox_AX7.Text = "AX7";
            checkBox_AX0.CheckStateChanged += new EventHandler(checkBox_CheckStateChanged);
            checkBox_AX1.CheckStateChanged += new EventHandler(checkBox_CheckStateChanged);
            checkBox_AX2.CheckStateChanged += new EventHandler(checkBox_CheckStateChanged);
            checkBox_AX3.CheckStateChanged += new EventHandler(checkBox_CheckStateChanged);
            checkBox_AX4.CheckStateChanged += new EventHandler(checkBox_CheckStateChanged);
            checkBox_AX5.CheckStateChanged += new EventHandler(checkBox_CheckStateChanged);
            checkBox_AX6.CheckStateChanged += new EventHandler(checkBox_CheckStateChanged);
            checkBox_AX7.CheckStateChanged += new EventHandler(checkBox_CheckStateChanged);

            #endregion

            #region Create form

            form = new Form();
            form.ClientSize = new System.Drawing.Size(439, 48);
            form.Controls.Add(checkBox_AX0);
            form.Controls.Add(checkBox_AX1);
            form.Controls.Add(checkBox_AX2);
            form.Controls.Add(checkBox_AX3);
            form.Controls.Add(checkBox_AX4);
            form.Controls.Add(checkBox_AX5);
            form.Controls.Add(checkBox_AX6);
            form.Controls.Add(checkBox_AX7);
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.Text = "Digital I/O Panel";
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);

            #endregion

            #region Create timer

            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += new EventHandler(timer_Tick);

            #endregion

            #region Create properties

            IsInput = new xIMU_API.DigitalIOdata.PortData();
            State = new xIMU_API.DigitalIOdata.PortData();

            #endregion
        }

        #endregion

        #region Methods

        /// <summary>
        /// Shows the digital I/O panel form.
        /// </summary>
        public void Show()
        {
            timer.Start();
            form.Show();
        }

        /// <summary>
        /// Hides the digital I/O panel form.
        /// </summary>
        public void Hide()
        {
            timer.Stop();
            form.Hide();
        }

        /// <summary>
        /// Timer tick event to update form controls.
        /// </summary>
        void timer_Tick(object sender, EventArgs e)
        {
            #region Indicate direction

            checkBox_AX0.Enabled = !IsInput.AX0;
            checkBox_AX1.Enabled = !IsInput.AX1;
            checkBox_AX2.Enabled = !IsInput.AX2;
            checkBox_AX3.Enabled = !IsInput.AX3;
            checkBox_AX4.Enabled = !IsInput.AX4;
            checkBox_AX5.Enabled = !IsInput.AX5;
            checkBox_AX6.Enabled = !IsInput.AX6;
            checkBox_AX7.Enabled = !IsInput.AX7;

            #endregion

            #region Indicate state

            if (IsInput.AX0) checkBox_AX0.Checked = State.AX0;  // do not adjust outputs as out-of-date incoming data may cancel out user action
            if (IsInput.AX1) checkBox_AX1.Checked = State.AX1;
            if (IsInput.AX2) checkBox_AX2.Checked = State.AX2;
            if (IsInput.AX3) checkBox_AX3.Checked = State.AX3;
            if (IsInput.AX4) checkBox_AX4.Checked = State.AX4;
            if (IsInput.AX5) checkBox_AX5.Checked = State.AX5;
            if (IsInput.AX6) checkBox_AX6.Checked = State.AX6;
            if (IsInput.AX7) checkBox_AX7.Checked = State.AX7;

            #endregion
        }

        /// <summary>
        /// Form closing event to minimise form instead of close.
        /// </summary>
        void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }

        #endregion

        #region Events

        /// <summary>
        /// Check box state changed event to update property parse data to parent.
        /// </summary>
        void checkBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Enabled == true)
            {
                State.AX0 = checkBox_AX0.Checked;
                State.AX1 = checkBox_AX1.Checked;
                State.AX2 = checkBox_AX2.Checked;
                State.AX3 = checkBox_AX3.Checked;
                State.AX4 = checkBox_AX4.Checked;
                State.AX5 = checkBox_AX5.Checked;
                State.AX6 = checkBox_AX6.Checked;
                State.AX7 = checkBox_AX7.Checked;
                OnStateChanged(State);
            }
        }

        public delegate void onStateChanged(object sender, xIMU_API.DigitalIOdata.PortData e);
        public event onStateChanged StateChanged;
        protected virtual void OnStateChanged(xIMU_API.DigitalIOdata.PortData e) { if (StateChanged != null) StateChanged(this, e); }

        #endregion
    }
}
