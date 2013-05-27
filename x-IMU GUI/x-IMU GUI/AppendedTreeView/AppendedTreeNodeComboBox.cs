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
    /// A class that inherits from TreeNode and allows coloured text to be appended and edited with a ComboBox.
    /// </summary>
    public class AppendedTreeNodeComboBox : AppendedTreeNode
    {
        /// <summary>
        /// ComboBox object appended to TreeNode.
        /// </summary>
        private ComboBox comboBox = new ComboBox();

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendedTreeNodeComboBox"/> class.
        /// </summary>
        public AppendedTreeNodeComboBox()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendedTreeNodeComboBox"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        public AppendedTreeNodeComboBox(string text)
            : base(text) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendedTreeNodeComboBox"/> class.
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
        /// Initializes a new instance of the <see cref="AppendedTreeNodeComboBox"/> class.
        /// </summary>
        /// <param name="serializationInfo">
        /// A <see cref="System.Runtime.Serialization.SerializationInfo"></see> containing the data to deserialize the class.
        /// </param>
        /// <param name="context">
        /// The <see cref="System.Runtime.Serialization.StreamingContext"></see> containing the source and destination of the serialized stream.
        /// </param>
        public AppendedTreeNodeComboBox(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendedTreeNodeComboBox"/> class.
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
        /// Initializes a new instance of the <see cref="AppendedTreeNodeComboBox"/> class.
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
    }
}
