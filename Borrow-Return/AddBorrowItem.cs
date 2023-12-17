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
using USB_Barcode_Scanner_Tutorial___C_Sharp.Properties;
using System.IO;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Windows.Media.Media3D;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class AddBorrowItem : Form
    {
        //ThisPageTempData
        List<Image> selectedImages = new List<Image>();
        int? selectingImage = null;
        //DefaultValue
        string defaultBarcode = "65A1234567";
        string defaultProductName = "เครื่องคอมพิวเตอร์พกพา";
        string defaultBorrowerName = "นายเรียนดี มีวินัย";
        string defaultPicstatus = "0 of 0";
        //DateTime defaultReturnDate = DateTime.Now;
        string defaultcontact = "0812345678";
        string defaultnote = "";
        //TemporaryData
        RentResults TemporaryData;
        public AddBorrowItem()
        {
            InitializeComponent();
        }

        public void AssignBarcodeText(RentResults result)
        {
            TemporaryData = result;
            BarcodeID_TXT.Text = TemporaryData.BarcodeNumber;
            Product_Name_TXT.Text = TemporaryData.Product_Name;
            Return_Date_TXT.Value = DateTime.Now;

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
                            selectedImages[i].Tag = "NormalFile";
                        }
                        else
                        {
                            selectedImages.Add(Resources.corruptedfile);
                            selectedImages[i].Tag = "FileCorrupt";
                        }
                    }
                    else
                    {
                        selectedImages.Add(Resources.filemissing);
                        selectedImages[i].Tag = "FileMissing";
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
            /////////////////////////////////////////////////////
        }

        public void InitializePage()
        {
            Borrow_BarcodeIDChecker Search = MainMenu.initializedForms.Find(f => f is Borrow_BarcodeIDChecker) as Borrow_BarcodeIDChecker;
            if (Search != null)
            {
                Search.SoftReset();
            }
            ////////////////////////////////////////////
            //BarcodeID_TXT.Text = defaultBarcode;
            //Product_Name_TXT.Text = defaultProductName;
            this.ActiveControl = null;
            Return_Date_TXT.Value = DateTime.Now;
            Borrower_Name_TB.Text = defaultBorrowerName;
            Contact_TB.Text = defaultcontact;
            Note_TB.Text= defaultnote;

            Borrower_Name_TB.ForeColor = Color.Gray;
            Contact_TB.ForeColor = Color.Gray;
            Note_TB.ForeColor = Color.Gray;
            /////////////////////////////////
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
            ////////
            if (TemporaryData == null)
            {
                TemporaryData = new RentResults();
            }
        }

        private void Add_BorrowItem_ToDB(object sender, EventArgs e)
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
                bool isexistinDB = false;

                if (Product_Name_TXT.Text == defaultProductName || BarcodeID_TXT.Text == defaultBarcode || Borrower_Name_TB.Text == defaultProductName ||
                    Borrower_Name_TB.Text == "" || Borrower_Name_TB.Text == defaultBorrowerName ||
                    Return_Date_TXT.Value.Date < DateTime.Now.Date || Contact_TB.Text == defaultcontact ||
                    Contact_TB.Text == "")
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
                else if (isDataSame)
                {
                    if (!(TemporaryData.Status == null || TemporaryData.Status == 2))
                    {
                        warningMessage += "ไม่สามารถยืมครุภัณฑ์ที่ทำการยืมอยู่ตอนนี้ได้\n";
                    }
                    else if (TemporaryData.Status == 2)
                    {
                        isexistinDB = true;
                    }
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
                    if (isexistinDB)
                    {
                        EditItemToDB();
                    }
                    else
                    {
                        AddItemToDB();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด : " + ex.Message);
            }
        }

        private void AddItemToDB()
        {
            //Adjust object before we put in database.
            if (TemporaryData == null)
            {
                MessageBox.Show("ไม่มีข้อมูลที่ใช้อ้างอิงครุภัณฑ์ที่อยู่ในระบบตอนนี้\n");
                return;
            }
            TemporaryData.InitialBorrowDate = DateTime.Now;
            TemporaryData.EstReturnDate = Return_Date_TXT.Value.Date;
            TemporaryData.Borrower_Name = Borrower_Name_TB.Text;
            TemporaryData.Borrower_Contact = Contact_TB.Text;
            TemporaryData.Note = Note_TB.Text;
            //ถูกยืม
            TemporaryData.Status = 0;
            //////////////////////////////////////////////////////////////////////////////////////////////////////
            string connectionString = "server=127.0.0.1; user=root; database=borrow_returning_system; password=";
            MySqlConnection mySqlConnection2 = new MySqlConnection(connectionString);

            try
            {
                //TryAddittoDATABASE
                mySqlConnection2.Open();

                string query = "INSERT INTO borrowing_info (Initial_Borrow_Time, EST_Return_Date, BarcodeNumber, Product_Name, Borrower_Name, ImageData, MD5_ImageValidityChecksum, Contact, Note, Status) " +
               "VALUES (@Initial_Borrow_Time, @EST_Return_Date, @BarcodeNumber, @Product_Name, @Borrower_Name, @ImageData, @MD5_ImageValidityChecksum, @Contact, @Note, @Status)";


                using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection2))
                {
                    cmd.Parameters.AddWithValue("@Initial_Borrow_Time", TemporaryData.InitialBorrowDate);
                    cmd.Parameters.AddWithValue("@EST_Return_Date", TemporaryData.EstReturnDate);
                    cmd.Parameters.AddWithValue("@BarcodeNumber", TemporaryData.BarcodeNumber);
                    cmd.Parameters.AddWithValue("@Product_Name", TemporaryData.Product_Name);
                    cmd.Parameters.AddWithValue("@Borrower_Name", TemporaryData.Borrower_Name);
                    cmd.Parameters.AddWithValue("@ImageData", TemporaryData.FilePath);
                    cmd.Parameters.AddWithValue("@MD5_ImageValidityChecksum", TemporaryData.SHA512);
                    cmd.Parameters.AddWithValue("@Contact", TemporaryData.Borrower_Contact);
                    cmd.Parameters.AddWithValue("@Note", TemporaryData.Note);
                    cmd.Parameters.AddWithValue("@Status", TemporaryData.Status);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("การยืมครุภัณฑ์สำเร็จ!");
                        //PullDataFromDB();
                    }
                    else
                    {
                        MessageBox.Show("การยืมครุภัณฑ์ล้มเหลว.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด : " + ex.Message);
            }
            finally
            {
                mySqlConnection2.Close();
                AddBorrowItem AddItem = MainMenu.initializedForms.Find(f => f is AddBorrowItem) as AddBorrowItem;
                ManageBorrowedItem ManageRent = MainMenu.initializedForms.Find(f => f is ManageBorrowedItem) as ManageBorrowedItem;
                if (AddItem != null)
                {
                    AddItem.Hide();
                }
                if (ManageRent != null)
                {
                    ManageRent.SearchDatainDB();
                }
            }
        }
        private void EditItemToDB()
        {
            //Adjust object before we put in database.
            if (TemporaryData == null)
            {
                MessageBox.Show("ไม่มีข้อมูลที่ใช้อ้างอิงครุภัณฑ์ที่อยู่ในระบบตอนนี้\n");
                return;
            }
            TemporaryData.InitialBorrowDate = DateTime.Now;
            TemporaryData.EstReturnDate = Return_Date_TXT.Value.Date;
            TemporaryData.Borrower_Name = Borrower_Name_TB.Text;
            TemporaryData.Borrower_Contact = Contact_TB.Text;
            TemporaryData.Note = Note_TB.Text;
            //ถูกยืม
            TemporaryData.Status = 0;
            //////////////////////////////////////////////////////////////////////////////////////////////////////
            string connectionString = "server=127.0.0.1; user=root; database=borrow_returning_system; password=";
            MySqlConnection mySqlConnection2 = new MySqlConnection(connectionString);

            try
            {
                //TryAddittoDATABASE
                mySqlConnection2.Open();

                string query = "UPDATE borrowing_info SET " +
               "Initial_Borrow_Time = @Initial_Borrow_Time, " +
               "EST_Return_Date = @EST_Return_Date, " +
               "BarcodeNumber = @BarcodeNumber, " +
               "Product_Name = @Product_Name, " +
               "Borrower_Name = @Borrower_Name, " +
               "Note = @Note, " +
               "ImageData = @ImageData, " +
               "MD5_ImageValidityChecksum = @MD5_ImageValidityChecksum," +
               "Contact = @Contact, " +
               "Status = @Status " +
               "WHERE BarcodeNumber = @BarcodeNumber";


                using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection2))
                {
                    cmd.Parameters.AddWithValue("@Initial_Borrow_Time", TemporaryData.InitialBorrowDate);
                    cmd.Parameters.AddWithValue("@EST_Return_Date", TemporaryData.EstReturnDate);
                    cmd.Parameters.AddWithValue("@BarcodeNumber", TemporaryData.BarcodeNumber);
                    cmd.Parameters.AddWithValue("@Product_Name", TemporaryData.Product_Name);
                    cmd.Parameters.AddWithValue("@Borrower_Name", TemporaryData.Borrower_Name);
                    cmd.Parameters.AddWithValue("@ImageData", TemporaryData.FilePath);
                    cmd.Parameters.AddWithValue("@MD5_ImageValidityChecksum", TemporaryData.SHA512);
                    cmd.Parameters.AddWithValue("@Contact", TemporaryData.Borrower_Contact);
                    cmd.Parameters.AddWithValue("@Note", TemporaryData.Note);
                    cmd.Parameters.AddWithValue("@Status", TemporaryData.Status);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("การยืมครุภัณฑ์สำเร็จ!");
                        //PullDataFromDB();
                    }
                    else
                    {
                        MessageBox.Show("การยืมครุภัณฑ์ล้มเหลว.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด : " + ex.Message);
            }
            finally
            {
                mySqlConnection2.Close();
                AddBorrowItem AddItem = MainMenu.initializedForms.Find(f => f is AddBorrowItem) as AddBorrowItem;
                ManageBorrowedItem ManageRent = MainMenu.initializedForms.Find(f => f is ManageBorrowedItem) as ManageBorrowedItem;
                if (AddItem != null)
                {
                    AddItem.Hide();
                }
                if (ManageRent != null)
                {
                    ManageRent.SearchDatainDB();
                }
            }
        }

        private void AddBorrowItem_Load(object sender, EventArgs e)
        {
            InitializePage();
        }

        private void AddBorrowItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
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

        private void Borrower_Name_TB_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Borrower_Name_TB.Text) || Borrower_Name_TB.Text == defaultBorrowerName)
            {
                Borrower_Name_TB.Text = defaultBorrowerName;
                Borrower_Name_TB.ForeColor = Color.Gray;
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

        private void Contact_TB_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Contact_TB.Text) || Contact_TB.Text == defaultcontact)
            {
                Contact_TB.Text = defaultcontact;
                Contact_TB.ForeColor = Color.Gray;
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

        private void Note_TB_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Note_TB.Text) || Note_TB.Text == defaultnote)
            {
                Note_TB.Text = defaultnote;
                Note_TB.ForeColor = Color.Gray;
            }
        }
        ///////////////////////////////////////////
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
        string CalculateSHA512Checksum1pic(Image image)
        {
            string sha512Values = string.Empty;
            if (image != null)
            {
                using (var sha512 = SHA512.Create())
                using (var stream = new MemoryStream())
                {
                    // Convert the image to JPEG format before saving
                    ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    image.Save(stream, jpgEncoder, myEncoderParameters);

                    stream.Seek(0, SeekOrigin.Begin); // Reset stream position

                    byte[] sha512ChecksumBytes = sha512.ComputeHash(stream);
                    string sha512Checksum = BitConverter.ToString(sha512ChecksumBytes).Replace("-", "").ToLower();
                    sha512Values = sha512Checksum;
                }
            }
            return sha512Values;
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
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
        //////////////////////////////////////////////////
    }
}
