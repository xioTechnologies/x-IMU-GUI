using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Drawing;

namespace xIMU_GUI
{
    #region AppendedTreeView class

    /// <summary>
    /// Treeview control capable of having tree nodes with coloured text that may be edited with an appended control.  Text coloured red when modified by user.
    /// </summary>
    /// <remarks>
    /// DrawMode should not be altered from the default OwnerDrawText value.
    /// </remarks>
    public class AppendedTreeView : TreeView
    {

        #region Variables

        string originalAppendedText;
        AppendedTreeNode selectedAppendedTreeNode;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeView"/> class.
        /// </summary>
        public AppendedTreeView()
            : base()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawText;
        }

        #endregion

        #region Methods and events

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

        #endregion
    }

    #endregion

    #region AppendedTreeNode class

    /// <summary>
    /// A class that inherits from TreeNode and allows coloured text that may be edited with an appended control. Base class only, cannot be instantiated.
    /// </summary>
    public abstract class AppendedTreeNode : TreeNode
    {
        #region Variables

        protected Color textColor = Color.Black;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeComboBox"/> class.
        /// </summary>
        public AppendedTreeNode()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeComboBox"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        public AppendedTreeNode(string text)
            : base(text) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeComboBox"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="children">
        /// The children.
        /// </param>
        public AppendedTreeNode(string text, TreeNode[] children)
            : base(text, children) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeComboBox"/> class.
        /// </summary>
        /// <param name="serializationInfo">
        /// A <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> containing the data to deserialize the class.
        /// </param>
        /// <param name="context">
        /// The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> containing the source and destination of the serialized stream.
        /// </param>
        public AppendedTreeNode(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeComboBox"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="imageIndex">
        /// Index of the image.
        /// </param>
        /// <param name="selectedImageIndex">
        /// Index of the selected image.
        /// </param>
        public AppendedTreeNode(string text, int imageIndex, int selectedImageIndex)
            : base(text, imageIndex, selectedImageIndex) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeComboBox"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="imageIndex">
        /// Index of the image.
        /// </param>
        /// <param name="selectedImageIndex">
        /// Index of the selected image.
        /// </param>
        /// <param name="children">
        /// The children.
        /// </param>
        public AppendedTreeNode(string text, int imageIndex, int selectedImageIndex, TreeNode[] children)
            : base(text, imageIndex, selectedImageIndex, children) { }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the TextColor.
        /// </summary>
        /// <value>
        /// Color enumeration.
        /// </value>
        public virtual Color TextColor
        {
            get
            {
                return this.textColor;
            }
            set
            {
                this.textColor = value;
            }
        }

        #endregion
    }

    #endregion

    #region AppendedTreeNodeComboBox class

    /// <summary>
    /// A class that inherits from TreeNode and allows coloured text to be appended and edited with a ComboBox.
    /// </summary>
    public class AppendedTreeNodeComboBox : AppendedTreeNode
    {
        #region Variables

        private ComboBox comboBox = new ComboBox();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeComboBox"/> class.
        /// </summary>
        public AppendedTreeNodeComboBox()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeComboBox"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        public AppendedTreeNodeComboBox(string text)
            : base(text) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeComboBox"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="children">
        /// The children.
        /// </param>
        public AppendedTreeNodeComboBox(string text, TreeNode[] children)
            : base(text, children) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeComboBox"/> class.
        /// </summary>
        /// <param name="serializationInfo">
        /// A <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> containing the data to deserialize the class.
        /// </param>
        /// <param name="context">
        /// The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> containing the source and destination of the serialized stream.
        /// </param>
        public AppendedTreeNodeComboBox(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeComboBox"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="imageIndex">
        /// Index of the image.
        /// </param>
        /// <param name="selectedImageIndex">
        /// Index of the selected image.
        /// </param>
        public AppendedTreeNodeComboBox(string text, int imageIndex, int selectedImageIndex)
            : base(text, imageIndex, selectedImageIndex) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeComboBox"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="imageIndex">
        /// Index of the image.
        /// </param>
        /// <param name="selectedImageIndex">
        /// Index of the selected image.
        /// </param>
        /// <param name="children">
        /// The children.
        /// </param>
        public AppendedTreeNodeComboBox(string text, int imageIndex, int selectedImageIndex, TreeNode[] children)
            : base(text, imageIndex, selectedImageIndex, children) { }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the TextColor.
        /// </summary>
        /// <value>
        /// Color enumeration.
        /// </value>
        public override Color TextColor
        {
            get
            {
                return base.textColor;
            }
            set
            {
                base.textColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the ComboBox.  Provides access to all properties of the internal ComboBox.
        /// </summary>
        /// <example>
        /// For example,
        /// <code>
        /// AppendedTreeNodeComboBox node1 = new AppendedTreeNodeComboBox("Some text");
        /// node1.ComboBox.Items.Add("Some text");
        /// node1.ComboBox.Items.Add("Some more text");
        /// node1.IsDropDown = true; 
        /// </code>
        /// </example>
        /// <value>ComboBox object
        /// </value>
        public ComboBox ComboBox
        {
            get
            {
                return this.comboBox;
            }
            set
            {
                this.comboBox = value;
            }
        }

        #endregion
    }

    #endregion

    #region AppendedTreeNodeTextBox class

    /// <summary>
    /// A class that inherits from TreeNode and allows coloured text to be appended and edited with a TextBox.
    /// </summary>
    public class AppendedTreeNodeTextBox : AppendedTreeNode
    {
        #region Variables

        private TextBox textBox = new TextBox();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeTextBox"/> class.
        /// </summary>
        public AppendedTreeNodeTextBox()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeTextBox"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        public AppendedTreeNodeTextBox(string text)
            : base(text) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeTextBox"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="children">
        /// The children.
        /// </param>
        public AppendedTreeNodeTextBox(string text, TreeNode[] children)
            : base(text, children) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeTextBox"/> class.
        /// </summary>
        /// <param name="serializationInfo">
        /// A <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> containing the data to deserialize the class.
        /// </param>
        /// <param name="context">
        /// The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> containing the source and destination of the serialized stream.
        /// </param>
        public AppendedTreeNodeTextBox(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeTextBox"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="imageIndex">
        /// Index of the image.
        /// /param>
        /// <param name="selectedImageIndex">
        /// Index of the selected image.
        /// </param>
        public AppendedTreeNodeTextBox(string text, int imageIndex, int selectedImageIndex)
            : base(text, imageIndex, selectedImageIndex) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppendedTreeNodeTextBox"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="imageIndex">
        /// Index of the image.
        /// </param>
        /// <param name="selectedImageIndex">
        /// Index of the selected image.
        /// </param>
        /// <param name="children">
        /// The children.
        /// </param>
        public AppendedTreeNodeTextBox(string text, int imageIndex, int selectedImageIndex, TreeNode[] children)
            : base(text, imageIndex, selectedImageIndex, children) { }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the TextColor.
        /// </summary>
        /// <value>
        /// Color enumeration.
        /// </value>
        public override Color TextColor
        {
            get
            {
                return base.textColor;
            }
            set
            {
                base.textColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the TextBox.  Provides access to all properties of the internal TextBox.
        /// </summary>
        /// <example>
        /// For example,
        /// <code>
        /// AppendedTreeNodeTextBox node1 = new AppendedTreeNodeTextBox("Textbox label");
        /// node1.TextBox.MaxLength = 5;
        /// node1.TextBox.TextAlign = HorizontalAlignment.Right;
        /// </code>
        /// </example>
        /// <value>
        /// TextBox object.
        /// </value>
        public TextBox TextBox
        {
            get
            {
                return this.textBox;
            }
            set
            {
                this.textBox = value;
            }
        }

        #endregion
    }

    #endregion
}
