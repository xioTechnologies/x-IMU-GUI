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
    /// ToggleButton class.
    /// </summary>
    public partial class ToggleButton : Button
    {
        /// <summary>
        /// Protected toggle state.
        /// </summary>
        protected bool toggleState;

        /// <summary>
        /// Protected prefix text used when toggle state is true.
        /// </summary>
        protected string truePrefixText;

        /// <summary>
        /// Protected prefix text used when toggle state is false.
        /// </summary>
        protected string falsePrefixText;

        /// <summary>
        /// Protected suffix text.
        /// </summary>
        protected string suffixText;

        /// <summary>
        /// Gets or sets the toggle state.
        /// </summary>
        public bool ToggleState
        {
            get
            {
                return toggleState;
            }
            set
            {
                toggleState = value;
                UpdateText();
            }
        }

        /// <summary>
        /// Gets or sets the prefix text used when toggle state is true.
        /// </summary>
        public string TruePrefixText
        {
            get
            {
                return truePrefixText;
            }
            set
            {
                truePrefixText = value;
                UpdateText();
            }
        }

        /// <summary>
        /// Gets or sets the prefix text used when toggle state is false.
        /// </summary>
        public string FalsePrefixText
        {
            get
            {
                return falsePrefixText;
            }
            set
            {
                falsePrefixText = value;
                UpdateText();
            }
        }

        /// <summary>
        /// Gets or sets the suffix text.
        /// </summary>
        public string SuffixText
        {
            get
            {
                return suffixText;
            }
            set
            {
                suffixText = value;
                UpdateText();
            }
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="ToggleButton"/> class.
        /// </summary>
        public ToggleButton()
        {
            InitializeComponent();
            toggleState = false;
            truePrefixText = "TruePrefixText";
            falsePrefixText = "FalsePrefixText";
            suffixText = "SuffixText";
            UpdateText();
        }

        /// <summary>
        /// Mouse click event toggles state and update text.
        /// </summary>
        protected override void OnClick(EventArgs e)
        {
            toggleState = !toggleState;
            UpdateText();
            base.OnClick(e);
        }

        /// <summary>
        /// Updates the button text.
        /// </summary>
        public void UpdateText()
        {
            this.Text = (toggleState ? TruePrefixText : FalsePrefixText) + suffixText;
        }
    }
}
