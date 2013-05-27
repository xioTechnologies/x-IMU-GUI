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

namespace xIMU_GUI
{
    public partial class Form_main : Form
    {
        #region Variables

        /// <summary>
        /// x-IMU serial object used to commutate to the x-IMU via USB or Bluetooth.
        /// </summary>
        private xIMU_API.xIMUserial xIMUserial;

        /// <summary>
        /// For update timer used to periodically update form data
        /// </summary>
        private System.Windows.Forms.Timer formUpdateTimer;

        /// <summary>
        /// RegisterData array used to parse register data between xIMUserial and GUI threads.
        /// </summary>
        private xIMU_API.RegisterData[] treeViewRegisterData;

        /// <summary>
        /// DateTime object used to buffer date/time data between xIMUserial and GUI threads.
        /// </summary>
        private xIMU_API.DateTimeData dateTimeData;

        /// <summary>
        /// Oscilloscope objects used to display individual sensor data.
        /// </summary>
        /// <remarks>
        /// Requires Osc_DLL.dll version 2.8.2, see http://www.oscilloscope-lib.com/. Oscilloscope.cs wrapper class provided by Frank Greenlee.
        /// </remarks>
        private Oscilloscope battOscilloscope, thermOscilloscope, gyroOscilloscope, accelOscilloscope, magOscilloscope, eulerOscilloscope;

        /// <summary>
        /// 3D Cuboid graphics form used to display 3D orientation (quaternion) data.
        /// </summary>
        private Cuboid3D cuboid3D;

        /// <summary>
        /// Digital I/O form used to set and display digital I/O data.
        /// </summary>
        private DigitalIOpanel digitalIOpanel;

        /// <summary>
        /// Packet count data at of start of data logging.  This is used to calculate the number of packets received during data logging.
        /// </summary>
        private xIMU_API.PacketCount packetCountAtStartOfDataLogging;

        /// <summary>
        /// Global flag set/cleared used by data logger functionality to enable/disabled file writes in individual data receive events.
        /// </summary>
        private bool loggingToFile = false;

        /// <summary>
        /// Packet count data at start of hard-iron calibration dataset collection. This is used to calculate the number of packets received during data logging.
        /// </summary>
        private xIMU_API.PacketCount packetCountAtStartOfHardIronDatasetCollection;

        /// <summary>
        /// File used to collect hard-iron calibration dataset.  A non-null value is used to enable file writes in data received event.
        /// </summary>
        private StreamWriter hardIronDatasetFile = null;

        #region Data files

        /// <summary>
        /// Index of each file within array.  Each label is used as part of file name.
        /// </summary>
        private enum FileIndexes
        {
            DateTime,
            RawBattTherm,
            CalBattTherm,
            RawInertialMagnetic,
            CalInertialMagnetic,
            Quaternion,
            RotationMatrix,
            EulerAngles,
            DigitalIO,
            NumberOfFiles
        }

        /// <summary>
        /// Array of files used by data logging functionality.  A non-null value is used to enable file writes in data received event.
        /// </summary>
        private StreamWriter[] LoggedFiles = new StreamWriter[(int)FileIndexes.NumberOfFiles];

        /// <summary>
        /// Array of files used by binary file conversion functionality.  A non-null value is used to enable file writes in data received event.
        /// </summary>
        private StreamWriter[] ConvertedFiles = new StreamWriter[(int)FileIndexes.NumberOfFiles];

        #endregion

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
        /// Form closed load event to set initial form control values and start form update timer.
        /// </summary>
        private void Form_main_Load(object sender, EventArgs e)
        {
            #region Create peripheral GUIs

            battOscilloscope = Oscilloscope.CreateScope("ScopeSettings/battOscilloscope_settings.ini", "");
            thermOscilloscope = Oscilloscope.CreateScope("ScopeSettings/thermOscilloscope_settings.ini", "");
            gyroOscilloscope = Oscilloscope.CreateScope("ScopeSettings/gyroOscilloscope_settings.ini", "");
            accelOscilloscope = Oscilloscope.CreateScope("ScopeSettings/accelOscilloscope_settings.ini", "");
            magOscilloscope = Oscilloscope.CreateScope("ScopeSettings/magOscilloscope_settings.ini", "");
            eulerOscilloscope = Oscilloscope.CreateScope("ScopeSettings/eulerOscilloscope_settings.ini", "");
            cuboid3D = new Cuboid3D(new float[] { 6, 4, 2 }, new string[] { @"CuboidImages\Right.png", @"CuboidImages\Left.png", @"CuboidImages\Back.png",
                                                                            @"CuboidImages\Front.png", @"CuboidImages\Top.png", @"CuboidImages\Bottom.png"});
            digitalIOpanel = new DigitalIOpanel();
            digitalIOpanel.StateChanged += new DigitalIOpanel.onStateChanged(digitalIOpanel_StateChanged);

            #endregion

            #region Create x-IMU serial object

            xIMUserial = new xIMU_API.xIMUserial();
            xIMUserial.ErrorMessageReceived += new xIMU_API.xIMUserial.onErrorMessageReceived(xIMUserial_ErrorMessageReceived);
            xIMUserial.CommandMessageReceived += new xIMU_API.xIMUserial.onCommandMessageReceived(xIMUserial_CommandMessageReceived);
            xIMUserial.RegisterDataReceived += new xIMU_API.xIMUserial.onRegisterDataReceived(xIMUserial_RegisterDataReceived);
            xIMUserial.DateTimeDataReceived += new xIMU_API.xIMUserial.onDateTimeDataReceived(xIMUserial_DateTimeDataReceived);
            xIMUserial.RawBattThermDataReceived += new xIMU_API.xIMUserial.onRawBattThermDataReceived(xIMUserial_RawBattThermDataReceived);
            xIMUserial.CalBattThermDataReceived += new xIMU_API.xIMUserial.onCalBattThermDataReceived(xIMUserial_CalBattThermDataReceived);
            xIMUserial.RawInertialMagDataReceived += new xIMU_API.xIMUserial.onRawInertialMagDataReceived(xIMUserial_RawInertialMagDataReceived);
            xIMUserial.CalInertialMagDataReceived += new xIMU_API.xIMUserial.onCalInertialMagDataReceived(xIMUserial_CalInertialMagDataReceived);
            xIMUserial.QuaternionDataReceived += new xIMU_API.xIMUserial.onQuaternionDataReceived(xIMUserial_QuaternionDataReceived);
            xIMUserial.DigitalIODataReceived += new xIMU_API.xIMUserial.onDigitalIODataReceived(xIMUserial_DigitalIODataReceived);

            #endregion

            #region Create tool tip for registers

            ToolTip toolTip = new ToolTip();
            toolTip.ToolTipTitle = "Tip";
            toolTip.SetToolTip(appendedTreeView_registers, "Right-click for action menu");

            #endregion

            #region Set constant form control values

            this.Text += " " + Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
            label_GUIversionNum.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            label_APIversionNum.Text = FileVersionInfo.GetVersionInfo("xIMU_API.dll").FileVersion.ToString();
            label_compatibleFirmwareVersionNums.Text = "";
            int[] compatibleFirmMajorVerNums = (int[])Enum.GetValues(typeof(xIMU_API.CompatibleFirmwareVersions));
            for (int i = 0; i < compatibleFirmMajorVerNums.Length; i++)
            {
                label_compatibleFirmwareVersionNums.Text += Convert.ToString(compatibleFirmMajorVerNums[i]) + ".x";
                if (i < compatibleFirmMajorVerNums.Length - 1)
                {
                    label_compatibleFirmwareVersionNums.Text += ", ";
                }
            }

            #endregion

            #region Set default variable form control values

            refreshCOMportList();
            textBox_dataLoggerFilePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\" + "LoggedData";
            textBox_collectHardIronCalDatasetFilePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\" + "HardIronCalDataset" + "_" + FileIndexes.CalInertialMagnetic.ToString() + ".csv";
            textBox_hardIronCalFilePath.Text = textBox_collectHardIronCalDatasetFilePath.Text;

            #endregion

            #region Create Form update timer and associated variables

            treeViewRegisterData = new xIMU_API.RegisterData[(int)xIMU_API.RegisterAddresses.numRegisters];

            formUpdateTimer = new System.Windows.Forms.Timer();
            formUpdateTimer.Interval = 50;
            formUpdateTimer.Tick += new EventHandler(formUpdateTimer_Tick);
            formUpdateTimer.Start();

            #endregion
        }

        /// <summary>
        /// Form closed event to close serial port and files.
        /// </summary>
        private void Form_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            xIMUserial.Close();
            CloseFiles(LoggedFiles);
            CloseFiles(ConvertedFiles);
            hardIronDatasetFile.Close();
        }

        #endregion

        #region Form update timer

        /// <summary>
        /// Timer tick event to update form control data.
        /// </summary>
        void formUpdateTimer_Tick(object sender, EventArgs e)
        {
            #region Update packet counter text boxes

            textBox_packetsReceived.Text = Convert.ToString(xIMUserial.PacketCounter.TotalPacketsReceived);
            textBox_packetsSent.Text = Convert.ToString(xIMUserial.PacketCounter.TotalPacketsSent);

            #endregion

            #region Apply new register data to tree view

            bool needToRefresh = false;
            for (int i = 0; i < (int)xIMU_API.RegisterAddresses.numRegisters; i++)
            {
                if (treeViewRegisterData[i] != null)                                // non-null data class indicates new data
                {
                    RegisterDataToTreeNode(treeViewRegisterData[i]);
                    treeViewRegisterData[i] = null;                                 // flag data class as up-to-date
                    needToRefresh = true;
                }
            }
            if (needToRefresh)
            {
                appendedTreeView_registers.Refresh();                               // refresh only once per timer tick
            }

            #endregion

            #region Update received date/time text box

            if (dateTimeData != null)
            {
                textBox_receivedDataTime.Text = String.Format("{0:F}", dateTimeData.DateTimeObject);
            }

            #endregion
        }

        #endregion

        #region Serial port

        /// <summary>
        /// Toggles the open/closed state of the serial port.  Exceptions shown message box.
        /// </summary>
        private void button_openPort_Click(object sender, EventArgs e)
        {
            if (button_openPort.Text == "Open Port")
            {
                try
                {
                    comboBox_portName.Enabled = false;
                    button_refreshList.Enabled = false;
                    button_openPort.Enabled = false;
                    button_openPort.Text = "Opening...";
                    this.Update();
                    xIMUserial.PortName = comboBox_portName.Text;
                    xIMUserial.Open();
                    button_openPort.Text = "Close Port";
                    button_openPort.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    button_openPort.Text = "Open Port";
                    comboBox_portName.Enabled = true;
                    button_refreshList.Enabled = true;
                    button_openPort.Enabled = true;
                }
            }
            else if (button_openPort.Text == "Close Port")
            {
                xIMUserial.Close();
                comboBox_portName.Enabled = true;
                button_refreshList.Enabled = true;
                button_openPort.Text = "Open Port";
            }
        }

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
            string[] aviablePorts = xIMU_API.xIMUserial.GetPortNames();
            comboBox_portName.Items.Clear();
            for (int i = 0; i < aviablePorts.Length; i++)
            {
                comboBox_portName.Items.Add(aviablePorts[i]);
            }
            comboBox_portName.SelectedIndex = comboBox_portName.Items.Count - 1;
        }

        #endregion

        #region Error message received

        /// <summary>
        /// Error message received event to display error message in message box.
        /// </summary>
        void xIMUserial_ErrorMessageReceived(object sender, xIMU_API.ErrorData e)
        {
            if (e.ErrorCode == (ushort)xIMU_API.ErrorCodes.TransmitBufferOvun) return;      // ignore transmit buffer overrun errors as may be frequent with poor Bluetooth reception
            MessageBoxThread.Show("Error message: " + e.GetMessage(), "Message From Device");
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
        void regContextMenu_ItemClick_expand(object sender, EventArgs e)
        {
            appendedTreeView_registers.ExpandAll();
        }

        /// <summary>
        /// Context menu item click event to collapse all of the tree view.
        /// </summary>
        void regContextMenu_ItemClick_collapse(object sender, EventArgs e)
        {
            appendedTreeView_registers.CollapseAll();
        }

        #endregion

        #region Save all to file

        /// <summary>
        /// Context menu item click event to save all registers data to file.
        /// </summary>
        void regContextMenu_ItemClick_saveAllToFile(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Select File";
            saveFileDialog.Filter = "binary files (*.bin)|*.bin|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.FileName = "savedRegisters" + appendedTextBoxTreeNode_DeviceID.TextBox.Text + ".bin";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                xIMU_API.xIMUfile xIMUfile = new xIMU_API.xIMUfile(saveFileDialog.FileName.ToString(), true);
                foreach (TreeNode rootNode in appendedTreeView_registers.Nodes)
                {
                    xIMU_API.RegisterData registerData = TreeNodeToRegisterData(rootNode, false);
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
        private void WriteWriteRegisterForAllChildNodes(xIMU_API.xIMUfile xIMUfile, TreeNode rootNode)
        {
            foreach (TreeNode childNode in rootNode.Nodes)
            {
                xIMU_API.RegisterData registerData = TreeNodeToRegisterData(childNode, false);
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
        private void WriteWriteRegister(xIMU_API.xIMUfile xIMUfile, xIMU_API.RegisterData registerData)
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
        void regContextMenu_ItemClick_loadFromFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select File";
            openFileDialog.Filter = "binary files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.FileName = "savedRegisters.bin";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var thread = new Thread(
                  () =>
                  {
                      xIMU_API.xIMUfile xIMUfile = new xIMU_API.xIMUfile(openFileDialog.FileName.ToString());
                      xIMUfile.RegisterDataRead += new xIMU_API.xIMUfile.onRegisterDataRead(xIMUfile_RegisterDataRead);
                      xIMUfile.Read();
                      if (xIMUfile.PacketCounter.PacketsReceivedErrors != 0)
                      {
                          MessageBox.Show(Convert.ToString(xIMUfile.PacketCounter.PacketsReceivedErrors) + " read errors occurred.", "Error");
                      }
                      xIMUfile.Close();
                  });
                thread.Start();
            }
        }

        /// <summary>
        /// Register data read event to parse data to register tree view.
        /// </summary>
        void xIMUfile_RegisterDataRead(object sender, xIMU_API.RegisterData e)
        {
            treeViewRegisterData[(int)e.Address] = e;
        }

        #endregion

        #region Read registers

        /// <summary>
        /// Context menu item click event to send a read register packet for nodes in the tree view.
        /// </summary>
        void regContextMenu_ItemClick_readAll(object sender, EventArgs e)
        {
            if (xIMUserial.IsOpen)
            {
                foreach (TreeNode rootNode in appendedTreeView_registers.Nodes)
                {
                    xIMU_API.RegisterData registerData = TreeNodeToRegisterData(rootNode, true);
                    if (registerData != null) SendReadRegister(registerData);
                    SendReadRegisterForAllChildNodes(rootNode);
                }
            }
            else
            {
                MessageBox.Show("The port is closed.", "Error");
            }
        }


        /// <summary>
        /// Context menu item click event to send a read register packet for all child nodes of the current selected tree node.
        /// </summary>
        void regContextMenu_ItemClick_readAllThisGroupOnly(object sender, EventArgs e)
        {
            if (xIMUserial.IsOpen)
            {
                SendReadRegisterForAllChildNodes(appendedTreeView_registers.SelectedNode);
            }
            else
            {
                MessageBox.Show("The port is closed.", "Error");
            }
        }

        /// <summary>
        /// Context menu item click event to send a read register packet for the current selected tree node.
        /// </summary>
        void regContextMenu_ItemClick_readThisOnly(object sender, EventArgs e)
        {
            xIMU_API.RegisterData registerData = TreeNodeToRegisterData(appendedTreeView_registers.SelectedNode, true);
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
                xIMU_API.RegisterData registerData = TreeNodeToRegisterData(childNode, true);
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
        private void SendReadRegister(xIMU_API.RegisterData registerData)
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
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        /// <summary>
        /// Register data received event to parse data to register tree view buffer.
        /// </summary>
        void xIMUserial_RegisterDataReceived(object sender, xIMU_API.RegisterData e)
        {
            treeViewRegisterData[(int)e.Address] = e;
        }

        #endregion

        #region Write registers

        /// <summary>
        /// Context menu item click event to send a write register packet for nodes in the tree view.
        /// </summary>
        void regContextMenu_ItemClick_writeAll(object sender, EventArgs e)
        {
            if (xIMUserial.IsOpen)
            {
                foreach (TreeNode rootNode in appendedTreeView_registers.Nodes)
                {
                    xIMU_API.RegisterData registerData = TreeNodeToRegisterData(rootNode, false);
                    SendWriteRegister(registerData);
                    SendWriteRegisterForAllChildNodes(rootNode);
                }
            }
            else
            {
                MessageBox.Show("The port is closed.", "Error");
            }
        }

        /// <summary>
        /// Context menu item click event to send a write register packet for all child nodes of the current selected tree node.
        /// </summary>
        void regContextMenu_ItemClick_writAllThisGroupOnly(object sender, EventArgs e)
        {
            if (xIMUserial.IsOpen)
            {
                SendWriteRegisterForAllChildNodes(appendedTreeView_registers.SelectedNode);
            }
            else
            {
                MessageBox.Show("The port is closed.", "Error");
            }
        }

        /// <summary>
        /// Context menu item click event to send a write register packet for the current selected tree node.
        /// </summary>
        void regContextMenu_ItemClick_writeThisOnly(object sender, EventArgs e)
        {
            xIMU_API.RegisterData registerData = TreeNodeToRegisterData(appendedTreeView_registers.SelectedNode, false);
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
                xIMU_API.RegisterData registerData = TreeNodeToRegisterData(childNode, false);
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
        private void SendWriteRegister(xIMU_API.RegisterData registerData)
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
                    MessageBox.Show(ex.Message, "Error");
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
        private void RegisterDataToTreeNode(xIMU_API.RegisterData registerData)
        {
            try
            {
                AppendedTreeNode treeNode = null;
                switch (registerData.Address)
                {
                    case ((ushort)xIMU_API.RegisterAddresses.FirmVersionMajorNum): treeNode = appendedTextBoxTreeNode_FirmVersionMajorNum; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString((ushort)registerData.Value); break;
                    case ((ushort)xIMU_API.RegisterAddresses.FirmVersionMinorNum): treeNode = appendedTextBoxTreeNode_FirmVersionMinorNum; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString((ushort)registerData.Value); break;
                    case ((ushort)xIMU_API.RegisterAddresses.DeviceID): treeNode = appendedTextBoxTreeNode_DeviceID; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = string.Format("{0:X4}", registerData.Value); break;
                    case ((ushort)xIMU_API.RegisterAddresses.ButtonMode): treeNode = appendedComboBoxTreeNode_buttonMode; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)xIMU_API.RegisterAddresses.BattSensitivity): treeNode = appendedTextBoxTreeNode_battSens; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.BattBias): treeNode = appendedTextBoxTreeNode_battBias; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.ThermSensitivity): treeNode = appendedTextBoxTreeNode_thermSens; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.ThermBias): treeNode = appendedTextBoxTreeNode_thermBias; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.GyroSensitivityX): treeNode = appendedTextBoxTreeNode_gyroSensX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.GyroSensitivityY): treeNode = appendedTextBoxTreeNode_gyroSensY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.GyroSensitivityZ): treeNode = appendedTextBoxTreeNode_gyroSensZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.GyroBiasX): treeNode = appendedTextBoxTreeNode_gyroBiasX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.GyroBiasY): treeNode = appendedTextBoxTreeNode_gyroBiasY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.GyroBiasZ): treeNode = appendedTextBoxTreeNode_gyroBiasZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.GyroBiasTempSensX): treeNode = appendedTextBoxTreeNode_gyroBiasTempSensX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.GyroBiasTempSensY): treeNode = appendedTextBoxTreeNode_gyroBiasTempSensY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.GyroBiasTempSensZ): treeNode = appendedTextBoxTreeNode_gyroBiasTempSensZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.GyroSample1Temp): treeNode = appendedTextBoxTreeNode_gyroSample1Temp; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.GyroSample1BiasX): treeNode = appendedTextBoxTreeNode_gyroSample1BiasX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.GyroSample1BiasY): treeNode = appendedTextBoxTreeNode_gyroSample1BiasY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.GyroSample1BiasZ): treeNode = appendedTextBoxTreeNode_gyroSample1BiasZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.GyroSample2Temp): treeNode = appendedTextBoxTreeNode_gyroSample2Temp; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.GyroSample2BiasX): treeNode = appendedTextBoxTreeNode_gyroSample2BiasX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.GyroSample2BiasY): treeNode = appendedTextBoxTreeNode_gyroSample2BiasY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.GyroSample2BiasZ): treeNode = appendedTextBoxTreeNode_gyroSample2BiasZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.AccelFullScale): treeNode = appendedComboBoxTreeNode_accelFullScale; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)xIMU_API.RegisterAddresses.AccelSensitivityX): treeNode = appendedTextBoxTreeNode_accelSensX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.AccelSensitivityY): treeNode = appendedTextBoxTreeNode_accelSensY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.AccelSensitivityZ): treeNode = appendedTextBoxTreeNode_accelSensZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.AccelBiasX): treeNode = appendedTextBoxTreeNode_accelBiasX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.AccelBiasY): treeNode = appendedTextBoxTreeNode_accelBiasY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.AccelBiasZ): treeNode = appendedTextBoxTreeNode_accelBiasZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.MagFullScale): treeNode = appendedComboBoxTreeNode_magFullScale; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)xIMU_API.RegisterAddresses.MagSensitivityX): treeNode = appendedTextBoxTreeNode_magSensX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.MagSensitivityY): treeNode = appendedTextBoxTreeNode_magSensY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.MagSensitivityZ): treeNode = appendedTextBoxTreeNode_magSensZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.MagBiasX): treeNode = appendedTextBoxTreeNode_magBiasX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.MagBiasY): treeNode = appendedTextBoxTreeNode_magBiasY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.MagBiasZ): treeNode = appendedTextBoxTreeNode_magBiasZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.MagHardIronBiasX): treeNode = appendedTextBoxTreeNode_magHIbiasX; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.MagHardIronBiasY): treeNode = appendedTextBoxTreeNode_magHIbiasY; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.MagHardIronBiasZ): treeNode = appendedTextBoxTreeNode_magHIbiasZ; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.AlgorithmMode): treeNode = appendedComboBoxTreeNode_algorithmMode; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)xIMU_API.RegisterAddresses.AlgorithmKp): treeNode = appendedTextBoxTreeNode_algoGainKp; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.AlgorithmKi): treeNode = appendedTextBoxTreeNode_algoGainKi; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.AlgorithmInitKp): treeNode = appendedTextBoxTreeNode_algoInitKp; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.AlgorithmInitPeriod): treeNode = appendedTextBoxTreeNode_algoInitPeriod; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.TareQuat0): treeNode = appendedTextBoxTreeNode_tareQuatElement0; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.TareQuat1): treeNode = appendedTextBoxTreeNode_tareQuatElement1; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.TareQuat2): treeNode = appendedTextBoxTreeNode_tareQuatElement2; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.TareQuat3): treeNode = appendedTextBoxTreeNode_tareQuatElement3; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.SensorDataMode): treeNode = appendedComboBoxTreeNode_sensorDataMode; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)xIMU_API.RegisterAddresses.DateTimeOutputRate): treeNode = appendedComboBoxTreeNode_dateTimeOutputRate; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)xIMU_API.RegisterAddresses.BattThermOutputRate): treeNode = appendedComboBoxTreeNode_battThermOutputRate; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)xIMU_API.RegisterAddresses.InertialMagOutputRate): treeNode = appendedComboBoxTreeNode_inertialMagOutputRate; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)xIMU_API.RegisterAddresses.QuatOutputRate): treeNode = appendedComboBoxTreeNode_quatOutputRate; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)xIMU_API.RegisterAddresses.SDcardNewFileName): treeNode = appendedTextBoxTreeNode_SDcardNewFileName; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = string.Format("{0:D5}", (ushort)registerData.Value); break;
                    case ((ushort)xIMU_API.RegisterAddresses.BattShutdownVoltage): treeNode = appendedComboBoxTreeNode_battShutdownVoltage; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = Convert.ToString(registerData.floatValue); break;
                    case ((ushort)xIMU_API.RegisterAddresses.SleepTimer): treeNode = appendedTextBoxTreeNode_sleepTimer; ((AppendedTreeNodeTextBox)treeNode).TextBox.Text = (registerData.Value == 0 ? "Disabled" : Convert.ToString(registerData.Value)); break;
                    case ((ushort)xIMU_API.RegisterAddresses.MotionTrigWakeUp): treeNode = appendedComboBoxTreeNode_motionTriggeredWakeup; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)xIMU_API.RegisterAddresses.BluetoothPower): treeNode = appendedComboBoxTreeNode_bluetoothPower; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)xIMU_API.RegisterAddresses.AuxiliaryPortMode): treeNode = appendedComboBoxTreeNode_auxiliaryPortMode; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)xIMU_API.RegisterAddresses.DigitalIOdirection): treeNode = appendedComboBoxTreeNode_digitalIOdirection; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    case ((ushort)xIMU_API.RegisterAddresses.DigitalIOoutputRate): treeNode = appendedComboBoxTreeNode_digitalIOoutputRate; ((AppendedTreeNodeComboBox)treeNode).ComboBox.SelectedIndex = registerData.Value; break;
                    default: throw new Exception("Specified register address does have an associated tree node.");
                }
                if (treeNode != null)
                {
                    treeNode.TextColor = Color.Blue;

                    #region Warning if device firmware is not listed as compatible

                    if (treeNode == appendedTextBoxTreeNode_FirmVersionMajorNum)
                    {
                        if (!Enum.IsDefined(typeof(xIMU_API.CompatibleFirmwareVersions), Convert.ToInt32(appendedTextBoxTreeNode_FirmVersionMajorNum.TextBox.Text)))
                        {
                            MessageBoxThread.Show("The detected firmware version is not fully compatible with this software version.", "Warning");
                        }
                    }

                    #endregion
                }
            }
            catch
            {
                MessageBox.Show("Invalid register address (0x" + string.Format("{0:X4}", registerData.Address) + ") and/or value (0x" + string.Format("{0:X4}", registerData.Value) + ")", "Error");
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
        private xIMU_API.RegisterData TreeNodeToRegisterData(TreeNode treeNode, bool addressOnly)
        {
            xIMU_API.RegisterData registerData = new xIMU_API.RegisterData();
            try
            {
                if (treeNode.Equals(appendedTextBoxTreeNode_FirmVersionMajorNum)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.FirmVersionMajorNum; if (!addressOnly) registerData = null; }         // return null for read-only register
                else if (treeNode.Equals(appendedTextBoxTreeNode_FirmVersionMinorNum)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.FirmVersionMinorNum; if (!addressOnly) registerData = null; }    // return null for read-only register
                else if (treeNode.Equals(appendedTextBoxTreeNode_DeviceID)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.DeviceID; if (!addressOnly) registerData = null; }                                      // return null for read-only register
                else if (treeNode.Equals(appendedComboBoxTreeNode_buttonMode)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.ButtonMode; if (!addressOnly) { int selectedIndex = (int)appendedComboBoxTreeNode_buttonMode.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTextBoxTreeNode_battSens)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.BattSensitivity; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_battSens.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_battBias)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.BattBias; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_battBias.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_thermSens)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.ThermSensitivity; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_thermSens.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_thermBias)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.ThermBias; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_thermBias.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_gyroSensX)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.GyroSensitivityX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_gyroSensX.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_gyroSensY)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.GyroSensitivityY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_gyroSensY.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_gyroSensZ)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.GyroSensitivityZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_gyroSensZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_gyroBiasX)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.GyroBiasX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_gyroBiasX.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_gyroBiasY)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.GyroBiasY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_gyroBiasY.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_gyroBiasZ)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.GyroBiasZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_gyroBiasZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_gyroBiasTempSensX)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.GyroBiasTempSensX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_gyroBiasTempSensX.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_gyroBiasTempSensY)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.GyroBiasTempSensY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_gyroBiasTempSensY.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_gyroBiasTempSensZ)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.GyroBiasTempSensZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_gyroBiasTempSensZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_gyroSample1Temp)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.GyroSample1Temp; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_gyroSample1Temp.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_gyroSample1BiasX)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.GyroSample1BiasX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_gyroSample1BiasX.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_gyroSample1BiasY)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.GyroSample1BiasY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_gyroSample1BiasY.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_gyroSample1BiasZ)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.GyroSample1BiasZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_gyroSample1BiasZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_gyroSample2Temp)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.GyroSample2Temp; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_gyroSample2Temp.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_gyroSample2BiasX)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.GyroSample2BiasX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_gyroSample2BiasX.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_gyroSample2BiasY)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.GyroSample2BiasY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_gyroSample2BiasY.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_gyroSample2BiasZ)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.GyroSample2BiasZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_gyroSample2BiasZ.TextBox.Text); }
                else if (treeNode.Equals(appendedComboBoxTreeNode_accelFullScale)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.AccelFullScale; if (!addressOnly) { int selectedIndex = (int)appendedComboBoxTreeNode_accelFullScale.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTextBoxTreeNode_accelSensX)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.AccelSensitivityX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_accelSensX.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_accelSensY)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.AccelSensitivityY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_accelSensY.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_accelSensZ)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.AccelSensitivityZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_accelSensZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_accelBiasX)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.AccelBiasX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_accelBiasX.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_accelBiasY)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.AccelBiasY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_accelBiasY.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_accelBiasZ)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.AccelBiasZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_accelBiasZ.TextBox.Text); }
                else if (treeNode.Equals(appendedComboBoxTreeNode_magFullScale)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.MagFullScale; if (!addressOnly) { int selectedIndex = (int)appendedComboBoxTreeNode_magFullScale.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTextBoxTreeNode_magSensX)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.MagSensitivityX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_magSensX.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_magSensY)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.MagSensitivityY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_magSensY.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_magSensZ)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.MagSensitivityZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_magSensZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_magBiasX)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.MagBiasX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_magBiasX.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_magBiasY)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.MagBiasY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_magBiasY.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_magBiasZ)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.MagBiasZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_magBiasZ.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_magHIbiasX)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.MagHardIronBiasX; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_magHIbiasX.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_magHIbiasY)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.MagHardIronBiasY; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_magHIbiasY.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_magHIbiasZ)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.MagHardIronBiasZ; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_magHIbiasZ.TextBox.Text); }
                else if (treeNode.Equals(appendedComboBoxTreeNode_algorithmMode)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.AlgorithmMode; if (!addressOnly) { int selectedIndex = (int)appendedComboBoxTreeNode_algorithmMode.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTextBoxTreeNode_algoGainKp)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.AlgorithmKp; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_algoGainKp.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_algoGainKi)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.AlgorithmKi; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_algoGainKi.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_algoInitKp)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.AlgorithmInitKp; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_algoInitKp.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_algoInitPeriod)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.AlgorithmInitPeriod; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_algoInitPeriod.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_tareQuatElement0)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.TareQuat0; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_tareQuatElement0.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_tareQuatElement1)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.TareQuat1; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_tareQuatElement1.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_tareQuatElement2)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.TareQuat2; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_tareQuatElement2.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_tareQuatElement3)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.TareQuat3; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedTextBoxTreeNode_tareQuatElement3.TextBox.Text); }
                else if (treeNode.Equals(appendedComboBoxTreeNode_sensorDataMode)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.SensorDataMode; if (!addressOnly) { int selectedIndex = (int)appendedComboBoxTreeNode_sensorDataMode.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedComboBoxTreeNode_dateTimeOutputRate)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.DateTimeOutputRate; if (!addressOnly) { int selectedIndex = (int)appendedComboBoxTreeNode_dateTimeOutputRate.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedComboBoxTreeNode_battThermOutputRate)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.BattThermOutputRate; if (!addressOnly) { int selectedIndex = (int)appendedComboBoxTreeNode_battThermOutputRate.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedComboBoxTreeNode_inertialMagOutputRate)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.InertialMagOutputRate; if (!addressOnly) { int selectedIndex = (int)appendedComboBoxTreeNode_inertialMagOutputRate.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedComboBoxTreeNode_quatOutputRate)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.QuatOutputRate; if (!addressOnly) { int selectedIndex = (int)appendedComboBoxTreeNode_quatOutputRate.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedTextBoxTreeNode_SDcardNewFileName)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.SDcardNewFileName; if (!addressOnly) registerData.Value = Convert.ToUInt16(appendedTextBoxTreeNode_SDcardNewFileName.TextBox.Text); }
                else if (treeNode.Equals(appendedComboBoxTreeNode_battShutdownVoltage)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.BattShutdownVoltage; if (!addressOnly) registerData.floatValue = (float)Convert.ToDouble(appendedComboBoxTreeNode_battShutdownVoltage.TextBox.Text); }
                else if (treeNode.Equals(appendedTextBoxTreeNode_sleepTimer)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.SleepTimer; if (!addressOnly) { string text = appendedTextBoxTreeNode_sleepTimer.TextBox.Text; registerData.Value = (string.Equals(text, "Disabled", StringComparison.CurrentCultureIgnoreCase) ? (ushort)0 : Convert.ToUInt16(text)); } }
                else if (treeNode.Equals(appendedComboBoxTreeNode_motionTriggeredWakeup)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.MotionTrigWakeUp; if (!addressOnly) { int selectedIndex = (int)appendedComboBoxTreeNode_motionTriggeredWakeup.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedComboBoxTreeNode_bluetoothPower)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.BluetoothPower; if (!addressOnly) { int selectedIndex = (int)appendedComboBoxTreeNode_bluetoothPower.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedComboBoxTreeNode_auxiliaryPortMode)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.AuxiliaryPortMode; if (!addressOnly) { int selectedIndex = (int)appendedComboBoxTreeNode_auxiliaryPortMode.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedComboBoxTreeNode_digitalIOdirection)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.DigitalIOdirection; if (!addressOnly) { int selectedIndex = (int)appendedComboBoxTreeNode_digitalIOdirection.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else if (treeNode.Equals(appendedComboBoxTreeNode_digitalIOoutputRate)) { registerData.Address = (ushort)xIMU_API.RegisterAddresses.DigitalIOoutputRate; if (!addressOnly) { int selectedIndex = (int)appendedComboBoxTreeNode_digitalIOoutputRate.ComboBox.SelectedIndex; if (selectedIndex != -1) registerData.Value = (ushort)selectedIndex; else throw new Exception("Item not selected."); } }
                else registerData = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r" + treeNode.ToString(), "Error");
                registerData = null;
            }
            return registerData;
        }

        /// <summary>
        /// Returns a ushort value equal to the specified hexadecimal string.
        /// </summary>
        /// <param name="hexString">
        /// Hexadecimal string.
        /// </param>
        /// <returns>
        /// ushort value equal to the specified hexadecimal string.
        /// </returns>
        private ushort HexStringToUshort(string hexString)
        {
            byte[] byteArray;
            try
            {
                byteArray = Enumerable.Range(0, hexString.Length).Where(x => 0 == x % 2).Select(x => Convert.ToByte(hexString.Substring(x, 2), 16)).ToArray();
            }
            catch
            {
                throw new Exception("Hexadecimal string was not in correct format.");
            }
            return (ushort)((ushort)((ushort)byteArray[0] << 8) | (ushort)byteArray[1]);
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
                xIMUserial.SendWriteDateTimePacket(new xIMU_API.DateTimeData(DateTime.Now));
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
        /// Date/Time data received event to display data in form and write to file.  Will create new file if file not open.
        /// </summary>
        void xIMUserial_DateTimeDataReceived(object sender, xIMU_API.DateTimeData e)
        {
            dateTimeData = e;
            if (loggingToFile)
            {
                if (LoggedFiles[(int)FileIndexes.DateTime] == null)
                {
                    LoggedFiles[(int)FileIndexes.DateTime] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_dataLoggerFilePath.Text) + "_" + FileIndexes.DateTime.ToString() + ".txt", false);
                }
                LoggedFiles[(int)FileIndexes.DateTime].WriteLine(String.Format("{0:F}", e.DateTimeObject));
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Sends command packet to reset device.
        /// </summary>
        private void button_resetDevice_Click(object sender, EventArgs e)
        {
            SendCommandPacket(xIMU_API.CommandCodes.ResetDevice);
        }

        /// <summary>
        /// Sends command packet to sleep device.
        /// </summary>
        private void button_sleep_Click(object sender, EventArgs e)
        {
            SendCommandPacket(xIMU_API.CommandCodes.Sleep);
        }

        /// <summary>
        /// Sends command packet to reset sleep timer.
        /// </summary>
        private void button_resetSleepTimer_Click(object sender, EventArgs e)
        {
            SendCommandPacket(xIMU_API.CommandCodes.ResetSleepTimer);
        }

        /// <summary>
        /// Sends command packet sample gyroscope bias at temperature 1.
        /// </summary>
        private void button_sampleGyroBiasAtT1_Click(object sender, EventArgs e)
        {
            SendCommandPacket(xIMU_API.CommandCodes.SampleGyroBiasTemp1);
        }

        /// <summary>
        /// Sends command packet sample gyroscope bias at temperature 2.
        /// </summary>
        private void button_sampleGyroBiasAtT2_Click(object sender, EventArgs e)
        {
            SendCommandPacket(xIMU_API.CommandCodes.SampleGyroBiasTemp2);
        }

        /// <summary>
        /// Sends command packet calcualte gyroscope bias parameters.
        /// </summary>
        private void button_calcGyroBiasParams_Click(object sender, EventArgs e)
        {
            SendCommandPacket(xIMU_API.CommandCodes.CalcGyroBiasParams);
        } 


        /// <summary>
        /// Sends command packet to lookup accelerometer sensitivity.
        /// </summary>
        private void button_lookupAccelSensitivity_Click(object sender, EventArgs e)
        {
            SendCommandPacket(xIMU_API.CommandCodes.LookupAccelBiasAndSens);
        }

        /// <summary>
        /// Sends command packet to measure magnetometer bias and sensitivity.
        /// </summary>
        private void button_measMagBiasSens_Click(object sender, EventArgs e)
        {
            SendCommandPacket(xIMU_API.CommandCodes.MeasureMagBiasAndSens);
        }

        /// <summary>
        /// Sends command packet to reset algorithm.
        /// </summary>
        private void button_resetAlgorithm_Click(object sender, EventArgs e)
        {
            SendCommandPacket(xIMU_API.CommandCodes.ResetAlgorithm);
        }

        /// <summary>
        /// Sends command packet to tare.
        /// </summary>
        private void button_tare_Click(object sender, EventArgs e)
        {
            SendCommandPacket(xIMU_API.CommandCodes.Tare);
        }

        /// <summary>
        /// Sends command packet to clear tare.
        /// </summary>
        private void button_clearTare_Click(object sender, EventArgs e)
        {
            SendCommandPacket(xIMU_API.CommandCodes.ClearTare);
        }

        /// <summary>
        /// Sends a command packet to device.  Exceptions shown message box.
        /// </summary>
        /// <param name="commandCode">
        /// Command code to be sent.
        /// </param>
        private void SendCommandPacket(xIMU_API.CommandCodes commandCode)
        {
            try
            {
                xIMUserial.SendCommandPacket(commandCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Command message received event to display message in message box.
        /// </summary>
        void xIMUserial_CommandMessageReceived(object sender, xIMU_API.CommandData e)
        {
            if (checkBox_displayReceivedCommandMessages.Checked)
            {
                MessageBoxThread.Show("Command message: " + e.GetMessage(), "Message From Device");
            }
        }

        #endregion

        #region View sensor data & Data logger file writes

        #region Sensor data received events & Data logger file writes

        /// <summary>
        /// Raw battery and thermometer data received event to write data to graph and file.  Will create new file if file not open.
        /// </summary>
        void xIMUserial_RawBattThermDataReceived(object sender, xIMU_API.RawBattThermData e)
        {
            battOscilloscope.AddScopeData(e.BatteryVoltage, 0.0, 0.0);
            thermOscilloscope.AddScopeData(e.Thermometer, 0.0, 0.0);
            if (loggingToFile)
            {
                if (LoggedFiles[(int)FileIndexes.RawBattTherm] == null)
                {
                    LoggedFiles[(int)FileIndexes.RawBattTherm] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_dataLoggerFilePath.Text) + "_" + FileIndexes.RawBattTherm.ToString() + ".csv", false);
                }
                LoggedFiles[(int)FileIndexes.RawBattTherm].WriteLine(e.ConvertToCSV());
            }
        }

        /// <summary>
        /// Calibrated battery and thermometer data received event to write data to graph and file.  Will create new file if file not open.
        /// </summary>
        void xIMUserial_CalBattThermDataReceived(object sender, xIMU_API.CalBattThermData e)
        {
            battOscilloscope.AddScopeData(e.BatteryVoltage, 0.0, 0.0);
            thermOscilloscope.AddScopeData(e.Thermometer, 0.0, 0.0);
            if (loggingToFile)
            {
                if (LoggedFiles[(int)FileIndexes.CalBattTherm] == null)
                {
                    LoggedFiles[(int)FileIndexes.CalBattTherm] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_dataLoggerFilePath.Text) + "_" + FileIndexes.CalBattTherm.ToString() + ".csv", false);
                }
                LoggedFiles[(int)FileIndexes.CalBattTherm].WriteLine(e.ConvertToCSV());
            }
        }

        /// <summary>
        /// Raw inertial and magnetic data received event to write data to graph and file.  Will create new file if file not open.
        /// </summary>
        void xIMUserial_RawInertialMagDataReceived(object sender, xIMU_API.RawInertialMagData e)
        {
            gyroOscilloscope.AddScopeData(e.Gyroscope[0], e.Gyroscope[1], e.Gyroscope[2]);
            accelOscilloscope.AddScopeData(e.Accelerometer[0], e.Accelerometer[1], e.Accelerometer[2]);
            magOscilloscope.AddScopeData(e.Magnetometer[0], e.Magnetometer[1], e.Magnetometer[2]);
            if (loggingToFile)
            {
                if (LoggedFiles[(int)FileIndexes.RawInertialMagnetic] == null)
                {
                    LoggedFiles[(int)FileIndexes.RawInertialMagnetic] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_dataLoggerFilePath.Text) + "_" + FileIndexes.RawInertialMagnetic.ToString() + ".csv", false);
                }
                LoggedFiles[(int)FileIndexes.RawInertialMagnetic].WriteLine(e.ConvertToCSV());
            }
        }

        /// <summary>
        /// Calibrated inertial and magnetic data received event to write data to graph and files.  Will create new file if file not open.
        /// </summary>
        void xIMUserial_CalInertialMagDataReceived(object sender, xIMU_API.CalInertialMagData e)
        {
            gyroOscilloscope.AddScopeData(e.Gyroscope[0], e.Gyroscope[1], e.Gyroscope[2]);
            accelOscilloscope.AddScopeData(e.Accelerometer[0], e.Accelerometer[1], e.Accelerometer[2]);
            magOscilloscope.AddScopeData(e.Magnetometer[0], e.Magnetometer[1], e.Magnetometer[2]);
            if (loggingToFile)
            {
                if (LoggedFiles[(int)FileIndexes.CalInertialMagnetic] == null)
                {
                    LoggedFiles[(int)FileIndexes.CalInertialMagnetic] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_dataLoggerFilePath.Text) + "_" + FileIndexes.CalInertialMagnetic.ToString() + ".csv", false);
                }
                LoggedFiles[(int)FileIndexes.CalInertialMagnetic].WriteLine(e.ConvertToCSV());
            }
            if (hardIronDatasetFile != null)
            {
                try { hardIronDatasetFile.WriteLine(e.ConvertToCSV()); }
                catch { }
            }
        }

        /// <summary>
        /// Quaternion data received event to write data to graph and file.  Will create new file if file not open.
        /// </summary>
        void xIMUserial_QuaternionDataReceived(object sender, xIMU_API.QuaternionData e)
        {
            float[] euler = e.ConvertToEulerAngles();
            eulerOscilloscope.AddScopeData(euler[0], euler[1], euler[2]);
            cuboid3D.RotationMatrix = e.ConvertToRotationMatrix();
            if (loggingToFile)
            {
                if (LoggedFiles[(int)FileIndexes.Quaternion] == null)
                {
                    LoggedFiles[(int)FileIndexes.Quaternion] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_dataLoggerFilePath.Text) + "_" + FileIndexes.Quaternion.ToString() + ".csv", false);
                }
                LoggedFiles[(int)FileIndexes.Quaternion].WriteLine(e.ConvertToCSV());
                if (LoggedFiles[(int)FileIndexes.RotationMatrix] == null)
                {
                    LoggedFiles[(int)FileIndexes.RotationMatrix] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_dataLoggerFilePath.Text) + "_" + FileIndexes.RotationMatrix.ToString() + ".csv", false);
                }
                LoggedFiles[(int)FileIndexes.RotationMatrix].WriteLine(e.ConvertToRotationMatrixCSV());
                if (LoggedFiles[(int)FileIndexes.EulerAngles] == null)
                {
                    LoggedFiles[(int)FileIndexes.EulerAngles] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_dataLoggerFilePath.Text) + "_" + FileIndexes.EulerAngles.ToString() + ".csv", false);
                }
                LoggedFiles[(int)FileIndexes.EulerAngles].WriteLine(e.ConvertToEulerAnglesCSV());
            }
        }

        /// <summary>
        /// Gets file path without extension.
        /// </summary>
        /// <param name="fullPath">
        /// Full path of file including extension.
        /// </param>
        /// <returns>
        /// File path without extension.
        /// </returns>
        string GetPathWithoutExtension(string fullPath)
        {
            return Path.GetDirectoryName(fullPath) + "\\" + Path.GetFileNameWithoutExtension(fullPath);
        }

        #endregion

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

        #endregion

        #region Auxilary port

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
        void digitalIOpanel_StateChanged(object sender, xIMU_API.DigitalIOdata.PortData e)
        {
            try
            {
                xIMUserial.SendDigitalIOPacket(new xIMU_API.DigitalIOdata(e));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Digital I/O data received event to display data in form and write to file.  Will create new file if file not open.
        /// </summary>
        void xIMUserial_DigitalIODataReceived(object sender, xIMU_API.DigitalIOdata e)
        {
            digitalIOpanel.IsInput = e.IsInput;
            digitalIOpanel.State = e.State;
            if (loggingToFile)
            {
                if (LoggedFiles[(int)FileIndexes.DigitalIO] == null)
                {
                    LoggedFiles[(int)FileIndexes.DigitalIO] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_dataLoggerFilePath.Text) + "_" + FileIndexes.DigitalIO.ToString() + ".csv", false);
                }
                LoggedFiles[(int)FileIndexes.DigitalIO].WriteLine(e.ConvertToCSV());
            }
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
            try
            {
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(textBox_dataLoggerFilePath.Text);
                saveFileDialog.FileName = Path.GetFileName(textBox_dataLoggerFilePath.Text);
            }
            catch
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.FileName = "LoggedData";
            }
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
                #region Error if invalid file path

                try
                {
                    if ((!Directory.Exists(Path.GetDirectoryName(textBox_dataLoggerFilePath.Text)) ||
                        (Path.GetFileNameWithoutExtension(textBox_dataLoggerFilePath.Text) == "")))
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid file path.", "Error");
                    return;
                }

                #endregion

                button_dataLoggerStart.Text = "Stop Logging";
                textBox_dataLoggerFilePath.Enabled = false;
                button_dataLoggerFilePathBrowse.Enabled = false;
                packetCountAtStartOfDataLogging = new xIMU_API.PacketCount(xIMUserial.PacketCounter);
                loggingToFile = true;
            }
            else if (button_dataLoggerStart.Text == "Stop Logging")
            {
                loggingToFile = false;
                ShowLogOrConvertReport(packetCountAtStartOfDataLogging.Difference(xIMUserial.PacketCounter), LoggedFiles, true);
                CloseFiles(LoggedFiles);
                button_dataLoggerFilePathBrowse.Enabled = true;
                textBox_dataLoggerFilePath.Enabled = true;
                button_dataLoggerStart.Text = "Start Logging";
            }
        }

        /// <summary>
        /// Shows a log or conversion report detailing packets counts and files created.
        /// </summary>
        /// <param name="packetCount">
        /// PacketCount instance representing the number of packets received (for log report) or read (for conversion report).
        /// </param>
        /// <param name="files">
        /// Array containing file objects. Object is null if not created.
        /// </param>
        /// <param name="LogOrConvert">
        /// Used to display correct language.  true = log report, false = conversion report.
        /// </param>
        private void ShowLogOrConvertReport(xIMU_API.PacketCount packetCount, StreamWriter[] files, bool LogOrConvert)
        {
            string filesCreated = "";
            for (int i = 0; i < (int)FileIndexes.NumberOfFiles; i++)        // create list of files created
            {
                if (files[i] != null)
                {
                    filesCreated += "\r" + Path.GetFileName(((FileStream)files[i].BaseStream).Name);
                }
            }
            if (filesCreated == "") filesCreated = "\rNone.";
            MessageBoxThread.Show("Total packets " + (LogOrConvert ? "received:" : "read:") + "\t\t\t\t" + Convert.ToString(packetCount.TotalPacketsReceived) + "\r" +
                                  "Packet " + (LogOrConvert ? "reception" : "read") + " errors: \t\t\t\t" + Convert.ToString(packetCount.PacketsReceivedErrors) + "\r" +
                                  "Date/time packets " + (LogOrConvert ? "received:\t" : "read:") + "\t\t\t" + Convert.ToString(packetCount.DateTimeDataPacketsReceived) + "\r" +
                                  "Raw battery and thermometer packets " + (LogOrConvert ? "received:\t" : "read:") + "\t" + Convert.ToString(packetCount.RawBattThermDataPacketsReceived) + "\r" +
                                  "Calibrated battery and thermometer packets " + (LogOrConvert ? "received:" : "read:") + "\t" + Convert.ToString(packetCount.CalBattThermDataPacketsReceived) + "\r" +
                                  "Raw inertial/magnetic packets " + (LogOrConvert ? "received:\t" : "read:") + "\t\t" + Convert.ToString(packetCount.RawInertialMagDataPacketsReceived) + "\r" +
                                  "Calibrated inertial/magnetic packets " + (LogOrConvert ? "received:" : "read:") + "\t\t" + Convert.ToString(packetCount.CalInertialMagDataPacketsReceived) + "\r" +
                                  "Quaternion packets " + (LogOrConvert ? "received:\t" : "read:") + "\t\t\t" + Convert.ToString(packetCount.QuaternionDataPacketsReceived) + "\r" +
                                  "Digital I/O packets " + (LogOrConvert ? "received:\t" : "read:") + "\t\t\t" + Convert.ToString(packetCount.DigitalIODataPacketsReceived) + "\r\r" +
                                  "Files created:" +
                                  filesCreated,
                                  (LogOrConvert ? "Log" : "Conversion") + " Report");
        }

        /// <summary>
        /// Closes files and sets file objects to null.
        /// </summary>
        /// <param name="files">
        /// Array of files to close and set to null.
        /// </param>
        private void CloseFiles(StreamWriter[] files)
        {
            for (int i = 0; i < (int)FileIndexes.NumberOfFiles; i++)
            {
                if (files[i] != null)
                {
                    files[i].Close();
                    files[i] = null;
                }
            }
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
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
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
            #region Error if file not exist

            if (!File.Exists(textBox_convertBinaryFileFilePath.Text))
            {
                MessageBox.Show("File does not exist.", "Error");
                return;
            }

            #endregion

            #region Disable SD card form controls

            textBox_convertBinaryFileFilePath.Enabled = false;
            button_convertBinaryFileConvertBrowse.Enabled = false;
            button_convertBinaryFileConvert.Enabled = false;
            button_convertBinaryFileConvert.Text = "Converting...";

            #endregion

            #region Perform conversion in new thread (Re-enable SD card form controls)

            var thread = new Thread(
              () =>
              {
                  try
                  {
                      xIMU_API.xIMUfile xIMUfile = new xIMU_API.xIMUfile(textBox_convertBinaryFileFilePath.Text);
                      xIMUfile.DateTimeDataRead += new xIMU_API.xIMUfile.onDateTimeDataRead(xIMUfile_DateTimeDataRead);
                      xIMUfile.RawBattThermDataRead += new xIMU_API.xIMUfile.onRawBattThermDataRead(xIMUfile_RawBattThermDataRead);
                      xIMUfile.CalBattThermDataRead += new xIMU_API.xIMUfile.onCalBattThermDataRead(xIMUfile_CalBattThermDataRead);
                      xIMUfile.RawInertialMagDataRead += new xIMU_API.xIMUfile.onRawInertialMagDataRead(xIMUfile_RawInertialMagDataRead);
                      xIMUfile.CalInertialMagDataRead += new xIMU_API.xIMUfile.onCalInertialMagDataRead(xIMUfile_CalInertialMagDataRead);
                      xIMUfile.QuaternionDataRead += new xIMU_API.xIMUfile.onQuaternionDataRead(xIMUfile_QuaternionDataRead);
                      xIMUfile.DigitalIODataRead += new xIMU_API.xIMUfile.onDigitalIODataRead(xIMUfile_DigitalIODataRead);
                      xIMUfile.Read();
                      xIMUfile.Close();
                      ShowLogOrConvertReport(xIMUfile.PacketCounter, ConvertedFiles, false);
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message, "Error");
                  }
                  CloseFiles(ConvertedFiles);

                  #region Re-enable SD card form controls

                  this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate
                  {
                      button_convertBinaryFileConvert.Text = "Convert";
                      textBox_convertBinaryFileFilePath.Enabled = true;
                      button_convertBinaryFileConvert.Enabled = true;
                      button_convertBinaryFileConvertBrowse.Enabled = true;
                  })));

                  #endregion
              });
            thread.Start();
            #endregion
        }

        #region Packet read events

        /// <summary>
        /// Date/time data read event to write data to file.  Will create new file if file not open.
        /// </summary>
        void xIMUfile_DateTimeDataRead(object sender, xIMU_API.DateTimeData e)
        {
            if (ConvertedFiles[(int)FileIndexes.DateTime] == null)
            {
                ConvertedFiles[(int)FileIndexes.DateTime] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_convertBinaryFileFilePath.Text) + "_" + FileIndexes.DateTime.ToString() + ".txt", false);
            }
            ConvertedFiles[(int)FileIndexes.DateTime].WriteLine(String.Format("{0:F}", e.DateTimeObject));
        }

        /// <summary>
        /// Raw battery and thermometer data read event to write data to file.  Will create new file if file not open.
        /// </summary>
        void xIMUfile_RawBattThermDataRead(object sender, xIMU_API.RawBattThermData e)
        {
            if (ConvertedFiles[(int)FileIndexes.RawBattTherm] == null)
            {
                ConvertedFiles[(int)FileIndexes.RawBattTherm] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_convertBinaryFileFilePath.Text) + "_" + FileIndexes.RawBattTherm.ToString() + ".csv", false);
            }
            ConvertedFiles[(int)FileIndexes.RawBattTherm].WriteLine(e.ConvertToCSV());
        }

        /// <summary>
        /// Calibrated battery and thermometer data read event to write data to file.  Will create new file if file not open.
        /// </summary>
        void xIMUfile_CalBattThermDataRead(object sender, xIMU_API.CalBattThermData e)
        {
            if (ConvertedFiles[(int)FileIndexes.CalBattTherm] == null)
            {
                ConvertedFiles[(int)FileIndexes.CalBattTherm] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_convertBinaryFileFilePath.Text) + "_" + FileIndexes.CalBattTherm.ToString() + ".csv", false);
            }
            ConvertedFiles[(int)FileIndexes.CalBattTherm].WriteLine(e.ConvertToCSV());
        }

        /// <summary>
        /// Raw inertial/magnetic data read event to write data to file.  Will create new file if file not open.
        /// </summary>
        void xIMUfile_RawInertialMagDataRead(object sender, xIMU_API.RawInertialMagData e)
        {
            if (ConvertedFiles[(int)FileIndexes.RawInertialMagnetic] == null)
            {
                ConvertedFiles[(int)FileIndexes.RawInertialMagnetic] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_convertBinaryFileFilePath.Text) + "_" + FileIndexes.RawInertialMagnetic.ToString() + ".csv", false);
            }
            ConvertedFiles[(int)FileIndexes.RawInertialMagnetic].WriteLine(e.ConvertToCSV());
        }

        /// <summary>
        /// Calibrated inertial/magnetic data read event to write data to file.  Will create new file if file not open.
        /// </summary>
        void xIMUfile_CalInertialMagDataRead(object sender, xIMU_API.CalInertialMagData e)
        {
            if (ConvertedFiles[(int)FileIndexes.CalInertialMagnetic] == null)
            {
                ConvertedFiles[(int)FileIndexes.CalInertialMagnetic] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_convertBinaryFileFilePath.Text) + "_" + FileIndexes.CalInertialMagnetic.ToString() + ".csv", false);
            }
            ConvertedFiles[(int)FileIndexes.CalInertialMagnetic].WriteLine(e.ConvertToCSV());
        }

        /// <summary>
        /// Quaternion data read event to write data to files.  Will create new files if files not open.
        /// </summary>
        void xIMUfile_QuaternionDataRead(object sender, xIMU_API.QuaternionData e)
        {
            if (ConvertedFiles[(int)FileIndexes.Quaternion] == null)
            {
                ConvertedFiles[(int)FileIndexes.Quaternion] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_convertBinaryFileFilePath.Text) + "_" + FileIndexes.Quaternion.ToString() + ".csv", false);
            }
            ConvertedFiles[(int)FileIndexes.Quaternion].WriteLine(e.ConvertToCSV());
            if (ConvertedFiles[(int)FileIndexes.RotationMatrix] == null)
            {
                ConvertedFiles[(int)FileIndexes.RotationMatrix] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_convertBinaryFileFilePath.Text) + "_" + FileIndexes.RotationMatrix.ToString() + ".csv", false);
            }
            ConvertedFiles[(int)FileIndexes.RotationMatrix].WriteLine(e.ConvertToRotationMatrixCSV());
            if (ConvertedFiles[(int)FileIndexes.EulerAngles] == null)
            {
                ConvertedFiles[(int)FileIndexes.EulerAngles] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_convertBinaryFileFilePath.Text) + "_" + FileIndexes.EulerAngles.ToString() + ".csv", false);
            }
            ConvertedFiles[(int)FileIndexes.EulerAngles].WriteLine(e.ConvertToEulerAnglesCSV());
        }

        /// <summary>
        /// Digital I/O data read event to write data to file.  Will create new files if file not open.
        /// </summary>
        void xIMUfile_DigitalIODataRead(object sender, xIMU_API.DigitalIOdata e)
        {
            if (ConvertedFiles[(int)FileIndexes.DigitalIO] == null)
            {
                ConvertedFiles[(int)FileIndexes.DigitalIO] = new System.IO.StreamWriter(GetPathWithoutExtension(textBox_convertBinaryFileFilePath.Text) + "_" + FileIndexes.DigitalIO.ToString() + ".csv", false);
            }
            ConvertedFiles[(int)FileIndexes.DigitalIO].WriteLine(e.ConvertToCSV());
        }

        #endregion

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
                    SendWriteRegister(new xIMU_API.RegisterData(xIMU_API.RegisterAddresses.MagHardIronBiasX, 0.0f));
                    SendWriteRegister(new xIMU_API.RegisterData(xIMU_API.RegisterAddresses.MagHardIronBiasY, 0.0f));
                    SendWriteRegister(new xIMU_API.RegisterData(xIMU_API.RegisterAddresses.MagHardIronBiasZ, 0.0f));
                }
                else
                {
                    throw new Exception("Port is closed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        #endregion

        #region Step 2 - Collect Calibration Dataset

        /// <summary>
        /// Opens file navigation form to define file path for the hard-iron calibration dataset.
        /// </summary>
        private void buttoncollectHardIronCalDatasetBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Select File";
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.OverwritePrompt = false;
            try
            {
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(textBox_collectHardIronCalDatasetFilePath.Text);
                saveFileDialog.FileName = Path.GetFileName(textBox_collectHardIronCalDatasetFilePath.Text);
            }
            catch
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                saveFileDialog.FileName = "HardIronCalDataset" + "_" + FileIndexes.CalInertialMagnetic.ToString() + ".csv";
            }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_collectHardIronCalDatasetFilePath.Text = saveFileDialog.FileName.ToString();
            }
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
                #region Error if invalid file path

                try
                {
                    if ((!Directory.Exists(Path.GetDirectoryName(textBox_collectHardIronCalDatasetFilePath.Text)) ||
                        (Path.GetFileNameWithoutExtension(textBox_collectHardIronCalDatasetFilePath.Text) == "")))
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid file path.", "Error");
                    return;
                }

                #endregion

                #region Open file

                try
                {
                    hardIronDatasetFile = new StreamWriter(GetPathWithoutExtension(textBox_collectHardIronCalDatasetFilePath.Text) + ".csv");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return;
                }

                #endregion

                packetCountAtStartOfHardIronDatasetCollection = new xIMU_API.PacketCount(xIMUserial.PacketCounter);

                button_collectHardIronCalDatasetStartLogging.Text = "Stop Logging";
                textBox_collectHardIronCalDatasetFilePath.Enabled = false;
                button_collectHardIronCalDatasetBrowse.Enabled = false;
            }
            else if (button_collectHardIronCalDatasetStartLogging.Text == "Stop Logging")
            {
                hardIronDatasetFile.Close();
                hardIronDatasetFile = null;

                MessageBoxThread.Show("Calibrated inertial/magnetic packets received: " + Convert.ToString(packetCountAtStartOfHardIronDatasetCollection.Difference(xIMUserial.PacketCounter).CalInertialMagDataPacketsReceived), "Message");

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
            openFileDialog.Title = "Select *_inertialMag.csv File";
            openFileDialog.Filter = "CSV Files|*.csv";
            try
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(textBox_hardIronCalFilePath.Text);
                openFileDialog.FileName = Path.GetFileName(textBox_hardIronCalFilePath.Text);
            }
            catch
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                openFileDialog.FileName = "HardIronCalDataset" + "_" + FileIndexes.CalInertialMagnetic.ToString() + ".csv";
            }
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
            #region Error if file not exist

            if (!File.Exists(textBox_hardIronCalFilePath.Text))
            {
                MessageBox.Show("File does not exist.", "Error");
                return;
            }

            #endregion

            #region Disable hard-iron calibration form controls

            textBox_hardIronCalFilePath.Enabled = false;
            button_hardIronCalBrowse.Enabled = false;
            button_hardIronCalRun.Enabled = false;
            button_hardIronCalRun.Text = "Running...";
            this.Update();

            #endregion

            try
            {
                #region Import calibration dataset from CSV file

                StreamReader streamReader = new StreamReader(textBox_hardIronCalFilePath.Text);
                string CSVline = null;
                List<double> xDataList = new List<double>();
                List<double> yDataList = new List<double>();
                List<double> zDataList = new List<double>();

                while ((CSVline = streamReader.ReadLine()) != null)
                {
                    try
                    {
                        string[] vars = CSVline.Split(',');
                        xDataList.Add(Convert.ToDouble(vars[6]));
                        yDataList.Add(Convert.ToDouble(vars[7]));
                        zDataList.Add(Convert.ToDouble(vars[8]));
                    }
                    catch
                    {
                        streamReader.Close();
                        throw new Exception("Error reading CSV line.");
                    }
                }
                streamReader.Close();

                double[] xData = xDataList.ToArray();
                double[] yData = yDataList.ToArray();
                double[] zData = zDataList.ToArray();

                if (xData.Length == 0)
                {
                    throw new Exception("No data was imported from CSV file.");
                }

                #endregion

                #region Run hard-iron calibration algorithm

                double[] biasAndSD = HardIronCal.HardIronCalibration.Run(xData, yData, zData);

                #endregion

                #region Write parameters to device registers

                if (xIMUserial.IsOpen)
                {
                    SendWriteRegister(new xIMU_API.RegisterData(xIMU_API.RegisterAddresses.MagHardIronBiasX, (float)biasAndSD[0]));
                    SendWriteRegister(new xIMU_API.RegisterData(xIMU_API.RegisterAddresses.MagHardIronBiasY, (float)biasAndSD[1]));
                    SendWriteRegister(new xIMU_API.RegisterData(xIMU_API.RegisterAddresses.MagHardIronBiasZ, (float)biasAndSD[2]));
                }
                else
                {
                    throw new Exception("Port is closed.");
                }

                MessageBoxThread.Show("Hard-iron calibration complete. Standard deviation = " + string.Format("{0:0.000000}", biasAndSD[3]) + ".\r\r" +
                                      "The magnetometer hard-iron bias registers have been updated.", "Message");

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            #region Re-enable hard-iron calibration form controls

            button_hardIronCalRun.Text = "Run";
            textBox_hardIronCalFilePath.Enabled = true;
            button_hardIronCalBrowse.Enabled = true;
            button_hardIronCalRun.Enabled = true;

            #endregion
        }

        #endregion

        #endregion

        #region Bootloader

        /// <summary>
        /// Tab control selected index changed event to display warning to user.
        /// </summary>
        private void tabControl_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_main.SelectedIndex == tabControl_main.TabPages.IndexOf(tabPage_bootloader))
            {
                MessageBox.Show("Register values may be lost when new firmware is uploaded.\r" +
                                "Save registers to file before uploading new firmware.", "Warning");
            }
        }

        /// <summary>
        /// Button click event to open file dialog and copy result to firmware file path textbox.
        /// </summary>
        private void button_bootloaderBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select Firmware Hex File";
            openFileDialog.Filter = "HEX Files|*.hex";
            try
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(textBox_bootloaderFilePath.Text);
                openFileDialog.FileName = Path.GetFileName(textBox_bootloaderFilePath.Text);
            }
            catch
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }
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
            #region Error if file not exist

            if (!File.Exists(textBox_bootloaderFilePath.Text))
            {
                MessageBox.Show("File does not exist.", "Error");
                return;
            }

            #endregion

            #region  Error if serial port already open

            if (xIMUserial.IsOpen)
            {
                MessageBox.Show("Serial port must be closed.", "Error");
                return;
            }

            #endregion

            #region Disable bootloader form controls

            textBox_bootloaderFilePath.Enabled = false;
            button_bootloaderBrowse.Enabled = false;
            button_bootloaderUpload.Enabled = false;
            button_bootloaderUpload.Text = "Uploading...";
            this.Update();

            #endregion

            #region Perform firmware upload procedure

            try
            {
                #region Reset device

                xIMU_API.xIMUserial tempxIMUserial = new xIMU_API.xIMUserial(comboBox_portName.Text);
                tempxIMUserial.Open();
                tempxIMUserial.SendCommandPacket(xIMU_API.CommandCodes.ResetDevice);
                tempxIMUserial.Close();

                #endregion

                #region Run external bootloader process

                ProcessStartInfo processInfo = new ProcessStartInfo("16-Bit Flash Programmer.exe");
                processInfo.Arguments = "-i " + "\\\\.\\" + comboBox_portName.Text + " -b 115200 \"" + textBox_bootloaderFilePath.Text + "\"";
                processInfo.UseShellExecute = false;
                Process process = Process.Start(processInfo);
                process.WaitForExit();
                process.Close();

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            #endregion

            #region Re-enable bootloader form controls

            textBox_bootloaderFilePath.Enabled = true;
            button_bootloaderBrowse.Enabled = true;
            button_bootloaderUpload.Enabled = true;
            button_bootloaderUpload.Text = "Upload";

            #endregion
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
                MessageBox.Show("Browser launch failed.", "Error");
            }
        }

        #endregion
    }
}
