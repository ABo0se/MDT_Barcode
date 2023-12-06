using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using USB_Barcode_Scanner_Tutorial___C_Sharp.Borrow_Return;

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
            //FontUtility.ApplyEmbeddedFont(this);

            foreach (Type type in formTypes)
            {
                if (type.IsSubclassOf(typeof(Form)) && type != typeof(MainMenu))
                {
                    Form form = (Form)Activator.CreateInstance(type);
                    //FontUtility.ApplyEmbeddedFont(form);
                    initializedForms.Add(form);
                    form.Hide();
                }
            }
        }
        private void AddItem_Click(object sender, EventArgs e)
        {
            AddItemP2 AddItemForm = initializedForms.Find(f => f is AddItemP2) as AddItemP2;
            if (AddItemForm != null)
            {
                AddItemForm.Show();
                AddItemForm.InitializePage();
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

        private void Borrow_Return_Manager_Click(object sender, EventArgs e)
        {
            ManageBorrowedItem ManageQRForm = initializedForms.Find(f => f is ManageBorrowedItem) as ManageBorrowedItem;
            if (ManageQRForm != null)
            {
                ManageQRForm.Show();
                ManageQRForm.SearchDatainDB();
            }
        }

        private void Borrow_Return_System_Click(object sender, EventArgs e)
        {
            Borrow_BarcodeIDChecker ManageQRForm = initializedForms.Find(f => f is Borrow_BarcodeIDChecker) as Borrow_BarcodeIDChecker;
            if (ManageQRForm != null)
            {
                ManageQRForm.Show();
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Settings Setting = initializedForms.Find(f => f is Settings) as Settings;
            if (Setting != null)
            {
                Setting.Show();
            }
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
            embeddedFont = new Font(ff, 16f, FontStyle.Regular);
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

            // If the control is a DataGridView, apply the font to its cells
            if (control is DataGridView dataGridView)
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Style != null && cell.Style.Font != null)
                        {
                            cell.Style.Font = new Font(ff, 16.0f, FontStyle.Regular);
                        }
                    }
                }
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