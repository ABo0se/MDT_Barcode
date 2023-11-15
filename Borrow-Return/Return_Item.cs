using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USB_Barcode_Scanner_Tutorial___C_Sharp.Borrow_Return;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class Return_Item : Form
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
        //TemporaryData
        RentResults TemporaryData;

        public Return_Item()
        {
            InitializeComponent();
        }

        public void AssignBarcodeText(RentResults temporarydata)
        {
            if (SearchDatabase(temporarydata.BarcodeNumber, out RentResults myResult))
            {
                if (myResult.Status == 3)
                {
                    MessageBox.Show("ไม่สามารถคืนครุภัณฑ์ที่ไม่ถูกยืมได้");
                    this.Hide();
                    return;
                }
                TemporaryData = myResult;
                //string serializedRentResults = JsonConvert.SerializeObject(myResult, Formatting.Indented);
                //MessageBox.Show(serializedRentResults);
                //GetDataNormally
                BarcodeID_TXT.Text = TemporaryData.BarcodeNumber;
                Product_Name_TXT.Text = TemporaryData.Product_Name;
                Borrower_TXT.Text = TemporaryData.Borrower_Name;
                //Status_TXT.Text = DecodingStatus(myResult.Status);
                EST_Borrow_Date_TXT.Text = TemporaryData.InitialBorrowDate.HasValue
    ? TemporaryData.InitialBorrowDate.Value.ToString("dd MMMM yyyy")
    : "-";

                EST_Return_Date_TXT.Text = TemporaryData.EstReturnDate.HasValue
                    ? TemporaryData.EstReturnDate.Value.ToString("dd MMMM yyyy")
                    : "-";

                Return_Date_TXT.Text = DateTime.Now.Date.ToString("dd MMMM yyyy");

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
                    pictureBox1.Image = Properties.Resources.NoImage;
                }
                ////////////////////////////////////
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูลในฐานข้อมูลการยืมสิ่งของ");
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

        public void InitializePage()
        {
            ////////////////////////////////////////////
            BarcodeID_TXT.Text = defaultBarcode;
            Product_Name_TXT.Text = defaultProductName;
            Borrower_TXT.Text = defaultBorrowerName;
            EST_Borrow_Date_TXT.Text = defaultBorrowDate;
            EST_Return_Date_TXT.Text = defaultESTReturnDate;
            Return_Date_TXT.Text = defaultACTUAlReturnDate;
            Contact_TXT.Text = defaultcontact;
            Note_TXT.Text = defaultnote;
            //---------------------------
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



        private void Return_Item_Load(object sender, EventArgs e)
        {
            InitializePage();
        }

        private void Return_Borrowed_Item_toDB_Click(object sender, EventArgs e)
        {
            //Serach before we do something.
            List<string> dbData = new List<string>();
            string dbConnectionString = "server=127.0.0.1; user=root; database=borrow_returning_system; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(dbConnectionString);

            try
            {
                mySqlConnection.Open();
                string selectQuery = "SELECT BarcodeNumber FROM borrowing_info";

                // Use MySqlCommand instead of SqlCommand for MySQL
                MySqlCommand command = new MySqlCommand(selectQuery, mySqlConnection);

                // SqlDataReader is for SQL Server, use MySqlDataReader for MySQL
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string rowData = reader["BarcodeNumber"].ToString();
                    dbData.Add(rowData);
                }

                // Compare the data
                bool isDataSame = dbData.Contains(TemporaryData.BarcodeNumber); // Check if the barcode is already in the database

                string warningMessage = "";

                if (!isDataSame)
                {
                    warningMessage += "ไม่สามารถเปลี่ยนข้อมูลในระบบได้ เนื่องจากไม่มีรหัสครุภัณฑ์นี้ในระบบการยืม-คืนอยู่แล้ว\n";
                }

                //if (Product_Name_TXT.Text == defaultProductName || BarcodeID_TXT.Text == defaultBarcode || Borrower_Name_TB.Text == defaultProductName ||
                //    Borrower_Name_TB.Text == "" || Borrower_Name_TB.Text == defaultBorrowerName ||
                //    Return_Date_TXT.Value.Date < DateTime.Now.Date || Contact_TB.Text == defaultcontact ||
                //    Contact_TB.Text == "" || Note_TB.Text == defaultnote)
                //{
                //    warningMessage += "กรุณากรอกรายละเอียดของครุภัณฑ์ให้ครบถ้วนและถูกต้อง ก่อนทำการเพิ่่มเข้ามา\n";
                //}

                //if (BarcodeID_TXT.Text.Length > 50)
                //{
                //    warningMessage += "ความยาว Barcode ห้ามเกิน 50 ตัวอักษร\n";
                //}

                //if (Borrower_Name_TB.Text.Length > 100 || Contact_TB.Text.Length > 100)
                //{
                //    warningMessage += "ความยาวของข้อมูลผู้ยืม ห้ามเกิน 100 ตัวอักษร\n";
                //}
                //if (Return_Date_TXT.Value.Date < DateTime.Now.Date)
                //{
                //    warningMessage += "กรุณากรอกวันที่ให้ถูกต้อง\n";
                //}
                //if (Note_TB.Text.Length > 200)
                //{
                //    warningMessage += "ความยาวของหมายเหตุห้ามเกิน 200 ตัวอักษร\n";
                //}
                if (TemporaryData == null)
                {
                    warningMessage += "ไม่มีข้อมูลที่ใช้อ้างอิงครุภัณฑ์ที่อยู่ในระบบตอนนี้\n";
                }
                //////////////////////////////////////////////
                //if (Note_TB.Text == defaultnote || Note_TB.Text == "")
                //{
                //    Note_TB.Text = "-";
                //}
                ///////////////////////
                if (!string.IsNullOrEmpty(warningMessage))
                {
                    MessageBox.Show(warningMessage);
                }
                else
                {
                    EditItemToDB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        private void EditItemToDB()
        {
            //Assign data
            if (TemporaryData == null) return;

            TemporaryData.ActualReturnDate = DateTime.Now.Date;
            TemporaryData.Status = 2;

            RentHistory newrent = new RentHistory();
            newrent.InitialBorrowDate = TemporaryData.InitialBorrowDate.Value;
            newrent.Borrower_Contact = TemporaryData.Borrower_Contact;
            newrent.Borrower_Name = TemporaryData.Borrower_Name;
            newrent.EstReturnDate = TemporaryData.EstReturnDate.Value;
            newrent.ActualReturnDate = TemporaryData.ActualReturnDate.Value;
            newrent.Note = TemporaryData.Note;

            if (TemporaryData.BarcodeHistoryList == null)
            {
                TemporaryData.BarcodeHistoryList = new List<RentHistory>();
            }
            TemporaryData.BarcodeHistoryList.Add(newrent);

            string serializedRentHistory = JsonConvert.SerializeObject(TemporaryData.BarcodeHistoryList, Formatting.Indented);
            TemporaryData.BarcodeHistoryListSerialized = serializedRentHistory;

            /////////////////////
            string connectionString = "server=127.0.0.1; user=root; database=borrow_returning_system; password=";
            MySqlConnection mySqlConnection2 = new MySqlConnection(connectionString);
            try
            {
                string query = "UPDATE borrowing_info SET " +
                                "Status = @Status, " +
                                "ACTUAL_Return_Date = @ACTUAL_Return_Date, " +
                                "HistoryTextlog = @HistoryTextlog " +

                                "WHERE BarcodeNumber = @BarcodeNumberReplacement";
                //TryAddittoDATABASE
                mySqlConnection2.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection2))
                {
                    cmd.Parameters.AddWithValue("@ACTUAL_Return_Date", TemporaryData.ActualReturnDate);
                    cmd.Parameters.AddWithValue("@Status", TemporaryData.Status);
                    cmd.Parameters.AddWithValue("@BarcodeNumberReplacement", TemporaryData.BarcodeNumber);
                    cmd.Parameters.AddWithValue("@HistoryTextlog", TemporaryData.BarcodeHistoryListSerialized);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("การคืนครุภัณฑ์สำเร็จ!");
                        this.Hide();
                        ManageBorrowedItem Search = MainMenu.initializedForms.Find(f => f is ManageBorrowedItem) as ManageBorrowedItem;
                        if (Search != null)
                        {
                            Search.SearchDatainDB();
                        }
                        //PullDataFromDB();
                    }
                    else
                    {
                        MessageBox.Show("การคืนครุภัณฑ์ล้มเหลว.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                mySqlConnection2.Close();
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
                image.Save(stream, ImageFormat.Png); // You can choose the appropriate format
                stream.Seek(0, SeekOrigin.Begin); // Reset stream position

                byte[] imageBytes = stream.ToArray();
                byte[] computedHash = sha512.ComputeHash(imageBytes);

                // Convert the computed hash to a hexadecimal string
                string computedHashString = BitConverter.ToString(computedHash).Replace("-", "").ToLower();

                // Compare the computed hash with the stored hash
                return computedHashString.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
            }
        }

        private void Return_Item_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
            }
        }
    }
}
