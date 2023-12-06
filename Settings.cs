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
                string DataFolder = Path.Combine(applicationDataFolder, "PictureData");
                GlobalVariable.SetFilePath(DataFolder);
                UpdatePictureFilePath();
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
                //GlobalVariable.SetFilePath(settingValue.ToString());
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
                    GlobalVariable.SetFilePath(path);
                    MessageBox.Show("การเปลี่ยนที่อยู่ไฟล์เก็บภาพสำเร็จ!\n" + "ที่อยู๋ไฟล์ภาพล่าสุดอยู่ที่ : " + path);
                    FilePath_TXT.Text = path;
                    //
                    UpdatePictureFilePath();
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
        private void UpdatePictureFilePath()
        {
            List<SRResults> temporaryData = GetDataFromDB();
            Dictionary<string, List<RentHistory>> temporaryData2 = GetDataFromDB2();
            //////////////////////////////////////////////////////////////////////////////////////////////////
            //ChangeAllPathsInDB
            List<string> parentpath = new List<string>();
            if (temporaryData != null)
            {
                foreach (SRResults data in temporaryData)
                {
                    List<string> paths = JsonConvert.DeserializeObject<List<string>>(data.FilePath);

                    for (int i = paths.Count - 1; i >= 0; i--)
                    {
                        string oldparentpath = Path.GetDirectoryName(paths[i]);
                        if (!parentpath.Contains(oldparentpath) && Directory.Exists(oldparentpath) &&
                                (oldparentpath != GlobalVariable.FilePath))
                        {
                            parentpath.Add(oldparentpath);
                        }
                        string filename = Path.GetFileName(paths[i]);
                        string newPath = Path.Combine(GlobalVariable.FilePath, filename);
                        paths[i] = newPath;
                    }

                    data.FilePath = JsonConvert.SerializeObject(paths);
                }
            }
            if (temporaryData2 != null)
            {
                foreach (KeyValuePair<string, List<RentHistory>> data in temporaryData2)
                {
                    foreach (RentHistory mydata in data.Value)
                    {
                        List<string> paths = JsonConvert.DeserializeObject<List<string>>(mydata.ImageData);

                        for (int i = paths.Count - 1; i >= 0; i--)
                        {
                            string oldparentpath = Path.GetDirectoryName(paths[i]);
                            if (!parentpath.Contains(oldparentpath) && Directory.Exists(oldparentpath) &&
                                (oldparentpath != GlobalVariable.FilePath))
                            {
                                parentpath.Add(oldparentpath);
                            }
                            string filename = Path.GetFileName(paths[i]);
                            string newPath = Path.Combine(GlobalVariable.FilePath, filename);
                            paths[i] = newPath;
                        }

                        mydata.ImageData = JsonConvert.SerializeObject(paths);
                    }
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////////
            //MoveFileData
            // Old parent directory
            //string oldParentDirectory = @"C:\OldParent\";

            // New parent directory
            string newParentDirectory = GlobalVariable.FilePath;

            try
            {
                // Create the new directory if it doesn't exist
                if (!Directory.Exists(newParentDirectory))
                    Directory.CreateDirectory(newParentDirectory);

                // Get all files in the old parent directory
                foreach (string myparentpath in parentpath)
                {
                    string[] filesInOldParent = Directory.GetFiles(myparentpath);

                    // Move each file to the new parent directory
                    foreach (string filePathInOldParent in filesInOldParent)
                    {
                        // Get the file name
                        string fileName = Path.GetFileName(filePathInOldParent);

                        // Combine the new parent directory with the file name to form the new path
                        string newFilePath = Path.Combine(newParentDirectory, fileName);

                        // Move the file to the new location
                        File.Move(filePathInOldParent, newFilePath);

                        Console.WriteLine($"File '{fileName}' moved successfully.");
                    }

                    Console.WriteLine("All files moved successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error moving files: {ex.Message}");
                MessageBox.Show("ข้อผิดพลาด : " + ex.Message);
            }
        }
        private List<SRResults> GetDataFromDB()
        {
            List<SRResults> ResultDataList = new List<SRResults>();
            string connectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";

            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    mySqlConnection.Open();

                    string query = "SELECT * FROM information";

                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SRResults data2 = new SRResults
                                {
                                    BarcodeNumber = reader["BarcodeNumber"].ToString(),
                                    FilePath = reader["ImageData"].ToString(),
                                    SHA512 = reader["MD5_ImageValidityChecksum"].ToString()
                                };
                                ResultDataList.Add(data2);
                            }
                        }
                    }
                    mySqlConnection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex);
                }
                if (ResultDataList.Count <= 0)
                {
                    return null;
                }
                else
                {
                    return ResultDataList;
                }
            }
        }
        Dictionary<string, List<RentHistory>> GetDataFromDB2()
        {
            Dictionary<string, List<RentHistory>> ResultDataList = new Dictionary<string, List<RentHistory>>();
            List<RentResults> DataList = new List<RentResults>();
            string connectionString = "server=127.0.0.1; user=root; database=borrow_returning_system; password=";

            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    mySqlConnection.Open();

                    string query = "SELECT * FROM borrowing_info";

                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RentResults data2 = new RentResults
                                {
                                    BarcodeNumber = reader["BarcodeNumber"].ToString(),
                                    BarcodeHistoryListSerialized = reader["HistoryTextlog"].ToString()
                                };
                                DataList.Add(data2);
                            }
                        }
                    }
                    mySqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex);
                }
                if (DataList.Count <= 0)
                {
                    return null;
                }
                else
                {
                    foreach (RentResults Data in DataList)
                    {
                        if (Data.BarcodeHistoryListSerialized != "[]")
                        {
                            Data.BarcodeHistoryList = JsonConvert.DeserializeObject<List<RentHistory>>(Data.BarcodeHistoryListSerialized);
                            ResultDataList.Add(Data.BarcodeNumber, Data.BarcodeHistoryList);
                        }
                    }
                    if (ResultDataList.Count <= 0)
                    {
                        return null;
                    }
                    else
                    {
                        return ResultDataList;
                    }
                }

            }
        }
    }
}
