using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace x_IMU_GUI
{
    /// <summary>
    /// SimpleOscilloscope class.
    /// </summary>
    /// <remarks>
    /// Requires Osc_DLL.dll version 2.8.2, see http://www.oscilloscope-lib.com/.
    /// </remarks> 
    public class SimpleOscilloscope
    {
        /// <summary>
        /// Private Oscilloscope.
        /// </summary>
        private Oscilloscope oscilloscope;

        /// <summary>
        /// Private caption text.
        /// </summary>
        private string privCaption;

        /// <summary>
        /// Gets or sets the Oscilloscope caption text.
        /// </summary>
        public string Caption
        {
            get
            {
                return privCaption;
            }
            set
            {
                if (value != privCaption)
                {
                    privCaption = value;
                    oscilloscope.Caption = privCaption;
                }
            }
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="SimpleOscilloscope"/> class.
        /// </summary>
        public SimpleOscilloscope(string caption, string scopeSettingsFileName)
        {
            oscilloscope = Oscilloscope.CreateScope(scopeSettingsFileName, "");
            Caption = caption;
        }

        /// <summary>
        /// Shows the Oscilloscope.
        /// </summary>
        public void ShowScope()
        {
            oscilloscope.ShowScope();
        }

        /// <summary>
        /// Hides the Oscilloscope.
        /// </summary>
        public void HideScope()
        {
            oscilloscope.HideScope();
        }

        /// <summary>
        /// Adds trace data to the Oscilloscope.
        /// </summary>
        public void AddScopeData(double beam1, double beam2, double beam3)
        {
            oscilloscope.AddScopeData(beam1, beam2, beam3);
        }
    }
}
