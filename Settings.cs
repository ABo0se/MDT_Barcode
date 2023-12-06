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
                //UpdatePictureFilePath();
                MessageBox.Show("ที่อยู่ไฟล์ภาพของคุณถูกเปลี่ยน คุณจะต้องเริ่มการทำงานของโปรแกรมใหม่!\n" + "ที่อยู๋ไฟล์ภาพล่าสุดอยู่ที่ : " + GlobalVariable.FilePath);
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
                    MessageBox.Show("ที่อยู่ไฟล์ภาพของคุณถูกเปลี่ยน คุณจะต้องเริ่มการทำงานของโปรแกรมใหม่!\n" + "ที่อยู๋ไฟล์ภาพล่าสุดอยู่ที่ : " + path);
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
        private void UpdatePictureFilePath()
        {
            List<SRResults> temporaryData = GetDataFromDB();
            Dictionary<string, List<RentHistory>> temporaryData2 = GetDataFromDB2();

            // Change all paths in the database
            UpdatePathsInDatabase(temporaryData, out List<string> ppath1);
            UpdatePathsInDatabase(temporaryData2, out List<string> ppath2);

            // Move files to the new parent directory
            MoveFilesToNewParentDirectory(ppath1);

            // Clean up and edit the database records
            EditmyDataBase(temporaryData);
            EditmyDataBase2(temporaryData2);
        }

        private void UpdatePathsInDatabase(List<SRResults> data, out List<string> parentPaths)
        {
            parentPaths = new List<string>();

            if (data != null)
            {
                foreach (SRResults result in data)
                {
                    List<string> paths = JsonConvert.DeserializeObject<List<string>>(result.FilePath);

                    for (int i = paths.Count - 1; i >= 0; i--)
                    {
                        string oldParentPath = Path.GetDirectoryName(paths[i]);

                        if (!parentPaths.Contains(oldParentPath) && Directory.Exists(oldParentPath))
                        {
                            parentPaths.Add(oldParentPath);
                        }

                        string filename = Path.GetFileName(paths[i]);
                        string newPath = Path.Combine(GlobalVariable.FilePath, filename);
                        paths[i] = newPath;
                    }

                    result.FilePath = JsonConvert.SerializeObject(paths);
                }
            }
        }

        private void UpdatePathsInDatabase(Dictionary<string, List<RentHistory>> data, out List<string> parentPaths)
        {
            parentPaths = new List<string>();
            if (data != null)
            {
                foreach (var entry in data)
                {
                    foreach (RentHistory rentHistory in entry.Value)
                    {
                        List<string> paths = JsonConvert.DeserializeObject<List<string>>(rentHistory.ImageData);

                        for (int i = paths.Count - 1; i >= 0; i--)
                        {
                            string oldParentPath = Path.GetDirectoryName(paths[i]);

                            if (!parentPaths.Contains(oldParentPath) && Directory.Exists(oldParentPath))
                            {
                                parentPaths.Add(oldParentPath);
                            }

                            string filename = Path.GetFileName(paths[i]);
                            string newPath = Path.Combine(GlobalVariable.FilePath, filename);
                            paths[i] = newPath;
                        }

                        rentHistory.ImageData = JsonConvert.SerializeObject(paths);
                    }
                }
            }
        }

        private void MoveFilesToNewParentDirectory(List<string> parentPaths)
        {
            string newParentDirectory = GlobalVariable.FilePath;

            try
            {
                // Create the new directory if it doesn't exist
                if (!Directory.Exists(newParentDirectory))
                {
                    Directory.CreateDirectory(newParentDirectory);
                }

                // Get all files in the old parent directories
                foreach (string parentPath in parentPaths)
                {
                    string[] filesInOldParent = Directory.GetFiles(parentPath);

                    // Move each file to the new parent directory
                    foreach (string filePathInOldParent in filesInOldParent)
                    {
                        // Get the file name
                        string fileName = Path.GetFileName(filePathInOldParent);

                        // Combine the new parent directory with the file name to form the new path
                        string newFilePath = Path.Combine(newParentDirectory, fileName);

                        if (!Directory.Exists(newFilePath))
                        {
                            File.Move(filePathInOldParent, newFilePath);
                            Console.WriteLine($"File '{fileName}' moved successfully.");
                        }
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
        private void EditmyDataBase(List<SRResults> Data)
        {
            if (Data == null) return;

            ////////////
            foreach (SRResults TempData in Data)
            {
                //Update in initinal database.
                string connectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";
                MySqlConnection mySqlConnection2 = new MySqlConnection(connectionString);

                try
                {
                    mySqlConnection2.Open();

                    string query = "UPDATE information SET " +
                   "MD5_ImageValidityChecksum = @MD5_ImageValidityChecksum, " +
                   "ImageData = @ImageData " +

                   "WHERE BarcodeNumber = @BarcodeNumberReplacement";


                    //if (PicFilePath == null)
                    //{
                    //    PicFilePath = "";
                    //}

                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection2))
                    {
                        cmd.Parameters.AddWithValue("@ImageData", TempData.FilePath);
                        cmd.Parameters.AddWithValue("@MD5_ImageValidityChecksum", TempData.SHA512);
                        //////////
                        cmd.Parameters.AddWithValue("@BarcodeNumberReplacement", TempData.BarcodeNumber);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            //MessageBox.Show("การปรับเปลี่ยนข้อมูลสำเร็จ!");
                        }
                        else
                        {
                            // MessageBox.Show("การปรับเปลี่ยนข้อมูลล้มเหลว");
                        }
                    }
                    mySqlConnection2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ข้อผิดพลาด : " + ex.Message);
                }
                ////////////////////////////////////////
                //Now we update picture in rent borrow database.
                string connectionString2 = "server=127.0.0.1; user=root; database=borrow_returning_system; password=";
                MySqlConnection mySqlConnection3 = new MySqlConnection(connectionString2);

                try
                {
                    mySqlConnection3.Open();

                    string query = "UPDATE borrowing_info SET " +
                   "MD5_ImageValidityChecksum = @MD5_ImageValidityChecksum, " +
                   "ImageData = @ImageData " +

                   "WHERE BarcodeNumber = @BarcodeNumberReplacement";


                    //if (PicFilePath == null)
                    //{
                    //    PicFilePath = "";
                    //}

                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection3))
                    {
                        cmd.Parameters.AddWithValue("@ImageData", TempData.FilePath);
                        cmd.Parameters.AddWithValue("@MD5_ImageValidityChecksum", TempData.SHA512);
                        //////////
                        cmd.Parameters.AddWithValue("@BarcodeNumberReplacement", TempData.BarcodeNumber);


                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            //MessageBox.Show("การปรับเปลี่ยนข้อมูลสำเร็จ!");
                        }
                        else
                        {
                            // MessageBox.Show("การปรับเปลี่ยนข้อมูลล้มเหลว");
                        }
                    }
                    mySqlConnection3.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ข้อผิดพลาด : " + ex.Message);
                }
            }
        }

        private void EditmyDataBase2(Dictionary<string, List<RentHistory>> Data)
        {
            if (Data == null) return;
            foreach (KeyValuePair<string, List<RentHistory>> TempData in Data)
            {
                string SerializedHistoryData = JsonConvert.SerializeObject(TempData.Value, Formatting.Indented);
                ////////////////////////////////////////
                //Now we update picture in rent borrow database.
                string connectionString2 = "server=127.0.0.1; user=root; database=borrow_returning_system; password=";
                MySqlConnection mySqlConnection3 = new MySqlConnection(connectionString2);

                try
                {
                    mySqlConnection3.Open();

                    string query = "UPDATE borrowing_info SET " +
                   "HistoryTextlog = @HistoryTextlog " +

                   "WHERE BarcodeNumber = @BarcodeNumberReplacement";


                    //if (PicFilePath == null)
                    //{
                    //    PicFilePath = "";
                    //}

                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection3))
                    {
                        cmd.Parameters.AddWithValue("@BarcodeNumberReplacement", TempData.Key);
                        cmd.Parameters.AddWithValue("@HistoryTextlog", SerializedHistoryData);
                        //////////

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            //MessageBox.Show("การปรับเปลี่ยนข้อมูลสำเร็จ!");
                        }
                        else
                        {
                            // MessageBox.Show("การปรับเปลี่ยนข้อมูลล้มเหลว");
                        }
                    }
                    mySqlConnection3.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ข้อผิดพลาด : " + ex.Message);
                }

            }

        }
    }
}
