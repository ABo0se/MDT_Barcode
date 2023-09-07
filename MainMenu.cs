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
        }
        public void Font_Load()
        {
            // Load the embedded font
            PrivateFontCollection privateFonts = new PrivateFontCollection();
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fontStream = assembly.GetManifestResourceStream("YourAppName.Properties.Resources.THSarabunNew_Font");// Replace with the correct resource name
            byte[] fontData = new byte[fontStream.Length];
            fontStream.Read(fontData, 0, (int)fontStream.Length);
            fontStream.Close();
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            privateFonts.AddMemoryFont(fontPtr, fontData.Length);

            // Set the form's font to the loaded custom font
            Font customFont = new Font(privateFonts.Families[0], 12.0f); // Replace 12.0f with your desired font size
            this.Font = customFont;

            // Use the FontManager to store original font sizes
            FontManager.Instance.StoreOriginalFontSizes(this);

            // Set the custom font for individual controls (e.g., myLabel)
            myLabel.Font = customFont;
        }

    }
}
