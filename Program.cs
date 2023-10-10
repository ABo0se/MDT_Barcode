using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainMenu());
        }
    }
    /// <summary>
    /// ////////////////////////////////////////////////////
    /// </summary>

    public class FontManager
    {
        private static FontManager _instance;
        private Font _originalFormFont; // Store the original font size for the form
        private Dictionary<Control, Font> _originalFontSizes = new Dictionary<Control, Font>(); // Store original font sizes for controls

        private FontManager()
        {
        }

        public static FontManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FontManager();
                }
                return _instance;
            }
        }

        public void StoreOriginalFontSizes(Control control)
        {
            // Store the original font size for the control
            _originalFontSizes[control] = control.Font;
        }

        public void AdaptFormFontSize(Form form, float newSize)
        {
            // Adapt the form's font size to the specified newSize
            form.Font = new Font(form.Font.FontFamily, newSize);

            // Restore individual font sizes for controls
            RestoreOriginalFontSizesRecursively(form);
        }

        private void RestoreOriginalFontSizesRecursively(Control control)
        {
            if (_originalFontSizes.ContainsKey(control))
            {
                // Restore the original font size for the control
                control.Font = _originalFontSizes[control];
            }

            foreach (Control childControl in control.Controls)
            {
                RestoreOriginalFontSizesRecursively(childControl); // Recursively restore font sizes for child controls
            }
        }
    }
}