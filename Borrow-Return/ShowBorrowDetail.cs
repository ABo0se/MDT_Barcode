using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USB_Barcode_Scanner_Tutorial___C_Sharp.Borrow_Return;
using System.IO;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using MySqlX.XDevAPI.Common;
using System.Linq.Expressions;
using Org.BouncyCastle.Utilities.Collections;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class ShowBorrowDetail : Form
    {
        //ThisPageTempData
        List<Image> selectedImages = new List<Image>();
        int? selectingImage = null;
        //DefaultValue
        string defaultBarcode = "-";
        string defaultProductName = "-";
        string defaultBorrowerName = "-";
        string defaultPicstatus = "0 of 0";
        string defaultstatus = "-";
        string defaultBorrowDate = "-";
        string defaultESTReturnDate = "-";
        string defaultACTUAlReturnDate = "-";
        string defaultcontact = "-";
        string defaultnote = "-";

        RentResults TemporaryData = null;
        public ShowBorrowDetail()
        {
            InitializeComponent();
        }

        public void AssignBarcodeText(RentResults temporarydata)
        {
            if (SearchDatabase(temporarydata.BarcodeNumber, out RentResults Temporarydata))
            {
                TemporaryData = Temporarydata;
                //string serializedRentResults = JsonConvert.SerializeObject(TemporaryData, Formatting.Indented);

                //MessageBox.Show(serializedRentResults);
                //GetDataNormally
                BarcodeID_TXT.Text = TemporaryData.BarcodeNumber;
                Product_Name_TXT.Text = TemporaryData.Product_Name;
                Borrower_TXT.Text = TemporaryData.Borrower_Name;
                Status_TXT.Text = DecodingStatus(TemporaryData.Status);
                EST_Borrow_Date_TXT.Text = TemporaryData.InitialBorrowDate.HasValue
    ? TemporaryData.InitialBorrowDate.Value.ToString("dd MMMM yyyy HH:mm:ss")
    : "-";

                EST_Return_Date_TXT.Text = TemporaryData.EstReturnDate.HasValue
                    ? TemporaryData.EstReturnDate.Value.ToString("dd MMMM yyyy")
                    : "-";

                Return_Date_TXT.Text = TemporaryData.ActualReturnDate.HasValue
                    ? TemporaryData.ActualReturnDate.Value.ToString("dd MMMM yyyy HH:mm:ss")
                    : "-";

                Contact_TXT.Text = TemporaryData.Borrower_Contact;
                Note_TXT.Text = TemporaryData.Note;
                ////////////////////////////////////
                selectedImages.Clear();
                List<string> path = JsonConvert.DeserializeObject<List<string>>(TemporaryData.FilePath);
                List<string> SHA512 = JsonConvert.DeserializeObject<List<string>>(TemporaryData.SHA512);
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
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูลในฐานข้อมูลการยืมสิ่งของ");
            }
        }

        public void InitializePage()
        {
            BarcodeID_TXT.Text = defaultBarcode;
            Product_Name_TXT.Text = defaultProductName;
            Borrower_TXT.Text = defaultBorrowerName;
            Status_TXT.Text = defaultstatus;
            EST_Borrow_Date_TXT.Text = defaultBorrowDate;
            EST_Return_Date_TXT.Text = defaultESTReturnDate;
            Return_Date_TXT.Text = defaultACTUAlReturnDate;
            Contact_TXT.Text = defaultcontact;
            Note_TXT.Text = defaultnote;
            //---------------------------
            TemporaryData = null;
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

        private void ShowBorrowDetail_Load(object sender, EventArgs e)
        {
            InitializePage();
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

        private string DecodingStatus(int? status)
        {
            switch (status)
            {
                case 0:
                    {
                        return "ถูกยืม";
                    }
                case 1:
                    {
                        return "เลยกำหนด";
                    }
                case 2:
                    {
                        return "พร้อมให้ยืม";
                    }
                case 3:
                    {
                        return "ไม่พบข้อมูล";
                    }
                case null:
                    {
                        return "พร้อมให้ยืม";
                    }
                default:
                    {
                        return "ไม่พบข้อมูล";
                    }
            }
        }
        private int? EncodingStatus(string stringstatus)
        {
            switch (stringstatus)
            {
                case "ถูกยืม":
                    {
                        return 0;
                    }
                case "เลยกำหนด":
                    {
                        return 1;
                    }
                case "พร้อมให้ยืม [มีประวัติ]":
                    {
                        return 2;
                    }
                case "ไม่พบข้อมูล":
                    {
                        return 3;
                    }
                case "พร้อมให้ยืม":
                    {
                        return null;
                    }
                default:
                    {
                        return 3;
                    }
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

        private void ShowBorrowDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
            }
        }
        private void Show_History_Click_1(object sender, EventArgs e)
        {
            Borrow_History History = MainMenu.initializedForms.Find(f => f is Borrow_History) as Borrow_History;
            if (History != null)
            {
                if (TemporaryData != null)
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
            }
            else
            {
                MessageBox.Show("ไม่พบหน้าต่างยืม");
            }
        }
    }
}
