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
        /// x-IMU serial object used to communicate to the x-IMU via USB or Bluetooth.
        /// </summary>
        private x_IMU_API.xIMUserial xIMUserial;

        /// <summary>
        /// Progress dialog used to display and enable cancellation of auto connect process.
        /// </summary>
        private ProgressDialog autoConnectProgressDialog;

        /// <summary>
        /// For update timer used to periodically update form data
        /// </summary>
        private System.Windows.Forms.Timer formUpdateTimer;

        /// <summary>
        /// RegisterData array used to parse register data between xIMUserial and GUI threads.
        /// </summary>
        private x_IMU_API.RegisterData[] treeViewRegisterDataBuffer;

        /// <summary>
        /// DateTime object used to buffer date/time data between xIMUserial and GUI threads.
        /// </summary>
        private x_IMU_API.DateTimeData dateTimeData;

        /// <summary>
        /// Oscilloscope objects used to display individual sensor data.
        /// </summary>
        /// <remarks>
        /// Requires Osc_DLL.dll version 2.8.2, see http://www.oscilloscope-lib.com/. Original Oscilloscope.cs wrapper class provided by Frank Greenlee.
        /// </remarks>
        private Oscilloscope battOscilloscope, thermOscilloscope, gyroOscilloscope, accelOscilloscope, magOscilloscope, eulerOscilloscope,
                             AnalogueInputAX0AX1oscilloscope, AnalogueInputAX2AX3oscilloscope, AnalogueInputAX4AX5oscilloscope, AnalogueInputAX6AX7oscilloscope,
                             _ADXL345_Aoscilloscope, _ADXL345_Boscilloscope, _ADXL345_Coscilloscope, _ADXL345_Doscilloscope;

        /// <summary>
        /// 3D Cuboid graphics form used to display 3D orientation (quaternion) data.
        /// </summary>
        private Cuboid3D cuboid3D;

        /// <summary>
        /// Digital I/O form used to set and display digital I/O data.
        /// </summary>
        private Form_digitalIOpanel digitalIOpanel;

        /// <summary>
        /// PWM output form used to set and display PWM output data.
        /// </summary>
        private Form_PWMoutputPanel PWMoutputPanel;
        
        /// <summary>
        /// CSV files object for data logger.
        /// </summary>
        private x_IMU_API.CSVfileWriter dataLoggerFiles;

        /// <summary>
        /// Packet count object used to calculate the number of packets logged using the data logger.
        /// </summary>
        private x_IMU_API.PacketCount dataLoggerStartPacketCount;

        /// <summary>
        /// CSV files object for converted binary files.
        /// </summary>
        private x_IMU_API.CSVfileWriter convertedBinaryFiles;

        /// <summary>
        /// Progress dialog used to display and enable cancellation of asynchronous file read process.
        /// </summary>
        private ProgressDialog binaryFileConverterProgressDialog;

        /// <summary>
        /// CSV files object for hard-iron calibration dataset logging.
        /// </summary>
        private x_IMU_API.CSVfileWriter hardIronCalDataFiles;

        /// <summary>
        /// Packet count object used to calculate the number of packets logged using the hard-iron calibration dataset logger.
        /// </summary>
        private x_IMU_API.PacketCount hardIronCalStartPacketCount;

        #endregion

        #region Form constructor

        /// <summary>
        /// Form constructor.
        /// </summary>
        public Form_main()
        {
            InitializeComponent();
            InitializeAppendedTreeViewComponents();
        }

        #endregion

        #region Form load/close

        /// <summary>
        /// Form load event to set initial form control values and start form update timer.
        /// </summary>
        private void Form_main_Load(object sender, EventArgs e)
        {
            this.Text = Assembly.GetExecutingAssembly().GetName().Name + " " + Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();

            // Create peripheral GUI objects
            battOscilloscope = Oscilloscope.CreateScope("Oscilloscope/battOscilloscope_settings.ini", "");
            thermOscilloscope = Oscilloscope.CreateScope("Oscilloscope/thermOscilloscope_settings.ini", "");
            gyroOscilloscope = Oscilloscope.CreateScope("Oscilloscope/gyroOscilloscope_settings.ini", "");
            accelOscilloscope = Oscilloscope.CreateScope("Oscilloscope/accelOscilloscope_settings.ini", "");
            magOscilloscope = Oscilloscope.CreateScope("Oscilloscope/magOscilloscope_settings.ini", "");
            eulerOscilloscope = Oscilloscope.CreateScope("Oscilloscope/eulerOscilloscope_settings.ini", "");
            cuboid3D = new Cuboid3D(new float[] { 6, 4, 2 }, new string[] { "Cuboid3D/Right.png", "Cuboid3D/Left.png", "Cuboid3D/Back.png",
                                                                            "Cuboid3D/Front.png", "Cuboid3D/Top.png", "Cuboid3D/Bottom.png"});
            digitalIOpanel = new Form_digitalIOpanel();
            digitalIOpanel.OutputChanged += new Form_digitalIOpanel.onOutputChanged(digitalIOpanel_OutputChanged);
            AnalogueInputAX0AX1oscilloscope = Oscilloscope.CreateScope("Oscilloscope/AnalogueInputAX0AX1oscilloscope_settings.ini", "");
            AnalogueInputAX2AX3oscilloscope = Oscilloscope.CreateScope("Oscilloscope/AnalogueInputAX2AX3oscilloscope_settings.ini", "");
            AnalogueInputAX4AX5oscilloscope = Oscilloscope.CreateScope("Oscilloscope/AnalogueInputAX4AX5oscilloscope_settings.ini", "");
            AnalogueInputAX6AX7oscilloscope = Oscilloscope.CreateScope("Oscilloscope/AnalogueInputAX6AX7oscilloscope_settings.ini", "");
            PWMoutputPanel = new Form_PWMoutputPanel();
            PWMoutputPanel.ValuesChanged += new Form_PWMoutputPanel.onValuesChanged(PWMoutputPanel_ValuesChanged);
            _ADXL345_Aoscilloscope = Oscilloscope.CreateScope("Oscilloscope/ADXL345Aoscilloscope_settings.ini", "");
            _ADXL345_Boscilloscope = Oscilloscope.CreateScope("Oscilloscope/ADXL345Boscilloscope_settings.ini", "");
            _ADXL345_Coscilloscope = Oscilloscope.CreateScope("Oscilloscope/ADXL345Coscilloscope_settings.ini", "");
            _ADXL345_Doscilloscope = Oscilloscope.CreateScope("Oscilloscope/ADXL345Doscilloscope_settings.ini", "");

            // Create x-IMU serial object
            xIMUserial = new x_IMU_API.xIMUserial();
            xIMUserial.xIMUdataReceived += new x_IMU_API.xIMUserial.onxIMUdataReceived(xIMUserial_xIMUdataReceived);
            xIMUserial.ErrorDataReceived += new x_IMU_API.xIMUserial.onErrorDataReceived(xIMUserial_ErrorDataReceived);
            xIMUserial.CommandDataReceived += new x_IMU_API.xIMUserial.onCommandDataReceived(xIMUserial_CommandDataReceived);
            xIMUserial.RegisterDataReceived += new x_IMU_API.xIMUserial.onRegisterDataReceived(xIMUserial_RegisterDataReceived);
            xIMUserial.DateTimeDataReceived += new x_IMU_API.xIMUserial.onDateTimeDataReceived(xIMUserial_DateTimeDataReceived);
            xIMUserial.RawBattThermDataReceived += new x_IMU_API.xIMUserial.onRawBattThermDataReceived(xIMUserial_RawBattThermDataReceived);
            xIMUserial.CalBattThermDataReceived += new x_IMU_API.xIMUserial.onCalBattThermDataReceived(xIMUserial_CalBattThermDataReceived);
            xIMUserial.RawInertialMagDataReceived += new x_IMU_API.xIMUserial.onRawInertialMagDataReceived(xIMUserial_RawInertialMagDataReceived);
            xIMUserial.CalInertialMagDataReceived += new x_IMU_API.xIMUserial.onCalInertialMagDataReceived(xIMUserial_CalInertialMagDataReceived);
            xIMUserial.QuaternionDataReceived += new x_IMU_API.xIMUserial.onQuaternionDataReceived(xIMUserial_QuaternionDataReceived);
            xIMUserial.DigitalIODataReceived += new x_IMU_API.xIMUserial.onDigitalIODataReceived(xIMUserial_DigitalIODataReceived);
            xIMUserial.RawAnalogueInputDataReceived += new x_IMU_API.xIMUserial.onRawAnalogueInputDataReceived(xIMUserial_RawAnalogueInputDataReceived);
            xIMUserial.CalAnalogueInputDataReceived += new x_IMU_API.xIMUserial.onCalAnalogueInputDataReceived(xIMUserial_CalAnalogueInputDataReceived);
            xIMUserial.PWMoutputDataReceived += new x_IMU_API.xIMUserial.onPWMoutputDataReceived(xIMUserial_PWMoutputDataReceived);
            xIMUserial.RawADXL345busDataReceived += new x_IMU_API.xIMUserial.onRawADXL345busDataReceived(xIMUserial_RawADXL345busDataReceived);
            xIMUserial.CalADXL345busDataReceived += new x_IMU_API.xIMUserial.onCalADXL345busDataReceived(xIMUserial_CalADXL345busDataReceived);

            // Create register data buffer and tool tip
            treeViewRegisterDataBuffer = new x_IMU_API.RegisterData[(int)x_IMU_API.RegisterAddresses.NumRegisters];
            ToolTip toolTip = new ToolTip();
            toolTip.ToolTipTitle = "Tip:";
            toolTip.SetToolTip(appendedTreeView_registers, "Right-click for action menu");

            // Set fixed form control values
            label_GUIversionNum.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            label_APIversionNum.Text = FileVersionInfo.GetVersionInfo("x-IMU API.dll").FileVersion.ToString();
            label_compatibleFirmwareVersionNums.Text = "";
            for (int i = 0; i < ((int[])Enum.GetValues(typeof(x_IMU_API.CompatibleFirmwareVersions))).Length; i++)
            {
                label_compatibleFirmwareVersionNums.Text += Convert.ToString(((int[])Enum.GetValues(typeof(x_IMU_API.CompatibleFirmwareVersions)))[i]) + ".x";
                if (i < ((int[])Enum.GetValues(typeof(x_IMU_API.CompatibleFirmwareVersions))).Length - 1)
                {
                    label_compatibleFirmwareVersionNums.Text += ", ";
                }
            }

            // Set default variable form control values
            refreshCOMportList();
            textBox_dataLoggerFilePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\" + "LoggedData";
            textBox_collectHardIronCalDatasetFilePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\" + "HardIronCal";

            // Create and start form update timer
            formUpdateTimer = new System.Windows.Forms.Timer();
            formUpdateTimer.Interval = 50;
            formUpdateTimer.Tick += new EventHandler(formUpdateTimer_Tick);
            formUpdateTimer.Start();

            // Auto connect on start up
            AutoConnect();
        }

        /// <summary>
        /// Form closed event to close serial port and files.
        /// </summary>
        private void Form_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosePort();
            dataLoggerFiles.CloseFiles();
            convertedBinaryFiles.CloseFiles();
            hardIronCalDataFiles.CloseFiles();
        }

        #endregion

        #region Form update timer

        /// <summary>
        /// Timer tick event to update form control data.
        /// </summary>
        private void formUpdateTimer_Tick(object sender, EventArgs e)
        {
            // Update packet counter text boxes
            textBox_packetsReceived.Text = Convert.ToString(xIMUserial.PacketCounter.TotalPacketsRead);
            textBox_packetsSent.Text = Convert.ToString(xIMUserial.PacketCounter.TotalPacketsWritten);

            // Apply new register data to tree view
            bool needToRefresh = false;
            for (int i = 0; i < (int)x_IMU_API.RegisterAddresses.NumRegisters; i++)
            {
                if (treeViewRegisterDataBuffer[i] != null)                              // non-null data class indicates new data
                {
                    RegisterDataToTreeNode(treeViewRegisterDataBuffer[i]);
                    treeViewRegisterDataBuffer[i] = null;                               // flag data class as up-to-date
                    needToRefresh = true;
                }
            }
            if (needToRefresh)
            {
                appendedTreeView_registers.Refresh();                                   // refresh only once per timer tick
            }

            // Update received date/time text box
            if (dateTimeData != null)
            {
                textBox_receivedDataTime.Text = dateTimeData.ConvertToString();
            }
        }

        #endregion

        #region Serial port

        /// <summary>
        /// Button click event to refresh port names combo box.
        /// </summary>
        private void button_refreshList_Click(object sender, EventArgs e)
        {
            refreshCOMportList();
        }

        /// <summary>
        /// Adds available port names to the port name combo box and selects the last in the list.
        /// </summary>
        private void refreshCOMportList()
        {
            string[] aviablePorts = x_IMU_API.xIMUserial.GetPortNames();
            comboBox_portName.Items.Clear();
            comboBox_portName.Items.Add("Auto");
            for (int i = 0; i < aviablePorts.Length; i++)
            {
                comboBox_portName.Items.Add(aviablePorts[i]);
            }
            comboBox_portName.SelectedIndex = 0;
        }

        /// <summary>
        /// Toggles the open/closed state of the serial port.
        /// </summary>
        private void button_openPort_Click(object sender, EventArgs e)
        {
            if (button_openPort.Text == "Open Port")
            {
                OpenPort();
            }
            else if (button_openPort.Text == "Close Port")
            {
                ClosePort();
            }
        }

        /// <summary>
        /// Opens x-IMU serial port and sets form controls. Exceptions shown message box.
        /// </summary>
        private void OpenPort()
        {
            try
            {
                comboBox_portName.Enabled = false;
                button_refreshList.Enabled = false;
                button_openPort.Enabled = false;
                button_openPort.Text = "Opening...";
                this.Update();
                if (string.Equals(comboBox_portName.Text, "Auto", StringComparison.CurrentCultureIgnoreCase))
                {
                    AutoConnect();
                    return;
                }
                else
                {
                    xIMUserial.PortName = comboBox_portName.Text;
                    xIMUserial.Open();
                }
                button_openPort.Text = "Close Port";
                button_openPort.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button_openPort.Text = "Open Port";
                comboBox_portName.Enabled = true;
                button_refreshList.Enabled = true;
                button_openPort.Enabled = true;
            }
        }

        /// <summary>
        /// Closes x-IMU serial port and sets form controls.
        /// </summary>
        private void ClosePort()
        {
            try
            {
                xIMUserial.Close();
            }
            catch { }
            comboBox_portName.Enabled = true;
            button_refreshList.Enabled = true;
            button_openPort.Enabled = true;
            button_openPort.Text = "Open Port";
        }

        /// <summary>
        /// Automatically connect to the first x-IMU found using the PortScanner.
        /// </summary>
        private void AutoConnect()
        {
            // Set form control states
            comboBox_portName.Enabled = false;
            button_refreshList.Enabled = false;
            button_openPort.Enabled = false;
            button_openPort.Text = "Opening...";

            // Create process dialog
            autoConnectProgressDialog = new ProgressDialog(this.Handle);
            autoConnectProgressDialog.Title = "Auto Connecting";
            autoConnectProgressDialog.CancelMessage = "Cancelling...";
            autoConnectProgressDialog.Line1 = "Searching for x-IMU";
            autoConnectProgressDialog.Line3 = "Initialising x-IMU port scanner.";
            autoConnectProgressDialog.ShowDialog();
            autoConnectProgressDialog.Value = 101;     // set value >100 after show, for continuous animation.

            // Create port scanner
            x_IMU_API.PortScanner portScanner = new x_IMU_API.PortScanner();
            portScanner.AsyncScanProgressChanged += new x_IMU_API.PortScanner.onAsyncScanProgressChanged(portScanner_AsyncScanProgressChanged);
            portScanner.AsyncScanCompleted += new x_IMU_API.PortScanner.onAsyncScanCompleted(portScanner_AsyncScanCompleted);
            portScanner.DontGiveUp = true;
            portScanner.FirstResultOnly = true;
            portScanner.RunAsynsScan();
        }

        /// <summary>
        /// Port scanner progress change event to update progress dialog and poll user cancel.
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
        /// PortScanner complete event to set form control states and open serial port if successful.
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
        /// Error message received event to display error message in message box.
        /// </summary>
        private void xIMUserial_ErrorDataReceived(object sender, x_IMU_API.ErrorData e)
        {
            PassiveMessageBox.Show("Error: " + e.GetMessage(), "Message From x-IMU", MessageBoxIcon.Error);
        }

        #endregion

        #region Registers

        #region Register tree view context menu

        /// <summary>
        /// Tree view click event to display context menu on right-click.
        /// </summary>
        /// <remarks>
        /// The tree view selected node will be set to that at the location of the cursor.
        /// </remarks>
        private void appendedTreeView_registers_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            appendedTreeView_registers.SelectedNode = appendedTreeView_registers.GetNodeAt(e.X, e.Y);
            if ((appendedTreeView_registers.SelectedNode != null) && (e.Button == MouseButtons.Right))
            {
                ContextMenu regContextMenu = new ContextMenu();
                regContextMenu.MenuItems.Add(new MenuItem("Expand all"));
                regContextMenu.MenuItems.Add(new MenuItem("Collapse all"));
                regContextMenu.MenuItems.Add(new MenuItem("-"));
                regContextMenu.MenuItems.Add(new MenuItem("Save all to file"));
                regContextMenu.MenuItems.Add(new MenuItem("Load from file"));
                regContextMenu.MenuItems.Add(new MenuItem("-"));
                regContextMenu.MenuItems.Add(new MenuItem("Read all registers"));
                regContextMenu.MenuItems.Add(new MenuItem("Write all registers"));
                regContextMenu.MenuItems[0].Click += new EventHandler(regContextMenu_ItemClick_expand);
                regContextMenu.MenuItems[1].Click += new EventHandler(regContextMenu_ItemClick_collapse);
                regContextMenu.MenuItems[3].Click += new EventHandler(regContextMenu_ItemClick_saveAllToFile);
                regContextMenu.MenuItems[4].Click += new EventHandler(regContextMenu_ItemClick_loadFromFile);
                regContextMenu.MenuItems[6].Click += new EventHandler(regContextMenu_ItemClick_readAll);
                regContextMenu.MenuItems[7].Click += new EventHandler(regContextMenu_ItemClick_writeAll);
                regContextMenu.MenuItems.Add(new MenuItem("-"));
                if (e.Node.LastNode == null)
                {
                    regContextMenu.MenuItems.Add(new MenuItem("Read this register only"));
                    regContextMenu.MenuItems.Add(new MenuItem("Write this register only"));
                    regContextMenu.MenuItems[9].Click += new EventHandler(regContextMenu_ItemClick_readThisOnly);
                    regContextMenu.MenuItems[10].Click += new EventHandler(regContextMenu_ItemClick_writeThisOnly);
                }
                else
                {
                    regContextMenu.MenuItems.Add(new MenuItem("Read all registers in this group only"));
                    regContextMenu.MenuItems.Add(new MenuItem("Write all registers in this group only"));
                    regContextMenu.MenuItems[9].Click += new EventHandler(regContextMenu_ItemClick_readAllThisGroupOnly);
                    regContextMenu.MenuItems[10].Click += new EventHandler(regContextMenu_ItemClick_writAllThisGroupOnly);
                }
                regContextMenu.Show(appendedTreeView_registers, new Point(e.X, e.Y));
            }
        }

        #region Expand/collapse all

        /// <summary>
        /// Context menu item click event to expand all of the tree view.
        /// </summary>
        private void regContextMenu_ItemClick_expand(object sender, EventArgs e)
        {
            appendedTreeView_registers.ExpandAll();
        }

        /// <summary>
        /// Context menu item click event to collapse all of the tree view.
        /// </summary>
        private void regContextMenu_ItemClick_collapse(object sender, EventArgs e)
        {
            appendedTreeView_registers.CollapseAll();
        }

        #endregion

        #region Save all to file

        /// <summary>
        /// Context menu item click event to save all registers data to file.
        /// </summary>
        private void regContextMenu_ItemClick_saveAllToFile(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Select File";
            saveFileDialog.Filter = "x-IMU Binary Files (*.bin)|*.bin|All files (*.*)|*.*";
            saveFileDialog.FileName = "savedRegisters" + appendedTreeNodeTextBox_deviceID.TextBox.Text + ".bin";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                x_IMU_API.xIMUfile xIMUfile = new x_IMU_API.xIMUfile(saveFileDialog.FileName.ToString(), true);
                foreach (TreeNode rootNode in appendedTreeView_registers.Nodes)
                {
                    x_IMU_API.RegisterData registerData = TreeNodeToRegisterData(rootNode, false);
                    WriteWriteRegister(xIMUfile, registerData);
                    WriteWriteRegisterForAllChildNodes(xIMUfile, rootNode);
                }
                xIMUfile.Close();
            }
        }

        /// <summary>
        /// Sends a write register packet to device for each child node of a specified tree node.
        /// </summary>
        /// <param name="register">
        /// x-IMU file object to be written to.
        /// </param>
        /// <param name="rootNode">
        /// Parent node of all nodes for which a write register packet will be written.
        /// </param>
        private void WriteWriteRegisterForAllChildNodes(x_IMU_API.xIMUfile xIMUfile, TreeNode rootNode)
        {
            foreach (TreeNode childNode in rootNode.Nodes)
            {
                x_IMU_API.RegisterData registerData = TreeNodeToRegisterData(childNode, false);
                WriteWriteRegister(xIMUfile, registerData);
                if (childNode.Nodes.Count > 0) WriteWriteRegisterForAllChildNodes(xIMUfile, childNode); // apply to all child nodes recursively
            }
        }

        /// <summary>
        /// Write a write register packet to file.
        /// </summary>
        /// <param name="register">
        /// x-IMU file object to be written to.
        /// </param>
        /// <param name="registerData">
        /// Register data object containing address and value of register to be written.
        /// </param>
        private void WriteWriteRegister(x_IMU_API.xIMUfile xIMUfile, x_IMU_API.RegisterData registerData)
        {
            if (registerData != null)
            {
                xIMUfile.WriteWriteRegisterPacket(registerData);
            }
        }

        #endregion

        #region Load from file

        /// <summary>
        /// Context menu item click event to load register data from file.
        /// </summary>
        /// <remarks>
        /// File read process is started within new thread.
        /// </remarks>
        private void regContextMenu_ItemClick_loadFromFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select File";
            openFileDialog.Filter = "x-IMU Binary Files (*.bin)|*.bin|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                x_IMU_API.xIMUfile xIMUfile = new x_IMU_API.xIMUfile(openFileDialog.FileName.ToString());
                xIMUfile.RegisterDataRead += new x_IMU_API.xIMUfile.onRegisterDataRead(xIMUfile_RegisterDataRead);
                xIMUfile.Read();
                if (xIMUfile.PacketCounter.PacketsReadErrors != 0)
                {
                    MessageBox.Show(Convert.ToString(xIMUfile.PacketCounter.PacketsReadErrors) + " read errors occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                xIMUfile.Close();
            }
        }

        /// <summary>
        /// Register data read event to parse data to register tree view.
        /// </summary>
        private void xIMUfile_RegisterDataRead(object sender, x_IMU_API.RegisterData e)
        {
            treeViewRegisterDataBuffer[(int)e.Address] = e;
        }

        #endregion

        #region Read registers

        /// <summary>
        /// Context menu item click event to send a read register packet for nodes in the tree view.
        /// </summary>
        private void regContextMenu_ItemClick_readAll(object sender, EventArgs e)
        {
            if (xIMUserial.IsOpen)
            {
                foreach (TreeNode rootNode in appendedTreeView_registers.Nodes)
                {
                    x_IMU_API.RegisterData registerData = TreeNodeToRegisterData(rootNode, true);
                    if (registerData != null) SendReadRegister(registerData);
                    SendReadRegisterForAllChildNodes(rootNode);
                }
            }
            else
            {
                MessageBox.Show("The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Context menu item click event to send a read register packet for all child nodes of the current selected tree node.
        /// </summary>
        private void regContextMenu_ItemClick_readAllThisGroupOnly(object sender, EventArgs e)
        {
            if (xIMUserial.IsOpen)
            {
                SendReadRegisterForAllChildNodes(appendedTreeView_registers.SelectedNode);
            }
            else
            {
                MessageBox.Show("The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Context menu item click event to send a read register packet for the current selected tree node.
        /// </summary>
        private void regContextMenu_ItemClick_readThisOnly(object sender, EventArgs e)
        {
            x_IMU_API.RegisterData registerData = TreeNodeToRegisterData(appendedTreeView_registers.SelectedNode, true);
            SendReadRegister(registerData);
        }

        /// <summary>
        /// Sends a read register packet to device for each child node of a specified tree node.
        /// </summary>
        /// <param name="rootNode">
        /// Parent node of all nodes for which a read register packet will be sent.
        /// </param>
        private void SendReadRegisterForAllChildNodes(TreeNode rootNode)
        {
            foreach (TreeNode childNode in rootNode.Nodes)
            {
                x_IMU_API.RegisterData registerData = TreeNodeToRegisterData(childNode, true);
                SendReadRegister(registerData);
                if (childNode.Nodes.Count > 0) SendReadRegisterForAllChildNodes(childNode);   // apply to all child nodes recursively
            }
        }

        /// <summary>
        /// Sends a read register packet to device.  Exceptions shown message box.
        /// </summary>
        /// <param name="registerData">
        /// Register data object containing address of register to be read.  Register value ignored.
        /// </param>
        private void SendReadRegister(x_IMU_API.RegisterData registerData)
        {
            if (registerData != null)
            {
                try
                {
                    Thread.Sleep(5);                                        // delay to avoid overrunning the device receive buffer
                    xIMUserial.SendReadRegisterPacket(registerData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Register data received event to parse data to register tree view buffer.
        /// </summary>
        private void xIMUserial_RegisterDataReceived(object sender, x_IMU_API.RegisterData e)
        {
            treeViewRegisterDataBuffer[(int)e.Address] = e;
        }

        #endregion

        #region Write registers

        /// <summary>
        /// Context menu item click event to send a write register packet for nodes in the tree view.
        /// </summary>
        private void regContextMenu_ItemClick_writeAll(object sender, EventArgs e)
        {
            if (xIMUserial.IsOpen)
            {
                foreach (TreeNode rootNode in appendedTreeView_registers.Nodes)
                {
                    x_IMU_API.RegisterData registerData = TreeNodeToRegisterData(rootNode, false);
                    SendWriteRegister(registerData);
                    SendWriteRegisterForAllChildNodes(rootNode);
                }
            }
            else
            {
                MessageBox.Show("The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Context menu item click event to send a write register packet for all child nodes of the current selected tree node.
        /// </summary>
        private void regContextMenu_ItemClick_writAllThisGroupOnly(object sender, EventArgs e)
        {
            if (xIMUserial.IsOpen)
            {
                SendWriteRegisterForAllChildNodes(appendedTreeView_registers.SelectedNode);
            }
            else
            {
                MessageBox.Show("The port is closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Context menu item click event to send a write register packet for the current selected tree node.
        /// </summary>
        private void regContextMenu_ItemClick_writeThisOnly(object sender, EventArgs e)
        {
            x_IMU_API.RegisterData registerData = TreeNodeToRegisterData(appendedTreeView_registers.SelectedNode, false);
            SendWriteRegister(registerData);
        }

        /// <summary>
        /// Sends a write register packet to device.  Exceptions shown message box.
        /// </summary>
        /// <param name="rootNode">
        /// Parent node of all nodes for which a write register packet will be sent.
        /// </param>
        private void SendWriteRegisterForAllChildNodes(TreeNode rootNode)
        {
            foreach (TreeNode childNode in rootNode.Nodes)
            {
                x_IMU_API.RegisterData registerData = TreeNodeToRegisterData(childNode, false);
                SendWriteRegister(registerData);
                if (childNode.Nodes.Count > 0) SendWriteRegisterForAllChildNodes(childNode);    // apply to all child nodes recursively
            }
        }

        /// <summary>
        /// Sends a write register packet to device.  Exceptions shown message box.
        /// </summary>
        /// <param name="registerData">
        /// Register data object containing address and value of register to be written.
        /// </param>
        private void SendWriteRegister(x_IMU_API.RegisterData registerData)
        {
            if (registerData != null)
            {
                try
                {
                    Thread.Sleep(5);                                        // delay to avoid overrunning the device receive buffer
                    xIMUserial.SendWriteRegisterPacket(registerData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #endregion

        #region Register tree view data parsing

        /// <summary>
        /// Applies register data to associated tree node.
        /// </summary>
        /// <param name="registerData">
        /// Register data to be applied to associated tree node.
        /// </param> 
        private void RegisterDataToTreeNode(x_IMU_API.RegisterData registerData)
        {
            try
            {
                AppendedTreeNode treeNode = null;
                switch (registerData.Address)
                {
                    #region General

                    case ((ushort)x_IMU_API.RegisterAddresses.FirmVersionMajorNum): treeNode = appendedTreeNodeTextBox_firmVersionMajorNum; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString((ushort)registerData.Value); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.FirmVersionMinorNum): treeNode = appendedTreeNodeTextBox_firmVersionMinorNum; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString((ushort)registerData.Value); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.DeviceID): treeNode = appendedTreeNodeTextBox_deviceID; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = string.Format("{0:X4}", registerData.Value); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ButtonMode): treeNode = appendedTreeNodeComboBox_buttonMode; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;

                    #endregion

                    #region Sensor Calibration Parameters

                    case ((ushort)x_IMU_API.RegisterAddresses.BattSensitivity): treeNode = appendedTreeNodeTextBox_battSens; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.BattBias): treeNode = appendedTreeNodeTextBox_battBias; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ThermSensitivity): treeNode = appendedTreeNodeTextBox_thermSens; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ThermBias): treeNode = appendedTreeNodeTextBox_thermBias; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroFullScale): treeNode = appendedTreeNodeComboBox_gyroFullScale; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroSensitivityX): treeNode = appendedTreeNodeTextBox_gyroSensX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroSensitivityY): treeNode = appendedTreeNodeTextBox_gyroSensY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroSensitivityZ): treeNode = appendedTreeNodeTextBox_gyroSensZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroSampledPlus200dpsX): treeNode = appendedTreeNodeTextBox_gyroSampledPlus200dpsX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroSampledPlus200dpsY): treeNode = appendedTreeNodeTextBox_gyroSampledPlus200dpsY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroSampledPlus200dpsZ): treeNode = appendedTreeNodeTextBox_gyroSampledPlus200dpsZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroSampledMinus200dpsX): treeNode = appendedTreeNodeTextBox_gyroSampledMinus200dpsX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroSampledMinus200dpsY): treeNode = appendedTreeNodeTextBox_gyroSampledMinus200dpsY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroSampledMinus200dpsZ): treeNode = appendedTreeNodeTextBox_gyroSampledMinus200dpsZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;                   
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroBiasX): treeNode = appendedTreeNodeTextBox_gyroBiasX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroBiasY): treeNode = appendedTreeNodeTextBox_gyroBiasY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroBiasZ): treeNode = appendedTreeNodeTextBox_gyroBiasZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroBiasTempSensX): treeNode = appendedTreeNodeTextBox_gyroBiasTempSensX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroBiasTempSensY): treeNode = appendedTreeNodeTextBox_gyroBiasTempSensY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroBiasTempSensZ): treeNode = appendedTreeNodeTextBox_gyroBiasTempSensZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroSample1Temp): treeNode = appendedTreeNodeTextBox_gyroSample1Temp; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroSample1BiasX): treeNode = appendedTreeNodeTextBox_gyroSample1BiasX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroSample1BiasY): treeNode = appendedTreeNodeTextBox_gyroSample1BiasY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroSample1BiasZ): treeNode = appendedTreeNodeTextBox_gyroSample1BiasZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroSample2Temp): treeNode = appendedTreeNodeTextBox_gyroSample2Temp; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroSample2BiasX): treeNode = appendedTreeNodeTextBox_gyroSample2BiasX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroSample2BiasY): treeNode = appendedTreeNodeTextBox_gyroSample2BiasY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.GyroSample2BiasZ): treeNode = appendedTreeNodeTextBox_gyroSample2BiasZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AccelFullScale): treeNode = appendedTreeNodeComboBox_accelFullScale; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AccelSensitivityX): treeNode = appendedTreeNodeTextBox_accelSensX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AccelSensitivityY): treeNode = appendedTreeNodeTextBox_accelSensY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AccelSensitivityZ): treeNode = appendedTreeNodeTextBox_accelSensZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AccelBiasX): treeNode = appendedTreeNodeTextBox_accelBiasX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AccelBiasY): treeNode = appendedTreeNodeTextBox_accelBiasY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AccelBiasZ): treeNode = appendedTreeNodeTextBox_accelBiasZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AccelSampledPlus1gX): treeNode = appendedTreeNodeTextBox_accelSampledPlus1gX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;                
                    case ((ushort)x_IMU_API.RegisterAddresses.AccelSampledPlus1gY): treeNode = appendedTreeNodeTextBox_accelSampledPlus1gY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AccelSampledPlus1gZ): treeNode = appendedTreeNodeTextBox_accelSampledPlus1gZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AccelSampledMinus1gX): treeNode = appendedTreeNodeTextBox_accelSampledMinus1gX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AccelSampledMinus1gY): treeNode = appendedTreeNodeTextBox_accelSampledMinus1gY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AccelSampledMinus1gZ): treeNode = appendedTreeNodeTextBox_accelSampledMinus1gZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.MagFullScale): treeNode = appendedTreeNodeComboBox_magFullScale; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)x_IMU_API.RegisterAddresses.MagSensitivityX): treeNode = appendedTreeNodeTextBox_magSensX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.MagSensitivityY): treeNode = appendedTreeNodeTextBox_magSensY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.MagSensitivityZ): treeNode = appendedTreeNodeTextBox_magSensZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.MagBiasX): treeNode = appendedTreeNodeTextBox_magBiasX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.MagBiasY): treeNode = appendedTreeNodeTextBox_magBiasY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.MagBiasZ): treeNode = appendedTreeNodeTextBox_magBiasZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.MagHardIronBiasX): treeNode = appendedTreeNodeTextBox_magHIbiasX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.MagHardIronBiasY): treeNode = appendedTreeNodeTextBox_magHIbiasY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.MagHardIronBiasZ): treeNode = appendedTreeNodeTextBox_magHIbiasZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;

                    #endregion

                    #region Algorithm Parameters

                    case ((ushort)x_IMU_API.RegisterAddresses.AlgorithmMode): treeNode = appendedTreeNodeComboBox_algorithmMode; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AlgorithmKp): treeNode = appendedTreeNodeTextBox_algorithmGainKp; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AlgorithmKi): treeNode = appendedTreeNodeTextBox_algorithmGainKi; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AlgorithmInitKp): treeNode = appendedTreeNodeTextBox_algorithmInitKp; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AlgorithmInitPeriod): treeNode = appendedTreeNodeTextBox_algorithmInitPeriod; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AlgorithmMinValidMag): treeNode = appendedTreeNodeTextBox_algorithmMinValidMag; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AlgorithmMaxValidMag): treeNode = appendedTreeNodeTextBox_algorithmMaxValidMag; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AlgorithmTareQuat0): treeNode = appendedTreeNodeTextBoxtareQuatElement0; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AlgorithmTareQuat1): treeNode = appendedTreeNodeTextBoxtareQuatElement1; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AlgorithmTareQuat2): treeNode = appendedTreeNodeTextBoxtareQuatElement2; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AlgorithmTareQuat3): treeNode = appendedTreeNodeTextBoxtareQuatElement3; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;

                    #endregion

                    #region Data Output Settings

                    case ((ushort)x_IMU_API.RegisterAddresses.SensorDataMode): treeNode = appendedTreeNodeComboBox_sensorDataMode; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)x_IMU_API.RegisterAddresses.DateTimeOutputRate): treeNode = appendedTreeNodeComboBox_dateTimeOutputRate; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)x_IMU_API.RegisterAddresses.BattThermOutputRate): treeNode = appendedTreeNodeComboBox_battThermOutputRate; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)x_IMU_API.RegisterAddresses.InertialMagOutputRate): treeNode = appendedTreeNodeComboBox_inertialMagOutputRate; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)x_IMU_API.RegisterAddresses.QuatOutputRate): treeNode = appendedTreeNodeComboBox_quatOutputRate; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;

                    #endregion

                    #region SD Card

                    case ((ushort)x_IMU_API.RegisterAddresses.SDcardNewFileName): treeNode = appendedTreeNodeTextBox_SDcardNewFileName; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = string.Format("{0:D5}", (ushort)registerData.Value); break;

                    #endregion

                    #region Power Management

                    case ((ushort)x_IMU_API.RegisterAddresses.BattShutdownVoltage): treeNode = appendedTreeNodeComboBox_battShutdownVoltage; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.SleepTimer): treeNode = appendedTreeNodeTextBoxsleepTimer; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = (registerData.Value == 0 ? "Disabled" : Convert.ToString(registerData.Value)); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.MotionTrigWakeUp): treeNode = appendedTreeNodeComboBox_motionTriggeredWakeup; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)x_IMU_API.RegisterAddresses.BluetoothPower): treeNode = appendedTreeNodeComboBox_bluetoothPower; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;

                    #endregion

                    #region Auxiliary Port

                    case ((ushort)x_IMU_API.RegisterAddresses.AuxiliaryPortMode): treeNode = appendedTreeNodeComboBox_auxiliaryPortMode; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;

                    #region Digital I/O

                    case ((ushort)x_IMU_API.RegisterAddresses.DigitalIOdirection): treeNode = appendedTreeNodeComboBox_digitalIOdirection; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)x_IMU_API.RegisterAddresses.DigitalIOoutputRate): treeNode = appendedTreeNodeComboBox_digitalIOoutputRate; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;

                    #endregion

                    #region Analogue Input

                    case ((ushort)x_IMU_API.RegisterAddresses.AnalogueInputDataMode): treeNode = appendedTreeNodeComboBox_analogueInputDataMode; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AnalogueInputDataRate): treeNode = appendedTreeNodeComboBox_analogueInputDataRate; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AnalogueInputSensitivity): treeNode = appendedTreeNodeTextBox_analogueInputSensitivity; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.AnalogueInputBias): treeNode = appendedTreeNodeTextBox_analogueInputBias; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;

                    #endregion

                    #region PWM Output

                    case ((ushort)x_IMU_API.RegisterAddresses.PWMoutputFrequency): treeNode = appendedTreeNodeTextBox_PWMoutputFrequency; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.Value); break;

                    #endregion

                    #region ADXL345 Bus

                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345busDataMode): treeNode = appendedTreeNodeComboBox_ADXL345busDataMode; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345busDataRate): treeNode = appendedTreeNodeComboBox_ADXL345busDataRate; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345AsensitivityX): treeNode = appendedTreeNodeTextBox_ADXL345ASensX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345AsensitivityY): treeNode = appendedTreeNodeTextBox_ADXL345ASensY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345AsensitivityZ): treeNode = appendedTreeNodeTextBox_ADXL345ASensZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345AbiasX): treeNode = appendedTreeNodeTextBox_ADXL345AbiasX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345AbiasY): treeNode = appendedTreeNodeTextBox_ADXL345AbiasY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345AbiasZ): treeNode = appendedTreeNodeTextBox_ADXL345AbiasZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345BsensitivityX): treeNode = appendedTreeNodeTextBox_ADXL345BSensX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345BsensitivityY): treeNode = appendedTreeNodeTextBox_ADXL345BSensY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345BsensitivityZ): treeNode = appendedTreeNodeTextBox_ADXL345BSensZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345BbiasX): treeNode = appendedTreeNodeTextBox_ADXL345BbiasX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345BbiasY): treeNode = appendedTreeNodeTextBox_ADXL345BbiasY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345BbiasZ): treeNode = appendedTreeNodeTextBox_ADXL345BbiasZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345CsensitivityX): treeNode = appendedTreeNodeTextBox_ADXL345CSensX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345CsensitivityY): treeNode = appendedTreeNodeTextBox_ADXL345CSensY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345CsensitivityZ): treeNode = appendedTreeNodeTextBox_ADXL345CSensZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345CbiasX): treeNode = appendedTreeNodeTextBox_ADXL345CbiasX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345CbiasY): treeNode = appendedTreeNodeTextBox_ADXL345CbiasY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345CbiasZ): treeNode = appendedTreeNodeTextBox_ADXL345CbiasZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345DsensitivityX): treeNode = appendedTreeNodeTextBox_ADXL345DSensX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345DsensitivityY): treeNode = appendedTreeNodeTextBox_ADXL345DSensY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345DsensitivityZ): treeNode = appendedTreeNodeTextBox_ADXL345DSensZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345DbiasX): treeNode = appendedTreeNodeTextBox_ADXL345DbiasX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345DbiasY): treeNode = appendedTreeNodeTextBox_ADXL345DbiasY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)x_IMU_API.RegisterAddresses.ADXL345DbiasZ): treeNode = appendedTreeNodeTextBox_ADXL345DbiasZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;

                    #endregion

                    #endregion

                    default: throw new Exception("Specified register address does have an associated tree node.");
                }
                if (treeNode != null)
                {
                    treeNode.TextColor = Color.Blue;
                    if (treeNode == appendedTreeNodeTextBox_firmVersionMajorNum)    // Warning if device firmware is not listed as compatible
                    {
                        if (!Enum.IsDefined(typeof(x_IMU_API.CompatibleFirmwareVersions), Convert.ToInt32(appendedTreeNodeTextBox_firmVersionMajorNum.TextBox.Text)))
                        {
                            PassiveMessageBox.Show("The detected x-IMU firmware version is not fully compatible with this version of the x-IMU GUI and API.\r\n\r\n" +
                                                   "Please download and install the latest x-IMU software and firmware available at: www.x-io.co.uk.", "Warning", MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch
            {
                PassiveMessageBox.Show("Invalid register address (0x" + string.Format("{0:X4}", registerData.Address) + ") and/or value (0x" + string.Format("{0:X4}", registerData.Value) + ")", "Error", MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Returns a register data object representing data from specified tree node.  Exceptions shown message box with tree node label text.
        /// </summary>
        /// <param name="treeNode">
        /// Tree node representing desired register data.
        /// </param>
        /// <param name="addressOnly">
        /// Return register address only if true.
        /// </param> 
        /// <returns>
        /// Register data object representing data from specified tree node.  A null object is returned for unhandled tree nodes.
        /// </returns>
        private x_IMU_API.RegisterData TreeNodeToRegisterData(TreeNode treeNode, bool addressOnly)
        {
            x_IMU_API.RegisterData registerData = new x_IMU_API.RegisterData();
            try
            {
                #region General

                if (treeNode.Equals(appendedTreeNodeTextBox_firmVersionMajorNum)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.FirmVersionMajorNum; if (!addressOnly) registerData = null; }         // return null for read-only register
                else if (treeNode.Equals(appendedTreeNodeTextBox_firmVersionMinorNum)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.FirmVersionMinorNum; if (!addressOnly) registerData = null; }    // return null for read-only register
                else if (treeNode.Equals(appendedTreeNodeTextBox_deviceID)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.DeviceID; if (!addressOnly) registerData = null; }                          // return null for read-only register
                else if (treeNode.Equals(appendedTreeNodeComboBox_buttonMode)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ButtonMode; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_buttonMode.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }

                #endregion

                #region Sensor Calibration Parameters

                else if (treeNode.Equals(appendedTreeNodeTextBox_battSens)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.BattSensitivity; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_battSens.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_battBias)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.BattBias; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_battBias.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_thermSens)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ThermSensitivity; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_thermSens.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_thermBias)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ThermBias; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_thermBias.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeComboBox_gyroFullScale)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroFullScale; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_gyroFullScale.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroSensX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroSensitivityX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroSensX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroSensY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroSensitivityY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroSensY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroSensZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroSensitivityZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroSensZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroSampledPlus200dpsX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroSampledPlus200dpsX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroSampledPlus200dpsX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroSampledPlus200dpsY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroSampledPlus200dpsY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroSampledPlus200dpsY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroSampledPlus200dpsZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroSampledPlus200dpsZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroSampledPlus200dpsZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroSampledMinus200dpsX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroSampledMinus200dpsX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroSampledMinus200dpsX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroSampledMinus200dpsY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroSampledMinus200dpsY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroSampledMinus200dpsY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroSampledMinus200dpsZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroSampledMinus200dpsZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroSampledMinus200dpsZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroBiasX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroBiasX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroBiasX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroBiasY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroBiasY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroBiasY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroBiasZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroBiasZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroBiasZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroBiasTempSensX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroBiasTempSensX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroBiasTempSensX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroBiasTempSensY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroBiasTempSensY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroBiasTempSensY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroBiasTempSensZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroBiasTempSensZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroBiasTempSensZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroSample1Temp)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroSample1Temp; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroSample1Temp.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroSample1BiasX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroSample1BiasX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroSample1BiasX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroSample1BiasY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroSample1BiasY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroSample1BiasY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroSample1BiasZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroSample1BiasZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroSample1BiasZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroSample2Temp)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroSample2Temp; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroSample2Temp.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroSample2BiasX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroSample2BiasX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroSample2BiasX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroSample2BiasY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroSample2BiasY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroSample2BiasY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_gyroSample2BiasZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.GyroSample2BiasZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_gyroSample2BiasZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeComboBox_accelFullScale)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AccelFullScale; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_accelFullScale.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTreeNodeTextBox_accelSensX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AccelSensitivityX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_accelSensX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_accelSensY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AccelSensitivityY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_accelSensY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_accelSensZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AccelSensitivityZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_accelSensZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_accelBiasX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AccelBiasX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_accelBiasX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_accelBiasY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AccelBiasY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_accelBiasY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_accelBiasZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AccelBiasZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_accelBiasZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_accelSampledPlus1gX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AccelSampledPlus1gX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_accelSampledPlus1gX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_accelSampledPlus1gY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AccelSampledPlus1gY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_accelSampledPlus1gY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_accelSampledPlus1gZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AccelSampledPlus1gZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_accelSampledPlus1gZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_accelSampledMinus1gX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AccelSampledMinus1gX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_accelSampledMinus1gX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_accelSampledMinus1gY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AccelSampledMinus1gY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_accelSampledMinus1gY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_accelSampledMinus1gZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AccelSampledMinus1gZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_accelSampledMinus1gZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeComboBox_magFullScale)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.MagFullScale; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_magFullScale.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTreeNodeTextBox_magSensX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.MagSensitivityX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_magSensX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_magSensY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.MagSensitivityY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_magSensY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_magSensZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.MagSensitivityZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_magSensZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_magBiasX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.MagBiasX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_magBiasX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_magBiasY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.MagBiasY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_magBiasY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_magBiasZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.MagBiasZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_magBiasZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_magHIbiasX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.MagHardIronBiasX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_magHIbiasX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_magHIbiasY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.MagHardIronBiasY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_magHIbiasY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_magHIbiasZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.MagHardIronBiasZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_magHIbiasZ.TextBox.Text); }

                #endregion

                #region Algorithm Parameters

                else if (treeNode.Equals(appendedTreeNodeComboBox_algorithmMode)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AlgorithmMode; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_algorithmMode.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTreeNodeTextBox_algorithmGainKp)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AlgorithmKp; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_algorithmGainKp.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_algorithmGainKi)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AlgorithmKi; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_algorithmGainKi.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_algorithmInitKp)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AlgorithmInitKp; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_algorithmInitKp.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_algorithmInitPeriod)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AlgorithmInitPeriod; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_algorithmInitPeriod.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_algorithmMinValidMag)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AlgorithmMinValidMag; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_algorithmMinValidMag.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_algorithmMaxValidMag)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AlgorithmMaxValidMag; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_algorithmMaxValidMag.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBoxtareQuatElement0)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AlgorithmTareQuat0; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBoxtareQuatElement0.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBoxtareQuatElement1)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AlgorithmTareQuat1; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBoxtareQuatElement1.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBoxtareQuatElement2)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AlgorithmTareQuat2; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBoxtareQuatElement2.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBoxtareQuatElement3)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AlgorithmTareQuat3; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBoxtareQuatElement3.TextBox.Text); }

                #endregion

                #region Data Output Settings

                else if (treeNode.Equals(appendedTreeNodeComboBox_sensorDataMode)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.SensorDataMode; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_sensorDataMode.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTreeNodeComboBox_dateTimeOutputRate)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.DateTimeOutputRate; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_dateTimeOutputRate.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTreeNodeComboBox_battThermOutputRate)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.BattThermOutputRate; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_battThermOutputRate.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTreeNodeComboBox_inertialMagOutputRate)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.InertialMagOutputRate; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_inertialMagOutputRate.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTreeNodeComboBox_quatOutputRate)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.QuatOutputRate; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_quatOutputRate.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }

                #endregion

                #region SD Card

                else if (treeNode.Equals(appendedTreeNodeTextBox_SDcardNewFileName)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.SDcardNewFileName; if (!addressOnly) registerData.Value = Convert.ToUInt16(appendedTreeNodeTextBox_SDcardNewFileName.TextBox.Text); }

                #endregion

                #region Power Management

                else if (treeNode.Equals(appendedTreeNodeComboBox_battShutdownVoltage)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.BattShutdownVoltage; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeComboBox_battShutdownVoltage.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBoxsleepTimer)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.SleepTimer; if (!addressOnly) { string text = appendedTreeNodeTextBoxsleepTimer.TextBox.Text; registerData.Value = (string.Equals(text, "Disabled", StringComparison.CurrentCultureIgnoreCase) ? (ushort)0 : Convert.ToUInt16(text)); } }
                else if (treeNode.Equals(appendedTreeNodeComboBox_motionTriggeredWakeup)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.MotionTrigWakeUp; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_motionTriggeredWakeup.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTreeNodeComboBox_bluetoothPower)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.BluetoothPower; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_bluetoothPower.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }

                #endregion

                #region Auxiliary Port

                else if (treeNode.Equals(appendedTreeNodeComboBox_auxiliaryPortMode)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AuxiliaryPortMode; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_auxiliaryPortMode.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }

                #region Digital I/O

                else if (treeNode.Equals(appendedTreeNodeComboBox_digitalIOdirection)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.DigitalIOdirection; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_digitalIOdirection.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTreeNodeComboBox_digitalIOoutputRate)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.DigitalIOoutputRate; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_digitalIOoutputRate.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }

                #endregion

                #region Analogue Input

                else if (treeNode.Equals(appendedTreeNodeComboBox_analogueInputDataMode)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AnalogueInputDataMode; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_analogueInputDataMode.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTreeNodeComboBox_analogueInputDataRate)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AnalogueInputDataRate; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_analogueInputDataRate.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTreeNodeTextBox_analogueInputSensitivity)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AnalogueInputSensitivity; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_analogueInputSensitivity.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_analogueInputBias)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.AnalogueInputBias; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_analogueInputBias.TextBox.Text); }

                #endregion

                #region PWM Output

                else if (treeNode.Equals(appendedTreeNodeTextBox_PWMoutputFrequency)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.PWMoutputFrequency; if (!addressOnly) registerData.Value = Convert.ToUInt16(appendedTreeNodeTextBox_PWMoutputFrequency.TextBox.Text); }

                #endregion

                #region ADXL345 Bus

                else if (treeNode.Equals(appendedTreeNodeComboBox_ADXL345busDataMode)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345busDataMode; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_ADXL345busDataMode.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTreeNodeComboBox_ADXL345busDataRate)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345busDataRate; if (!addressOnly) { int selectedIndex = (int)appendedTreeNodeComboBox_ADXL345busDataRate.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345ASensX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345AsensitivityX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345ASensX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345ASensY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345AsensitivityY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345ASensY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345ASensZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345AsensitivityZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345ASensZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345AbiasX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345AbiasX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345AbiasX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345AbiasY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345AbiasY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345AbiasY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345AbiasZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345AbiasZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345AbiasZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345BSensX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345BsensitivityX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345BSensX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345BSensY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345BsensitivityY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345BSensY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345BSensZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345BsensitivityZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345BSensZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345BbiasX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345BbiasX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345BbiasX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345BbiasY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345BbiasY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345BbiasY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345BbiasZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345BbiasZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345BbiasZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345CSensX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345CsensitivityX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345CSensX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345CSensY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345CsensitivityY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345CSensY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345CSensZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345CsensitivityZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345CSensZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345CbiasX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345CbiasX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345CbiasX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345CbiasY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345CbiasY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345CbiasY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345CbiasZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345CbiasZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345CbiasZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345DSensX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345DsensitivityX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345DSensX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345DSensY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345DsensitivityY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345DSensY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345DSensZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345DsensitivityZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345DSensZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345DbiasX)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345DbiasX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345DbiasX.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345DbiasY)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345DbiasY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345DbiasY.TextBox.Text); }
                else if (treeNode.Equals(appendedTreeNodeTextBox_ADXL345DbiasZ)) { registerData.Address = (ushort)x_IMU_API.RegisterAddresses.ADXL345DbiasZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTreeNodeTextBox_ADXL345DbiasZ.TextBox.Text); }

                #endregion

                #endregion

                else registerData = null;
            }
            catch (Exception ex)
            {
                TreeNode tempTreeNode = treeNode.Parent;
                string breadcrumb = treeNode.ToString().Substring("TreeNode: ".Length, treeNode.ToString().Length - "TreeNode: ".Length);
                do
                {
                    breadcrumb = tempTreeNode.ToString().Substring("TreeNode: ".Length, tempTreeNode.ToString().Length - "TreeNode: ".Length) + " > " + breadcrumb;
                    tempTreeNode = tempTreeNode.Parent;
                } while (tempTreeNode != null);
                MessageBox.Show(ex.Message + "\r\r" + breadcrumb, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                registerData = null;
            }
            return registerData;
        }

        #endregion

        #endregion

        #region Date/Time

        /// <summary>
        /// Button click event to set data/time to PC date/time.
        /// </summary>
        private void button_setDateTime_Click(object sender, EventArgs e)
        {
            try
            {
                xIMUserial.SendWriteDateTimePacket(new x_IMU_API.DateTimeData(DateTime.Now));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Button click event to read date/time.
        /// </summary>
        private void button_readDateTime_Click(object sender, EventArgs e)
        {
            try
            {
                xIMUserial.SendReadDateTimePacket();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Date/Time data received event to display data in form and write to file.
        /// </summary>
        private void xIMUserial_DateTimeDataReceived(object sender, x_IMU_API.DateTimeData e)
        {
            dateTimeData = e;
        }

        #endregion

        #region Commands

        /// <summary>
        /// Sends command packet to factory reset.
        /// </summary>
        private void button_factoryReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Factory reset will set all registers to default values and all current calibration parameters will be lost.\r\n\r\n" +
                                "Press button on x-IMU after sending this command to confirm.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                SendCommandPacket(x_IMU_API.CommandCodes.FactoryReset);
            }
        }

        /// <summary>
        /// Sends command packet to reset device.
        /// </summary>
        private void button_reset_Click(object sender, EventArgs e)
        {
            SendCommandPacket(x_IMU_API.CommandCodes.Reset);
        }

        /// <summary>
        /// Sends command packet to sleep device.
        /// </summary>
        private void button_sleep_Click(object sender, EventArgs e)
        {
            SendCommandPacket(x_IMU_API.CommandCodes.Sleep);
        }

        /// <summary>
        /// Sends command packet to reset sleep timer.
        /// </summary>
        private void button_resetSleepTimer_Click(object sender, EventArgs e)
        {
            SendCommandPacket(x_IMU_API.CommandCodes.ResetSleepTimer);
        }

        /// <summary>
        /// Sends command packet to sample gyroscope axes at ±1 200 dps.
        /// </summary>
        private void button_sampleGyroAt200dps_Click(object sender, EventArgs e)
        {
            SendCommandPacket(x_IMU_API.CommandCodes.SampleGyroscopeAxisAt200dps);
        }

        /// <summary>
        /// Sends command packet to calculate gyroscope sensitivity.
        /// </summary>
        private void button_calculateGyroSensitivity_Click(object sender, EventArgs e)
        {
            SendCommandPacket(x_IMU_API.CommandCodes.CalcGyroscopeSensitivity);
        }

        /// <summary>
        /// Sends command packet to sample gyroscope bias at temperature 1.
        /// </summary>
        private void button_sampleGyroBiasAtT1_Click(object sender, EventArgs e)
        {
            SendCommandPacket(x_IMU_API.CommandCodes.SampleGyroscopeBiasTemp1);
        }

        /// <summary>
        /// Sends command packet to sample gyroscope bias at temperature 2.
        /// </summary>
        private void button_sampleGyroBiasAtT2_Click(object sender, EventArgs e)
        {
            SendCommandPacket(x_IMU_API.CommandCodes.SampleGyroscopeBiasTemp2);
        }

        /// <summary>
        /// Sends command packet to sample calculate gyroscope bias parameters.
        /// </summary>
        private void button_calcGyroBiasParameters_Click(object sender, EventArgs e)
        {
            SendCommandPacket(x_IMU_API.CommandCodes.CalcGyroscopeBiasParameters);
        }

        /// <summary>
        /// Sends command packet to sample accelerometer axis value at ±1 g.
        /// </summary>
        private void button_lookupAccelSensitivity_Click(object sender, EventArgs e)
        {
            SendCommandPacket(x_IMU_API.CommandCodes.SampleAccelerometerAxisAt1g);
        }

        /// <summary>
        /// Sends command packet to calculate accelerometer bias and sensitivity.
        /// </summary>
        private void button_calcAccelBiasSens_Click(object sender, EventArgs e)
        {
            SendCommandPacket(x_IMU_API.CommandCodes.CalcAccelerometerBiasAndSens);
        }

        /// <summary>
        /// Sends command packet to measure magnetometer bias and sensitivity.
        /// </summary>
        private void button_measMagBiasSens_Click(object sender, EventArgs e)
        {
            SendCommandPacket(x_IMU_API.CommandCodes.MeasureMagnetometerBiasAndSens);
        }

        /// <summary>
        /// Sends command packet to reset algorithm.
        /// </summary>
        private void button_initialise_Click(object sender, EventArgs e)
        {
            SendCommandPacket(x_IMU_API.CommandCodes.AlgorithmInitialise);
        }

        /// <summary>
        /// Sends command packet to tare.
        /// </summary>
        private void button_tare_Click(object sender, EventArgs e)
        {
            SendCommandPacket(x_IMU_API.CommandCodes.AlgorithmTare);
        }

        /// <summary>
        /// Sends command packet to clear tare.
        /// </summary>
        private void button_clearTare_Click(object sender, EventArgs e)
        {
            SendCommandPacket(x_IMU_API.CommandCodes.AlgorithmClearTare);
        }

        /// <summary>
        /// Sends command packet to clear initialise then tare.
        /// </summary>
        private void button_initialiseThenTare_Click(object sender, EventArgs e)
        {
            SendCommandPacket(x_IMU_API.CommandCodes.AlgorithmInitialiseThenTare);
        }

        /// <summary>
        /// Sends a command packet to device.  Exceptions shown message box.
        /// </summary>
        /// <param name="commandCode">
        /// Command code to be sent.
        /// </param>
        private void SendCommandPacket(x_IMU_API.CommandCodes commandCode)
        {
            try
            {
                xIMUserial.SendCommandPacket(commandCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Command message received event to display message in message box.
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

        #region Show/hide sensor data graphics

        /// <summary>
        /// Toggles the show/hide state of the battery voltmeter graph.
        /// </summary>
        private void button_showBatteryGraph_Click(object sender, EventArgs e)
        {
            if (button_showBatteryGraph.Text == "Show Battery Graph")
            {
                button_showBatteryGraph.Text = "Hide Battery Graph";
                battOscilloscope.ShowScope();
            }
            else
            {
                button_showBatteryGraph.Text = "Show Battery Graph";
                battOscilloscope.HideScope();
            }
        }

        /// <summary>
        /// Toggles the show/hide state of the thermometer graph.
        /// </summary>
        private void button_showThermGraph_Click(object sender, EventArgs e)
        {
            if (button_showThermGraph.Text == "Show Thermometer Graph")
            {
                button_showThermGraph.Text = "Hide Thermometer Graph";
                thermOscilloscope.ShowScope();
            }
            else
            {
                button_showThermGraph.Text = "Show Thermometer Graph";
                thermOscilloscope.HideScope();
            }
        }

        /// <summary>
        /// Toggles the show/hide state of the gyroscope graph.
        /// </summary>
        private void button_showGyroGraph_Click(object sender, EventArgs e)
        {
            if (button_showGyroGraph.Text == "Show Gyroscope Graph")
            {
                button_showGyroGraph.Text = "Hide Gyroscope Graph";
                gyroOscilloscope.ShowScope();
            }
            else
            {
                button_showGyroGraph.Text = "Show Gyroscope Graph";
                gyroOscilloscope.HideScope();
            }
        }

        /// <summary>
        /// Toggles the show/hide state of the accelerometer graph.
        /// </summary>
        private void button_showAccelGraph_Click(object sender, EventArgs e)
        {
            if (button_showAccelGraph.Text == "Show Accelerometer Graph")
            {
                button_showAccelGraph.Text = "Hide Accelerometer Graph";
                accelOscilloscope.ShowScope();
            }
            else
            {
                button_showAccelGraph.Text = "Show Accelerometer Graph";
                accelOscilloscope.HideScope();
            }
        }

        /// <summary>
        /// Toggles the show/hide state of the magnetometer graph.
        /// </summary>
        private void button_showMagGraph_Click(object sender, EventArgs e)
        {
            if (button_showMagGraph.Text == "Show Magnetometer Graph")
            {
                button_showMagGraph.Text = "Hide Magnetometer Graph";
                magOscilloscope.ShowScope();
            }
            else
            {
                button_showMagGraph.Text = "Show Magnetometer Graph";
                magOscilloscope.HideScope();
            }
        }

        /// <summary>
        /// Toggles the show/hide state of the Euler angle graph.
        /// </summary>
        private void button_showEulerAngleGraph_Click(object sender, EventArgs e)
        {
            if (button_showEulerAngleGraph.Text == "Show Euler Angle Graph")
            {
                button_showEulerAngleGraph.Text = "Hide Euler Angle Graph";
                eulerOscilloscope.ShowScope();
            }
            else
            {
                button_showEulerAngleGraph.Text = "Show Euler Angle Graph";
                eulerOscilloscope.HideScope();
            }
        }

        /// <summary>
        /// Toggles the show/hide state of the 3D cuboid graphics form.
        /// </summary>
        private void button_show3Dcuboid_Click(object sender, EventArgs e)
        {
            if (button_show3Dcuboid.Text == "Show 3D Cuboid")
            {
                button_show3Dcuboid.Text = "Hide 3D Cuboid";
                cuboid3D.Show();
            }
            else
            {
                button_show3Dcuboid.Text = "Show 3D Cuboid";
                cuboid3D.Hide();
            }
        }

        #endregion

        #region Sensor data received events

        /// <summary>
        /// Raw battery and thermometer data received event to update oscilloscope.
        /// </summary>
        private void xIMUserial_RawBattThermDataReceived(object sender, x_IMU_API.RawBattThermData e)
        {
            battOscilloscope.AddScopeData(e.BatteryVoltage, 0.0, 0.0);
            thermOscilloscope.AddScopeData(e.Thermometer, 0.0, 0.0);
        }

        /// <summary>
        /// Calibrated battery and thermometer data received event to update oscilloscope..
        /// </summary>
        private void xIMUserial_CalBattThermDataReceived(object sender, x_IMU_API.CalBattThermData e)
        {
            battOscilloscope.AddScopeData(e.BatteryVoltage, 0.0, 0.0);
            thermOscilloscope.AddScopeData(e.Thermometer, 0.0, 0.0);
        }

        /// <summary>
        /// Raw inertial and magnetic data received event to update oscilloscope.
        /// </summary>
        private void xIMUserial_RawInertialMagDataReceived(object sender, x_IMU_API.RawInertialMagData e)
        {
            gyroOscilloscope.AddScopeData(e.Gyroscope[0], e.Gyroscope[1], e.Gyroscope[2]);
            accelOscilloscope.AddScopeData(e.Accelerometer[0], e.Accelerometer[1], e.Accelerometer[2]);
            magOscilloscope.AddScopeData(e.Magnetometer[0], e.Magnetometer[1], e.Magnetometer[2]);
        }

        /// <summary>
        /// Calibrated inertial and magnetic data received event to update oscilloscope.
        /// </summary>
        private void xIMUserial_CalInertialMagDataReceived(object sender, x_IMU_API.CalInertialMagData e)
        {
            gyroOscilloscope.AddScopeData(e.Gyroscope[0], e.Gyroscope[1], e.Gyroscope[2]);
            accelOscilloscope.AddScopeData(e.Accelerometer[0], e.Accelerometer[1], e.Accelerometer[2]);
            magOscilloscope.AddScopeData(e.Magnetometer[0], e.Magnetometer[1], e.Magnetometer[2]);
        }

        /// <summary>
        /// Quaternion data received event to update oscilloscope and 3D graphics.
        /// </summary>
        private void xIMUserial_QuaternionDataReceived(object sender, x_IMU_API.QuaternionData e)
        {
            float[] euler = e.ConvertToEulerAngles();
            eulerOscilloscope.AddScopeData(euler[0], euler[1], euler[2]);
            cuboid3D.RotationMatrix = e.ConvertToRotationMatrix();
        }

        #endregion

        #endregion

        #region Auxiliary port

        #region Digital I/O

        /// <summary>
        /// Toggles the show/hide state of the digital I/O panel.
        /// </summary>
        private void button_showDigitalIOpanel_Click(object sender, EventArgs e)
        {
            if (button_showDigitalIOpanel.Text == "Show Digital I/O Panel")
            {
                button_showDigitalIOpanel.Text = "Hide Digital I/O Panel";
                digitalIOpanel.Show();
            }
            else
            {
                button_showDigitalIOpanel.Text = "Show Digital I/O Panel";
                digitalIOpanel.Hide();
            }
        }

        /// <summary>
        /// Digital I/O panel state changed event to send digital I/O packet to x-IMU. Exceptions shown message box.
        /// </summary>
        private void digitalIOpanel_OutputChanged(object sender, x_IMU_API.DigitalPortBits e)
        {
            try
            {
                xIMUserial.SendDigitalIOPacket(new x_IMU_API.DigitalIOdata(e));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Digital I/O data received event to display data in form.
        /// </summary>
        private void xIMUserial_DigitalIODataReceived(object sender, x_IMU_API.DigitalIOdata e)
        {
            digitalIOpanel.Direction = e.Direction;
            digitalIOpanel.State = e.State;
        }

        #endregion

        #region Analogue Input

        /// <summary>
        /// Toggles the show/hide state of the analogue input AX0 and AX1 graph.
        /// </summary>
        private void button_showAX0andAX1graph_Click(object sender, EventArgs e)
        {
            if (button_showAX0andAX1graph.Text == "Show AX0 and AX1 Graph")
            {
                button_showAX0andAX1graph.Text = "Hide AX0 and AX1 Graph";
                AnalogueInputAX0AX1oscilloscope.ShowScope();
            }
            else
            {
                button_showAX0andAX1graph.Text = "Show AX0 and AX1 Graph";
                AnalogueInputAX0AX1oscilloscope.HideScope();
            }
        }

        /// <summary>
        /// Toggles the show/hide state of the analogue input AX2 and AX3 graph.
        /// </summary>
        private void button_showAX2andAX3graph_Click(object sender, EventArgs e)
        {
            if (button_showAX2andAX3graph.Text == "Show AX2 and AX3 Graph")
            {
                button_showAX2andAX3graph.Text = "Hide AX2 and AX3 Graph";
                AnalogueInputAX2AX3oscilloscope.ShowScope();
            }
            else
            {
                button_showAX2andAX3graph.Text = "Show AX2 and AX3 Graph";
                AnalogueInputAX2AX3oscilloscope.HideScope();
            }
        }

        /// <summary>
        /// Toggles the show/hide state of the analogue input AX4 and AX5 graph.
        /// </summary>
        private void button_showAX4andAX5graph_Click(object sender, EventArgs e)
        {
            if (button_showAX4andAX5graph.Text == "Show AX4 and AX5 Graph")
            {
                button_showAX4andAX5graph.Text = "Hide AX4 and AX5 Graph";
                AnalogueInputAX4AX5oscilloscope.ShowScope();
            }
            else
            {
                button_showAX4andAX5graph.Text = "Show AX4 and AX5 Graph";
                AnalogueInputAX4AX5oscilloscope.HideScope();
            }
        }

        /// <summary>
        /// Toggles the show/hide state of the analogue input AX6 and AX7 graph.
        /// </summary>
        private void button_showAX6andAX7graph_Click(object sender, EventArgs e)
        {
            if (button_showAX6andAX7graph.Text == "Show AX6 and AX7 Graph")
            {
                button_showAX6andAX7graph.Text = "Hide AX6 and AX7 Graph";
                AnalogueInputAX6AX7oscilloscope.ShowScope();
            }
            else
            {
                button_showAX6andAX7graph.Text = "Show AX6 and AX7 Graph";
                AnalogueInputAX6AX7oscilloscope.HideScope();
            }
        }

        /// <summary>
        /// Raw analogue input data received event to update oscilloscope.
        /// </summary>
        void xIMUserial_RawAnalogueInputDataReceived(object sender, x_IMU_API.RawAnalogueInputData e)
        {
            AnalogueInputAX0AX1oscilloscope.AddScopeData(e.AX0, e.AX1, 0.0f);
            AnalogueInputAX2AX3oscilloscope.AddScopeData(e.AX2, e.AX3, 0.0f);
            AnalogueInputAX4AX5oscilloscope.AddScopeData(e.AX4, e.AX5, 0.0f);
            AnalogueInputAX6AX7oscilloscope.AddScopeData(e.AX6, e.AX7, 0.0f);
        }

        /// <summary>
        /// Calibrated analogue input data received event to update oscilloscope.
        /// </summary>
        void xIMUserial_CalAnalogueInputDataReceived(object sender, x_IMU_API.CalAnalogueInputData e)
        {
            AnalogueInputAX0AX1oscilloscope.AddScopeData(e.AX0, e.AX1, 0.0f);
            AnalogueInputAX2AX3oscilloscope.AddScopeData(e.AX2, e.AX3, 0.0f);
            AnalogueInputAX4AX5oscilloscope.AddScopeData(e.AX4, e.AX5, 0.0f);
            AnalogueInputAX6AX7oscilloscope.AddScopeData(e.AX6, e.AX7, 0.0f);
        }

        #endregion

        #region PWM output

        /// <summary>
        /// Toggles the show/hide state of the PWM output panel.
        /// </summary>
        private void button_showPWMoutputPanel_Click(object sender, EventArgs e)
        {
            if (button_showPWMoutputPanel.Text == "Show PWM Output Panel")
            {
                button_showPWMoutputPanel.Text = "Hide PWM Output Panel";
                PWMoutputPanel.Show();
            }
            else
            {
                button_showPWMoutputPanel.Text = "Show PWM Output Panel";
                PWMoutputPanel.Hide();
            }
        }

        /// <summary>
        /// PWM duty cycle changed event to send PWM output packet to x-IMU. Exceptions shown message box.
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
        /// PWM output data received event to display data in PWM output panel.
        /// </summary>
        void xIMUserial_PWMoutputDataReceived(object sender, x_IMU_API.PWMoutputData e)
        {
            PWMoutputPanel.AX0 = e.AX0;
            PWMoutputPanel.AX2 = e.AX2;
            PWMoutputPanel.AX4 = e.AX4;
            PWMoutputPanel.AX6 = e.AX6;
        }

        #endregion

        #region ADXL345 bus

        /// <summary>
        /// Toggles the show/hide state of the ADXL345 A graph.
        /// </summary>
        private void button_showADXL345Agraph_Click(object sender, EventArgs e)
        {
            if (button_showADXL345Agraph.Text == "Show ADXL345 A Graph")
            {
                button_showADXL345Agraph.Text = "Hide ADXL345 A Graph";
                _ADXL345_Aoscilloscope.ShowScope();
            }
            else
            {
                button_showADXL345Agraph.Text = "Show ADXL345 A Graph";
                _ADXL345_Aoscilloscope.HideScope();
            }
        }

        /// <summary>
        /// Toggles the show/hide state of the ADXL345 B graph.
        /// </summary>
        private void button_showADXL345Bgraph_Click(object sender, EventArgs e)
        {
            if (button_showADXL345Bgraph.Text == "Show ADXL345 B Graph")
            {
                button_showADXL345Bgraph.Text = "Hide ADXL345 B Graph";
                _ADXL345_Boscilloscope.ShowScope();
            }
            else
            {
                button_showADXL345Bgraph.Text = "Show ADXL345 B Graph";
                _ADXL345_Boscilloscope.HideScope();
            }
        }

        /// <summary>
        /// Toggles the show/hide state of the ADXL345 C graph.
        /// </summary>
        private void button_showADXL345Cgraph_Click(object sender, EventArgs e)
        {
            if (button_showADXL345Cgraph.Text == "Show ADXL345 C Graph")
            {
                button_showADXL345Cgraph.Text = "Hide ADXL345 C Graph";
                _ADXL345_Coscilloscope.ShowScope();
            }
            else
            {
                button_showADXL345Cgraph.Text = "Show ADXL345 C Graph";
                _ADXL345_Coscilloscope.HideScope();
            }
        }

        /// <summary>
        /// Toggles the show/hide state of the ADXL345 D graph.
        /// </summary>
        private void button_showADXL345Dgraph_Click(object sender, EventArgs e)
        {
            if (button_showADXL345Dgraph.Text == "Show ADXL345 D Graph")
            {
                button_showADXL345Dgraph.Text = "Hide ADXL345 D Graph";
                _ADXL345_Doscilloscope.ShowScope();
            }
            else
            {
                button_showADXL345Dgraph.Text = "Show ADXL345 D Graph";
                _ADXL345_Doscilloscope.HideScope();
            }
        }

        /// <summary>
        /// Raw ADXL345 bus data received event to update oscilloscope.
        /// </summary>
        void xIMUserial_RawADXL345busDataReceived(object sender, x_IMU_API.RawADXL345busData e)
        {
            _ADXL345_Aoscilloscope.AddScopeData(e.ADXL345_A[0], e.ADXL345_A[1], e.ADXL345_A[2]);
            _ADXL345_Boscilloscope.AddScopeData(e.ADXL345_B[0], e.ADXL345_B[1], e.ADXL345_B[2]);
            _ADXL345_Coscilloscope.AddScopeData(e.ADXL345_C[0], e.ADXL345_C[1], e.ADXL345_C[2]);
            _ADXL345_Doscilloscope.AddScopeData(e.ADXL345_D[0], e.ADXL345_D[1], e.ADXL345_D[2]);
        }

        /// <summary>
        /// Calibrated ADXL345 bus data received event to update oscilloscope.
        /// </summary>
        void xIMUserial_CalADXL345busDataReceived(object sender, x_IMU_API.CalADXL345busData e)
        {
            _ADXL345_Aoscilloscope.AddScopeData(e.ADXL345_A[0], e.ADXL345_A[1], e.ADXL345_A[2]);
            _ADXL345_Boscilloscope.AddScopeData(e.ADXL345_B[0], e.ADXL345_B[1], e.ADXL345_B[2]);
            _ADXL345_Coscilloscope.AddScopeData(e.ADXL345_C[0], e.ADXL345_C[1], e.ADXL345_C[2]);
            _ADXL345_Doscilloscope.AddScopeData(e.ADXL345_D[0], e.ADXL345_D[1], e.ADXL345_D[2]);
        }

        #endregion

        #endregion

        #region Data logger

        /// <summary>
        /// Opens file navigation form to define file path for logged data.
        /// </summary>
        private void button_dataLoggerFilePathBrowse_Click(object sender, EventArgs e)
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
        /// Button click event to toggle the internal data logging flag.
        /// </summary>
        /// <remarks>
        /// File writing/creation is handled in each data reception events.
        /// </remarks>
        private void button_dataLoggerStart_Click(object sender, EventArgs e)
        {
            if (button_dataLoggerStart.Text == "Start Logging")
            {
                try
                {
                    dataLoggerStartPacketCount = new x_IMU_API.PacketCount(xIMUserial.PacketCounter);
                    dataLoggerFiles = new x_IMU_API.CSVfileWriter(textBox_dataLoggerFilePath.Text);
                    button_dataLoggerStart.Text = "Stop Logging";
                    textBox_dataLoggerFilePath.Enabled = false;
                    button_dataLoggerFilePathBrowse.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("Invalid file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (button_dataLoggerStart.Text == "Stop Logging")
            {
                ShowDataLoggerReport(xIMUserial.PacketCounter.Difference(dataLoggerStartPacketCount), dataLoggerFiles.CloseFiles(), "Data Logger Report");
                dataLoggerFiles = null;
                button_dataLoggerFilePathBrowse.Enabled = true;
                textBox_dataLoggerFilePath.Enabled = true;
                button_dataLoggerStart.Text = "Start Logging";
            }
        }

        /// <summary>
        /// x-IMU data receive event to write data to CSV files if data logging.
        /// </summary>
        void xIMUserial_xIMUdataReceived(object sender, x_IMU_API.xIMUdata e)
        {
            if (dataLoggerFiles != null)
            {
                try
                {
                    dataLoggerFiles.WriteData(e);
                }
                catch { }
            }
            if ((hardIronCalDataFiles != null) && (e is x_IMU_API.CalInertialMagData))
            {
                try
                {
                    hardIronCalDataFiles.WriteCalInertialMagData((x_IMU_API.CalInertialMagData)e);
                }
                catch { }
            }
        }

        /// <summary>
        /// Shows data logger report detailing packets counts and files created.
        /// </summary>
        /// <param name="packetCount">
        /// PacketCount instance representing the number of packets received (for log report) or read (for conversion report).
        /// </param>
        /// <param name="filesNames">
        /// Array of file names of created files.
        /// </param>
        /// <param name="caption">
        /// Caption of report message box.
        /// </param>
        private void ShowDataLoggerReport(x_IMU_API.PacketCount packetCount, string[] filesNames, string caption)
        {
            string filesCreated = "";
            if (filesNames != null)
            {
                for (int i = 0; i < filesNames.Length; i++)
                {
                    filesCreated += "\r" + filesNames[i];
                }
            }
            if (filesCreated == "") filesCreated = "\rNone.";
            PassiveMessageBox.Show("Total packets read:\t\t\t\t" + Convert.ToString(packetCount.TotalPacketsRead) + "\r" +
                                   "Packet read errors:\t\t\t\t" + Convert.ToString(packetCount.PacketsReadErrors) + "\r" +
                                   "Error packets read:\t\t\t\t" + Convert.ToString(packetCount.ErrorPacketsRead) + "\r" +
                                   "Command packets read:\t\t\t" + Convert.ToString(packetCount.CommandPacketsRead) + "\r" +
                                   "Register packets read:\t\t\t" + Convert.ToString(packetCount.RegisterPacketsRead) + "\r" +
                                   "Date/time packets read:\t\t\t" + Convert.ToString(packetCount.DateTimePacketsRead) + "\r" +
                                   "Raw battery and thermometer packets read:\t" + Convert.ToString(packetCount.RawBattThermPacketsRead) + "\r" +
                                   "Calibrated battery and thermometer packets read:\t" + Convert.ToString(packetCount.CalBattThermPacketsRead) + "\r" +
                                   "Raw inertial/magnetic packets read:\t\t" + Convert.ToString(packetCount.RawInertialMagPacketsRead) + "\r" +
                                   "Calibrated inertial/magnetic packets read:\t\t" + Convert.ToString(packetCount.CalInertialMagPacketsRead) + "\r" +
                                   "Quaternion packets read:\t\t\t" + Convert.ToString(packetCount.QuaternionPacketsRead) + "\r" +
                                   "Digital I/O packets read:\t\t\t" + Convert.ToString(packetCount.DigitalIOPacketsRead) + "\r" +
                                   "Raw analogue input packets read:\t\t" + Convert.ToString(packetCount.RawAnalogueInputPacketsRead) + "\r" +
                                   "Calibrated analogue input packets read:\t\t" + Convert.ToString(packetCount.CalAnalogueInputPacketsRead) + "\r" +
                                   "PWM output packets read:\t\t\t" + Convert.ToString(packetCount.PWMoutputPacketsRead) + "\r" +
                                   "Raw ADXL345 bus packets read:\t\t\t" + Convert.ToString(packetCount.RawADXL345busPacketsRead) + "\r" +
                                   "Calibrated ADXL345 bus packets read:\t\t" + Convert.ToString(packetCount.CalADXL345busPacketsRead) + "\r\r" +
                                   "Files created:" +
                                   filesCreated,
                                   caption,
                                   MessageBoxIcon.Information);
        }

        #endregion

        #region SD card file

        /// <summary>
        /// Button click event to open file dialog and copy result to file path text box.
        /// </summary>
        private void button_convertBinaryFileConvertBrowse_Click(object sender, EventArgs e)
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
        /// Button click event to start processing file in new thread.
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
            button_convertBinaryFileConvertBrowse.Enabled = false;
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
            convertedBinaryFiles = new x_IMU_API.CSVfileWriter(Path.GetDirectoryName(textBox_convertBinaryFileFilePath.Text) + "\\" + Path.GetFileNameWithoutExtension(textBox_convertBinaryFileFilePath.Text));
            x_IMU_API.xIMUfile xIMUfile = new x_IMU_API.xIMUfile(textBox_convertBinaryFileFilePath.Text);
            xIMUfile.xIMUdataRead += new x_IMU_API.xIMUfile.onxIMUdataRead(xIMUfile_xIMUdataRead);
            xIMUfile.AsyncReadProgressChanged += new x_IMU_API.xIMUfile.onAsyncReadProgressChanged(xIMUfile_AsyncReadProgressChanged);
            xIMUfile.AsyncReadCompleted += new x_IMU_API.xIMUfile.onAsyncReadCompleted(xIMUfile_AsyncReadCompleted);
            xIMUfile.RunAnsycRead();
        }

        /// <summary>
        /// Asynchronous read progress change event to update progress dialog and poll user cancel.
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
        /// Asynchronous read complete event to set form control states and open serial port if successful.
        /// </summary>
        void xIMUfile_AsyncReadCompleted(object sender, x_IMU_API.AsyncReadCompletedEventArgs e)
        {
            string[] fileNames = convertedBinaryFiles.CloseFiles();
            ((x_IMU_API.xIMUfile)sender).Close();
            if (!e.Cancelled)
            {
                ShowDataLoggerReport(e.PacketCounter, fileNames, "Conversion Report");
            }
            this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate
            {
                button_convertBinaryFileConvert.Text = "Convert";
                textBox_convertBinaryFileFilePath.Enabled = true;
                button_convertBinaryFileConvert.Enabled = true;
                button_convertBinaryFileConvertBrowse.Enabled = true;
                binaryFileConverterProgressDialog.CloseDialog();
            })));
        }

        /// <summary>
        /// x-IMU data read event to write data to CSV files.
        /// </summary>
        void xIMUfile_xIMUdataRead(object sender, x_IMU_API.xIMUdata e)
        {
            try
            {
                convertedBinaryFiles.WriteData(e);
            }
            catch { }
        }

        #endregion

        #region Hard-iron calibration

        #region Step 1 - Clear current hard-iron bias parameters

        /// <summary>
        /// Button click event to clear current hard-iron bias parameters.
        /// </summary>
        private void button_clearHardIronRegisters_Click(object sender, EventArgs e)
        {
            try
            {
                if (xIMUserial.IsOpen)
                {
                    SendWriteRegister(new x_IMU_API.RegisterData(x_IMU_API.RegisterAddresses.MagHardIronBiasX, 0.0f));
                    SendWriteRegister(new x_IMU_API.RegisterData(x_IMU_API.RegisterAddresses.MagHardIronBiasY, 0.0f));
                    SendWriteRegister(new x_IMU_API.RegisterData(x_IMU_API.RegisterAddresses.MagHardIronBiasZ, 0.0f));
                }
                else
                {
                    throw new Exception("Port is closed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Step 2 - Collect Calibration Dataset

        /// <summary>
        /// Opens file navigation form to define file path for the hard-iron calibration dataset.
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
        /// Text changed event to synchronise dependant file path in text box.
        /// </summary>
        private void textBox_collectHardIronCalDatasetFilePath_TextChanged(object sender, EventArgs e)
        {
            textBox_hardIronCalFilePath.Text = textBox_collectHardIronCalDatasetFilePath.Text + "_CalInertialMagnetic.csv";
        }

        /// <summary>
        /// Button click event to start/stop collecting the hard-iron calibration dataset.
        /// </summary>
        /// <remarks>
        /// File writing is handled in data reception event.
        /// </remarks>
        private void button_collectHardIronCalDatasetStartLogging_Click(object sender, EventArgs e)
        {
            if (button_collectHardIronCalDatasetStartLogging.Text == "Start Logging")
            {
                try
                {
                    hardIronCalStartPacketCount = new x_IMU_API.PacketCount(xIMUserial.PacketCounter);
                    hardIronCalDataFiles = new x_IMU_API.CSVfileWriter(textBox_collectHardIronCalDatasetFilePath.Text);
                    button_collectHardIronCalDatasetStartLogging.Text = "Stop Logging";
                    textBox_collectHardIronCalDatasetFilePath.Enabled = false;
                    button_collectHardIronCalDatasetBrowse.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("Invalid file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (button_collectHardIronCalDatasetStartLogging.Text == "Stop Logging")
            {
                int numPackets = xIMUserial.PacketCounter.Difference(hardIronCalStartPacketCount).CalInertialMagPacketsRead;
                string[] fileNames = hardIronCalDataFiles.CloseFiles();
                hardIronCalDataFiles = null;;
                if (numPackets == 0)
                {
                    PassiveMessageBox.Show("No calibrated inertial/magnetic data packets were received.  File not created.", "Information", MessageBoxIcon.Warning);
                }
                else
                {
                    PassiveMessageBox.Show("Calibrated inertial/magnetic packets received: " + Convert.ToString(numPackets) + ".\r"+
                                          "File created: " + fileNames[0], "Information", MessageBoxIcon.Information);
                }
                button_collectHardIronCalDatasetBrowse.Enabled = true;
                textBox_collectHardIronCalDatasetFilePath.Enabled = true;
                button_collectHardIronCalDatasetStartLogging.Text = "Start Logging";
            }
        }

        #endregion

        #region Step 3 - Run Hard-Iron Calibration Algorithm

        /// <summary>
        /// Button click event to open file dialog and copy result to file path text box.  Exceptions shown message box.
        /// </summary>
        private void button_hardIronCalBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select File";
            openFileDialog.Filter = "x-IMU Calibrated Inertial/Magnetic CSV Files|*_CalInertialMagnetic.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_hardIronCalFilePath.Text = openFileDialog.FileName.ToString();
            }
        }

        /// <summary>
        /// Button click event to run hard-iron calibration algorithm and write parameters to device registers.
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
                if (xIMUserial.IsOpen)
                {
                    SendWriteRegister(new x_IMU_API.RegisterData(x_IMU_API.RegisterAddresses.MagHardIronBiasX, (float)Convert.ToDouble(biasesStr[0])));
                    SendWriteRegister(new x_IMU_API.RegisterData(x_IMU_API.RegisterAddresses.MagHardIronBiasY, (float)Convert.ToDouble(biasesStr[1])));
                    SendWriteRegister(new x_IMU_API.RegisterData(x_IMU_API.RegisterAddresses.MagHardIronBiasZ, (float)Convert.ToDouble(biasesStr[2])));
                }
                else
                {
                    throw new Exception("Port is closed.");
                }
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
        /// Button click event to open file dialog and copy result to firmware file path textbox.
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
        /// Button click event to upload firmware.
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
            if (MessageBox.Show("Please ensure that the selected port name is the port assigned to the x-IMU USB connection else the upload will fail.\r\n\r\n" +
                                "The new firmware will be uploaded to the x-IMU and the current firmware will be lost.\r\n\r\n" +
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
                ClosePort();
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
                OpenPort();
            }
        }

        #endregion

        #region About

        /// <summary>
        /// linked label click event to open URL.
        /// </summary>
        private void linkLabel_wwwxiocouk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            launchWebBrowser("http://www.x-io.co.uk");
        }

        /// <summary>
        /// linked label click event to open URL.
        /// </summary>
        private void linkLabel_wwwoscilloscopelibcom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            launchWebBrowser("http://www.oscilloscope-lib.com");
        }

        /// <summary>
        /// linked label click event to open URL.
        /// </summary>
        private void linkLabel_httpsourceforgenetprojectstaoframework_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            launchWebBrowser("http://sourceforge.net/projects/taoframework/");
        }

        /// <summary>
        /// Launch web browser on specified URL.
        /// </summary>
        /// <param name="URL">
        /// URL to be opened when web browser is launched.
        /// </param>
        private void launchWebBrowser(string URL)
        {
            try
            {
                System.Diagnostics.Process.Start(URL);
            }
            catch
            {
                MessageBox.Show("Browser launch failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}