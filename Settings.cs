using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using USB_Barcode_Scanner;
using System.IO;
using Newtonsoft.Json;
using USB_Barcode_Scanner_Tutorial___C_Sharp.Borrow_Return;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            InitializeApplication();
        }

        public void InitializeApplication()
        {
            FilePath_TXT.Text = "-";
        }
        public void GetFilePath()
        {
            FilePath_TXT.Text = GlobalVariable.FilePath;
        }
        private void DefaultPath_Click(object sender, EventArgs e)
        {
            string applicationDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MDT_Inventory");

            DialogResult result = MessageBox.Show
            ("ต้องการใช้ที่อยู่เก็บไฟล์เดิมหรือไม่?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                string oldpath = GlobalVariable.FilePath;
                string DataFolder = Path.Combine(applicationDataFolder, "PictureData");
                GlobalVariable.SetFilePath(DataFolder, oldpath);
                //UpdatePictureFilePath();
                MessageBox.Show("ที่อยู่ไฟล์ภาพของคุณถูกเปลี่ยน คุณจะต้องเริ่มการทำงานของโปรแกรมใหม่!\n" + "ที่อยู่ไฟล์ภาพล่าสุดอยู่ที่ : " + GlobalVariable.FilePath);
                FilePath_TXT.Text = GlobalVariable.FilePath;
                // Restart the application
                //Application.Restart();
                // Exit the current instance
                Environment.Exit(0);
            }
            else
            {
                // User clicked "No" or closed the dialog, do nothing or handle as needed
            }
        }

        private void Change_Pic_Container_Click(object sender, EventArgs e)
        {
            //GetExistingPath
            string applicationDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MDT_Inventory");
            object settingValue = Registry.GetValue("HKEY_CURRENT_USER\\Software\\MDT_Inventory", "PictureFilePath", null);
            string oldpath;
            if (settingValue != null)
            {
                // Use the setting value
                //GlobalVariable.SetFilePath(settingValue.ToString());
                oldpath = settingValue.ToString();
                // Do something with stringValue...
            }
            else
            {
                // Use the default value
                string DataFolder = Path.Combine(applicationDataFolder, "PictureData");
                oldpath = DataFolder;
            }

            // Create an instance of FolderBrowserDialog
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                // Set the initial directory (optional)
                folderDialog.SelectedPath = oldpath;

                // Show the dialog and capture the result
                DialogResult result = folderDialog.ShowDialog();

                // Check if the user clicked OK
                if (result == DialogResult.OK)
                {
                    // Use the selected folder path
                    string newpath = folderDialog.SelectedPath;
                    Console.WriteLine("Selected Folder: " + newpath);
                    GlobalVariable.SetFilePath(newpath, oldpath);
                    MessageBox.Show("ที่อยู่ไฟล์ภาพของคุณถูกเปลี่ยน คุณจะต้องเริ่มการทำงานของโปรแกรมใหม่!\n" + "ที่อยู่ไฟล์ภาพล่าสุดอยู่ที่ : " + newpath);
                    //FilePath_TXT.Text = path;
                    //Application.Restart();
                    // Exit the current instance
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Folder selection canceled.");
                }
            }
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
            }
        }
    }
}
