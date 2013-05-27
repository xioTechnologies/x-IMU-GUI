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
    /// A class that inherits from TreeNode and allows coloured text to be appended and edited with a TextBox.
    /// </summary>
    public class AppendedTreeNodeTextBox : AppendedTreeNode
    {
        /// <summary>
        /// TextBox object appended to TreeNode.
        /// </summary>
        private TextBox textBox = new TextBox();

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendedTreeNodeTextBox"/> class.
        /// </summary>
        public AppendedTreeNodeTextBox()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendedTreeNodeTextBox"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        public AppendedTreeNodeTextBox(string text)
            : base(text) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendedTreeNodeTextBox"/> class.
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
        /// Initializes a new instance of the <see cref="AppendedTreeNodeTextBox"/> class.
        /// </summary>
        /// <param name="serializationInfo">
        /// A <see cref="System.Runtime.Serialization.SerializationInfo"></see> containing the data to deserialize the class.
        /// </param>
        /// <param name="context">
        /// The <see cref="System.Runtime.Serialization.StreamingContext"></see> containing the source and destination of the serialized stream.
        /// </param>
        public AppendedTreeNodeTextBox(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendedTreeNodeTextBox"/> class.
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
        /// Initializes a new instance of the <see cref="AppendedTreeNodeTextBox"/> class.
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
    }
}
