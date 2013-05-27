namespace x_IMU_GUI
{
    partial class Form_PWMoutputPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBar_AX0 = new System.Windows.Forms.TrackBar();
            this.groupBox_AX0 = new System.Windows.Forms.GroupBox();
            this.textBox_AX0 = new System.Windows.Forms.TextBox();
            this.label_AX0_0_5 = new System.Windows.Forms.Label();
            this.label_AX0_1_0 = new System.Windows.Forms.Label();
            this.label_AX0_0_0 = new System.Windows.Forms.Label();
            this.groupBox_AX2 = new System.Windows.Forms.GroupBox();
            this.textBox_AX2 = new System.Windows.Forms.TextBox();
            this.label_AX2_0_5 = new System.Windows.Forms.Label();
            this.label_AX2_1_0 = new System.Windows.Forms.Label();
            this.label_AX2_0_0 = new System.Windows.Forms.Label();
            this.trackBar_AX2 = new System.Windows.Forms.TrackBar();
            this.groupBox_AX4 = new System.Windows.Forms.GroupBox();
            this.textBox_AX4 = new System.Windows.Forms.TextBox();
            this.label_AX4_0_5 = new System.Windows.Forms.Label();
            this.label_AX4_1_0 = new System.Windows.Forms.Label();
            this.label_AX4_0_0 = new System.Windows.Forms.Label();
            this.trackBar_AX4 = new System.Windows.Forms.TrackBar();
            this.groupBox_AX6 = new System.Windows.Forms.GroupBox();
            this.textBox_AX6 = new System.Windows.Forms.TextBox();
            this.label_AX6_0_5 = new System.Windows.Forms.Label();
            this.label_AX6_1_0 = new System.Windows.Forms.Label();
            this.label_AX6_0_0 = new System.Windows.Forms.Label();
            this.trackBar_AX6 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_AX0)).BeginInit();
            this.groupBox_AX0.SuspendLayout();
            this.groupBox_AX2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_AX2)).BeginInit();
            this.groupBox_AX4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_AX4)).BeginInit();
            this.groupBox_AX6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_AX6)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar_AX0
            // 
            this.trackBar_AX0.LargeChange = 1024;
            this.trackBar_AX0.Location = new System.Drawing.Point(6, 19);
            this.trackBar_AX0.Maximum = 65535;
            this.trackBar_AX0.Name = "trackBar_AX0";
            this.trackBar_AX0.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_AX0.Size = new System.Drawing.Size(45, 229);
            this.trackBar_AX0.TabIndex = 0;
            this.trackBar_AX0.TickFrequency = 1300;
            this.trackBar_AX0.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // groupBox_AX0
            // 
            this.groupBox_AX0.Controls.Add(this.textBox_AX0);
            this.groupBox_AX0.Controls.Add(this.label_AX0_0_5);
            this.groupBox_AX0.Controls.Add(this.label_AX0_1_0);
            this.groupBox_AX0.Controls.Add(this.label_AX0_0_0);
            this.groupBox_AX0.Controls.Add(this.trackBar_AX0);
            this.groupBox_AX0.Location = new System.Drawing.Point(12, 12);
            this.groupBox_AX0.Name = "groupBox_AX0";
            this.groupBox_AX0.Size = new System.Drawing.Size(74, 295);
            this.groupBox_AX0.TabIndex = 0;
            this.groupBox_AX0.TabStop = false;
            this.groupBox_AX0.Text = "AX0";
            // 
            // textBox_AX0
            // 
            this.textBox_AX0.Enabled = false;
            this.textBox_AX0.Location = new System.Drawing.Point(6, 264);
            this.textBox_AX0.Name = "textBox_AX0";
            this.textBox_AX0.Size = new System.Drawing.Size(60, 20);
            this.textBox_AX0.TabIndex = 1;
            this.textBox_AX0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_AX0_0_5
            // 
            this.label_AX0_0_5.AutoSize = true;
            this.label_AX0_0_5.Location = new System.Drawing.Point(38, 120);
            this.label_AX0_0_5.Name = "label_AX0_0_5";
            this.label_AX0_0_5.Size = new System.Drawing.Size(27, 13);
            this.label_AX0_0_5.TabIndex = 4;
            this.label_AX0_0_5.Text = "50%";
            // 
            // label_AX0_1_0
            // 
            this.label_AX0_1_0.AutoSize = true;
            this.label_AX0_1_0.Location = new System.Drawing.Point(38, 19);
            this.label_AX0_1_0.Name = "label_AX0_1_0";
            this.label_AX0_1_0.Size = new System.Drawing.Size(33, 13);
            this.label_AX0_1_0.TabIndex = 3;
            this.label_AX0_1_0.Text = "100%";
            // 
            // label_AX0_0_0
            // 
            this.label_AX0_0_0.AutoSize = true;
            this.label_AX0_0_0.Location = new System.Drawing.Point(38, 235);
            this.label_AX0_0_0.Name = "label_AX0_0_0";
            this.label_AX0_0_0.Size = new System.Drawing.Size(21, 13);
            this.label_AX0_0_0.TabIndex = 2;
            this.label_AX0_0_0.Text = "0%";
            // 
            // groupBox_AX2
            // 
            this.groupBox_AX2.Controls.Add(this.textBox_AX2);
            this.groupBox_AX2.Controls.Add(this.label_AX2_0_5);
            this.groupBox_AX2.Controls.Add(this.label_AX2_1_0);
            this.groupBox_AX2.Controls.Add(this.label_AX2_0_0);
            this.groupBox_AX2.Controls.Add(this.trackBar_AX2);
            this.groupBox_AX2.Location = new System.Drawing.Point(92, 12);
            this.groupBox_AX2.Name = "groupBox_AX2";
            this.groupBox_AX2.Size = new System.Drawing.Size(74, 295);
            this.groupBox_AX2.TabIndex = 1;
            this.groupBox_AX2.TabStop = false;
            this.groupBox_AX2.Text = "AX2";
            // 
            // textBox_AX2
            // 
            this.textBox_AX2.Enabled = false;
            this.textBox_AX2.Location = new System.Drawing.Point(6, 264);
            this.textBox_AX2.Name = "textBox_AX2";
            this.textBox_AX2.Size = new System.Drawing.Size(60, 20);
            this.textBox_AX2.TabIndex = 1;
            this.textBox_AX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_AX2_0_5
            // 
            this.label_AX2_0_5.AutoSize = true;
            this.label_AX2_0_5.Location = new System.Drawing.Point(38, 120);
            this.label_AX2_0_5.Name = "label_AX2_0_5";
            this.label_AX2_0_5.Size = new System.Drawing.Size(27, 13);
            this.label_AX2_0_5.TabIndex = 4;
            this.label_AX2_0_5.Text = "50%";
            // 
            // label_AX2_1_0
            // 
            this.label_AX2_1_0.AutoSize = true;
            this.label_AX2_1_0.Location = new System.Drawing.Point(38, 19);
            this.label_AX2_1_0.Name = "label_AX2_1_0";
            this.label_AX2_1_0.Size = new System.Drawing.Size(33, 13);
            this.label_AX2_1_0.TabIndex = 3;
            this.label_AX2_1_0.Text = "100%";
            // 
            // label_AX2_0_0
            // 
            this.label_AX2_0_0.AutoSize = true;
            this.label_AX2_0_0.Location = new System.Drawing.Point(38, 235);
            this.label_AX2_0_0.Name = "label_AX2_0_0";
            this.label_AX2_0_0.Size = new System.Drawing.Size(21, 13);
            this.label_AX2_0_0.TabIndex = 2;
            this.label_AX2_0_0.Text = "0%";
            // 
            // trackBar_AX2
            // 
            this.trackBar_AX2.LargeChange = 1024;
            this.trackBar_AX2.Location = new System.Drawing.Point(6, 19);
            this.trackBar_AX2.Maximum = 65535;
            this.trackBar_AX2.Name = "trackBar_AX2";
            this.trackBar_AX2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_AX2.Size = new System.Drawing.Size(45, 229);
            this.trackBar_AX2.TabIndex = 0;
            this.trackBar_AX2.TickFrequency = 1300;
            this.trackBar_AX2.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // groupBox_AX4
            // 
            this.groupBox_AX4.Controls.Add(this.textBox_AX4);
            this.groupBox_AX4.Controls.Add(this.label_AX4_0_5);
            this.groupBox_AX4.Controls.Add(this.label_AX4_1_0);
            this.groupBox_AX4.Controls.Add(this.label_AX4_0_0);
            this.groupBox_AX4.Controls.Add(this.trackBar_AX4);
            this.groupBox_AX4.Location = new System.Drawing.Point(172, 12);
            this.groupBox_AX4.Name = "groupBox_AX4";
            this.groupBox_AX4.Size = new System.Drawing.Size(74, 295);
            this.groupBox_AX4.TabIndex = 2;
            this.groupBox_AX4.TabStop = false;
            this.groupBox_AX4.Text = "AX4";
            // 
            // textBox_AX4
            // 
            this.textBox_AX4.Enabled = false;
            this.textBox_AX4.Location = new System.Drawing.Point(6, 264);
            this.textBox_AX4.Name = "textBox_AX4";
            this.textBox_AX4.Size = new System.Drawing.Size(60, 20);
            this.textBox_AX4.TabIndex = 1;
            this.textBox_AX4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_AX4_0_5
            // 
            this.label_AX4_0_5.AutoSize = true;
            this.label_AX4_0_5.Location = new System.Drawing.Point(38, 120);
            this.label_AX4_0_5.Name = "label_AX4_0_5";
            this.label_AX4_0_5.Size = new System.Drawing.Size(27, 13);
            this.label_AX4_0_5.TabIndex = 4;
            this.label_AX4_0_5.Text = "50%";
            // 
            // label_AX4_1_0
            // 
            this.label_AX4_1_0.AutoSize = true;
            this.label_AX4_1_0.Location = new System.Drawing.Point(38, 19);
            this.label_AX4_1_0.Name = "label_AX4_1_0";
            this.label_AX4_1_0.Size = new System.Drawing.Size(33, 13);
            this.label_AX4_1_0.TabIndex = 3;
            this.label_AX4_1_0.Text = "100%";
            // 
            // label_AX4_0_0
            // 
            this.label_AX4_0_0.AutoSize = true;
            this.label_AX4_0_0.Location = new System.Drawing.Point(38, 235);
            this.label_AX4_0_0.Name = "label_AX4_0_0";
            this.label_AX4_0_0.Size = new System.Drawing.Size(21, 13);
            this.label_AX4_0_0.TabIndex = 2;
            this.label_AX4_0_0.Text = "0%";
            // 
            // trackBar_AX4
            // 
            this.trackBar_AX4.LargeChange = 1024;
            this.trackBar_AX4.Location = new System.Drawing.Point(6, 19);
            this.trackBar_AX4.Maximum = 65535;
            this.trackBar_AX4.Name = "trackBar_AX4";
            this.trackBar_AX4.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_AX4.Size = new System.Drawing.Size(45, 229);
            this.trackBar_AX4.TabIndex = 0;
            this.trackBar_AX4.TickFrequency = 1300;
            this.trackBar_AX4.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // groupBox_AX6
            // 
            this.groupBox_AX6.Controls.Add(this.textBox_AX6);
            this.groupBox_AX6.Controls.Add(this.label_AX6_0_5);
            this.groupBox_AX6.Controls.Add(this.label_AX6_1_0);
            this.groupBox_AX6.Controls.Add(this.label_AX6_0_0);
            this.groupBox_AX6.Controls.Add(this.trackBar_AX6);
            this.groupBox_AX6.Location = new System.Drawing.Point(252, 12);
            this.groupBox_AX6.Name = "groupBox_AX6";
            this.groupBox_AX6.Size = new System.Drawing.Size(74, 295);
            this.groupBox_AX6.TabIndex = 3;
            this.groupBox_AX6.TabStop = false;
            this.groupBox_AX6.Text = "AX6";
            // 
            // textBox_AX6
            // 
            this.textBox_AX6.Enabled = false;
            this.textBox_AX6.Location = new System.Drawing.Point(6, 264);
            this.textBox_AX6.Name = "textBox_AX6";
            this.textBox_AX6.Size = new System.Drawing.Size(60, 20);
            this.textBox_AX6.TabIndex = 1;
            this.textBox_AX6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_AX6_0_5
            // 
            this.label_AX6_0_5.AutoSize = true;
            this.label_AX6_0_5.Location = new System.Drawing.Point(38, 120);
            this.label_AX6_0_5.Name = "label_AX6_0_5";
            this.label_AX6_0_5.Size = new System.Drawing.Size(27, 13);
            this.label_AX6_0_5.TabIndex = 4;
            this.label_AX6_0_5.Text = "50%";
            // 
            // label_AX6_1_0
            // 
            this.label_AX6_1_0.AutoSize = true;
            this.label_AX6_1_0.Location = new System.Drawing.Point(38, 19);
            this.label_AX6_1_0.Name = "label_AX6_1_0";
            this.label_AX6_1_0.Size = new System.Drawing.Size(33, 13);
            this.label_AX6_1_0.TabIndex = 3;
            this.label_AX6_1_0.Text = "100%";
            // 
            // label_AX6_0_0
            // 
            this.label_AX6_0_0.AutoSize = true;
            this.label_AX6_0_0.Location = new System.Drawing.Point(38, 235);
            this.label_AX6_0_0.Name = "label_AX6_0_0";
            this.label_AX6_0_0.Size = new System.Drawing.Size(21, 13);
            this.label_AX6_0_0.TabIndex = 2;
            this.label_AX6_0_0.Text = "0%";
            // 
            // trackBar_AX6
            // 
            this.trackBar_AX6.LargeChange = 1024;
            this.trackBar_AX6.Location = new System.Drawing.Point(6, 19);
            this.trackBar_AX6.Maximum = 65535;
            this.trackBar_AX6.Name = "trackBar_AX6";
            this.trackBar_AX6.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_AX6.Size = new System.Drawing.Size(45, 229);
            this.trackBar_AX6.TabIndex = 0;
            this.trackBar_AX6.TickFrequency = 1300;
            this.trackBar_AX6.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // Form_PWMoutputPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 318);
            this.Controls.Add(this.groupBox_AX6);
            this.Controls.Add(this.groupBox_AX4);
            this.Controls.Add(this.groupBox_AX2);
            this.Controls.Add(this.groupBox_AX0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_PWMoutputPanel";
            this.Text = "PWM Output Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_PWMoutputPanel_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.Form_PWMoutputPanel_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_AX0)).EndInit();
            this.groupBox_AX0.ResumeLayout(false);
            this.groupBox_AX0.PerformLayout();
            this.groupBox_AX2.ResumeLayout(false);
            this.groupBox_AX2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_AX2)).EndInit();
            this.groupBox_AX4.ResumeLayout(false);
            this.groupBox_AX4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_AX4)).EndInit();
            this.groupBox_AX6.ResumeLayout(false);
            this.groupBox_AX6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_AX6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_AX0;
        private System.Windows.Forms.TrackBar trackBar_AX0;
        private System.Windows.Forms.TextBox textBox_AX0;
        private System.Windows.Forms.Label label_AX0_0_0;
        private System.Windows.Forms.Label label_AX0_0_5;
        private System.Windows.Forms.Label label_AX0_1_0;
        private System.Windows.Forms.GroupBox groupBox_AX2;
        private System.Windows.Forms.TrackBar trackBar_AX2;
        private System.Windows.Forms.TextBox textBox_AX2;
        private System.Windows.Forms.Label label_AX2_0_0;
        private System.Windows.Forms.Label label_AX2_0_5;
        private System.Windows.Forms.Label label_AX2_1_0;
        private System.Windows.Forms.GroupBox groupBox_AX4;
        private System.Windows.Forms.TrackBar trackBar_AX4;
        private System.Windows.Forms.TextBox textBox_AX4;
        private System.Windows.Forms.Label label_AX4_0_0;
        private System.Windows.Forms.Label label_AX4_0_5;
        private System.Windows.Forms.Label label_AX4_1_0;
        private System.Windows.Forms.GroupBox groupBox_AX6;
        private System.Windows.Forms.TrackBar trackBar_AX6;
        private System.Windows.Forms.TextBox textBox_AX6;
        private System.Windows.Forms.Label label_AX6_0_0;
        private System.Windows.Forms.Label label_AX6_0_5;
        private System.Windows.Forms.Label label_AX6_1_0;
    }
}