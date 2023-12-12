using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using USB_Barcode_Scanner_Tutorial___C_Sharp.Borrow_Return;
using System.Runtime.ExceptionServices;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class ShowItem : Form
    {
        SRResults myData;
        private MySqlConnection mySqlConnection;
        List<System.Drawing.Image> selectedImages = new List<System.Drawing.Image>();
        int? selectingImage = null;
        //////////////////////
        public ShowItem()
        {
            InitializeComponent();
            mySqlConnection = new MySqlConnection("server=127.0.0.1; user=root; database=barcodedatacollector; password=");
        }

        private void ShowItem_Load(object sender, EventArgs e)
        {
            InitializePage();
        }

        private void ShowForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public void ShowItemDetail(string barcodeText)
        {
            AssignBarcodeText(barcodeText);
        }

        public void AssignBarcodeText(string barcodeText)
        {
            if (TryFetchDataBySerialCode(barcodeText, out SRResults data))
            {
                //DisplayData
                myData = data;
                BarcodeID_TXT.Text = myData.BarcodeNumber;
                ProductName_TXT.Text = myData.Product_Name;
                ModelName_TXT.Text = myData.ModelNumber;
                Brand_TXT.Text = myData.Brand;
                SN_TXT.Text = myData.SerialNum;
                Price_TXT.Text = myData.Price;
                Stay_TXT.Text = myData.Room;
                Note_TXT.Text = myData.Description;
                ////////////////////////////////////
                selectedImages.Clear();
                List<string> path = JsonConvert.DeserializeObject<List<string>>(myData.FilePath);
                List<string> SHA512 = JsonConvert.DeserializeObject<List<string>>(myData.SHA512);
                if (path.Count > 0)
                {
                    for (int i = 0; i < path.Count; i++)
                    {
                        if (File.Exists(path[i]))
                        {
                            Image selectedImage = Image.FromFile(path[i]);
                            if (VerifyImageSHA512Hash(selectedImage, SHA512[i]))
                            {
                                selectedImages.Add(selectedImage);
                            }
                            else
                            {
                                selectedImages.Add(Properties.Resources.corruptedfile);
                            }
                        }
                        else
                        {
                            selectedImages.Add(Properties.Resources.filemissing);
                        }
                    }
                    CheckImageButtonBehavior();
                    ChangePicture(0);
                    pictureBox1.Refresh();
                }
                else
                {
                    CheckImageButtonBehavior();
                    ChangePicture(null);
                    pictureBox1.Refresh();
                }
                ////////////////////////////////////
                int statusX, conditionX;
                statusX = myData.Status;
                conditionX = myData.Condition;
                switch (statusX)
                {
                    case -1:
                    {
                        Status_TXT.Text = "ไม่พบข้อมูล";
                        break;
                    }
                    case 0:
                    {
                        Status_TXT.Text = "มีให้ตรวจสอบ";
                        break;
                    }
                    case 1:
                    {
                        Status_TXT.Text = "มีให้ตรวจสอบ";
                        break;
                    }
                }
                switch (conditionX)
                {
                    case -1:
                        {
                            Condition_TXT.Text = "ไม่พบข้อมูล";
                            break;
                        }
                    case 0:
                        {
                            Condition_TXT.Text = "ใช้งานได้";
                            break;
                        }
                    case 1:
                        {
                            Condition_TXT.Text = "ชำรุดรอซ่อม";
                            break;
                        }
                    case 2:
                        {
                            Condition_TXT.Text = "สิ้นสภาพ";
                            break;
                        }
                    case 3:
                        {
                            Condition_TXT.Text = "สูญหาย";
                            break;
                        }
                    case 4:
                        {
                            Condition_TXT.Text = "จำหน่ายแล้ว";
                            break;
                        }
                    case 5:
                        {
                            Condition_TXT.Text = "โอนแล้ว";
                            break;
                        }
                    case 6:
                        {
                            Condition_TXT.Text = "อื่นๆ";
                            break;
                        }
                }
                ////////////////////////////////////
            }
            else
            {
                myData = null;
            }
        }

        private bool TryFetchDataBySerialCode(string serialCode, out SRResults data)
        {
            data = null;

            try
            {
                mySqlConnection.Open();
                string selectQuery = "SELECT * FROM information WHERE BarcodeNumber = @BarcodeNumber";

                using (MySqlCommand command = new MySqlCommand(selectQuery, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@BarcodeNumber", serialCode);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data = new SRResults
                            {
                                Date = reader.GetDateTime("Time"),
                                Product_Name = reader["Product_Name"].ToString(),
                                BarcodeNumber = reader["BarcodeNumber"].ToString(),
                                ModelNumber = reader["Model_Name"].ToString(),
                                Brand = reader["Brand"].ToString(),
                                SerialNum = reader["Serial_Number"].ToString(),
                                Price = reader["Price"].ToString(),
                                Room = reader["Room"].ToString(),
                                FilePath = reader["ImageData"].ToString(),
                                SHA512 = reader["MD5_ImageValidityChecksum"].ToString(),
                                Description = reader["Note"].ToString(),
                                Status = int.Parse(reader["Status"].ToString()),
                                Condition = int.Parse(reader["ITEM_CONDITION"].ToString())
                            };
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                // MessageBox.Show(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
            return false;
        }

    

        public void InitializePage()
        {
            BarcodeID_TXT.Text = ProductName_TXT.Text = ModelName_TXT.Text = Brand_TXT.Text = 
            SN_TXT.Text = Price_TXT.Text = Stay_TXT.Text = Note_TXT.Text = Status_TXT.Text = Condition_TXT.Text = string.Empty;
            if (selectedImages != null)
            {
                selectedImages.Clear();
            }
            else
            {
                selectedImages = new List<System.Drawing.Image>();
            }
            ChangePicture(null);
            CheckImageButtonBehavior();
        }

        // Other event handler methods...

        private void BarcodeID_TXT_Click(object sender, EventArgs e)
        {
            // You can add logic here if needed
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (myData == null) return;
            if (selectingImage == null) return;
            if (selectedImages == null) return;
            if (selectedImages[(int)selectingImage] != Properties.Resources.corruptedfile && selectedImages[(int)selectingImage] != Properties.Resources.filemissing)
            {
                List<string> path = JsonConvert.DeserializeObject<List<string>>(myData.FilePath);
                try
                {
                    Process.Start("explorer.exe", $"/select, \"{path[(int)selectingImage]}\"");
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("ข้อผิดพลาด : " + ex.Message);
                }
            }
        }

        private void CheckImageButtonBehavior()
        {
            if (selectedImages != null && selectedImages.Count > 1)
            {
                Prevpic.Enabled = true;
                Nextpic.Enabled = true;
                Prevpic.Show();
                Nextpic.Show();
            }
            else
            {
                Prevpic.Enabled = false;
                Nextpic.Enabled = false;
                Prevpic.Hide();
                Nextpic.Hide();
            }
        }
        private void ChangePicture(int? pictureindex)
        {
            selectingImage = pictureindex;
            if (selectingImage != null)
            {
                pictureBox1.Image = selectedImages[(int)selectingImage];
                PicInformation.Text = (int)(selectingImage + 1) + " of " + selectedImages.Count;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.NoImage;
                PicInformation.Text = "0 of 0";
            }
        }
        private void Nextpic_Click(object sender, EventArgs e)
        {
            if (selectedImages.Count < 2) return;
            if ((selectingImage + 1) < (selectedImages.Count))
            {
                selectingImage++;

            }
            else
            {
                selectingImage = 0;
            }
            ChangePicture((int)selectingImage);
        }

        private void Prevpic_Click(object sender, EventArgs e)
        {
            if (selectedImages.Count < 2) return;
            if ((selectingImage - 1) >= 0)
            {
                selectingImage--;
            }
            else
            {
                selectingImage = selectedImages.Count - 1;
            }
            ChangePicture((int)selectingImage);
        }
        public bool VerifyImageSHA512Hash(Image image, string storedHash)
        {
            using (SHA512 sha512 = SHA512.Create())
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Jpeg); // You can choose the appropriate format
                stream.Seek(0, SeekOrigin.Begin); // Reset stream position

                byte[] imageBytes = stream.ToArray();
                byte[] computedHash = sha512.ComputeHash(imageBytes);

                // Convert the computed hash to a hexadecimal string
                string computedHashString = BitConverter.ToString(computedHash).Replace("-", "").ToLower();

                // Compare the computed hash with the stored hash
                return computedHashString.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
            }
        }
        private bool SearchDatabase(string BarcodeName, out RentResults mysearchresults)
        {
            mysearchresults = null;

            try
            {
                string connectionString = "server=127.0.0.1; user=root; database=borrow_returning_system; password=";
                string query = "SELECT * FROM borrowing_info WHERE BarcodeNumber = @BarcodesearchCriteria";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BarcodesearchCriteria", BarcodeName);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                mysearchresults = new RentResults
                                {
                                    Date = reader.IsDBNull(reader.GetOrdinal("Time")) ? (DateTime?)null : reader.GetDateTime("Time"),
                                    InitialBorrowDate = reader.IsDBNull(reader.GetOrdinal("Initial_Borrow_Time")) ? (DateTime?)null : reader.GetDateTime("Initial_Borrow_Time"),
                                    EstReturnDate = reader.IsDBNull(reader.GetOrdinal("EST_Return_Date")) ? (DateTime?)null : reader.GetDateTime("EST_Return_Date"),
                                    ActualReturnDate = reader.IsDBNull(reader.GetOrdinal("ACTUAL_Return_Date")) ? (DateTime?)null : reader.GetDateTime("ACTUAL_Return_Date"),
                                    BarcodeNumber = !string.IsNullOrEmpty(reader["BarcodeNumber"]?.ToString()) ? reader["BarcodeNumber"].ToString() : "-",
                                    Product_Name = !string.IsNullOrEmpty(reader["Product_Name"]?.ToString()) ? reader["Product_Name"].ToString() : "-",
                                    Borrower_Name = !string.IsNullOrEmpty(reader["Borrower_Name"]?.ToString()) ? reader["Borrower_Name"].ToString() : "-",
                                    FilePath = !string.IsNullOrEmpty(reader["ImageData"]?.ToString()) ? reader["ImageData"].ToString() : "[]",
                                    SHA512 = !string.IsNullOrEmpty(reader["MD5_ImageValidityChecksum"]?.ToString()) ? reader["MD5_ImageValidityChecksum"].ToString() : "[]",
                                    BarcodeHistoryListSerialized = !string.IsNullOrEmpty(reader["HistoryTextlog"]?.ToString()) ? reader["HistoryTextlog"].ToString() : "[]",
                                    Borrower_Contact = !string.IsNullOrEmpty(reader["Contact"]?.ToString()) ? reader["Contact"].ToString() : "-",
                                    Note = !string.IsNullOrEmpty(reader["Note"]?.ToString()) ? reader["Note"].ToString() : "-",
                                    Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? 3 : reader.GetInt16("Status")
                                };
                                if (mysearchresults.BarcodeHistoryListSerialized != "[]")
                                {
                                    mysearchresults.BarcodeHistoryList = JsonConvert.DeserializeObject<List<RentHistory>>(mysearchresults.BarcodeHistoryListSerialized);
                                }
                                // If a match is found, return true immediately
                                return true;
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด : " + ex.ToString());
            }

            // If no match is found, mysearchresults is already set to null by default
            return false;
        }

        private void Show_History_Click(object sender, EventArgs e)
        {
            Borrow_History History = MainMenu.initializedForms.Find(f => f is Borrow_History) as Borrow_History;
            if (History != null)
            {
                if (myData != null)
                {
                    if (SearchDatabase(myData.BarcodeNumber, out RentResults TemporaryData))
                    {
                        if (TemporaryData.BarcodeHistoryList != null)
                        {
                            if (TemporaryData.BarcodeHistoryList.Count > 0)
                            {
                                History.Show();
                                History.AssignText(TemporaryData.BarcodeHistoryList);
                            }
                            else
                            {
                                MessageBox.Show("ไม่พบประวัติการยืมครุภัณฑ์นี้");
                            }
                        }
                        else
                        {
                            MessageBox.Show("ไม่พบประวัติการยืมครุภัณฑ์นี้");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบประวัติการยืมครุภัณฑ์นี้");
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลครุภัณฑ์นี้");
                }
            }
            else
            {
                MessageBox.Show("ไม่พบหน้าต่างยืม");
            }
        }

        private void ShowPic_Enter(object sender, EventArgs e)
        {
            if (selectedImages == null)
            { 
                return; 
            }
            if (selectedImages.Count <= 0)
            {
                return;
            }
            if (selectedImages[(int)selectingImage] == null)
            { 
                return; 
            }
            else if (selectedImages[(int)selectingImage] != Properties.Resources.corruptedfile && selectedImages[(int)selectingImage] != Properties.Resources.filemissing)
            {
                pictureBox1.Image = Properties.Resources.search;
            }
        }

        private void ShowPic_Leave(object sender, EventArgs e)
        {
            if (selectedImages == null)
            {
                ChangePicture(null);
            }
            if (selectedImages.Count <= 0)
            {
                ChangePicture(null);
            }
            else if (selectedImages[(int)selectingImage] != null)
            {
                pictureBox1.Image = selectedImages[(int)selectingImage];
            }
            else
            {
                ChangePicture(null);
            }
        }
    }
}
