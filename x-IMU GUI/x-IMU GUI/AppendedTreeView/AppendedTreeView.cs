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
    /// Treeview control capable of having tree nodes with coloured text that may be edited with an appended control.  Text coloured red when modified by user.
    /// </summary>
    /// <remarks>
    /// DrawMode should not be altered from the default OwnerDrawText value.
    /// </remarks>
    public class AppendedTreeView : TreeView
    {
        /// <summary>
        /// Original text of appended control before it became 'editable'.
        /// </summary>
        string originalAppendedText;

        /// <summary>
        /// Selected AppendedTreeNode. 
        /// </summary>
        AppendedTreeNode selectedAppendedTreeNode;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendedTreeView"/> class.
        /// </summary>
        public AppendedTreeView()
            : base()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawText;
        }

        /// <summary>
        /// Overridden mouse click event to display appended form control on left-click.
        /// </summary>
        /// <param name="e">
        /// A TreeNodeMouseClickEventArgs that contains the event data.
        /// </param>
        /// <remarks>
        /// The tree view selected node will be set to that at the location of the cursor.
        /// </remarks> 
        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.SelectedNode = this.GetNodeAt(e.X, e.Y);
                if (e.Node is AppendedTreeNode)
                {
                    Control appendedControl = null;
                    if (e.Node is AppendedTreeNodeComboBox)
                    {
                        ((AppendedTreeNodeComboBox)this.SelectedNode).ComboBox.DropDownClosed += new EventHandler(AppendedComboBox_DropDownClosed);
                        appendedControl = (Control)((AppendedTreeNodeComboBox)this.SelectedNode).ComboBox;
                    }
                    else if (e.Node is AppendedTreeNodeTextBox)
                    {
                        ((AppendedTreeNodeTextBox)this.SelectedNode).TextBox.KeyPress += new KeyPressEventHandler(AppendedTextBox_KeyPress);
                        appendedControl = (Control)((AppendedTreeNodeTextBox)this.SelectedNode).TextBox;
                    }
                    selectedAppendedTreeNode = (AppendedTreeNode)e.Node;
                    originalAppendedText = appendedControl.Text;
                    this.Controls.Add(appendedControl);
                    appendedControl.Top = this.SelectedNode.Bounds.Top - 2;
                    appendedControl.Left = this.SelectedNode.Bounds.Right;
                    appendedControl.Leave += new EventHandler(AppendedControl_Leave);
                    appendedControl.Show();
                    appendedControl.Select();
                }
            }
            base.OnNodeMouseClick(e);
        }

        /// <summary>
        /// Overridden mouse wheel event to remove appended control on scroll.
        /// </summary>
        /// <param name="e">
        /// MouseEventArgs to process.
        /// </param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (this.SelectedNode is AppendedTreeNode)
            {
                RemoveAppendedControlFromSelectedNode();
            }
            base.OnMouseWheel(e);
        }

        /// <summary>
        /// Overridden processes Windows messages function to remove appended control on scroll.
        /// </summary>
        /// <param name="m">
        /// The Windows Message to process.
        /// </param>
        protected override void WndProc(ref Message m)
        {
            const int WM_HSCROLL = 0x0114;     // ID numbers found in "...Program Files\Microsoft SDKs\Windows\v6.0A\Include\WinUser.h"
            const int WM_VSCROLL = 0x0115;
            if ((m.Msg == WM_HSCROLL) | (m.Msg == WM_VSCROLL))
            {
                RemoveAppendedControlFromSelectedNode();
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Removes appended control from selected tree node.
        /// </summary>
        private void RemoveAppendedControlFromSelectedNode()
        {
            if (this.SelectedNode is AppendedTreeNode)
            {
                Control appendedControl = null;
                if (this.SelectedNode is AppendedTreeNodeComboBox)
                {
                    appendedControl = ((AppendedTreeNodeComboBox)this.SelectedNode).ComboBox;
                }
                else if (this.SelectedNode is AppendedTreeNodeTextBox)
                {
                    appendedControl = ((AppendedTreeNodeTextBox)this.SelectedNode).TextBox;
                }
                RemoveAppendedControl(appendedControl);
            }
        }

        /// <summary>
        /// Drop down list closed event to remove appended combobox.
        /// </summary>
        /// <param name="e">
        /// A EventArgs that contains the event data.
        /// </param> 
        private void AppendedComboBox_DropDownClosed(object sender, EventArgs e)
        {
            RemoveAppendedControl((Control)sender);
        }

        /// <summary>
        /// Key press closed event to remove appended textbox on cartridge return key press.
        /// </summary>
        /// <param name="e">
        /// A EventArgs that contains the event data.
        /// </param> 
        private void AppendedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') RemoveAppendedControl((Control)sender);
        }

        /// <summary>
        /// Leave event to remove appended contorl.
        /// </summary>
        /// <param name="e">
        /// A EventArgs that contains the event data.
        /// </param> 
        private void AppendedControl_Leave(object sender, EventArgs e)
        {
            RemoveAppendedControl((Control)sender);
        }

        /// <summary>
        /// Removes appended control.  To be called by control event.
        /// </summary>
        /// <param name="appendedControl">
        /// Appended control to be removed.
        /// </param>
        private void RemoveAppendedControl(Control appendedControl)
        {
            if (appendedControl is ComboBox)
            {
                ((ComboBox)appendedControl).DropDownClosed -= AppendedComboBox_DropDownClosed;
            }
            else if (appendedControl is TextBox)
            {
                ((TextBox)appendedControl).KeyPress -= AppendedTextBox_KeyPress;
            }
            appendedControl.Leave -= AppendedControl_Leave;
            this.Controls.Remove(appendedControl);
            if ((appendedControl.Text != originalAppendedText) && (selectedAppendedTreeNode != null)) selectedAppendedTreeNode.TextColor = Color.Red;   // appended text red if text modified
        }

        /// <summary>
        /// Overridden draw event to appended control to tree node.
        /// </summary>
        /// <param name="e">
        /// A DrawTreeNodeEventArgs that contains the event data.
        /// </param> 
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            if (e.Node is AppendedTreeNode)
            {
                Control appendedControl = null;
                if (e.Node is AppendedTreeNodeComboBox)
                {
                    appendedControl = ((AppendedTreeNodeComboBox)e.Node).ComboBox;
                }
                else if (e.Node is AppendedTreeNodeTextBox)
                {
                    appendedControl = ((AppendedTreeNodeTextBox)e.Node).TextBox;
                }
                e.Graphics.DrawString(appendedControl.Text, e.Node.TreeView.Font, new SolidBrush(((AppendedTreeNode)(e.Node)).TextColor), e.Bounds.Right, e.Bounds.Top);
            }
            e.DrawDefault = true;
            base.OnDrawNode(e);
        }
    }
}
