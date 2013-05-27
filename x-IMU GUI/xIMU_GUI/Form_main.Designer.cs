namespace xIMU_GUI
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
            this.appendedTreeView_registers = new xIMU_GUI.AppendedTreeView();
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
            this.button_clearTare = new System.Windows.Forms.Button();
            this.button_tare = new System.Windows.Forms.Button();
            this.button_resetAlgorithm = new System.Windows.Forms.Button();
            this.groupBox_sensorCalibration = new System.Windows.Forms.GroupBox();
            this.button_sampleGyroBiasAtT2 = new System.Windows.Forms.Button();
            this.button_lookupAccelBiasAndSens = new System.Windows.Forms.Button();
            this.button_measMagParameters = new System.Windows.Forms.Button();
            this.button_sampleGyroBiasAtT1 = new System.Windows.Forms.Button();
            this.groupBox_general = new System.Windows.Forms.GroupBox();
            this.button_resetSleepTimer = new System.Windows.Forms.Button();
            this.button_sleep = new System.Windows.Forms.Button();
            this.button_resetDevice = new System.Windows.Forms.Button();
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
            this.groupBox_hardIronCalibrationAlgorithm = new System.Windows.Forms.GroupBox();
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
            this.tabPage_bootloader = new System.Windows.Forms.TabPage();
            this.groupBox_uploadFirmware = new System.Windows.Forms.GroupBox();
            this.button_bootloaderBrowse = new System.Windows.Forms.Button();
            this.label_bootloaderFilePath = new System.Windows.Forms.Label();
            this.textBox_bootloaderFilePath = new System.Windows.Forms.TextBox();
            this.button_bootloaderUpload = new System.Windows.Forms.Button();
            this.tabPage_about = new System.Windows.Forms.TabPage();
            this.linkLabel_sourceforgenetprojectstaoframework = new System.Windows.Forms.LinkLabel();
            this.linkLabel_wwwoscilloscopelibcom = new System.Windows.Forms.LinkLabel();
            this.label_theFollwingLinksProvideMoreInfo = new System.Windows.Forms.Label();
            this.label_GUIversionNum = new System.Windows.Forms.Label();
            this.label_APIversionNum = new System.Windows.Forms.Label();
            this.label_compatibleFirmwareVersionNums = new System.Windows.Forms.Label();
            this.linkLabel_wwwxiocouk = new System.Windows.Forms.LinkLabel();
            this.label_forMoreInfo = new System.Windows.Forms.Label();
            this.label_thexIMUGUIis = new System.Windows.Forms.Label();
            this.label_compatibleFirmwareVersions = new System.Windows.Forms.Label();
            this.label_APIversion = new System.Windows.Forms.Label();
            this.label_GUIversion = new System.Windows.Forms.Label();
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
            this.groupBox_sensorCalibration.SuspendLayout();
            this.groupBox_general.SuspendLayout();
            this.tabPage_ViewSensorData.SuspendLayout();
            this.groupBox_orienData.SuspendLayout();
            this.groupBox_sensorData.SuspendLayout();
            this.groupBox_battThermData.SuspendLayout();
            this.tabPage_auxillaryPort.SuspendLayout();
            this.groupBox_digitalIO.SuspendLayout();
            this.tabPage_dataLogger.SuspendLayout();
            this.groupBox_logReceivedDataToFile.SuspendLayout();
            this.tabPage_SDcard.SuspendLayout();
            this.groupBox_convertBinaryFile.SuspendLayout();
            this.tabPage_hardIronCalibration.SuspendLayout();
            this.groupBox_hardIronCalibrationAlgorithm.SuspendLayout();
            this.groupBox_step2collectHardIronCalibrationDataSet.SuspendLayout();
            this.groupBox_step1ClearHardIronBiasRegisters.SuspendLayout();
            this.tabPage_bootloader.SuspendLayout();
            this.groupBox_uploadFirmware.SuspendLayout();
            this.tabPage_about.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_openPort
            // 
            this.button_openPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_openPort.Location = new System.Drawing.Point(692, 20);
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
            this.tabControl_main.Controls.Add(this.tabPage_bootloader);
            this.tabControl_main.Controls.Add(this.tabPage_about);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(812, 490);
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
            this.tabPage_serialPort.Size = new System.Drawing.Size(804, 464);
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
            this.groupBox_packetCounts.Size = new System.Drawing.Size(798, 84);
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
            this.groupBox_OpenClosePort.Size = new System.Drawing.Size(798, 59);
            this.groupBox_OpenClosePort.TabIndex = 0;
            this.groupBox_OpenClosePort.TabStop = false;
            this.groupBox_OpenClosePort.Text = "Open/Close Port";
            // 
            // button_refreshList
            // 
            this.button_refreshList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_refreshList.Location = new System.Drawing.Point(586, 20);
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
            this.tabPage_registers.Size = new System.Drawing.Size(804, 464);
            this.tabPage_registers.TabIndex = 6;
            this.tabPage_registers.Text = "Registers";
            this.tabPage_registers.UseVisualStyleBackColor = true;
            // 
            // appendedTreeView_registers
            // 
            this.appendedTreeView_registers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appendedTreeView_registers.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.appendedTreeView_registers.Location = new System.Drawing.Point(3, 3);
            this.appendedTreeView_registers.Name = "appendedTreeView_registers";
            this.appendedTreeView_registers.Size = new System.Drawing.Size(798, 458);
            this.appendedTreeView_registers.TabIndex = 0;
            this.appendedTreeView_registers.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.appendedTreeView_registers_NodeMouseClick);
            // 
            // tabPage_dateTime
            // 
            this.tabPage_dateTime.Controls.Add(this.groupBox_dateTime);
            this.tabPage_dateTime.Location = new System.Drawing.Point(4, 22);
            this.tabPage_dateTime.Name = "tabPage_dateTime";
            this.tabPage_dateTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_dateTime.Size = new System.Drawing.Size(804, 464);
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
            this.groupBox_dateTime.Size = new System.Drawing.Size(798, 59);
            this.groupBox_dateTime.TabIndex = 0;
            this.groupBox_dateTime.TabStop = false;
            this.groupBox_dateTime.Text = "Date/Time";
            // 
            // button_setDateTime
            // 
            this.button_setDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_setDateTime.Location = new System.Drawing.Point(665, 20);
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
            this.button_readDateTime.Location = new System.Drawing.Point(534, 20);
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
            this.textBox_receivedDataTime.Size = new System.Drawing.Size(412, 20);
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
            this.tabPage_commands.Controls.Add(this.groupBox_sensorCalibration);
            this.tabPage_commands.Controls.Add(this.groupBox_general);
            this.tabPage_commands.Location = new System.Drawing.Point(4, 22);
            this.tabPage_commands.Name = "tabPage_commands";
            this.tabPage_commands.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_commands.Size = new System.Drawing.Size(804, 464);
            this.tabPage_commands.TabIndex = 9;
            this.tabPage_commands.Text = "Commands";
            this.tabPage_commands.UseVisualStyleBackColor = true;
            // 
            // groupBox_receivedCommandMessages
            // 
            this.groupBox_receivedCommandMessages.Controls.Add(this.checkBox_displayCommandConfirmations);
            this.groupBox_receivedCommandMessages.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_receivedCommandMessages.Location = new System.Drawing.Point(3, 180);
            this.groupBox_receivedCommandMessages.Name = "groupBox_receivedCommandMessages";
            this.groupBox_receivedCommandMessages.Size = new System.Drawing.Size(798, 59);
            this.groupBox_receivedCommandMessages.TabIndex = 3;
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
            this.groupBox_algorithm.Controls.Add(this.button_clearTare);
            this.groupBox_algorithm.Controls.Add(this.button_tare);
            this.groupBox_algorithm.Controls.Add(this.button_resetAlgorithm);
            this.groupBox_algorithm.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_algorithm.Location = new System.Drawing.Point(3, 121);
            this.groupBox_algorithm.Name = "groupBox_algorithm";
            this.groupBox_algorithm.Size = new System.Drawing.Size(798, 59);
            this.groupBox_algorithm.TabIndex = 2;
            this.groupBox_algorithm.TabStop = false;
            this.groupBox_algorithm.Text = "Algorithm";
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
            // button_resetAlgorithm
            // 
            this.button_resetAlgorithm.Location = new System.Drawing.Point(10, 20);
            this.button_resetAlgorithm.Name = "button_resetAlgorithm";
            this.button_resetAlgorithm.Size = new System.Drawing.Size(147, 23);
            this.button_resetAlgorithm.TabIndex = 0;
            this.button_resetAlgorithm.Text = "Reset Algorithm";
            this.button_resetAlgorithm.UseVisualStyleBackColor = true;
            this.button_resetAlgorithm.Click += new System.EventHandler(this.button_resetAlgorithm_Click);
            // 
            // groupBox_sensorCalibration
            // 
            this.groupBox_sensorCalibration.Controls.Add(this.button_sampleGyroBiasAtT2);
            this.groupBox_sensorCalibration.Controls.Add(this.button_lookupAccelBiasAndSens);
            this.groupBox_sensorCalibration.Controls.Add(this.button_measMagParameters);
            this.groupBox_sensorCalibration.Controls.Add(this.button_sampleGyroBiasAtT1);
            this.groupBox_sensorCalibration.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_sensorCalibration.Location = new System.Drawing.Point(3, 62);
            this.groupBox_sensorCalibration.Name = "groupBox_sensorCalibration";
            this.groupBox_sensorCalibration.Size = new System.Drawing.Size(798, 59);
            this.groupBox_sensorCalibration.TabIndex = 1;
            this.groupBox_sensorCalibration.TabStop = false;
            this.groupBox_sensorCalibration.Text = "Sensor Calibration";
            // 
            // button_sampleGyroBiasAtT2
            // 
            this.button_sampleGyroBiasAtT2.Location = new System.Drawing.Point(163, 20);
            this.button_sampleGyroBiasAtT2.Name = "button_sampleGyroBiasAtT2";
            this.button_sampleGyroBiasAtT2.Size = new System.Drawing.Size(147, 23);
            this.button_sampleGyroBiasAtT2.TabIndex = 3;
            this.button_sampleGyroBiasAtT2.Text = "Sample Gyro. Bias @ T2";
            this.button_sampleGyroBiasAtT2.UseVisualStyleBackColor = true;
            this.button_sampleGyroBiasAtT2.Click += new System.EventHandler(this.button_sampleGyroBiasAtT2_Click);
            // 
            // button_lookupAccelBiasAndSens
            // 
            this.button_lookupAccelBiasAndSens.Location = new System.Drawing.Point(316, 20);
            this.button_lookupAccelBiasAndSens.Name = "button_lookupAccelBiasAndSens";
            this.button_lookupAccelBiasAndSens.Size = new System.Drawing.Size(147, 23);
            this.button_lookupAccelBiasAndSens.TabIndex = 1;
            this.button_lookupAccelBiasAndSens.Text = "Lookup Accel. Bias/Sens.";
            this.button_lookupAccelBiasAndSens.UseVisualStyleBackColor = true;
            this.button_lookupAccelBiasAndSens.Click += new System.EventHandler(this.button_lookupAccelSensitivity_Click);
            // 
            // button_measMagParameters
            // 
            this.button_measMagParameters.Location = new System.Drawing.Point(469, 20);
            this.button_measMagParameters.Name = "button_measMagParameters";
            this.button_measMagParameters.Size = new System.Drawing.Size(147, 23);
            this.button_measMagParameters.TabIndex = 2;
            this.button_measMagParameters.Text = "Measure Mag. Bias/Sens.";
            this.button_measMagParameters.UseVisualStyleBackColor = true;
            this.button_measMagParameters.Click += new System.EventHandler(this.button_measMagBiasSens_Click);
            // 
            // button_sampleGyroBiasAtT1
            // 
            this.button_sampleGyroBiasAtT1.Location = new System.Drawing.Point(10, 20);
            this.button_sampleGyroBiasAtT1.Name = "button_sampleGyroBiasAtT1";
            this.button_sampleGyroBiasAtT1.Size = new System.Drawing.Size(147, 23);
            this.button_sampleGyroBiasAtT1.TabIndex = 0;
            this.button_sampleGyroBiasAtT1.Text = "Sample Gyro. Bias @ T1";
            this.button_sampleGyroBiasAtT1.UseVisualStyleBackColor = true;
            this.button_sampleGyroBiasAtT1.Click += new System.EventHandler(this.button_sampleGyroBiasAtT1_Click);
            // 
            // groupBox_general
            // 
            this.groupBox_general.Controls.Add(this.button_resetSleepTimer);
            this.groupBox_general.Controls.Add(this.button_sleep);
            this.groupBox_general.Controls.Add(this.button_resetDevice);
            this.groupBox_general.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_general.Location = new System.Drawing.Point(3, 3);
            this.groupBox_general.Name = "groupBox_general";
            this.groupBox_general.Size = new System.Drawing.Size(798, 59);
            this.groupBox_general.TabIndex = 0;
            this.groupBox_general.TabStop = false;
            this.groupBox_general.Text = "General";
            // 
            // button_resetSleepTimer
            // 
            this.button_resetSleepTimer.Location = new System.Drawing.Point(316, 20);
            this.button_resetSleepTimer.Name = "button_resetSleepTimer";
            this.button_resetSleepTimer.Size = new System.Drawing.Size(147, 23);
            this.button_resetSleepTimer.TabIndex = 2;
            this.button_resetSleepTimer.Text = "Reset Sleep Timer";
            this.button_resetSleepTimer.UseVisualStyleBackColor = true;
            this.button_resetSleepTimer.Click += new System.EventHandler(this.button_resetSleepTimer_Click);
            // 
            // button_sleep
            // 
            this.button_sleep.Location = new System.Drawing.Point(163, 20);
            this.button_sleep.Name = "button_sleep";
            this.button_sleep.Size = new System.Drawing.Size(147, 23);
            this.button_sleep.TabIndex = 1;
            this.button_sleep.Text = "Sleep";
            this.button_sleep.UseVisualStyleBackColor = true;
            this.button_sleep.Click += new System.EventHandler(this.button_sleep_Click);
            // 
            // button_resetDevice
            // 
            this.button_resetDevice.Location = new System.Drawing.Point(10, 20);
            this.button_resetDevice.Name = "button_resetDevice";
            this.button_resetDevice.Size = new System.Drawing.Size(147, 23);
            this.button_resetDevice.TabIndex = 0;
            this.button_resetDevice.Text = "Reset Device";
            this.button_resetDevice.UseVisualStyleBackColor = true;
            this.button_resetDevice.Click += new System.EventHandler(this.button_resetDevice_Click);
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
            this.tabPage_ViewSensorData.Size = new System.Drawing.Size(804, 464);
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
            this.groupBox_orienData.Size = new System.Drawing.Size(798, 59);
            this.groupBox_orienData.TabIndex = 2;
            this.groupBox_orienData.TabStop = false;
            this.groupBox_orienData.Text = "Orientation Data";
            // 
            // label_psi
            // 
            this.label_psi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_psi.AutoSize = true;
            this.label_psi.ForeColor = System.Drawing.Color.Blue;
            this.label_psi.Location = new System.Drawing.Point(773, 24);
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
            this.label_theta.Location = new System.Drawing.Point(754, 24);
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
            this.label_phi.Location = new System.Drawing.Point(733, 24);
            this.label_phi.Name = "label_phi";
            this.label_phi.Size = new System.Drawing.Size(15, 13);
            this.label_phi.TabIndex = 43;
            this.label_phi.Text = "φ";
            // 
            // label_eulerLegend
            // 
            this.label_eulerLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_eulerLegend.AutoSize = true;
            this.label_eulerLegend.Location = new System.Drawing.Point(681, 24);
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
            this.groupBox_sensorData.Size = new System.Drawing.Size(798, 59);
            this.groupBox_sensorData.TabIndex = 1;
            this.groupBox_sensorData.TabStop = false;
            this.groupBox_sensorData.Text = "Inertial/Magnetic Sensor Data";
            // 
            // label_legendZ
            // 
            this.label_legendZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_legendZ.AutoSize = true;
            this.label_legendZ.ForeColor = System.Drawing.Color.Blue;
            this.label_legendZ.Location = new System.Drawing.Point(774, 25);
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
            this.label_legendY.Location = new System.Drawing.Point(754, 25);
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
            this.label_legendX.Location = new System.Drawing.Point(734, 25);
            this.label_legendX.Name = "label_legendX";
            this.label_legendX.Size = new System.Drawing.Size(14, 13);
            this.label_legendX.TabIndex = 39;
            this.label_legendX.Text = "X";
            // 
            // label_sensorLegend
            // 
            this.label_sensorLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_sensorLegend.AutoSize = true;
            this.label_sensorLegend.Location = new System.Drawing.Point(682, 25);
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
            this.groupBox_battThermData.Size = new System.Drawing.Size(798, 59);
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
            this.tabPage_auxillaryPort.Controls.Add(this.groupBox_digitalIO);
            this.tabPage_auxillaryPort.Location = new System.Drawing.Point(4, 22);
            this.tabPage_auxillaryPort.Name = "tabPage_auxillaryPort";
            this.tabPage_auxillaryPort.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_auxillaryPort.Size = new System.Drawing.Size(804, 464);
            this.tabPage_auxillaryPort.TabIndex = 14;
            this.tabPage_auxillaryPort.Text = "Auxillary Port";
            this.tabPage_auxillaryPort.UseVisualStyleBackColor = true;
            // 
            // groupBox_digitalIO
            // 
            this.groupBox_digitalIO.Controls.Add(this.button_showDigitalIOpanel);
            this.groupBox_digitalIO.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_digitalIO.Location = new System.Drawing.Point(3, 3);
            this.groupBox_digitalIO.Name = "groupBox_digitalIO";
            this.groupBox_digitalIO.Size = new System.Drawing.Size(798, 59);
            this.groupBox_digitalIO.TabIndex = 0;
            this.groupBox_digitalIO.TabStop = false;
            this.groupBox_digitalIO.Text = "Digital I/O";
            // 
            // button_showDigitalIOpanel
            // 
            this.button_showDigitalIOpanel.Location = new System.Drawing.Point(10, 20);
            this.button_showDigitalIOpanel.Name = "button_showDigitalIOpanel";
            this.button_showDigitalIOpanel.Size = new System.Drawing.Size(147, 23);
            this.button_showDigitalIOpanel.TabIndex = 41;
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
            this.tabPage_dataLogger.Size = new System.Drawing.Size(804, 464);
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
            this.groupBox_logReceivedDataToFile.Size = new System.Drawing.Size(798, 59);
            this.groupBox_logReceivedDataToFile.TabIndex = 0;
            this.groupBox_logReceivedDataToFile.TabStop = false;
            this.groupBox_logReceivedDataToFile.Text = "Log Received Data To File";
            // 
            // button_dataLoggerFilePathBrowse
            // 
            this.button_dataLoggerFilePathBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_dataLoggerFilePathBrowse.Location = new System.Drawing.Point(596, 22);
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
            this.textBox_dataLoggerFilePath.Size = new System.Drawing.Size(526, 20);
            this.textBox_dataLoggerFilePath.TabIndex = 0;
            // 
            // button_dataLoggerStart
            // 
            this.button_dataLoggerStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_dataLoggerStart.Location = new System.Drawing.Point(697, 22);
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
            this.tabPage_SDcard.Size = new System.Drawing.Size(804, 464);
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
            this.groupBox_convertBinaryFile.Size = new System.Drawing.Size(798, 60);
            this.groupBox_convertBinaryFile.TabIndex = 0;
            this.groupBox_convertBinaryFile.TabStop = false;
            this.groupBox_convertBinaryFile.Text = "Convert Binary File";
            // 
            // button_convertBinaryFileConvertBrowse
            // 
            this.button_convertBinaryFileConvertBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_convertBinaryFileConvertBrowse.Location = new System.Drawing.Point(596, 22);
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
            this.textBox_convertBinaryFileFilePath.Size = new System.Drawing.Size(526, 20);
            this.textBox_convertBinaryFileFilePath.TabIndex = 0;
            // 
            // button_convertBinaryFileConvert
            // 
            this.button_convertBinaryFileConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_convertBinaryFileConvert.Location = new System.Drawing.Point(697, 22);
            this.button_convertBinaryFileConvert.Name = "button_convertBinaryFileConvert";
            this.button_convertBinaryFileConvert.Size = new System.Drawing.Size(95, 23);
            this.button_convertBinaryFileConvert.TabIndex = 2;
            this.button_convertBinaryFileConvert.Text = "Convert";
            this.button_convertBinaryFileConvert.UseVisualStyleBackColor = true;
            this.button_convertBinaryFileConvert.Click += new System.EventHandler(this.button_convertBinaryFileConvert_Click);
            // 
            // tabPage_hardIronCalibration
            // 
            this.tabPage_hardIronCalibration.Controls.Add(this.groupBox_hardIronCalibrationAlgorithm);
            this.tabPage_hardIronCalibration.Controls.Add(this.groupBox_step2collectHardIronCalibrationDataSet);
            this.tabPage_hardIronCalibration.Controls.Add(this.groupBox_step1ClearHardIronBiasRegisters);
            this.tabPage_hardIronCalibration.Location = new System.Drawing.Point(4, 22);
            this.tabPage_hardIronCalibration.Name = "tabPage_hardIronCalibration";
            this.tabPage_hardIronCalibration.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_hardIronCalibration.Size = new System.Drawing.Size(804, 464);
            this.tabPage_hardIronCalibration.TabIndex = 10;
            this.tabPage_hardIronCalibration.Text = "Hard-Iron Calibration";
            this.tabPage_hardIronCalibration.UseVisualStyleBackColor = true;
            // 
            // groupBox_hardIronCalibrationAlgorithm
            // 
            this.groupBox_hardIronCalibrationAlgorithm.Controls.Add(this.button_hardIronCalBrowse);
            this.groupBox_hardIronCalibrationAlgorithm.Controls.Add(this.label_hardIronCalFilePath);
            this.groupBox_hardIronCalibrationAlgorithm.Controls.Add(this.textBox_hardIronCalFilePath);
            this.groupBox_hardIronCalibrationAlgorithm.Controls.Add(this.button_hardIronCalRun);
            this.groupBox_hardIronCalibrationAlgorithm.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_hardIronCalibrationAlgorithm.Location = new System.Drawing.Point(3, 123);
            this.groupBox_hardIronCalibrationAlgorithm.Name = "groupBox_hardIronCalibrationAlgorithm";
            this.groupBox_hardIronCalibrationAlgorithm.Size = new System.Drawing.Size(798, 60);
            this.groupBox_hardIronCalibrationAlgorithm.TabIndex = 0;
            this.groupBox_hardIronCalibrationAlgorithm.TabStop = false;
            this.groupBox_hardIronCalibrationAlgorithm.Text = "Step 3 - Run Hard-Iron Calibration Algorithm";
            // 
            // button_hardIronCalBrowse
            // 
            this.button_hardIronCalBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_hardIronCalBrowse.Location = new System.Drawing.Point(596, 22);
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
            this.textBox_hardIronCalFilePath.Size = new System.Drawing.Size(526, 20);
            this.textBox_hardIronCalFilePath.TabIndex = 0;
            // 
            // button_hardIronCalRun
            // 
            this.button_hardIronCalRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_hardIronCalRun.Location = new System.Drawing.Point(697, 22);
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
            this.groupBox_step2collectHardIronCalibrationDataSet.Size = new System.Drawing.Size(798, 60);
            this.groupBox_step2collectHardIronCalibrationDataSet.TabIndex = 2;
            this.groupBox_step2collectHardIronCalibrationDataSet.TabStop = false;
            this.groupBox_step2collectHardIronCalibrationDataSet.Text = "Step 2 - Collect Hard-Iron Calibration Dataset";
            // 
            // button_collectHardIronCalDatasetBrowse
            // 
            this.button_collectHardIronCalDatasetBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_collectHardIronCalDatasetBrowse.Location = new System.Drawing.Point(596, 22);
            this.button_collectHardIronCalDatasetBrowse.Name = "button_collectHardIronCalDatasetBrowse";
            this.button_collectHardIronCalDatasetBrowse.Size = new System.Drawing.Size(95, 23);
            this.button_collectHardIronCalDatasetBrowse.TabIndex = 49;
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
            this.textBox_collectHardIronCalDatasetFilePath.Size = new System.Drawing.Size(526, 20);
            this.textBox_collectHardIronCalDatasetFilePath.TabIndex = 48;
            this.textBox_collectHardIronCalDatasetFilePath.TextChanged += new System.EventHandler(this.textBox_collectHardIronCalDatasetFilePath_TextChanged);
            // 
            // button_collectHardIronCalDatasetStartLogging
            // 
            this.button_collectHardIronCalDatasetStartLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_collectHardIronCalDatasetStartLogging.Location = new System.Drawing.Point(697, 22);
            this.button_collectHardIronCalDatasetStartLogging.Name = "button_collectHardIronCalDatasetStartLogging";
            this.button_collectHardIronCalDatasetStartLogging.Size = new System.Drawing.Size(95, 23);
            this.button_collectHardIronCalDatasetStartLogging.TabIndex = 50;
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
            this.groupBox_step1ClearHardIronBiasRegisters.Size = new System.Drawing.Size(798, 60);
            this.groupBox_step1ClearHardIronBiasRegisters.TabIndex = 1;
            this.groupBox_step1ClearHardIronBiasRegisters.TabStop = false;
            this.groupBox_step1ClearHardIronBiasRegisters.Text = "Step 1 - Clear Hard-Iron Bias Registers";
            // 
            // button_clearHardIronRegisters
            // 
            this.button_clearHardIronRegisters.Location = new System.Drawing.Point(11, 22);
            this.button_clearHardIronRegisters.Name = "button_clearHardIronRegisters";
            this.button_clearHardIronRegisters.Size = new System.Drawing.Size(147, 23);
            this.button_clearHardIronRegisters.TabIndex = 3;
            this.button_clearHardIronRegisters.Text = "Clear Hard-Iron Regsiters";
            this.button_clearHardIronRegisters.UseVisualStyleBackColor = true;
            this.button_clearHardIronRegisters.Click += new System.EventHandler(this.button_clearHardIronRegisters_Click);
            // 
            // tabPage_bootloader
            // 
            this.tabPage_bootloader.AutoScroll = true;
            this.tabPage_bootloader.Controls.Add(this.groupBox_uploadFirmware);
            this.tabPage_bootloader.Location = new System.Drawing.Point(4, 22);
            this.tabPage_bootloader.Name = "tabPage_bootloader";
            this.tabPage_bootloader.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_bootloader.Size = new System.Drawing.Size(804, 464);
            this.tabPage_bootloader.TabIndex = 5;
            this.tabPage_bootloader.Text = "Bootloader";
            this.tabPage_bootloader.UseVisualStyleBackColor = true;
            // 
            // groupBox_uploadFirmware
            // 
            this.groupBox_uploadFirmware.Controls.Add(this.button_bootloaderBrowse);
            this.groupBox_uploadFirmware.Controls.Add(this.label_bootloaderFilePath);
            this.groupBox_uploadFirmware.Controls.Add(this.textBox_bootloaderFilePath);
            this.groupBox_uploadFirmware.Controls.Add(this.button_bootloaderUpload);
            this.groupBox_uploadFirmware.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_uploadFirmware.Location = new System.Drawing.Point(3, 3);
            this.groupBox_uploadFirmware.Name = "groupBox_uploadFirmware";
            this.groupBox_uploadFirmware.Size = new System.Drawing.Size(798, 60);
            this.groupBox_uploadFirmware.TabIndex = 0;
            this.groupBox_uploadFirmware.TabStop = false;
            this.groupBox_uploadFirmware.Text = "Upload Firmware";
            // 
            // button_bootloaderBrowse
            // 
            this.button_bootloaderBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_bootloaderBrowse.Location = new System.Drawing.Point(596, 22);
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
            this.textBox_bootloaderFilePath.Size = new System.Drawing.Size(526, 20);
            this.textBox_bootloaderFilePath.TabIndex = 0;
            // 
            // button_bootloaderUpload
            // 
            this.button_bootloaderUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_bootloaderUpload.Location = new System.Drawing.Point(697, 22);
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
            this.tabPage_about.Controls.Add(this.linkLabel_sourceforgenetprojectstaoframework);
            this.tabPage_about.Controls.Add(this.linkLabel_wwwoscilloscopelibcom);
            this.tabPage_about.Controls.Add(this.label_theFollwingLinksProvideMoreInfo);
            this.tabPage_about.Controls.Add(this.label_GUIversionNum);
            this.tabPage_about.Controls.Add(this.label_APIversionNum);
            this.tabPage_about.Controls.Add(this.label_compatibleFirmwareVersionNums);
            this.tabPage_about.Controls.Add(this.linkLabel_wwwxiocouk);
            this.tabPage_about.Controls.Add(this.label_forMoreInfo);
            this.tabPage_about.Controls.Add(this.label_thexIMUGUIis);
            this.tabPage_about.Controls.Add(this.label_compatibleFirmwareVersions);
            this.tabPage_about.Controls.Add(this.label_APIversion);
            this.tabPage_about.Controls.Add(this.label_GUIversion);
            this.tabPage_about.Location = new System.Drawing.Point(4, 22);
            this.tabPage_about.Name = "tabPage_about";
            this.tabPage_about.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_about.Size = new System.Drawing.Size(804, 464);
            this.tabPage_about.TabIndex = 2;
            this.tabPage_about.Text = "About";
            this.tabPage_about.UseVisualStyleBackColor = true;
            // 
            // linkLabel_sourceforgenetprojectstaoframework
            // 
            this.linkLabel_sourceforgenetprojectstaoframework.AutoSize = true;
            this.linkLabel_sourceforgenetprojectstaoframework.Location = new System.Drawing.Point(8, 235);
            this.linkLabel_sourceforgenetprojectstaoframework.Name = "linkLabel_sourceforgenetprojectstaoframework";
            this.linkLabel_sourceforgenetprojectstaoframework.Size = new System.Drawing.Size(197, 13);
            this.linkLabel_sourceforgenetprojectstaoframework.TabIndex = 35;
            this.linkLabel_sourceforgenetprojectstaoframework.TabStop = true;
            this.linkLabel_sourceforgenetprojectstaoframework.Text = "sourceforge.net/projects/taoframework/";
            this.linkLabel_sourceforgenetprojectstaoframework.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_httpsourceforgenetprojectstaoframework_LinkClicked);
            // 
            // linkLabel_wwwoscilloscopelibcom
            // 
            this.linkLabel_wwwoscilloscopelibcom.AutoSize = true;
            this.linkLabel_wwwoscilloscopelibcom.Location = new System.Drawing.Point(8, 215);
            this.linkLabel_wwwoscilloscopelibcom.Name = "linkLabel_wwwoscilloscopelibcom";
            this.linkLabel_wwwoscilloscopelibcom.Size = new System.Drawing.Size(128, 13);
            this.linkLabel_wwwoscilloscopelibcom.TabIndex = 34;
            this.linkLabel_wwwoscilloscopelibcom.TabStop = true;
            this.linkLabel_wwwoscilloscopelibcom.Text = "www.oscilloscope-lib.com";
            this.linkLabel_wwwoscilloscopelibcom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_wwwoscilloscopelibcom_LinkClicked);
            // 
            // label_theFollwingLinksProvideMoreInfo
            // 
            this.label_theFollwingLinksProvideMoreInfo.AutoSize = true;
            this.label_theFollwingLinksProvideMoreInfo.Location = new System.Drawing.Point(8, 195);
            this.label_theFollwingLinksProvideMoreInfo.Name = "label_theFollwingLinksProvideMoreInfo";
            this.label_theFollwingLinksProvideMoreInfo.Size = new System.Drawing.Size(523, 13);
            this.label_theFollwingLinksProvideMoreInfo.TabIndex = 33;
            this.label_theFollwingLinksProvideMoreInfo.Text = "The following links provide more information and downloads for the third party re" +
                "sources used by this software:";
            // 
            // label_GUIversionNum
            // 
            this.label_GUIversionNum.AutoSize = true;
            this.label_GUIversionNum.Location = new System.Drawing.Point(160, 115);
            this.label_GUIversionNum.Name = "label_GUIversionNum";
            this.label_GUIversionNum.Size = new System.Drawing.Size(13, 13);
            this.label_GUIversionNum.TabIndex = 32;
            this.label_GUIversionNum.Text = "?";
            // 
            // label_APIversionNum
            // 
            this.label_APIversionNum.AutoSize = true;
            this.label_APIversionNum.Location = new System.Drawing.Point(160, 135);
            this.label_APIversionNum.Name = "label_APIversionNum";
            this.label_APIversionNum.Size = new System.Drawing.Size(13, 13);
            this.label_APIversionNum.TabIndex = 31;
            this.label_APIversionNum.Text = "?";
            // 
            // label_compatibleFirmwareVersionNums
            // 
            this.label_compatibleFirmwareVersionNums.AutoSize = true;
            this.label_compatibleFirmwareVersionNums.Location = new System.Drawing.Point(160, 155);
            this.label_compatibleFirmwareVersionNums.Name = "label_compatibleFirmwareVersionNums";
            this.label_compatibleFirmwareVersionNums.Size = new System.Drawing.Size(13, 13);
            this.label_compatibleFirmwareVersionNums.TabIndex = 30;
            this.label_compatibleFirmwareVersionNums.Text = "?";
            // 
            // linkLabel_wwwxiocouk
            // 
            this.linkLabel_wwwxiocouk.AutoSize = true;
            this.linkLabel_wwwxiocouk.Location = new System.Drawing.Point(8, 75);
            this.linkLabel_wwwxiocouk.Name = "linkLabel_wwwxiocouk";
            this.linkLabel_wwwxiocouk.Size = new System.Drawing.Size(80, 13);
            this.linkLabel_wwwxiocouk.TabIndex = 29;
            this.linkLabel_wwwxiocouk.TabStop = true;
            this.linkLabel_wwwxiocouk.Text = "www.x-io.co.uk";
            this.linkLabel_wwwxiocouk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_wwwxiocouk_LinkClicked);
            // 
            // label_forMoreInfo
            // 
            this.label_forMoreInfo.AutoSize = true;
            this.label_forMoreInfo.Location = new System.Drawing.Point(8, 55);
            this.label_forMoreInfo.Name = "label_forMoreInfo";
            this.label_forMoreInfo.Size = new System.Drawing.Size(456, 13);
            this.label_forMoreInfo.TabIndex = 27;
            this.label_forMoreInfo.Text = "For more information and to obtain the latest versions of software, firmware and " +
                "API, please see:";
            // 
            // label_thexIMUGUIis
            // 
            this.label_thexIMUGUIis.Location = new System.Drawing.Point(8, 12);
            this.label_thexIMUGUIis.Name = "label_thexIMUGUIis";
            this.label_thexIMUGUIis.Size = new System.Drawing.Size(788, 33);
            this.label_thexIMUGUIis.TabIndex = 26;
            this.label_thexIMUGUIis.Text = resources.GetString("label_thexIMUGUIis.Text");
            // 
            // label_compatibleFirmwareVersions
            // 
            this.label_compatibleFirmwareVersions.AutoSize = true;
            this.label_compatibleFirmwareVersions.Location = new System.Drawing.Point(8, 155);
            this.label_compatibleFirmwareVersions.Name = "label_compatibleFirmwareVersions";
            this.label_compatibleFirmwareVersions.Size = new System.Drawing.Size(146, 13);
            this.label_compatibleFirmwareVersions.TabIndex = 25;
            this.label_compatibleFirmwareVersions.Text = "Compatible firmware versions:";
            // 
            // label_APIversion
            // 
            this.label_APIversion.AutoSize = true;
            this.label_APIversion.Location = new System.Drawing.Point(8, 135);
            this.label_APIversion.Name = "label_APIversion";
            this.label_APIversion.Size = new System.Drawing.Size(64, 13);
            this.label_APIversion.TabIndex = 24;
            this.label_APIversion.Text = "API version:";
            // 
            // label_GUIversion
            // 
            this.label_GUIversion.AutoSize = true;
            this.label_GUIversion.Location = new System.Drawing.Point(8, 115);
            this.label_GUIversion.Name = "label_GUIversion";
            this.label_GUIversion.Size = new System.Drawing.Size(66, 13);
            this.label_GUIversion.TabIndex = 23;
            this.label_GUIversion.Text = "GUI version:";
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 490);
            this.Controls.Add(this.tabControl_main);
            this.Name = "Form_main";
            this.Text = "x-IMU GUI";
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
            this.groupBox_sensorCalibration.ResumeLayout(false);
            this.groupBox_general.ResumeLayout(false);
            this.tabPage_ViewSensorData.ResumeLayout(false);
            this.groupBox_orienData.ResumeLayout(false);
            this.groupBox_orienData.PerformLayout();
            this.groupBox_sensorData.ResumeLayout(false);
            this.groupBox_sensorData.PerformLayout();
            this.groupBox_battThermData.ResumeLayout(false);
            this.tabPage_auxillaryPort.ResumeLayout(false);
            this.groupBox_digitalIO.ResumeLayout(false);
            this.tabPage_dataLogger.ResumeLayout(false);
            this.groupBox_logReceivedDataToFile.ResumeLayout(false);
            this.groupBox_logReceivedDataToFile.PerformLayout();
            this.tabPage_SDcard.ResumeLayout(false);
            this.groupBox_convertBinaryFile.ResumeLayout(false);
            this.groupBox_convertBinaryFile.PerformLayout();
            this.tabPage_hardIronCalibration.ResumeLayout(false);
            this.groupBox_hardIronCalibrationAlgorithm.ResumeLayout(false);
            this.groupBox_hardIronCalibrationAlgorithm.PerformLayout();
            this.groupBox_step2collectHardIronCalibrationDataSet.ResumeLayout(false);
            this.groupBox_step2collectHardIronCalibrationDataSet.PerformLayout();
            this.groupBox_step1ClearHardIronBiasRegisters.ResumeLayout(false);
            this.tabPage_bootloader.ResumeLayout(false);
            this.groupBox_uploadFirmware.ResumeLayout(false);
            this.groupBox_uploadFirmware.PerformLayout();
            this.tabPage_about.ResumeLayout(false);
            this.tabPage_about.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_openPort;
        private System.Windows.Forms.Label label_portName;
        private System.Windows.Forms.ComboBox comboBox_portName;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_serialPort;
        private System.Windows.Forms.TabPage tabPage_about;
        private System.Windows.Forms.TabPage tabPage_ViewSensorData;
        private System.Windows.Forms.TabPage tabPage_bootloader;
        private System.Windows.Forms.Button button_refreshList;
        private System.Windows.Forms.GroupBox groupBox_battThermData;
        private System.Windows.Forms.GroupBox groupBox_sensorData;
        private System.Windows.Forms.GroupBox groupBox_OpenClosePort;
        private System.Windows.Forms.GroupBox groupBox_packetCounts;
        private System.Windows.Forms.GroupBox groupBox_orienData;
        private System.Windows.Forms.Button button_showMagGraph;
        private System.Windows.Forms.Button button_showAccelGraph;
        private System.Windows.Forms.Button button_showGyroGraph;
        private System.Windows.Forms.Button button_show3Dcuboid;
        private System.Windows.Forms.GroupBox groupBox_uploadFirmware;
        private System.Windows.Forms.Button button_bootloaderBrowse;
        private System.Windows.Forms.Label label_bootloaderFilePath;
        private System.Windows.Forms.TextBox textBox_bootloaderFilePath;
        private System.Windows.Forms.Button button_bootloaderUpload;
        private System.Windows.Forms.Label label_legendZ;
        private System.Windows.Forms.Label label_legendY;
        private System.Windows.Forms.Label label_legendX;
        private System.Windows.Forms.Label label_sensorLegend;
        private System.Windows.Forms.TabPage tabPage_registers;
        private System.Windows.Forms.Button button_showBatteryGraph;
        private System.Windows.Forms.Button button_showThermGraph;
        private System.Windows.Forms.Label label_psi;
        private System.Windows.Forms.Label label_theta;
        private System.Windows.Forms.Label label_phi;
        private System.Windows.Forms.Label label_eulerLegend;
        private System.Windows.Forms.Button button_showEulerAngleGraph;
        private System.Windows.Forms.TabPage tabPage_commands;
        private System.Windows.Forms.GroupBox groupBox_general;
        private System.Windows.Forms.Button button_resetDevice;
        private System.Windows.Forms.Button button_sleep;
        private System.Windows.Forms.Button button_resetSleepTimer;
        private System.Windows.Forms.GroupBox groupBox_sensorCalibration;
        private System.Windows.Forms.Button button_sampleGyroBiasAtT1;
        private System.Windows.Forms.Button button_sampleGyroBiasAtT2;
        private System.Windows.Forms.Button button_lookupAccelBiasAndSens;
        private System.Windows.Forms.Button button_measMagParameters;
        private System.Windows.Forms.GroupBox groupBox_algorithm;
        private System.Windows.Forms.Button button_resetAlgorithm;
        private System.Windows.Forms.Button button_tare;
        private System.Windows.Forms.Button button_clearTare;
        private System.Windows.Forms.GroupBox groupBox_receivedCommandMessages;
        private System.Windows.Forms.CheckBox checkBox_displayCommandConfirmations;
        private System.Windows.Forms.TabPage tabPage_hardIronCalibration;
        private System.Windows.Forms.GroupBox groupBox_hardIronCalibrationAlgorithm;
        private System.Windows.Forms.Button button_hardIronCalBrowse;
        private System.Windows.Forms.Label label_hardIronCalFilePath;
        private System.Windows.Forms.TextBox textBox_hardIronCalFilePath;
        private System.Windows.Forms.Button button_hardIronCalRun;
        private System.Windows.Forms.Label label_packetsSent;
        private System.Windows.Forms.TextBox textBox_packetsSent;
        private System.Windows.Forms.TextBox textBox_packetsReceived;
        private System.Windows.Forms.Label label_packetsReceived;
        private System.Windows.Forms.TabPage tabPage_dateTime;
        private System.Windows.Forms.GroupBox groupBox_dateTime;
        private System.Windows.Forms.TextBox textBox_receivedDataTime;
        private System.Windows.Forms.Label label_receivedDateTime;
        private System.Windows.Forms.Button button_readDateTime;
        private System.Windows.Forms.Button button_setDateTime;
        private System.Windows.Forms.TabPage tabPage_dataLogger;
        private System.Windows.Forms.TabPage tabPage_auxillaryPort;
        private System.Windows.Forms.GroupBox groupBox_logReceivedDataToFile;
        private System.Windows.Forms.Button button_dataLoggerFilePathBrowse;
        private System.Windows.Forms.Label label_dataLoggerFilePath;
        private System.Windows.Forms.TextBox textBox_dataLoggerFilePath;
        private System.Windows.Forms.Button button_dataLoggerStart;
        private System.Windows.Forms.TabPage tabPage_SDcard;
        private System.Windows.Forms.GroupBox groupBox_convertBinaryFile;
        private System.Windows.Forms.Button button_convertBinaryFileConvertBrowse;
        private System.Windows.Forms.Label labelconvertBinaryFileFilePath;
        private System.Windows.Forms.TextBox textBox_convertBinaryFileFilePath;
        private System.Windows.Forms.Button button_convertBinaryFileConvert;
        private System.Windows.Forms.GroupBox groupBox_digitalIO;
        private System.Windows.Forms.Button button_showDigitalIOpanel;
        private System.Windows.Forms.GroupBox groupBox_step2collectHardIronCalibrationDataSet;
        private System.Windows.Forms.GroupBox groupBox_step1ClearHardIronBiasRegisters;
        private System.Windows.Forms.Button button_clearHardIronRegisters;
        private System.Windows.Forms.Button button_collectHardIronCalDatasetBrowse;
        private System.Windows.Forms.Label label_collectHardIronCalDatasetFilePath;
        private System.Windows.Forms.TextBox textBox_collectHardIronCalDatasetFilePath;
        private System.Windows.Forms.Button button_collectHardIronCalDatasetStartLogging;
        private System.Windows.Forms.Label label_compatibleFirmwareVersions;
        private System.Windows.Forms.Label label_APIversion;
        private System.Windows.Forms.Label label_GUIversion;
        private System.Windows.Forms.Label label_thexIMUGUIis;
        private System.Windows.Forms.LinkLabel linkLabel_wwwxiocouk;
        private System.Windows.Forms.Label label_forMoreInfo;
        private System.Windows.Forms.Label label_theFollwingLinksProvideMoreInfo;
        private System.Windows.Forms.Label label_GUIversionNum;
        private System.Windows.Forms.Label label_APIversionNum;
        private System.Windows.Forms.Label label_compatibleFirmwareVersionNums;
        private System.Windows.Forms.LinkLabel linkLabel_sourceforgenetprojectstaoframework;
        private System.Windows.Forms.LinkLabel linkLabel_wwwoscilloscopelibcom;

        #region appendedTreeView_registers design code and child nodes

        private AppendedTreeView appendedTreeView_registers;

        private void InitializeAppendedTreeViewComponents()
        {
            #region General

            appendedTextBoxTreeNode_FirmVersionMajorNum = new AppendedTreeNodeTextBox("Major Number:");
            appendedTextBoxTreeNode_FirmVersionMajorNum.TextBox.ReadOnly = true;
            appendedTextBoxTreeNode_FirmVersionMinorNum = new AppendedTreeNodeTextBox("Minor Number:");
            appendedTextBoxTreeNode_FirmVersionMinorNum.TextBox.ReadOnly = true;
            appendedTextBoxTreeNode_FirmwareVersion = new System.Windows.Forms.TreeNode("Firmware Version (read-only):", new AppendedTreeNodeTextBox[] {
            appendedTextBoxTreeNode_FirmVersionMajorNum,
            appendedTextBoxTreeNode_FirmVersionMinorNum});
            appendedTextBoxTreeNode_DeviceID = new AppendedTreeNodeTextBox("Device ID (read only):");
            appendedTextBoxTreeNode_DeviceID.TextBox.ReadOnly = true;
            appendedComboBoxTreeNode_buttonMode = new AppendedTreeNodeComboBox("Button Mode:");
            appendedComboBoxTreeNode_buttonMode.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedComboBoxTreeNode_buttonMode.ComboBox.Items.Add("Disabled");
            appendedComboBoxTreeNode_buttonMode.ComboBox.Items.Add("Reset device");
            appendedComboBoxTreeNode_buttonMode.ComboBox.Items.Add("Sleep/wake");
            appendedComboBoxTreeNode_buttonMode.ComboBox.Items.Add("Reset algorithm");
            appendedComboBoxTreeNode_buttonMode.ComboBox.Items.Add("Tare");
            treeNodeGeneral = new System.Windows.Forms.TreeNode("General", new System.Windows.Forms.TreeNode[] {
            appendedTextBoxTreeNode_FirmwareVersion,
            appendedTextBoxTreeNode_DeviceID,
            appendedComboBoxTreeNode_buttonMode
            });

            #endregion

            #region Sensor Calibration Parameters

            #region Battery Voltmeter

            appendedTextBoxTreeNode_battSens = new AppendedTreeNodeTextBox("Sensitivity (lsb/V):");
            appendedTextBoxTreeNode_battBias = new AppendedTreeNodeTextBox("Bias (lsb):");
            treeNode_battVoltmeter = new System.Windows.Forms.TreeNode("Battery Voltmeter", new AppendedTreeNodeTextBox[] {
            appendedTextBoxTreeNode_battSens,
            appendedTextBoxTreeNode_battBias});

            #endregion

            #region Thermometer

            appendedTextBoxTreeNode_thermSens = new AppendedTreeNodeTextBox("Sensitivity (lsb/˚C):");
            appendedTextBoxTreeNode_thermBias = new AppendedTreeNodeTextBox("Bias (lsb):");
            treeNode_thermometer = new System.Windows.Forms.TreeNode("Thermometer", new AppendedTreeNodeTextBox[] {
            appendedTextBoxTreeNode_thermSens,
            appendedTextBoxTreeNode_thermBias});

            #endregion

            #region Gyroscope

            appendedTextBoxTreeNode_gyroSensX = new AppendedTreeNodeTextBox("X:");
            appendedTextBoxTreeNode_gyroSensY = new AppendedTreeNodeTextBox("Y:");
            appendedTextBoxTreeNode_gyroSensZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_gyroSens = new System.Windows.Forms.TreeNode("Sensitivity (lsb/˚/s)", new AppendedTreeNodeTextBox[] {
            appendedTextBoxTreeNode_gyroSensX,
            appendedTextBoxTreeNode_gyroSensY,
            appendedTextBoxTreeNode_gyroSensZ});
            appendedTextBoxTreeNode_gyroBiasX = new AppendedTreeNodeTextBox("X:");
            appendedTextBoxTreeNode_gyroBiasY = new AppendedTreeNodeTextBox("Y:");
            appendedTextBoxTreeNode_gyroBiasZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_gyroBias = new System.Windows.Forms.TreeNode("Bias @ 25˚C (lsb)", new AppendedTreeNodeTextBox[] {
            appendedTextBoxTreeNode_gyroBiasX,
            appendedTextBoxTreeNode_gyroBiasY,
            appendedTextBoxTreeNode_gyroBiasZ});
            appendedTextBoxTreeNode_gyroBiasTempSensX = new AppendedTreeNodeTextBox("X:");
            appendedTextBoxTreeNode_gyroBiasTempSensY = new AppendedTreeNodeTextBox("Y:");
            appendedTextBoxTreeNode_gyroBiasTempSensZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_gyroBiasTempSens = new System.Windows.Forms.TreeNode("Bias Temperature Sensitivity (˚C/lsb)", new AppendedTreeNodeTextBox[] { 
            appendedTextBoxTreeNode_gyroBiasTempSensX,
            appendedTextBoxTreeNode_gyroBiasTempSensY,
            appendedTextBoxTreeNode_gyroBiasTempSensZ});
            appendedTextBoxTreeNode_gyroSample1Temp = new AppendedTreeNodeTextBox("Temperature (˚C):");
            appendedTextBoxTreeNode_gyroSample1BiasX = new AppendedTreeNodeTextBox("Bias X (lsb):");
            appendedTextBoxTreeNode_gyroSample1BiasY = new AppendedTreeNodeTextBox("Bias Y (lsb):");
            appendedTextBoxTreeNode_gyroSample1BiasZ = new AppendedTreeNodeTextBox("Bias Z (lsb):");
            treeNode_gyroSample1 = new System.Windows.Forms.TreeNode("Sampled Temperature 1", new AppendedTreeNodeTextBox[] {
            appendedTextBoxTreeNode_gyroSample1Temp,
            appendedTextBoxTreeNode_gyroSample1BiasX,
            appendedTextBoxTreeNode_gyroSample1BiasY,
            appendedTextBoxTreeNode_gyroSample1BiasZ});
            appendedTextBoxTreeNode_gyroSample2Temp = new AppendedTreeNodeTextBox("Temperature (˚C):");
            appendedTextBoxTreeNode_gyroSample2BiasX = new AppendedTreeNodeTextBox("Bias X (lsb):");
            appendedTextBoxTreeNode_gyroSample2BiasY = new AppendedTreeNodeTextBox("Bias Y (lsb):");
            appendedTextBoxTreeNode_gyroSample2BiasZ = new AppendedTreeNodeTextBox("Bias Z (lsb):");
            treeNode_gyroSample2 = new System.Windows.Forms.TreeNode("Sampled Temperature 2", new AppendedTreeNodeTextBox[] {
            appendedTextBoxTreeNode_gyroSample2Temp,
            appendedTextBoxTreeNode_gyroSample2BiasX,
            appendedTextBoxTreeNode_gyroSample2BiasY,
            appendedTextBoxTreeNode_gyroSample2BiasZ});
            treeNode_gyroBiasParent = new System.Windows.Forms.TreeNode("Bias", new System.Windows.Forms.TreeNode[] {
            treeNode_gyroBias,
            treeNode_gyroBiasTempSens,
            treeNode_gyroSample1,
            treeNode_gyroSample2});
            treeNode_gyroscope = new System.Windows.Forms.TreeNode("Gyroscope", new System.Windows.Forms.TreeNode[] {
            treeNode_gyroSens,
            treeNode_gyroBiasParent});

            #endregion

            #region Acceleroemter

            appendedComboBoxTreeNode_accelFullScale = new AppendedTreeNodeComboBox("Full-Scale:");
            appendedComboBoxTreeNode_accelFullScale.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedComboBoxTreeNode_accelFullScale.ComboBox.Width = 50;
            appendedComboBoxTreeNode_accelFullScale.ComboBox.Items.Add("±2 g");
            appendedComboBoxTreeNode_accelFullScale.ComboBox.Items.Add("±4 g");
            appendedComboBoxTreeNode_accelFullScale.ComboBox.Items.Add("±8 g");
            appendedTextBoxTreeNode_accelSensX = new AppendedTreeNodeTextBox("X:");
            appendedTextBoxTreeNode_accelSensY = new AppendedTreeNodeTextBox("Y:");
            appendedTextBoxTreeNode_accelSensZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_accelSens = new System.Windows.Forms.TreeNode("Sensitivity (lsb/g)", new AppendedTreeNodeTextBox[] {
            appendedTextBoxTreeNode_accelSensX,
            appendedTextBoxTreeNode_accelSensY,
            appendedTextBoxTreeNode_accelSensZ});
            appendedTextBoxTreeNode_accelBiasX = new AppendedTreeNodeTextBox("X:");
            appendedTextBoxTreeNode_accelBiasY = new AppendedTreeNodeTextBox("Y:");
            appendedTextBoxTreeNode_accelBiasZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_accelBias = new System.Windows.Forms.TreeNode("Bias (lsb)", new AppendedTreeNodeTextBox[] {
            appendedTextBoxTreeNode_accelBiasX,
            appendedTextBoxTreeNode_accelBiasY,
            appendedTextBoxTreeNode_accelBiasZ});
            treeNode_accelerometer = new System.Windows.Forms.TreeNode("Accelerometer", new System.Windows.Forms.TreeNode[] {
            appendedComboBoxTreeNode_accelFullScale,
            treeNode_accelSens,
            treeNode_accelBias});

            #endregion

            #region Magnetometer

            appendedComboBoxTreeNode_magFullScale = new AppendedTreeNodeComboBox("Full Scale:");
            appendedComboBoxTreeNode_magFullScale.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedComboBoxTreeNode_magFullScale.ComboBox.Width = 60;
            appendedComboBoxTreeNode_magFullScale.ComboBox.Items.Add("±1.3 G");
            appendedComboBoxTreeNode_magFullScale.ComboBox.Items.Add("±1.9 G");
            appendedComboBoxTreeNode_magFullScale.ComboBox.Items.Add("±2.5 G");
            appendedComboBoxTreeNode_magFullScale.ComboBox.Items.Add("±4.0 G");
            appendedComboBoxTreeNode_magFullScale.ComboBox.Items.Add("±4.7 G");
            appendedComboBoxTreeNode_magFullScale.ComboBox.Items.Add("±5.6 G");
            appendedComboBoxTreeNode_magFullScale.ComboBox.Items.Add("±8.1 G");
            appendedTextBoxTreeNode_magSensX = new AppendedTreeNodeTextBox("X:");
            appendedTextBoxTreeNode_magSensY = new AppendedTreeNodeTextBox("Y:");
            appendedTextBoxTreeNode_magSensZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_magSens = new System.Windows.Forms.TreeNode("Sensitivity (lsb/G)", new AppendedTreeNodeTextBox[] {
            appendedTextBoxTreeNode_magSensX,
            appendedTextBoxTreeNode_magSensY,
            appendedTextBoxTreeNode_magSensZ});
            appendedTextBoxTreeNode_magBiasX = new AppendedTreeNodeTextBox("X:");
            appendedTextBoxTreeNode_magBiasY = new AppendedTreeNodeTextBox("Y:");
            appendedTextBoxTreeNode_magBiasZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_magBias = new System.Windows.Forms.TreeNode("Bias (lsb)", new AppendedTreeNodeTextBox[] {
            appendedTextBoxTreeNode_magBiasX,
            appendedTextBoxTreeNode_magBiasY,
            appendedTextBoxTreeNode_magBiasZ});
            appendedTextBoxTreeNode_magHIbiasX = new AppendedTreeNodeTextBox("X:");
            appendedTextBoxTreeNode_magHIbiasY = new AppendedTreeNodeTextBox("Y:");
            appendedTextBoxTreeNode_magHIbiasZ = new AppendedTreeNodeTextBox("Z:");
            treeNode_magHIbias = new System.Windows.Forms.TreeNode("Hard-Iron Bias (G)", new AppendedTreeNodeTextBox[] {
            appendedTextBoxTreeNode_magHIbiasX,
            appendedTextBoxTreeNode_magHIbiasY,
            appendedTextBoxTreeNode_magHIbiasZ});
            treeNode_magnetometer = new System.Windows.Forms.TreeNode("Magnetometer", new System.Windows.Forms.TreeNode[] {
            appendedComboBoxTreeNode_magFullScale,
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

            appendedComboBoxTreeNode_algorithmMode = new AppendedTreeNodeComboBox("Algorithm Mode:");
            appendedComboBoxTreeNode_algorithmMode.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedComboBoxTreeNode_algorithmMode.ComboBox.Width = 60;
            appendedComboBoxTreeNode_algorithmMode.ComboBox.Items.Add("Disabled");
            appendedComboBoxTreeNode_algorithmMode.ComboBox.Items.Add("IMU");
            appendedComboBoxTreeNode_algorithmMode.ComboBox.Items.Add("AHRS");
            appendedTextBoxTreeNode_algoGainKp = new AppendedTreeNodeTextBox("Proportional Gain:");
            appendedTextBoxTreeNode_algoGainKi = new AppendedTreeNodeTextBox("Integral Gain:");
            System.Windows.Forms.TreeNode treeNode_algorithmGains = new System.Windows.Forms.TreeNode("Algorithm Gains", new System.Windows.Forms.TreeNode[] {
            appendedTextBoxTreeNode_algoGainKp,
            appendedTextBoxTreeNode_algoGainKi});
            appendedTextBoxTreeNode_algoInitKp = new AppendedTreeNodeTextBox("Initial Proportional Gain:");
            appendedTextBoxTreeNode_algoInitPeriod = new AppendedTreeNodeTextBox("Initialisation Period (s):");
            System.Windows.Forms.TreeNode treeNode_algoInitialisation = new System.Windows.Forms.TreeNode("Initialisation", new System.Windows.Forms.TreeNode[] {
            appendedTextBoxTreeNode_algoInitKp,
            appendedTextBoxTreeNode_algoInitPeriod});
            appendedTextBoxTreeNode_algoMinValidMag = new AppendedTreeNodeTextBox("Minimum Valid Field Magnitude (G):");
            appendedTextBoxTreeNode_algoMaxValidMag = new AppendedTreeNodeTextBox("Maximum Valid Field Magnitude (G):");
            System.Windows.Forms.TreeNode treeNode_magneticFieldRejection = new System.Windows.Forms.TreeNode("Magnetic Field Rejection", new System.Windows.Forms.TreeNode[] {
            appendedTextBoxTreeNode_algoMinValidMag,
            appendedTextBoxTreeNode_algoMaxValidMag});
            appendedTextBoxTreeNode_tareQuatElement0 = new AppendedTreeNodeTextBox("Element 0:");
            appendedTextBoxTreeNode_tareQuatElement1 = new AppendedTreeNodeTextBox("Element 1:");
            appendedTextBoxTreeNode_tareQuatElement2 = new AppendedTreeNodeTextBox("Element 2:");
            appendedTextBoxTreeNode_tareQuatElement3 = new AppendedTreeNodeTextBox("Element 3:");
            appendedTextBoxTreeNode_TareQuaternion = new System.Windows.Forms.TreeNode("Tare Quaternion", new AppendedTreeNodeTextBox[] {
            appendedTextBoxTreeNode_tareQuatElement0,
            appendedTextBoxTreeNode_tareQuatElement1,
            appendedTextBoxTreeNode_tareQuatElement2,
            appendedTextBoxTreeNode_tareQuatElement3});
            treeNode_algorithmParameters = new System.Windows.Forms.TreeNode("Algorithm Parameters", new System.Windows.Forms.TreeNode[] {
            appendedComboBoxTreeNode_algorithmMode,
            treeNode_algorithmGains,
            treeNode_algoInitialisation,
            treeNode_magneticFieldRejection,
            appendedTextBoxTreeNode_TareQuaternion});

            #endregion

            #region Data Output Settings

            appendedComboBoxTreeNode_sensorDataMode = new AppendedTreeNodeComboBox("Sensor Data Mode:");
            appendedComboBoxTreeNode_sensorDataMode.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedComboBoxTreeNode_sensorDataMode.ComboBox.Items.Add("Raw ADC results");
            appendedComboBoxTreeNode_sensorDataMode.ComboBox.Items.Add("Calibrated units");
            appendedComboBoxTreeNode_dateTimeOutputRate = new AppendedTreeNodeComboBox("Date/Time Data Rate:");
            appendedComboBoxTreeNode_dateTimeOutputRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedComboBoxTreeNode_dateTimeOutputRate.ComboBox.Width = 200;
            appendedComboBoxTreeNode_dateTimeOutputRate.ComboBox.Items.Add("Disabled (sent on reset/wake only)");
            appendedComboBoxTreeNode_dateTimeOutputRate.ComboBox.Items.Add("1 Hz");
            appendedComboBoxTreeNode_battThermOutputRate = new AppendedTreeNodeComboBox("Battery and Thermometer Data Rate:");
            appendedComboBoxTreeNode_battThermOutputRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedComboBoxTreeNode_battThermOutputRate.ComboBox.Width = 80;
            appendedComboBoxTreeNode_battThermOutputRate.ComboBox.Items.Add("Disabled");
            appendedComboBoxTreeNode_battThermOutputRate.ComboBox.Items.Add("1 Hz");
            appendedComboBoxTreeNode_battThermOutputRate.ComboBox.Items.Add("2 Hz");
            appendedComboBoxTreeNode_battThermOutputRate.ComboBox.Items.Add("4 Hz");
            appendedComboBoxTreeNode_battThermOutputRate.ComboBox.Items.Add("8 Hz");
            appendedComboBoxTreeNode_battThermOutputRate.ComboBox.Items.Add("16 Hz");
            appendedComboBoxTreeNode_battThermOutputRate.ComboBox.Items.Add("32 Hz");
            appendedComboBoxTreeNode_battThermOutputRate.ComboBox.Items.Add("64 Hz");
            appendedComboBoxTreeNode_battThermOutputRate.ComboBox.Items.Add("128 Hz");
            appendedComboBoxTreeNode_battThermOutputRate.ComboBox.Items.Add("256 Hz");
            appendedComboBoxTreeNode_inertialMagOutputRate = new AppendedTreeNodeComboBox("Inertial and Magnetic Data Rate:");
            appendedComboBoxTreeNode_inertialMagOutputRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedComboBoxTreeNode_inertialMagOutputRate.ComboBox.Width = 80;
            appendedComboBoxTreeNode_inertialMagOutputRate.ComboBox.Items.Add("Disabled");
            appendedComboBoxTreeNode_inertialMagOutputRate.ComboBox.Items.Add("1 Hz");
            appendedComboBoxTreeNode_inertialMagOutputRate.ComboBox.Items.Add("2 Hz");
            appendedComboBoxTreeNode_inertialMagOutputRate.ComboBox.Items.Add("4 Hz");
            appendedComboBoxTreeNode_inertialMagOutputRate.ComboBox.Items.Add("8 Hz");
            appendedComboBoxTreeNode_inertialMagOutputRate.ComboBox.Items.Add("16 Hz");
            appendedComboBoxTreeNode_inertialMagOutputRate.ComboBox.Items.Add("32 Hz");
            appendedComboBoxTreeNode_inertialMagOutputRate.ComboBox.Items.Add("64 Hz");
            appendedComboBoxTreeNode_inertialMagOutputRate.ComboBox.Items.Add("128 Hz");
            appendedComboBoxTreeNode_inertialMagOutputRate.ComboBox.Items.Add("256 Hz");
            appendedComboBoxTreeNode_quatOutputRate = new AppendedTreeNodeComboBox("Quaternion Data Rate:");
            appendedComboBoxTreeNode_quatOutputRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedComboBoxTreeNode_quatOutputRate.ComboBox.Width = 80;
            appendedComboBoxTreeNode_quatOutputRate.ComboBox.Items.Add("Disabled");
            appendedComboBoxTreeNode_quatOutputRate.ComboBox.Items.Add("1 Hz");
            appendedComboBoxTreeNode_quatOutputRate.ComboBox.Items.Add("2 Hz");
            appendedComboBoxTreeNode_quatOutputRate.ComboBox.Items.Add("4 Hz");
            appendedComboBoxTreeNode_quatOutputRate.ComboBox.Items.Add("8 Hz");
            appendedComboBoxTreeNode_quatOutputRate.ComboBox.Items.Add("16 Hz");
            appendedComboBoxTreeNode_quatOutputRate.ComboBox.Items.Add("32 Hz");
            appendedComboBoxTreeNode_quatOutputRate.ComboBox.Items.Add("64 Hz");
            appendedComboBoxTreeNode_quatOutputRate.ComboBox.Items.Add("128 Hz");
            appendedComboBoxTreeNode_quatOutputRate.ComboBox.Items.Add("256 Hz");
            treeNode_dataOutputRate = new System.Windows.Forms.TreeNode("Data Output Settings", new System.Windows.Forms.TreeNode[] {
            appendedComboBoxTreeNode_sensorDataMode,
            appendedComboBoxTreeNode_dateTimeOutputRate,
            appendedComboBoxTreeNode_battThermOutputRate,
            appendedComboBoxTreeNode_inertialMagOutputRate,
            appendedComboBoxTreeNode_quatOutputRate});

            #endregion

            #region SD Card

            appendedTextBoxTreeNode_SDcardNewFileName = new AppendedTreeNodeTextBox("New File Name (integer):");
            treeNode_SDcard = new System.Windows.Forms.TreeNode("SD Card", new AppendedTreeNodeTextBox[] {
            appendedTextBoxTreeNode_SDcardNewFileName});

            #endregion

            #region Power Management

            appendedComboBoxTreeNode_battShutdownVoltage = new AppendedTreeNodeTextBox("Battery Shutdown Voltage (V):");
            appendedTextBoxTreeNode_sleepTimer = new AppendedTreeNodeTextBox("Sleep Timer (s):");
            appendedComboBoxTreeNode_motionTriggeredWakeup = new AppendedTreeNodeComboBox("Motion Triggered Wake Up:");
            appendedComboBoxTreeNode_motionTriggeredWakeup.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedComboBoxTreeNode_motionTriggeredWakeup.ComboBox.Width = 95;
            appendedComboBoxTreeNode_motionTriggeredWakeup.ComboBox.Items.Add("Disabled");
            appendedComboBoxTreeNode_motionTriggeredWakeup.ComboBox.Items.Add("Low sensitivity");
            appendedComboBoxTreeNode_motionTriggeredWakeup.ComboBox.Items.Add("High sensitivity");
            appendedComboBoxTreeNode_bluetoothPower = new AppendedTreeNodeComboBox("Bluetooth Power:");
            appendedComboBoxTreeNode_bluetoothPower.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedComboBoxTreeNode_bluetoothPower.ComboBox.Width = 80;
            appendedComboBoxTreeNode_bluetoothPower.ComboBox.Items.Add("Disabled");
            appendedComboBoxTreeNode_bluetoothPower.ComboBox.Items.Add("Enabled");
            treeNode_powerManagement = new System.Windows.Forms.TreeNode("Power Management", new AppendedTreeNode[] {
            appendedComboBoxTreeNode_battShutdownVoltage,
            appendedTextBoxTreeNode_sleepTimer,
            appendedComboBoxTreeNode_motionTriggeredWakeup,
            appendedComboBoxTreeNode_bluetoothPower});

            #endregion

            #region Auxiliary port

            appendedComboBoxTreeNode_auxiliaryPortMode = new AppendedTreeNodeComboBox("Auxiliary Port Mode:");
            appendedComboBoxTreeNode_auxiliaryPortMode.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedComboBoxTreeNode_auxiliaryPortMode.ComboBox.Width = 100;
            appendedComboBoxTreeNode_auxiliaryPortMode.ComboBox.Items.Add("Disabled");
            appendedComboBoxTreeNode_auxiliaryPortMode.ComboBox.Items.Add("Digital I/O");

            #region Digital I/O

            appendedComboBoxTreeNode_digitalIOdirection = new AppendedTreeNodeComboBox("I/O Direction:");
            appendedComboBoxTreeNode_digitalIOdirection.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedComboBoxTreeNode_digitalIOdirection.ComboBox.Width = 210;
            appendedComboBoxTreeNode_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2,3,4,5,6,7");
            appendedComboBoxTreeNode_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2,3,4,5,6, Ouput = AX7");
            appendedComboBoxTreeNode_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2,3,4,5, Ouput = AX6,7");
            appendedComboBoxTreeNode_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2,3,4, Ouput = AX5,6,7");
            appendedComboBoxTreeNode_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2,3, Ouput = AX4,5,6,7");
            appendedComboBoxTreeNode_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1,2, Ouput = AX3,4,5,6,7");
            appendedComboBoxTreeNode_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0,1, Ouput = AX2,3,4,5,6,7");
            appendedComboBoxTreeNode_digitalIOdirection.ComboBox.Items.Add("Inputs = AX0, Ouput = AX1,2,3,4,5,6,7");
            appendedComboBoxTreeNode_digitalIOdirection.ComboBox.Items.Add("Outputs = AX0,1,2,3,4,5,6,7");
            appendedComboBoxTreeNode_digitalIOoutputRate = new AppendedTreeNodeComboBox("Data Rate:");
            appendedComboBoxTreeNode_digitalIOoutputRate.ComboBox.Items.Add("On change only");
            appendedComboBoxTreeNode_digitalIOoutputRate.ComboBox.Items.Add("1 Hz");
            appendedComboBoxTreeNode_digitalIOoutputRate.ComboBox.Items.Add("2 Hz");
            appendedComboBoxTreeNode_digitalIOoutputRate.ComboBox.Items.Add("4 Hz");
            appendedComboBoxTreeNode_digitalIOoutputRate.ComboBox.Items.Add("8 Hz");
            appendedComboBoxTreeNode_digitalIOoutputRate.ComboBox.Items.Add("16 Hz");
            appendedComboBoxTreeNode_digitalIOoutputRate.ComboBox.Items.Add("32 Hz");
            appendedComboBoxTreeNode_digitalIOoutputRate.ComboBox.Items.Add("64 Hz");
            appendedComboBoxTreeNode_digitalIOoutputRate.ComboBox.Items.Add("128 Hz");
            appendedComboBoxTreeNode_digitalIOoutputRate.ComboBox.Items.Add("256 Hz");
            appendedComboBoxTreeNode_digitalIOoutputRate.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            appendedComboBoxTreeNode_digitalIOoutputRate.ComboBox.Width = 100;
            treeNode_digitalIO = new System.Windows.Forms.TreeNode("Digital I/O", new AppendedTreeNode[] {
            appendedComboBoxTreeNode_digitalIOdirection,
            appendedComboBoxTreeNode_digitalIOoutputRate});

            #endregion

            treeNode_auxiliaryPort = new System.Windows.Forms.TreeNode("Auxiliary Port", new System.Windows.Forms.TreeNode[] {
            appendedComboBoxTreeNode_auxiliaryPortMode,
            treeNode_digitalIO});

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

        #region General

        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_FirmVersionMajorNum;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_FirmVersionMinorNum;
        private System.Windows.Forms.TreeNode appendedTextBoxTreeNode_FirmwareVersion;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_DeviceID;
        private AppendedTreeNodeComboBox appendedComboBoxTreeNode_buttonMode;
        private System.Windows.Forms.TreeNode treeNodeGeneral;

        #endregion

        #region Sensor Calibration Parameters

        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_battSens;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_battBias;
        private System.Windows.Forms.TreeNode treeNode_battVoltmeter;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_thermSens;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_thermBias;
        private System.Windows.Forms.TreeNode treeNode_thermometer;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_gyroSensX;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_gyroSensY;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_gyroSensZ;
        private System.Windows.Forms.TreeNode treeNode_gyroSens;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_gyroBiasX;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_gyroBiasY;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_gyroBiasZ;
        private System.Windows.Forms.TreeNode treeNode_gyroBias;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_gyroBiasTempSensX;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_gyroBiasTempSensY;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_gyroBiasTempSensZ;
        private System.Windows.Forms.TreeNode treeNode_gyroBiasTempSens;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_gyroSample1Temp;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_gyroSample1BiasX;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_gyroSample1BiasY;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_gyroSample1BiasZ;
        private System.Windows.Forms.TreeNode treeNode_gyroSample1;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_gyroSample2Temp;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_gyroSample2BiasX;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_gyroSample2BiasY;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_gyroSample2BiasZ;
        private System.Windows.Forms.TreeNode treeNode_gyroSample2;
        private System.Windows.Forms.TreeNode treeNode_gyroBiasParent;
        private System.Windows.Forms.TreeNode treeNode_gyroscope;
        private AppendedTreeNodeComboBox appendedComboBoxTreeNode_accelFullScale;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_accelSensX;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_accelSensY;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_accelSensZ;
        private System.Windows.Forms.TreeNode treeNode_accelSens;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_accelBiasX;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_accelBiasY;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_accelBiasZ;
        private System.Windows.Forms.TreeNode treeNode_accelBias;
        private System.Windows.Forms.TreeNode treeNode_accelerometer;
        private AppendedTreeNodeComboBox appendedComboBoxTreeNode_magFullScale;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_magSensX;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_magSensY;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_magSensZ;
        private System.Windows.Forms.TreeNode treeNode_magSens;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_magBiasX;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_magBiasY;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_magBiasZ;
        private System.Windows.Forms.TreeNode treeNode_magBias;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_magHIbiasX;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_magHIbiasY;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_magHIbiasZ;
        private System.Windows.Forms.TreeNode treeNode_magHIbias;
        private System.Windows.Forms.TreeNode treeNode_magnetometer;

        #endregion

        #region Algorithm Parameters

        private AppendedTreeNodeComboBox appendedComboBoxTreeNode_algorithmMode;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_algoGainKp;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_algoGainKi;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_algoMinValidMag;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_algoMaxValidMag;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_algoInitKp;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_algoInitPeriod;
        private System.Windows.Forms.TreeNode appendedTextBoxTreeNode_TareQuaternion;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_tareQuatElement0;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_tareQuatElement1;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_tareQuatElement2;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_tareQuatElement3;
        private System.Windows.Forms.TreeNode treeNode_algorithmParameters;

        #endregion

        #region Data Output Settings

        private AppendedTreeNodeComboBox appendedComboBoxTreeNode_sensorDataMode;
        private AppendedTreeNodeComboBox appendedComboBoxTreeNode_dateTimeOutputRate;
        private AppendedTreeNodeComboBox appendedComboBoxTreeNode_battThermOutputRate;
        private AppendedTreeNodeComboBox appendedComboBoxTreeNode_inertialMagOutputRate;
        private AppendedTreeNodeComboBox appendedComboBoxTreeNode_quatOutputRate;
        private System.Windows.Forms.TreeNode treeNode_dataOutputRate;

        #endregion

        #region SD Card

        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_SDcardNewFileName;
        private System.Windows.Forms.TreeNode treeNode_SDcard;

        #endregion

        #region Power Management

        private AppendedTreeNodeTextBox appendedComboBoxTreeNode_battShutdownVoltage;
        private AppendedTreeNodeTextBox appendedTextBoxTreeNode_sleepTimer;
        private AppendedTreeNodeComboBox appendedComboBoxTreeNode_motionTriggeredWakeup;
        private AppendedTreeNodeComboBox appendedComboBoxTreeNode_bluetoothPower;
        private System.Windows.Forms.TreeNode treeNode_powerManagement;

        #endregion

        #region Auxiliary Port

        private AppendedTreeNodeComboBox appendedComboBoxTreeNode_auxiliaryPortMode;

        #region Digital I/O

        private AppendedTreeNodeComboBox appendedComboBoxTreeNode_digitalIOdirection;
        private AppendedTreeNodeComboBox appendedComboBoxTreeNode_digitalIOoutputRate;
        private System.Windows.Forms.TreeNode treeNode_digitalIO;

        #endregion


        private System.Windows.Forms.TreeNode treeNode_auxiliaryPort;

        #endregion


        #endregion

    }
}