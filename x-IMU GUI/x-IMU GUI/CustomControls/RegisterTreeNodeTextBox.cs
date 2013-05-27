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
    /// RegisterTreeNodeTextBox class.
    /// </summary>
    public class RegisterTreeNodeTextBox : RegisterTreeNode
    {
        /// <summary>
        /// Gets or sets the TextBox.
        /// </summary>
        public TextBox TextBox { get; set; }

        /// <summary>
        /// Gets the TextBox as a Control.
        /// </summary>
        public override Control Control
        {
            get
            {
                return TextBox;
            }
        }

        /// <summary>
        /// Gets or sets the composite format string used by string.Format() method.
        /// </summary>
        public string NumberFormat { get; set; }

        /// <summary>
        /// Initializes a new instance of the RegisterTreeNodeTextBox class.
        /// </summary>
        /// <param name="registerAddress">
        /// Fixed register address of tree node. See x_IMU_API.RegisterAddresses.
        /// </param>
        /// <param name="text">
        /// The text of the new tree node.
        /// </param>
        public RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses registerAddress, string text)
            : this(registerAddress, text, "{0:g}")
        {
        }

        /// <summary>
        /// Initializes a new instance of the RegisterTreeNodeTextBox class.
        /// </summary>
        /// <param name="registerAddress">
        /// Fixed register address of tree node. See x_IMU_API.RegisterAddresses.
        /// </param>
        /// <param name="text">
        /// The text of the new tree node.
        /// </param>
        /// <param name="numberFormat">
        /// Composite format string used by string.Format() method.
        /// </param>
        public RegisterTreeNodeTextBox(x_IMU_API.RegisterAddresses registerAddress, string text, string numberFormat)
            : base(registerAddress, text)
        {
            TextBox = new TextBox();
            TextBox.Leave += new EventHandler(delegate { TextBox.Parent.Controls.Remove(TextBox); });
            TextBox.KeyPress += new KeyPressEventHandler(delegate(object sender, KeyPressEventArgs e) { if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-')) e.Handled = true; if (e.KeyChar == '\r') TextBox.Parent.Controls.Remove(TextBox); });
            TextBox.GotFocus += new EventHandler(delegate { TextBox.SelectAll(); });
            NumberFormat = numberFormat;
        }

        /// <summary>
        /// Converts RegisterTreeNodeTextBox register address and TextBox text to RegisterData object.
        /// </summary>
        /// <returns>
        /// RegisterData object.
        /// </returns>
        protected override x_IMU_API.RegisterData CreateRegisterData()
        {
            try
            {
                return new x_IMU_API.RegisterData(RegisterAddress, (float)Convert.ToDouble(TextBox.Text));
            }
            catch { }
            try
            { 
                return new x_IMU_API.RegisterData(RegisterAddress, Convert.ToUInt16(TextBox.Text));
            }
            catch { }
            return new x_IMU_API.RegisterData(RegisterAddress, ushort.Parse(TextBox.Text, System.Globalization.NumberStyles.HexNumber));
        }

        /// <summary>
        /// Applies RegisterData value to TextBox. 
        /// </summary>
        /// <param name="registerData">
        /// RegisterData object to be displayed by TextBox
        /// </param>
        protected override void ApplyRegisterData(x_IMU_API.RegisterData registerData)
        {
            try
            {
                TextBox.Text = string.Format(NumberFormat, registerData.ConvertValueToFloat());
            }
            catch
            {
                TextBox.Text = string.Format(NumberFormat, registerData.Value);
            }
        }
    }
}