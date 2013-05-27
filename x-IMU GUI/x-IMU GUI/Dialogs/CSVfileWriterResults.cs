using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace x_IMU_GUI
{
    /// <summary>
    /// CSVfileWriterResults class.
    /// </summary>
    public class CSVfileWriterResults
    {
        /// <summary>
        /// Shows <see cref="CSVfileWriter"/> packet counts and file names in <see cref="PassiveMessageBox"/>.
        /// </summary>
        /// <param name="CSVfileWriter">
        /// <see cref="CSVfileWriter"/> object.
        /// </param>
        public static void Show(x_IMU_API.CSVfileWriter CSVfileWriter)
        {
            Show(CSVfileWriter, "CSVfileWriterResults");
        }

        /// <summary>
        /// Shows <see cref="CSVfileWriter"/> packet counts and file names in <see cref="PassiveMessageBox"/>.
        /// </summary>
        /// <param name="CSVfileWriter">
        /// <see cref="CSVfileWriter"/> object.
        /// </param>
        /// <param name="caption">
        /// Caption of <see cref="PassiveMessageBox"/>.
        /// </param>
        public static void Show(x_IMU_API.CSVfileWriter CSVfileWriter, string caption)
        {
            string dialogText = "No files were created.";

            if (CSVfileWriter.FilesCreated.Length != 0)
            {
                int maxWidth = 0;

                // Measure x_IMU_API.PacketCount property names with a non-zero value for tab spacing
                foreach (PropertyInfo propertyInfo in CSVfileWriter.PacketsWrittenCounter.GetType().GetProperties())
                {
                    if ((int)propertyInfo.GetValue(CSVfileWriter.PacketsWrittenCounter, null) > 0)
                    {
                        int width = TextRenderer.MeasureText(propertyInfo.Name + ":", Control.DefaultFont).Width;
                        maxWidth = width > maxWidth ? width : maxWidth;
                    }
                }

                // Add all property names with a non-zero to dialog text with tab spacing.
                dialogText = "";
                foreach (PropertyInfo propertyInfo in CSVfileWriter.PacketsWrittenCounter.GetType().GetProperties())
                {
                    if ((int)propertyInfo.GetValue(CSVfileWriter.PacketsWrittenCounter, null) > 0)
                    {
                        string lineText = propertyInfo.Name + ":";
                        while (TextRenderer.MeasureText(lineText, Control.DefaultFont).Width < maxWidth)
                        {
                            lineText += " ";
                        }
                        dialogText += lineText + "\t" + propertyInfo.GetValue(CSVfileWriter.PacketsWrittenCounter, null).ToString() + Environment.NewLine;
                    }
                }

                // Add list of file names to dialog text
                dialogText += Environment.NewLine + "Files created:" + Environment.NewLine;
                foreach (string fileName in CSVfileWriter.FilesCreated)
                {
                    dialogText += fileName + Environment.NewLine;
                }
                if (CSVfileWriter.FilesCreated.Length == 0)
                {
                    dialogText += "None.";
                }
            }

            // Display dialog text in PassiveMessageBox
            PassiveMessageBox.Show(dialogText, caption, MessageBoxIcon.Information);
        }
    }
}
