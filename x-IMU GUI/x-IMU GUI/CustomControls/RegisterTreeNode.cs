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
    /// RegisterTreeNode class
    /// </summary>
    public abstract class RegisterTreeNode : TreeNode
    {
        /// <summary>
        /// Confirmed register value.
        /// </summary>
        private string confirmedRegisterText;

        /// <summary>
        /// Gets the register address.
        /// </summary>
        public x_IMU_API.RegisterAddresses RegisterAddress { get; private set; }

        /// <summary>
        /// Gets the Control.
        /// </summary>
        public abstract Control Control { get; }

        /// <summary>
        /// Initializes a new instance of the RegisterTreeNode class.
        /// </summary>
        /// <param name="registerAddress">
        /// Fixed register address of tree node. See x_IMU_API.RegisterAddresses.
        /// </param>
        /// <param name="text">
        /// The text of the new tree node.
        /// </param>
        public RegisterTreeNode(x_IMU_API.RegisterAddresses registerAddress, string text)
            : base(text)
        {
            RegisterAddress = registerAddress;
            confirmedRegisterText = "";
        }

        /// <summary>
        /// Creates text colour that indicates if the current Control text matches the last confirmed register value.
        /// </summary>
        public Color CreateTextColor()
        {
            return (Control.Text == confirmedRegisterText) ? Color.Blue : Color.Red;
        }

        /// <summary>
        /// Converts RegisterTreeNode to RegisterData object.
        /// </summary>
        /// <returns>
        /// RegisterData object.
        /// </returns>
        public x_IMU_API.RegisterData ConvertToRegisterData()
        {
            try
            {
                return CreateRegisterData();
            }
            catch (Exception ex)
            {
                TreeNode parentTreeNode = Parent;
                string breadcrumb = "\"" + this.ToString().Substring("TreeNode: ".Length, this.ToString().Length - "TreeNode: ".Length) + "\"";
                do
                {
                    breadcrumb = "\"" + parentTreeNode.ToString().Substring("TreeNode: ".Length, parentTreeNode.ToString().Length - "TreeNode: ".Length) + "\"" + " > " + breadcrumb;
                    parentTreeNode = parentTreeNode.Parent;
                } while (parentTreeNode != null);
                throw new Exception(ex.Message + "  " + breadcrumb);
            }
        }

        /// <summary>
        /// Converts RegisterTreeNode register address and Control of inherited class to RegisterData object.
        /// </summary>
        /// <returns>
        /// RegisterData object.
        /// </returns>
        protected abstract x_IMU_API.RegisterData CreateRegisterData();

        /// <summary>
        /// Applies RegisterData value to Control of inherited class. 
        /// </summary>
        /// <param name="registerData">
        /// RegisterData object to be displayed by Control of inherited class.
        /// </param>
        public virtual void SetFromRegisterData(x_IMU_API.RegisterData registerData, bool isConfirmed)
        {
            if (registerData.Address != RegisterAddress)
            {
                throw new Exception("Regsiter address does not match RegisterTreeNode");
            }
            ApplyRegisterData(registerData);
            if (isConfirmed)
            {
                confirmedRegisterText = Control.Text;
            }
        }

        /// <summary>
        /// Applies RegisterData value to Control of inherited class. 
        /// </summary>
        /// <param name="registerData">
        /// RegisterData object to be displayed by Control of inherited class. 
        /// </param>
        protected abstract void ApplyRegisterData(x_IMU_API.RegisterData registerData);
    }
}