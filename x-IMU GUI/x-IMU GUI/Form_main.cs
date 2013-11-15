using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Diagnostics;

namespace x_IMU_GUI
{
    public partial class Form_main : Form
    {
        #region Variables

        /// <summary>
        /// For update timer used to periodically update form control values
        /// </summary>
        private System.Windows.Forms.Timer formUpdateTimer;

        /// <summary>
        /// RegisterData object array to written to by xIMUserial thread and read by Form_main thread.
        /// </summary>
        private x_IMU_API.RegisterData[] registerDataBuffer;

        /// <summary>
        /// DateTimeData object to written to by xIMUserial thread and read by Form_main thread.
        /// </summary>
        private x_IMU_API.DateTimeData dateTimeDataBuffer;

        /// <summary>
        /// xIMUserial object communicates with the x-IMU via USB or Bluetooth.
        /// </summary>
        private x_IMU_API.xIMUserial xIMUserial;

        /// <summary>
        /// ProgressDialog displays auto-connect progress and enables user cancellation.
        /// </summary>
        private ProgressDialog autoConnectProgressDialog;

        /// <summary>
        /// SimpleOscilloscope objects display real-time individual sensor data.
        /// </summary>
        private SimpleOscilloscope batteryOscilloscope, thermometerOscilloscope, gyroscopeOscilloscope, accelerometerOscilloscope, magnetometerOscilloscope, eulerAnglesOscilloscope,
                                   analogueInputAX0AX1oscilloscope, analogueInputAX2AX3oscilloscope, analogueInputAX4AX5oscilloscope, analogueInputAX6AX7oscilloscope,
                                   ADXL345_Aoscilloscope, ADXL345_Boscilloscope, ADXL345_Coscilloscope, ADXL345_Doscilloscope;

        /// <summary>
        /// Form_3Dcuboid form displays real-time orientation data a 3D cuboid.
        /// </summary>
        private Form_3Dcuboid form_3Dcuboid;

        /// <summary>
        /// Form_digitalIOpanel form displays digital I/O inputs and controls outputs.
        /// </summary>
        private Form_digitalIOpanel form_digitalIOpanel;

        /// <summary>
        /// Form_PWMoutputPanel form controls PWM outputs and displays confirmed values.
        /// </summary>
        private Form_PWMoutputPanel form_PWMoutputPanel;

        /// <summary>
        /// CSVfileWriter object used by data logger.
        /// </summary>
        private x_IMU_API.CSVfileWriter dataLoggerCSVfileWriter;

        /// <summary>
        /// CSVfileWriter object used by binary file converter.
        /// </summary>
        private x_IMU_API.CSVfileWriter binaryFileConverterCSVfileWriter;

        /// <summary>
        /// ProgressDialog displays progress and enables user cancellation of binary file converter asynchronous process.
        /// </summary>
        private ProgressDialog binaryFileConverterProgressDialog;

        /// <summary>
        /// CSVfileWriter object used by hard-iron calibration dataset collection.
        /// </summary>
        private x_IMU_API.CSVfileWriter hardIronCalCSVfileWriter;

        #endregion

        /// <summary>
        /// Form constructor.
        /// </summary>
        public Form_main()
        {
            InitializeComponent();
            InitializeRegisterTreeViewComponents();
        }

        #region Form load/close

        /// <summary>
        /// Form Load event initialises form objects, sets form control values and starts auto-connect process.
        /// </summary>
        private void Form_main_Load(object sender, EventArgs e)
        {
            this.Text = Assembly.GetExecutingAssembly().GetName().Name + " " + Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();

            // Create peripheral GUIs and assign to ShowHideButton
            batteryOscilloscope = new SimpleOscilloscope("Battery Data (V)", "Oscilloscope/batteryOscilloscope_settings.ini");
            showHideButton_batteryGraph.Object = batteryOscilloscope;
            thermometerOscilloscope = new SimpleOscilloscope("Thermometer Data (°C)", "Oscilloscope/thermometerOscilloscope_settings.ini");
            showHideButton_thermometerGraph.Object = thermometerOscilloscope;
            gyroscopeOscilloscope = new SimpleOscilloscope("Gyroscope Data (°/s)", "Oscilloscope/gyroscopeOscilloscope_settings.ini");
            showHideButton_gyroscopeGraph.Object = gyroscopeOscilloscope;
            accelerometerOscilloscope = new SimpleOscilloscope("Accelerometer Data (g)", "Oscilloscope/accelerometerOscilloscope_settings.ini");
            showHideButton_accelerometerGraph.Object = accelerometerOscilloscope;
            magnetometerOscilloscope = new SimpleOscilloscope("Magnetometer Data (Gauss)", "Oscilloscope/magnetometerOscilloscope_settings.ini");
            showHideButton_magnetometerGraph.Object = magnetometerOscilloscope;
            eulerAnglesOscilloscope = new SimpleOscilloscope("Euler Angles Data (°)", "Oscilloscope/eulerAnglesOscilloscope_settings.ini");
            showHideButton_eulerAnglesGraph.Object = eulerAnglesOscilloscope;
            form_3Dcuboid = new Form_3Dcuboid();
            form_3Dcuboid.MinimizeInsteadOfClose = true;
            showHideButton_3Dcuboid.Object = form_3Dcuboid;
            form_digitalIOpanel = new Form_digitalIOpanel();
            form_digitalIOpanel.OutputChanged += new Form_digitalIOpanel.onOutputChanged(digitalIOpanel_OutputChanged);
            showHideButton_digitalIOpanel.Object = form_digitalIOpanel;
            analogueInputAX0AX1oscilloscope = new SimpleOscilloscope("Analogue Input AX0 AX1 Data (lsb)", "Oscilloscope/analogueInputAX0AX1oscilloscope_settings.ini");
            showHideButton_AX0andAX1graph.Object = analogueInputAX0AX1oscilloscope;
            analogueInputAX2AX3oscilloscope = new SimpleOscilloscope("Analogue Input AX2 AX3 Data (lsb)", "Oscilloscope/analogueInputAX2AX3oscilloscope_settings.ini");
            showHideButton_AX2andAX3graph.Object = analogueInputAX2AX3oscilloscope;
            analogueInputAX4AX5oscilloscope = new SimpleOscilloscope("Analogue Input AX4 AX5 Data (lsb)", "Oscilloscope/analogueInputAX4AX5oscilloscope_settings.ini");
            showHideButton_AX4andAX5graph.Object = analogueInputAX4AX5oscilloscope;
            analogueInputAX6AX7oscilloscope = new SimpleOscilloscope("Analogue Input AX6 AX7 Data (lsb)", "Oscilloscope/analogueInputAX6AX7oscilloscope_settings.ini");
            showHideButton_AX6andAX7graph.Object = analogueInputAX6AX7oscilloscope;
            form_PWMoutputPanel = new Form_PWMoutputPanel();
            form_PWMoutputPanel.ValuesChanged += new Form_PWMoutputPanel.onValuesChanged(PWMoutputPanel_ValuesChanged);
            showHideButton_PWMoutputPanel.Object = form_PWMoutputPanel;
            ADXL345_Aoscilloscope = new SimpleOscilloscope("ADXL234 A Data", "Oscilloscope/ADXL345Aoscilloscope_settings.ini");
            showHideButton_ADXL345Agraph.Object = ADXL345_Aoscilloscope;
            ADXL345_Boscilloscope = new SimpleOscilloscope("ADXL234 B Data", "Oscilloscope/ADXL345Boscilloscope_settings.ini");
            showHideButton_ADXL345Bgraph.Object = ADXL345_Boscilloscope;
            ADXL345_Coscilloscope = new SimpleOscilloscope("ADXL234 C Data", "Oscilloscope/ADXL345Coscilloscope_settings.ini");
            showHideButton_ADXL345Cgraph.Object = ADXL345_Coscilloscope;
            ADXL345_Doscilloscope = new SimpleOscilloscope("ADXL234 D Data", "Oscilloscope/ADXL345Doscilloscope_settings.ini");
            showHideButton_ADXL345Dgraph.Object = ADXL345_Doscilloscope;

            // Create x-IMU serial object
            xIMUserial = new x_IMU_API.xIMUserial();
            xIMUserial.xIMUdataReceived += new x_IMU_API.xIMUserial.onxIMUdataReceived(xIMUserial_xIMUdataReceived);
            xIMUserial.ErrorDataReceived += new x_IMU_API.xIMUserial.onErrorDataReceived(xIMUserial_ErrorDataReceived);
            xIMUserial.CommandDataReceived += new x_IMU_API.xIMUserial.onCommandDataReceived(xIMUserial_CommandDataReceived);
            xIMUserial.RegisterDataReceived += new x_IMU_API.xIMUserial.onRegisterDataReceived(xIMUserial_RegisterDataReceived);
            xIMUserial.DateTimeDataReceived += new x_IMU_API.xIMUserial.onDateTimeDataReceived(xIMUserial_DateTimeDataReceived);
            xIMUserial.RawBatteryAndThermometerDataReceived += new x_IMU_API.xIMUserial.onRawBatteryAndThermometerDataReceived(xIMUserial_RawBatteryAndThermometerDataReceived);
            xIMUserial.CalBatteryAndThermometerDataReceived += new x_IMU_API.xIMUserial.onCalBatteryAndThermometerDataReceived(xIMUserial_CalBatteryAndThermometerDataReceived);
            xIMUserial.RawInertialAndMagneticDataReceived += new x_IMU_API.xIMUserial.onRawInertialAndMagneticDataReceived(xIMUserial_RawInertialAndMagneticDataReceived);
            xIMUserial.CalInertialAndMagneticDataReceived += new x_IMU_API.xIMUserial.onCalInertialAndMagneticDataReceived(xIMUserial_CalInertialAndMagneticDataReceived);
            xIMUserial.CalInertialAndMagneticDataReceived += new x_IMU_API.xIMUserial.onCalInertialAndMagneticDataReceived(xIMUserial_CalInertialAndMagneticDataReceivedHardIronCal);
            xIMUserial.QuaternionDataReceived += new x_IMU_API.xIMUserial.onQuaternionDataReceived(xIMUserial_QuaternionDataReceived);
            xIMUserial.DigitalIODataReceived += new x_IMU_API.xIMUserial.onDigitalIODataReceived(xIMUserial_DigitalIODataReceived);
            xIMUserial.RawAnalogueInputDataReceived += new x_IMU_API.xIMUserial.onRawAnalogueInputDataReceived(xIMUserial_RawAnalogueInputDataReceived);
            xIMUserial.CalAnalogueInputDataReceived += new x_IMU_API.xIMUserial.onCalAnalogueInputDataReceived(xIMUserial_CalAnalogueInputDataReceived);
            xIMUserial.PWMoutputDataReceived += new x_IMU_API.xIMUserial.onPWMoutputDataReceived(xIMUserial_PWMoutputDataReceived);
            xIMUserial.RawADXL345busDataReceived += new x_IMU_API.xIMUserial.onRawADXL345busDataReceived(xIMUserial_RawADXL345busDataReceived);
            xIMUserial.CalADXL345busDataReceived += new x_IMU_API.xIMUserial.onCalADXL345busDataReceived(xIMUserial_CalADXL345busDataReceived);

            // Create buffers to parse data between xIMUserial and Form_main threads
            dateTimeDataBuffer = null;
            registerDataBuffer = new x_IMU_API.RegisterData[(int)x_IMU_API.RegisterAddresses.NumRegisters];

            // Create ToolTip for RegisterTreeView
            ToolTip toolTip = new ToolTip();
            toolTip.ToolTipTitle = "Tip:";
            toolTip.SetToolTip(registerTreeView, "Right-click for action menu");

            // Set fixed form control values
            label_GUIversionNum.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            label_APIversionNum.Text = FileVersionInfo.GetVersionInfo("x-IMU API.dll").FileVersion.ToString();
            label_compatibleFirmwareVersionNums.Text = "";
            for (int i = 0; i < Enum.GetValues(typeof(x_IMU_API.CompatibleFirmwareVersions)).Length; i++)
            {
                label_compatibleFirmwareVersionNums.Text += ((int[])Enum.GetValues(typeof(x_IMU_API.CompatibleFirmwareVersions)))[i].ToString() + ".x";
                if (i < ((int[])Enum.GetValues(typeof(x_IMU_API.CompatibleFirmwareVersions))).Length - 1)
                {
                    label_compatibleFirmwareVersionNums.Text += ", ";
                }
            }

            // Set default variable form control values
            button_refreshList.PerformClick();
            textBox_dataLoggerFilePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\" + "LoggedData";
            textBox_collectHardIronCalDatasetFilePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\" + "HardIronCal";

            // Create and start form update timer
            formUpdateTimer = new System.Windows.Forms.Timer();
            formUpdateTimer.Interval = 50;
            formUpdateTimer.Tick += new EventHandler(formUpdateTimer_Tick);
            formUpdateTimer.Start();

            // Auto connect on start up
            toggleButton_openClosePort.PerformClick();
        }

        /// <summary>
        /// FormClosed event closes serial port and files.
        /// </summary>
        private void Form_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosePort();
            dataLoggerCSVfileWriter.CloseFiles();
            binaryFileConverterCSVfileWriter.CloseFiles();
            hardIronCalCSVfileWriter.CloseFiles();
        }

        #endregion

        #region Form update timer

        /// <summary>
        /// Timer Tick event updates data displayed on form.
        /// </summary>
        private void formUpdateTimer_Tick(object sender, EventArgs e)
        {
            // Update packet counter text boxes
            textBox_packetsReceived.Text = xIMUserial.PacketsReadCounter.TotalPackets.ToString();
            textBox_packetsSent.Text = xIMUserial.PacketsWrittenCounter.TotalPackets.ToString();

            // Update textBox_receivedDataTime from dateTimeDataBuffer
            if (dateTimeDataBuffer != null)
            {
                textBox_receivedDataTime.Text = String.Format("{0:F}", dateTimeDataBuffer.ConvertToDateTime());
            }

            // Update registerTreeView from registerDataBuffer
            for (int i = 0; i < (int)x_IMU_API.RegisterAddresses.NumRegisters; i++)
            {
                if (registerDataBuffer[i] != null)
                {
                    try
                    {
                        registerTreeView.ApplyRegisterData(registerDataBuffer[i], true);
                    }
                    catch
                    {
                        PassiveMessageBox.Show("Register data received for address \"" + registerDataBuffer[i].Address.ToString() + "\" is invalid.", "Error", MessageBoxIcon.Error);
                    }
                    registerDataBuffer[i] = null;
                }
            }
            if (registerTreeView.RefreshPending)
            {
                registerTreeView.Refresh();
            }
        }

        #endregion

        #region Serial port

        /// <summary>
        /// Button Click event refreshes port names in ComboBox and select the first in the list.
        /// </summary>
        private void button_refreshList_Click(object sender, EventArgs e)
        {
            string[] aviablePorts = x_IMU_API.xIMUserial.GetPortNames();
            comboBox_portName.Items.Clear();
            comboBox_portName.Items.Add("Auto");
            foreach (string portName in aviablePorts)
            {
                comboBox_portName.Items.Add(portName);
            }
            comboBox_portName.SelectedIndex = 0;
        }

        /// <summary>
        /// Button Click event toggles open/closed state of x-IMU serial port.
        /// </summary>
        private void toggleButton_openClosePort_Click(object sender, EventArgs e)
        {
            if ((sender as ToggleButton).ToggleState)
            {
                comboBox_portName.Enabled = false;
                button_refreshList.Enabled = false;
                toggleButton_openClosePort.Enabled = false;
                toggleButton_openClosePort.Text = "Opening...";
                this.Update();
                if (string.Equals(comboBox_portName.Text, "Auto", StringComparison.CurrentCultureIgnoreCase))
                {
                    AutoConnect();
                }
                else
                {
                    OpenPort();
                }
            }
            else
            {
                ClosePort();
            }
        }

        /// <summary>
        /// Opens x-IMU serial port.
        /// </summary>
        private void OpenPort()
        {
            try
            {
                xIMUserial.PortName = comboBox_portName.Text;
                xIMUserial.Open();
                toggleButton_openClosePort.Enabled = true;
                toggleButton_openClosePort.ToggleState = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClosePort();
            }
        }

        /// <summary>
        /// Closes x-IMU serial port and enables form controls.
        /// </summary>
        private void ClosePort()
        {
            xIMUserial.Close();
            comboBox_portName.Enabled = true;
            button_refreshList.Enabled = true;
            toggleButton_openClosePort.Enabled = true;
            toggleButton_openClosePort.ToggleState = false;
        }

        /// <summary>
        /// Automatically connects to the first x-IMU found using the PortScanner.
        /// </summary>
        private void AutoConnect()
        {
            // Create ProgressDialog object
            autoConnectProgressDialog = new ProgressDialog(this.Handle);
            autoConnectProgressDialog.Title = "Auto Connecting";
            autoConnectProgressDialog.CancelMessage = "Cancelling...";
            autoConnectProgressDialog.Line1 = "Searching for x-IMU";
            autoConnectProgressDialog.Line3 = "Initialising x-IMU port scanner.";
            autoConnectProgressDialog.ShowDialog();
            autoConnectProgressDialog.Value = 101;     // set value >100 after show, for continuous animation.

            // Create PortScanner object
            x_IMU_API.PortScanner portScanner = new x_IMU_API.PortScanner();
            portScanner.AsyncScanProgressChanged += new x_IMU_API.PortScanner.onAsyncScanProgressChanged(portScanner_AsyncScanProgressChanged);
            portScanner.AsyncScanCompleted += new x_IMU_API.PortScanner.onAsyncScanCompleted(portScanner_AsyncScanCompleted);
            portScanner.DontGiveUp = true;
            portScanner.FirstResultOnly = true;
            portScanner.RunAsynsScan();
        }

        /// <summary>
        /// PortScanner AsyncScanProgressChanged event updates progress dialog and checks for user cancellation.
        /// </summary>
        private void portScanner_AsyncScanProgressChanged(object sender, x_IMU_API.AsyncScanProgressChangedEventArgs e)
        {
            this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate
            {
                if (autoConnectProgressDialog.HasUserCancelled)
                {
                    ((x_IMU_API.PortScanner)sender).CancelAnsycScan();
                }
                else
                {
                    autoConnectProgressDialog.Line3 = e.ProgressMessage;
                }
            })));
        }

        /// <summary>
        /// PortScanner AsyncScanCompleted event opens x-IMU serial port if successful.
        /// </summary>
        private void portScanner_AsyncScanCompleted(object sender, x_IMU_API.AsyncScanCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    throw new Exception();
                }
                this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate
                {
                    comboBox_portName.Text = e.PortAssignments[0].PortName;
                    OpenPort();
                    autoConnectProgressDialog.CloseDialog();
                })));
                PassiveMessageBox.Show("Connected to x-IMU " + e.PortAssignments[0].DeviceID + " on " + e.PortAssignments[0].PortName + ".", "Information", MessageBoxIcon.Information);
            }
            catch
            {
                this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate
                {
                    ClosePort();
                    autoConnectProgressDialog.CloseDialog();
                })));
            }
        }

        #endregion

        #region Error message received

        /// <summary>
        /// xIMUserial ErrorDataReceived received event displays error in PassiveMessageBox.
        /// </summary>
        private void xIMUserial_ErrorDataReceived(object sender, x_IMU_API.ErrorData e)
        {
            PassiveMessageBox.Show("Error: " + e.GetMessage(), "Message From x-IMU", MessageBoxIcon.Error);
        }

        #endregion

        #region Registers

        /// <summary>
        /// RegisterTreeView NodeMouseClick event selects node at the location of the cursor and displays context menu if right-click.
        /// </summary>
        private void registerTreeView_registers_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            registerTreeView.SelectedNode = registerTreeView.GetNodeAt(e.X, e.Y);
            if ((registerTreeView.SelectedNode != null) && (e.Button == MouseButtons.Right))
            {
                ContextMenu regContextMenu = new ContextMenu();
                regContextMenu.MenuItems.Add(new MenuItem("Expand all"));
                regContextMenu.MenuItems.Add(new MenuItem("Collapse all"));
                regContextMenu.MenuItems.Add(new MenuItem("-"));
                regContextMenu.MenuItems.Add(new MenuItem("Load from file"));
                regContextMenu.MenuItems.Add(new MenuItem("Save all to file"));
                regContextMenu.MenuItems[0].Click += new EventHandler(delegate { registerTreeView.ExpandAll(); });
                regContextMenu.MenuItems[1].Click += new EventHandler(delegate { registerTreeView.CollapseAll(); });
                regContextMenu.MenuItems[3].Click += new EventHandler(regContextMenu_ItemClick_loadFromFile);
                regContextMenu.MenuItems[4].Click += new EventHandler(regContextMenu_ItemClick_saveAllToFile);
                if (xIMUserial.IsOpen)
                {
                    regContextMenu.MenuItems.Add(new MenuItem("-"));
                    regContextMenu.MenuItems.Add(new MenuItem("Read all registers"));
                    regContextMenu.MenuItems.Add(new MenuItem("Write all registers"));
                    regContextMenu.MenuItems[6].Click += new EventHandler(delegate { foreach (TreeNode rootNode in registerTreeView.Nodes) { ReadAllChildRegisterTreeNode(rootNode); } });
                    regContextMenu.MenuItems[7].Click += new EventHandler(delegate { foreach (TreeNode rootNode in registerTreeView.Nodes) { WriteAllChildRegisterTreeNode(rootNode); } });
                    regContextMenu.MenuItems.Add(new MenuItem("-"));
                    if (e.Node.LastNode == null)
                    {
                        regContextMenu.MenuItems.Add(new MenuItem("Read this register only"));
                        regContextMenu.MenuItems.Add(new MenuItem("Write this register only"));
                        regContextMenu.MenuItems[9].Click += new EventHandler(delegate { ReadRegisterTreeNode((registerTreeView.SelectedNode as RegisterTreeNode)); });
                        regContextMenu.MenuItems[10].Click += new EventHandler(delegate { WriteRegisterTreeNode((registerTreeView.SelectedNode as RegisterTreeNode)); });
                    }
                    else
                    {
                        regContextMenu.MenuItems.Add(new MenuItem("Read all registers in this group only"));
                        regContextMenu.MenuItems.Add(new MenuItem("Write all registers in this group only"));
                        regContextMenu.MenuItems[9].Click += new EventHandler(delegate { ReadAllChildRegisterTreeNode(registerTreeView.SelectedNode); });
                        regContextMenu.MenuItems[10].Click += new EventHandler(delegate { WriteAllChildRegisterTreeNode(registerTreeView.SelectedNode); });
                    }
                }
                regContextMenu.Show(registerTreeView, new Point(e.X, e.Y));
            }
        }

        #region 'Load from file' and 'Save all to file'

        /// <summary>
        /// ContextMenu ItemClick event loads registers from file.
        /// </summary>
        private void regContextMenu_ItemClick_loadFromFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select File";
            openFileDialog.Filter = "x-IMU Binary Files (*.bin)|*.bin|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                x_IMU_API.xIMUfile xIMUfile = new x_IMU_API.xIMUfile(openFileDialog.FileName.ToString());
                xIMUfile.RegisterDataRead += new x_IMU_API.xIMUfile.onRegisterDataRead(delegate(object s, x_IMU_API.RegisterData r) { registerTreeView.ApplyRegisterData(r, false); });
                xIMUfile.Read();
                if (xIMUfile.ReadErrors != 0)
                {
                    MessageBox.Show(xIMUfile.ReadErrors.ToString() + " read errors occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                xIMUfile.Close();
            }
        }

        /// <summary>
        /// ContextMenu ItemClick event saves all registers to file.
        /// </summary>
        private void regContextMenu_ItemClick_saveAllToFile(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Select File";
            saveFileDialog.Filter = "x-IMU Binary Files (*.bin)|*.bin|All files (*.*)|*.*";
            saveFileDialog.FileName = "savedRegisters" + registerTreeNodeTextBox_deviceID.TextBox.Text + ".bin";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                x_IMU_API.xIMUfile xIMUfile = new x_IMU_API.xIMUfile(saveFileDialog.FileName.ToString(), true);
                foreach (TreeNode rootNode in registerTreeView.Nodes)
                {
                    WriteAllChildRegisterTreeNode(xIMUfile, rootNode);
                }
                xIMUfile.Close();
            }
        }

        /// <summary>
        /// Writes register data to xIMUfile object for each child nodes recursively from a root tree node.
        /// </summary>
        /// <param name="xIMUfile">
        /// xIMUfile object to write to.
        /// </param>
        /// <param name="rootNode">
        /// Root node of all child nodes for which a write register packet will be written.
        /// </param>
        private void WriteAllChildRegisterTreeNode(x_IMU_API.xIMUfile xIMUfile, TreeNode rootNode)
        {
            foreach (TreeNode childNode in rootNode.Nodes)
            {
                if (childNode is RegisterTreeNode)
                {
                    try
                    {
                        xIMUfile.WriteWriteRegisterPacket((childNode as RegisterTreeNode).ConvertToRegisterData());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (childNode.Nodes.Count > 0)
                {
                    WriteAllChildRegisterTreeNode(xIMUfile, childNode);    // for all child nodes recursively
                }
            }
        }

        #endregion

        #region Read registers

        /// <summary>
        /// Sends a read register packet for each child nodes recursively from a root tree node.
        /// </summary>
        /// <param name="rootNode">
        /// Root node of all child nodes for which a read register packet will be sent.
        /// </param>
        private void ReadAllChildRegisterTreeNode(TreeNode rootNode)
        {
            foreach (TreeNode childNode in rootNode.Nodes)
            {
                if (childNode is RegisterTreeNode)
                {
                    ReadRegisterTreeNode((childNode as RegisterTreeNode));
                }
                else if (childNode.Nodes.Count > 0)
                {
                    ReadAllChildRegisterTreeNode(childNode);    // for all child nodes recursively
                }
            }
        }

        /// <summary>
        /// Sends a read register packet for a RegisterTreeNode.
        /// </summary>
        /// <param name="registerTreeNode">
        /// RegisterTreeNode to be read.
        /// </param>
        private void ReadRegisterTreeNode(RegisterTreeNode registerTreeNode)
        {
            try
            {
                Thread.Sleep(5);    // delay to avoid overrunning the device receive buffer
                xIMUserial.SendReadRegisterPacket(new x_IMU_API.RegisterData(registerTreeNode.RegisterAddress));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Register data received event parses data to registerDataBuffer and displays warning if incompatible firmware version detected.
        /// </summary>
        private void xIMUserial_RegisterDataReceived(object sender, x_IMU_API.RegisterData e)
        {
            if (!Enum.IsDefined(typeof(x_IMU_API.RegisterAddresses), (int)e.Address))
            {
                PassiveMessageBox.Show("Register data received with unknown address 0x" + string.Format("{0:X4}", (ushort)e.Address) + ".", "Error", MessageBoxIcon.Error);
            }
            else
            {
                registerDataBuffer[(int)e.Address] = e;
                if ((e.Address == x_IMU_API.RegisterAddresses.FirmwareVersionMajorNum) && (!Enum.IsDefined(typeof(x_IMU_API.CompatibleFirmwareVersions), (int)e.Value)))
                {
                    PassiveMessageBox.Show("The detected x-IMU firmware version is not fully compatible with this version of the x-IMU GUI and API." + Environment.NewLine + Environment.NewLine +
                                           "Please download and install the latest x-IMU software and firmware available from www.x-io.co.uk.", "Warning", MessageBoxIcon.Warning);
                }
            }
        }

        #endregion

        #region Write registers

        /// <summary>
        /// Sends a write register packet for each child nodes recursively from a root tree node.
        /// </summary>
        /// <param name="rootNode">
        /// Root node of all child nodes for which a write register packet will be sent.
        /// </param>
        private void WriteAllChildRegisterTreeNode(TreeNode rootNode)
        {
            foreach (TreeNode childNode in rootNode.Nodes)
            {
                if (childNode is RegisterTreeNode)
                {
                    WriteRegisterTreeNode(childNode as RegisterTreeNode);
                }
                else if (childNode.Nodes.Count > 0)
                {
                    WriteAllChildRegisterTreeNode(childNode);   // apply to all child nodes recursively
                }
            }
        }

        /// <summary>
        /// Sends a write register packet for a RegisterTreeNode.
        /// </summary>
        /// <param name="registerTreeNode">
        /// RegisterTreeNode to be written.
        /// </param>
        private void WriteRegisterTreeNode(RegisterTreeNode registerTreeNode)
        {
            if ((registerTreeNode.RegisterAddress == x_IMU_API.RegisterAddresses.FirmwareVersionMajorNum) ||
                (registerTreeNode.RegisterAddress == x_IMU_API.RegisterAddresses.FirmwareVersionMinorNum) ||
                (registerTreeNode.RegisterAddress == x_IMU_API.RegisterAddresses.DeviceID))
            {
                return;             // do not attmept to write read-only registers
            }
            try
            {
                Thread.Sleep(5);    // delay to avoid overrunning the device receive buffer
                xIMUserial.SendWriteRegisterPacket(registerTreeNode.ConvertToRegisterData());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #endregion

        #region Date/Time

        /// <summary>
        /// Button Click sets x-IMU data/time to system date/time.
        /// </summary>
        private void button_setDateTime_Click(object sender, EventArgs e)
        {
            try
            {
                xIMUserial.SendWriteDateTimePacket(new x_IMU_API.DateTimeData(DateTime.Now));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Click event reads date/time.
        /// </summary>
        private void button_readDateTime_Click(object sender, EventArgs e)
        {
            try
            {
                xIMUserial.SendReadDateTimePacket();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// xIMUserial DateTimeDataReceived event parses data to dateTimeDataBuffer. 
        /// </summary>
        private void xIMUserial_DateTimeDataReceived(object sender, x_IMU_API.DateTimeData e)
        {
            dateTimeDataBuffer = e;
        }

        #endregion

        #region Commands

        /// <summary>
        /// CommandButton Click event sends command packet.
        /// </summary>
        private void commandButton_Click(object sender, EventArgs e)
        {
            try
            {
                xIMUserial.SendCommandPacket((sender as CommandButton).CommandCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// xIMUserial CommandDataReceived event displays message in PassiveMessageBox if enabled by CheckBox.
        /// </summary>
        private void xIMUserial_CommandDataReceived(object sender, x_IMU_API.CommandData e)
        {
            if (checkBox_displayCommandConfirmations.Checked)
            {
                PassiveMessageBox.Show("Command confirmed: " + e.GetMessage(), "Message From x-IMU", MessageBoxIcon.Information);
            }
        }

        #endregion

        #region View sensor data

        /// <summary>
        /// xIMUserial RawBatteryAndThermometerDataReceived event updates oscilloscope.
        /// </summary>
        private void xIMUserial_RawBatteryAndThermometerDataReceived(object sender, x_IMU_API.RawBatteryAndThermometerData e)
        {
            //batteryOscilloscope.Caption = "Raw Battery Data (lsb)";
            //thermometerOscilloscope.Caption = "Raw Thermometer Data (lsb)";
            batteryOscilloscope.AddScopeData(e.BatteryVoltage, 0.0f, 0.0f);
            thermometerOscilloscope.AddScopeData(e.Thermometer, 0.0f, 0.0f);
        }

        /// <summary>
        /// xIMUserial CalBatteryAndThermometerDataReceived event updates oscilloscope.
        /// </summary>
        private void xIMUserial_CalBatteryAndThermometerDataReceived(object sender, x_IMU_API.CalBatteryAndThermometerData e)
        {
            batteryOscilloscope.Caption = "Calibrated Battery Data (V)";
            thermometerOscilloscope.Caption = "Calibrated Thermometer Data (˚C)";
            batteryOscilloscope.AddScopeData(e.BatteryVoltage, 0.0f, 0.0f);
            thermometerOscilloscope.AddScopeData(e.Thermometer, 0.0f, 0.0f);
        }

        /// <summary>
        /// xIMUserial RawInertialAndMagneticDataReceived event updates oscilloscope.
        /// </summary>
        private void xIMUserial_RawInertialAndMagneticDataReceived(object sender, x_IMU_API.RawInertialAndMagneticData e)
        {
            gyroscopeOscilloscope.Caption = "Raw Gyroscope Data (lsb)";
            accelerometerOscilloscope.Caption = "Raw Accelerometer Data (lsb)";
            magnetometerOscilloscope.Caption = "Raw Magnetometer Data (lsb)";
            gyroscopeOscilloscope.AddScopeData(e.Gyroscope[0], e.Gyroscope[1], e.Gyroscope[2]);
            accelerometerOscilloscope.AddScopeData(e.Accelerometer[0], e.Accelerometer[1], e.Accelerometer[2]);
            magnetometerOscilloscope.AddScopeData(e.Magnetometer[0], e.Magnetometer[1], e.Magnetometer[2]);
        }

        /// <summary>
        /// xIMUserial CalInertialAndMagneticDataReceived event updates oscilloscope.
        /// </summary>
        private void xIMUserial_CalInertialAndMagneticDataReceived(object sender, x_IMU_API.CalInertialAndMagneticData e)
        {
            gyroscopeOscilloscope.Caption = "Calibrated Gyroscope Data (˚/s)";
            accelerometerOscilloscope.Caption = "Calibrated Accelerometer Data (g)";
            magnetometerOscilloscope.Caption = "Calibrated Magnetometer Data (G)";
            gyroscopeOscilloscope.AddScopeData(e.Gyroscope[0], e.Gyroscope[1], e.Gyroscope[2]);
            accelerometerOscilloscope.AddScopeData(e.Accelerometer[0], e.Accelerometer[1], e.Accelerometer[2]);
            magnetometerOscilloscope.AddScopeData(e.Magnetometer[0], e.Magnetometer[1], e.Magnetometer[2]);
        }

        /// <summary>
        /// xIMUserial QuaternionDataReceived event updates oscilloscope.
        /// </summary>
        private void xIMUserial_QuaternionDataReceived(object sender, x_IMU_API.QuaternionData e)
        {
            float[] euler = e.ConvertToEulerAngles();
            eulerAnglesOscilloscope.Caption = "Euler Angles Data (˚)";
            eulerAnglesOscilloscope.AddScopeData(euler[0], euler[1], euler[2]);
            form_3Dcuboid.RotationMatrix = e.ConvertToRotationMatrix();
        }

        #endregion

        #region Auxiliary port

        #region Digital I/O

        /// <summary>
        /// DigitalIOpanel OutputChanged event sends digital I/O packet.
        /// </summary>
        private void digitalIOpanel_OutputChanged(object sender, x_IMU_API.DigitalPortBits e)
        {
            try
            {
                xIMUserial.SendDigitalIOpacket(new x_IMU_API.DigitalIOdata(e));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// xIMUserial DigitalIODataReceived event parses DigitalIOdata to DigitalIOpanel.
        /// </summary>
        private void xIMUserial_DigitalIODataReceived(object sender, x_IMU_API.DigitalIOdata e)
        {
            form_digitalIOpanel.Direction = e.Direction;
            form_digitalIOpanel.State = e.State;
        }

        #endregion

        #region Analogue Input

        /// <summary>
        /// xIMUserial RawAnalogueInputDataReceived event updates oscilloscope.
        /// </summary>
        void xIMUserial_RawAnalogueInputDataReceived(object sender, x_IMU_API.RawAnalogueInputData e)
        {
            analogueInputAX0AX1oscilloscope.Caption = "Raw Analogue Input AX0 AX1 Data (lsb)";
            analogueInputAX2AX3oscilloscope.Caption = "Raw Analogue Input AX2 AX3 Data (lsb)";
            analogueInputAX4AX5oscilloscope.Caption = "Raw Analogue Input AX4 AX5 Data (lsb)";
            analogueInputAX6AX7oscilloscope.Caption = "Raw Analogue Input AX6 AX7 Data (lsb)";
            analogueInputAX0AX1oscilloscope.AddScopeData(e.AX0, e.AX1, 0.0f);
            analogueInputAX2AX3oscilloscope.AddScopeData(e.AX2, e.AX3, 0.0f);
            analogueInputAX4AX5oscilloscope.AddScopeData(e.AX4, e.AX5, 0.0f);
            analogueInputAX6AX7oscilloscope.AddScopeData(e.AX6, e.AX7, 0.0f);
        }

        /// <summary>
        /// xIMUserial CalAnalogueInputDataReceived event updates oscilloscope.
        /// </summary>
        void xIMUserial_CalAnalogueInputDataReceived(object sender, x_IMU_API.CalAnalogueInputData e)
        {
            analogueInputAX0AX1oscilloscope.Caption = "Calibrated Analogue Input AX0 AX1 Data (V)";
            analogueInputAX2AX3oscilloscope.Caption = "Calibrated Analogue Input AX2 AX3 Data (V)";
            analogueInputAX4AX5oscilloscope.Caption = "Calibrated Analogue Input AX4 AX5 Data (V)";
            analogueInputAX6AX7oscilloscope.Caption = "Calibrated Analogue Input AX6 AX7 Data (V)";
            analogueInputAX0AX1oscilloscope.AddScopeData(e.AX0, e.AX1, 0.0f);
            analogueInputAX2AX3oscilloscope.AddScopeData(e.AX2, e.AX3, 0.0f);
            analogueInputAX4AX5oscilloscope.AddScopeData(e.AX4, e.AX5, 0.0f);
            analogueInputAX6AX7oscilloscope.AddScopeData(e.AX6, e.AX7, 0.0f);
        }

        #endregion

        #region PWM output

        /// <summary>
        /// PWMoutputPanel ValuesChanged event to send PWMoutputData packet.
        /// </summary>
        void PWMoutputPanel_ValuesChanged(object sender, x_IMU_API.PWMoutputData e)
        {
            try
            {
                xIMUserial.SendPWMoutputPacket(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// xIMUserial PWMoutputDataReceived event parses PWMoutputData to PWMoutputPanel.
        /// </summary>
        void xIMUserial_PWMoutputDataReceived(object sender, x_IMU_API.PWMoutputData e)
        {
            form_PWMoutputPanel.PWMoutputData = e;
        }

        #endregion

        #region ADXL345 bus

        /// <summary>
        /// xIMUserial RawADXL345busDataReceived event updates oscilloscope.
        /// </summary>
        void xIMUserial_RawADXL345busDataReceived(object sender, x_IMU_API.RawADXL345busData e)
        {
            ADXL345_Aoscilloscope.Caption = "Raw ADXL234 A Data (lsb)";
            ADXL345_Boscilloscope.Caption = "Raw ADXL234 B Data (lsb)";
            ADXL345_Coscilloscope.Caption = "Raw ADXL234 C Data (lsb)";
            ADXL345_Doscilloscope.Caption = "Raw ADXL234 D Data (lsb)";
            ADXL345_Aoscilloscope.AddScopeData(e.ADXL345_A[0], e.ADXL345_A[1], e.ADXL345_A[2]);
            ADXL345_Boscilloscope.AddScopeData(e.ADXL345_B[0], e.ADXL345_B[1], e.ADXL345_B[2]);
            ADXL345_Coscilloscope.AddScopeData(e.ADXL345_C[0], e.ADXL345_C[1], e.ADXL345_C[2]);
            ADXL345_Doscilloscope.AddScopeData(e.ADXL345_D[0], e.ADXL345_D[1], e.ADXL345_D[2]);
        }

        /// <summary>
        /// xIMUserial CalADXL345busDataReceived event updates oscilloscope.
        /// </summary>
        void xIMUserial_CalADXL345busDataReceived(object sender, x_IMU_API.CalADXL345busData e)
        {
            ADXL345_Aoscilloscope.Caption = "Raw ADXL234 A Data (g)";
            ADXL345_Boscilloscope.Caption = "Raw ADXL234 B Data (g)";
            ADXL345_Coscilloscope.Caption = "Raw ADXL234 C Data (g)";
            ADXL345_Doscilloscope.Caption = "Raw ADXL234 D Data (g)";
            ADXL345_Aoscilloscope.AddScopeData(e.ADXL345_A[0], e.ADXL345_A[1], e.ADXL345_A[2]);
            ADXL345_Boscilloscope.AddScopeData(e.ADXL345_B[0], e.ADXL345_B[1], e.ADXL345_B[2]);
            ADXL345_Coscilloscope.AddScopeData(e.ADXL345_C[0], e.ADXL345_C[1], e.ADXL345_C[2]);
            ADXL345_Doscilloscope.AddScopeData(e.ADXL345_D[0], e.ADXL345_D[1], e.ADXL345_D[2]);
        }

        #endregion

        #endregion

        #region Data logger

        /// <summary>
        /// Button Click event displays SaveFileDialog to specify file path to be used by dataLoggerCSVfileWriter.
        /// </summary>
        private void button_dataLoggerBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Select File";
            saveFileDialog.Filter = "All files (*.*)|*.*";
            saveFileDialog.OverwritePrompt = false;
            saveFileDialog.FileName = "LoggedData";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_dataLoggerFilePath.Text = Path.GetDirectoryName(saveFileDialog.FileName.ToString()) + "\\" + Path.GetFileNameWithoutExtension(saveFileDialog.FileName.ToString());
            }
        }

        /// <summary>
        /// ToggleButton Click event toggles data logging start/stop.
        /// </summary>
        private void toggleButton_dataLoggerStartStopLogging_Click(object sender, EventArgs e)
        {
            if ((sender as ToggleButton).ToggleState)
            {
                try
                {
                    dataLoggerCSVfileWriter = new x_IMU_API.CSVfileWriter(textBox_dataLoggerFilePath.Text);
                    textBox_dataLoggerFilePath.Enabled = false;
                    button_dataLoggerBrowse.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("Invalid file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                dataLoggerCSVfileWriter.CloseFiles();
                CSVfileWriterResults.Show(dataLoggerCSVfileWriter, "Data Logger Results");
                dataLoggerCSVfileWriter = null;
                button_dataLoggerBrowse.Enabled = true;
                textBox_dataLoggerFilePath.Enabled = true;
            }
        }

        /// <summary>
        /// xIMUserial xIMUdataReceived event writes xIMUdata to file using dataLoggerCSVfileWriter.
        /// </summary>
        void xIMUserial_xIMUdataReceived(object sender, x_IMU_API.xIMUdata e)
        {
            if (dataLoggerCSVfileWriter != null)
            {
                try
                {
                    dataLoggerCSVfileWriter.WriteData(e);
                }
                catch { }
            }
        }

        #endregion

        #region SD card file

        /// <summary>
        /// Button Click event displays OpenFileDialog to specify file path of binary file.
        /// </summary>
        private void button_convertBinaryFileBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select File";
            openFileDialog.Filter = "binary files (*.bin)|*.bin|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_convertBinaryFileFilePath.Text = openFileDialog.FileName.ToString();
            }
        }

        /// <summary>
        /// Button Click event disables form control and starts binary file conversion in new thread.
        /// </summary>
        private void button_convertBinaryFileConvert_Click(object sender, EventArgs e)
        {
            // Error if file not exist
            if (!File.Exists(textBox_convertBinaryFileFilePath.Text))
            {
                MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Disable SD card form controls
            textBox_convertBinaryFileFilePath.Enabled = false;
            button_convertBinaryFileBrowse.Enabled = false;
            button_convertBinaryFileConvert.Enabled = false;
            button_convertBinaryFileConvert.Text = "Converting...";

            // Create process dialog
            binaryFileConverterProgressDialog = new ProgressDialog(this.Handle);
            binaryFileConverterProgressDialog.Title = "Converting Binary File";
            binaryFileConverterProgressDialog.CancelMessage = "Cancelling...";
            binaryFileConverterProgressDialog.Line1 = "Converting to binary file to CSV files";
            binaryFileConverterProgressDialog.Line3 = "Initialising x-IMU file reader.";
            binaryFileConverterProgressDialog.ShowDialog();
            binaryFileConverterProgressDialog.Value = 0;

            // Create file converter objects
            binaryFileConverterCSVfileWriter = new x_IMU_API.CSVfileWriter(Path.GetDirectoryName(textBox_convertBinaryFileFilePath.Text) + "\\" + Path.GetFileNameWithoutExtension(textBox_convertBinaryFileFilePath.Text));
            x_IMU_API.xIMUfile xIMUfile = new x_IMU_API.xIMUfile(textBox_convertBinaryFileFilePath.Text);
            xIMUfile.xIMUdataRead += new x_IMU_API.xIMUfile.onxIMUdataRead(xIMUfile_xIMUdataRead);
            xIMUfile.AsyncReadProgressChanged += new x_IMU_API.xIMUfile.onAsyncReadProgressChanged(xIMUfile_AsyncReadProgressChanged);
            xIMUfile.AsyncReadCompleted += new x_IMU_API.xIMUfile.onAsyncReadCompleted(xIMUfile_AsyncReadCompleted);
            xIMUfile.RunAnsycRead();
        }

        /// <summary>
        /// xIMUfile AsyncReadProgressChanged event updates binaryFileConverterProgressDialog and checks for user cancellation.
        /// </summary>
        void xIMUfile_AsyncReadProgressChanged(object sender, x_IMU_API.AsyncReadProgressChangedEventArgs e)
        {
            this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate
            {
                if (binaryFileConverterProgressDialog.HasUserCancelled)
                {
                    ((x_IMU_API.xIMUfile)sender).CancelAnsycRead();
                }
                else
                {
                    binaryFileConverterProgressDialog.Value = (uint)e.ProgressPercentage;
                    binaryFileConverterProgressDialog.Line3 = e.ProgressMessage;
                }
            })));
        }

        /// <summary>
        /// xIMUfile AsyncReadCompleted event closes files, displays CSVfileWriterResults dialog and re-enables form controls.
        /// </summary>
        void xIMUfile_AsyncReadCompleted(object sender, x_IMU_API.AsyncReadCompletedEventArgs e)
        {
            binaryFileConverterCSVfileWriter.CloseFiles();
            ((x_IMU_API.xIMUfile)sender).Close();
            if (!e.Cancelled)
            {
                CSVfileWriterResults.Show(binaryFileConverterCSVfileWriter, "Binary File Conversion Results");
            }
            this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate
            {
                button_convertBinaryFileConvert.Text = "Convert";
                textBox_convertBinaryFileFilePath.Enabled = true;
                button_convertBinaryFileConvert.Enabled = true;
                button_convertBinaryFileBrowse.Enabled = true;
                binaryFileConverterProgressDialog.CloseDialog();
            })));
        }

        /// <summary>
        /// xIMUfile xIMUdataRead event writes xIMUdata to file using binaryFileConverterCSVfileWriter.
        /// </summary>
        void xIMUfile_xIMUdataRead(object sender, x_IMU_API.xIMUdata e)
        {
            try
            {
                binaryFileConverterCSVfileWriter.WriteData(e);
            }
            catch { }
        }

        #endregion

        #region Hard-iron calibration

        #region Step 1 - Clear current hard-iron bias parameters

        /// <summary>
        /// Button Click event sends write register packets to clear hard-iron bias registers.
        /// </summary>
        private void button_clearHardIronRegisters_Click(object sender, EventArgs e)
        {
            try
            {
                xIMUserial.SendWriteRegisterPacket(new x_IMU_API.RegisterData(x_IMU_API.RegisterAddresses.MagnetometerHardIronBiasX, 0));
                xIMUserial.SendWriteRegisterPacket(new x_IMU_API.RegisterData(x_IMU_API.RegisterAddresses.MagnetometerHardIronBiasY, 0));
                xIMUserial.SendWriteRegisterPacket(new x_IMU_API.RegisterData(x_IMU_API.RegisterAddresses.MagnetometerHardIronBiasZ, 0));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Step 2 - Collect Calibration Dataset

        /// <summary>
        /// Button Click event displays SaveFileDialog to specify file path to be used by hardIronCalCSVfileWriter.
        /// </summary>
        private void buttonCollectHardIronCalDatasetBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Select File";
            saveFileDialog.Filter = "All files (*.*)|*.*";
            saveFileDialog.OverwritePrompt = false;
            saveFileDialog.FileName = "HardIronCalDataset";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_collectHardIronCalDatasetFilePath.Text = saveFileDialog.FileName.ToString();
            }
        }

        /// <summary>
        /// TextBox TextChanged event synchronises dependant related file paths.
        /// </summary>
        private void textBox_collectHardIronCalDatasetFilePath_TextChanged(object sender, EventArgs e)
        {
            textBox_hardIronCalFilePath.Text = textBox_collectHardIronCalDatasetFilePath.Text + "_CalInertialAndMag.csv";
        }

        /// <summary>
        /// ToggleButton Click event toggles hard-iron calibration data logger start/stop.
        /// </summary>
        private void toggleButton_collectHardIronCalDatasetStartStopLogging_Click(object sender, EventArgs e)
        {
            if ((sender as ToggleButton).ToggleState)
            {
                try
                {
                    hardIronCalCSVfileWriter = new x_IMU_API.CSVfileWriter(textBox_collectHardIronCalDatasetFilePath.Text);
                    textBox_collectHardIronCalDatasetFilePath.Enabled = false;
                    button_collectHardIronCalDatasetBrowse.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("Invalid file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                hardIronCalCSVfileWriter.CloseFiles();
                if (hardIronCalCSVfileWriter.PacketsWrittenCounter.CalInertialAndMagneticDataPackets == 0)
                {
                    PassiveMessageBox.Show("No 'CalInertialAndMagneticData' packets were received." + Environment.NewLine + Environment.NewLine +
                                           "Please check the \"Data Output Settings\" registers.", "Warning", MessageBoxIcon.Warning);
                }
                else
                {
                    CSVfileWriterResults.Show(hardIronCalCSVfileWriter, "Hard-Iron Dataset Collection Results");
                }
                button_collectHardIronCalDatasetBrowse.Enabled = true;
                textBox_collectHardIronCalDatasetFilePath.Enabled = true;
                hardIronCalCSVfileWriter = null;
            }
        }

        /// <summary>
        /// xIMUserial xIMUdataReceived event writes xIMUdata to file using hardIronCalCSVfileWriter.
        /// </summary>
        void xIMUserial_CalInertialAndMagneticDataReceivedHardIronCal(object sender, x_IMU_API.CalInertialAndMagneticData e)
        {
            if (hardIronCalCSVfileWriter != null)
            {
                try
                {
                    hardIronCalCSVfileWriter.WriteCalInertialAndMagneticData(e);
                }
                catch { }
            }
        }

        #endregion

        #region Step 3 - Run Hard-Iron Calibration Algorithm

        /// <summary>
        /// Button Click event displays OpenFileDialog to specify file path of hard-iron calibration dataset.
        /// </summary>
        private void button_hardIronCalBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select File";
            openFileDialog.Filter = "x-IMU CSV File|*_CalInertialAndMag.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_hardIronCalFilePath.Text = openFileDialog.FileName.ToString();
            }
        }

        /// <summary>
        /// Button Click event runs hard-iron calibration algorithm and write parameters to registers.
        /// </summary>
        private void button_hardIronCalRun_Click(object sender, EventArgs e)
        {
            // Error if file not exist
            if (!File.Exists(textBox_hardIronCalFilePath.Text))
            {
                MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Disable hard-iron calibration form controls
            textBox_hardIronCalFilePath.Enabled = false;
            button_hardIronCalBrowse.Enabled = false;
            button_hardIronCalRun.Enabled = false;
            button_hardIronCalRun.Text = "Running...";
            this.Update();

            try
            {
                // Run hard-iron calibration bootloader process
                string resultPath = Path.GetDirectoryName(textBox_hardIronCalFilePath.Text) + "\\" + "HardIronCal_Result.csv";
                ProcessStartInfo processInfo = new ProcessStartInfo("HardIronCal\\HardIronCal.exe");
                processInfo.Arguments = " -src " + "\"" + textBox_hardIronCalFilePath.Text + "\"" +
                                        " -des " + "\"" + Path.GetDirectoryName(textBox_hardIronCalFilePath.Text) + "\"" +
                                        " -row " + "1" +
                                        " -col " + "7" +
                                        " -ext " + "True";
                processInfo.UseShellExecute = false;
                Process process = Process.Start(processInfo);
                process.WaitForExit();
                if (process.ExitCode != 0)
                {
                    throw new Exception("Hard-iron calibration failed.  See console application for details.");
                }
                process.Close();

                // Import hard-iron bias parameters
                StreamReader streamReader = new StreamReader(resultPath);
                streamReader.ReadLine();                                    // disregard first line (column headings)
                string[] biasesStr = streamReader.ReadLine().Split(',');
                streamReader.Close();

                // Write parameters to device registers
                xIMUserial.SendWriteRegisterPacket(new x_IMU_API.RegisterData(x_IMU_API.RegisterAddresses.MagnetometerHardIronBiasX, (float)Convert.ToDouble(biasesStr[0])));
                xIMUserial.SendWriteRegisterPacket(new x_IMU_API.RegisterData(x_IMU_API.RegisterAddresses.MagnetometerHardIronBiasY, (float)Convert.ToDouble(biasesStr[1])));
                xIMUserial.SendWriteRegisterPacket(new x_IMU_API.RegisterData(x_IMU_API.RegisterAddresses.MagnetometerHardIronBiasZ, (float)Convert.ToDouble(biasesStr[2])));
                PassiveMessageBox.Show("Hard-iron calibration complete.  The magnetometer hard-iron bias registers have been updated.", "Information", MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Re-enable hard-iron calibration form controls
            button_hardIronCalRun.Text = "Run";
            textBox_hardIronCalFilePath.Enabled = true;
            button_hardIronCalBrowse.Enabled = true;
            button_hardIronCalRun.Enabled = true;
        }

        #endregion

        #endregion

        #region Upload firmware

        /// <summary>
        /// Button Click event displays OpenFileDialog to specify file path of firmware .hex file.
        /// </summary>
        private void button_bootloaderBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select Firmware Hex File";
            openFileDialog.Filter = "HEX Files|*.hex";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_bootloaderFilePath.Text = openFileDialog.FileName.ToString();
            }
        }

        /// <summary>
        /// Button Click event to upload firmware.
        /// </summary>
        private void button_bootloaderUpload_Click(object sender, EventArgs e)
        {
            // Error if file not exist
            if (!File.Exists(textBox_bootloaderFilePath.Text))
            {
                MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Error if selected port name = "Auto"
            if (string.Equals(comboBox_portName.Text, "Auto", StringComparison.CurrentCultureIgnoreCase))
            {
                MessageBox.Show("Port name \"Auto\" cannot be used for bootloading.  Please select the port name assigned to the USB connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // User confirmation
            if (MessageBox.Show("Please ensure that the selected port name is the port assigned to the x-IMU USB connection else the upload will fail." + Environment.NewLine + Environment.NewLine +
                                "The new firmware will be uploaded to the x-IMU and the current firmware will be lost." + Environment.NewLine + Environment.NewLine +
                                "Do not switch off or disconnect the x-IMU while firmware is being uploaded as this may permanently damage the x-IMU.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            // Disable bootloader form controls
            textBox_bootloaderFilePath.Enabled = false;
            button_bootloaderBrowse.Enabled = false;
            button_bootloaderUpload.Enabled = false;
            button_bootloaderUpload.Text = "Uploading...";
            this.Update();

            // Close port is currently open
            bool reopenPort = false;
            if (xIMUserial.IsOpen)
            {
                xIMUserial.Close();
                reopenPort = true;
            }

            // Perform firmware upload procedure
            try
            {
                // Reset device
                x_IMU_API.xIMUserial tempxIMUserial = new x_IMU_API.xIMUserial(comboBox_portName.Text);
                tempxIMUserial.Open();
                tempxIMUserial.SendCommandPacket(x_IMU_API.CommandCodes.Reset);
                tempxIMUserial.Close();

                // Run external bootloader process
                ProcessStartInfo processInfo = new ProcessStartInfo("Bootloader/16-Bit Flash Programmer.exe");
                processInfo.Arguments = "-i " + "\\\\.\\" + comboBox_portName.Text + " -b 115200 \"" + textBox_bootloaderFilePath.Text + "\"";
                processInfo.UseShellExecute = false;
                Process process = Process.Start(processInfo);
                process.WaitForExit();
                process.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Re-enable bootloader form controls
            textBox_bootloaderFilePath.Enabled = true;
            button_bootloaderBrowse.Enabled = true;
            button_bootloaderUpload.Enabled = true;
            button_bootloaderUpload.Text = "Upload";

            // Re-open port if was closed prior to bootload
            if (reopenPort)
            {
                xIMUserial.Open();
            }
        }

        #endregion

        #region About

        /// <summary>
        /// LinkLabel Click event opens company website in web browser.
        /// </summary>
        private void linkLabel_wwwxiocouk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.x-io.co.uk");
            }
            catch
            {
                MessageBox.Show("Browser launch failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}