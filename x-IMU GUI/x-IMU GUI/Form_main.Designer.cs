namespace x_IMU_GUI
{
    partial class Form_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed; otherwise, false.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_main));
            this.button_openPort = new System.Windows.Forms.Button();
            this.label_portName = new System.Windows.Forms.Label();
            this.comboBox_portName = new System.Windows.Forms.ComboBox();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_serialPort = new System.Windows.Forms.TabPage();
            this.groupBox_packetCounts = new System.Windows.Forms.GroupBox();
            this.label_packetsSent = new System.Windows.Forms.Label();
            this.textBox_packetsSent = new System.Windows.Forms.TextBox();
            this.textBox_packetsReceived = new System.Windows.Forms.TextBox();
            this.label_packetsReceived = new System.Windows.Forms.Label();
            this.groupBox_OpenClosePort = new System.Windows.Forms.GroupBox();
            this.button_refreshList = new System.Windows.Forms.Button();
            this.tabPage_registers = new System.Windows.Forms.TabPage();
            this.tabPage_dateTime = new System.Windows.Forms.TabPage();
            this.groupBox_dateTime = new System.Windows.Forms.GroupBox();
            this.button_setDateTime = new System.Windows.Forms.Button();
            this.button_readDateTime = new System.Windows.Forms.Button();
            this.textBox_receivedDataTime = new System.Windows.Forms.TextBox();
            this.label_receivedDateTime = new System.Windows.Forms.Label();
            this.tabPage_commands = new System.Windows.Forms.TabPage();
            this.groupBox_receivedCommandMessages = new System.Windows.Forms.GroupBox();
            this.checkBox_displayCommandConfirmations = new System.Windows.Forms.CheckBox();
            this.groupBox_algorithm = new System.Windows.Forms.GroupBox();
            this.button_initialiseThenTare = new System.Windows.Forms.Button();
            this.button_clearTare = new System.Windows.Forms.Button();
            this.button_tare = new System.Windows.Forms.Button();
            this.button_initialise = new System.Windows.Forms.Button();
            this.groupBox_magnetometerCalibration = new System.Windows.Forms.GroupBox();
            this.button_measMagBiasSens = new System.Windows.Forms.Button();
            this.groupBox_accelerometerCalibration = new System.Windows.Forms.GroupBox();
            this.button_sampleAccelAxisAt1g = new System.Windows.Forms.Button();
            this.button_calcAccelBiasSens = new System.Windows.Forms.Button();
            this.groupBox_gyroscopeCalibration = new System.Windows.Forms.GroupBox();
            this.button_calcGyroBiasParameters = new System.Windows.Forms.Button();
            this.button_calculateGyroSensitivity = new System.Windows.Forms.Button();
            this.button_sampleGyroAt200dps = new System.Windows.Forms.Button();
            this.button_sampleGyroBiasAtT2 = new System.Windows.Forms.Button();
            this.button_sampleGyroBiasAtT1 = new System.Windows.Forms.Button();
            this.groupBox_general = new System.Windows.Forms.GroupBox();
            this.button_factoryReset = new System.Windows.Forms.Button();
            this.button_resetSleepTimer = new System.Windows.Forms.Button();
            this.button_sleep = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            this.tabPage_ViewSensorData = new System.Windows.Forms.TabPage();
            this.groupBox_orienData = new System.Windows.Forms.GroupBox();
            this.label_psi = new System.Windows.Forms.Label();
            this.label_theta = new System.Windows.Forms.Label();
            this.label_phi = new System.Windows.Forms.Label();
            this.label_eulerLegend = new System.Windows.Forms.Label();
            this.button_showEulerAngleGraph = new System.Windows.Forms.Button();
            this.button_show3Dcuboid = new System.Windows.Forms.Button();
            this.groupBox_sensorData = new System.Windows.Forms.GroupBox();
            this.label_legendZ = new System.Windows.Forms.Label();
            this.label_legendY = new System.Windows.Forms.Label();
            this.label_legendX = new System.Windows.Forms.Label();
            this.label_sensorLegend = new System.Windows.Forms.Label();
            this.button_showMagGraph = new System.Windows.Forms.Button();
            this.button_showAccelGraph = new System.Windows.Forms.Button();
            this.button_showGyroGraph = new System.Windows.Forms.Button();
            this.groupBox_battThermData = new System.Windows.Forms.GroupBox();
            this.button_showBatteryGraph = new System.Windows.Forms.Button();
            this.button_showThermGraph = new System.Windows.Forms.Button();
            this.tabPage_auxillaryPort = new System.Windows.Forms.TabPage();
            this.groupBox_ADXL345bus = new System.Windows.Forms.GroupBox();
            this.button_showADXL345Dgraph = new System.Windows.Forms.Button();
            this.button_showADXL345Cgraph = new System.Windows.Forms.Button();
            this.button_showADXL345Bgraph = new System.Windows.Forms.Button();
            this.button_showADXL345Agraph = new System.Windows.Forms.Button();
            this.groupBox_pwmOutput = new System.Windows.Forms.GroupBox();
            this.button_showPWMoutputPanel = new System.Windows.Forms.Button();
            this.groupBox_analogueInput = new System.Windows.Forms.GroupBox();
            this.button_showAX6andAX7graph = new System.Windows.Forms.Button();
            this.button_showAX4andAX5graph = new System.Windows.Forms.Button();
            this.button_showAX2andAX3graph = new System.Windows.Forms.Button();
            this.button_showAX0andAX1graph = new System.Windows.Forms.Button();
            this.groupBox_digitalIO = new System.Windows.Forms.GroupBox();
            this.button_showDigitalIOpanel = new System.Windows.Forms.Button();
            this.tabPage_dataLogger = new System.Windows.Forms.TabPage();
            this.groupBox_logReceivedDataToFile = new System.Windows.Forms.GroupBox();
            this.button_dataLoggerFilePathBrowse = new System.Windows.Forms.Button();
            this.label_dataLoggerFilePath = new System.Windows.Forms.Label();
            this.textBox_dataLoggerFilePath = new System.Windows.Forms.TextBox();
            this.button_dataLoggerStart = new System.Windows.Forms.Button();
            this.tabPage_SDcard = new System.Windows.Forms.TabPage();
            this.groupBox_convertBinaryFile = new System.Windows.Forms.GroupBox();
            this.button_convertBinaryFileConvertBrowse = new System.Windows.Forms.Button();
            this.labelconvertBinaryFileFilePath = new System.Windows.Forms.Label();
            this.textBox_convertBinaryFileFilePath = new System.Windows.Forms.TextBox();
            this.button_convertBinaryFileConvert = new System.Windows.Forms.Button();
            this.tabPage_hardIronCalibration = new System.Windows.Forms.TabPage();
            this.groupBox_step3hardIronCalibrationAlgorithm = new System.Windows.Forms.GroupBox();
            this.button_hardIronCalBrowse = new System.Windows.Forms.Button();
            this.label_hardIronCalFilePath = new System.Windows.Forms.Label();
            this.textBox_hardIronCalFilePath = new System.Windows.Forms.TextBox();
            this.button_hardIronCalRun = new System.Windows.Forms.Button();
            this.groupBox_step2collectHardIronCalibrationDataSet = new System.Windows.Forms.GroupBox();
            this.button_collectHardIronCalDatasetBrowse = new System.Windows.Forms.Button();
            this.label_collectHardIronCalDatasetFilePath = new System.Windows.Forms.Label();
            this.textBox_collectHardIronCalDatasetFilePath = new System.Windows.Forms.TextBox();
            this.button_collectHardIronCalDatasetStartLogging = new System.Windows.Forms.Button();
            this.groupBox_step1ClearHardIronBiasRegisters = new System.Windows.Forms.GroupBox();
            this.button_clearHardIronRegisters = new System.Windows.Forms.Button();
            this.tabPage_uploadFirmware = new System.Windows.Forms.TabPage();
            this.groupBox_bootloader = new System.Windows.Forms.GroupBox();
            this.button_bootloaderBrowse = new System.Windows.Forms.Button();
            this.label_bootloaderFilePath = new System.Windows.Forms.Label();
            this.textBox_bootloaderFilePath = new System.Windows.Forms.TextBox();
            this.button_bootloaderUpload = new System.Windows.Forms.Button();
            this.tabPage_about = new System.Windows.Forms.TabPage();
            this.label_forLatest = new System.Windows.Forms.Label();
            this.label_check = new System.Windows.Forms.Label();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.label_GUIversionNum = new System.Windows.Forms.Label();
            this.label_APIversionNum = new System.Windows.Forms.Label();
            this.label_compatibleFirmwareVersionNums = new System.Windows.Forms.Label();
            this.linkLabel_www = new System.Windows.Forms.LinkLabel();
            this.label_compatibleFirmwareVersions = new System.Windows.Forms.Label();
            this.label_APIversion = new System.Windows.Forms.Label();
            this.label_GUIversion = new System.Windows.Forms.Label();
            this.appendedTreeView_registers = new x_IMU_GUI.AppendedTreeView();
            this.tabControl_main.SuspendLayout();
            this.tabPage_serialPort.SuspendLayout();
            this.groupBox_packetCounts.SuspendLayout();
            this.groupBox_OpenClosePort.SuspendLayout();
            this.tabPage_registers.SuspendLayout();
            this.tabPage_dateTime.SuspendLayout();
            this.groupBox_dateTime.SuspendLayout();
            this.tabPage_commands.SuspendLayout();
            this.groupBox_receivedCommandMessages.SuspendLayout();
            this.groupBox_algorithm.SuspendLayout();
            this.groupBox_magnetometerCalibration.SuspendLayout();
            this.groupBox_accelerometerCalibration.SuspendLayout();
            this.groupBox_gyroscopeCalibration.SuspendLayout();
            this.groupBox_general.SuspendLayout();
            this.tabPage_ViewSensorData.SuspendLayout();
            this.groupBox_orienData.SuspendLayout();
            this.groupBox_sensorData.SuspendLayout();
            this.groupBox_battThermData.SuspendLayout();
            this.tabPage_auxillaryPort.SuspendLayout();
            this.groupBox_ADXL345bus.SuspendLayout();
            this.groupBox_pwmOutput.SuspendLayout();
            this.groupBox_analogueInput.SuspendLayout();
            this.groupBox_digitalIO.SuspendLayout();
            this.tabPage_dataLogger.SuspendLayout();
            this.groupBox_logReceivedDataToFile.SuspendLayout();
            this.tabPage_SDcard.SuspendLayout();
            this.groupBox_convertBinaryFile.SuspendLayout();
            this.tabPage_hardIronCalibration.SuspendLayout();
            this.groupBox_step3hardIronCalibrationAlgorithm.SuspendLayout();
            this.groupBox_step2collectHardIronCalibrationDataSet.SuspendLayout();
            this.groupBox_step1ClearHardIronBiasRegisters.SuspendLayout();
            this.tabPage_uploadFirmware.SuspendLayout();
            this.groupBox_bootloader.SuspendLayout();
            this.tabPage_about.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // button_openPort
            // 
            this.button_openPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_openPort.Location = new System.Drawing.Point(720, 20);
            this.button_openPort.Name = "button_openPort";
            this.button_openPort.Size = new System.Drawing.Size(100, 23);
            this.button_openPort.TabIndex = 2;
            this.button_openPort.Text = "Open Port";
            this.button_openPort.UseVisualStyleBackColor = true;
            this.button_openPort.Click += new System.EventHandler(this.button_openPort_Click);
            // 
            // label_portName
            // 
            this.label_portName.AutoSize = true;
            this.label_portName.Location = new System.Drawing.Point(6, 25);
            this.label_portName.Name = "label_portName";
            this.label_portName.Size = new System.Drawing.Size(58, 13);
            this.label_portName.TabIndex = 22;
            this.label_portName.Text = "Port name:";
            // 
            // comboBox_portName
            // 
            this.comboBox_portName.FormattingEnabled = true;
            this.comboBox_portName.Location = new System.Drawing.Point(105, 22);
            this.comboBox_portName.Name = "comboBox_portName";
            this.comboBox_portName.Size = new System.Drawing.Size(81, 21);
            this.comboBox_portName.TabIndex = 0;
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_serialPort);
            this.tabControl_main.Controls.Add(this.tabPage_registers);
            this.tabControl_main.Controls.Add(this.tabPage_dateTime);
            this.tabControl_main.Controls.Add(this.tabPage_commands);
            this.tabControl_main.Controls.Add(this.tabPage_ViewSensorData);
            this.tabControl_main.Controls.Add(this.tabPage_auxillaryPort);
            this.tabControl_main.Controls.Add(this.tabPage_dataLogger);
            this.tabControl_main.Controls.Add(this.tabPage_SDcard);
            this.tabControl_main.Controls.Add(this.tabPage_hardIronCalibration);
            this.tabControl_main.Controls.Add(this.tabPage_uploadFirmware);
            this.tabControl_main.Controls.Add(this.tabPage_about);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(840, 436);
            this.tabControl_main.TabIndex = 10;
            // 
            // tabPage_serialPort
            // 
            this.tabPage_serialPort.AutoScroll = true;
            this.tabPage_serialPort.Controls.Add(this.groupBox_packetCounts);
            this.tabPage_serialPort.Controls.Add(this.groupBox_OpenClosePort);
            this.tabPage_serialPort.Location = new System.Drawing.Point(4, 22);
            this.tabPage_serialPort.Name = "tabPage_serialPort";
            this.tabPage_serialPort.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_serialPort.Size = new System.Drawing.Size(832, 410);
            this.tabPage_serialPort.TabIndex = 0;
            this.tabPage_serialPort.Text = "Serial Port";
            this.tabPage_serialPort.UseVisualStyleBackColor = true;
            // 
            // groupBox_packetCounts
            // 
            this.groupBox_packetCounts.Controls.Add(this.label_packetsSent);
            this.groupBox_packetCounts.Controls.Add(this.textBox_packetsSent);
            this.groupBox_packetCounts.Controls.Add(this.textBox_packetsReceived);
            this.groupBox_packetCounts.Controls.Add(this.label_packetsReceived);
            this.groupBox_packetCounts.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_packetCounts.Location = new System.Drawing.Point(3, 62);
            this.groupBox_packetCounts.Name = "groupBox_packetCounts";
            this.groupBox_packetCounts.Size = new System.Drawing.Size(826, 84);
            this.groupBox_packetCounts.TabIndex = 1;
            this.groupBox_packetCounts.TabStop = false;
            this.groupBox_packetCounts.Text = "Packet Counts";
            // 
            // label_packetsSent
            // 
            this.label_packetsSent.AutoSize = true;
            this.label_packetsSent.Location = new System.Drawing.Point(6, 51);
            this.label_packetsSent.Name = "label_packetsSent";
            this.label_packetsSent.Size = new System.Drawing.Size(72, 13);
            this.label_packetsSent.TabIndex = 26;
            this.label_packetsSent.Text = "Packets sent:";
            // 
            // textBox_packetsSent
            // 
            this.textBox_packetsSent.Enabled = false;
            this.textBox_packetsSent.Location = new System.Drawing.Point(105, 48);
            this.textBox_packetsSent.Name = "textBox_packetsSent";
            this.textBox_packetsSent.Size = new System.Drawing.Size(81, 20);
            this.textBox_packetsSent.TabIndex = 1;
            this.textBox_packetsSent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_packetsReceived
            // 
            this.textBox_packetsReceived.Enabled = false;
            this.textBox_packetsReceived.Location = new System.Drawing.Point(105, 22);
            this.textBox_packetsReceived.Name = "textBox_packetsReceived";
            this.textBox_packetsReceived.Size = new System.Drawing.Size(81, 20);
            this.textBox_packetsReceived.TabIndex = 0;
            this.textBox_packetsReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_packetsReceived
            // 
            this.label_packetsReceived.AutoSize = true;
            this.label_packetsReceived.Location = new System.Drawing.Point(6, 25);
            this.label_packetsReceived.Name = "label_packetsReceived";
            this.label_packetsReceived.Size = new System.Drawing.Size(93, 13);
            this.label_packetsReceived.TabIndex = 23;
            this.label_packetsReceived.Text = "Packets received:";
            // 
            // groupBox_OpenClosePort
            // 
            this.groupBox_OpenClosePort.Controls.Add(this.comboBox_portName);
            this.groupBox_OpenClosePort.Controls.Add(this.button_refreshList);
            this.groupBox_OpenClosePort.Controls.Add(this.button_openPort);
            this.groupBox_OpenClosePort.Controls.Add(this.label_portName);
            this.groupBox_OpenClosePort.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_OpenClosePort.Location = new System.Drawing.Point(3, 3);
            this.groupBox_OpenClosePort.Name = "groupBox_OpenClosePort";
            this.groupBox_OpenClosePort.Size = new System.Drawing.Size(826, 59);
            this.groupBox_OpenClosePort.TabIndex = 0;
            this.groupBox_OpenClosePort.TabStop = false;
            this.groupBox_OpenClosePort.Text = "Open/Close Port";
            // 
            // button_refreshList
            // 
            this.button_refreshList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_refreshList.Location = new System.Drawing.Point(614, 20);
            this.button_refreshList.Name = "button_refreshList";
            this.button_refreshList.Size = new System.Drawing.Size(100, 23);
            this.button_refreshList.TabIndex = 1;
            this.button_refreshList.Text = "Refresh List";
            this.button_refreshList.UseVisualStyleBackColor = true;
            this.button_refreshList.Click += new System.EventHandler(this.button_refreshList_Click);
            // 
            // tabPage_registers
            // 
            this.tabPage_registers.Controls.Add(this.appendedTreeView_registers);
            this.tabPage_registers.Location = new System.Drawing.Point(4, 22);
            this.tabPage_registers.Name = "tabPage_registers";
            this.tabPage_registers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_registers.Size = new System.Drawing.Size(832, 410);
            this.tabPage_registers.TabIndex = 6;
            this.tabPage_registers.Text = "Registers";
            this.tabPage_registers.UseVisualStyleBackColor = true;
            // 
            // tabPage_dateTime
            // 
            this.tabPage_dateTime.Controls.Add(this.groupBox_dateTime);
            this.tabPage_dateTime.Location = new System.Drawing.Point(4, 22);
            this.tabPage_dateTime.Name = "tabPage_dateTime";
            this.tabPage_dateTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_dateTime.Size = new System.Drawing.Size(832, 410);
            this.tabPage_dateTime.TabIndex = 11;
            this.tabPage_dateTime.Text = "Date/Time";
            this.tabPage_dateTime.UseVisualStyleBackColor = true;
            // 
            // groupBox_dateTime
            // 
            this.groupBox_dateTime.Controls.Add(this.button_setDateTime);
            this.groupBox_dateTime.Controls.Add(this.button_readDateTime);
            this.groupBox_dateTime.Controls.Add(this.textBox_receivedDataTime);
            this.groupBox_dateTime.Controls.Add(this.label_receivedDateTime);
            this.groupBox_dateTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_dateTime.Location = new System.Drawing.Point(3, 3);
            this.groupBox_dateTime.Name = "groupBox_dateTime";
            this.groupBox_dateTime.Size = new System.Drawing.Size(826, 59);
            this.groupBox_dateTime.TabIndex = 0;
            this.groupBox_dateTime.TabStop = false;
            this.groupBox_dateTime.Text = "Date/Time";
            // 
            // button_setDateTime
            // 
            this.button_setDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_setDateTime.Location = new System.Drawing.Point(693, 20);
            this.button_setDateTime.Name = "button_setDateTime";
            this.button_setDateTime.Size = new System.Drawing.Size(125, 23);
            this.button_setDateTime.TabIndex = 2;
            this.button_setDateTime.Text = "Set Date/Time";
            this.button_setDateTime.UseVisualStyleBackColor = true;
            this.button_setDateTime.Click += new System.EventHandler(this.button_setDateTime_Click);
            // 
            // button_readDateTime
            // 
            this.button_readDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_readDateTime.Location = new System.Drawing.Point(562, 20);
            this.button_readDateTime.Name = "button_readDateTime";
            this.button_readDateTime.Size = new System.Drawing.Size(125, 23);
            this.button_readDateTime.TabIndex = 1;
            this.button_readDateTime.Text = "Read Date/Time";
            this.button_readDateTime.UseVisualStyleBackColor = true;
            this.button_readDateTime.Click += new System.EventHandler(this.button_readDateTime_Click);
            // 
            // textBox_receivedDataTime
            // 
            this.textBox_receivedDataTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_receivedDataTime.Enabled = false;
            this.textBox_receivedDataTime.Location = new System.Drawing.Point(116, 22);
            this.textBox_receivedDataTime.Name = "textBox_receivedDataTime";
            this.textBox_receivedDataTime.Size = new System.Drawing.Size(440, 20);
            this.textBox_receivedDataTime.TabIndex = 0;
            this.textBox_receivedDataTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_receivedDateTime
            // 
            this.label_receivedDateTime.AutoSize = true;
            this.label_receivedDateTime.Location = new System.Drawing.Point(6, 25);
            this.label_receivedDateTime.Name = "label_receivedDateTime";
            this.label_receivedDateTime.Size = new System.Drawing.Size(104, 13);
            this.label_receivedDateTime.TabIndex = 22;
            this.label_receivedDateTime.Text = "Received date/time:";
            // 
            // tabPage_commands
            // 
            this.tabPage_commands.Controls.Add(this.groupBox_receivedCommandMessages);
            this.tabPage_commands.Controls.Add(this.groupBox_algorithm);
            this.tabPage_commands.Controls.Add(this.groupBox_magnetometerCalibration);
            this.tabPage_commands.Controls.Add(this.groupBox_accelerometerCalibration);
            this.tabPage_commands.Controls.Add(this.groupBox_gyroscopeCalibration);
            this.tabPage_commands.Controls.Add(this.groupBox_general);
            this.tabPage_commands.Location = new System.Drawing.Point(4, 22);
            this.tabPage_commands.Name = "tabPage_commands";
            this.tabPage_commands.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_commands.Size = new System.Drawing.Size(832, 410);
            this.tabPage_commands.TabIndex = 9;
            this.tabPage_commands.Text = "Commands";
            this.tabPage_commands.UseVisualStyleBackColor = true;
            // 
            // groupBox_receivedCommandMessages
            // 
            this.groupBox_receivedCommandMessages.Controls.Add(this.checkBox_displayCommandConfirmations);
            this.groupBox_receivedCommandMessages.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_receivedCommandMessages.Location = new System.Drawing.Point(3, 298);
            this.groupBox_receivedCommandMessages.Name = "groupBox_receivedCommandMessages";
            this.groupBox_receivedCommandMessages.Size = new System.Drawing.Size(826, 59);
            this.groupBox_receivedCommandMessages.TabIndex = 5;
            this.groupBox_receivedCommandMessages.TabStop = false;
            this.groupBox_receivedCommandMessages.Text = "Received Command Messages";
            // 
            // checkBox_displayCommandConfirmations
            // 
            this.checkBox_displayCommandConfirmations.AutoSize = true;
            this.checkBox_displayCommandConfirmations.Checked = true;
            this.checkBox_displayCommandConfirmations.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_displayCommandConfirmations.Location = new System.Drawing.Point(10, 24);
            this.checkBox_displayCommandConfirmations.Name = "checkBox_displayCommandConfirmations";
            this.checkBox_displayCommandConfirmations.Size = new System.Drawing.Size(250, 17);
            this.checkBox_displayCommandConfirmations.TabIndex = 0;
            this.checkBox_displayCommandConfirmations.Text = "Display command confirmations in message box";
            this.checkBox_displayCommandConfirmations.UseVisualStyleBackColor = true;
            // 
            // groupBox_algorithm
            // 
            this.groupBox_algorithm.Controls.Add(this.button_initialiseThenTare);
            this.groupBox_algorithm.Controls.Add(this.button_clearTare);
            this.groupBox_algorithm.Controls.Add(this.button_tare);
            this.groupBox_algorithm.Controls.Add(this.button_initialise);
            this.groupBox_algorithm.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_algorithm.Location = new System.Drawing.Point(3, 239);
            this.groupBox_algorithm.Name = "groupBox_algorithm";
            this.groupBox_algorithm.Size = new System.Drawing.Size(826, 59);
            this.groupBox_algorithm.TabIndex = 4;
            this.groupBox_algorithm.TabStop = false;
            this.groupBox_algorithm.Text = "Algorithm";
            // 
            // button_initialiseThenTare
            // 
            this.button_initialiseThenTare.Location = new System.Drawing.Point(469, 20);
            this.button_initialiseThenTare.Name = "button_initialiseThenTare";
            this.button_initialiseThenTare.Size = new System.Drawing.Size(147, 23);
            this.button_initialiseThenTare.TabIndex = 3;
            this.button_initialiseThenTare.Text = "Initialise Then Tare";
            this.button_initialiseThenTare.UseVisualStyleBackColor = true;
            this.button_initialiseThenTare.Click += new System.EventHandler(this.button_initialiseThenTare_Click);
            // 
            // button_clearTare
            // 
            this.button_clearTare.Location = new System.Drawing.Point(316, 20);
            this.button_clearTare.Name = "button_clearTare";
            this.button_clearTare.Size = new System.Drawing.Size(147, 23);
            this.button_clearTare.TabIndex = 2;
            this.button_clearTare.Text = "Clear Tare";
            this.button_clearTare.UseVisualStyleBackColor = true;
            this.button_clearTare.Click += new System.EventHandler(this.button_clearTare_Click);
            // 
            // button_tare
            // 
            this.button_tare.Location = new System.Drawing.Point(163, 20);
            this.button_tare.Name = "button_tare";
            this.button_tare.Size = new System.Drawing.Size(147, 23);
            this.button_tare.TabIndex = 1;
            this.button_tare.Text = "Tare";
            this.button_tare.UseVisualStyleBackColor = true;
            this.button_tare.Click += new System.EventHandler(this.button_tare_Click);
            // 
            // button_initialise
            // 
            this.button_initialise.Location = new System.Drawing.Point(10, 20);
            this.button_initialise.Name = "button_initialise";
            this.button_initialise.Size = new System.Drawing.Size(147, 23);
            this.button_initialise.TabIndex = 0;
            this.button_initialise.Text = "Initialise";
            this.button_initialise.UseVisualStyleBackColor = true;
            this.button_initialise.Click += new System.EventHandler(this.button_initialise_Click);
            // 
            // groupBox_magnetometerCalibration
            // 
            this.groupBox_magnetometerCalibration.Controls.Add(this.button_measMagBiasSens);
            this.groupBox_magnetometerCalibration.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_magnetometerCalibration.Location = new System.Drawing.Point(3, 180);
            this.groupBox_magnetometerCalibration.Name = "groupBox_magnetometerCalibration";
            this.groupBox_magnetometerCalibration.Size = new System.Drawing.Size(826, 59);
            this.groupBox_magnetometerCalibration.TabIndex = 3;
            this.groupBox_magnetometerCalibration.TabStop = false;
            this.groupBox_magnetometerCalibration.Text = "Magnetometer Calibration";
            // 
            // button_measMagBiasSens
            // 
            this.button_measMagBiasSens.Location = new System.Drawing.Point(10, 20);
            this.button_measMagBiasSens.Name = "button_measMagBiasSens";
            this.button_measMagBiasSens.Size = new System.Drawing.Size(147, 23);
            this.button_measMagBiasSens.TabIndex = 0;
            this.button_measMagBiasSens.Text = "Measure Mag. Bias/Sens.";
            this.button_measMagBiasSens.UseVisualStyleBackColor = true;
            this.button_measMagBiasSens.Click += new System.EventHandler(this.button_measMagBiasSens_Click);
            // 
            // groupBox_accelerometerCalibration
            // 
            this.groupBox_accelerometerCalibration.Controls.Add(this.button_sampleAccelAxisAt1g);
            this.groupBox_accelerometerCalibration.Controls.Add(this.button_calcAccelBiasSens);
            this.groupBox_accelerometerCalibration.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_accelerometerCalibration.Location = new System.Drawing.Point(3, 121);
            this.groupBox_accelerometerCalibration.Name = "groupBox_accelerometerCalibration";
            this.groupBox_accelerometerCalibration.Size = new System.Drawing.Size(826, 59);
            this.groupBox_accelerometerCalibration.TabIndex = 2;
            this.groupBox_accelerometerCalibration.TabStop = false;
            this.groupBox_accelerometerCalibration.Text = "Accelerometer Calibration";
            // 
            // button_sampleAccelAxisAt1g
            // 
            this.button_sampleAccelAxisAt1g.Location = new System.Drawing.Point(10, 20);
            this.button_sampleAccelAxisAt1g.Name = "button_sampleAccelAxisAt1g";
            this.button_sampleAccelAxisAt1g.Size = new System.Drawing.Size(147, 23);
            this.button_sampleAccelAxisAt1g.TabIndex = 0;
            this.button_sampleAccelAxisAt1g.Text = "Sample Accel. Axis @ ±1 g";
            this.button_sampleAccelAxisAt1g.UseVisualStyleBackColor = true;
            this.button_sampleAccelAxisAt1g.Click += new System.EventHandler(this.button_lookupAccelSensitivity_Click);
            // 
            // button_calcAccelBiasSens
            // 
            this.button_calcAccelBiasSens.Location = new System.Drawing.Point(163, 20);
            this.button_calcAccelBiasSens.Name = "button_calcAccelBiasSens";
            this.button_calcAccelBiasSens.Size = new System.Drawing.Size(147, 23);
            this.button_calcAccelBiasSens.TabIndex = 1;
            this.button_calcAccelBiasSens.Text = "Calc. Accel. Bias/Sens.";
            this.button_calcAccelBiasSens.UseVisualStyleBackColor = true;
            this.button_calcAccelBiasSens.Click += new System.EventHandler(this.button_calcAccelBiasSens_Click);
            // 
            // groupBox_gyroscopeCalibration
            // 
            this.groupBox_gyroscopeCalibration.Controls.Add(this.button_calcGyroBiasParameters);
            this.groupBox_gyroscopeCalibration.Controls.Add(this.button_calculateGyroSensitivity);
            this.groupBox_gyroscopeCalibration.Controls.Add(this.button_sampleGyroAt200dps);
            this.groupBox_gyroscopeCalibration.Controls.Add(this.button_sampleGyroBiasAtT2);
            this.groupBox_gyroscopeCalibration.Controls.Add(this.button_sampleGyroBiasAtT1);
            this.groupBox_gyroscopeCalibration.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_gyroscopeCalibration.Location = new System.Drawing.Point(3, 62);
            this.groupBox_gyroscopeCalibration.Name = "groupBox_gyroscopeCalibration";
            this.groupBox_gyroscopeCalibration.Size = new System.Drawing.Size(826, 59);
            this.groupBox_gyroscopeCalibration.TabIndex = 1;
            this.groupBox_gyroscopeCalibration.TabStop = false;
            this.groupBox_gyroscopeCalibration.Text = "Gyroscope Calibration";
            // 
            // button_calcGyroBiasParameters
            // 
            this.button_calcGyroBiasParameters.Location = new System.Drawing.Point(622, 20);
            this.button_calcGyroBiasParameters.Name = "button_calcGyroBiasParameters";
            this.button_calcGyroBiasParameters.Size = new System.Drawing.Size(147, 23);
            this.button_calcGyroBiasParameters.TabIndex = 4;
            this.button_calcGyroBiasParameters.Text = "Calc. Gyro. Bias Parameters";
            this.button_calcGyroBiasParameters.UseVisualStyleBackColor = true;
            this.button_calcGyroBiasParameters.Click += new System.EventHandler(this.button_calcGyroBiasParameters_Click);
            // 
            // button_calculateGyroSensitivity
            // 
            this.button_calculateGyroSensitivity.Location = new System.Drawing.Point(163, 20);
            this.button_calculateGyroSensitivity.Name = "button_calculateGyroSensitivity";
            this.button_calculateGyroSensitivity.Size = new System.Drawing.Size(147, 23);
            this.button_calculateGyroSensitivity.TabIndex = 1;
            this.button_calculateGyroSensitivity.Text = "Calculate Gyro. Sensitivity";
            this.button_calculateGyroSensitivity.UseVisualStyleBackColor = true;
            this.button_calculateGyroSensitivity.Click += new System.EventHandler(this.button_calculateGyroSensitivity_Click);
            // 
            // button_sampleGyroAt200dps
            // 
            this.button_sampleGyroAt200dps.Location = new System.Drawing.Point(10, 20);
            this.button_sampleGyroAt200dps.Name = "button_sampleGyroAt200dps";
            this.button_sampleGyroAt200dps.Size = new System.Drawing.Size(147, 23);
            this.button_sampleGyroAt200dps.TabIndex = 0;
            this.button_sampleGyroAt200dps.Text = "Sample Gyro. @ ±200 ˚/s";
            this.button_sampleGyroAt200dps.UseVisualStyleBackColor = true;
            this.button_sampleGyroAt200dps.Click += new System.EventHandler(this.button_sampleGyroAt200dps_Click);
            // 
            // button_sampleGyroBiasAtT2
            // 
            this.button_sampleGyroBiasAtT2.Location = new System.Drawing.Point(469, 20);
            this.button_sampleGyroBiasAtT2.Name = "button_sampleGyroBiasAtT2";
            this.button_sampleGyroBiasAtT2.Size = new System.Drawing.Size(147, 23);
            this.button_sampleGyroBiasAtT2.TabIndex = 3;
            this.button_sampleGyroBiasAtT2.Text = "Sample Gyro. Bias @ T2";
            this.button_sampleGyroBiasAtT2.UseVisualStyleBackColor = true;
            this.button_sampleGyroBiasAtT2.Click += new System.EventHandler(this.button_sampleGyroBiasAtT2_Click);
            // 
            // button_sampleGyroBiasAtT1
            // 
            this.button_sampleGyroBiasAtT1.Location = new System.Drawing.Point(316, 20);
            this.button_sampleGyroBiasAtT1.Name = "button_sampleGyroBiasAtT1";
            this.button_sampleGyroBiasAtT1.Size = new System.Drawing.Size(147, 23);
            this.button_sampleGyroBiasAtT1.TabIndex = 2;
            this.button_sampleGyroBiasAtT1.Text = "Sample Gyro. Bias @ T1";
            this.button_sampleGyroBiasAtT1.UseVisualStyleBackColor = true;
            this.button_sampleGyroBiasAtT1.Click += new System.EventHandler(this.button_sampleGyroBiasAtT1_Click);
            // 
            // groupBox_general
            // 
            this.groupBox_general.Controls.Add(this.button_factoryReset);
            this.groupBox_general.Controls.Add(this.button_resetSleepTimer);
            this.groupBox_general.Controls.Add(this.button_sleep);
            this.groupBox_general.Controls.Add(this.button_reset);
            this.groupBox_general.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_general.Location = new System.Drawing.Point(3, 3);
            this.groupBox_general.Name = "groupBox_general";
            this.groupBox_general.Size = new System.Drawing.Size(826, 59);
            this.groupBox_general.TabIndex = 0;
            this.groupBox_general.TabStop = false;
            this.groupBox_general.Text = "General";
            // 
            // button_factoryReset
            // 
            this.button_factoryReset.Location = new System.Drawing.Point(10, 20);
            this.button_factoryReset.Name = "button_factoryReset";
            this.button_factoryReset.Size = new System.Drawing.Size(147, 23);
            this.button_factoryReset.TabIndex = 0;
            this.button_factoryReset.Text = "Factory Reset";
            this.button_factoryReset.UseVisualStyleBackColor = true;
            this.button_factoryReset.Click += new System.EventHandler(this.button_factoryReset_Click);
            // 
            // button_resetSleepTimer
            // 
            this.button_resetSleepTimer.Location = new System.Drawing.Point(469, 20);
            this.button_resetSleepTimer.Name = "button_resetSleepTimer";
            this.button_resetSleepTimer.Size = new System.Drawing.Size(147, 23);
            this.button_resetSleepTimer.TabIndex = 3;
            this.button_resetSleepTimer.Text = "Reset Sleep Timer";
            this.button_resetSleepTimer.UseVisualStyleBackColor = true;
            this.button_resetSleepTimer.Click += new System.EventHandler(this.button_resetSleepTimer_Click);
            // 
            // button_sleep
            // 
            this.button_sleep.Location = new System.Drawing.Point(316, 20);
            this.button_sleep.Name = "button_sleep";
            this.button_sleep.Size = new System.Drawing.Size(147, 23);
            this.button_sleep.TabIndex = 2;
            this.button_sleep.Text = "Sleep";
            this.button_sleep.UseVisualStyleBackColor = true;
            this.button_sleep.Click += new System.EventHandler(this.button_sleep_Click);
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(163, 20);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(147, 23);
            this.button_reset.TabIndex = 1;
            this.button_reset.Text = "Reset";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // tabPage_ViewSensorData
            // 
            this.tabPage_ViewSensorData.AutoScroll = true;
            this.tabPage_ViewSensorData.Controls.Add(this.groupBox_orienData);
            this.tabPage_ViewSensorData.Controls.Add(this.groupBox_sensorData);
            this.tabPage_ViewSensorData.Controls.Add(this.groupBox_battThermData);
            this.tabPage_ViewSensorData.Location = new System.Drawing.Point(4, 22);
            this.tabPage_ViewSensorData.Name = "tabPage_ViewSensorData";
            this.tabPage_ViewSensorData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ViewSensorData.Size = new System.Drawing.Size(832, 410);
            this.tabPage_ViewSensorData.TabIndex = 3;
            this.tabPage_ViewSensorData.Text = "View Sensor Data";
            this.tabPage_ViewSensorData.UseVisualStyleBackColor = true;
            // 
            // groupBox_orienData
            // 
            this.groupBox_orienData.Controls.Add(this.label_psi);
            this.groupBox_orienData.Controls.Add(this.label_theta);
            this.groupBox_orienData.Controls.Add(this.label_phi);
            this.groupBox_orienData.Controls.Add(this.label_eulerLegend);
            this.groupBox_orienData.Controls.Add(this.button_showEulerAngleGraph);
            this.groupBox_orienData.Controls.Add(this.button_show3Dcuboid);
            this.groupBox_orienData.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_orienData.Location = new System.Drawing.Point(3, 121);
            this.groupBox_orienData.Name = "groupBox_orienData";
            this.groupBox_orienData.Size = new System.Drawing.Size(826, 59);
            this.groupBox_orienData.TabIndex = 2;
            this.groupBox_orienData.TabStop = false;
            this.groupBox_orienData.Text = "Orientation Data";
            // 
            // label_psi
            // 
            this.label_psi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_psi.AutoSize = true;
            this.label_psi.ForeColor = System.Drawing.Color.Blue;
            this.label_psi.Location = new System.Drawing.Point(801, 24);
            this.label_psi.Name = "label_psi";
            this.label_psi.Size = new System.Drawing.Size(15, 13);
            this.label_psi.TabIndex = 45;
            this.label_psi.Text = "ψ";
            // 
            // label_theta
            // 
            this.label_theta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_theta.AutoSize = true;
            this.label_theta.ForeColor = System.Drawing.Color.Lime;
            this.label_theta.Location = new System.Drawing.Point(782, 24);
            this.label_theta.Name = "label_theta";
            this.label_theta.Size = new System.Drawing.Size(13, 13);
            this.label_theta.TabIndex = 44;
            this.label_theta.Text = "θ";
            // 
            // label_phi
            // 
            this.label_phi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_phi.AutoSize = true;
            this.label_phi.ForeColor = System.Drawing.Color.Red;
            this.label_phi.Location = new System.Drawing.Point(761, 24);
            this.label_phi.Name = "label_phi";
            this.label_phi.Size = new System.Drawing.Size(15, 13);
            this.label_phi.TabIndex = 43;
            this.label_phi.Text = "φ";
            // 
            // label_eulerLegend
            // 
            this.label_eulerLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_eulerLegend.AutoSize = true;
            this.label_eulerLegend.Location = new System.Drawing.Point(709, 24);
            this.label_eulerLegend.Name = "label_eulerLegend";
            this.label_eulerLegend.Size = new System.Drawing.Size(46, 13);
            this.label_eulerLegend.TabIndex = 42;
            this.label_eulerLegend.Text = "Legend:";
            // 
            // button_showEulerAngleGraph
            // 
            this.button_showEulerAngleGraph.Location = new System.Drawing.Point(163, 19);
            this.button_showEulerAngleGraph.Name = "button_showEulerAngleGraph";
            this.button_showEulerAngleGraph.Size = new System.Drawing.Size(147, 23);
            this.button_showEulerAngleGraph.TabIndex = 1;
            this.button_showEulerAngleGraph.Text = "Show Euler Angle Graph";
            this.button_showEulerAngleGraph.UseVisualStyleBackColor = true;
            this.button_showEulerAngleGraph.Click += new System.EventHandler(this.button_showEulerAngleGraph_Click);
            // 
            // button_show3Dcuboid
            // 
            this.button_show3Dcuboid.Location = new System.Drawing.Point(10, 20);
            this.button_show3Dcuboid.Name = "button_show3Dcuboid";
            this.button_show3Dcuboid.Size = new System.Drawing.Size(147, 23);
            this.button_show3Dcuboid.TabIndex = 0;
            this.button_show3Dcuboid.Text = "Show 3D Cuboid";
            this.button_show3Dcuboid.UseVisualStyleBackColor = true;
            this.button_show3Dcuboid.Click += new System.EventHandler(this.button_show3Dcuboid_Click);
            // 
            // groupBox_sensorData
            // 
            this.groupBox_sensorData.Controls.Add(this.label_legendZ);
            this.groupBox_sensorData.Controls.Add(this.label_legendY);
            this.groupBox_sensorData.Controls.Add(this.label_legendX);
            this.groupBox_sensorData.Controls.Add(this.label_sensorLegend);
            this.groupBox_sensorData.Controls.Add(this.button_showMagGraph);
            this.groupBox_sensorData.Controls.Add(this.button_showAccelGraph);
            this.groupBox_sensorData.Controls.Add(this.button_showGyroGraph);
            this.groupBox_sensorData.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_sensorData.Location = new System.Drawing.Point(3, 62);
            this.groupBox_sensorData.Name = "groupBox_sensorData";
            this.groupBox_sensorData.Size = new System.Drawing.Size(826, 59);
            this.groupBox_sensorData.TabIndex = 1;
            this.groupBox_sensorData.TabStop = false;
            this.groupBox_sensorData.Text = "Inertial/Magnetic Sensor Data";
            // 
            // label_legendZ
            // 
            this.label_legendZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_legendZ.AutoSize = true;
            this.label_legendZ.ForeColor = System.Drawing.Color.Blue;
            this.label_legendZ.Location = new System.Drawing.Point(802, 25);
            this.label_legendZ.Name = "label_legendZ";
            this.label_legendZ.Size = new System.Drawing.Size(14, 13);
            this.label_legendZ.TabIndex = 41;
            this.label_legendZ.Text = "Z";
            // 
            // label_legendY
            // 
            this.label_legendY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_legendY.AutoSize = true;
            this.label_legendY.ForeColor = System.Drawing.Color.Lime;
            this.label_legendY.Location = new System.Drawing.Point(782, 25);
            this.label_legendY.Name = "label_legendY";
            this.label_legendY.Size = new System.Drawing.Size(14, 13);
            this.label_legendY.TabIndex = 40;
            this.label_legendY.Text = "Y";
            // 
            // label_legendX
            // 
            this.label_legendX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_legendX.AutoSize = true;
            this.label_legendX.ForeColor = System.Drawing.Color.Red;
            this.label_legendX.Location = new System.Drawing.Point(762, 25);
            this.label_legendX.Name = "label_legendX";
            this.label_legendX.Size = new System.Drawing.Size(14, 13);
            this.label_legendX.TabIndex = 39;
            this.label_legendX.Text = "X";
            // 
            // label_sensorLegend
            // 
            this.label_sensorLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_sensorLegend.AutoSize = true;
            this.label_sensorLegend.Location = new System.Drawing.Point(710, 25);
            this.label_sensorLegend.Name = "label_sensorLegend";
            this.label_sensorLegend.Size = new System.Drawing.Size(46, 13);
            this.label_sensorLegend.TabIndex = 38;
            this.label_sensorLegend.Text = "Legend:";
            // 
            // button_showMagGraph
            // 
            this.button_showMagGraph.Location = new System.Drawing.Point(316, 20);
            this.button_showMagGraph.Name = "button_showMagGraph";
            this.button_showMagGraph.Size = new System.Drawing.Size(147, 23);
            this.button_showMagGraph.TabIndex = 2;
            this.button_showMagGraph.Text = "Show Magnetometer Graph";
            this.button_showMagGraph.UseVisualStyleBackColor = true;
            this.button_showMagGraph.Click += new System.EventHandler(this.button_showMagGraph_Click);
            // 
            // button_showAccelGraph
            // 
            this.button_showAccelGraph.Location = new System.Drawing.Point(163, 20);
            this.button_showAccelGraph.Name = "button_showAccelGraph";
            this.button_showAccelGraph.Size = new System.Drawing.Size(147, 23);
            this.button_showAccelGraph.TabIndex = 1;
            this.button_showAccelGraph.Text = "Show Accelerometer Graph";
            this.button_showAccelGraph.UseVisualStyleBackColor = true;
            this.button_showAccelGraph.Click += new System.EventHandler(this.button_showAccelGraph_Click);
            // 
            // button_showGyroGraph
            // 
            this.button_showGyroGraph.Location = new System.Drawing.Point(10, 20);
            this.button_showGyroGraph.Name = "button_showGyroGraph";
            this.button_showGyroGraph.Size = new System.Drawing.Size(147, 23);
            this.button_showGyroGraph.TabIndex = 0;
            this.button_showGyroGraph.Text = "Show Gyroscope Graph";
            this.button_showGyroGraph.UseVisualStyleBackColor = true;
            this.button_showGyroGraph.Click += new System.EventHandler(this.button_showGyroGraph_Click);
            // 
            // groupBox_battThermData
            // 
            this.groupBox_battThermData.Controls.Add(this.button_showBatteryGraph);
            this.groupBox_battThermData.Controls.Add(this.button_showThermGraph);
            this.groupBox_battThermData.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_battThermData.Location = new System.Drawing.Point(3, 3);
            this.groupBox_battThermData.Name = "groupBox_battThermData";
            this.groupBox_battThermData.Size = new System.Drawing.Size(826, 59);
            this.groupBox_battThermData.TabIndex = 0;
            this.groupBox_battThermData.TabStop = false;
            this.groupBox_battThermData.Text = "Battery And Thermometer Data";
            // 
            // button_showBatteryGraph
            // 
            this.button_showBatteryGraph.Location = new System.Drawing.Point(10, 20);
            this.button_showBatteryGraph.Name = "button_showBatteryGraph";
            this.button_showBatteryGraph.Size = new System.Drawing.Size(147, 23);
            this.button_showBatteryGraph.TabIndex = 0;
            this.button_showBatteryGraph.Text = "Show Battery Graph";
            this.button_showBatteryGraph.UseVisualStyleBackColor = true;
            this.button_showBatteryGraph.Click += new System.EventHandler(this.button_showBatteryGraph_Click);
            // 
            // button_showThermGraph
            // 
            this.button_showThermGraph.Location = new System.Drawing.Point(163, 20);
            this.button_showThermGraph.Name = "button_showThermGraph";
            this.button_showThermGraph.Size = new System.Drawing.Size(147, 23);
            this.button_showThermGraph.TabIndex = 1;
            this.button_showThermGraph.Text = "Show Thermometer Graph";
            this.button_showThermGraph.UseVisualStyleBackColor = true;
            this.button_showThermGraph.Click += new System.EventHandler(this.button_showThermGraph_Click);
            // 
            // tabPage_auxillaryPort
            // 
            this.tabPage_auxillaryPort.Controls.Add(this.groupBox_ADXL345bus);
            this.tabPage_auxillaryPort.Controls.Add(this.groupBox_pwmOutput);
            this.tabPage_auxillaryPort.Controls.Add(this.groupBox_analogueInput);
            this.tabPage_auxillaryPort.Controls.Add(this.groupBox_digitalIO);
            this.tabPage_auxillaryPort.Location = new System.Drawing.Point(4, 22);
            this.tabPage_auxillaryPort.Name = "tabPage_auxillaryPort";
            this.tabPage_auxillaryPort.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_auxillaryPort.Size = new System.Drawing.Size(832, 410);
            this.tabPage_auxillaryPort.TabIndex = 14;
            this.tabPage_auxillaryPort.Text = "Auxillary Port";
            this.tabPage_auxillaryPort.UseVisualStyleBackColor = true;
            // 
            // groupBox_ADXL345bus
            // 
            this.groupBox_ADXL345bus.Controls.Add(this.button_showADXL345Dgraph);
            this.groupBox_ADXL345bus.Controls.Add(this.button_showADXL345Cgraph);
            this.groupBox_ADXL345bus.Controls.Add(this.button_showADXL345Bgraph);
            this.groupBox_ADXL345bus.Controls.Add(this.button_showADXL345Agraph);
            this.groupBox_ADXL345bus.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_ADXL345bus.Location = new System.Drawing.Point(3, 180);
            this.groupBox_ADXL345bus.Name = "groupBox_ADXL345bus";
            this.groupBox_ADXL345bus.Size = new System.Drawing.Size(826, 59);
            this.groupBox_ADXL345bus.TabIndex = 3;
            this.groupBox_ADXL345bus.TabStop = false;
            this.groupBox_ADXL345bus.Text = "AXDL345 Bus";
            // 
            // button_showADXL345Dgraph
            // 
            this.button_showADXL345Dgraph.Location = new System.Drawing.Point(469, 20);
            this.button_showADXL345Dgraph.Name = "button_showADXL345Dgraph";
            this.button_showADXL345Dgraph.Size = new System.Drawing.Size(147, 23);
            this.button_showADXL345Dgraph.TabIndex = 3;
            this.button_showADXL345Dgraph.Text = "Show ADXL345 D Graph";
            this.button_showADXL345Dgraph.UseVisualStyleBackColor = true;
            this.button_showADXL345Dgraph.Click += new System.EventHandler(this.button_showADXL345Dgraph_Click);
            // 
            // button_showADXL345Cgraph
            // 
            this.button_showADXL345Cgraph.Location = new System.Drawing.Point(316, 20);
            this.button_showADXL345Cgraph.Name = "button_showADXL345Cgraph";
            this.button_showADXL345Cgraph.Size = new System.Drawing.Size(147, 23);
            this.button_showADXL345Cgraph.TabIndex = 2;
            this.button_showADXL345Cgraph.Text = "Show ADXL345 C Graph";
            this.button_showADXL345Cgraph.UseVisualStyleBackColor = true;
            this.button_showADXL345Cgraph.Click += new System.EventHandler(this.button_showADXL345Cgraph_Click);
            // 
            // button_showADXL345Bgraph
            // 
            this.button_showADXL345Bgraph.Location = new System.Drawing.Point(163, 20);
            this.button_showADXL345Bgraph.Name = "button_showADXL345Bgraph";
            this.button_showADXL345Bgraph.Size = new System.Drawing.Size(147, 23);
            this.button_showADXL345Bgraph.TabIndex = 1;
            this.button_showADXL345Bgraph.Text = "Show ADXL345 B Graph";
            this.button_showADXL345Bgraph.UseVisualStyleBackColor = true;
            this.button_showADXL345Bgraph.Click += new System.EventHandler(this.button_showADXL345Bgraph_Click);
            // 
            // button_showADXL345Agraph
            // 
            this.button_showADXL345Agraph.Location = new System.Drawing.Point(10, 20);
            this.button_showADXL345Agraph.Name = "button_showADXL345Agraph";
            this.button_showADXL345Agraph.Size = new System.Drawing.Size(147, 23);
            this.button_showADXL345Agraph.TabIndex = 0;
            this.button_showADXL345Agraph.Text = "Show ADXL345 A Graph";
            this.button_showADXL345Agraph.UseVisualStyleBackColor = true;
            this.button_showADXL345Agraph.Click += new System.EventHandler(this.button_showADXL345Agraph_Click);
            // 
            // groupBox_pwmOutput
            // 
            this.groupBox_pwmOutput.Controls.Add(this.button_showPWMoutputPanel);
            this.groupBox_pwmOutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_pwmOutput.Location = new System.Drawing.Point(3, 121);
            this.groupBox_pwmOutput.Name = "groupBox_pwmOutput";
            this.groupBox_pwmOutput.Size = new System.Drawing.Size(826, 59);
            this.groupBox_pwmOutput.TabIndex = 2;
            this.groupBox_pwmOutput.TabStop = false;
            this.groupBox_pwmOutput.Text = "PWM Output";
            // 
            // button_showPWMoutputPanel
            // 
            this.button_showPWMoutputPanel.Location = new System.Drawing.Point(10, 20);
            this.button_showPWMoutputPanel.Name = "button_showPWMoutputPanel";
            this.button_showPWMoutputPanel.Size = new System.Drawing.Size(147, 23);
            this.button_showPWMoutputPanel.TabIndex = 0;
            this.button_showPWMoutputPanel.Text = "Show PWM Output Panel";
            this.button_showPWMoutputPanel.UseVisualStyleBackColor = true;
            this.button_showPWMoutputPanel.Click += new System.EventHandler(this.button_showPWMoutputPanel_Click);
            // 
            // groupBox_analogueInput
            // 
            this.groupBox_analogueInput.Controls.Add(this.button_showAX6andAX7graph);
            this.groupBox_analogueInput.Controls.Add(this.button_showAX4andAX5graph);
            this.groupBox_analogueInput.Controls.Add(this.button_showAX2andAX3graph);
            this.groupBox_analogueInput.Controls.Add(this.button_showAX0andAX1graph);
            this.groupBox_analogueInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_analogueInput.Location = new System.Drawing.Point(3, 62);
            this.groupBox_analogueInput.Name = "groupBox_analogueInput";
            this.groupBox_analogueInput.Size = new System.Drawing.Size(826, 59);
            this.groupBox_analogueInput.TabIndex = 1;
            this.groupBox_analogueInput.TabStop = false;
            this.groupBox_analogueInput.Text = "Analogue Input";
            // 
            // button_showAX6andAX7graph
            // 
            this.button_showAX6andAX7graph.Location = new System.Drawing.Point(469, 20);
            this.button_showAX6andAX7graph.Name = "button_showAX6andAX7graph";
            this.button_showAX6andAX7graph.Size = new System.Drawing.Size(147, 23);
            this.button_showAX6andAX7graph.TabIndex = 3;
            this.button_showAX6andAX7graph.Text = "Show AX6 and AX7 Graph";
            this.button_showAX6andAX7graph.UseVisualStyleBackColor = true;
            this.button_showAX6andAX7graph.Click += new System.EventHandler(this.button_showAX6andAX7graph_Click);
            // 
            // button_showAX4andAX5graph
            // 
            this.button_showAX4andAX5graph.Location = new System.Drawing.Point(316, 20);
            this.button_showAX4andAX5graph.Name = "button_showAX4andAX5graph";
            this.button_showAX4andAX5graph.Size = new System.Drawing.Size(147, 23);
            this.button_showAX4andAX5graph.TabIndex = 2;
            this.button_showAX4andAX5graph.Text = "Show AX4 and AX5 Graph";
            this.button_showAX4andAX5graph.UseVisualStyleBackColor = true;
            this.button_showAX4andAX5graph.Click += new System.EventHandler(this.button_showAX4andAX5graph_Click);
            // 
            // button_showAX2andAX3graph
            // 
            this.button_showAX2andAX3graph.Location = new System.Drawing.Point(163, 20);
            this.button_showAX2andAX3graph.Name = "button_showAX2andAX3graph";
            this.button_showAX2andAX3graph.Size = new System.Drawing.Size(147, 23);
            this.button_showAX2andAX3graph.TabIndex = 1;
            this.button_showAX2andAX3graph.Text = "Show AX2 and AX3 Graph";
            this.button_showAX2andAX3graph.UseVisualStyleBackColor = true;
            this.button_showAX2andAX3graph.Click += new System.EventHandler(this.button_showAX2andAX3graph_Click);
            // 
            // button_showAX0andAX1graph
            // 
            this.button_showAX0andAX1graph.Location = new System.Drawing.Point(10, 20);
            this.button_showAX0andAX1graph.Name = "button_showAX0andAX1graph";
            this.button_showAX0andAX1graph.Size = new System.Drawing.Size(147, 23);
            this.button_showAX0andAX1graph.TabIndex = 0;
            this.button_showAX0andAX1graph.Text = "Show AX0 and AX1 Graph";
            this.button_showAX0andAX1graph.UseVisualStyleBackColor = true;
            this.button_showAX0andAX1graph.Click += new System.EventHandler(this.button_showAX0andAX1graph_Click);
            // 
            // groupBox_digitalIO
            // 
            this.groupBox_digitalIO.Controls.Add(this.button_showDigitalIOpanel);
            this.groupBox_digitalIO.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_digitalIO.Location = new System.Drawing.Point(3, 3);
            this.groupBox_digitalIO.Name = "groupBox_digitalIO";
            this.groupBox_digitalIO.Size = new System.Drawing.Size(826, 59);
            this.groupBox_digitalIO.TabIndex = 0;
            this.groupBox_digitalIO.TabStop = false;
            this.groupBox_digitalIO.Text = "Digital I/O";
            // 
            // button_showDigitalIOpanel
            // 
            this.button_showDigitalIOpanel.Location = new System.Drawing.Point(10, 20);
            this.button_showDigitalIOpanel.Name = "button_showDigitalIOpanel";
            this.button_showDigitalIOpanel.Size = new System.Drawing.Size(147, 23);
            this.button_showDigitalIOpanel.TabIndex = 0;
            this.button_showDigitalIOpanel.Text = "Show Digital I/O Panel";
            this.button_showDigitalIOpanel.UseVisualStyleBackColor = true;
            this.button_showDigitalIOpanel.Click += new System.EventHandler(this.button_showDigitalIOpanel_Click);
            // 
            // tabPage_dataLogger
            // 
            this.tabPage_dataLogger.Controls.Add(this.groupBox_logReceivedDataToFile);
            this.tabPage_dataLogger.Location = new System.Drawing.Point(4, 22);
            this.tabPage_dataLogger.Name = "tabPage_dataLogger";
            this.tabPage_dataLogger.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_dataLogger.Size = new System.Drawing.Size(832, 410);
            this.tabPage_dataLogger.TabIndex = 13;
            this.tabPage_dataLogger.Text = "Data Logger";
            this.tabPage_dataLogger.UseVisualStyleBackColor = true;
            // 
            // groupBox_logReceivedDataToFile
            // 
            this.groupBox_logReceivedDataToFile.Controls.Add(this.button_dataLoggerFilePathBrowse);
            this.groupBox_logReceivedDataToFile.Controls.Add(this.label_dataLoggerFilePath);
            this.groupBox_logReceivedDataToFile.Controls.Add(this.textBox_dataLoggerFilePath);
            this.groupBox_logReceivedDataToFile.Controls.Add(this.button_dataLoggerStart);
            this.groupBox_logReceivedDataToFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_logReceivedDataToFile.Location = new System.Drawing.Point(3, 3);
            this.groupBox_logReceivedDataToFile.Name = "groupBox_logReceivedDataToFile";
            this.groupBox_logReceivedDataToFile.Size = new System.Drawing.Size(826, 60);
            this.groupBox_logReceivedDataToFile.TabIndex = 0;
            this.groupBox_logReceivedDataToFile.TabStop = false;
            this.groupBox_logReceivedDataToFile.Text = "Log Received Data To File";
            // 
            // button_dataLoggerFilePathBrowse
            // 
            this.button_dataLoggerFilePathBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_dataLoggerFilePathBrowse.Location = new System.Drawing.Point(624, 22);
            this.button_dataLoggerFilePathBrowse.Name = "button_dataLoggerFilePathBrowse";
            this.button_dataLoggerFilePathBrowse.Size = new System.Drawing.Size(95, 23);
            this.button_dataLoggerFilePathBrowse.TabIndex = 1;
            this.button_dataLoggerFilePathBrowse.Text = "Browse...";
            this.button_dataLoggerFilePathBrowse.UseVisualStyleBackColor = true;
            this.button_dataLoggerFilePathBrowse.Click += new System.EventHandler(this.button_dataLoggerFilePathBrowse_Click);
            // 
            // label_dataLoggerFilePath
            // 
            this.label_dataLoggerFilePath.AutoSize = true;
            this.label_dataLoggerFilePath.Location = new System.Drawing.Point(8, 27);
            this.label_dataLoggerFilePath.Name = "label_dataLoggerFilePath";
            this.label_dataLoggerFilePath.Size = new System.Drawing.Size(50, 13);
            this.label_dataLoggerFilePath.TabIndex = 47;
            this.label_dataLoggerFilePath.Text = "File path:";
            // 
            // textBox_dataLoggerFilePath
            // 
            this.textBox_dataLoggerFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_dataLoggerFilePath.Location = new System.Drawing.Point(64, 24);
            this.textBox_dataLoggerFilePath.Name = "textBox_dataLoggerFilePath";
            this.textBox_dataLoggerFilePath.Size = new System.Drawing.Size(554, 20);
            this.textBox_dataLoggerFilePath.TabIndex = 0;
            // 
            // button_dataLoggerStart
            // 
            this.button_dataLoggerStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_dataLoggerStart.Location = new System.Drawing.Point(725, 22);
            this.button_dataLoggerStart.Name = "button_dataLoggerStart";
            this.button_dataLoggerStart.Size = new System.Drawing.Size(95, 23);
            this.button_dataLoggerStart.TabIndex = 2;
            this.button_dataLoggerStart.Text = "Start Logging";
            this.button_dataLoggerStart.UseVisualStyleBackColor = true;
            this.button_dataLoggerStart.Click += new System.EventHandler(this.button_dataLoggerStart_Click);
            // 
            // tabPage_SDcard
            // 
            this.tabPage_SDcard.Controls.Add(this.groupBox_convertBinaryFile);
            this.tabPage_SDcard.Location = new System.Drawing.Point(4, 22);
            this.tabPage_SDcard.Name = "tabPage_SDcard";
            this.tabPage_SDcard.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SDcard.Size = new System.Drawing.Size(832, 410);
            this.tabPage_SDcard.TabIndex = 12;
            this.tabPage_SDcard.Text = "SD Card";
            this.tabPage_SDcard.UseVisualStyleBackColor = true;
            // 
            // groupBox_convertBinaryFile
            // 
            this.groupBox_convertBinaryFile.Controls.Add(this.button_convertBinaryFileConvertBrowse);
            this.groupBox_convertBinaryFile.Controls.Add(this.labelconvertBinaryFileFilePath);
            this.groupBox_convertBinaryFile.Controls.Add(this.textBox_convertBinaryFileFilePath);
            this.groupBox_convertBinaryFile.Controls.Add(this.button_convertBinaryFileConvert);
            this.groupBox_convertBinaryFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_convertBinaryFile.Location = new System.Drawing.Point(3, 3);
            this.groupBox_convertBinaryFile.Name = "groupBox_convertBinaryFile";
            this.groupBox_convertBinaryFile.Size = new System.Drawing.Size(826, 60);
            this.groupBox_convertBinaryFile.TabIndex = 0;
            this.groupBox_convertBinaryFile.TabStop = false;
            this.groupBox_convertBinaryFile.Text = "Convert Binary File";
            // 
            // button_convertBinaryFileConvertBrowse
            // 
            this.button_convertBinaryFileConvertBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_convertBinaryFileConvertBrowse.Location = new System.Drawing.Point(624, 22);
            this.button_convertBinaryFileConvertBrowse.Name = "button_convertBinaryFileConvertBrowse";
            this.button_convertBinaryFileConvertBrowse.Size = new System.Drawing.Size(95, 23);
            this.button_convertBinaryFileConvertBrowse.TabIndex = 1;
            this.button_convertBinaryFileConvertBrowse.Text = "Browse...";
            this.button_convertBinaryFileConvertBrowse.UseVisualStyleBackColor = true;
            this.button_convertBinaryFileConvertBrowse.Click += new System.EventHandler(this.button_convertBinaryFileConvertBrowse_Click);
            // 
            // labelconvertBinaryFileFilePath
            // 
            this.labelconvertBinaryFileFilePath.AutoSize = true;
            this.labelconvertBinaryFileFilePath.Location = new System.Drawing.Point(8, 27);
            this.labelconvertBinaryFileFilePath.Name = "labelconvertBinaryFileFilePath";
            this.labelconvertBinaryFileFilePath.Size = new System.Drawing.Size(50, 13);
            this.labelconvertBinaryFileFilePath.TabIndex = 47;
            this.labelconvertBinaryFileFilePath.Text = "File path:";
            // 
            // textBox_convertBinaryFileFilePath
            // 
            this.textBox_convertBinaryFileFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_convertBinaryFileFilePath.Location = new System.Drawing.Point(64, 24);
            this.textBox_convertBinaryFileFilePath.Name = "textBox_convertBinaryFileFilePath";
            this.textBox_convertBinaryFileFilePath.Size = new System.Drawing.Size(554, 20);
            this.textBox_convertBinaryFileFilePath.TabIndex = 0;
            // 
            // button_convertBinaryFileConvert
            // 
            this.button_convertBinaryFileConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_convertBinaryFileConvert.Location = new System.Drawing.Point(725, 22);
            this.button_convertBinaryFileConvert.Name = "button_convertBinaryFileConvert";
            this.button_convertBinaryFileConvert.Size = new System.Drawing.Size(95, 23);
            this.button_convertBinaryFileConvert.TabIndex = 2;
            this.button_convertBinaryFileConvert.Text = "Convert";
            this.button_convertBinaryFileConvert.UseVisualStyleBackColor = true;
            this.button_convertBinaryFileConvert.Click += new System.EventHandler(this.button_convertBinaryFileConvert_Click);
            // 
            // tabPage_hardIronCalibration
            // 
            this.tabPage_hardIronCalibration.Controls.Add(this.groupBox_step3hardIronCalibrationAlgorithm);
            this.tabPage_hardIronCalibration.Controls.Add(this.groupBox_step2collectHardIronCalibrationDataSet);
            this.tabPage_hardIronCalibration.Controls.Add(this.groupBox_step1ClearHardIronBiasRegisters);
            this.tabPage_hardIronCalibration.Location = new System.Drawing.Point(4, 22);
            this.tabPage_hardIronCalibration.Name = "tabPage_hardIronCalibration";
            this.tabPage_hardIronCalibration.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_hardIronCalibration.Size = new System.Drawing.Size(832, 410);
            this.tabPage_hardIronCalibration.TabIndex = 10;
            this.tabPage_hardIronCalibration.Text = "Hard-Iron Calibration";
            this.tabPage_hardIronCalibration.UseVisualStyleBackColor = true;
            // 
            // groupBox_step3hardIronCalibrationAlgorithm
            // 
            this.groupBox_step3hardIronCalibrationAlgorithm.Controls.Add(this.button_hardIronCalBrowse);
            this.groupBox_step3hardIronCalibrationAlgorithm.Controls.Add(this.label_hardIronCalFilePath);
            this.groupBox_step3hardIronCalibrationAlgorithm.Controls.Add(this.textBox_hardIronCalFilePath);
            this.groupBox_step3hardIronCalibrationAlgorithm.Controls.Add(this.button_hardIronCalRun);
            this.groupBox_step3hardIronCalibrationAlgorithm.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_step3hardIronCalibrationAlgorithm.Location = new System.Drawing.Point(3, 123);
            this.groupBox_step3hardIronCalibrationAlgorithm.Name = "groupBox_step3hardIronCalibrationAlgorithm";
            this.groupBox_step3hardIronCalibrationAlgorithm.Size = new System.Drawing.Size(826, 60);
            this.groupBox_step3hardIronCalibrationAlgorithm.TabIndex = 2;
            this.groupBox_step3hardIronCalibrationAlgorithm.TabStop = false;
            this.groupBox_step3hardIronCalibrationAlgorithm.Text = "Step 3 - Run Hard-Iron Calibration Algorithm";
            // 
            // button_hardIronCalBrowse
            // 
            this.button_hardIronCalBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_hardIronCalBrowse.Location = new System.Drawing.Point(624, 22);
            this.button_hardIronCalBrowse.Name = "button_hardIronCalBrowse";
            this.button_hardIronCalBrowse.Size = new System.Drawing.Size(95, 23);
            this.button_hardIronCalBrowse.TabIndex = 1;
            this.button_hardIronCalBrowse.Text = "Browse...";
            this.button_hardIronCalBrowse.UseVisualStyleBackColor = true;
            this.button_hardIronCalBrowse.Click += new System.EventHandler(this.button_hardIronCalBrowse_Click);
            // 
            // label_hardIronCalFilePath
            // 
            this.label_hardIronCalFilePath.AutoSize = true;
            this.label_hardIronCalFilePath.Location = new System.Drawing.Point(8, 27);
            this.label_hardIronCalFilePath.Name = "label_hardIronCalFilePath";
            this.label_hardIronCalFilePath.Size = new System.Drawing.Size(50, 13);
            this.label_hardIronCalFilePath.TabIndex = 47;
            this.label_hardIronCalFilePath.Text = "File path:";
            // 
            // textBox_hardIronCalFilePath
            // 
            this.textBox_hardIronCalFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_hardIronCalFilePath.Location = new System.Drawing.Point(64, 24);
            this.textBox_hardIronCalFilePath.Name = "textBox_hardIronCalFilePath";
            this.textBox_hardIronCalFilePath.Size = new System.Drawing.Size(554, 20);
            this.textBox_hardIronCalFilePath.TabIndex = 0;
            // 
            // button_hardIronCalRun
            // 
            this.button_hardIronCalRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_hardIronCalRun.Location = new System.Drawing.Point(725, 22);
            this.button_hardIronCalRun.Name = "button_hardIronCalRun";
            this.button_hardIronCalRun.Size = new System.Drawing.Size(95, 23);
            this.button_hardIronCalRun.TabIndex = 2;
            this.button_hardIronCalRun.Text = "Run";
            this.button_hardIronCalRun.UseVisualStyleBackColor = true;
            this.button_hardIronCalRun.Click += new System.EventHandler(this.button_hardIronCalRun_Click);
            // 
            // groupBox_step2collectHardIronCalibrationDataSet
            // 
            this.groupBox_step2collectHardIronCalibrationDataSet.Controls.Add(this.button_collectHardIronCalDatasetBrowse);
            this.groupBox_step2collectHardIronCalibrationDataSet.Controls.Add(this.label_collectHardIronCalDatasetFilePath);
            this.groupBox_step2collectHardIronCalibrationDataSet.Controls.Add(this.textBox_collectHardIronCalDatasetFilePath);
            this.groupBox_step2collectHardIronCalibrationDataSet.Controls.Add(this.button_collectHardIronCalDatasetStartLogging);
            this.groupBox_step2collectHardIronCalibrationDataSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_step2collectHardIronCalibrationDataSet.Location = new System.Drawing.Point(3, 63);
            this.groupBox_step2collectHardIronCalibrationDataSet.Name = "groupBox_step2collectHardIronCalibrationDataSet";
            this.groupBox_step2collectHardIronCalibrationDataSet.Size = new System.Drawing.Size(826, 60);
            this.groupBox_step2collectHardIronCalibrationDataSet.TabIndex = 1;
            this.groupBox_step2collectHardIronCalibrationDataSet.TabStop = false;
            this.groupBox_step2collectHardIronCalibrationDataSet.Text = "Step 2 - Collect Hard-Iron Calibration Dataset";
            // 
            // button_collectHardIronCalDatasetBrowse
            // 
            this.button_collectHardIronCalDatasetBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_collectHardIronCalDatasetBrowse.Location = new System.Drawing.Point(624, 22);
            this.button_collectHardIronCalDatasetBrowse.Name = "button_collectHardIronCalDatasetBrowse";
            this.button_collectHardIronCalDatasetBrowse.Size = new System.Drawing.Size(95, 23);
            this.button_collectHardIronCalDatasetBrowse.TabIndex = 1;
            this.button_collectHardIronCalDatasetBrowse.Text = "Browse...";
            this.button_collectHardIronCalDatasetBrowse.UseVisualStyleBackColor = true;
            this.button_collectHardIronCalDatasetBrowse.Click += new System.EventHandler(this.buttonCollectHardIronCalDatasetBrowse_Click);
            // 
            // label_collectHardIronCalDatasetFilePath
            // 
            this.label_collectHardIronCalDatasetFilePath.AutoSize = true;
            this.label_collectHardIronCalDatasetFilePath.Location = new System.Drawing.Point(8, 27);
            this.label_collectHardIronCalDatasetFilePath.Name = "label_collectHardIronCalDatasetFilePath";
            this.label_collectHardIronCalDatasetFilePath.Size = new System.Drawing.Size(50, 13);
            this.label_collectHardIronCalDatasetFilePath.TabIndex = 51;
            this.label_collectHardIronCalDatasetFilePath.Text = "File path:";
            // 
            // textBox_collectHardIronCalDatasetFilePath
            // 
            this.textBox_collectHardIronCalDatasetFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_collectHardIronCalDatasetFilePath.Location = new System.Drawing.Point(63, 24);
            this.textBox_collectHardIronCalDatasetFilePath.Name = "textBox_collectHardIronCalDatasetFilePath";
            this.textBox_collectHardIronCalDatasetFilePath.Size = new System.Drawing.Size(554, 20);
            this.textBox_collectHardIronCalDatasetFilePath.TabIndex = 0;
            this.textBox_collectHardIronCalDatasetFilePath.TextChanged += new System.EventHandler(this.textBox_collectHardIronCalDatasetFilePath_TextChanged);
            // 
            // button_collectHardIronCalDatasetStartLogging
            // 
            this.button_collectHardIronCalDatasetStartLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_collectHardIronCalDatasetStartLogging.Location = new System.Drawing.Point(725, 22);
            this.button_collectHardIronCalDatasetStartLogging.Name = "button_collectHardIronCalDatasetStartLogging";
            this.button_collectHardIronCalDatasetStartLogging.Size = new System.Drawing.Size(95, 23);
            this.button_collectHardIronCalDatasetStartLogging.TabIndex = 2;
            this.button_collectHardIronCalDatasetStartLogging.Text = "Start Logging";
            this.button_collectHardIronCalDatasetStartLogging.UseVisualStyleBackColor = true;
            this.button_collectHardIronCalDatasetStartLogging.Click += new System.EventHandler(this.button_collectHardIronCalDatasetStartLogging_Click);
            // 
            // groupBox_step1ClearHardIronBiasRegisters
            // 
            this.groupBox_step1ClearHardIronBiasRegisters.Controls.Add(this.button_clearHardIronRegisters);
            this.groupBox_step1ClearHardIronBiasRegisters.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_step1ClearHardIronBiasRegisters.Location = new System.Drawing.Point(3, 3);
            this.groupBox_step1ClearHardIronBiasRegisters.Name = "groupBox_step1ClearHardIronBiasRegisters";
            this.groupBox_step1ClearHardIronBiasRegisters.Size = new System.Drawing.Size(826, 60);
            this.groupBox_step1ClearHardIronBiasRegisters.TabIndex = 0;
            this.groupBox_step1ClearHardIronBiasRegisters.TabStop = false;
            this.groupBox_step1ClearHardIronBiasRegisters.Text = "Step 1 - Clear Hard-Iron Bias Registers";
            // 
            // button_clearHardIronRegisters
            // 
            this.button_clearHardIronRegisters.Location = new System.Drawing.Point(11, 22);
            this.button_clearHardIronRegisters.Name = "button_clearHardIronRegisters";
            this.button_clearHardIronRegisters.Size = new System.Drawing.Size(147, 23);
            this.button_clearHardIronRegisters.TabIndex = 0;
            this.button_clearHardIronRegisters.Text = "Clear Hard-Iron Regsiters";
            this.button_clearHardIronRegisters.UseVisualStyleBackColor = true;
            this.button_clearHardIronRegisters.Click += new System.EventHandler(this.button_clearHardIronRegisters_Click);
            // 
            // tabPage_uploadFirmware
            // 
            this.tabPage_uploadFirmware.AutoScroll = true;
            this.tabPage_uploadFirmware.Controls.Add(this.groupBox_bootloader);
            this.tabPage_uploadFirmware.Location = new System.Drawing.Point(4, 22);
            this.tabPage_uploadFirmware.Name = "tabPage_uploadFirmware";
            this.tabPage_uploadFirmware.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_uploadFirmware.Size = new System.Drawing.Size(832, 410);
            this.tabPage_uploadFirmware.TabIndex = 5;
            this.tabPage_uploadFirmware.Text = "Upload Firmware";
            this.tabPage_uploadFirmware.UseVisualStyleBackColor = true;
            // 
            // groupBox_bootloader
            // 
            this.groupBox_bootloader.Controls.Add(this.button_bootloaderBrowse);
            this.groupBox_bootloader.Controls.Add(this.label_bootloaderFilePath);
            this.groupBox_bootloader.Controls.Add(this.textBox_bootloaderFilePath);
            this.groupBox_bootloader.Controls.Add(this.button_bootloaderUpload);
            this.groupBox_bootloader.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_bootloader.Location = new System.Drawing.Point(3, 3);
            this.groupBox_bootloader.Name = "groupBox_bootloader";
            this.groupBox_bootloader.Size = new System.Drawing.Size(826, 60);
            this.groupBox_bootloader.TabIndex = 0;
            this.groupBox_bootloader.TabStop = false;
            this.groupBox_bootloader.Text = "Bootloader";
            // 
            // button_bootloaderBrowse
            // 
            this.button_bootloaderBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_bootloaderBrowse.Location = new System.Drawing.Point(624, 22);
            this.button_bootloaderBrowse.Name = "button_bootloaderBrowse";
            this.button_bootloaderBrowse.Size = new System.Drawing.Size(95, 23);
            this.button_bootloaderBrowse.TabIndex = 1;
            this.button_bootloaderBrowse.Text = "Browse...";
            this.button_bootloaderBrowse.UseVisualStyleBackColor = true;
            this.button_bootloaderBrowse.Click += new System.EventHandler(this.button_bootloaderBrowse_Click);
            // 
            // label_bootloaderFilePath
            // 
            this.label_bootloaderFilePath.AutoSize = true;
            this.label_bootloaderFilePath.Location = new System.Drawing.Point(8, 27);
            this.label_bootloaderFilePath.Name = "label_bootloaderFilePath";
            this.label_bootloaderFilePath.Size = new System.Drawing.Size(50, 13);
            this.label_bootloaderFilePath.TabIndex = 47;
            this.label_bootloaderFilePath.Text = "File path:";
            // 
            // textBox_bootloaderFilePath
            // 
            this.textBox_bootloaderFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_bootloaderFilePath.Location = new System.Drawing.Point(64, 24);
            this.textBox_bootloaderFilePath.Name = "textBox_bootloaderFilePath";
            this.textBox_bootloaderFilePath.Size = new System.Drawing.Size(554, 20);
            this.textBox_bootloaderFilePath.TabIndex = 0;
            // 
            // button_bootloaderUpload
            // 
            this.button_bootloaderUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_bootloaderUpload.Location = new System.Drawing.Point(725, 22);
            this.button_bootloaderUpload.Name = "button_bootloaderUpload";
            this.button_bootloaderUpload.Size = new System.Drawing.Size(95, 23);
            this.button_bootloaderUpload.TabIndex = 2;
            this.button_bootloaderUpload.Text = "Upload";
            this.button_bootloaderUpload.UseVisualStyleBackColor = true;
            this.button_bootloaderUpload.Click += new System.EventHandler(this.button_bootloaderUpload_Click);
            // 
            // tabPage_about
            // 
            this.tabPage_about.AutoScroll = true;
            this.tabPage_about.Controls.Add(this.label_forLatest);
            this.tabPage_about.Controls.Add(this.label_check);
            this.tabPage_about.Controls.Add(this.pictureBox_logo);
            this.tabPage_about.Controls.Add(this.label_GUIversionNum);
            this.tabPage_about.Controls.Add(this.label_APIversionNum);
            this.tabPage_about.Controls.Add(this.label_compatibleFirmwareVersionNums);
            this.tabPage_about.Controls.Add(this.linkLabel_www);
            this.tabPage_about.Controls.Add(this.label_compatibleFirmwareVersions);
            this.tabPage_about.Controls.Add(this.label_APIversion);
            this.tabPage_about.Controls.Add(this.label_GUIversion);
            this.tabPage_about.Location = new System.Drawing.Point(4, 22);
            this.tabPage_about.Name = "tabPage_about";
            this.tabPage_about.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_about.Size = new System.Drawing.Size(832, 410);
            this.tabPage_about.TabIndex = 2;
            this.tabPage_about.Text = "About";
            this.tabPage_about.UseVisualStyleBackColor = true;
            // 
            // label_forLatest
            // 
            this.label_forLatest.AutoSize = true;
            this.label_forLatest.Location = new System.Drawing.Point(120, 167);
            this.label_forLatest.Name = "label_forLatest";
            this.label_forLatest.Size = new System.Drawing.Size(289, 13);
            this.label_forLatest.TabIndex = 35;
            this.label_forLatest.Text = " for latest versions of software, firmware and documentation.";
            // 
            // label_check
            // 
            this.label_check.AutoSize = true;
            this.label_check.Location = new System.Drawing.Point(8, 167);
            this.label_check.Name = "label_check";
            this.label_check.Size = new System.Drawing.Size(38, 13);
            this.label_check.TabIndex = 34;
            this.label_check.Text = "Check";
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_logo.Image")));
            this.pictureBox_logo.Location = new System.Drawing.Point(8, 6);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(249, 50);
            this.pictureBox_logo.TabIndex = 33;
            this.pictureBox_logo.TabStop = false;
            // 
            // label_GUIversionNum
            // 
            this.label_GUIversionNum.AutoSize = true;
            this.label_GUIversionNum.Location = new System.Drawing.Point(160, 85);
            this.label_GUIversionNum.Name = "label_GUIversionNum";
            this.label_GUIversionNum.Size = new System.Drawing.Size(14, 13);
            this.label_GUIversionNum.TabIndex = 32;
            this.label_GUIversionNum.Text = "#";
            // 
            // label_APIversionNum
            // 
            this.label_APIversionNum.AutoSize = true;
            this.label_APIversionNum.Location = new System.Drawing.Point(160, 105);
            this.label_APIversionNum.Name = "label_APIversionNum";
            this.label_APIversionNum.Size = new System.Drawing.Size(14, 13);
            this.label_APIversionNum.TabIndex = 31;
            this.label_APIversionNum.Text = "#";
            // 
            // label_compatibleFirmwareVersionNums
            // 
            this.label_compatibleFirmwareVersionNums.AutoSize = true;
            this.label_compatibleFirmwareVersionNums.Location = new System.Drawing.Point(160, 125);
            this.label_compatibleFirmwareVersionNums.Name = "label_compatibleFirmwareVersionNums";
            this.label_compatibleFirmwareVersionNums.Size = new System.Drawing.Size(14, 13);
            this.label_compatibleFirmwareVersionNums.TabIndex = 30;
            this.label_compatibleFirmwareVersionNums.Text = "#";
            // 
            // linkLabel_www
            // 
            this.linkLabel_www.AutoSize = true;
            this.linkLabel_www.Location = new System.Drawing.Point(44, 167);
            this.linkLabel_www.Name = "linkLabel_www";
            this.linkLabel_www.Size = new System.Drawing.Size(80, 13);
            this.linkLabel_www.TabIndex = 29;
            this.linkLabel_www.TabStop = true;
            this.linkLabel_www.Text = "www.x-io.co.uk";
            this.linkLabel_www.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_wwwxiocouk_LinkClicked);
            // 
            // label_compatibleFirmwareVersions
            // 
            this.label_compatibleFirmwareVersions.AutoSize = true;
            this.label_compatibleFirmwareVersions.Location = new System.Drawing.Point(8, 125);
            this.label_compatibleFirmwareVersions.Name = "label_compatibleFirmwareVersions";
            this.label_compatibleFirmwareVersions.Size = new System.Drawing.Size(146, 13);
            this.label_compatibleFirmwareVersions.TabIndex = 25;
            this.label_compatibleFirmwareVersions.Text = "Compatible firmware versions:";
            // 
            // label_APIversion
            // 
            this.label_APIversion.AutoSize = true;
            this.label_APIversion.Location = new System.Drawing.Point(8, 105);
            this.label_APIversion.Name = "label_APIversion";
            this.label_APIversion.Size = new System.Drawing.Size(64, 13);
            this.label_APIversion.TabIndex = 24;
            this.label_APIversion.Text = "API version:";
            // 
            // label_GUIversion
            // 
            this.label_GUIversion.AutoSize = true;
            this.label_GUIversion.Location = new System.Drawing.Point(8, 85);
            this.label_GUIversion.Name = "label_GUIversion";
            this.label_GUIversion.Size = new System.Drawing.Size(66, 13);
            this.label_GUIversion.TabIndex = 23;
            this.label_GUIversion.Text = "GUI version:";
            // 
            // appendedTreeView_registers
            // 
            this.appendedTreeView_registers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appendedTreeView_registers.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.appendedTreeView_registers.Location = new System.Drawing.Point(3, 3);
            this.appendedTreeView_registers.Name = "appendedTreeView_registers";
            this.appendedTreeView_registers.Size = new System.Drawing.Size(826, 404);
            this.appendedTreeView_registers.TabIndex = 0;
            this.appendedTreeView_registers.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.appendedTreeView_registers_NodeMouseClick);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 436);
            this.Controls.Add(this.tabControl_main);
            this.Name = "Form_main";
            this.Text = "Form_main";
            this.Load += new System.EventHandler(this.Form_main_Load);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_serialPort.ResumeLayout(false);
            this.groupBox_packetCounts.ResumeLayout(false);
            this.groupBox_packetCounts.PerformLayout();
            this.groupBox_OpenClosePort.ResumeLayout(false);
            this.groupBox_OpenClosePort.PerformLayout();
            this.tabPage_registers.ResumeLayout(false);
            this.tabPage_dateTime.ResumeLayout(false);
            this.groupBox_dateTime.ResumeLayout(false);
            this.groupBox_dateTime.PerformLayout();
            this.tabPage_commands.ResumeLayout(false);
            this.groupBox_receivedCommandMessages.ResumeLayout(false);
            this.groupBox_receivedCommandMessages.PerformLayout();
            this.groupBox_algorithm.ResumeLayout(false);
            this.groupBox_magnetometerCalibration.ResumeLayout(false);
            this.groupBox_accelerometerCalibration.ResumeLayout(false);
            this.groupBox_gyroscopeCalibration.ResumeLayout(false);
            this.groupBox_general.ResumeLayout(false);
            this.tabPage_ViewSensorData.ResumeLayout(false);
            this.groupBox_orienData.ResumeLayout(false);
            this.groupBox_orienData.PerformLayout();
            this.groupBox_sensorData.ResumeLayout(false);
            this.groupBox_sensorData.PerformLayout();
            this.groupBox_battThermData.ResumeLayout(false);
            this.tabPage_auxillaryPort.ResumeLayout(false);
            this.groupBox_ADXL345bus.ResumeLayout(false);
            this.groupBox_pwmOutput.ResumeLayout(false);
            this.groupBox_analogueInput.ResumeLayout(false);
            this.groupBox_digitalIO.ResumeLayout(false);
            this.tabPage_dataLogger.ResumeLayout(false);
            this.groupBox_logReceivedDataToFile.ResumeLayout(false);
            this.groupBox_logReceivedDataToFile.PerformLayout();
            this.tabPage_SDcard.ResumeLayout(false);
            this.groupBox_convertBinaryFile.ResumeLayout(false);
            this.groupBox_convertBinaryFile.PerformLayout();
            this.tabPage_hardIronCalibration.ResumeLayout(false);
            this.groupBox_step3hardIronCalibrationAlgorithm.ResumeLayout(false);
            this.groupBox_step3hardIronCalibrationAlgorithm.PerformLayout();
            this.groupBox_step2collectHardIronCalibrationDataSet.ResumeLayout(false);
            this.groupBox_step2collectHardIronCalibrationDataSet.PerformLayout();
            this.groupBox_step1ClearHardIronBiasRegisters.ResumeLayout(false);
            this.tabPage_uploadFirmware.ResumeLayout(false);
            this.groupBox_bootloader.ResumeLayout(false);
            this.groupBox_bootloader.PerformLayout();
            this.tabPage_about.ResumeLayout(false);
            this.tabPage_about.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Register tree view design code

        private void InitializeAppendedTreeViewComponents()
        {
            #region General

            appendedTreeNodeTextBox_firmVersionMajorNum = new AppendedTreeNodeTextBox("Major Number:");
            appendedTreeNodeTextBox_firmVersionMajorNum.TextBox.ReadOnly = true;
            appendedTreeNodeTextBox_firmVersionMinorNum = new AppendedTreeNodeTextBox("Minor Number:");
            appendedTreeNodeTextBox_firmVersionMinorNum.TextBox.ReadOnly = true;
            appendedTreeNodeTextBox_firmwareVersion = new System.Windows.Forms.TreeNode("Firmware Version (read-only):", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_firmVersionMajorNum,
            appendedTreeNodeTextBox_firmVersionMinorNum});
            appendedTreeNodeTextBox_deviceID = new AppendedTreeNodeTextBox("Device ID (read only):");
            appendedTreeNodeTextBox_deviceID.TextBox.ReadOnly = true;
            appendedTreeNodeComboBox_buttonMode = new AppendedTreeNodeComboBox("Button Mode:");
            appendedTreeNodeComboBox_buttonMode.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_buttonMode.ComboBox.Width = 150;
            appendedTreeNodeComboBox_buttonMode.ComboBox.Items.Add("Disabled");
            appendedTreeNodeComboBox_buttonMode.ComboBox.Items.Add("Reset");
            appendedTreeNodeComboBox_buttonMode.ComboBox.Items.Add("Sleep/wake");
            appendedTreeNodeComboBox_buttonMode.ComboBox.Items.Add("Algorithm initialise");
            appendedTreeNodeComboBox_buttonMode.ComboBox.Items.Add("Algorithm tare");
            appendedTreeNodeComboBox_buttonMode.ComboBox.Items.Add("Algorithm initialise then tare");
            treeNodeGeneral = new System.Windows.Forms.TreeNode("General", new System.Windows.Forms.TreeNode[] {
            appendedTreeNodeTextBox_firmwareVersion,
            appendedTreeNodeTextBox_deviceID,
            appendedTreeNodeComboBox_buttonMode
            });

            #endregion

            #region Sensor Calibration Parameters

            #region Battery Voltmeter

            appendedTreeNodeTextBox_battSens = new AppendedTreeNodeTextBox("Sensitivity (lsb/V):");
            appendedTreeNodeTextBox_battBias = new AppendedTreeNodeTextBox("Bias (lsb):");
            treeNode_battVoltmeter = new System.Windows.Forms.TreeNode("Battery Voltmeter", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_battSens,
            appendedTreeNodeTextBox_battBias});

            #endregion

            #region Thermometer

            appendedTreeNodeTextBox_thermSens = new AppendedTreeNodeTextBox("Sensitivity (lsb/˚C):");
            appendedTreeNodeTextBox_thermBias = new AppendedTreeNodeTextBox("Bias (lsb):");
            treeNode_thermometer = new System.Windows.Forms.TreeNode("Thermometer", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_thermSens,
            appendedTreeNodeTextBox_thermBias});

            #endregion

            #region Gyroscope

            appendedTreeNodeComboBox_gyroFullScale = new AppendedTreeNodeComboBox("Full-Scale:");
            appendedTreeNodeComboBox_gyroFullScale.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_gyroFullScale.ComboBox.Width = 75;
            appendedTreeNodeComboBox_gyroFullScale.ComboBox.Items.Add("±250 ˚/s");
            appendedTreeNodeComboBox_gyroFullScale.ComboBox.Items.Add("±500 ˚/s");
            appendedTreeNodeComboBox_gyroFullScale.ComboBox.Items.Add("±1000 ˚/s");
            appendedTreeNodeComboBox_gyroFullScale.ComboBox.Items.Add("±2000 ˚/s");
            appendedTreeNodeTextBox_gyroSensX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_gyroSensY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_gyroSensZ = new AppendedTreeNodeTextBox("Z:");
            appendedTreeNodeTextBox_gyroSampledPlus200dpsX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_gyroSampledPlus200dpsY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_gyroSampledPlus200dpsZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_gyroSampledAxesAtPlus200dps = new System.Windows.Forms.TreeNode("Sample Axes @ +200 ˚/s (lsb)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_gyroSampledPlus200dpsX,
            appendedTreeNodeTextBox_gyroSampledPlus200dpsY,
            appendedTreeNodeTextBox_gyroSampledPlus200dpsZ});
            appendedTreeNodeTextBox_gyroSampledMinus200dpsX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_gyroSampledMinus200dpsY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_gyroSampledMinus200dpsZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_gyroSampledAxesAtMinus200dps = new System.Windows.Forms.TreeNode("Sample Axes @ -200 ˚/s (lsb)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_gyroSampledMinus200dpsX,
            appendedTreeNodeTextBox_gyroSampledMinus200dpsY,
            appendedTreeNodeTextBox_gyroSampledMinus200dpsZ});
            treeNode_gyroSens = new System.Windows.Forms.TreeNode("Sensitivity (lsb/˚/s)", new System.Windows.Forms.TreeNode[] {
            appendedTreeNodeTextBox_gyroSensX,
            appendedTreeNodeTextBox_gyroSensY,
            appendedTreeNodeTextBox_gyroSensZ,
            treeNode_gyroSampledAxesAtPlus200dps,
            treeNode_gyroSampledAxesAtMinus200dps});
            appendedTreeNodeTextBox_gyroBiasX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_gyroBiasY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_gyroBiasZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_gyroBias = new System.Windows.Forms.TreeNode("Bias @ 25˚C (lsb)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_gyroBiasX,
            appendedTreeNodeTextBox_gyroBiasY,
            appendedTreeNodeTextBox_gyroBiasZ});
            appendedTreeNodeTextBox_gyroBiasTempSensX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_gyroBiasTempSensY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_gyroBiasTempSensZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_gyroBiasTempSens = new System.Windows.Forms.TreeNode("Bias Temperature Sensitivity (˚C/lsb)", new AppendedTreeNodeTextBox[] { 
            appendedTreeNodeTextBox_gyroBiasTempSensX,
            appendedTreeNodeTextBox_gyroBiasTempSensY,
            appendedTreeNodeTextBox_gyroBiasTempSensZ});
            appendedTreeNodeTextBox_gyroSample1Temp = new AppendedTreeNodeTextBox("Temperature (˚C):");
            appendedTreeNodeTextBox_gyroSample1BiasX = new AppendedTreeNodeTextBox("Bias X (lsb):");
            appendedTreeNodeTextBox_gyroSample1BiasY = new AppendedTreeNodeTextBox("Bias Y (lsb):");
            appendedTreeNodeTextBox_gyroSample1BiasZ = new AppendedTreeNodeTextBox("Bias Z (lsb):");
            treeNode_gyroSample1 = new System.Windows.Forms.TreeNode("Sampled Temperature 1", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_gyroSample1Temp,
            appendedTreeNodeTextBox_gyroSample1BiasX,
            appendedTreeNodeTextBox_gyroSample1BiasY,
            appendedTreeNodeTextBox_gyroSample1BiasZ});
            appendedTreeNodeTextBox_gyroSample2Temp = new AppendedTreeNodeTextBox("Temperature (˚C):");
            appendedTreeNodeTextBox_gyroSample2BiasX = new AppendedTreeNodeTextBox("Bias X (lsb):");
            appendedTreeNodeTextBox_gyroSample2BiasY = new AppendedTreeNodeTextBox("Bias Y (lsb):");
            appendedTreeNodeTextBox_gyroSample2BiasZ = new AppendedTreeNodeTextBox("Bias Z (lsb):");
            treeNode_gyroSample2 = new System.Windows.Forms.TreeNode("Sampled Temperature 2", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_gyroSample2Temp,
            appendedTreeNodeTextBox_gyroSample2BiasX,
            appendedTreeNodeTextBox_gyroSample2BiasY,
            appendedTreeNodeTextBox_gyroSample2BiasZ});
            treeNode_gyroBiasParent = new System.Windows.Forms.TreeNode("Bias", new System.Windows.Forms.TreeNode[] {
            treeNode_gyroBias,
            treeNode_gyroBiasTempSens,
            treeNode_gyroSample1,
            treeNode_gyroSample2});
            treeNode_gyroscope = new System.Windows.Forms.TreeNode("Gyroscope", new System.Windows.Forms.TreeNode[] {
            appendedTreeNodeComboBox_gyroFullScale,
            treeNode_gyroSens,
            treeNode_gyroBiasParent});

            #endregion

            #region Acceleroemter

            appendedTreeNodeComboBox_accelFullScale = new AppendedTreeNodeComboBox("Full-Scale:");
            appendedTreeNodeComboBox_accelFullScale.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_accelFullScale.ComboBox.Width = 50;
            appendedTreeNodeComboBox_accelFullScale.ComboBox.Items.Add("±2 g");
            appendedTreeNodeComboBox_accelFullScale.ComboBox.Items.Add("±4 g");
            appendedTreeNodeComboBox_accelFullScale.ComboBox.Items.Add("±8 g");
            appendedTreeNodeTextBox_accelSensX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_accelSensY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_accelSensZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_accelSens = new System.Windows.Forms.TreeNode("Sensitivity (lsb/g)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_accelSensX,
            appendedTreeNodeTextBox_accelSensY,
            appendedTreeNodeTextBox_accelSensZ});
            appendedTreeNodeTextBox_accelBiasX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_accelBiasY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_accelBiasZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_accelBias = new System.Windows.Forms.TreeNode("Bias (lsb)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_accelBiasX,
            appendedTreeNodeTextBox_accelBiasY,
            appendedTreeNodeTextBox_accelBiasZ});
            appendedTreeNodeTextBox_accelSampledPlus1gX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_accelSampledPlus1gY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_accelSampledPlus1gZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_accelSampledAsexAtPlus1g = new System.Windows.Forms.TreeNode("Sampled Axes @ +1 g (lsb)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_accelSampledPlus1gX,
            appendedTreeNodeTextBox_accelSampledPlus1gY,
            appendedTreeNodeTextBox_accelSampledPlus1gZ});
            appendedTreeNodeTextBox_accelSampledMinus1gX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_accelSampledMinus1gY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_accelSampledMinus1gZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_accelSampledAsexAtMinus1g = new System.Windows.Forms.TreeNode("Sampled Axes @ -1 g (lsb)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_accelSampledMinus1gX,
            appendedTreeNodeTextBox_accelSampledMinus1gY,
            appendedTreeNodeTextBox_accelSampledMinus1gZ});
            treeNode_accelerometer = new System.Windows.Forms.TreeNode("Accelerometer", new System.Windows.Forms.TreeNode[] {
            appendedTreeNodeComboBox_accelFullScale,
            treeNode_accelSens,
            treeNode_accelBias,
            treeNode_accelSampledAsexAtPlus1g,
            treeNode_accelSampledAsexAtMinus1g});

            #endregion

            #region Magnetometer

            appendedTreeNodeComboBox_magFullScale = new AppendedTreeNodeComboBox("Full Scale:");
            appendedTreeNodeComboBox_magFullScale.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_magFullScale.ComboBox.Width = 60;
            appendedTreeNodeComboBox_magFullScale.ComboBox.Items.Add("±1.3 G");
            appendedTreeNodeComboBox_magFullScale.ComboBox.Items.Add("±1.9 G");
            appendedTreeNodeComboBox_magFullScale.ComboBox.Items.Add("±2.5 G");
            appendedTreeNodeComboBox_magFullScale.ComboBox.Items.Add("±4.0 G");
            appendedTreeNodeComboBox_magFullScale.ComboBox.Items.Add("±4.7 G");
            appendedTreeNodeComboBox_magFullScale.ComboBox.Items.Add("±5.6 G");
            appendedTreeNodeComboBox_magFullScale.ComboBox.Items.Add("±8.1 G");
            appendedTreeNodeTextBox_magSensX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_magSensY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_magSensZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_magSens = new System.Windows.Forms.TreeNode("Sensitivity (lsb/G)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_magSensX,
            appendedTreeNodeTextBox_magSensY,
            appendedTreeNodeTextBox_magSensZ});
            appendedTreeNodeTextBox_magBiasX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_magBiasY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_magBiasZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_magBias = new System.Windows.Forms.TreeNode("Bias (lsb)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_magBiasX,
            appendedTreeNodeTextBox_magBiasY,
            appendedTreeNodeTextBox_magBiasZ});
            appendedTreeNodeTextBox_magHIbiasX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_magHIbiasY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_magHIbiasZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_magHIbias = new System.Windows.Forms.TreeNode("Hard-Iron Bias (G)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_magHIbiasX,
            appendedTreeNodeTextBox_magHIbiasY,
            appendedTreeNodeTextBox_magHIbiasZ});
            treeNode_magnetometer = new System.Windows.Forms.TreeNode("Magnetometer", new System.Windows.Forms.TreeNode[] {
            appendedTreeNodeComboBox_magFullScale,
            treeNode_magSens,
            treeNode_magBias,
            treeNode_magHIbias});
            System.Windows.Forms.TreeNode treeNode_sensorCalParam = new System.Windows.Forms.TreeNode("Sensor Calibration Parameters", new System.Windows.Forms.TreeNode[] {
            treeNode_battVoltmeter,
            treeNode_thermometer,
            treeNode_gyroscope,
            treeNode_accelerometer,
            treeNode_magnetometer});

            #endregion

            #endregion

            #region Algorithm Parameters

            appendedTreeNodeComboBox_algorithmMode = new AppendedTreeNodeComboBox("Algorithm Mode:");
            appendedTreeNodeComboBox_algorithmMode.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_algorithmMode.ComboBox.Width = 60;
            appendedTreeNodeComboBox_algorithmMode.ComboBox.Items.Add("Disabled");
            appendedTreeNodeComboBox_algorithmMode.ComboBox.Items.Add("IMU");
            appendedTreeNodeComboBox_algorithmMode.ComboBox.Items.Add("AHRS");
            appendedTreeNodeTextBox_algorithmGainKp = new AppendedTreeNodeTextBox("Proportional Gain:");
            appendedTreeNodeTextBox_algorithmGainKi = new AppendedTreeNodeTextBox("Integral Gain:");
            System.Windows.Forms.TreeNode treeNode_algorithmGains = new System.Windows.Forms.TreeNode("Algorithm Gains", new System.Windows.Forms.TreeNode[] {
            appendedTreeNodeTextBox_algorithmGainKp,
            appendedTreeNodeTextBox_algorithmGainKi});
            appendedTreeNodeTextBox_algorithmInitKp = new AppendedTreeNodeTextBox("Initial Proportional Gain:");
            appendedTreeNodeTextBox_algorithmInitPeriod = new AppendedTreeNodeTextBox("Initialisation Period (s):");
            System.Windows.Forms.TreeNode treeNode_algoInitialisation = new System.Windows.Forms.TreeNode("Initialisation", new System.Windows.Forms.TreeNode[] {
            appendedTreeNodeTextBox_algorithmInitKp,
            appendedTreeNodeTextBox_algorithmInitPeriod});
            appendedTreeNodeTextBox_algorithmMinValidMag = new AppendedTreeNodeTextBox("Minimum Valid Field Magnitude (G):");
            appendedTreeNodeTextBox_algorithmMaxValidMag = new AppendedTreeNodeTextBox("Maximum Valid Field Magnitude (G):");
            System.Windows.Forms.TreeNode treeNode_magneticFieldRejection = new System.Windows.Forms.TreeNode("Magnetic Field Rejection", new System.Windows.Forms.TreeNode[] {
            appendedTreeNodeTextBox_algorithmMinValidMag,
            appendedTreeNodeTextBox_algorithmMaxValidMag});
            appendedTreeNodeTextBoxtareQuatElement0 = new AppendedTreeNodeTextBox("Element 0:");
            appendedTreeNodeTextBoxtareQuatElement1 = new AppendedTreeNodeTextBox("Element 1:");
            appendedTreeNodeTextBoxtareQuatElement2 = new AppendedTreeNodeTextBox("Element 2:");
            appendedTreeNodeTextBoxtareQuatElement3 = new AppendedTreeNodeTextBox("Element 3:");
            appendedTreeNodeTextBox_algorithmTareQuaternion = new System.Windows.Forms.TreeNode("Tare Quaternion", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBoxtareQuatElement0,
            appendedTreeNodeTextBoxtareQuatElement1,
            appendedTreeNodeTextBoxtareQuatElement2,
            appendedTreeNodeTextBoxtareQuatElement3});
            treeNode_algorithmParameters = new System.Windows.Forms.TreeNode("Algorithm Parameters", new System.Windows.Forms.TreeNode[] {
            appendedTreeNodeComboBox_algorithmMode,
            treeNode_algorithmGains,
            treeNode_algoInitialisation,
            treeNode_magneticFieldRejection,
            appendedTreeNodeTextBox_algorithmTareQuaternion});

            #endregion

            #region Data Output Settings

            appendedTreeNodeComboBox_sensorDataMode = new AppendedTreeNodeComboBox("Sensor Data Mode:");
            appendedTreeNodeComboBox_sensorDataMode.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_sensorDataMode.ComboBox.Items.Add("Raw ADC results");
            appendedTreeNodeComboBox_sensorDataMode.ComboBox.Items.Add("Calibrated units");
            appendedTreeNodeComboBox_dateTimeOutputRate = new AppendedTreeNodeComboBox("Date/Time Data Rate:");
            appendedTreeNodeComboBox_dateTimeOutputRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_dateTimeOutputRate.ComboBox.Width = 80;
            appendedTreeNodeComboBox_dateTimeOutputRate.ComboBox.Items.Add("Disabled");
            appendedTreeNodeComboBox_dateTimeOutputRate.ComboBox.Items.Add("1 Hz");
            appendedTreeNodeComboBox_dateTimeOutputRate.ComboBox.Items.Add("2 Hz");
            appendedTreeNodeComboBox_dateTimeOutputRate.ComboBox.Items.Add("4 Hz");
            appendedTreeNodeComboBox_dateTimeOutputRate.ComboBox.Items.Add("8 Hz");
            appendedTreeNodeComboBox_dateTimeOutputRate.ComboBox.Items.Add("16 Hz");
            appendedTreeNodeComboBox_dateTimeOutputRate.ComboBox.Items.Add("32 Hz");
            appendedTreeNodeComboBox_dateTimeOutputRate.ComboBox.Items.Add("64 Hz");
            appendedTreeNodeComboBox_dateTimeOutputRate.ComboBox.Items.Add("128 Hz");
            appendedTreeNodeComboBox_dateTimeOutputRate.ComboBox.Items.Add("256 Hz");
            appendedTreeNodeComboBox_battThermOutputRate = new AppendedTreeNodeComboBox("Battery and Thermometer Data Rate:");
            appendedTreeNodeComboBox_battThermOutputRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_battThermOutputRate.ComboBox.Width = 80;
            appendedTreeNodeComboBox_battThermOutputRate.ComboBox.Items.Add("Disabled");
            appendedTreeNodeComboBox_battThermOutputRate.ComboBox.Items.Add("1 Hz");
            appendedTreeNodeComboBox_battThermOutputRate.ComboBox.Items.Add("2 Hz");
            appendedTreeNodeComboBox_battThermOutputRate.ComboBox.Items.Add("4 Hz");
            appendedTreeNodeComboBox_battThermOutputRate.ComboBox.Items.Add("8 Hz");
            appendedTreeNodeComboBox_battThermOutputRate.ComboBox.Items.Add("16 Hz");
            appendedTreeNodeComboBox_battThermOutputRate.ComboBox.Items.Add("32 Hz");
            appendedTreeNodeComboBox_battThermOutputRate.ComboBox.Items.Add("64 Hz");
            appendedTreeNodeComboBox_battThermOutputRate.ComboBox.Items.Add("128 Hz");
            appendedTreeNodeComboBox_battThermOutputRate.ComboBox.Items.Add("256 Hz");
            appendedTreeNodeComboBox_inertialMagOutputRate = new AppendedTreeNodeComboBox("Inertial and Magnetic Data Rate:");
            appendedTreeNodeComboBox_inertialMagOutputRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_inertialMagOutputRate.ComboBox.Width = 80;
            appendedTreeNodeComboBox_inertialMagOutputRate.ComboBox.Items.Add("Disabled");
            appendedTreeNodeComboBox_inertialMagOutputRate.ComboBox.Items.Add("1 Hz");
            appendedTreeNodeComboBox_inertialMagOutputRate.ComboBox.Items.Add("2 Hz");
            appendedTreeNodeComboBox_inertialMagOutputRate.ComboBox.Items.Add("4 Hz");
            appendedTreeNodeComboBox_inertialMagOutputRate.ComboBox.Items.Add("8 Hz");
            appendedTreeNodeComboBox_inertialMagOutputRate.ComboBox.Items.Add("16 Hz");
            appendedTreeNodeComboBox_inertialMagOutputRate.ComboBox.Items.Add("32 Hz");
            appendedTreeNodeComboBox_inertialMagOutputRate.ComboBox.Items.Add("64 Hz");
            appendedTreeNodeComboBox_inertialMagOutputRate.ComboBox.Items.Add("128 Hz");
            appendedTreeNodeComboBox_inertialMagOutputRate.ComboBox.Items.Add("256 Hz");
            appendedTreeNodeComboBox_quatOutputRate = new AppendedTreeNodeComboBox("Quaternion Data Rate:");
            appendedTreeNodeComboBox_quatOutputRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_quatOutputRate.ComboBox.Width = 80;
            appendedTreeNodeComboBox_quatOutputRate.ComboBox.Items.Add("Disabled");
            appendedTreeNodeComboBox_quatOutputRate.ComboBox.Items.Add("1 Hz");
            appendedTreeNodeComboBox_quatOutputRate.ComboBox.Items.Add("2 Hz");
            appendedTreeNodeComboBox_quatOutputRate.ComboBox.Items.Add("4 Hz");
            appendedTreeNodeComboBox_quatOutputRate.ComboBox.Items.Add("8 Hz");
            appendedTreeNodeComboBox_quatOutputRate.ComboBox.Items.Add("16 Hz");
            appendedTreeNodeComboBox_quatOutputRate.ComboBox.Items.Add("32 Hz");
            appendedTreeNodeComboBox_quatOutputRate.ComboBox.Items.Add("64 Hz");
            appendedTreeNodeComboBox_quatOutputRate.ComboBox.Items.Add("128 Hz");
            appendedTreeNodeComboBox_quatOutputRate.ComboBox.Items.Add("256 Hz");
            treeNode_dataOutputRate = new System.Windows.Forms.TreeNode("Data Output Settings", new System.Windows.Forms.TreeNode[] {
            appendedTreeNodeComboBox_sensorDataMode,
            appendedTreeNodeComboBox_dateTimeOutputRate,
            appendedTreeNodeComboBox_battThermOutputRate,
            appendedTreeNodeComboBox_inertialMagOutputRate,
            appendedTreeNodeComboBox_quatOutputRate});

            #endregion

            #region SD Card

            appendedTreeNodeTextBox_SDcardNewFileName = new AppendedTreeNodeTextBox("New File Name (integer):");
            treeNode_SDcard = new System.Windows.Forms.TreeNode("SD Card", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_SDcardNewFileName});

            #endregion

            #region Power Management

            appendedTreeNodeComboBox_battShutdownVoltage = new AppendedTreeNodeTextBox("Battery Shutdown Voltage (V):");
            appendedTreeNodeTextBoxsleepTimer = new AppendedTreeNodeTextBox("Sleep Timer (s):");
            appendedTreeNodeComboBox_motionTriggeredWakeup = new AppendedTreeNodeComboBox("Motion Triggered Wake Up:");
            appendedTreeNodeComboBox_motionTriggeredWakeup.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_motionTriggeredWakeup.ComboBox.Width = 95;
            appendedTreeNodeComboBox_motionTriggeredWakeup.ComboBox.Items.Add("Disabled");
            appendedTreeNodeComboBox_motionTriggeredWakeup.ComboBox.Items.Add("Low sensitivity");
            appendedTreeNodeComboBox_motionTriggeredWakeup.ComboBox.Items.Add("High sensitivity");
            appendedTreeNodeComboBox_bluetoothPower = new AppendedTreeNodeComboBox("Bluetooth Power:");
            appendedTreeNodeComboBox_bluetoothPower.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_bluetoothPower.ComboBox.Width = 80;
            appendedTreeNodeComboBox_bluetoothPower.ComboBox.Items.Add("Disabled");
            appendedTreeNodeComboBox_bluetoothPower.ComboBox.Items.Add("Enabled");
            treeNode_powerManagement = new System.Windows.Forms.TreeNode("Power Management", new AppendedTreeNode[] {
            appendedTreeNodeComboBox_battShutdownVoltage,
            appendedTreeNodeTextBoxsleepTimer,
            appendedTreeNodeComboBox_motionTriggeredWakeup,
            appendedTreeNodeComboBox_bluetoothPower});

            #endregion

            #region Auxiliary Port

            appendedTreeNodeComboBox_auxiliaryPortMode = new AppendedTreeNodeComboBox("Auxiliary Port Mode:");
            appendedTreeNodeComboBox_auxiliaryPortMode.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_auxiliaryPortMode.ComboBox.Width = 100;
            appendedTreeNodeComboBox_auxiliaryPortMode.ComboBox.Items.Add("Disabled");
            appendedTreeNodeComboBox_auxiliaryPortMode.ComboBox.Items.Add("Digital I/O");
            appendedTreeNodeComboBox_auxiliaryPortMode.ComboBox.Items.Add("Analogue input");
            appendedTreeNodeComboBox_auxiliaryPortMode.ComboBox.Items.Add("PWM output");
            appendedTreeNodeComboBox_auxiliaryPortMode.ComboBox.Items.Add("ADXL345 bus");

            #region Digital I/O

            appendedTreeNodeComboBox_digitalIOdirection = new AppendedTreeNodeComboBox("I/O Direction:");
            appendedTreeNodeComboBox_digitalIOdirection.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_digitalIOdirection.ComboBox.Width = 210;
            appendedTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2,3,4,5,6,7");
            appendedTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2,3,4,5,6, Ouput = AX7");
            appendedTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2,3,4,5, Ouput = AX6,7");
            appendedTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2,3,4, Ouput = AX5,6,7");
            appendedTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2,3, Ouput = AX4,5,6,7");
            appendedTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2, Ouput = AX3,4,5,6,7");
            appendedTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1, Ouput = AX2,3,4,5,6,7");
            appendedTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0, Ouput = AX1,2,3,4,5,6,7");
            appendedTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Outputs = AX0,1,2,3,4,5,6,7");
            appendedTreeNodeComboBox_digitalIOoutputRate = new AppendedTreeNodeComboBox("Data Rate:");
            appendedTreeNodeComboBox_digitalIOoutputRate.ComboBox.Items.Add("On change only");
            appendedTreeNodeComboBox_digitalIOoutputRate.ComboBox.Items.Add("1 Hz");
            appendedTreeNodeComboBox_digitalIOoutputRate.ComboBox.Items.Add("2 Hz");
            appendedTreeNodeComboBox_digitalIOoutputRate.ComboBox.Items.Add("4 Hz");
            appendedTreeNodeComboBox_digitalIOoutputRate.ComboBox.Items.Add("8 Hz");
            appendedTreeNodeComboBox_digitalIOoutputRate.ComboBox.Items.Add("16 Hz");
            appendedTreeNodeComboBox_digitalIOoutputRate.ComboBox.Items.Add("32 Hz");
            appendedTreeNodeComboBox_digitalIOoutputRate.ComboBox.Items.Add("64 Hz");
            appendedTreeNodeComboBox_digitalIOoutputRate.ComboBox.Items.Add("128 Hz");
            appendedTreeNodeComboBox_digitalIOoutputRate.ComboBox.Items.Add("256 Hz");
            appendedTreeNodeComboBox_digitalIOoutputRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_digitalIOoutputRate.ComboBox.Width = 100;
            treeNode_digitalIO = new System.Windows.Forms.TreeNode("Digital I/O", new AppendedTreeNode[] {
            appendedTreeNodeComboBox_digitalIOdirection,
            appendedTreeNodeComboBox_digitalIOoutputRate});

            #endregion

            #region Analogue Input

            appendedTreeNodeComboBox_analogueInputDataMode = new AppendedTreeNodeComboBox("Data Mode:");
            appendedTreeNodeComboBox_analogueInputDataMode.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_analogueInputDataMode.ComboBox.Items.Add("Raw ADC results");
            appendedTreeNodeComboBox_analogueInputDataMode.ComboBox.Items.Add("Calibrated units");
            appendedTreeNodeComboBox_analogueInputDataRate = new AppendedTreeNodeComboBox("Data Rate:");
            appendedTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("Disabled");
            appendedTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("1 Hz");
            appendedTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("2 Hz");
            appendedTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("4 Hz");
            appendedTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("8 Hz");
            appendedTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("16 Hz");
            appendedTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("32 Hz");
            appendedTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("64 Hz");
            appendedTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("128 Hz");
            appendedTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("256 Hz");
            appendedTreeNodeComboBox_analogueInputDataRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_analogueInputDataRate.ComboBox.Width = 80;
            appendedTreeNodeTextBox_analogueInputSensitivity = new AppendedTreeNodeTextBox("Sensitivity:");
            appendedTreeNodeTextBox_analogueInputBias = new AppendedTreeNodeTextBox("Bias:");
            appendedTreeNodeComboBox_analogueInputCalibrationParameters = new System.Windows.Forms.TreeNode("Calibration Parameters", new System.Windows.Forms.TreeNode[] {
            appendedTreeNodeTextBox_analogueInputSensitivity,
            appendedTreeNodeTextBox_analogueInputBias});
            treeNode_analogueInput = new System.Windows.Forms.TreeNode("Analogue Input", new System.Windows.Forms.TreeNode[] {
            appendedTreeNodeComboBox_analogueInputDataMode,
            appendedTreeNodeComboBox_analogueInputDataRate,
            appendedTreeNodeComboBox_analogueInputCalibrationParameters});

            #endregion

            #region PWMoutput

            appendedTreeNodeTextBox_PWMoutputFrequency = new AppendedTreeNodeTextBox("Frequency (Hz):");
            treeNode_PWMoutput = new System.Windows.Forms.TreeNode("PWM Output", new System.Windows.Forms.TreeNode[] {
            appendedTreeNodeTextBox_PWMoutputFrequency});

            #endregion

            #region ADXL345 bus

            appendedTreeNodeComboBox_ADXL345busDataMode = new AppendedTreeNodeComboBox("Data Mode:");
            appendedTreeNodeComboBox_ADXL345busDataMode.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_ADXL345busDataMode.ComboBox.Items.Add("Raw ADC results");
            appendedTreeNodeComboBox_ADXL345busDataMode.ComboBox.Items.Add("Calibrated units");
            appendedTreeNodeComboBox_ADXL345busDataRate = new AppendedTreeNodeComboBox("Data Rate:");
            appendedTreeNodeComboBox_ADXL345busDataRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("Disabled");
            appendedTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("1 Hz");
            appendedTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("2 Hz");
            appendedTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("4 Hz");
            appendedTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("8 Hz");
            appendedTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("16 Hz");
            appendedTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("32 Hz");
            appendedTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("64 Hz");
            appendedTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("128 Hz");
            appendedTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("256 Hz");
            appendedTreeNodeComboBox_ADXL345busDataRate.ComboBox.Width = 80;

            #region ADXL345 A

            appendedTreeNodeTextBox_ADXL345ASensX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_ADXL345ASensY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_ADXL345ASensZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_ADXL345ASens = new System.Windows.Forms.TreeNode("Sensitivity (lsb/g)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_ADXL345ASensX,
            appendedTreeNodeTextBox_ADXL345ASensY,
            appendedTreeNodeTextBox_ADXL345ASensZ});
            appendedTreeNodeTextBox_ADXL345AbiasX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_ADXL345AbiasY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_ADXL345AbiasZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_ADXL345ABias = new System.Windows.Forms.TreeNode("Bias (lsb)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_ADXL345AbiasX,
            appendedTreeNodeTextBox_ADXL345AbiasY,
            appendedTreeNodeTextBox_ADXL345AbiasZ});
            treeNode_ADXL345A = new System.Windows.Forms.TreeNode("ADXL345 A", new System.Windows.Forms.TreeNode[] {
            treeNode_ADXL345ASens,
            treeNode_ADXL345ABias});

            #endregion

            #region ADXL345 B

            appendedTreeNodeTextBox_ADXL345BSensX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_ADXL345BSensY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_ADXL345BSensZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_ADXL345BSens = new System.Windows.Forms.TreeNode("Sensitivity (lsb/g)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_ADXL345BSensX,
            appendedTreeNodeTextBox_ADXL345BSensY,
            appendedTreeNodeTextBox_ADXL345BSensZ});
            appendedTreeNodeTextBox_ADXL345BbiasX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_ADXL345BbiasY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_ADXL345BbiasZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_ADXL345Bbias = new System.Windows.Forms.TreeNode("Bias (lsb)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_ADXL345BbiasX,
            appendedTreeNodeTextBox_ADXL345BbiasY,
            appendedTreeNodeTextBox_ADXL345BbiasZ});
            treeNode_ADXL345B = new System.Windows.Forms.TreeNode("ADXL345 B", new System.Windows.Forms.TreeNode[] {
            treeNode_ADXL345BSens,
            treeNode_ADXL345Bbias});

            #endregion

            #region ADXL345 C

            appendedTreeNodeTextBox_ADXL345CSensX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_ADXL345CSensY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_ADXL345CSensZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_ADXL345CSens = new System.Windows.Forms.TreeNode("Sensitivity (lsb/g)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_ADXL345CSensX,
            appendedTreeNodeTextBox_ADXL345CSensY,
            appendedTreeNodeTextBox_ADXL345CSensZ});
            appendedTreeNodeTextBox_ADXL345CbiasX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_ADXL345CbiasY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_ADXL345CbiasZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_ADXL345Cbias = new System.Windows.Forms.TreeNode("Bias (lsb)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_ADXL345CbiasX,
            appendedTreeNodeTextBox_ADXL345CbiasY,
            appendedTreeNodeTextBox_ADXL345CbiasZ});
            treeNode_ADXL345C = new System.Windows.Forms.TreeNode("ADXL345 C", new System.Windows.Forms.TreeNode[] {
            treeNode_ADXL345CSens,
            treeNode_ADXL345Cbias});

            #endregion

            #region ADXL345 D

            appendedTreeNodeTextBox_ADXL345DSensX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_ADXL345DSensY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_ADXL345DSensZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_ADXL345DSens = new System.Windows.Forms.TreeNode("Sensitivity (lsb/g)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_ADXL345DSensX,
            appendedTreeNodeTextBox_ADXL345DSensY,
            appendedTreeNodeTextBox_ADXL345DSensZ});
            appendedTreeNodeTextBox_ADXL345DbiasX = new AppendedTreeNodeTextBox("X:");
            appendedTreeNodeTextBox_ADXL345DbiasY = new AppendedTreeNodeTextBox("Y:");
            appendedTreeNodeTextBox_ADXL345DbiasZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_ADXL345Dbias = new System.Windows.Forms.TreeNode("Bias (lsb)", new AppendedTreeNodeTextBox[] {
            appendedTreeNodeTextBox_ADXL345DbiasX,
            appendedTreeNodeTextBox_ADXL345DbiasY,
            appendedTreeNodeTextBox_ADXL345DbiasZ});
            treeNode_ADXL345D = new System.Windows.Forms.TreeNode("ADXL345 D", new System.Windows.Forms.TreeNode[] {
            treeNode_ADXL345DSens,
            treeNode_ADXL345Dbias});

            #endregion

            treeNode_ADXL345busCalibrationParameters = new System.Windows.Forms.TreeNode("Calibration Parameters", new System.Windows.Forms.TreeNode[] {
            treeNode_ADXL345A,
            treeNode_ADXL345B,
            treeNode_ADXL345C,
            treeNode_ADXL345D});
            treeNode_ADXL345 = new System.Windows.Forms.TreeNode("ADXL345 Bus", new System.Windows.Forms.TreeNode[] {
            appendedTreeNodeComboBox_ADXL345busDataMode,
            appendedTreeNodeComboBox_ADXL345busDataRate,
            treeNode_ADXL345busCalibrationParameters});

            #endregion

            treeNode_auxiliaryPort = new System.Windows.Forms.TreeNode("Auxiliary Port", new System.Windows.Forms.TreeNode[] {
            appendedTreeNodeComboBox_auxiliaryPortMode,
            treeNode_digitalIO,
            treeNode_analogueInput,
            treeNode_PWMoutput,
            treeNode_ADXL345});

            #endregion

            appendedTreeView_registers.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNodeGeneral,
            treeNode_sensorCalParam,
            treeNode_algorithmParameters,
            treeNode_dataOutputRate,
            treeNode_SDcard,
            treeNode_powerManagement,
            treeNode_auxiliaryPort});
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_serialPort;
        private System.Windows.Forms.Button button_refreshList;
        private System.Windows.Forms.GroupBox groupBox_OpenClosePort;
        private System.Windows.Forms.Label label_portName;
        private System.Windows.Forms.ComboBox comboBox_portName;
        private System.Windows.Forms.Button button_openPort;
        private System.Windows.Forms.GroupBox groupBox_packetCounts;
        private System.Windows.Forms.Label label_packetsReceived;
        private System.Windows.Forms.TextBox textBox_packetsReceived;
        private System.Windows.Forms.Label label_packetsSent;
        private System.Windows.Forms.TextBox textBox_packetsSent;
        private System.Windows.Forms.TabPage tabPage_registers;
        private AppendedTreeView appendedTreeView_registers;
        private System.Windows.Forms.TabPage tabPage_dateTime;
        private System.Windows.Forms.GroupBox groupBox_dateTime;
        private System.Windows.Forms.Label label_receivedDateTime;
        private System.Windows.Forms.TextBox textBox_receivedDataTime;
        private System.Windows.Forms.Button button_readDateTime;
        private System.Windows.Forms.Button button_setDateTime;
        private System.Windows.Forms.TabPage tabPage_commands;
        private System.Windows.Forms.GroupBox groupBox_general;
        private System.Windows.Forms.Button button_factoryReset;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Button button_sleep;
        private System.Windows.Forms.Button button_resetSleepTimer;
        private System.Windows.Forms.GroupBox groupBox_gyroscopeCalibration;
        private System.Windows.Forms.Button button_sampleGyroAt200dps;
        private System.Windows.Forms.Button button_calculateGyroSensitivity;
        private System.Windows.Forms.Button button_sampleGyroBiasAtT1;
        private System.Windows.Forms.Button button_sampleGyroBiasAtT2;
        private System.Windows.Forms.Button button_calcGyroBiasParameters;
        private System.Windows.Forms.GroupBox groupBox_accelerometerCalibration;
        private System.Windows.Forms.Button button_sampleAccelAxisAt1g;
        private System.Windows.Forms.Button button_calcAccelBiasSens;
        private System.Windows.Forms.GroupBox groupBox_magnetometerCalibration;
        private System.Windows.Forms.Button button_measMagBiasSens;
        private System.Windows.Forms.GroupBox groupBox_algorithm;
        private System.Windows.Forms.Button button_initialise;
        private System.Windows.Forms.Button button_tare;
        private System.Windows.Forms.Button button_clearTare;
        private System.Windows.Forms.Button button_initialiseThenTare;
        private System.Windows.Forms.GroupBox groupBox_receivedCommandMessages;
        private System.Windows.Forms.CheckBox checkBox_displayCommandConfirmations;
        private System.Windows.Forms.TabPage tabPage_ViewSensorData;
        private System.Windows.Forms.GroupBox groupBox_battThermData;
        private System.Windows.Forms.Button button_showBatteryGraph;
        private System.Windows.Forms.Button button_showThermGraph;
        private System.Windows.Forms.GroupBox groupBox_sensorData;
        private System.Windows.Forms.Button button_showGyroGraph;
        private System.Windows.Forms.Button button_showAccelGraph;
        private System.Windows.Forms.Button button_showMagGraph;
        private System.Windows.Forms.Label label_sensorLegend;
        private System.Windows.Forms.Label label_legendX;
        private System.Windows.Forms.Label label_legendY;
        private System.Windows.Forms.Label label_legendZ;
        private System.Windows.Forms.GroupBox groupBox_orienData;
        private System.Windows.Forms.Button button_show3Dcuboid;
        private System.Windows.Forms.Button button_showEulerAngleGraph;
        private System.Windows.Forms.Label label_eulerLegend;
        private System.Windows.Forms.Label label_phi;
        private System.Windows.Forms.Label label_theta;
        private System.Windows.Forms.Label label_psi;
        private System.Windows.Forms.TabPage tabPage_auxillaryPort;
        private System.Windows.Forms.GroupBox groupBox_digitalIO;
        private System.Windows.Forms.Button button_showDigitalIOpanel;
        private System.Windows.Forms.GroupBox groupBox_analogueInput;
        private System.Windows.Forms.Button button_showAX0andAX1graph;
        private System.Windows.Forms.Button button_showAX2andAX3graph;
        private System.Windows.Forms.Button button_showAX4andAX5graph;
        private System.Windows.Forms.Button button_showAX6andAX7graph;
        private System.Windows.Forms.GroupBox groupBox_pwmOutput;
        private System.Windows.Forms.Button button_showPWMoutputPanel;
        private System.Windows.Forms.GroupBox groupBox_ADXL345bus;
        private System.Windows.Forms.Button button_showADXL345Dgraph;
        private System.Windows.Forms.Button button_showADXL345Cgraph;
        private System.Windows.Forms.Button button_showADXL345Bgraph;
        private System.Windows.Forms.Button button_showADXL345Agraph;
        private System.Windows.Forms.TabPage tabPage_dataLogger;
        private System.Windows.Forms.GroupBox groupBox_logReceivedDataToFile;
        private System.Windows.Forms.Label label_dataLoggerFilePath;
        private System.Windows.Forms.TextBox textBox_dataLoggerFilePath;
        private System.Windows.Forms.Button button_dataLoggerFilePathBrowse;
        private System.Windows.Forms.Button button_dataLoggerStart;
        private System.Windows.Forms.TabPage tabPage_SDcard;
        private System.Windows.Forms.GroupBox groupBox_convertBinaryFile;
        private System.Windows.Forms.TextBox textBox_convertBinaryFileFilePath;
        private System.Windows.Forms.Label labelconvertBinaryFileFilePath;
        private System.Windows.Forms.Button button_convertBinaryFileConvertBrowse;
        private System.Windows.Forms.Button button_convertBinaryFileConvert;
        private System.Windows.Forms.TabPage tabPage_hardIronCalibration;
        private System.Windows.Forms.GroupBox groupBox_step1ClearHardIronBiasRegisters;
        private System.Windows.Forms.Button button_clearHardIronRegisters;
        private System.Windows.Forms.GroupBox groupBox_step2collectHardIronCalibrationDataSet;
        private System.Windows.Forms.Label label_collectHardIronCalDatasetFilePath;
        private System.Windows.Forms.TextBox textBox_collectHardIronCalDatasetFilePath;
        private System.Windows.Forms.Button button_collectHardIronCalDatasetBrowse;
        private System.Windows.Forms.Button button_collectHardIronCalDatasetStartLogging;
        private System.Windows.Forms.GroupBox groupBox_step3hardIronCalibrationAlgorithm;
        private System.Windows.Forms.Label label_hardIronCalFilePath;
        private System.Windows.Forms.TextBox textBox_hardIronCalFilePath;
        private System.Windows.Forms.Button button_hardIronCalBrowse;
        private System.Windows.Forms.Button button_hardIronCalRun;
        private System.Windows.Forms.TabPage tabPage_uploadFirmware;
        private System.Windows.Forms.GroupBox groupBox_bootloader;
        private System.Windows.Forms.Label label_bootloaderFilePath;
        private System.Windows.Forms.TextBox textBox_bootloaderFilePath;
        private System.Windows.Forms.Button button_bootloaderBrowse;
        private System.Windows.Forms.Button button_bootloaderUpload;
        private System.Windows.Forms.TabPage tabPage_about;
        private System.Windows.Forms.PictureBox pictureBox_logo;
        private System.Windows.Forms.Label label_GUIversion;
        private System.Windows.Forms.Label label_GUIversionNum;
        private System.Windows.Forms.Label label_APIversion;
        private System.Windows.Forms.Label label_APIversionNum;
        private System.Windows.Forms.Label label_compatibleFirmwareVersions;
        private System.Windows.Forms.Label label_compatibleFirmwareVersionNums;
        private System.Windows.Forms.Label label_check;
        private System.Windows.Forms.LinkLabel linkLabel_www;
        private System.Windows.Forms.Label label_forLatest;

        #region Register TreeView object declearations

        #region General

        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_firmVersionMajorNum;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_firmVersionMinorNum;
        private System.Windows.Forms.TreeNode appendedTreeNodeTextBox_firmwareVersion;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_deviceID;
        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_buttonMode;
        private System.Windows.Forms.TreeNode treeNodeGeneral;

        #endregion

        #region Sensor Calibration Parameters

        #region Battery Voltmeter

        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_battSens;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_battBias;
        private System.Windows.Forms.TreeNode treeNode_battVoltmeter;

        #endregion

        #region Thermometer

        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_thermSens;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_thermBias;
        private System.Windows.Forms.TreeNode treeNode_thermometer;

        #endregion

        #region Gyroscope

        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_gyroFullScale;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroSensX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroSensY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroSensZ;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroSampledPlus200dpsX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroSampledPlus200dpsY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroSampledPlus200dpsZ;
        private System.Windows.Forms.TreeNode treeNode_gyroSampledAxesAtPlus200dps;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroSampledMinus200dpsX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroSampledMinus200dpsY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroSampledMinus200dpsZ;
        private System.Windows.Forms.TreeNode treeNode_gyroSampledAxesAtMinus200dps;
        private System.Windows.Forms.TreeNode treeNode_gyroSens;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroBiasX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroBiasY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroBiasZ;
        private System.Windows.Forms.TreeNode treeNode_gyroBias;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroBiasTempSensX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroBiasTempSensY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroBiasTempSensZ;
        private System.Windows.Forms.TreeNode treeNode_gyroBiasTempSens;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroSample1Temp;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroSample1BiasX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroSample1BiasY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroSample1BiasZ;
        private System.Windows.Forms.TreeNode treeNode_gyroSample1;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroSample2Temp;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroSample2BiasX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroSample2BiasY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_gyroSample2BiasZ;
        private System.Windows.Forms.TreeNode treeNode_gyroSample2;
        private System.Windows.Forms.TreeNode treeNode_gyroBiasParent;
        private System.Windows.Forms.TreeNode treeNode_gyroscope;

        #endregion

        #region Acceleroemter

        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_accelFullScale;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_accelSensX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_accelSensY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_accelSensZ;
        private System.Windows.Forms.TreeNode treeNode_accelSens;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_accelBiasX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_accelBiasY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_accelBiasZ;
        private System.Windows.Forms.TreeNode treeNode_accelBias;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_accelSampledPlus1gX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_accelSampledPlus1gY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_accelSampledPlus1gZ;
        private System.Windows.Forms.TreeNode treeNode_accelSampledAsexAtPlus1g;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_accelSampledMinus1gX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_accelSampledMinus1gY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_accelSampledMinus1gZ;
        private System.Windows.Forms.TreeNode treeNode_accelSampledAsexAtMinus1g;
        private System.Windows.Forms.TreeNode treeNode_accelerometer;

        #endregion

        #region Magnetometer

        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_magFullScale;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_magSensX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_magSensY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_magSensZ;
        private System.Windows.Forms.TreeNode treeNode_magSens;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_magBiasX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_magBiasY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_magBiasZ;
        private System.Windows.Forms.TreeNode treeNode_magBias;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_magHIbiasX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_magHIbiasY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_magHIbiasZ;
        private System.Windows.Forms.TreeNode treeNode_magHIbias;
        private System.Windows.Forms.TreeNode treeNode_magnetometer;

        #endregion

        #endregion

        #region Algorithm Parameters

        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_algorithmMode;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_algorithmGainKp;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_algorithmGainKi;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_algorithmMinValidMag;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_algorithmMaxValidMag;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_algorithmInitKp;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_algorithmInitPeriod;
        private System.Windows.Forms.TreeNode appendedTreeNodeTextBox_algorithmTareQuaternion;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBoxtareQuatElement0;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBoxtareQuatElement1;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBoxtareQuatElement2;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBoxtareQuatElement3;
        private System.Windows.Forms.TreeNode treeNode_algorithmParameters;

        #endregion

        #region Data Output Settings

        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_sensorDataMode;
        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_dateTimeOutputRate;
        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_battThermOutputRate;
        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_inertialMagOutputRate;
        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_quatOutputRate;
        private System.Windows.Forms.TreeNode treeNode_dataOutputRate;

        #endregion

        #region SD Card

        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_SDcardNewFileName;
        private System.Windows.Forms.TreeNode treeNode_SDcard;

        #endregion

        #region Power Management

        private AppendedTreeNodeTextBox appendedTreeNodeComboBox_battShutdownVoltage;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBoxsleepTimer;
        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_motionTriggeredWakeup;
        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_bluetoothPower;
        private System.Windows.Forms.TreeNode treeNode_powerManagement;

        #endregion

        #region Auxiliary Port

        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_auxiliaryPortMode;

        #region Digital I/O

        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_digitalIOdirection;
        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_digitalIOoutputRate;
        private System.Windows.Forms.TreeNode treeNode_digitalIO;

        #endregion

        #region Analogue Input

        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_analogueInputDataMode;
        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_analogueInputDataRate;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_analogueInputSensitivity;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_analogueInputBias;
        private System.Windows.Forms.TreeNode appendedTreeNodeComboBox_analogueInputCalibrationParameters;
        private System.Windows.Forms.TreeNode treeNode_analogueInput;

        #endregion

        #region PWM Output

        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_PWMoutputFrequency;
        private System.Windows.Forms.TreeNode treeNode_PWMoutput; 

        #endregion

        #region ADXL345 Bus
        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_ADXL345busDataMode;
        private AppendedTreeNodeComboBox appendedTreeNodeComboBox_ADXL345busDataRate;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345ASensX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345ASensY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345ASensZ;
        private System.Windows.Forms.TreeNode treeNode_ADXL345ASens;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345AbiasX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345AbiasY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345AbiasZ;
        private System.Windows.Forms.TreeNode treeNode_ADXL345ABias;
        private System.Windows.Forms.TreeNode treeNode_ADXL345A;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345BSensX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345BSensY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345BSensZ;
        private System.Windows.Forms.TreeNode treeNode_ADXL345BSens;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345BbiasX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345BbiasY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345BbiasZ;
        private System.Windows.Forms.TreeNode treeNode_ADXL345Bbias;
        private System.Windows.Forms.TreeNode treeNode_ADXL345B;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345CSensX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345CSensY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345CSensZ;
        private System.Windows.Forms.TreeNode treeNode_ADXL345CSens;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345CbiasX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345CbiasY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345CbiasZ;
        private System.Windows.Forms.TreeNode treeNode_ADXL345Cbias;
        private System.Windows.Forms.TreeNode treeNode_ADXL345C;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345DSensX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345DSensY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345DSensZ;
        private System.Windows.Forms.TreeNode treeNode_ADXL345DSens;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345DbiasX;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345DbiasY;
        private AppendedTreeNodeTextBox appendedTreeNodeTextBox_ADXL345DbiasZ;
        private System.Windows.Forms.TreeNode treeNode_ADXL345Dbias;
        private System.Windows.Forms.TreeNode treeNode_ADXL345D;
        private System.Windows.Forms.TreeNode treeNode_ADXL345busCalibrationParameters;
        private System.Windows.Forms.TreeNode treeNode_ADXL345;
        #endregion

        private System.Windows.Forms.TreeNode treeNode_auxiliaryPort;

        #endregion

        #endregion
    }
}