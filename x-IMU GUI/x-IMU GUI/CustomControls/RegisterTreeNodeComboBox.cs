using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Drawing;

namespace x_IMU_GUI
{
    /// <summary>
    /// RegisterTreeNodeComboBox class.
    /// </summary>
    public class RegisterTreeNodeComboBox : RegisterTreeNode
    {
        /// <summary>
        /// Gets or sets the ComboBox.
        /// </summary>
        public ComboBox ComboBox { set; get; }

        /// <summary>
        /// Gets the ComboBox as a Control object.
        /// </summary>
        public override Control Control
        {
            get
            {
                return ComboBox;
            }
        }

        /// <summary>
        /// Initializes a new instance of the RegisterTreeNodeComboBox class.
        /// </summary>
        /// <param name="registerAddress">
        /// Fixed register address of tree node. See x_IMU_API.RegisterAddresses.
        /// </param>
        /// <param name="text">
        /// The text of the new tree node.
        /// </param>
        public RegisterTreeNodeComboBox(x_IMU_API.RegisterAddresses registerAddress, string text)
            : base(registerAddress, text)
        {
            ComboBox = new ComboBox();
            ComboBox.Leave += new EventHandler(delegate { ComboBox.Parent.Controls.Remove(ComboBox); });
            ComboBox.DropDownClosed += new EventHandler(delegate { ComboBox.Parent.Controls.Remove(ComboBox); });
        }

        /// <summary>
        /// Converts RegisterTreeNodeComboBox to RegisterData object.
        /// </summary>
        /// <returns>
        /// RegisterData object.
        /// </returns>
        protected override x_IMU_API.RegisterData CreateRegisterData()
        {
            if (ComboBox.SelectedIndex == -1)
            {
                throw new Exception("Item not selected.");
            }
            return new x_IMU_API.RegisterData(RegisterAddress, (ushort)ComboBox.SelectedIndex);
        }

        /// <summary>
        /// Applies RegisterData value to ComboBox. 
        /// </summary>
        /// <param name="registerData">
        /// RegisterData object to be displayed by ComboBox
        /// </param>
        protected override void ApplyRegisterData(x_IMU_API.RegisterData registerData)
        {
            ComboBox.SelectedIndex = (int)registerData.Value;
        }
    }
}