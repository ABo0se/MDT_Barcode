using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class MainMenu : Form
    {
        public static List<Form> initializedForms = new List<Form>();
        ///////////////////////////////////
        public MainMenu()
        {
            InitializeComponent();
            InitializeAllForms();
            //FontUtility.ApplyEmbeddedFont(this);
        }
        private void InitializeAllForms()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] formTypes = assembly.GetTypes();
            FontUtility.ApplyEmbeddedFont(this);

            foreach (Type type in formTypes)
            {
                if (type.IsSubclassOf(typeof(Form)) && type != typeof(MainMenu))
                {
                    Form form = (Form)Activator.CreateInstance(type);
                    FontUtility.ApplyEmbeddedFont(form);
                    initializedForms.Add(form);
                    form.Hide();
                }
            }
        }
        private void AddItem_Click(object sender, EventArgs e)
        {
            AddItemP1 AddItemForm = initializedForms.Find(f => f is AddItemP1) as AddItemP1;
            if (AddItemForm != null)
            {
                AddItemForm.Show();
                AddItemForm.InitializeApplication();
            }
        }
        private void Search_Click(object sender, EventArgs e)
        {
            Search SearchForm = initializedForms.Find(f => f is Search) as Search;
            if (SearchForm != null)
            {
                SearchForm.Show();
            }
        }
        private void Manage_Click(object sender, EventArgs e)
        {
            ManageQR ManageQRForm = initializedForms.Find(f => f is ManageQR) as ManageQR;
            if (ManageQRForm != null)
            {
                ManageQRForm.Show();
                ManageQRForm.SearchDatainDB();
            }
        }
        private void Exit_Application(object sender, FormClosedEventArgs e)
        {
            foreach (Form form in initializedForms)
            {
                form.Close();// Close all initialized forms
            }
            Application.Exit();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            InitializeAllForms();
        }
    }
    public static class FontUtility
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx
            (IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);

        private static FontFamily ff;
        private static Font embeddedFont;
        private static Dictionary<Control, Font> originalFonts = new Dictionary<Control, Font>();

        public static void LoadFont()
        {
            byte[] fontArray = Properties.Resources.THSarabunNew;
            int datalength = Properties.Resources.THSarabunNew.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(datalength);
            Marshal.Copy(fontArray, 0, ptrData, datalength);

            uint cFonts = 0;

            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);
            PrivateFontCollection pfc = new PrivateFontCollection();

            pfc.AddMemoryFont(ptrData, datalength);
            Marshal.FreeCoTaskMem(ptrData);

            ff = pfc.Families[0];
            embeddedFont = new Font(ff, 15f, FontStyle.Regular);
        }

        public static void ApplyEmbeddedFont(Control control)
        {
            if (embeddedFont == null)
            {
                LoadFont();
            }

            // Store the original font for the control
            originalFonts[control] = control.Font;

            // Set the control's font using the embedded font
            control.Font = new Font(ff, control.Font.Size, FontStyle.Regular);

            // Recursively apply the font to child controls
            foreach (Control childControl in control.Controls)
            {
                ApplyEmbeddedFont(childControl);
            }
        }

        public static void RestoreOriginalFonts(Control control)
        {
            // Restore the original font for the control
            if (originalFonts.TryGetValue(control, out Font originalFont))
            {
                control.Font = originalFont;
            }

            // Recursively restore original fonts for child controls
            foreach (Control childControl in control.Controls)
            {
                RestoreOriginalFonts(childControl);
            }
        }
    }
}