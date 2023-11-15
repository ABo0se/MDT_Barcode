using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp.Borrow_Return
{
    public partial class EditBorrowedItems : Form
    {
        RentResults TemporaryData;
        //ThisPageTempData
        List<Image> selectedImages = new List<Image>();
        int? selectingImage = null;
        //DefaultValue
        string defaultBarcode = "[ตัวอย่าง : 45123564250]";
        string defaultProductName = "[ตัวอย่าง : Tesla-X]";
        string defaultBorrowerName = "[ตัวอย่าง : นางแป๊บซิลอน อิ่มดี]";
        string defaultPicstatus = "0 of 0";
        DateTime defaultESTReturnDate = DateTime.Now.Date;
        string defaultcontact = "[ตัวอย่าง : 0876523941]";
        string defaultnote = "[ตัวอย่าง : จะยืมออุปกรณ์นี้ไปทำสวน]";
        public EditBorrowedItems()
        {
            InitializeComponent();
        }
        public void InitializePage()
        {
          

            ////////////////////////////////////////////
            BarcodeID_TXT.Text = defaultBarcode;
            Product_Name_TXT.Text = defaultProductName;
            Borrower_Name_TB.Text = defaultBorrowerName;
            Return_Date_TXT.Value = defaultESTReturnDate;
            Contact_TB.Text = defaultcontact;
            Note_TB.Text = defaultnote;

            Borrower_Name_TB.ForeColor = Color.Gray;
            Contact_TB.ForeColor = Color.Gray;
            Note_TB.ForeColor = Color.Gray;
            //---------------------------
            if (selectedImages != null)
            {
                selectedImages.Clear();
            }
            else
            {
                selectedImages = new List<Image>();
            }
            ChangePicture(null);
            CheckImageButtonBehavior();
        }

        public void AssignBarcodeText(RentResults temporarydata)
        {
            if (SearchDatabase(temporarydata.BarcodeNumber, out RentResults myResult))
            {
                if (myResult.Status == 2)
                {
                    MessageBox.Show("ไม่สามารถปรับเปลี่ยนรายละเอียดครุภัณฑ์ที่คืนแล้วได้");
                    this.Hide();
                    return;
                }
                TemporaryData = myResult;
                BarcodeID_TXT.Text = TemporaryData.BarcodeNumber;
                Product_Name_TXT.Text = TemporaryData.Product_Name;
                Borrower_Name_TB.Text = TemporaryData.Borrower_Name;
                Return_Date_TXT.Value = TemporaryData.EstReturnDate.Value.Date;
                Contact_TB.Text = TemporaryData.Borrower_Contact;
                Note_TB.Text = TemporaryData.Note;

                Borrower_Name_TB.ForeColor = Color.Black;
                Contact_TB.ForeColor = Color.Black;
                Note_TB.ForeColor = Color.Black;
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

        private void Add_Borrowed_Item_toDB_Click(object sender, EventArgs e)
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

                if (Product_Name_TXT.Text == defaultProductName || BarcodeID_TXT.Text == defaultBarcode || Borrower_Name_TB.Text == defaultProductName ||
                    Borrower_Name_TB.Text == "" || Borrower_Name_TB.Text == defaultBorrowerName ||
                    Return_Date_TXT.Value.Date < DateTime.Now.Date || Contact_TB.Text == defaultcontact ||
                    Contact_TB.Text == "" || Note_TB.Text == defaultnote)
                {
                    warningMessage += "กรุณากรอกรายละเอียดของครุภัณฑ์ให้ครบถ้วนและถูกต้อง ก่อนทำการเพิ่่มเข้ามา\n";
                }

                if (BarcodeID_TXT.Text.Length > 50)
                {
                    warningMessage += "ความยาว Barcode ห้ามเกิน 50 ตัวอักษร\n";
                }

                if (Borrower_Name_TB.Text.Length > 100 || Contact_TB.Text.Length > 100)
                {
                    warningMessage += "ความยาวของข้อมูลผู้ยืม ห้ามเกิน 100 ตัวอักษร\n";
                }
                if (Return_Date_TXT.Value.Date < DateTime.Now.Date)
                {
                    warningMessage += "กรุณากรอกวันที่ให้ถูกต้อง\n";
                }
                if (Note_TB.Text.Length > 200)
                {
                    warningMessage += "ความยาวของหมายเหตุห้ามเกิน 200 ตัวอักษร\n";
                }
                if (TemporaryData == null)
                {
                    warningMessage += "ไม่มีข้อมูลที่ใช้อ้างอิงครุภัณฑ์ที่อยู่ในระบบตอนนี้\n";
                }
                //////////////////////////////////////////////
                if (Note_TB.Text == defaultnote || Note_TB.Text == "")
                {
                    Note_TB.Text = "-";
                }
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
                MessageBox.Show("ข้อผิดพลาด : " + ex.Message);
            }
        }

        private void EditItemToDB()
        {
            //Assign data
            if (TemporaryData == null) return;

            TemporaryData.EstReturnDate = Return_Date_TXT.Value.Date;
            TemporaryData.Borrower_Name = Borrower_Name_TB.Text;
            TemporaryData.Borrower_Contact = Contact_TB.Text;
            TemporaryData.Note = Note_TB.Text;

            if (Return_Date_TXT.Value.Date >= TemporaryData.InitialBorrowDate)
            {
                TemporaryData.Status = 0;
            }
            else
            {
                TemporaryData.Status = 1;
            }
            /////////////////////
            string connectionString = "server=127.0.0.1; user=root; database=borrow_returning_system; password=";
            MySqlConnection mySqlConnection2 = new MySqlConnection(connectionString);
            try
            {
                string query = "UPDATE borrowing_info SET " +
    "EST_Return_Date = @EST_Return_Date, " +
    "Borrower_Name = @Borrower_Name, " +
    "Contact = @Contact, " +
    "Note = @Note, " +
    "Status = @Status " +  // Removed the extra comma here
    "WHERE BarcodeNumber = @BarcodeNumberReplacement";
                //TryAddittoDATABASE
                mySqlConnection2.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection2))
                {
                    cmd.Parameters.AddWithValue("@EST_Return_Date", TemporaryData.EstReturnDate);
                    cmd.Parameters.AddWithValue("@Borrower_Name", TemporaryData.Borrower_Name);
                    cmd.Parameters.AddWithValue("@Contact", TemporaryData.Borrower_Contact);
                    cmd.Parameters.AddWithValue("@Note", TemporaryData.Note);
                    cmd.Parameters.AddWithValue("@Status", TemporaryData.Status);
                    cmd.Parameters.AddWithValue("@BarcodeNumberReplacement", TemporaryData.BarcodeNumber);
                    cmd.Parameters.AddWithValue("@Product_Name", TemporaryData.Product_Name);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("การเปลี่ยนข้อมูลการยืมครุภัณฑ์สำเร็จ!");
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
                        MessageBox.Show("การเปลี่ยนข้อมูลการยืมครุภัณฑ์ล้มเหลว.");
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

        private void EditBorrowedItems_Load(object sender, EventArgs e)
        {
            InitializePage();
        }

        private void EditBorrowedItems_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
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

        private void Borrower_Name_TB_Enter(object sender, EventArgs e)
        {
            if (Borrower_Name_TB.Text == defaultBorrowerName)
            {
                Borrower_Name_TB.Text = "";
                Borrower_Name_TB.ForeColor = Color.Black;
            }
        }

        private void Note_TB_Enter(object sender, EventArgs e)
        {
            if (Note_TB.Text == defaultnote)
            {
                Note_TB.Text = "";
                Note_TB.ForeColor = Color.Black;
            }
        }

        private void Contact_TB_Enter(object sender, EventArgs e)
        {
            if (Contact_TB.Text == defaultcontact)
            {
                Contact_TB.Text = "";
                Contact_TB.ForeColor = Color.Black;
            }
        }

        private void Borrower_Name_TB_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Borrower_Name_TB.Text) || Borrower_Name_TB.Text == defaultBorrowerName)
            {
                Borrower_Name_TB.Text = defaultBorrowerName;
                Borrower_Name_TB.ForeColor = Color.Gray;
            }
        }

        private void Contact_TB_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Contact_TB.Text) || Contact_TB.Text == defaultcontact)
            {
                Contact_TB.Text = defaultcontact;
                Contact_TB.ForeColor = Color.Gray;
            }
        }

        private void Note_TB_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Note_TB.Text) || Note_TB.Text == defaultnote)
            {
                Note_TB.Text = defaultnote;
                Note_TB.ForeColor = Color.Gray;
            }
        }
    }
}
