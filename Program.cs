using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using USB_Barcode_Scanner_Tutorial___C_Sharp.Borrow_Return;
using Org.BouncyCastle.Ocsp;
using System.Text.Json;
using PdfSharp.Pdf.Content.Objects;
using Microsoft.Win32;
using System.Diagnostics.Eventing.Reader;
using System.Threading;
using Org.BouncyCastle.Asn1.Mozilla;
using System.Collections;
using Google.Protobuf.WellKnownTypes;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    static class Program
    {
        public static DateChangeService service = new DateChangeService();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Run the main form
            service.previousDate = service.LoadLastUsedTime();
            // MessageBox.Show("Method called at: " + DateTime.Now);
            ///////////////
            GlobalVariable.GetCleanupData();
            bool cleanup = GlobalVariable.cleanuppath;
            //MessageBox.Show(cleanup.ToString());
            ///////////////
            service.CheckForDateChange(true, cleanup);
            GlobalVariable.SetCleanup(false);

            Application.Run(new MainMenu());
        }
    }

    public class DateChangeService
    {
        public DateTime previousDate;

        public void CheckForDateChange(bool isstartprogram, bool changefilepath)
        {
            DateTime currentDate = DateTime.Now.Date;

            // Check if the date has changed
            if (currentDate > previousDate || isstartprogram)
            {
                //// Perform actions for the new day
                //if (currentDate > previousDate)
                //    MessageBox.Show("The date has changed to the next day.");
                //if (isstartprogram)
                //    MessageBox.Show("We started program.");

                PerformOverProvisioningActions(isstartprogram, changefilepath);
                

                // Update the previous date
                previousDate = currentDate;
            }
        }
        public void SaveLastUsedTime(DateTime lastUsedTime)
        {
            //
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\MDT_Inventory", "LastUsedTime", lastUsedTime.ToString());
        }

        public DateTime LoadLastUsedTime()
        {
            object lutstring = Registry.GetValue("HKEY_CURRENT_USER\\Software\\MDT_Inventory", "LastUsedTime", null);
            if (lutstring != null)
            {
                if (DateTime.TryParse(lutstring.ToString(), out DateTime lastUsedTime))
                {
                    return lastUsedTime;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }

            // Default value if key or value not found
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\MDT_Inventory", "LastUsedTime", DateTime.MinValue.ToString());
            return DateTime.MinValue;
        }

        private void PerformOverProvisioningActions(bool isstartprogram, bool changefilepath)
        {
            // Your logic for the new day goes here
            Console.WriteLine("Performing actions for the new day...");
            if (isstartprogram)
            {
                GlobalVariable.GetPictureFilePath();
                CreateDataBase(); 
            }
            if (changefilepath)
            {
                UpdatePictureFilePath();
            }
            UpdateStatusDatabase();
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
            MoveFilesToNewParentDirectory(ppath2);

            // Cleanup duplicate data
            Dictionary<string, string> uniqueImage = CleanUpImageData(temporaryData, temporaryData2);
            List<string> UniqueImageFilePath = new List<string>(uniqueImage.Keys);
            List<string> UsedFilePath = new List<string>();

            // Cleanup duplicate data in the database
            CleanupDuplicateData(temporaryData, uniqueImage, out List<string> usedPath1);
            CleanupDuplicateData(temporaryData2, uniqueImage, out List<string> usedPath2);

            UsedFilePath = usedPath1.Union(usedPath2).ToList();

            if (UniqueImageFilePath.Count > UsedFilePath.Count)
            {
                DeleteExcessiveFile(UniqueImageFilePath, UsedFilePath);
            }

            // Edit the database records
            EditmyDataBase(temporaryData);
            EditmyDataBase2(temporaryData2);
        }

        private void DeleteExcessiveFile(List<string> UniqueImageFilePath, List<string> UsedFilePath)
        {
            foreach (string uniqueImagePath in UniqueImageFilePath)
            {
                // Check if the unique image path is not in the used file paths
                if (!UsedFilePath.Contains(uniqueImagePath))
                {
                    try
                    {
                        // Delete the file
                        File.Delete(uniqueImagePath);
                        Console.WriteLine($"File '{uniqueImagePath}' deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deleting file '{uniqueImagePath}': {ex.Message}");
                    }
                }
            }
        }

        private void MoveFilesToNewParentDirectory(List<string> parentPaths)
        {
            string oldDirectory = GlobalVariable.OldFilePath;
            if (oldDirectory != null)
            {
                parentPaths.Add(oldDirectory);
            }
            
            if (parentPaths == null)
                return;
            if (parentPaths.Count == 0) 
                return;

            string newParentDirectory = GlobalVariable.FilePath;
            
            string applicationDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MDT_Inventory");
            //string temporaryDataFolder = Path.Combine(applicationDataFolder, "TemporaryPictureData");

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
                    //MessageBox.Show("1");
                    // Move each JPEG image to the new parent directory
                    foreach (string filePathInOldParent in filesInOldParent)
                    {
                        //MessageBox.Show("2");
                        // Get the file name
                        string fileName = Path.GetFileName(filePathInOldParent);

                        // Combine the new parent directory with the file name to form the new path
                        string newFilePath = Path.Combine(newParentDirectory, fileName);

                        //MessageBox.Show((!Directory.Exists(newFilePath)).ToString());
                        //MessageBox.Show((!Directory.Exists(newFilePath)).ToString() + " / " + IsJpegImage(filePathInOldParent).ToString());
                        if (!Directory.Exists(newFilePath) && IsJpegImage(filePathInOldParent))
                        {
                            //MessageBox.Show("3");
                            File.Move(filePathInOldParent, newFilePath);
                            //MessageBox.Show($"File '{fileName}' moved successfully.");
                        }
                    }
                }
                GlobalVariable.SetFilePath(GlobalVariable.FilePath, null);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error moving files: {ex.Message}");
                MessageBox.Show("ข้อผิดพลาด : " + ex.Message);
            }
        }

        private static bool IsJpegImage(string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] header = new byte[2];
                    fs.Read(header, 0, 2);
                    // Check if the file has the JPEG magic number
                    return header[0] == 0xFF && header[1] == 0xD8;
                }
            }
            catch
            {
                return false; // An error occurred or the file is not accessible
            }
        }

        private void CleanupDuplicateData(List<SRResults> data, Dictionary<string, string> uniqueImage, out List<string> usedPath1)
        {
            usedPath1 = new List<string>();
            if (data == null || uniqueImage == null)
                return;
            foreach (SRResults result in data)
            {
                List<string> paths = JsonConvert.DeserializeObject<List<string>>(result.FilePath);
                List<string> sha512s = JsonConvert.DeserializeObject<List<string>>(result.SHA512);

                for (int i = paths.Count - 1; i >= 0; i--)
                {
                    string sha512 = sha512s[i];
                    if (uniqueImage.ContainsValue(sha512))
                    {
                        string newPath = uniqueImage.First(kvp => kvp.Value == sha512).Key;
                        paths[i] = newPath;
                        usedPath1.Add(newPath);
                    }
                    else
                    {
                        paths.RemoveAt(i);
                        sha512s.RemoveAt(i);
                    }
                }
                result.FilePath = JsonConvert.SerializeObject(paths);
                result.SHA512 = JsonConvert.SerializeObject(sha512s);
            }
        }

        private void CleanupDuplicateData(Dictionary<string, List<RentHistory>> data, Dictionary<string, string> uniqueImage, out List<string> usedPath2)
        {
            usedPath2 = new List<string>();
            if (data == null)
                return;
            foreach (var entry in data)
            {
                if (entry.Value != null)
                {
                    foreach (RentHistory rentHistory in entry.Value)
                    {
                        List<string> paths = JsonConvert.DeserializeObject<List<string>>(rentHistory.ImageData);
                        List<string> sha512s = JsonConvert.DeserializeObject<List<string>>(rentHistory.SHA512);

                        for (int i = paths.Count - 1; i >= 0; i--)
                        {
                            string sha512 = sha512s[i];
                            if (uniqueImage.ContainsValue(sha512))
                            {
                                string newPath = uniqueImage.First(kvp => kvp.Value == sha512).Key;
                                paths[i] = newPath;
                                usedPath2.Add(newPath);
                            }
                            else
                            {
                                paths.RemoveAt(i);
                                sha512s.RemoveAt(i);
                            }
                        }

                        rentHistory.ImageData = JsonConvert.SerializeObject(paths);
                        rentHistory.SHA512 = JsonConvert.SerializeObject(sha512s);
                    }
                }
            }
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
                    if (entry.Value != null)
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
        }

        Dictionary <string, List<RentHistory>> GetDataFromDB2()
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
                    MessageBox.Show("An error occurred: " + ex.Message);
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

        private void CreateDataBase()
        {
            try
            {
                string connectionString = "server=127.0.0.1; user=root; password=; charset=utf8;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Create the first database
                    string firstDatabaseName = "barcodedatacollector";
                    string createFirstDatabaseQuery = $"CREATE DATABASE IF NOT EXISTS {firstDatabaseName}";

                    using (MySqlCommand command = new MySqlCommand(createFirstDatabaseQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Create the second database
                    string secondDatabaseName = "Borrow_Returning_System";
                    string createSecondDatabaseQuery = $"CREATE DATABASE IF NOT EXISTS {secondDatabaseName}";

                    using (MySqlCommand command = new MySqlCommand(createSecondDatabaseQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Additional code for your application...

                    // Close the connection
                    connection.Close();
                }

                //////////////////////////////////////////////////////////////////////////////////////////////////////

                string connectionString2 = "server=127.0.0.1; user=root; database=barcodedatacollector; password=; charset=utf8;";
                using (MySqlConnection connection = new MySqlConnection(connectionString2))
                {
                    connection.Open();
                    string createTableQuery = "CREATE TABLE IF NOT EXISTS information ( " +
                                                "Time DATETIME DEFAULT CURRENT_TIMESTAMP, " +
                                                "BarcodeNumber VARCHAR(100), " +
                                                "Product_Name VARCHAR(100), " +
                                                "Model_Name VARCHAR(100), " +
                                                "Brand VARCHAR(100), " +
                                                "Serial_Number VARCHAR(100), " +
                                                "Price INT(30), " +
                                                "Room VARCHAR(100), " +
                                                "ImageData TEXT, " +
                                                "MD5_ImageValidityChecksum TEXT, " +
                                                "Note VARCHAR(200), " +
                                                "Status INT(1), " +
                                                "ITEM_CONDITION INT(1) " +
                                                ");";

                    using (MySqlCommand command = new MySqlCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    connection.Close();

                    string connectionString3 = "server=127.0.0.1; user=root; database=Borrow_Returning_System; password=; charset=utf8;";
                    using (MySqlConnection connection2 = new MySqlConnection(connectionString3))
                    {
                        connection2.Open();
                        string createTableQuery2 = "CREATE TABLE IF NOT EXISTS borrowing_info ( " +
                                                    "Time DATETIME DEFAULT CURRENT_TIMESTAMP, " +
                                                    "Initial_Borrow_Time DATETIME, " +
                                                    "EST_Return_Date DATETIME, " +
                                                    "ACTUAL_Return_Date DATETIME, " +
                                                    "BarcodeNumber VARCHAR(100), " +
                                                    "Product_Name VARCHAR(100), " +
                                                    "Borrower_Name VARCHAR(100), " +
                                                    "ImageData TEXT, " +
                                                    "MD5_ImageValidityChecksum TEXT, " +
                                                    "HistoryTextlog TEXT, " +
                                                    "Contact VARCHAR(200), " +
                                                    "Note VARCHAR(200), " +
                                                    "Status INT(1) " +
                                                    ");";

                        using (MySqlCommand command2 = new MySqlCommand(createTableQuery2, connection2))
                        {
                            command2.ExecuteNonQuery();
                        }
                        connection2.Close();
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("ไม่พบฐานข้อมูล XAMPP ทำงานอยู่");
                Environment.Exit(0);
                //MessageBox.Show("ข้อผิดพลาด : " + ex.Message);
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
                    MessageBox.Show("An error occurred: " + ex.Message);
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

        private Dictionary<string, string> CleanUpImageData(List<SRResults> DBdata, Dictionary<string, List<RentHistory>> DBdata2)
        {
            string applicationDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MDT_Inventory");
            //string DataFolder = Path.Combine(applicationDataFolder, "PictureData");
            string DataFolder = GlobalVariable.FilePath;
            string TemporaryDataFolder = Path.Combine(applicationDataFolder, "TemporaryPictureData");

            Dictionary<string, string> imageFiles = new Dictionary<string, string>();
            Dictionary<string, string> uniqueImageFiles = new Dictionary<string, string>();
            Dictionary<string, string> deleteFiles = new Dictionary<string, string>();

            List<string> SHA512DB = new List<string>();

            if (DBdata != null)
            {
                foreach (SRResults data in DBdata)
                {
                    List<string> SHA512DB2 = System.Text.Json.JsonSerializer.Deserialize<List<string>>(data.SHA512);
                    foreach (string SHA512 in SHA512DB2)
                    {
                        if (!SHA512DB.Contains(SHA512))
                        {
                            SHA512DB.Add(SHA512);
                        }
                    }
                }
            }
            if (DBdata2 != null)
            {
                foreach (KeyValuePair<string, List<RentHistory>> data in DBdata2)
                {
                    if (data.Value != null)
                    {
                        foreach (RentHistory mydata in data.Value)
                        {
                            List<string> SHA512DB2 = System.Text.Json.JsonSerializer.Deserialize<List<string>>(mydata.SHA512);
                            foreach (string SHA512 in SHA512DB2)
                            {
                                if (!SHA512DB.Contains(SHA512))
                                {
                                    SHA512DB.Add(SHA512);
                                }
                            }
                        }
                    }
                }
            }
            try
            {
                if (Directory.Exists(DataFolder))
                {
                    string[] files = Directory.GetFiles(DataFolder, "*.*", SearchOption.AllDirectories);

                    foreach (string file in files)
                    {
                        string extension = System.IO.Path.GetExtension(file).ToLower();

                        if (IsImageExtension(extension))
                        {
                            using (Image myImage = Image.FromFile(file))
                            {
                                string SHA512 = CalculateSHA512Checkone(myImage);
                                imageFiles.Add(file, SHA512);
                            }
                        }
                    }

                    foreach (KeyValuePair<string, string> fileDetail in imageFiles)
                    {
                        if (!uniqueImageFiles.Values.Contains(fileDetail.Value))
                        {
                            uniqueImageFiles.Add(fileDetail.Key, fileDetail.Value);
                        }
                        else
                        {
                            deleteFiles.Add(fileDetail.Key, fileDetail.Value);
                        }
                    }

                    foreach (string path in deleteFiles.Keys)
                    {
                        try
                        {
                            if (File.Exists(path))
                            {
                                File.Delete(path);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle exceptions related to file deletion, e.g., file in use
                            Console.WriteLine($"เกิดข้อผิดพลาดในการลบไฟล์ {path}: {ex.Message}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Directory not found: " + DataFolder);
                }
                ////////////////////////////////////////////////////////
                if (Directory.Exists(TemporaryDataFolder))
                {
                    DeleteAllPictures(TemporaryDataFolder);
                }
                else
                {
                    Console.WriteLine("Directory not found: " + TemporaryDataFolder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return uniqueImageFiles;
        }

        bool IsImageExtension(string extension)
        {
            // Define a list of common image extensions
            List<string> validExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

            // Check if the given extension is in the list of valid extensions
            return validExtensions.Contains(extension);
        }


        List<string> CalculateSHA512Checksum(List<Image> myImages)
        {
            List<string> sha512Values = new List<string>();
            foreach (Image image in myImages)
            {
                if (image != null)
                {
                    using (var sha512 = SHA512.Create())
                    using (var stream = new MemoryStream())
                    {
                        image.Save(stream, ImageFormat.Jpeg); // You can choose the appropriate format
                        stream.Seek(0, SeekOrigin.Begin); // Reset stream position

                        byte[] sha512ChecksumBytes = sha512.ComputeHash(stream);
                        string sha512Checksum = BitConverter.ToString(sha512ChecksumBytes).Replace("-", "").ToLower();
                        sha512Values.Add(sha512Checksum);
                    }
                }
            }
            return sha512Values;
        }
        string CalculateSHA512Checkone(Image myImage)
        {
            string SHA5122 = null;

            if (myImage != null)
            {
                using (var sha512 = SHA512.Create())
                using (var stream = new MemoryStream())
                {
                    myImage.Save(stream, ImageFormat.Jpeg); // You can choose the appropriate format
                    stream.Seek(0, SeekOrigin.Begin); // Reset stream position

                    byte[] sha512ChecksumBytes = sha512.ComputeHash(stream);
                    string sha512Checksum = BitConverter.ToString(sha512ChecksumBytes).Replace("-", "").ToLower();
                    SHA5122 = sha512Checksum;
                }
            }
            return SHA5122;
        }

        private void UpdateStatusDatabase()
        {
            //Phase 1 GetData
            List<RentResults> ResultDataList = new List<RentResults>();
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
                                    EstReturnDate = reader.GetDateTime("EST_Return_Date"),
                                    Status = reader.GetInt16("Status")
                                };
                                ResultDataList.Add(data2);
                            }
                        }
                    }
                    mySqlConnection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ข้อผิดพลาด : " + ex.Message);
                    return;
                    //return if error
                }
                ///////////////////////////////////////////////////////////////////////////////////////////////////
                //Phase 2 use data
                foreach (RentResults data in ResultDataList)
                {
                    //MessageBox.Show("EST : " + data.EstReturnDate.Value.Date.ToString());
                    //MessageBox.Show("NOW : " + DateTime.Now.Date.ToString());
                    if (data.EstReturnDate.Value.Date < DateTime.Now.Date && data.Status == 0)
                    {
                        //MessageBox.Show("Working");
                        data.Status = 1;
                    }
                }
                ///////////////////////////////////////////////////////////////////////////////////////////////////
                //Phase 3 update data
                foreach (RentResults data in ResultDataList)
                {
                    string connectionString2 = "server=127.0.0.1; user=root; database=borrow_returning_system; password=";
                    MySqlConnection mySqlConnection3 = new MySqlConnection(connectionString2);

                    try
                    {
                        mySqlConnection3.Open();

                        string query = "UPDATE borrowing_info SET " +
                       "Status = @Status " +

                       "WHERE BarcodeNumber = @BarcodeNumberReplacement";


                        //if (PicFilePath == null)
                        //{
                        //    PicFilePath = "";
                        //}

                        using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection3))
                        {
                            cmd.Parameters.AddWithValue("@@Status", data.Status);
                            //////////
                            cmd.Parameters.AddWithValue("@BarcodeNumberReplacement", data.BarcodeNumber);


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


        public void DeleteAllPictures(string folderPath)
        {
            try
            {
                // Get all file paths in the folder with a specific extension (e.g., ".jpg")
                string[] pictureFiles = Directory.GetFiles(folderPath, "*.jpg");

                foreach (string filePath in pictureFiles)
                {
                    // Delete each file
                    File.Delete(filePath);
                }

                Console.WriteLine("All pictures deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting pictures: {ex.Message}");
            }
        }
    }
    public static class GlobalVariable
    {
        // Auto-implemented property to store some data
        public static string OldFilePath { get; set; }
        public static string FilePath { get; set; }
        //public static string DefaultPath = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MDT_Inventory"), "PictureData");
        public static bool cleanuppath { get; set; }
        // Add other methods and properties as needed
        public static void SetCleanup(bool mybool)
        {
            cleanuppath = mybool;
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\MDT_Inventory", "Cleanup", cleanuppath ? 1 : 0, RegistryValueKind.DWord);
        }
        public static void GetCleanupData()
        {
            try
            {
                object registryValue = Registry.GetValue("HKEY_CURRENT_USER\\Software\\MDT_Inventory", "Cleanup", null);

                if (registryValue != null)
                {
                    int intValue = Convert.ToInt32(registryValue);
                    bool myBoolValue = (intValue == 1);
                    cleanuppath = myBoolValue;
                }
                else
                {
                    cleanuppath = false;
                    //MessageBox.Show("Registry value not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"ข้อผิดพลาด : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void SetFilePath(string path, string oldPath)
        {
            // Code to perform some action using MyVariable and FilePath
            if (oldPath != null && Directory.Exists(oldPath))
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\MDT_Inventory", "OldFilePath", oldPath);
                OldFilePath = oldPath;
            }
            else
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\MDT_Inventory", true))
                {
                    if (key != null)
                    {
                        // Delete the specified value (subkey)
                        object registryValue = Registry.GetValue("HKEY_CURRENT_USER\\Software\\MDT_Inventory", "OldFilePath", null);
                        if (registryValue != null)
                        {
                            key.DeleteValue("OldFilePath");
                            OldFilePath = null;
                        }
                        else
                        {
                            OldFilePath = null;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Key not found");
                        OldFilePath = null;
                    }
                }
            }
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\MDT_Inventory", "PictureFilePath", path);
            FilePath = path;
        }
        public static void GetPictureFilePath()
        {
            string applicationDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MDT_Inventory");
            //GetTemporaryDataPath
            string temporaryDataFolder = Path.Combine(applicationDataFolder, "TemporaryPictureData");
            //GetExistingPath
            object currentpath = Registry.GetValue("HKEY_CURRENT_USER\\Software\\MDT_Inventory", "PictureFilePath", null);
            object oldpath = Registry.GetValue("HKEY_CURRENT_USER\\Software\\MDT_Inventory", "OldFilePath", null);
            string path;
            if (currentpath != null)
            {
                // Use the setting value
                if (oldpath != null)
                {
                    if (Directory.Exists(oldpath.ToString()))
                    {
                        SetFilePath(currentpath.ToString(), oldpath.ToString());
                        path = currentpath.ToString();
                    }
                    else
                    {
                        SetFilePath(currentpath.ToString(), null);
                        path = currentpath.ToString();
                    }
                }
                else
                {
                    SetFilePath(currentpath.ToString(), null);
                    path = currentpath.ToString();
                }
                // Do something with stringValue...
            }
            else
            {
                // Use the default value
                string DataFolder = Path.Combine(applicationDataFolder, "PictureData");
                //
                SetFilePath(DataFolder, null);
                path = DataFolder;
            }
            //Create path if not exist.
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!Directory.Exists(temporaryDataFolder))
            {
                Directory.CreateDirectory(temporaryDataFolder);
            }
        }
    }
}
