using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using USB_Barcode_Scanner;
using System.IO;

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

        private void DefaultPath_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show
            ("ต้องการใช้ที่อยู่เก็บไฟล์เดิมหรือไม่?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                
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
            string path;
            if (settingValue != null)
            {
                // Use the setting value
                GlobalVariable.SetFilePath(settingValue.ToString());
                path = settingValue.ToString();
                // Do something with stringValue...
            }
            else
            {
                // Use the default value
                string DataFolder = Path.Combine(applicationDataFolder, "PictureData");
                path = DataFolder;
            }
            
            // Create an instance of FolderBrowserDialog
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                // Set the initial directory (optional)
                folderDialog.SelectedPath = path;

                // Show the dialog and capture the result
                DialogResult result = folderDialog.ShowDialog();

                // Check if the user clicked OK
                if (result == DialogResult.OK)
                {
                    // Use the selected folder path
                    path = folderDialog.SelectedPath;
                    Console.WriteLine("Selected Folder: " + path);
                    
                    MessageBox.Show("การเปลี่ยนที่อยู่ไฟล์เก็บภาพสำเร็จ!\n" + "ที่อยู๋ไฟล์ภาพล่าสุดอยู่ที่ : " + path);
                    FilePath_TXT.Text = path;
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
