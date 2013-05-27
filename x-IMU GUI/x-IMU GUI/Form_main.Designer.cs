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
            this.label_portName = new System.Windows.Forms.Label();
            this.comboBox_portName = new System.Windows.Forms.ComboBox();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_serialPort = new System.Windows.Forms.TabPage();
            this.groupBox_packetCounters = new System.Windows.Forms.GroupBox();
            this.label_packetsSent = new System.Windows.Forms.Label();
            this.textBox_packetsSent = new System.Windows.Forms.TextBox();
            this.textBox_packetsReceived = new System.Windows.Forms.TextBox();
            this.label_packetsReceived = new System.Windows.Forms.Label();
            this.groupBox_openClosePort = new System.Windows.Forms.GroupBox();
            this.toggleButton_openClosePort = new x_IMU_GUI.ToggleButton();
            this.button_refreshList = new System.Windows.Forms.Button();
            this.tabPage_registers = new System.Windows.Forms.TabPage();
            this.registerTreeView = new x_IMU_GUI.RegisterTreeView();
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
            this.commandButton_initialiseThenTare = new x_IMU_GUI.CommandButton();
            this.commandButton_initialise = new x_IMU_GUI.CommandButton();
            this.commandButton_clearTare = new x_IMU_GUI.CommandButton();
            this.commandButton_tare = new x_IMU_GUI.CommandButton();
            this.groupBox_magnetometerCalibration = new System.Windows.Forms.GroupBox();
            this.commandButton_measMagBiasSens = new x_IMU_GUI.CommandButton();
            this.groupBox_accelerometerCalibration = new System.Windows.Forms.GroupBox();
            this.commandButton_calcAccelBiasSens = new x_IMU_GUI.CommandButton();
            this.commandButton_sampleAccelAxisAt1g = new x_IMU_GUI.CommandButton();
            this.groupBox_gyroscopeCalibration = new System.Windows.Forms.GroupBox();
            this.commandButton_calcGyroBiasParameters = new x_IMU_GUI.CommandButton();
            this.commandButton_sampleGyroAt200dps = new x_IMU_GUI.CommandButton();
            this.commandButton_sampleGyroBiasAtT2 = new x_IMU_GUI.CommandButton();
            this.commandButton_calculateGyroSensitivity = new x_IMU_GUI.CommandButton();
            this.commandButtonbutton_sampleGyroBiasAtT1 = new x_IMU_GUI.CommandButton();
            this.groupBox_general = new System.Windows.Forms.GroupBox();
            this.commandButton_resetSleepTimer = new x_IMU_GUI.CommandButton();
            this.commandButton_sleep = new x_IMU_GUI.CommandButton();
            this.commandButton_reset = new x_IMU_GUI.CommandButton();
            this.commandButton_factoryReset = new x_IMU_GUI.CommandButton();
            this.tabPage_viewSensorData = new System.Windows.Forms.TabPage();
            this.groupBox_orientationData = new System.Windows.Forms.GroupBox();
            this.showHideButton_eulerAnglesGraph = new x_IMU_GUI.ShowHideButton();
            this.showHideButton_3Dcuboid = new x_IMU_GUI.ShowHideButton();
            this.label_orientationDataLegendPsi = new System.Windows.Forms.Label();
            this.label_orientationDataLegendTheta = new System.Windows.Forms.Label();
            this.label_orientationDataLegendPhi = new System.Windows.Forms.Label();
            this.label_orientationDataLegend = new System.Windows.Forms.Label();
            this.groupBox_inertialAndMagneticData = new System.Windows.Forms.GroupBox();
            this.showHideButton_magnetometerGraph = new x_IMU_GUI.ShowHideButton();
            this.showHideButton_accelerometerGraph = new x_IMU_GUI.ShowHideButton();
            this.showHideButton_gyroscopeGraph = new x_IMU_GUI.ShowHideButton();
            this.label_inertialAndMagneticDataZ = new System.Windows.Forms.Label();
            this.label_inertialAndMagneticDataY = new System.Windows.Forms.Label();
            this.label_inertialAndMagneticDataX = new System.Windows.Forms.Label();
            this.label_inertialAndMagneticDataLegend = new System.Windows.Forms.Label();
            this.groupBox_batteryAndThermometerData = new System.Windows.Forms.GroupBox();
            this.showHideButton_thermometerGraph = new x_IMU_GUI.ShowHideButton();
            this.showHideButton_batteryGraph = new x_IMU_GUI.ShowHideButton();
            this.tabPage_auxillaryPort = new System.Windows.Forms.TabPage();
            this.groupBox_ADXL345bus = new System.Windows.Forms.GroupBox();
            this.label_ADXL345busZ = new System.Windows.Forms.Label();
            this.label_ADXL345busY = new System.Windows.Forms.Label();
            this.label_ADXL345busX = new System.Windows.Forms.Label();
            this.label_ADXL345busLegend = new System.Windows.Forms.Label();
            this.showHideButton_ADXL345Dgraph = new x_IMU_GUI.ShowHideButton();
            this.showHideButton_ADXL345Agraph = new x_IMU_GUI.ShowHideButton();
            this.showHideButton_ADXL345Bgraph = new x_IMU_GUI.ShowHideButton();
            this.showHideButton_ADXL345Cgraph = new x_IMU_GUI.ShowHideButton();
            this.groupBox_PWMoutput = new System.Windows.Forms.GroupBox();
            this.showHideButton_PWMoutputPanel = new x_IMU_GUI.ShowHideButton();
            this.groupBox_analogueInput = new System.Windows.Forms.GroupBox();
            this.label_analogueInputAX0246 = new System.Windows.Forms.Label();
            this.label_analogueInputAX1357 = new System.Windows.Forms.Label();
            this.label_analogueInputLegend = new System.Windows.Forms.Label();
            this.showHideButton_AX6andAX7graph = new x_IMU_GUI.ShowHideButton();
            this.showHideButton_AX0andAX1graph = new x_IMU_GUI.ShowHideButton();
            this.showHideButton_AX4andAX5graph = new x_IMU_GUI.ShowHideButton();
            this.showHideButton_AX2andAX3graph = new x_IMU_GUI.ShowHideButton();
            this.groupBox_digitalIO = new System.Windows.Forms.GroupBox();
            this.showHideButton_digitalIOpanel = new x_IMU_GUI.ShowHideButton();
            this.tabPage_dataLogger = new System.Windows.Forms.TabPage();
            this.groupBox_logReceivedDataToFile = new System.Windows.Forms.GroupBox();
            this.toggleButton_dataLoggerStartStopLogging = new x_IMU_GUI.ToggleButton();
            this.button_dataLoggerBrowse = new System.Windows.Forms.Button();
            this.label_dataLoggerFilePath = new System.Windows.Forms.Label();
            this.textBox_dataLoggerFilePath = new System.Windows.Forms.TextBox();
            this.tabPage_SDcard = new System.Windows.Forms.TabPage();
            this.groupBox_binaryFileConverter = new System.Windows.Forms.GroupBox();
            this.button_convertBinaryFileBrowse = new System.Windows.Forms.Button();
            this.label_convertBinaryFileFilePath = new System.Windows.Forms.Label();
            this.textBox_convertBinaryFileFilePath = new System.Windows.Forms.TextBox();
            this.button_convertBinaryFileConvert = new System.Windows.Forms.Button();
            this.tabPage_hardIronCalibration = new System.Windows.Forms.TabPage();
            this.groupBox_step3hardIronCalibrationAlgorithm = new System.Windows.Forms.GroupBox();
            this.button_hardIronCalBrowse = new System.Windows.Forms.Button();
            this.label_hardIronCalFilePath = new System.Windows.Forms.Label();
            this.textBox_hardIronCalFilePath = new System.Windows.Forms.TextBox();
            this.button_hardIronCalRun = new System.Windows.Forms.Button();
            this.groupBox_step2collectHardIronCalibrationDataSet = new System.Windows.Forms.GroupBox();
            this.toggleButton_collectHardIronCalDatasetStartStopLogging = new x_IMU_GUI.ToggleButton();
            this.button_collectHardIronCalDatasetBrowse = new System.Windows.Forms.Button();
            this.label_collectHardIronCalDatasetFilePath = new System.Windows.Forms.Label();
            this.textBox_collectHardIronCalDatasetFilePath = new System.Windows.Forms.TextBox();
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
            this.tabControl_main.SuspendLayout();
            this.tabPage_serialPort.SuspendLayout();
            this.groupBox_packetCounters.SuspendLayout();
            this.groupBox_openClosePort.SuspendLayout();
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
            this.tabPage_viewSensorData.SuspendLayout();
            this.groupBox_orientationData.SuspendLayout();
            this.groupBox_inertialAndMagneticData.SuspendLayout();
            this.groupBox_batteryAndThermometerData.SuspendLayout();
            this.tabPage_auxillaryPort.SuspendLayout();
            this.groupBox_ADXL345bus.SuspendLayout();
            this.groupBox_PWMoutput.SuspendLayout();
            this.groupBox_analogueInput.SuspendLayout();
            this.groupBox_digitalIO.SuspendLayout();
            this.tabPage_dataLogger.SuspendLayout();
            this.groupBox_logReceivedDataToFile.SuspendLayout();
            this.tabPage_SDcard.SuspendLayout();
            this.groupBox_binaryFileConverter.SuspendLayout();
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
            this.tabControl_main.Controls.Add(this.tabPage_viewSensorData);
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
            this.tabPage_serialPort.Controls.Add(this.groupBox_packetCounters);
            this.tabPage_serialPort.Controls.Add(this.groupBox_openClosePort);
            this.tabPage_serialPort.Location = new System.Drawing.Point(4, 22);
            this.tabPage_serialPort.Name = "tabPage_serialPort";
            this.tabPage_serialPort.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_serialPort.Size = new System.Drawing.Size(832, 410);
            this.tabPage_serialPort.TabIndex = 0;
            this.tabPage_serialPort.Text = "Serial Port";
            this.tabPage_serialPort.UseVisualStyleBackColor = true;
            // 
            // groupBox_packetCounters
            // 
            this.groupBox_packetCounters.Controls.Add(this.label_packetsSent);
            this.groupBox_packetCounters.Controls.Add(this.textBox_packetsSent);
            this.groupBox_packetCounters.Controls.Add(this.textBox_packetsReceived);
            this.groupBox_packetCounters.Controls.Add(this.label_packetsReceived);
            this.groupBox_packetCounters.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_packetCounters.Location = new System.Drawing.Point(3, 62);
            this.groupBox_packetCounters.Name = "groupBox_packetCounters";
            this.groupBox_packetCounters.Size = new System.Drawing.Size(826, 84);
            this.groupBox_packetCounters.TabIndex = 1;
            this.groupBox_packetCounters.TabStop = false;
            this.groupBox_packetCounters.Text = "Packet Counters";
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
            // groupBox_openClosePort
            // 
            this.groupBox_openClosePort.Controls.Add(this.toggleButton_openClosePort);
            this.groupBox_openClosePort.Controls.Add(this.comboBox_portName);
            this.groupBox_openClosePort.Controls.Add(this.button_refreshList);
            this.groupBox_openClosePort.Controls.Add(this.label_portName);
            this.groupBox_openClosePort.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_openClosePort.Location = new System.Drawing.Point(3, 3);
            this.groupBox_openClosePort.Name = "groupBox_openClosePort";
            this.groupBox_openClosePort.Size = new System.Drawing.Size(826, 59);
            this.groupBox_openClosePort.TabIndex = 0;
            this.groupBox_openClosePort.TabStop = false;
            this.groupBox_openClosePort.Text = "Open/Close Port";
            // 
            // toggleButton_openClosePort
            // 
            this.toggleButton_openClosePort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleButton_openClosePort.FalsePrefixText = "Open ";
            this.toggleButton_openClosePort.Location = new System.Drawing.Point(720, 20);
            this.toggleButton_openClosePort.Name = "toggleButton_openClosePort";
            this.toggleButton_openClosePort.Size = new System.Drawing.Size(100, 23);
            this.toggleButton_openClosePort.SuffixText = "Port";
            this.toggleButton_openClosePort.TabIndex = 2;
            this.toggleButton_openClosePort.Text = "Open Port";
            this.toggleButton_openClosePort.ToggleState = false;
            this.toggleButton_openClosePort.TruePrefixText = "Close ";
            this.toggleButton_openClosePort.UseVisualStyleBackColor = true;
            this.toggleButton_openClosePort.Click += new System.EventHandler(this.toggleButton_openClosePort_Click);
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
            this.tabPage_registers.Controls.Add(this.registerTreeView);
            this.tabPage_registers.Location = new System.Drawing.Point(4, 22);
            this.tabPage_registers.Name = "tabPage_registers";
            this.tabPage_registers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_registers.Size = new System.Drawing.Size(832, 410);
            this.tabPage_registers.TabIndex = 6;
            this.tabPage_registers.Text = "Registers";
            this.tabPage_registers.UseVisualStyleBackColor = true;
            // 
            // registerTreeView
            // 
            this.registerTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registerTreeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.registerTreeView.Location = new System.Drawing.Point(3, 3);
            this.registerTreeView.Name = "registerTreeView";
            this.registerTreeView.RefreshPending = false;
            this.registerTreeView.Size = new System.Drawing.Size(826, 404);
            this.registerTreeView.TabIndex = 0;
            this.registerTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.registerTreeView_registers_NodeMouseClick);
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
            this.groupBox_algorithm.Controls.Add(this.commandButton_initialiseThenTare);
            this.groupBox_algorithm.Controls.Add(this.commandButton_initialise);
            this.groupBox_algorithm.Controls.Add(this.commandButton_clearTare);
            this.groupBox_algorithm.Controls.Add(this.commandButton_tare);
            this.groupBox_algorithm.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_algorithm.Location = new System.Drawing.Point(3, 239);
            this.groupBox_algorithm.Name = "groupBox_algorithm";
            this.groupBox_algorithm.Size = new System.Drawing.Size(826, 59);
            this.groupBox_algorithm.TabIndex = 4;
            this.groupBox_algorithm.TabStop = false;
            this.groupBox_algorithm.Text = "Algorithm";
            // 
            // commandButton_initialiseThenTare
            // 
            this.commandButton_initialiseThenTare.CommandCode = x_IMU_API.CommandCodes.AlgorithmInitialiseThenTare;
            this.commandButton_initialiseThenTare.Location = new System.Drawing.Point(469, 20);
            this.commandButton_initialiseThenTare.Name = "commandButton_initialiseThenTare";
            this.commandButton_initialiseThenTare.Size = new System.Drawing.Size(147, 23);
            this.commandButton_initialiseThenTare.TabIndex = 3;
            this.commandButton_initialiseThenTare.Text = "Initialise Then Tare";
            this.commandButton_initialiseThenTare.UseVisualStyleBackColor = true;
            this.commandButton_initialiseThenTare.Click += new System.EventHandler(this.commandButton_Click);
            // 
            // commandButton_initialise
            // 
            this.commandButton_initialise.CommandCode = x_IMU_API.CommandCodes.AlgorithmInitialise;
            this.commandButton_initialise.Location = new System.Drawing.Point(10, 20);
            this.commandButton_initialise.Name = "commandButton_initialise";
            this.commandButton_initialise.Size = new System.Drawing.Size(147, 23);
            this.commandButton_initialise.TabIndex = 0;
            this.commandButton_initialise.Text = "Initialise";
            this.commandButton_initialise.UseVisualStyleBackColor = true;
            this.commandButton_initialise.Click += new System.EventHandler(this.commandButton_Click);
            // 
            // commandButton_clearTare
            // 
            this.commandButton_clearTare.CommandCode = x_IMU_API.CommandCodes.AlgorithmClearTare;
            this.commandButton_clearTare.Location = new System.Drawing.Point(316, 20);
            this.commandButton_clearTare.Name = "commandButton_clearTare";
            this.commandButton_clearTare.Size = new System.Drawing.Size(147, 23);
            this.commandButton_clearTare.TabIndex = 2;
            this.commandButton_clearTare.Text = "Clear Tare";
            this.commandButton_clearTare.UseVisualStyleBackColor = true;
            this.commandButton_clearTare.Click += new System.EventHandler(this.commandButton_Click);
            // 
            // commandButton_tare
            // 
            this.commandButton_tare.CommandCode = x_IMU_API.CommandCodes.AlgorithmTare;
            this.commandButton_tare.Location = new System.Drawing.Point(163, 20);
            this.commandButton_tare.Name = "commandButton_tare";
            this.commandButton_tare.Size = new System.Drawing.Size(147, 23);
            this.commandButton_tare.TabIndex = 1;
            this.commandButton_tare.Text = "Tare";
            this.commandButton_tare.UseVisualStyleBackColor = true;
            this.commandButton_tare.Click += new System.EventHandler(this.commandButton_Click);
            // 
            // groupBox_magnetometerCalibration
            // 
            this.groupBox_magnetometerCalibration.Controls.Add(this.commandButton_measMagBiasSens);
            this.groupBox_magnetometerCalibration.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_magnetometerCalibration.Location = new System.Drawing.Point(3, 180);
            this.groupBox_magnetometerCalibration.Name = "groupBox_magnetometerCalibration";
            this.groupBox_magnetometerCalibration.Size = new System.Drawing.Size(826, 59);
            this.groupBox_magnetometerCalibration.TabIndex = 3;
            this.groupBox_magnetometerCalibration.TabStop = false;
            this.groupBox_magnetometerCalibration.Text = "Magnetometer Calibration";
            // 
            // commandButton_measMagBiasSens
            // 
            this.commandButton_measMagBiasSens.CommandCode = x_IMU_API.CommandCodes.MeasureMagnetometerBiasAndSensitivity;
            this.commandButton_measMagBiasSens.Location = new System.Drawing.Point(10, 20);
            this.commandButton_measMagBiasSens.Name = "commandButton_measMagBiasSens";
            this.commandButton_measMagBiasSens.Size = new System.Drawing.Size(147, 23);
            this.commandButton_measMagBiasSens.TabIndex = 0;
            this.commandButton_measMagBiasSens.Text = "Measure Mag. Bias/Sens.";
            this.commandButton_measMagBiasSens.UseVisualStyleBackColor = true;
            this.commandButton_measMagBiasSens.Click += new System.EventHandler(this.commandButton_Click);
            // 
            // groupBox_accelerometerCalibration
            // 
            this.groupBox_accelerometerCalibration.Controls.Add(this.commandButton_calcAccelBiasSens);
            this.groupBox_accelerometerCalibration.Controls.Add(this.commandButton_sampleAccelAxisAt1g);
            this.groupBox_accelerometerCalibration.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_accelerometerCalibration.Location = new System.Drawing.Point(3, 121);
            this.groupBox_accelerometerCalibration.Name = "groupBox_accelerometerCalibration";
            this.groupBox_accelerometerCalibration.Size = new System.Drawing.Size(826, 59);
            this.groupBox_accelerometerCalibration.TabIndex = 2;
            this.groupBox_accelerometerCalibration.TabStop = false;
            this.groupBox_accelerometerCalibration.Text = "Accelerometer Calibration";
            // 
            // commandButton_calcAccelBiasSens
            // 
            this.commandButton_calcAccelBiasSens.CommandCode = x_IMU_API.CommandCodes.CalculateAccelerometerBiasAndSensitivity;
            this.commandButton_calcAccelBiasSens.Location = new System.Drawing.Point(163, 20);
            this.commandButton_calcAccelBiasSens.Name = "commandButton_calcAccelBiasSens";
            this.commandButton_calcAccelBiasSens.Size = new System.Drawing.Size(147, 23);
            this.commandButton_calcAccelBiasSens.TabIndex = 1;
            this.commandButton_calcAccelBiasSens.Text = "Calc. Accel. Bias/Sens.";
            this.commandButton_calcAccelBiasSens.UseVisualStyleBackColor = true;
            this.commandButton_calcAccelBiasSens.Click += new System.EventHandler(this.commandButton_Click);
            // 
            // commandButton_sampleAccelAxisAt1g
            // 
            this.commandButton_sampleAccelAxisAt1g.CommandCode = x_IMU_API.CommandCodes.SampleAccelerometerAxisAt1g;
            this.commandButton_sampleAccelAxisAt1g.Location = new System.Drawing.Point(10, 20);
            this.commandButton_sampleAccelAxisAt1g.Name = "commandButton_sampleAccelAxisAt1g";
            this.commandButton_sampleAccelAxisAt1g.Size = new System.Drawing.Size(147, 23);
            this.commandButton_sampleAccelAxisAt1g.TabIndex = 0;
            this.commandButton_sampleAccelAxisAt1g.Text = "Sample Accel. Axis @ ±1 g";
            this.commandButton_sampleAccelAxisAt1g.UseVisualStyleBackColor = true;
            this.commandButton_sampleAccelAxisAt1g.Click += new System.EventHandler(this.commandButton_Click);
            // 
            // groupBox_gyroscopeCalibration
            // 
            this.groupBox_gyroscopeCalibration.Controls.Add(this.commandButton_calcGyroBiasParameters);
            this.groupBox_gyroscopeCalibration.Controls.Add(this.commandButton_sampleGyroAt200dps);
            this.groupBox_gyroscopeCalibration.Controls.Add(this.commandButton_sampleGyroBiasAtT2);
            this.groupBox_gyroscopeCalibration.Controls.Add(this.commandButton_calculateGyroSensitivity);
            this.groupBox_gyroscopeCalibration.Controls.Add(this.commandButtonbutton_sampleGyroBiasAtT1);
            this.groupBox_gyroscopeCalibration.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_gyroscopeCalibration.Location = new System.Drawing.Point(3, 62);
            this.groupBox_gyroscopeCalibration.Name = "groupBox_gyroscopeCalibration";
            this.groupBox_gyroscopeCalibration.Size = new System.Drawing.Size(826, 59);
            this.groupBox_gyroscopeCalibration.TabIndex = 1;
            this.groupBox_gyroscopeCalibration.TabStop = false;
            this.groupBox_gyroscopeCalibration.Text = "Gyroscope Calibration";
            // 
            // commandButton_calcGyroBiasParameters
            // 
            this.commandButton_calcGyroBiasParameters.CommandCode = x_IMU_API.CommandCodes.CalculateGyroscopeBiasParameters;
            this.commandButton_calcGyroBiasParameters.Location = new System.Drawing.Point(622, 20);
            this.commandButton_calcGyroBiasParameters.Name = "commandButton_calcGyroBiasParameters";
            this.commandButton_calcGyroBiasParameters.Size = new System.Drawing.Size(147, 23);
            this.commandButton_calcGyroBiasParameters.TabIndex = 4;
            this.commandButton_calcGyroBiasParameters.Text = "Calc. Gyro. Bias Parameters";
            this.commandButton_calcGyroBiasParameters.UseVisualStyleBackColor = true;
            this.commandButton_calcGyroBiasParameters.Click += new System.EventHandler(this.commandButton_Click);
            // 
            // commandButton_sampleGyroAt200dps
            // 
            this.commandButton_sampleGyroAt200dps.CommandCode = x_IMU_API.CommandCodes.SampleGyroscopeAxisAt200dps;
            this.commandButton_sampleGyroAt200dps.Location = new System.Drawing.Point(10, 20);
            this.commandButton_sampleGyroAt200dps.Name = "commandButton_sampleGyroAt200dps";
            this.commandButton_sampleGyroAt200dps.Size = new System.Drawing.Size(147, 23);
            this.commandButton_sampleGyroAt200dps.TabIndex = 0;
            this.commandButton_sampleGyroAt200dps.Text = "Sample Gyro. @ ±200 ˚/s";
            this.commandButton_sampleGyroAt200dps.UseVisualStyleBackColor = true;
            this.commandButton_sampleGyroAt200dps.Click += new System.EventHandler(this.commandButton_Click);
            // 
            // commandButton_sampleGyroBiasAtT2
            // 
            this.commandButton_sampleGyroBiasAtT2.CommandCode = x_IMU_API.CommandCodes.SampleGyroscopeBiasTemp2;
            this.commandButton_sampleGyroBiasAtT2.Location = new System.Drawing.Point(469, 20);
            this.commandButton_sampleGyroBiasAtT2.Name = "commandButton_sampleGyroBiasAtT2";
            this.commandButton_sampleGyroBiasAtT2.Size = new System.Drawing.Size(147, 23);
            this.commandButton_sampleGyroBiasAtT2.TabIndex = 3;
            this.commandButton_sampleGyroBiasAtT2.Text = "Sample Gyro. Bias @ T2";
            this.commandButton_sampleGyroBiasAtT2.UseVisualStyleBackColor = true;
            this.commandButton_sampleGyroBiasAtT2.Click += new System.EventHandler(this.commandButton_Click);
            // 
            // commandButton_calculateGyroSensitivity
            // 
            this.commandButton_calculateGyroSensitivity.CommandCode = x_IMU_API.CommandCodes.CalculateGyroscopeSensitivity;
            this.commandButton_calculateGyroSensitivity.Location = new System.Drawing.Point(163, 20);
            this.commandButton_calculateGyroSensitivity.Name = "commandButton_calculateGyroSensitivity";
            this.commandButton_calculateGyroSensitivity.Size = new System.Drawing.Size(147, 23);
            this.commandButton_calculateGyroSensitivity.TabIndex = 1;
            this.commandButton_calculateGyroSensitivity.Text = "Calculate Gyro. Sensitivity";
            this.commandButton_calculateGyroSensitivity.UseVisualStyleBackColor = true;
            this.commandButton_calculateGyroSensitivity.Click += new System.EventHandler(this.commandButton_Click);
            // 
            // commandButtonbutton_sampleGyroBiasAtT1
            // 
            this.commandButtonbutton_sampleGyroBiasAtT1.CommandCode = x_IMU_API.CommandCodes.SampleGyroscopeBiasTemp1;
            this.commandButtonbutton_sampleGyroBiasAtT1.Location = new System.Drawing.Point(316, 20);
            this.commandButtonbutton_sampleGyroBiasAtT1.Name = "commandButtonbutton_sampleGyroBiasAtT1";
            this.commandButtonbutton_sampleGyroBiasAtT1.Size = new System.Drawing.Size(147, 23);
            this.commandButtonbutton_sampleGyroBiasAtT1.TabIndex = 2;
            this.commandButtonbutton_sampleGyroBiasAtT1.Text = "Sample Gyro. Bias @ T1";
            this.commandButtonbutton_sampleGyroBiasAtT1.UseVisualStyleBackColor = true;
            this.commandButtonbutton_sampleGyroBiasAtT1.Click += new System.EventHandler(this.commandButton_Click);
            // 
            // groupBox_general
            // 
            this.groupBox_general.Controls.Add(this.commandButton_resetSleepTimer);
            this.groupBox_general.Controls.Add(this.commandButton_sleep);
            this.groupBox_general.Controls.Add(this.commandButton_reset);
            this.groupBox_general.Controls.Add(this.commandButton_factoryReset);
            this.groupBox_general.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_general.Location = new System.Drawing.Point(3, 3);
            this.groupBox_general.Name = "groupBox_general";
            this.groupBox_general.Size = new System.Drawing.Size(826, 59);
            this.groupBox_general.TabIndex = 0;
            this.groupBox_general.TabStop = false;
            this.groupBox_general.Text = "General";
            // 
            // commandButton_resetSleepTimer
            // 
            this.commandButton_resetSleepTimer.CommandCode = x_IMU_API.CommandCodes.ResetSleepTimer;
            this.commandButton_resetSleepTimer.Location = new System.Drawing.Point(469, 20);
            this.commandButton_resetSleepTimer.Name = "commandButton_resetSleepTimer";
            this.commandButton_resetSleepTimer.Size = new System.Drawing.Size(147, 23);
            this.commandButton_resetSleepTimer.TabIndex = 3;
            this.commandButton_resetSleepTimer.Text = "Reset Sleep Timer";
            this.commandButton_resetSleepTimer.UseVisualStyleBackColor = true;
            this.commandButton_resetSleepTimer.Click += new System.EventHandler(this.commandButton_Click);
            // 
            // commandButton_sleep
            // 
            this.commandButton_sleep.CommandCode = x_IMU_API.CommandCodes.Sleep;
            this.commandButton_sleep.Location = new System.Drawing.Point(316, 20);
            this.commandButton_sleep.Name = "commandButton_sleep";
            this.commandButton_sleep.Size = new System.Drawing.Size(147, 23);
            this.commandButton_sleep.TabIndex = 2;
            this.commandButton_sleep.Text = "Sleep";
            this.commandButton_sleep.UseVisualStyleBackColor = true;
            this.commandButton_sleep.Click += new System.EventHandler(this.commandButton_Click);
            // 
            // commandButton_reset
            // 
            this.commandButton_reset.CommandCode = x_IMU_API.CommandCodes.Reset;
            this.commandButton_reset.Location = new System.Drawing.Point(163, 20);
            this.commandButton_reset.Name = "commandButton_reset";
            this.commandButton_reset.Size = new System.Drawing.Size(147, 23);
            this.commandButton_reset.TabIndex = 1;
            this.commandButton_reset.Text = "Reset";
            this.commandButton_reset.UseVisualStyleBackColor = true;
            this.commandButton_reset.Click += new System.EventHandler(this.commandButton_Click);
            this.commandButton_reset.MouseClick += new System.Windows.Forms.MouseEventHandler(this.commandButton_Click);
            // 
            // commandButton_factoryReset
            // 
            this.commandButton_factoryReset.CommandCode = x_IMU_API.CommandCodes.FactoryReset;
            this.commandButton_factoryReset.Location = new System.Drawing.Point(10, 20);
            this.commandButton_factoryReset.Name = "commandButton_factoryReset";
            this.commandButton_factoryReset.Size = new System.Drawing.Size(147, 23);
            this.commandButton_factoryReset.TabIndex = 0;
            this.commandButton_factoryReset.Text = "Factory Reset";
            this.commandButton_factoryReset.UseVisualStyleBackColor = true;
            this.commandButton_factoryReset.Click += new System.EventHandler(this.commandButton_Click);
            // 
            // tabPage_viewSensorData
            // 
            this.tabPage_viewSensorData.AutoScroll = true;
            this.tabPage_viewSensorData.Controls.Add(this.groupBox_orientationData);
            this.tabPage_viewSensorData.Controls.Add(this.groupBox_inertialAndMagneticData);
            this.tabPage_viewSensorData.Controls.Add(this.groupBox_batteryAndThermometerData);
            this.tabPage_viewSensorData.Location = new System.Drawing.Point(4, 22);
            this.tabPage_viewSensorData.Name = "tabPage_viewSensorData";
            this.tabPage_viewSensorData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_viewSensorData.Size = new System.Drawing.Size(832, 410);
            this.tabPage_viewSensorData.TabIndex = 3;
            this.tabPage_viewSensorData.Text = "View Sensor Data";
            this.tabPage_viewSensorData.UseVisualStyleBackColor = true;
            // 
            // groupBox_orientationData
            // 
            this.groupBox_orientationData.Controls.Add(this.showHideButton_eulerAnglesGraph);
            this.groupBox_orientationData.Controls.Add(this.showHideButton_3Dcuboid);
            this.groupBox_orientationData.Controls.Add(this.label_orientationDataLegendPsi);
            this.groupBox_orientationData.Controls.Add(this.label_orientationDataLegendTheta);
            this.groupBox_orientationData.Controls.Add(this.label_orientationDataLegendPhi);
            this.groupBox_orientationData.Controls.Add(this.label_orientationDataLegend);
            this.groupBox_orientationData.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_orientationData.Location = new System.Drawing.Point(3, 121);
            this.groupBox_orientationData.Name = "groupBox_orientationData";
            this.groupBox_orientationData.Size = new System.Drawing.Size(826, 59);
            this.groupBox_orientationData.TabIndex = 2;
            this.groupBox_orientationData.TabStop = false;
            this.groupBox_orientationData.Text = "Orientation Data";
            // 
            // showHideButton_eulerAnglesGraph
            // 
            this.showHideButton_eulerAnglesGraph.FalsePrefixText = "Show ";
            this.showHideButton_eulerAnglesGraph.Location = new System.Drawing.Point(163, 20);
            this.showHideButton_eulerAnglesGraph.Name = "showHideButton_eulerAnglesGraph";
            this.showHideButton_eulerAnglesGraph.Object = null;
            this.showHideButton_eulerAnglesGraph.Size = new System.Drawing.Size(147, 23);
            this.showHideButton_eulerAnglesGraph.SuffixText = "Euler Anlges Graph";
            this.showHideButton_eulerAnglesGraph.TabIndex = 1;
            this.showHideButton_eulerAnglesGraph.Text = "Show Euler Anlges Graph";
            this.showHideButton_eulerAnglesGraph.ToggleState = false;
            this.showHideButton_eulerAnglesGraph.TruePrefixText = "Hide ";
            this.showHideButton_eulerAnglesGraph.UseVisualStyleBackColor = true;
            // 
            // showHideButton_3Dcuboid
            // 
            this.showHideButton_3Dcuboid.FalsePrefixText = "Show ";
            this.showHideButton_3Dcuboid.Location = new System.Drawing.Point(10, 20);
            this.showHideButton_3Dcuboid.Name = "showHideButton_3Dcuboid";
            this.showHideButton_3Dcuboid.Object = null;
            this.showHideButton_3Dcuboid.Size = new System.Drawing.Size(147, 23);
            this.showHideButton_3Dcuboid.SuffixText = "3D Cuboid";
            this.showHideButton_3Dcuboid.TabIndex = 0;
            this.showHideButton_3Dcuboid.Text = "Show 3D Cuboid";
            this.showHideButton_3Dcuboid.ToggleState = false;
            this.showHideButton_3Dcuboid.TruePrefixText = "Hide ";
            this.showHideButton_3Dcuboid.UseVisualStyleBackColor = true;
            // 
            // label_orientationDataLegendPsi
            // 
            this.label_orientationDataLegendPsi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_orientationDataLegendPsi.AutoSize = true;
            this.label_orientationDataLegendPsi.ForeColor = System.Drawing.Color.Blue;
            this.label_orientationDataLegendPsi.Location = new System.Drawing.Point(801, 24);
            this.label_orientationDataLegendPsi.Name = "label_orientationDataLegendPsi";
            this.label_orientationDataLegendPsi.Size = new System.Drawing.Size(15, 13);
            this.label_orientationDataLegendPsi.TabIndex = 45;
            this.label_orientationDataLegendPsi.Text = "ψ";
            // 
            // label_orientationDataLegendTheta
            // 
            this.label_orientationDataLegendTheta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_orientationDataLegendTheta.AutoSize = true;
            this.label_orientationDataLegendTheta.ForeColor = System.Drawing.Color.Lime;
            this.label_orientationDataLegendTheta.Location = new System.Drawing.Point(782, 24);
            this.label_orientationDataLegendTheta.Name = "label_orientationDataLegendTheta";
            this.label_orientationDataLegendTheta.Size = new System.Drawing.Size(13, 13);
            this.label_orientationDataLegendTheta.TabIndex = 44;
            this.label_orientationDataLegendTheta.Text = "θ";
            // 
            // label_orientationDataLegendPhi
            // 
            this.label_orientationDataLegendPhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_orientationDataLegendPhi.AutoSize = true;
            this.label_orientationDataLegendPhi.ForeColor = System.Drawing.Color.Red;
            this.label_orientationDataLegendPhi.Location = new System.Drawing.Point(761, 24);
            this.label_orientationDataLegendPhi.Name = "label_orientationDataLegendPhi";
            this.label_orientationDataLegendPhi.Size = new System.Drawing.Size(15, 13);
            this.label_orientationDataLegendPhi.TabIndex = 43;
            this.label_orientationDataLegendPhi.Text = "φ";
            // 
            // label_orientationDataLegend
            // 
            this.label_orientationDataLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_orientationDataLegend.AutoSize = true;
            this.label_orientationDataLegend.Location = new System.Drawing.Point(709, 24);
            this.label_orientationDataLegend.Name = "label_orientationDataLegend";
            this.label_orientationDataLegend.Size = new System.Drawing.Size(46, 13);
            this.label_orientationDataLegend.TabIndex = 42;
            this.label_orientationDataLegend.Text = "Legend:";
            // 
            // groupBox_inertialAndMagneticData
            // 
            this.groupBox_inertialAndMagneticData.Controls.Add(this.showHideButton_magnetometerGraph);
            this.groupBox_inertialAndMagneticData.Controls.Add(this.showHideButton_accelerometerGraph);
            this.groupBox_inertialAndMagneticData.Controls.Add(this.showHideButton_gyroscopeGraph);
            this.groupBox_inertialAndMagneticData.Controls.Add(this.label_inertialAndMagneticDataZ);
            this.groupBox_inertialAndMagneticData.Controls.Add(this.label_inertialAndMagneticDataY);
            this.groupBox_inertialAndMagneticData.Controls.Add(this.label_inertialAndMagneticDataX);
            this.groupBox_inertialAndMagneticData.Controls.Add(this.label_inertialAndMagneticDataLegend);
            this.groupBox_inertialAndMagneticData.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_inertialAndMagneticData.Location = new System.Drawing.Point(3, 62);
            this.groupBox_inertialAndMagneticData.Name = "groupBox_inertialAndMagneticData";
            this.groupBox_inertialAndMagneticData.Size = new System.Drawing.Size(826, 59);
            this.groupBox_inertialAndMagneticData.TabIndex = 1;
            this.groupBox_inertialAndMagneticData.TabStop = false;
            this.groupBox_inertialAndMagneticData.Text = "Inertial And Magnetic Sensor Data";
            // 
            // showHideButton_magnetometerGraph
            // 
            this.showHideButton_magnetometerGraph.FalsePrefixText = "Show ";
            this.showHideButton_magnetometerGraph.Location = new System.Drawing.Point(316, 20);
            this.showHideButton_magnetometerGraph.Name = "showHideButton_magnetometerGraph";
            this.showHideButton_magnetometerGraph.Object = null;
            this.showHideButton_magnetometerGraph.Size = new System.Drawing.Size(147, 23);
            this.showHideButton_magnetometerGraph.SuffixText = "Magnetometer Graph";
            this.showHideButton_magnetometerGraph.TabIndex = 2;
            this.showHideButton_magnetometerGraph.Text = "Show Magnetometer Graph";
            this.showHideButton_magnetometerGraph.ToggleState = false;
            this.showHideButton_magnetometerGraph.TruePrefixText = "Hide ";
            this.showHideButton_magnetometerGraph.UseVisualStyleBackColor = true;
            // 
            // showHideButton_accelerometerGraph
            // 
            this.showHideButton_accelerometerGraph.FalsePrefixText = "Show ";
            this.showHideButton_accelerometerGraph.Location = new System.Drawing.Point(163, 20);
            this.showHideButton_accelerometerGraph.Name = "showHideButton_accelerometerGraph";
            this.showHideButton_accelerometerGraph.Object = null;
            this.showHideButton_accelerometerGraph.Size = new System.Drawing.Size(147, 23);
            this.showHideButton_accelerometerGraph.SuffixText = "Accelerometer Graph";
            this.showHideButton_accelerometerGraph.TabIndex = 1;
            this.showHideButton_accelerometerGraph.Text = "Show Accelerometer Graph";
            this.showHideButton_accelerometerGraph.ToggleState = false;
            this.showHideButton_accelerometerGraph.TruePrefixText = "Hide ";
            this.showHideButton_accelerometerGraph.UseVisualStyleBackColor = true;
            // 
            // showHideButton_gyroscopeGraph
            // 
            this.showHideButton_gyroscopeGraph.FalsePrefixText = "Show ";
            this.showHideButton_gyroscopeGraph.Location = new System.Drawing.Point(10, 20);
            this.showHideButton_gyroscopeGraph.Name = "showHideButton_gyroscopeGraph";
            this.showHideButton_gyroscopeGraph.Object = null;
            this.showHideButton_gyroscopeGraph.Size = new System.Drawing.Size(147, 23);
            this.showHideButton_gyroscopeGraph.SuffixText = "Gyroscope Graph";
            this.showHideButton_gyroscopeGraph.TabIndex = 0;
            this.showHideButton_gyroscopeGraph.Text = "Show Gyroscope Graph";
            this.showHideButton_gyroscopeGraph.ToggleState = false;
            this.showHideButton_gyroscopeGraph.TruePrefixText = "Hide ";
            this.showHideButton_gyroscopeGraph.UseVisualStyleBackColor = true;
            // 
            // label_inertialAndMagneticDataZ
            // 
            this.label_inertialAndMagneticDataZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_inertialAndMagneticDataZ.AutoSize = true;
            this.label_inertialAndMagneticDataZ.ForeColor = System.Drawing.Color.Blue;
            this.label_inertialAndMagneticDataZ.Location = new System.Drawing.Point(802, 25);
            this.label_inertialAndMagneticDataZ.Name = "label_inertialAndMagneticDataZ";
            this.label_inertialAndMagneticDataZ.Size = new System.Drawing.Size(14, 13);
            this.label_inertialAndMagneticDataZ.TabIndex = 41;
            this.label_inertialAndMagneticDataZ.Text = "Z";
            // 
            // label_inertialAndMagneticDataY
            // 
            this.label_inertialAndMagneticDataY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_inertialAndMagneticDataY.AutoSize = true;
            this.label_inertialAndMagneticDataY.ForeColor = System.Drawing.Color.Lime;
            this.label_inertialAndMagneticDataY.Location = new System.Drawing.Point(782, 25);
            this.label_inertialAndMagneticDataY.Name = "label_inertialAndMagneticDataY";
            this.label_inertialAndMagneticDataY.Size = new System.Drawing.Size(14, 13);
            this.label_inertialAndMagneticDataY.TabIndex = 40;
            this.label_inertialAndMagneticDataY.Text = "Y";
            // 
            // label_inertialAndMagneticDataX
            // 
            this.label_inertialAndMagneticDataX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_inertialAndMagneticDataX.AutoSize = true;
            this.label_inertialAndMagneticDataX.ForeColor = System.Drawing.Color.Red;
            this.label_inertialAndMagneticDataX.Location = new System.Drawing.Point(762, 25);
            this.label_inertialAndMagneticDataX.Name = "label_inertialAndMagneticDataX";
            this.label_inertialAndMagneticDataX.Size = new System.Drawing.Size(14, 13);
            this.label_inertialAndMagneticDataX.TabIndex = 39;
            this.label_inertialAndMagneticDataX.Text = "X";
            // 
            // label_inertialAndMagneticDataLegend
            // 
            this.label_inertialAndMagneticDataLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_inertialAndMagneticDataLegend.AutoSize = true;
            this.label_inertialAndMagneticDataLegend.Location = new System.Drawing.Point(710, 25);
            this.label_inertialAndMagneticDataLegend.Name = "label_inertialAndMagneticDataLegend";
            this.label_inertialAndMagneticDataLegend.Size = new System.Drawing.Size(46, 13);
            this.label_inertialAndMagneticDataLegend.TabIndex = 38;
            this.label_inertialAndMagneticDataLegend.Text = "Legend:";
            // 
            // groupBox_batteryAndThermometerData
            // 
            this.groupBox_batteryAndThermometerData.Controls.Add(this.showHideButton_thermometerGraph);
            this.groupBox_batteryAndThermometerData.Controls.Add(this.showHideButton_batteryGraph);
            this.groupBox_batteryAndThermometerData.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_batteryAndThermometerData.Location = new System.Drawing.Point(3, 3);
            this.groupBox_batteryAndThermometerData.Name = "groupBox_batteryAndThermometerData";
            this.groupBox_batteryAndThermometerData.Size = new System.Drawing.Size(826, 59);
            this.groupBox_batteryAndThermometerData.TabIndex = 0;
            this.groupBox_batteryAndThermometerData.TabStop = false;
            this.groupBox_batteryAndThermometerData.Text = "Battery And Thermometer Data";
            // 
            // showHideButton_thermometerGraph
            // 
            this.showHideButton_thermometerGraph.FalsePrefixText = "Show ";
            this.showHideButton_thermometerGraph.Location = new System.Drawing.Point(163, 20);
            this.showHideButton_thermometerGraph.Name = "showHideButton_thermometerGraph";
            this.showHideButton_thermometerGraph.Object = null;
            this.showHideButton_thermometerGraph.Size = new System.Drawing.Size(147, 23);
            this.showHideButton_thermometerGraph.SuffixText = "Thermometer Graph";
            this.showHideButton_thermometerGraph.TabIndex = 1;
            this.showHideButton_thermometerGraph.Text = "Show Thermometer Graph";
            this.showHideButton_thermometerGraph.ToggleState = false;
            this.showHideButton_thermometerGraph.TruePrefixText = "Hide ";
            this.showHideButton_thermometerGraph.UseVisualStyleBackColor = true;
            // 
            // showHideButton_batteryGraph
            // 
            this.showHideButton_batteryGraph.FalsePrefixText = "Show ";
            this.showHideButton_batteryGraph.Location = new System.Drawing.Point(10, 20);
            this.showHideButton_batteryGraph.Name = "showHideButton_batteryGraph";
            this.showHideButton_batteryGraph.Object = null;
            this.showHideButton_batteryGraph.Size = new System.Drawing.Size(147, 23);
            this.showHideButton_batteryGraph.SuffixText = "Battery Graph";
            this.showHideButton_batteryGraph.TabIndex = 0;
            this.showHideButton_batteryGraph.Text = "Show Battery Graph";
            this.showHideButton_batteryGraph.ToggleState = false;
            this.showHideButton_batteryGraph.TruePrefixText = "Hide ";
            this.showHideButton_batteryGraph.UseVisualStyleBackColor = true;
            // 
            // tabPage_auxillaryPort
            // 
            this.tabPage_auxillaryPort.Controls.Add(this.groupBox_ADXL345bus);
            this.tabPage_auxillaryPort.Controls.Add(this.groupBox_PWMoutput);
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
            this.groupBox_ADXL345bus.Controls.Add(this.label_ADXL345busZ);
            this.groupBox_ADXL345bus.Controls.Add(this.label_ADXL345busY);
            this.groupBox_ADXL345bus.Controls.Add(this.label_ADXL345busX);
            this.groupBox_ADXL345bus.Controls.Add(this.label_ADXL345busLegend);
            this.groupBox_ADXL345bus.Controls.Add(this.showHideButton_ADXL345Dgraph);
            this.groupBox_ADXL345bus.Controls.Add(this.showHideButton_ADXL345Agraph);
            this.groupBox_ADXL345bus.Controls.Add(this.showHideButton_ADXL345Bgraph);
            this.groupBox_ADXL345bus.Controls.Add(this.showHideButton_ADXL345Cgraph);
            this.groupBox_ADXL345bus.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_ADXL345bus.Location = new System.Drawing.Point(3, 180);
            this.groupBox_ADXL345bus.Name = "groupBox_ADXL345bus";
            this.groupBox_ADXL345bus.Size = new System.Drawing.Size(826, 59);
            this.groupBox_ADXL345bus.TabIndex = 3;
            this.groupBox_ADXL345bus.TabStop = false;
            this.groupBox_ADXL345bus.Text = "AXDL345 Bus";
            // 
            // label_ADXL345busZ
            // 
            this.label_ADXL345busZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ADXL345busZ.AutoSize = true;
            this.label_ADXL345busZ.ForeColor = System.Drawing.Color.Blue;
            this.label_ADXL345busZ.Location = new System.Drawing.Point(806, 25);
            this.label_ADXL345busZ.Name = "label_ADXL345busZ";
            this.label_ADXL345busZ.Size = new System.Drawing.Size(14, 13);
            this.label_ADXL345busZ.TabIndex = 45;
            this.label_ADXL345busZ.Text = "Z";
            // 
            // label_ADXL345busY
            // 
            this.label_ADXL345busY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ADXL345busY.AutoSize = true;
            this.label_ADXL345busY.ForeColor = System.Drawing.Color.Lime;
            this.label_ADXL345busY.Location = new System.Drawing.Point(786, 25);
            this.label_ADXL345busY.Name = "label_ADXL345busY";
            this.label_ADXL345busY.Size = new System.Drawing.Size(14, 13);
            this.label_ADXL345busY.TabIndex = 44;
            this.label_ADXL345busY.Text = "Y";
            // 
            // label_ADXL345busX
            // 
            this.label_ADXL345busX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ADXL345busX.AutoSize = true;
            this.label_ADXL345busX.ForeColor = System.Drawing.Color.Red;
            this.label_ADXL345busX.Location = new System.Drawing.Point(766, 25);
            this.label_ADXL345busX.Name = "label_ADXL345busX";
            this.label_ADXL345busX.Size = new System.Drawing.Size(14, 13);
            this.label_ADXL345busX.TabIndex = 43;
            this.label_ADXL345busX.Text = "X";
            // 
            // label_ADXL345busLegend
            // 
            this.label_ADXL345busLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ADXL345busLegend.AutoSize = true;
            this.label_ADXL345busLegend.Location = new System.Drawing.Point(714, 25);
            this.label_ADXL345busLegend.Name = "label_ADXL345busLegend";
            this.label_ADXL345busLegend.Size = new System.Drawing.Size(46, 13);
            this.label_ADXL345busLegend.TabIndex = 42;
            this.label_ADXL345busLegend.Text = "Legend:";
            // 
            // showHideButton_ADXL345Dgraph
            // 
            this.showHideButton_ADXL345Dgraph.FalsePrefixText = "Show ";
            this.showHideButton_ADXL345Dgraph.Location = new System.Drawing.Point(469, 20);
            this.showHideButton_ADXL345Dgraph.Name = "showHideButton_ADXL345Dgraph";
            this.showHideButton_ADXL345Dgraph.Object = null;
            this.showHideButton_ADXL345Dgraph.Size = new System.Drawing.Size(147, 23);
            this.showHideButton_ADXL345Dgraph.SuffixText = "ADXL345 D Graph";
            this.showHideButton_ADXL345Dgraph.TabIndex = 11;
            this.showHideButton_ADXL345Dgraph.Text = "Show ADXL345 D Graph";
            this.showHideButton_ADXL345Dgraph.ToggleState = false;
            this.showHideButton_ADXL345Dgraph.TruePrefixText = "Hide ";
            this.showHideButton_ADXL345Dgraph.UseVisualStyleBackColor = true;
            // 
            // showHideButton_ADXL345Agraph
            // 
            this.showHideButton_ADXL345Agraph.FalsePrefixText = "Show ";
            this.showHideButton_ADXL345Agraph.Location = new System.Drawing.Point(10, 20);
            this.showHideButton_ADXL345Agraph.Name = "showHideButton_ADXL345Agraph";
            this.showHideButton_ADXL345Agraph.Object = null;
            this.showHideButton_ADXL345Agraph.Size = new System.Drawing.Size(147, 23);
            this.showHideButton_ADXL345Agraph.SuffixText = "ADXL345 A Graph";
            this.showHideButton_ADXL345Agraph.TabIndex = 8;
            this.showHideButton_ADXL345Agraph.Text = "Show ADXL345 A Graph";
            this.showHideButton_ADXL345Agraph.ToggleState = false;
            this.showHideButton_ADXL345Agraph.TruePrefixText = "Hide ";
            this.showHideButton_ADXL345Agraph.UseVisualStyleBackColor = true;
            // 
            // showHideButton_ADXL345Bgraph
            // 
            this.showHideButton_ADXL345Bgraph.FalsePrefixText = "Show ";
            this.showHideButton_ADXL345Bgraph.Location = new System.Drawing.Point(163, 20);
            this.showHideButton_ADXL345Bgraph.Name = "showHideButton_ADXL345Bgraph";
            this.showHideButton_ADXL345Bgraph.Object = null;
            this.showHideButton_ADXL345Bgraph.Size = new System.Drawing.Size(147, 23);
            this.showHideButton_ADXL345Bgraph.SuffixText = "ADXL345 B Graph";
            this.showHideButton_ADXL345Bgraph.TabIndex = 9;
            this.showHideButton_ADXL345Bgraph.Text = "Show ADXL345 B Graph";
            this.showHideButton_ADXL345Bgraph.ToggleState = false;
            this.showHideButton_ADXL345Bgraph.TruePrefixText = "Hide ";
            this.showHideButton_ADXL345Bgraph.UseVisualStyleBackColor = true;
            // 
            // showHideButton_ADXL345Cgraph
            // 
            this.showHideButton_ADXL345Cgraph.FalsePrefixText = "Show ";
            this.showHideButton_ADXL345Cgraph.Location = new System.Drawing.Point(316, 20);
            this.showHideButton_ADXL345Cgraph.Name = "showHideButton_ADXL345Cgraph";
            this.showHideButton_ADXL345Cgraph.Object = null;
            this.showHideButton_ADXL345Cgraph.Size = new System.Drawing.Size(147, 23);
            this.showHideButton_ADXL345Cgraph.SuffixText = "ADXL345 C Graph";
            this.showHideButton_ADXL345Cgraph.TabIndex = 10;
            this.showHideButton_ADXL345Cgraph.Text = "Show ADXL345 C Graph";
            this.showHideButton_ADXL345Cgraph.ToggleState = false;
            this.showHideButton_ADXL345Cgraph.TruePrefixText = "Hide ";
            this.showHideButton_ADXL345Cgraph.UseVisualStyleBackColor = true;
            // 
            // groupBox_PWMoutput
            // 
            this.groupBox_PWMoutput.Controls.Add(this.showHideButton_PWMoutputPanel);
            this.groupBox_PWMoutput.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_PWMoutput.Location = new System.Drawing.Point(3, 121);
            this.groupBox_PWMoutput.Name = "groupBox_PWMoutput";
            this.groupBox_PWMoutput.Size = new System.Drawing.Size(826, 59);
            this.groupBox_PWMoutput.TabIndex = 2;
            this.groupBox_PWMoutput.TabStop = false;
            this.groupBox_PWMoutput.Text = "PWM Output";
            // 
            // showHideButton_PWMoutputPanel
            // 
            this.showHideButton_PWMoutputPanel.FalsePrefixText = "Show ";
            this.showHideButton_PWMoutputPanel.Location = new System.Drawing.Point(10, 20);
            this.showHideButton_PWMoutputPanel.Name = "showHideButton_PWMoutputPanel";
            this.showHideButton_PWMoutputPanel.Object = null;
            this.showHideButton_PWMoutputPanel.Size = new System.Drawing.Size(147, 23);
            this.showHideButton_PWMoutputPanel.SuffixText = "PWM Output Panel";
            this.showHideButton_PWMoutputPanel.TabIndex = 5;
            this.showHideButton_PWMoutputPanel.Text = "Show PWM Output Panel";
            this.showHideButton_PWMoutputPanel.ToggleState = false;
            this.showHideButton_PWMoutputPanel.TruePrefixText = "Hide ";
            this.showHideButton_PWMoutputPanel.UseVisualStyleBackColor = true;
            // 
            // groupBox_analogueInput
            // 
            this.groupBox_analogueInput.Controls.Add(this.label_analogueInputAX0246);
            this.groupBox_analogueInput.Controls.Add(this.label_analogueInputAX1357);
            this.groupBox_analogueInput.Controls.Add(this.label_analogueInputLegend);
            this.groupBox_analogueInput.Controls.Add(this.showHideButton_AX6andAX7graph);
            this.groupBox_analogueInput.Controls.Add(this.showHideButton_AX0andAX1graph);
            this.groupBox_analogueInput.Controls.Add(this.showHideButton_AX4andAX5graph);
            this.groupBox_analogueInput.Controls.Add(this.showHideButton_AX2andAX3graph);
            this.groupBox_analogueInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_analogueInput.Location = new System.Drawing.Point(3, 62);
            this.groupBox_analogueInput.Name = "groupBox_analogueInput";
            this.groupBox_analogueInput.Size = new System.Drawing.Size(826, 59);
            this.groupBox_analogueInput.TabIndex = 1;
            this.groupBox_analogueInput.TabStop = false;
            this.groupBox_analogueInput.Text = "Analogue Input";
            // 
            // label_analogueInputAX0246
            // 
            this.label_analogueInputAX0246.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_analogueInputAX0246.AutoSize = true;
            this.label_analogueInputAX0246.ForeColor = System.Drawing.Color.Red;
            this.label_analogueInputAX0246.Location = new System.Drawing.Point(706, 25);
            this.label_analogueInputAX0246.Name = "label_analogueInputAX0246";
            this.label_analogueInputAX0246.Size = new System.Drawing.Size(54, 13);
            this.label_analogueInputAX0246.TabIndex = 48;
            this.label_analogueInputAX0246.Text = "AX0,2,4,6";
            // 
            // label_analogueInputAX1357
            // 
            this.label_analogueInputAX1357.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_analogueInputAX1357.AutoSize = true;
            this.label_analogueInputAX1357.ForeColor = System.Drawing.Color.Blue;
            this.label_analogueInputAX1357.Location = new System.Drawing.Point(766, 25);
            this.label_analogueInputAX1357.Name = "label_analogueInputAX1357";
            this.label_analogueInputAX1357.Size = new System.Drawing.Size(54, 13);
            this.label_analogueInputAX1357.TabIndex = 47;
            this.label_analogueInputAX1357.Text = "AX1,3,5,7";
            // 
            // label_analogueInputLegend
            // 
            this.label_analogueInputLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_analogueInputLegend.AutoSize = true;
            this.label_analogueInputLegend.Location = new System.Drawing.Point(654, 25);
            this.label_analogueInputLegend.Name = "label_analogueInputLegend";
            this.label_analogueInputLegend.Size = new System.Drawing.Size(46, 13);
            this.label_analogueInputLegend.TabIndex = 46;
            this.label_analogueInputLegend.Text = "Legend:";
            // 
            // showHideButton_AX6andAX7graph
            // 
            this.showHideButton_AX6andAX7graph.FalsePrefixText = "Show ";
            this.showHideButton_AX6andAX7graph.Location = new System.Drawing.Point(469, 20);
            this.showHideButton_AX6andAX7graph.Name = "showHideButton_AX6andAX7graph";
            this.showHideButton_AX6andAX7graph.Object = null;
            this.showHideButton_AX6andAX7graph.Size = new System.Drawing.Size(147, 23);
            this.showHideButton_AX6andAX7graph.SuffixText = "AX6 And AX7 Graph";
            this.showHideButton_AX6andAX7graph.TabIndex = 7;
            this.showHideButton_AX6andAX7graph.Text = "Show AX6 And AX7 Graph";
            this.showHideButton_AX6andAX7graph.ToggleState = false;
            this.showHideButton_AX6andAX7graph.TruePrefixText = "Hide ";
            this.showHideButton_AX6andAX7graph.UseVisualStyleBackColor = true;
            // 
            // showHideButton_AX0andAX1graph
            // 
            this.showHideButton_AX0andAX1graph.FalsePrefixText = "Show ";
            this.showHideButton_AX0andAX1graph.Location = new System.Drawing.Point(10, 20);
            this.showHideButton_AX0andAX1graph.Name = "showHideButton_AX0andAX1graph";
            this.showHideButton_AX0andAX1graph.Object = null;
            this.showHideButton_AX0andAX1graph.Size = new System.Drawing.Size(147, 23);
            this.showHideButton_AX0andAX1graph.SuffixText = "AX0 And AX1 Graph";
            this.showHideButton_AX0andAX1graph.TabIndex = 4;
            this.showHideButton_AX0andAX1graph.Text = "Show AX0 And AX1 Graph";
            this.showHideButton_AX0andAX1graph.ToggleState = false;
            this.showHideButton_AX0andAX1graph.TruePrefixText = "Hide ";
            this.showHideButton_AX0andAX1graph.UseVisualStyleBackColor = true;
            // 
            // showHideButton_AX4andAX5graph
            // 
            this.showHideButton_AX4andAX5graph.FalsePrefixText = "Show ";
            this.showHideButton_AX4andAX5graph.Location = new System.Drawing.Point(316, 20);
            this.showHideButton_AX4andAX5graph.Name = "showHideButton_AX4andAX5graph";
            this.showHideButton_AX4andAX5graph.Object = null;
            this.showHideButton_AX4andAX5graph.Size = new System.Drawing.Size(147, 23);
            this.showHideButton_AX4andAX5graph.SuffixText = "AX4 And AX5 Graph";
            this.showHideButton_AX4andAX5graph.TabIndex = 6;
            this.showHideButton_AX4andAX5graph.Text = "Show AX4 And AX5 Graph";
            this.showHideButton_AX4andAX5graph.ToggleState = false;
            this.showHideButton_AX4andAX5graph.TruePrefixText = "Hide ";
            this.showHideButton_AX4andAX5graph.UseVisualStyleBackColor = true;
            // 
            // showHideButton_AX2andAX3graph
            // 
            this.showHideButton_AX2andAX3graph.FalsePrefixText = "Show ";
            this.showHideButton_AX2andAX3graph.Location = new System.Drawing.Point(163, 20);
            this.showHideButton_AX2andAX3graph.Name = "showHideButton_AX2andAX3graph";
            this.showHideButton_AX2andAX3graph.Object = null;
            this.showHideButton_AX2andAX3graph.Size = new System.Drawing.Size(147, 23);
            this.showHideButton_AX2andAX3graph.SuffixText = "AX2 And AX3 Graph";
            this.showHideButton_AX2andAX3graph.TabIndex = 5;
            this.showHideButton_AX2andAX3graph.Text = "Show AX2 And AX3 Graph";
            this.showHideButton_AX2andAX3graph.ToggleState = false;
            this.showHideButton_AX2andAX3graph.TruePrefixText = "Hide ";
            this.showHideButton_AX2andAX3graph.UseVisualStyleBackColor = true;
            // 
            // groupBox_digitalIO
            // 
            this.groupBox_digitalIO.Controls.Add(this.showHideButton_digitalIOpanel);
            this.groupBox_digitalIO.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_digitalIO.Location = new System.Drawing.Point(3, 3);
            this.groupBox_digitalIO.Name = "groupBox_digitalIO";
            this.groupBox_digitalIO.Size = new System.Drawing.Size(826, 59);
            this.groupBox_digitalIO.TabIndex = 0;
            this.groupBox_digitalIO.TabStop = false;
            this.groupBox_digitalIO.Text = "Digital I/O";
            // 
            // showHideButton_digitalIOpanel
            // 
            this.showHideButton_digitalIOpanel.FalsePrefixText = "Show ";
            this.showHideButton_digitalIOpanel.Location = new System.Drawing.Point(10, 20);
            this.showHideButton_digitalIOpanel.Name = "showHideButton_digitalIOpanel";
            this.showHideButton_digitalIOpanel.Object = null;
            this.showHideButton_digitalIOpanel.Size = new System.Drawing.Size(147, 23);
            this.showHideButton_digitalIOpanel.SuffixText = "Digital I/O Panel";
            this.showHideButton_digitalIOpanel.TabIndex = 4;
            this.showHideButton_digitalIOpanel.Text = "Show Digital I/O Panel";
            this.showHideButton_digitalIOpanel.ToggleState = false;
            this.showHideButton_digitalIOpanel.TruePrefixText = "Hide ";
            this.showHideButton_digitalIOpanel.UseVisualStyleBackColor = true;
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
            this.groupBox_logReceivedDataToFile.Controls.Add(this.toggleButton_dataLoggerStartStopLogging);
            this.groupBox_logReceivedDataToFile.Controls.Add(this.button_dataLoggerBrowse);
            this.groupBox_logReceivedDataToFile.Controls.Add(this.label_dataLoggerFilePath);
            this.groupBox_logReceivedDataToFile.Controls.Add(this.textBox_dataLoggerFilePath);
            this.groupBox_logReceivedDataToFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_logReceivedDataToFile.Location = new System.Drawing.Point(3, 3);
            this.groupBox_logReceivedDataToFile.Name = "groupBox_logReceivedDataToFile";
            this.groupBox_logReceivedDataToFile.Size = new System.Drawing.Size(826, 60);
            this.groupBox_logReceivedDataToFile.TabIndex = 0;
            this.groupBox_logReceivedDataToFile.TabStop = false;
            this.groupBox_logReceivedDataToFile.Text = "Log Received Data To File";
            // 
            // toggleButton_dataLoggerStartStopLogging
            // 
            this.toggleButton_dataLoggerStartStopLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleButton_dataLoggerStartStopLogging.FalsePrefixText = "Start ";
            this.toggleButton_dataLoggerStartStopLogging.Location = new System.Drawing.Point(725, 22);
            this.toggleButton_dataLoggerStartStopLogging.Name = "toggleButton_dataLoggerStartStopLogging";
            this.toggleButton_dataLoggerStartStopLogging.Size = new System.Drawing.Size(95, 23);
            this.toggleButton_dataLoggerStartStopLogging.SuffixText = "Logging";
            this.toggleButton_dataLoggerStartStopLogging.TabIndex = 2;
            this.toggleButton_dataLoggerStartStopLogging.Text = "Start Logging";
            this.toggleButton_dataLoggerStartStopLogging.ToggleState = false;
            this.toggleButton_dataLoggerStartStopLogging.TruePrefixText = "Stop ";
            this.toggleButton_dataLoggerStartStopLogging.UseVisualStyleBackColor = true;
            this.toggleButton_dataLoggerStartStopLogging.Click += new System.EventHandler(this.toggleButton_dataLoggerStartStopLogging_Click);
            // 
            // button_dataLoggerBrowse
            // 
            this.button_dataLoggerBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_dataLoggerBrowse.Location = new System.Drawing.Point(624, 22);
            this.button_dataLoggerBrowse.Name = "button_dataLoggerBrowse";
            this.button_dataLoggerBrowse.Size = new System.Drawing.Size(95, 23);
            this.button_dataLoggerBrowse.TabIndex = 1;
            this.button_dataLoggerBrowse.Text = "Browse...";
            this.button_dataLoggerBrowse.UseVisualStyleBackColor = true;
            this.button_dataLoggerBrowse.Click += new System.EventHandler(this.button_dataLoggerBrowse_Click);
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
            // tabPage_SDcard
            // 
            this.tabPage_SDcard.Controls.Add(this.groupBox_binaryFileConverter);
            this.tabPage_SDcard.Location = new System.Drawing.Point(4, 22);
            this.tabPage_SDcard.Name = "tabPage_SDcard";
            this.tabPage_SDcard.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SDcard.Size = new System.Drawing.Size(832, 410);
            this.tabPage_SDcard.TabIndex = 12;
            this.tabPage_SDcard.Text = "SD Card";
            this.tabPage_SDcard.UseVisualStyleBackColor = true;
            // 
            // groupBox_binaryFileConverter
            // 
            this.groupBox_binaryFileConverter.Controls.Add(this.button_convertBinaryFileBrowse);
            this.groupBox_binaryFileConverter.Controls.Add(this.label_convertBinaryFileFilePath);
            this.groupBox_binaryFileConverter.Controls.Add(this.textBox_convertBinaryFileFilePath);
            this.groupBox_binaryFileConverter.Controls.Add(this.button_convertBinaryFileConvert);
            this.groupBox_binaryFileConverter.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_binaryFileConverter.Location = new System.Drawing.Point(3, 3);
            this.groupBox_binaryFileConverter.Name = "groupBox_binaryFileConverter";
            this.groupBox_binaryFileConverter.Size = new System.Drawing.Size(826, 60);
            this.groupBox_binaryFileConverter.TabIndex = 0;
            this.groupBox_binaryFileConverter.TabStop = false;
            this.groupBox_binaryFileConverter.Text = "Binary File Converter";
            // 
            // button_convertBinaryFileBrowse
            // 
            this.button_convertBinaryFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_convertBinaryFileBrowse.Location = new System.Drawing.Point(624, 22);
            this.button_convertBinaryFileBrowse.Name = "button_convertBinaryFileBrowse";
            this.button_convertBinaryFileBrowse.Size = new System.Drawing.Size(95, 23);
            this.button_convertBinaryFileBrowse.TabIndex = 1;
            this.button_convertBinaryFileBrowse.Text = "Browse...";
            this.button_convertBinaryFileBrowse.UseVisualStyleBackColor = true;
            this.button_convertBinaryFileBrowse.Click += new System.EventHandler(this.button_convertBinaryFileBrowse_Click);
            // 
            // label_convertBinaryFileFilePath
            // 
            this.label_convertBinaryFileFilePath.AutoSize = true;
            this.label_convertBinaryFileFilePath.Location = new System.Drawing.Point(8, 27);
            this.label_convertBinaryFileFilePath.Name = "label_convertBinaryFileFilePath";
            this.label_convertBinaryFileFilePath.Size = new System.Drawing.Size(50, 13);
            this.label_convertBinaryFileFilePath.TabIndex = 47;
            this.label_convertBinaryFileFilePath.Text = "File path:";
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
            this.groupBox_step2collectHardIronCalibrationDataSet.Controls.Add(this.toggleButton_collectHardIronCalDatasetStartStopLogging);
            this.groupBox_step2collectHardIronCalibrationDataSet.Controls.Add(this.button_collectHardIronCalDatasetBrowse);
            this.groupBox_step2collectHardIronCalibrationDataSet.Controls.Add(this.label_collectHardIronCalDatasetFilePath);
            this.groupBox_step2collectHardIronCalibrationDataSet.Controls.Add(this.textBox_collectHardIronCalDatasetFilePath);
            this.groupBox_step2collectHardIronCalibrationDataSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_step2collectHardIronCalibrationDataSet.Location = new System.Drawing.Point(3, 63);
            this.groupBox_step2collectHardIronCalibrationDataSet.Name = "groupBox_step2collectHardIronCalibrationDataSet";
            this.groupBox_step2collectHardIronCalibrationDataSet.Size = new System.Drawing.Size(826, 60);
            this.groupBox_step2collectHardIronCalibrationDataSet.TabIndex = 1;
            this.groupBox_step2collectHardIronCalibrationDataSet.TabStop = false;
            this.groupBox_step2collectHardIronCalibrationDataSet.Text = "Step 2 - Collect Hard-Iron Calibration Dataset";
            // 
            // toggleButton_collectHardIronCalDatasetStartStopLogging
            // 
            this.toggleButton_collectHardIronCalDatasetStartStopLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleButton_collectHardIronCalDatasetStartStopLogging.FalsePrefixText = "Start ";
            this.toggleButton_collectHardIronCalDatasetStartStopLogging.Location = new System.Drawing.Point(725, 22);
            this.toggleButton_collectHardIronCalDatasetStartStopLogging.Name = "toggleButton_collectHardIronCalDatasetStartStopLogging";
            this.toggleButton_collectHardIronCalDatasetStartStopLogging.Size = new System.Drawing.Size(95, 23);
            this.toggleButton_collectHardIronCalDatasetStartStopLogging.SuffixText = "Logging";
            this.toggleButton_collectHardIronCalDatasetStartStopLogging.TabIndex = 2;
            this.toggleButton_collectHardIronCalDatasetStartStopLogging.Text = "Start Logging";
            this.toggleButton_collectHardIronCalDatasetStartStopLogging.ToggleState = false;
            this.toggleButton_collectHardIronCalDatasetStartStopLogging.TruePrefixText = "Stop ";
            this.toggleButton_collectHardIronCalDatasetStartStopLogging.UseVisualStyleBackColor = true;
            this.toggleButton_collectHardIronCalDatasetStartStopLogging.Click += new System.EventHandler(this.toggleButton_collectHardIronCalDatasetStartStopLogging_Click);
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
            this.linkLabel_www.TabIndex = 0;
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
            this.groupBox_packetCounters.ResumeLayout(false);
            this.groupBox_packetCounters.PerformLayout();
            this.groupBox_openClosePort.ResumeLayout(false);
            this.groupBox_openClosePort.PerformLayout();
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
            this.tabPage_viewSensorData.ResumeLayout(false);
            this.groupBox_orientationData.ResumeLayout(false);
            this.groupBox_orientationData.PerformLayout();
            this.groupBox_inertialAndMagneticData.ResumeLayout(false);
            this.groupBox_inertialAndMagneticData.PerformLayout();
            this.groupBox_batteryAndThermometerData.ResumeLayout(false);
            this.tabPage_auxillaryPort.ResumeLayout(false);
            this.groupBox_ADXL345bus.ResumeLayout(false);
            this.groupBox_ADXL345bus.PerformLayout();
            this.groupBox_PWMoutput.ResumeLayout(false);
            this.groupBox_analogueInput.ResumeLayout(false);
            this.groupBox_analogueInput.PerformLayout();
            this.groupBox_digitalIO.ResumeLayout(false);
            this.tabPage_dataLogger.ResumeLayout(false);
            this.groupBox_logReceivedDataToFile.ResumeLayout(false);
            this.groupBox_logReceivedDataToFile.PerformLayout();
            this.tabPage_SDcard.ResumeLayout(false);
            this.groupBox_binaryFileConverter.ResumeLayout(false);
            this.groupBox_binaryFileConverter.PerformLayout();
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

        private void InitializeRegisterTreeViewComponents()
        {
            #region General

            registerTreeNodeTextBox_firmwareVersionMajorNum = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.FirmwareVersionMajorNum, "Major Number:");
            registerTreeNodeTextBox_firmwareVersionMajorNum.TextBox.ReadOnly = true;
            registerTreeNodeTextBox_firmwareVersionMinorNum = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.FirmwareVersionMinorNum, "Minor Number:");
            registerTreeNodeTextBox_firmwareVersionMinorNum.TextBox.ReadOnly = true;
            registerTreeNodeTextBox_firmwareVersion = new System.Windows.Forms.TreeNode("Firmware Version (read-only)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_firmwareVersionMajorNum,
            registerTreeNodeTextBox_firmwareVersionMinorNum});
            registerTreeNodeTextBox_deviceID = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.DeviceID, "Device ID (read-only):", "{0:X4}");
            registerTreeNodeTextBox_deviceID.TextBox.ReadOnly = true;
            registerTreeNodeComboBox_buttonMode = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.ButtonMode, "Button Mode:");
            registerTreeNodeComboBox_buttonMode.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_buttonMode.ComboBox.Width = 150;
            registerTreeNodeComboBox_buttonMode.ComboBox.Items.Add("Disabled");
            registerTreeNodeComboBox_buttonMode.ComboBox.Items.Add("Reset");
            registerTreeNodeComboBox_buttonMode.ComboBox.Items.Add("Sleep/wake");
            registerTreeNodeComboBox_buttonMode.ComboBox.Items.Add("Algorithm initialise");
            registerTreeNodeComboBox_buttonMode.ComboBox.Items.Add("Algorithm tare");
            registerTreeNodeComboBox_buttonMode.ComboBox.Items.Add("Algorithm initialise then tare");
            treeNodeGeneral = new System.Windows.Forms.TreeNode("General", new System.Windows.Forms.TreeNode[] {
            registerTreeNodeTextBox_firmwareVersion,
            registerTreeNodeTextBox_deviceID,
            registerTreeNodeComboBox_buttonMode
            });

            #endregion

            #region Sensor Calibration Parameters

            #region Battery Voltmeter

            registerTreeNodeTextBox_batterySensitivity = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.BatterySensitivity, "Sensitivity (lsb/V):");
            registerTreeNodeTextBox_batteryBias = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.BatteryBias, "Bias (lsb):");
            treeNode_batteryVoltmeter = new System.Windows.Forms.TreeNode("Battery Voltmeter", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_batterySensitivity,
            registerTreeNodeTextBox_batteryBias});

            #endregion

            #region Thermometer

            registerTreeNodeTextBox_thermometerSensitivity = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ThermometerSensitivity, "Sensitivity (lsb/˚C):");
            registerTreeNodeTextBox_thermometerBias = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ThermometerBias, "Bias (lsb):");
            treeNode_thermometer = new System.Windows.Forms.TreeNode("Thermometer", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_thermometerSensitivity,
            registerTreeNodeTextBox_thermometerBias});

            #endregion

            #region Gyroscope

            registerTreeNodeComboBox_gyroscopeFullScale = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.GyroscopeFullScale, "Full-Scale:");
            registerTreeNodeComboBox_gyroscopeFullScale.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_gyroscopeFullScale.ComboBox.Width = 75;
            registerTreeNodeComboBox_gyroscopeFullScale.ComboBox.Items.Add("±250 ˚/s");
            registerTreeNodeComboBox_gyroscopeFullScale.ComboBox.Items.Add("±500 ˚/s");
            registerTreeNodeComboBox_gyroscopeFullScale.ComboBox.Items.Add("±1000 ˚/s");
            registerTreeNodeComboBox_gyroscopeFullScale.ComboBox.Items.Add("±2000 ˚/s");
            registerTreeNodeTextBox_gyroscopeSensitivtyX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeSensitivityX, "X:");
            registerTreeNodeTextBox_gyroscopeSensitivtyY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeSensitivityY, "Y:");
            registerTreeNodeTextBox_gyroscopeSensitivtyZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeSensitivityZ, "Z:");
            registerTreeNodeTextBox_gyroscopeSampledPlus200dpsX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeSampledPlus200dpsX, "X:");
            registerTreeNodeTextBox_gyroscopeSampledPlus200dpsY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeSampledPlus200dpsY, "Y:");
            registerTreeNodeTextBox_gyroscopeSampledPlus200dpsZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeSampledPlus200dpsZ, "Z:");
            treeNode_gyroSampledAxesAtPlus200dps = new System.Windows.Forms.TreeNode("Sample Axes @ +200 ˚/s (lsb)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_gyroscopeSampledPlus200dpsX,
            registerTreeNodeTextBox_gyroscopeSampledPlus200dpsY,
            registerTreeNodeTextBox_gyroscopeSampledPlus200dpsZ});
            registerTreeNodeTextBox_gyroscopeSampledMinus200dpsX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeSampledMinus200dpsX, "X:");
            registerTreeNodeTextBox_gyroscopeSampledMinus200dpsY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeSampledMinus200dpsY, "Y:");
            registerTreeNodeTextBox_gyroscopeSampledMinus200dpsZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeSampledMinus200dpsZ, "Z:");
            treeNode_gyroSampledAxesAtMinus200dps = new System.Windows.Forms.TreeNode("Sample Axes @ -200 ˚/s (lsb)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_gyroscopeSampledMinus200dpsX,
            registerTreeNodeTextBox_gyroscopeSampledMinus200dpsY,
            registerTreeNodeTextBox_gyroscopeSampledMinus200dpsZ});
            treeNode_gyroSens = new System.Windows.Forms.TreeNode("Sensitivity (lsb/˚/s)", new System.Windows.Forms.TreeNode[] {
            registerTreeNodeTextBox_gyroscopeSensitivtyX,
            registerTreeNodeTextBox_gyroscopeSensitivtyY,
            registerTreeNodeTextBox_gyroscopeSensitivtyZ,
            treeNode_gyroSampledAxesAtPlus200dps,
            treeNode_gyroSampledAxesAtMinus200dps});
            registerTreeNodeTextBox_gyroscopeBiasAt25degCX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeBiasAt25degCX, "X:");
            registerTreeNodeTextBox_gyroscopeBiasAt25degCY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeBiasAt25degCY, "Y:");
            registerTreeNodeTextBox_gyroscopeBiasAt25degCZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeBiasAt25degCZ, "Z:");
            treeNode_gyroBias = new System.Windows.Forms.TreeNode("Bias @ 25˚C (lsb)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_gyroscopeBiasAt25degCX,
            registerTreeNodeTextBox_gyroscopeBiasAt25degCY,
            registerTreeNodeTextBox_gyroscopeBiasAt25degCZ});
            registerTreeNodeTextBox_gyroscopeBiasTempSensitivityX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeBiasTempSensitivityX, "X:");
            registerTreeNodeTextBox_gyroscopeBiasTempSensitivityY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeBiasTempSensitivityY, "Y:");
            registerTreeNodeTextBox_gyroscopeBiasTempSensitivityZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeBiasTempSensitivityZ, "Z:");
            treeNode_gyroBiasTempSens = new System.Windows.Forms.TreeNode("Bias Temperature Sensitivity (˚C/lsb)", new RegisterTreeNodeTextBox[] { 
            registerTreeNodeTextBox_gyroscopeBiasTempSensitivityX,
            registerTreeNodeTextBox_gyroscopeBiasTempSensitivityY,
            registerTreeNodeTextBox_gyroscopeBiasTempSensitivityZ});
            registerTreeNodeTextBox_gyroscopeSample1Temp = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeSample1Temp, "Temperature (˚C):");
            registerTreeNodeTextBox_gyroscopeSample1BiasX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeSample1BiasX, "Bias X (lsb):");
            registerTreeNodeTextBox_gyroscopeSample1BiasY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeSample1BiasY, "Bias Y (lsb):");
            registerTreeNodeTextBox_gyroscopeSample1BiasZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeSample1BiasZ, "Bias Z (lsb):");
            treeNode_gyroSample1 = new System.Windows.Forms.TreeNode("Sampled Temperature 1", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_gyroscopeSample1Temp,
            registerTreeNodeTextBox_gyroscopeSample1BiasX,
            registerTreeNodeTextBox_gyroscopeSample1BiasY,
            registerTreeNodeTextBox_gyroscopeSample1BiasZ});
            registerTreeNodeTextBox_gyroscopeSample2Temp = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeSample2Temp, "Temperature (˚C):");
            registerTreeNodeTextBox_gyroscopeSample2BiasX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeSample2BiasX, "Bias X (lsb):");
            registerTreeNodeTextBox_gyroscopeSample2BiasY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeSample2BiasY, "Bias Y (lsb):");
            registerTreeNodeTextBox_gyroscopeSample2BiasZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.GyroscopeSample2BiasZ, "Bias Z (lsb):");
            treeNode_gyroSample2 = new System.Windows.Forms.TreeNode("Sampled Temperature 2", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_gyroscopeSample2Temp,
            registerTreeNodeTextBox_gyroscopeSample2BiasX,
            registerTreeNodeTextBox_gyroscopeSample2BiasY,
            registerTreeNodeTextBox_gyroscopeSample2BiasZ});
            treeNode_gyroBiasParent = new System.Windows.Forms.TreeNode("Bias", new System.Windows.Forms.TreeNode[] {
            treeNode_gyroBias,
            treeNode_gyroBiasTempSens,
            treeNode_gyroSample1,
            treeNode_gyroSample2});
            treeNode_gyroscope = new System.Windows.Forms.TreeNode("Gyroscope", new System.Windows.Forms.TreeNode[] {
            registerTreeNodeComboBox_gyroscopeFullScale,
            treeNode_gyroSens,
            treeNode_gyroBiasParent});

            #endregion

            #region Acceleroemter

            registerTreeNodeComboBox_accelerometerFullScale = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.AccelerometerFullScale, "Full-Scale:");
            registerTreeNodeComboBox_accelerometerFullScale.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_accelerometerFullScale.ComboBox.Width = 50;
            registerTreeNodeComboBox_accelerometerFullScale.ComboBox.Items.Add("±2 g");
            registerTreeNodeComboBox_accelerometerFullScale.ComboBox.Items.Add("±4 g");
            registerTreeNodeComboBox_accelerometerFullScale.ComboBox.Items.Add("±8 g");
            registerTreeNodeTextBox_accelerometerSensitivtyX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AccelerometerSensitivityX, "X:");
            registerTreeNodeTextBox_accelerometerSensitivtyY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AccelerometerSensitivityY, "Y:");
            registerTreeNodeTextBox_accelerometerSensitivtyZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AccelerometerSensitivityZ, "Z:");
            treeNode_accelerometerSensitivity = new System.Windows.Forms.TreeNode("Sensitivity (lsb/g)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_accelerometerSensitivtyX,
            registerTreeNodeTextBox_accelerometerSensitivtyY,
            registerTreeNodeTextBox_accelerometerSensitivtyZ});
            registerTreeNodeTextBox_accelerometerBiasX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AccelerometerBiasX, "X:");
            registerTreeNodeTextBox_accelerometerBiasY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AccelerometerBiasY, "Y:");
            registerTreeNodeTextBox_accelerometerBiasZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AccelerometerBiasZ, "Z:");
            treeNode_accelerometerBias = new System.Windows.Forms.TreeNode("Bias (lsb)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_accelerometerBiasX,
            registerTreeNodeTextBox_accelerometerBiasY,
            registerTreeNodeTextBox_accelerometerBiasZ});
            registerTreeNodeTextBox_accelerometerSampledPlus1gX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AccelerometerSampledPlus1gX, "X:");
            registerTreeNodeTextBox_accelerometerSampledPlus1gY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AccelerometerSampledPlus1gY, "Y:");
            registerTreeNodeTextBox_accelerometerSampledPlus1gZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AccelerometerSampledPlus1gZ, "Z:");
            treeNode_accelerometerSampledAsexAtPlus1g = new System.Windows.Forms.TreeNode("Sampled Axes @ +1 g (lsb)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_accelerometerSampledPlus1gX,
            registerTreeNodeTextBox_accelerometerSampledPlus1gY,
            registerTreeNodeTextBox_accelerometerSampledPlus1gZ});
            registerTreeNodeTextBox_accelerometerSampledMinus1gX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AccelerometerSampledMinus1gX, "X:");
            registerTreeNodeTextBox_accelerometerSampledMinus1gY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AccelerometerSampledMinus1gY, "Y:");
            registerTreeNodeTextBox_accelerometerSampledMinus1gZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AccelerometerSampledMinus1gZ, "Z:");
            treeNode_accelerometerSampledAsexAtMinus1g = new System.Windows.Forms.TreeNode("Sampled Axes @ -1 g (lsb)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_accelerometerSampledMinus1gX,
            registerTreeNodeTextBox_accelerometerSampledMinus1gY,
            registerTreeNodeTextBox_accelerometerSampledMinus1gZ});
            treeNode_accelerometererometer = new System.Windows.Forms.TreeNode("Accelerometer", new System.Windows.Forms.TreeNode[] {
            registerTreeNodeComboBox_accelerometerFullScale,
            treeNode_accelerometerSensitivity,
            treeNode_accelerometerBias,
            treeNode_accelerometerSampledAsexAtPlus1g,
            treeNode_accelerometerSampledAsexAtMinus1g});

            #endregion

            #region Magnetometer

            registerTreeNodeComboBox_magnetometerFullScale = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.MagnetometerFullScale, "Full Scale:");
            registerTreeNodeComboBox_magnetometerFullScale.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_magnetometerFullScale.ComboBox.Width = 60;
            registerTreeNodeComboBox_magnetometerFullScale.ComboBox.Items.Add("±1.3 G");
            registerTreeNodeComboBox_magnetometerFullScale.ComboBox.Items.Add("±1.9 G");
            registerTreeNodeComboBox_magnetometerFullScale.ComboBox.Items.Add("±2.5 G");
            registerTreeNodeComboBox_magnetometerFullScale.ComboBox.Items.Add("±4.0 G");
            registerTreeNodeComboBox_magnetometerFullScale.ComboBox.Items.Add("±4.7 G");
            registerTreeNodeComboBox_magnetometerFullScale.ComboBox.Items.Add("±5.6 G");
            registerTreeNodeComboBox_magnetometerFullScale.ComboBox.Items.Add("±8.1 G");
            registerTreeNodeTextBox_magnetometerSensitivityX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.MagnetometerSensitivityX, "X:");
            registerTreeNodeTextBox_magnetometerSensitivityY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.MagnetometerSensitivityY, "Y:");
            registerTreeNodeTextBox_magnetometerSensitivityZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.MagnetometerSensitivityZ, "Z:");
            treeNode_magnetometerSensitivity = new System.Windows.Forms.TreeNode("Sensitivity (lsb/G)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_magnetometerSensitivityX,
            registerTreeNodeTextBox_magnetometerSensitivityY,
            registerTreeNodeTextBox_magnetometerSensitivityZ});
            registerTreeNodeTextBox_magnetometerBiasX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.MagnetometerBiasX, "X:");
            registerTreeNodeTextBox_magnetometerBiasY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.MagnetometerBiasY, "Y:");
            registerTreeNodeTextBox_magnetometerBiasZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.MagnetometerBiasZ, "Z:");
            treeNode_magnetometerBias = new System.Windows.Forms.TreeNode("Bias (lsb)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_magnetometerBiasX,
            registerTreeNodeTextBox_magnetometerBiasY,
            registerTreeNodeTextBox_magnetometerBiasZ});
            registerTreeNodeTextBox_magnetometerHardIronbiasX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.MagnetometerHardIronBiasX, "X:");
            registerTreeNodeTextBox_magnetometerHardIronbiasY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.MagnetometerHardIronBiasY, "Y:");
            registerTreeNodeTextBox_magnetometerHardIronbiasZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.MagnetometerHardIronBiasZ, "Z:");
            treeNode_magnetometerHardIronbias = new System.Windows.Forms.TreeNode("Hard-Iron Bias (G)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_magnetometerHardIronbiasX,
            registerTreeNodeTextBox_magnetometerHardIronbiasY,
            registerTreeNodeTextBox_magnetometerHardIronbiasZ});
            treeNode_magnetometer = new System.Windows.Forms.TreeNode("Magnetometer", new System.Windows.Forms.TreeNode[] {
            registerTreeNodeComboBox_magnetometerFullScale,
            treeNode_magnetometerSensitivity,
            treeNode_magnetometerBias,
            treeNode_magnetometerHardIronbias});

            #endregion

            System.Windows.Forms.TreeNode treeNode_sensorCalParam = new System.Windows.Forms.TreeNode("Sensor Calibration Parameters", new System.Windows.Forms.TreeNode[] {
            treeNode_batteryVoltmeter,
            treeNode_thermometer,
            treeNode_gyroscope,
            treeNode_accelerometererometer,
            treeNode_magnetometer});

            #endregion

            #region Algorithm Parameters

            registerTreeNodeComboBox_algorithmMode = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.AlgorithmMode, "Algorithm Mode:");
            registerTreeNodeComboBox_algorithmMode.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_algorithmMode.ComboBox.Width = 60;
            registerTreeNodeComboBox_algorithmMode.ComboBox.Items.Add("Disabled");
            registerTreeNodeComboBox_algorithmMode.ComboBox.Items.Add("IMU");
            registerTreeNodeComboBox_algorithmMode.ComboBox.Items.Add("AHRS");
            registerTreeNodeTextBox_algorithmGainKp = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AlgorithmKp, "Kp:");
            registerTreeNodeTextBox_algorithmGainKi = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AlgorithmKi, "Ki (1/1024):");
            System.Windows.Forms.TreeNode treeNode_algorithmGains = new System.Windows.Forms.TreeNode("Algorithm Gains", new System.Windows.Forms.TreeNode[] {
            registerTreeNodeTextBox_algorithmGainKp,
            registerTreeNodeTextBox_algorithmGainKi});
            registerTreeNodeTextBox_algorithmInitKp = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AlgorithmInitKp, "Initial Kp:");
            registerTreeNodeTextBox_algorithmInitPeriod = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AlgorithmInitPeriod, "Initialisation Period (s):");
            System.Windows.Forms.TreeNode treeNode_algoInitialisation = new System.Windows.Forms.TreeNode("Initialisation", new System.Windows.Forms.TreeNode[] {
            registerTreeNodeTextBox_algorithmInitKp,
            registerTreeNodeTextBox_algorithmInitPeriod});
            registerTreeNodeTextBox_algorithmMinValidMag = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AlgorithmMinValidMag, "Minimum Valid Field Magnitude (G):");
            registerTreeNodeTextBox_algorithmMaxValidMag = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AlgorithmMaxValidMag, "Maximum Valid Field Magnitude (G):");
            System.Windows.Forms.TreeNode treeNode_magnetometerneticFieldRejection = new System.Windows.Forms.TreeNode("Magnetic Field Rejection", new System.Windows.Forms.TreeNode[] {
            registerTreeNodeTextBox_algorithmMinValidMag,
            registerTreeNodeTextBox_algorithmMaxValidMag});
            registerTreeNodeTextBoxtareQuatElement0 = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AlgorithmTareQuat0, "Element 0:");
            registerTreeNodeTextBoxtareQuatElement1 = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AlgorithmTareQuat1, "Element 1:");
            registerTreeNodeTextBoxtareQuatElement2 = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AlgorithmTareQuat2, "Element 2:");
            registerTreeNodeTextBoxtareQuatElement3 = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AlgorithmTareQuat3, "Element 3:");
            registerTreeNodeTextBox_algorithmTareQuaternion = new System.Windows.Forms.TreeNode("Tare Quaternion", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBoxtareQuatElement0,
            registerTreeNodeTextBoxtareQuatElement1,
            registerTreeNodeTextBoxtareQuatElement2,
            registerTreeNodeTextBoxtareQuatElement3});
            treeNode_algorithmParameters = new System.Windows.Forms.TreeNode("Algorithm Parameters", new System.Windows.Forms.TreeNode[] {
            registerTreeNodeComboBox_algorithmMode,
            treeNode_algorithmGains,
            treeNode_algoInitialisation,
            treeNode_magnetometerneticFieldRejection,
            registerTreeNodeTextBox_algorithmTareQuaternion});

            #endregion

            #region Data Output Settings

            registerTreeNodeComboBox_sensorDataMode = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.SensorDataMode, "Sensor Data Mode:");
            registerTreeNodeComboBox_sensorDataMode.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_sensorDataMode.ComboBox.Items.Add("Raw ADC results");
            registerTreeNodeComboBox_sensorDataMode.ComboBox.Items.Add("Calibrated units");
            registerTreeNodeComboBox_dateTimeDateTimeDataRate = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.DateTimeDataRate, "Date/Time Data Rate:");
            registerTreeNodeComboBox_dateTimeDateTimeDataRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_dateTimeDateTimeDataRate.ComboBox.Width = 80;
            registerTreeNodeComboBox_dateTimeDateTimeDataRate.ComboBox.Items.Add("Disabled");
            registerTreeNodeComboBox_dateTimeDateTimeDataRate.ComboBox.Items.Add("1 Hz");
            registerTreeNodeComboBox_dateTimeDateTimeDataRate.ComboBox.Items.Add("2 Hz");
            registerTreeNodeComboBox_dateTimeDateTimeDataRate.ComboBox.Items.Add("4 Hz");
            registerTreeNodeComboBox_dateTimeDateTimeDataRate.ComboBox.Items.Add("8 Hz");
            registerTreeNodeComboBox_dateTimeDateTimeDataRate.ComboBox.Items.Add("16 Hz");
            registerTreeNodeComboBox_dateTimeDateTimeDataRate.ComboBox.Items.Add("32 Hz");
            registerTreeNodeComboBox_dateTimeDateTimeDataRate.ComboBox.Items.Add("64 Hz");
            registerTreeNodeComboBox_dateTimeDateTimeDataRate.ComboBox.Items.Add("128 Hz");
            registerTreeNodeComboBox_dateTimeDateTimeDataRate.ComboBox.Items.Add("256 Hz");
            registerTreeNodeComboBox_dateTimeDateTimeDataRate.ComboBox.Items.Add("512 Hz");
            registerTreeNodeComboBox_batteryAndThermometerDataRate = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.BatteryAndThermometerDataRate, "Battery And Thermometer Data Rate:");
            registerTreeNodeComboBox_batteryAndThermometerDataRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_batteryAndThermometerDataRate.ComboBox.Width = 80;
            registerTreeNodeComboBox_batteryAndThermometerDataRate.ComboBox.Items.Add("Disabled");
            registerTreeNodeComboBox_batteryAndThermometerDataRate.ComboBox.Items.Add("1 Hz");
            registerTreeNodeComboBox_batteryAndThermometerDataRate.ComboBox.Items.Add("2 Hz");
            registerTreeNodeComboBox_batteryAndThermometerDataRate.ComboBox.Items.Add("4 Hz");
            registerTreeNodeComboBox_batteryAndThermometerDataRate.ComboBox.Items.Add("8 Hz");
            registerTreeNodeComboBox_batteryAndThermometerDataRate.ComboBox.Items.Add("16 Hz");
            registerTreeNodeComboBox_batteryAndThermometerDataRate.ComboBox.Items.Add("32 Hz");
            registerTreeNodeComboBox_batteryAndThermometerDataRate.ComboBox.Items.Add("64 Hz");
            registerTreeNodeComboBox_batteryAndThermometerDataRate.ComboBox.Items.Add("128 Hz");
            registerTreeNodeComboBox_batteryAndThermometerDataRate.ComboBox.Items.Add("256 Hz");
            registerTreeNodeComboBox_batteryAndThermometerDataRate.ComboBox.Items.Add("512 Hz");
            registerTreeNodeComboBox_inertialAndMagneticDataRate = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.InertialAndMagneticDataRate, "Inertial And Magnetic Data Rate:");
            registerTreeNodeComboBox_inertialAndMagneticDataRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_inertialAndMagneticDataRate.ComboBox.Width = 80;
            registerTreeNodeComboBox_inertialAndMagneticDataRate.ComboBox.Items.Add("Disabled");
            registerTreeNodeComboBox_inertialAndMagneticDataRate.ComboBox.Items.Add("1 Hz");
            registerTreeNodeComboBox_inertialAndMagneticDataRate.ComboBox.Items.Add("2 Hz");
            registerTreeNodeComboBox_inertialAndMagneticDataRate.ComboBox.Items.Add("4 Hz");
            registerTreeNodeComboBox_inertialAndMagneticDataRate.ComboBox.Items.Add("8 Hz");
            registerTreeNodeComboBox_inertialAndMagneticDataRate.ComboBox.Items.Add("16 Hz");
            registerTreeNodeComboBox_inertialAndMagneticDataRate.ComboBox.Items.Add("32 Hz");
            registerTreeNodeComboBox_inertialAndMagneticDataRate.ComboBox.Items.Add("64 Hz");
            registerTreeNodeComboBox_inertialAndMagneticDataRate.ComboBox.Items.Add("128 Hz");
            registerTreeNodeComboBox_inertialAndMagneticDataRate.ComboBox.Items.Add("256 Hz");
            registerTreeNodeComboBox_inertialAndMagneticDataRate.ComboBox.Items.Add("512 Hz");
            registerTreeNodeComboBox_quaternionDataRate = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.QuaternionDataRate, "Quaternion Data Rate:");
            registerTreeNodeComboBox_quaternionDataRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_quaternionDataRate.ComboBox.Width = 80;
            registerTreeNodeComboBox_quaternionDataRate.ComboBox.Items.Add("Disabled");
            registerTreeNodeComboBox_quaternionDataRate.ComboBox.Items.Add("1 Hz");
            registerTreeNodeComboBox_quaternionDataRate.ComboBox.Items.Add("2 Hz");
            registerTreeNodeComboBox_quaternionDataRate.ComboBox.Items.Add("4 Hz");
            registerTreeNodeComboBox_quaternionDataRate.ComboBox.Items.Add("8 Hz");
            registerTreeNodeComboBox_quaternionDataRate.ComboBox.Items.Add("16 Hz");
            registerTreeNodeComboBox_quaternionDataRate.ComboBox.Items.Add("32 Hz");
            registerTreeNodeComboBox_quaternionDataRate.ComboBox.Items.Add("64 Hz");
            registerTreeNodeComboBox_quaternionDataRate.ComboBox.Items.Add("128 Hz");
            registerTreeNodeComboBox_quaternionDataRate.ComboBox.Items.Add("256 Hz");
            registerTreeNodeComboBox_quaternionDataRate.ComboBox.Items.Add("512 Hz");
            treeNode_dataOutputRate = new System.Windows.Forms.TreeNode("Data Output Settings", new System.Windows.Forms.TreeNode[] {
            registerTreeNodeComboBox_sensorDataMode,
            registerTreeNodeComboBox_dateTimeDateTimeDataRate,
            registerTreeNodeComboBox_batteryAndThermometerDataRate,
            registerTreeNodeComboBox_inertialAndMagneticDataRate,
            registerTreeNodeComboBox_quaternionDataRate});

            #endregion

            #region SD Card

            registerTreeNodeTextBox_SDcardNewFileName = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.SDcardNewFileName, "New File Name (numeric):", "{0:D5}");
            treeNode_SDcard = new System.Windows.Forms.TreeNode("SD Card", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_SDcardNewFileName});

            #endregion

            #region Power Management

            registerTreeNodeComboBox_batteryShutdownVoltage = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.BatteryShutdownVoltage, "Battery Shutdown Voltage (V):");
            registerTreeNodeTextBox_sleepTimer = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.SleepTimer, "Sleep Timer (s):");
            registerTreeNodeComboBox_motionTriggeredWakeup = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.MotionTrigWakeUp, "Motion Triggered Wake Up:");
            registerTreeNodeComboBox_motionTriggeredWakeup.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_motionTriggeredWakeup.ComboBox.Width = 95;
            registerTreeNodeComboBox_motionTriggeredWakeup.ComboBox.Items.Add("Disabled");
            registerTreeNodeComboBox_motionTriggeredWakeup.ComboBox.Items.Add("Low sensitivity");
            registerTreeNodeComboBox_motionTriggeredWakeup.ComboBox.Items.Add("High sensitivity");
            registerTreeNodeComboBox_bluetoothPower = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.BluetoothPower, "Bluetooth Power:");
            registerTreeNodeComboBox_bluetoothPower.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_bluetoothPower.ComboBox.Width = 80;
            registerTreeNodeComboBox_bluetoothPower.ComboBox.Items.Add("Disabled");
            registerTreeNodeComboBox_bluetoothPower.ComboBox.Items.Add("Enabled");
            treeNode_powerManagement = new System.Windows.Forms.TreeNode("Power Management", new RegisterTreeNode[] {
            registerTreeNodeComboBox_batteryShutdownVoltage,
            registerTreeNodeTextBox_sleepTimer,
            registerTreeNodeComboBox_motionTriggeredWakeup,
            registerTreeNodeComboBox_bluetoothPower});

            #endregion

            #region Auxiliary Port

            registerTreeNodeComboBox_auxiliaryPortMode = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.AuxiliaryPortMode, "Auxiliary Port Mode:");
            registerTreeNodeComboBox_auxiliaryPortMode.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_auxiliaryPortMode.ComboBox.Width = 100;
            registerTreeNodeComboBox_auxiliaryPortMode.ComboBox.Items.Add("Disabled");
            registerTreeNodeComboBox_auxiliaryPortMode.ComboBox.Items.Add("Digital I/O");
            registerTreeNodeComboBox_auxiliaryPortMode.ComboBox.Items.Add("Analogue input");
            registerTreeNodeComboBox_auxiliaryPortMode.ComboBox.Items.Add("PWM output");
            registerTreeNodeComboBox_auxiliaryPortMode.ComboBox.Items.Add("ADXL345 bus");
            registerTreeNodeComboBox_auxiliaryPortMode.ComboBox.Items.Add("UART");

            #region Digital I/O

            registerTreeNodeComboBox_digitalIOdirection = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.DigitalIOdirection, "I/O Direction:");
            registerTreeNodeComboBox_digitalIOdirection.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_digitalIOdirection.ComboBox.Width = 210;
            registerTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2,3,4,5,6,7");
            registerTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2,3,4,5,6, Ouputs = AX7");
            registerTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2,3,4,5, Ouputs = AX6,7");
            registerTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2,3,4, Ouputs = AX5,6,7");
            registerTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2,3, Ouputs = AX4,5,6,7");
            registerTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2, Ouputs = AX3,4,5,6,7");
            registerTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1, Ouputs = AX2,3,4,5,6,7");
            registerTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0, Ouputs = AX1,2,3,4,5,6,7");
            registerTreeNodeComboBox_digitalIOdirection.ComboBox.Items.Add("Outputs = AX0,1,2,3,4,5,6,7");
            registerTreeNodeComboBox_digitalIOdataRate = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.DigitalIOdataRate, "Data Rate:");
            registerTreeNodeComboBox_digitalIOdataRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_digitalIOdataRate.ComboBox.Width = 150;
            registerTreeNodeComboBox_digitalIOdataRate.ComboBox.Items.Add("Disabled (On change only)");
            registerTreeNodeComboBox_digitalIOdataRate.ComboBox.Items.Add("1 Hz");
            registerTreeNodeComboBox_digitalIOdataRate.ComboBox.Items.Add("2 Hz");
            registerTreeNodeComboBox_digitalIOdataRate.ComboBox.Items.Add("4 Hz");
            registerTreeNodeComboBox_digitalIOdataRate.ComboBox.Items.Add("8 Hz");
            registerTreeNodeComboBox_digitalIOdataRate.ComboBox.Items.Add("16 Hz");
            registerTreeNodeComboBox_digitalIOdataRate.ComboBox.Items.Add("32 Hz");
            registerTreeNodeComboBox_digitalIOdataRate.ComboBox.Items.Add("64 Hz");
            registerTreeNodeComboBox_digitalIOdataRate.ComboBox.Items.Add("128 Hz");
            registerTreeNodeComboBox_digitalIOdataRate.ComboBox.Items.Add("256 Hz");
            registerTreeNodeComboBox_digitalIOdataRate.ComboBox.Items.Add("512 Hz");
            treeNode_digitalIO = new System.Windows.Forms.TreeNode("Digital I/O", new RegisterTreeNode[] {
            registerTreeNodeComboBox_digitalIOdirection,
            registerTreeNodeComboBox_digitalIOdataRate});

            #endregion

            #region Analogue Input

            registerTreeNodeComboBox_analogueInputDataMode = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.AnalogueInputDataMode, "Data Mode:");
            registerTreeNodeComboBox_analogueInputDataMode.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_analogueInputDataMode.ComboBox.Items.Add("Raw ADC results");
            registerTreeNodeComboBox_analogueInputDataMode.ComboBox.Items.Add("Calibrated units");
            registerTreeNodeComboBox_analogueInputDataRate = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.AnalogueInputDataRate, "Data Rate:");
            registerTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("Disabled");
            registerTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("1 Hz");
            registerTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("2 Hz");
            registerTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("4 Hz");
            registerTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("8 Hz");
            registerTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("16 Hz");
            registerTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("32 Hz");
            registerTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("64 Hz");
            registerTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("128 Hz");
            registerTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("256 Hz");
            registerTreeNodeComboBox_analogueInputDataRate.ComboBox.Items.Add("512 Hz");
            registerTreeNodeComboBox_analogueInputDataRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_analogueInputDataRate.ComboBox.Width = 80;
            registerTreeNodeTextBox_analogueInputSensitivity = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AnalogueInputSensitivity, "Sensitivity:");
            registerTreeNodeTextBox_analogueInputBias = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.AnalogueInputBias, "Bias:");
            registerTreeNodeComboBox_analogueInputCalibrationParameters = new System.Windows.Forms.TreeNode("Calibration Parameters", new System.Windows.Forms.TreeNode[] {
            registerTreeNodeTextBox_analogueInputSensitivity,
            registerTreeNodeTextBox_analogueInputBias});
            treeNode_analogueInput = new System.Windows.Forms.TreeNode("Analogue Input", new System.Windows.Forms.TreeNode[] {
            registerTreeNodeComboBox_analogueInputDataMode,
            registerTreeNodeComboBox_analogueInputDataRate,
            registerTreeNodeComboBox_analogueInputCalibrationParameters});

            #endregion

            #region PWMoutput

            registerTreeNodeTextBox_PWMoutputFrequency = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.PWMoutputFrequency, "Frequency (Hz):");
            treeNode_PWMoutput = new System.Windows.Forms.TreeNode("PWM Output", new System.Windows.Forms.TreeNode[] {
            registerTreeNodeTextBox_PWMoutputFrequency});

            #endregion

            #region ADXL345 bus

            registerTreeNodeComboBox_ADXL345busDataMode = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.ADXL345busDataMode, "Data Mode:");
            registerTreeNodeComboBox_ADXL345busDataMode.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_ADXL345busDataMode.ComboBox.Items.Add("Raw ADC results");
            registerTreeNodeComboBox_ADXL345busDataMode.ComboBox.Items.Add("Calibrated units");
            registerTreeNodeComboBox_ADXL345busDataRate = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.ADXL345busDataRate, "Data Rate:");
            registerTreeNodeComboBox_ADXL345busDataRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_ADXL345busDataRate.ComboBox.Width = 80;
            registerTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("Disabled");
            registerTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("1 Hz");
            registerTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("2 Hz");
            registerTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("4 Hz");
            registerTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("8 Hz");
            registerTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("16 Hz");
            registerTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("32 Hz");
            registerTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("64 Hz");
            registerTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("128 Hz");
            registerTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("256 Hz");
            registerTreeNodeComboBox_ADXL345busDataRate.ComboBox.Items.Add("512 Hz");

            #region ADXL345 A

            registerTreeNodeTextBox_ADXL345AsensitivityX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345AsensitivityX, "X:");
            registerTreeNodeTextBox_ADXL345AsensitivityY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345AsensitivityY, "Y:");
            registerTreeNodeTextBox_ADXL345AsensitivityZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345AsensitivityZ, "Z:");
            treeNode_ADXL345Asensitivity = new System.Windows.Forms.TreeNode("Sensitivity (lsb/g)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_ADXL345AsensitivityX,
            registerTreeNodeTextBox_ADXL345AsensitivityY,
            registerTreeNodeTextBox_ADXL345AsensitivityZ});
            registerTreeNodeTextBox_ADXL345AbiasX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345AbiasX, "X:");
            registerTreeNodeTextBox_ADXL345AbiasY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345AbiasY, "Y:");
            registerTreeNodeTextBox_ADXL345AbiasZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345AbiasZ, "Z:");
            treeNode_ADXL345Abias = new System.Windows.Forms.TreeNode("Bias (lsb)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_ADXL345AbiasX,
            registerTreeNodeTextBox_ADXL345AbiasY,
            registerTreeNodeTextBox_ADXL345AbiasZ});
            treeNode_ADXL345A = new System.Windows.Forms.TreeNode("ADXL345 A", new System.Windows.Forms.TreeNode[] {
            treeNode_ADXL345Asensitivity,
            treeNode_ADXL345Abias});

            #endregion

            #region ADXL345 B

            registerTreeNodeTextBox_ADXL345BsensitivityX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345BsensitivityX, "X:");
            registerTreeNodeTextBox_ADXL345BsensitivityY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345BsensitivityY, "Y:");
            registerTreeNodeTextBox_ADXL345BsensitivityZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345BsensitivityZ, "Z:");
            treeNode_ADXL345Bsensitivity = new System.Windows.Forms.TreeNode("Sensitivity (lsb/g)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_ADXL345BsensitivityX,
            registerTreeNodeTextBox_ADXL345BsensitivityY,
            registerTreeNodeTextBox_ADXL345BsensitivityZ});
            registerTreeNodeTextBox_ADXL345BbiasX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345BbiasX, "X:");
            registerTreeNodeTextBox_ADXL345BbiasY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345BbiasY, "Y:");
            registerTreeNodeTextBox_ADXL345BbiasZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345BbiasZ, "Z:");
            treeNode_ADXL345Bbias = new System.Windows.Forms.TreeNode("Bias (lsb)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_ADXL345BbiasX,
            registerTreeNodeTextBox_ADXL345BbiasY,
            registerTreeNodeTextBox_ADXL345BbiasZ});
            treeNode_ADXL345B = new System.Windows.Forms.TreeNode("ADXL345 B", new System.Windows.Forms.TreeNode[] {
            treeNode_ADXL345Bsensitivity,
            treeNode_ADXL345Bbias});

            #endregion

            #region ADXL345 C

            registerTreeNodeTextBox_ADXL345CsensitivityX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345CsensitivityX, "X:");
            registerTreeNodeTextBox_ADXL345CsensitivityY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345CsensitivityY, "Y:");
            registerTreeNodeTextBox_ADXL345CsensitivityZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345CsensitivityZ, "Z:");
            treeNode_ADXL345Csensitivity = new System.Windows.Forms.TreeNode("Sensitivity (lsb/g)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_ADXL345CsensitivityX,
            registerTreeNodeTextBox_ADXL345CsensitivityY,
            registerTreeNodeTextBox_ADXL345CsensitivityZ});
            registerTreeNodeTextBox_ADXL345CbiasX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345CbiasX, "X:");
            registerTreeNodeTextBox_ADXL345CbiasY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345CbiasY, "Y:");
            registerTreeNodeTextBox_ADXL345CbiasZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345CbiasZ, "Z:");
            treeNode_ADXL345Cbias = new System.Windows.Forms.TreeNode("Bias (lsb)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_ADXL345CbiasX,
            registerTreeNodeTextBox_ADXL345CbiasY,
            registerTreeNodeTextBox_ADXL345CbiasZ});
            treeNode_ADXL345C = new System.Windows.Forms.TreeNode("ADXL345 C", new System.Windows.Forms.TreeNode[] {
            treeNode_ADXL345Csensitivity,
            treeNode_ADXL345Cbias});

            #endregion

            #region ADXL345 D

            registerTreeNodeTextBox_ADXL345DsensitivityX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345DsensitivityX, "X:");
            registerTreeNodeTextBox_ADXL345DsensitivityY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345DsensitivityY, "Y:");
            registerTreeNodeTextBox_ADXL345DsensitivityZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345DsensitivityZ, "Z:");
            treeNode_ADXL345Dsensitivity = new System.Windows.Forms.TreeNode("Sensitivity (lsb/g)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_ADXL345DsensitivityX,
            registerTreeNodeTextBox_ADXL345DsensitivityY,
            registerTreeNodeTextBox_ADXL345DsensitivityZ});
            registerTreeNodeTextBox_ADXL345DbiasX = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345DbiasX, "X:");
            registerTreeNodeTextBox_ADXL345DbiasY = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345DbiasY, "Y:");
            registerTreeNodeTextBox_ADXL345DbiasZ = new RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses.ADXL345DbiasZ, "Z:");
            treeNode_ADXL345Dbias = new System.Windows.Forms.TreeNode("Bias (lsb)", new RegisterTreeNodeTextBox[] {
            registerTreeNodeTextBox_ADXL345DbiasX,
            registerTreeNodeTextBox_ADXL345DbiasY,
            registerTreeNodeTextBox_ADXL345DbiasZ});
            treeNode_ADXL345D = new System.Windows.Forms.TreeNode("ADXL345 D", new System.Windows.Forms.TreeNode[] {
            treeNode_ADXL345Dsensitivity,
            treeNode_ADXL345Dbias});

            #endregion

            treeNode_ADXL345busCalibrationParameters = new System.Windows.Forms.TreeNode("Calibration Parameters", new System.Windows.Forms.TreeNode[] {
            treeNode_ADXL345A,
            treeNode_ADXL345B,
            treeNode_ADXL345C,
            treeNode_ADXL345D});
            treeNode_ADXL345 = new System.Windows.Forms.TreeNode("ADXL345 Bus", new System.Windows.Forms.TreeNode[] {
            registerTreeNodeComboBox_ADXL345busDataMode,
            registerTreeNodeComboBox_ADXL345busDataRate,
            treeNode_ADXL345busCalibrationParameters});

            #endregion

            #region UART

            registerTreeNodeComboBox_UARTbaudRate = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.UARTbaudRate, "Baud Rate:");
            registerTreeNodeComboBox_UARTbaudRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_UARTbaudRate.ComboBox.Width = 75;
            registerTreeNodeComboBox_UARTbaudRate.ComboBox.Items.Add("2400");
            registerTreeNodeComboBox_UARTbaudRate.ComboBox.Items.Add("4800");
            registerTreeNodeComboBox_UARTbaudRate.ComboBox.Items.Add("7200");
            registerTreeNodeComboBox_UARTbaudRate.ComboBox.Items.Add("9600");
            registerTreeNodeComboBox_UARTbaudRate.ComboBox.Items.Add("14400");
            registerTreeNodeComboBox_UARTbaudRate.ComboBox.Items.Add("19200");
            registerTreeNodeComboBox_UARTbaudRate.ComboBox.Items.Add("38400");
            registerTreeNodeComboBox_UARTbaudRate.ComboBox.Items.Add("57600");
            registerTreeNodeComboBox_UARTbaudRate.ComboBox.Items.Add("115200");
            registerTreeNodeComboBox_UARTbaudRate.ComboBox.Items.Add("23400");
            registerTreeNodeComboBox_UARTbaudRate.ComboBox.Items.Add("460800");
            registerTreeNodeComboBox_UARTbaudRate.ComboBox.Items.Add("921600");
            registerTreeNodeComboBox_UARThardwareFlowControl = new RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses.UARThardwareFlowControl, "Hardware Flow Control:");
            registerTreeNodeComboBox_UARThardwareFlowControl.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            registerTreeNodeComboBox_UARThardwareFlowControl.ComboBox.Width = 50;
            registerTreeNodeComboBox_UARThardwareFlowControl.ComboBox.Items.Add("Off");
            registerTreeNodeComboBox_UARThardwareFlowControl.ComboBox.Items.Add("On");
            treeNode_UART = new System.Windows.Forms.TreeNode("UART", new RegisterTreeNode[] {
            registerTreeNodeComboBox_UARTbaudRate,
            registerTreeNodeComboBox_UARThardwareFlowControl});

            #endregion

            treeNode_auxiliaryPort = new System.Windows.Forms.TreeNode("Auxiliary Port", new System.Windows.Forms.TreeNode[] {
            registerTreeNodeComboBox_auxiliaryPortMode,
            treeNode_digitalIO,
            treeNode_analogueInput,
            treeNode_PWMoutput,
            treeNode_ADXL345,
            treeNode_UART});

            #endregion

            registerTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
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
        private System.Windows.Forms.GroupBox groupBox_openClosePort;
        private System.Windows.Forms.Label label_portName;
        private System.Windows.Forms.ComboBox comboBox_portName;
        private ToggleButton toggleButton_openClosePort;
        private System.Windows.Forms.GroupBox groupBox_packetCounters;
        private System.Windows.Forms.Label label_packetsReceived;
        private System.Windows.Forms.TextBox textBox_packetsReceived;
        private System.Windows.Forms.Label label_packetsSent;
        private System.Windows.Forms.TextBox textBox_packetsSent;
        private System.Windows.Forms.TabPage tabPage_registers;
        private RegisterTreeView registerTreeView;
        private System.Windows.Forms.TabPage tabPage_dateTime;
        private System.Windows.Forms.GroupBox groupBox_dateTime;
        private System.Windows.Forms.Label label_receivedDateTime;
        private System.Windows.Forms.TextBox textBox_receivedDataTime;
        private System.Windows.Forms.Button button_readDateTime;
        private System.Windows.Forms.Button button_setDateTime;
        private System.Windows.Forms.TabPage tabPage_commands;
        private System.Windows.Forms.GroupBox groupBox_general;
        private CommandButton commandButton_factoryReset;
        private CommandButton commandButton_reset;
        private CommandButton commandButton_sleep;
        private CommandButton commandButton_resetSleepTimer;
        private System.Windows.Forms.GroupBox groupBox_gyroscopeCalibration;
        private CommandButton commandButton_sampleGyroAt200dps;
        private CommandButton commandButton_calculateGyroSensitivity;
        private CommandButton commandButtonbutton_sampleGyroBiasAtT1;
        private CommandButton commandButton_sampleGyroBiasAtT2;
        private CommandButton commandButton_calcGyroBiasParameters;
        private System.Windows.Forms.GroupBox groupBox_accelerometerCalibration;
        private CommandButton commandButton_sampleAccelAxisAt1g;
        private CommandButton commandButton_calcAccelBiasSens;
        private System.Windows.Forms.GroupBox groupBox_magnetometerCalibration;
        private CommandButton commandButton_measMagBiasSens;
        private System.Windows.Forms.GroupBox groupBox_algorithm;
        private CommandButton commandButton_initialise;
        private CommandButton commandButton_tare;
        private CommandButton commandButton_clearTare;
        private CommandButton commandButton_initialiseThenTare;
        private System.Windows.Forms.GroupBox groupBox_receivedCommandMessages;
        private System.Windows.Forms.CheckBox checkBox_displayCommandConfirmations;
        private System.Windows.Forms.TabPage tabPage_viewSensorData;
        private System.Windows.Forms.GroupBox groupBox_batteryAndThermometerData;
        private ShowHideButton showHideButton_batteryGraph;
        private ShowHideButton showHideButton_thermometerGraph;
        private System.Windows.Forms.GroupBox groupBox_inertialAndMagneticData;
        private ShowHideButton showHideButton_gyroscopeGraph;
        private ShowHideButton showHideButton_accelerometerGraph;
        private ShowHideButton showHideButton_magnetometerGraph;
        private System.Windows.Forms.Label label_inertialAndMagneticDataLegend;
        private System.Windows.Forms.Label label_inertialAndMagneticDataX;
        private System.Windows.Forms.Label label_inertialAndMagneticDataY;
        private System.Windows.Forms.Label label_inertialAndMagneticDataZ;
        private System.Windows.Forms.GroupBox groupBox_orientationData;
        private ShowHideButton showHideButton_3Dcuboid;
        private ShowHideButton showHideButton_eulerAnglesGraph;
        private System.Windows.Forms.Label label_orientationDataLegend;
        private System.Windows.Forms.Label label_orientationDataLegendPhi;
        private System.Windows.Forms.Label label_orientationDataLegendTheta;
        private System.Windows.Forms.Label label_orientationDataLegendPsi;
        private System.Windows.Forms.TabPage tabPage_auxillaryPort;
        private System.Windows.Forms.GroupBox groupBox_digitalIO;
        private ShowHideButton showHideButton_digitalIOpanel;
        private System.Windows.Forms.GroupBox groupBox_analogueInput;
        private ShowHideButton showHideButton_AX0andAX1graph;
        private ShowHideButton showHideButton_AX2andAX3graph;
        private ShowHideButton showHideButton_AX4andAX5graph;
        private ShowHideButton showHideButton_AX6andAX7graph;
        private System.Windows.Forms.Label label_analogueInputLegend;
        private System.Windows.Forms.Label label_analogueInputAX0246;
        private System.Windows.Forms.Label label_analogueInputAX1357;
        private System.Windows.Forms.GroupBox groupBox_PWMoutput;
        private ShowHideButton showHideButton_PWMoutputPanel;
        private System.Windows.Forms.GroupBox groupBox_ADXL345bus;
        private ShowHideButton showHideButton_ADXL345Agraph;
        private ShowHideButton showHideButton_ADXL345Bgraph;
        private ShowHideButton showHideButton_ADXL345Cgraph;
        private ShowHideButton showHideButton_ADXL345Dgraph;
        private System.Windows.Forms.Label label_ADXL345busLegend;
        private System.Windows.Forms.Label label_ADXL345busX;
        private System.Windows.Forms.Label label_ADXL345busY;
        private System.Windows.Forms.Label label_ADXL345busZ;
        private System.Windows.Forms.TabPage tabPage_dataLogger;
        private System.Windows.Forms.GroupBox groupBox_logReceivedDataToFile;
        private System.Windows.Forms.Label label_dataLoggerFilePath;
        private System.Windows.Forms.TextBox textBox_dataLoggerFilePath;
        private System.Windows.Forms.Button button_dataLoggerBrowse;
        private ToggleButton toggleButton_dataLoggerStartStopLogging;
        private System.Windows.Forms.TabPage tabPage_SDcard;
        private System.Windows.Forms.GroupBox groupBox_binaryFileConverter;
        private System.Windows.Forms.TextBox textBox_convertBinaryFileFilePath;
        private System.Windows.Forms.Label label_convertBinaryFileFilePath;
        private System.Windows.Forms.Button button_convertBinaryFileBrowse;
        private System.Windows.Forms.Button button_convertBinaryFileConvert;
        private System.Windows.Forms.TabPage tabPage_hardIronCalibration;
        private System.Windows.Forms.GroupBox groupBox_step1ClearHardIronBiasRegisters;
        private System.Windows.Forms.Button button_clearHardIronRegisters;
        private System.Windows.Forms.GroupBox groupBox_step2collectHardIronCalibrationDataSet;
        private System.Windows.Forms.Label label_collectHardIronCalDatasetFilePath;
        private System.Windows.Forms.TextBox textBox_collectHardIronCalDatasetFilePath;
        private System.Windows.Forms.Button button_collectHardIronCalDatasetBrowse;
        private ToggleButton toggleButton_collectHardIronCalDatasetStartStopLogging;
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

        private RegisterTreeNodeTextBox registerTreeNodeTextBox_firmwareVersionMajorNum;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_firmwareVersionMinorNum;
        private System.Windows.Forms.TreeNode registerTreeNodeTextBox_firmwareVersion;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_deviceID;
        private RegisterTreeNodeComboBox registerTreeNodeComboBox_buttonMode;
        private System.Windows.Forms.TreeNode treeNodeGeneral;

        #endregion

        #region Sensor Calibration Parameters

        #region Battery Voltmeter

        private RegisterTreeNodeTextBox registerTreeNodeTextBox_batterySensitivity;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_batteryBias;
        private System.Windows.Forms.TreeNode treeNode_batteryVoltmeter;

        #endregion

        #region Thermometer

        private RegisterTreeNodeTextBox registerTreeNodeTextBox_thermometerSensitivity;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_thermometerBias;
        private System.Windows.Forms.TreeNode treeNode_thermometer;

        #endregion

        #region Gyroscope

        private RegisterTreeNodeComboBox registerTreeNodeComboBox_gyroscopeFullScale;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeSensitivtyX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeSensitivtyY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeSensitivtyZ;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeSampledPlus200dpsX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeSampledPlus200dpsY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeSampledPlus200dpsZ;
        private System.Windows.Forms.TreeNode treeNode_gyroSampledAxesAtPlus200dps;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeSampledMinus200dpsX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeSampledMinus200dpsY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeSampledMinus200dpsZ;
        private System.Windows.Forms.TreeNode treeNode_gyroSampledAxesAtMinus200dps;
        private System.Windows.Forms.TreeNode treeNode_gyroSens;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeBiasAt25degCX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeBiasAt25degCY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeBiasAt25degCZ;
        private System.Windows.Forms.TreeNode treeNode_gyroBias;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeBiasTempSensitivityX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeBiasTempSensitivityY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeBiasTempSensitivityZ;
        private System.Windows.Forms.TreeNode treeNode_gyroBiasTempSens;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeSample1Temp;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeSample1BiasX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeSample1BiasY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeSample1BiasZ;
        private System.Windows.Forms.TreeNode treeNode_gyroSample1;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeSample2Temp;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeSample2BiasX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeSample2BiasY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_gyroscopeSample2BiasZ;
        private System.Windows.Forms.TreeNode treeNode_gyroSample2;
        private System.Windows.Forms.TreeNode treeNode_gyroBiasParent;
        private System.Windows.Forms.TreeNode treeNode_gyroscope;

        #endregion

        #region Acceleroemter

        private RegisterTreeNodeComboBox registerTreeNodeComboBox_accelerometerFullScale;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_accelerometerSensitivtyX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_accelerometerSensitivtyY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_accelerometerSensitivtyZ;
        private System.Windows.Forms.TreeNode treeNode_accelerometerSensitivity;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_accelerometerBiasX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_accelerometerBiasY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_accelerometerBiasZ;
        private System.Windows.Forms.TreeNode treeNode_accelerometerBias;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_accelerometerSampledPlus1gX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_accelerometerSampledPlus1gY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_accelerometerSampledPlus1gZ;
        private System.Windows.Forms.TreeNode treeNode_accelerometerSampledAsexAtPlus1g;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_accelerometerSampledMinus1gX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_accelerometerSampledMinus1gY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_accelerometerSampledMinus1gZ;
        private System.Windows.Forms.TreeNode treeNode_accelerometerSampledAsexAtMinus1g;
        private System.Windows.Forms.TreeNode treeNode_accelerometererometer;

        #endregion

        #region Magnetometer

        private RegisterTreeNodeComboBox registerTreeNodeComboBox_magnetometerFullScale;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_magnetometerSensitivityX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_magnetometerSensitivityY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_magnetometerSensitivityZ;
        private System.Windows.Forms.TreeNode treeNode_magnetometerSensitivity;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_magnetometerBiasX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_magnetometerBiasY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_magnetometerBiasZ;
        private System.Windows.Forms.TreeNode treeNode_magnetometerBias;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_magnetometerHardIronbiasX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_magnetometerHardIronbiasY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_magnetometerHardIronbiasZ;
        private System.Windows.Forms.TreeNode treeNode_magnetometerHardIronbias;
        private System.Windows.Forms.TreeNode treeNode_magnetometer;

        #endregion

        #endregion

        #region Algorithm Parameters

        private RegisterTreeNodeComboBox registerTreeNodeComboBox_algorithmMode;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_algorithmGainKp;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_algorithmGainKi;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_algorithmMinValidMag;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_algorithmMaxValidMag;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_algorithmInitKp;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_algorithmInitPeriod;
        private System.Windows.Forms.TreeNode registerTreeNodeTextBox_algorithmTareQuaternion;
        private RegisterTreeNodeTextBox registerTreeNodeTextBoxtareQuatElement0;
        private RegisterTreeNodeTextBox registerTreeNodeTextBoxtareQuatElement1;
        private RegisterTreeNodeTextBox registerTreeNodeTextBoxtareQuatElement2;
        private RegisterTreeNodeTextBox registerTreeNodeTextBoxtareQuatElement3;
        private System.Windows.Forms.TreeNode treeNode_algorithmParameters;

        #endregion

        #region Data Output Settings

        private RegisterTreeNodeComboBox registerTreeNodeComboBox_sensorDataMode;
        private RegisterTreeNodeComboBox registerTreeNodeComboBox_dateTimeDateTimeDataRate;
        private RegisterTreeNodeComboBox registerTreeNodeComboBox_batteryAndThermometerDataRate;
        private RegisterTreeNodeComboBox registerTreeNodeComboBox_inertialAndMagneticDataRate;
        private RegisterTreeNodeComboBox registerTreeNodeComboBox_quaternionDataRate;
        private System.Windows.Forms.TreeNode treeNode_dataOutputRate;

        #endregion

        #region SD Card

        private RegisterTreeNodeTextBox registerTreeNodeTextBox_SDcardNewFileName;
        private System.Windows.Forms.TreeNode treeNode_SDcard;

        #endregion

        #region Power Management

        private RegisterTreeNodeTextBox registerTreeNodeComboBox_batteryShutdownVoltage;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_sleepTimer;
        private RegisterTreeNodeComboBox registerTreeNodeComboBox_motionTriggeredWakeup;
        private RegisterTreeNodeComboBox registerTreeNodeComboBox_bluetoothPower;
        private System.Windows.Forms.TreeNode treeNode_powerManagement;

        #endregion

        #region Auxiliary Port

        private RegisterTreeNodeComboBox registerTreeNodeComboBox_auxiliaryPortMode;

        #region Digital I/O

        private RegisterTreeNodeComboBox registerTreeNodeComboBox_digitalIOdirection;
        private RegisterTreeNodeComboBox registerTreeNodeComboBox_digitalIOdataRate;
        private System.Windows.Forms.TreeNode treeNode_digitalIO;

        #endregion

        #region Analogue Input

        private RegisterTreeNodeComboBox registerTreeNodeComboBox_analogueInputDataMode;
        private RegisterTreeNodeComboBox registerTreeNodeComboBox_analogueInputDataRate;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_analogueInputSensitivity;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_analogueInputBias;
        private System.Windows.Forms.TreeNode registerTreeNodeComboBox_analogueInputCalibrationParameters;
        private System.Windows.Forms.TreeNode treeNode_analogueInput;

        #endregion

        #region PWM Output

        private RegisterTreeNodeTextBox registerTreeNodeTextBox_PWMoutputFrequency;
        private System.Windows.Forms.TreeNode treeNode_PWMoutput; 

        #endregion

        #region ADXL345 Bus

        private RegisterTreeNodeComboBox registerTreeNodeComboBox_ADXL345busDataMode;
        private RegisterTreeNodeComboBox registerTreeNodeComboBox_ADXL345busDataRate;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345AsensitivityX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345AsensitivityY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345AsensitivityZ;
        private System.Windows.Forms.TreeNode treeNode_ADXL345Asensitivity;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345AbiasX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345AbiasY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345AbiasZ;
        private System.Windows.Forms.TreeNode treeNode_ADXL345Abias;
        private System.Windows.Forms.TreeNode treeNode_ADXL345A;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345BsensitivityX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345BsensitivityY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345BsensitivityZ;
        private System.Windows.Forms.TreeNode treeNode_ADXL345Bsensitivity;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345BbiasX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345BbiasY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345BbiasZ;
        private System.Windows.Forms.TreeNode treeNode_ADXL345Bbias;
        private System.Windows.Forms.TreeNode treeNode_ADXL345B;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345CsensitivityX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345CsensitivityY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345CsensitivityZ;
        private System.Windows.Forms.TreeNode treeNode_ADXL345Csensitivity;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345CbiasX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345CbiasY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345CbiasZ;
        private System.Windows.Forms.TreeNode treeNode_ADXL345Cbias;
        private System.Windows.Forms.TreeNode treeNode_ADXL345C;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345DsensitivityX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345DsensitivityY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345DsensitivityZ;
        private System.Windows.Forms.TreeNode treeNode_ADXL345Dsensitivity;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345DbiasX;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345DbiasY;
        private RegisterTreeNodeTextBox registerTreeNodeTextBox_ADXL345DbiasZ;
        private System.Windows.Forms.TreeNode treeNode_ADXL345Dbias;
        private System.Windows.Forms.TreeNode treeNode_ADXL345D;
        private System.Windows.Forms.TreeNode treeNode_ADXL345busCalibrationParameters;
        private System.Windows.Forms.TreeNode treeNode_ADXL345;

        #endregion

        #region UART

        private RegisterTreeNodeComboBox registerTreeNodeComboBox_UARTbaudRate;
        private RegisterTreeNodeComboBox registerTreeNodeComboBox_UARThardwareFlowControl;
        private System.Windows.Forms.TreeNode treeNode_UART;

        #endregion

        private System.Windows.Forms.TreeNode treeNode_auxiliaryPort;

        #endregion

        #endregion
    }
}