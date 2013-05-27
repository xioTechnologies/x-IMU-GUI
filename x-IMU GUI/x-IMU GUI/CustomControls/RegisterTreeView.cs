using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace x_IMU_GUI
{
    /// <summary>
    /// RegisterTreeView class.
    /// </summary>
    public partial class RegisterTreeView : TreeView
    {
        /// <summary>
        /// Gets or sets a value indicating if a refresh is pending.
        /// </summary>
        public bool RefreshPending { get; set; }

        /// <summary>
        /// Initializes a new instance of the RegisterTreeView class.
        /// </summary>
        public RegisterTreeView()
        {
            InitializeComponent();
            DrawMode = TreeViewDrawMode.OwnerDrawText;
        }

        #region Override methods

        /// <summary>
        /// Override mouse click event to display appended Control on left-click.
        /// </summary>
        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SelectedNode = GetNodeAt(e.X, e.Y);
                if (SelectedNode is RegisterTreeNode)
                {
                    Controls.Add((SelectedNode as RegisterTreeNode).Control);
                    (SelectedNode as RegisterTreeNode).Control.Top = SelectedNode.Bounds.Top - 3;
                    (SelectedNode as RegisterTreeNode).Control.Left = SelectedNode.Bounds.Right;
                    (SelectedNode as RegisterTreeNode).Control.Show();
                    (SelectedNode as RegisterTreeNode).Control.Select();
                }
            }
            base.OnNodeMouseClick(e);
        }

        /// <summary>
        /// Override mouse wheel event to remove appended control on scroll.
        /// </summary>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (SelectedNode is RegisterTreeNode)
            {
                Controls.Remove((SelectedNode as RegisterTreeNode).Control);
            }
            base.OnMouseWheel(e);
        }

        /// <summary>
        /// Override process Windows messages event to remove appended control on scroll.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == 0x0114) | (m.Msg == 0x0115))  // WM_HSCROLL or WM_VSCROLL, see "\Program Files\Microsoft SDKs\Windows\v6.0A\Include\WinUser.h"
            {
                if (SelectedNode is RegisterTreeNode)
                {
                    Controls.Remove((SelectedNode as RegisterTreeNode).Control);
                }
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Override draw event to draw appended Control text to RegisterTreeNode.
        /// </summary>
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            if (e.Node is RegisterTreeNode)
            {
                e.Graphics.DrawString((e.Node as RegisterTreeNode).Control.Text, Font, new SolidBrush((e.Node as RegisterTreeNode).CreateTextColor()), e.Bounds.Right, e.Bounds.Top);
            }
            e.DrawDefault = true;
            base.OnDrawNode(e);
        }

        /// <summary>
        /// Override Refresh method to clear RefreshPending flag immediately before refresh.
        /// </summary>
        public override void Refresh()
        {
            RefreshPending = false;
            base.Refresh();
        }

        #endregion

        #region ApplyRegisterData methods

        /// <summary>
        /// Applys register to data to associated RegisterTreeNode.
        /// </summary>
        /// <param name="registerAddress">
        /// Register address of tree node. See x_IMU_API.RegisterAddresses.
        /// </param>
        /// <param name="isConfirmed">
        /// A value indicating if the register data being applied should be displayed as confirmed.
        /// </param>
        public void ApplyRegisterData(x_IMU_API.RegisterData registerData, bool isConfirmed)
        {
            RegisterTreeNode registerTreeNode = FindRegisterTreeNode(registerData.Address);
            if (registerTreeNode == null)
            {
                throw new Exception("Register address does have an associated RegisterTreeNode.");
            }
            registerTreeNode.SetFromRegisterData(registerData, isConfirmed);
            RefreshPending = true;
        }

        /// <summary>
        /// Finds RegisterTreeNode with register address.
        /// </summary>
        /// <param name="registerAddress">
        /// Register address of tree node.
        /// </param>
        /// <returns>
        /// RegisterTreeNode.
        /// </returns>
        private RegisterTreeNode FindRegisterTreeNode(x_IMU_API.RegisterAddresses registerAddress)
        {
            foreach (TreeNode childNode in Nodes)
            {
                RegisterTreeNode registerTreeNode = FindRegisterTreeNode(childNode, registerAddress);
                if (registerTreeNode != null)
                {
                    return registerTreeNode;
                }
            }
            return null;
        }

        /// <summary>
        /// Recursively searches for RegisterTreeNode with register address starting from a root TreeNode.
        /// </summary>
        /// <param name="rootNode">
        /// Root TreeNode that recursive search starts from.
        /// </param>
        /// <param name="registerAddress">
        /// Register address of tree node. See x_IMU_API.RegisterAddresses.
        /// </param>
        /// <returns>
        /// RegisterTreeNode.
        /// </returns>
        private RegisterTreeNode FindRegisterTreeNode(TreeNode rootNode, x_IMU_API.RegisterAddresses registerAddress)
        {
            foreach (TreeNode childNode in rootNode.Nodes)
            {
                if (childNode is RegisterTreeNode)
                {
                    if ((childNode as RegisterTreeNode).RegisterAddress == registerAddress)
                    {
                        return childNode as RegisterTreeNode;
                    }
                }
                else if (childNode.Nodes.Count > 0)
                {
                    RegisterTreeNode registerTreeNode = FindRegisterTreeNode(childNode, registerAddress);   // for all child nodes recursively
                    if (registerTreeNode != null)
                    {
                        return registerTreeNode;
                    }
                }
            }
            return null;
        }

        #endregion
    }
}