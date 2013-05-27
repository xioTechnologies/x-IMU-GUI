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
    /// ShowHideButton class.
    /// </summary>
    public partial class ShowHideButton : ToggleButton
    {
        /// <summary>
        /// Gets or sets the <see cref="Object"/> associated with the <see cref="ShowHideButton"/>. Can be a Form or <see cref="SimpleOscilloscope"/>.
        /// </summary>
        public Object Object { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="ShowHideButton"/> class.
        /// </summary>
        public ShowHideButton()
        {
            InitializeComponent();
            Object = null;
            truePrefixText = "Hide ";
            falsePrefixText = "Show ";
            suffixText = "Object";
        }

        /// <summary>
        /// Mouse click event toggles visibility state of Object.
        /// </summary>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (Object is Form)
            {
                (Object as Form).Visible = toggleState;
            }
            else if (Object is SimpleOscilloscope)
            {
                if (toggleState)
                {
                    (Object as SimpleOscilloscope).ShowScope();
                }
                else
                {
                    (Object as SimpleOscilloscope).HideScope();
                }
            }
        }
    }
}