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
    /// A class that inherits from TreeNode and allows coloured text that may be edited with an appended control. Base class only, cannot be instantiated.
    /// </summary>
    public abstract class AppendedTreeNode : TreeNode
    {
        /// <summary>
        /// Color of text in appended control.
        /// </summary>
        protected Color textColor = Color.Black;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendedTreeNodeComboBox"/> class.
        /// </summary>
        public AppendedTreeNode()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppendedTreeNodeComboBox"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        public AppendedTreeNode(string text)
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
        public AppendedTreeNode(string text, TreeNode[] children)
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
        public AppendedTreeNode(SerializationInfo serializationInfo, StreamingContext context)
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
        public AppendedTreeNode(string text, int imageIndex, int selectedImageIndex)
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
        public AppendedTreeNode(string text, int imageIndex, int selectedImageIndex, TreeNode[] children)
            : base(text, imageIndex, selectedImageIndex, children) { }

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
    }
}
