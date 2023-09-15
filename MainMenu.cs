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

            foreach (Type type in formTypes)
            {
                if (type.IsSubclassOf(typeof(Form)) && type != typeof(MainMenu))
                {
                    Form form = (Form)Activator.CreateInstance(type);
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
            //
            FontUtility.LoadFont();
            FontUtility.AllocatemyFont(FontUtility.font, AddItem, AddItem.Font.Size);
        }
    }
    public static class FontUtility
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx
            (IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);

        static FontFamily ff;
        public static Font font;

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
            font = new Font(ff, 15f, FontStyle.Regular);
        }
        public static void AllocatemyFont(Font f, Control c, float size)
        {
            FontStyle fontStyle = FontStyle.Regular;
            c.Font = new Font(ff, 20, fontStyle);
        }
    }
}