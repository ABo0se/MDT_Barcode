﻿using System;
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
using iTextSharp.text.pdf.parser;


namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize the host
            using (var host = CreateHostBuilder().Build())
            {
                // Start the background service
                var dateChangeService = host.Services.GetRequiredService<DateChangeService>();
                dateChangeService.CheckForDateChange(); // Run the initial check
                host.Start();

                // Run the main form
                Application.Run(new MainMenu());

                // Stop the host when the main form is closed
                host.StopAsync().Wait();
            }
        }

        public static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<DateChangeService>();
                    // Other service configurations...
                });
        }
    }

    public class DateChangeService : BackgroundService
    {
        private DateTime previousDate = DateTime.MinValue;

        protected override async Task ExecuteAsync(System.Threading.CancellationToken stoppingToken)
        {
            // Load the last used time when the service starts
            LoadLastUsedTime();

            while (!stoppingToken.IsCancellationRequested)
            {
                CheckForDateChange();

                // Save the last used time at regular intervals
                SaveLastUsedTime();

                // Adjust the interval as needed
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

        public void CheckForDateChange()
        {
            DateTime currentDate = DateTime.Now.Date;

            // Check if the date has changed
            if (currentDate > previousDate)
            {
                // Perform actions for the new day
                PerformOverProvisioningActions();
                Console.WriteLine("The date has changed to the next day.");

                // Update the previous date
                previousDate = currentDate;
            }
        }

        private void PerformOverProvisioningActions()
        {
            // Your logic for the new day goes here
            Console.WriteLine("Performing actions for the new day...");
            UpdatePictureFilePath();
            UpdateStatusDatabase();
        }

        private void UpdatePictureFilePath()
        {
            Dictionary<string, string> uniqueImage = CleanUpImageData();
            List<SRResults> temporaryData = GetDataFromDB();
            if (temporaryData == null) return;

            foreach (SRResults data in temporaryData)
            {
                List<string> paths = JsonConvert.DeserializeObject<List<string>>(data.FilePath);
                List<string> sha512s = JsonConvert.DeserializeObject<List<string>>(data.SHA512);

                for (int i = paths.Count - 1; i >= 0; i--)
                {
                    string sha512 = sha512s[i];
                    if (uniqueImage.ContainsValue(sha512))
                    {
                        string newPath = uniqueImage.First(kvp => kvp.Value == sha512).Key;
                        paths[i] = newPath;
                    }
                    else
                    {
                        paths.RemoveAt(i);
                        sha512s.RemoveAt(i);
                    }
                }

                data.FilePath = JsonConvert.SerializeObject(paths);
                data.SHA512 = JsonConvert.SerializeObject(sha512s);
            }
            EditmyDataBase(temporaryData);
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
                    MessageBox.Show("ข้อผิดพลาด : " + ex);
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
                    MessageBox.Show("ข้อผิดพลาด : " + ex);
                }
            }
        }

        private Dictionary<string, string> CleanUpImageData()
        {
            string directoryPath = @"C:\\BarcodeDatabaseImage";
            Dictionary<string, string> imageFiles = new Dictionary<string, string>();
            Dictionary<string, string> uniqueImageFiles = new Dictionary<string, string>();
            Dictionary<string, string> deleteFiles = new Dictionary<string, string>();

            try
            {
                if (Directory.Exists(directoryPath))
                {
                    string[] files = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);

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
                            Console.WriteLine($"Error deleting file {path}: {ex.Message}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Directory not found: " + directoryPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                    MessageBox.Show("An error occurred: " + ex);
                    return;
                    //return if error
                }
                ///////////////////////////////////////////////////////////////////////////////////////////////////
                //Phase 2 use data
                foreach (RentResults data in ResultDataList)
                {
                    if (data.EstReturnDate.Value.Date < DateTime.Now.Date && data.Status == 1)
                    {
                        data.Status = 2;
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
                        MessageBox.Show("ข้อผิดพลาด : " + ex);
                    }
                }
            }
        }

        private void SaveLastUsedTime()
        {
            // Save the last used time to persistent storage (e.g., application settings)
            Properties.Settings.Default.LastUsedTime = DateTime.Now;
            Properties.Settings.Default.Save();
        }

        private void LoadLastUsedTime()
        {
            // Load the last used time from persistent storage (e.g., application settings)
            DateTime lastUsedTime = Properties.Settings.Default.LastUsedTime;
            previousDate = lastUsedTime.Date;
        }

    }
}
