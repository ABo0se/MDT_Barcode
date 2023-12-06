using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Data;
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
    ? TemporaryData.InitialBorrowDate.Value.ToString("dd MMMM yyyy HH:mm:ss")
    : "-";

                EST_Return_Date_TXT.Text = TemporaryData.EstReturnDate.HasValue
                    ? TemporaryData.EstReturnDate.Value.ToString("dd MMMM yyyy")
                    : "-";

                Return_Date_TXT.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");

                Contact_TXT.Text = TemporaryData.Borrower_Contact;
                Note_TXT.Text = TemporaryData.Note;
                Note_TXT.ForeColor = Color.Black;
                ////////////////////////////////////
                //selectedImages.Clear();
                //List<string> path = JsonConvert.DeserializeObject<List<string>>(TemporaryData.FilePath);
                //List<string> SHA512 = JsonConvert.DeserializeObject<List<string>>(TemporaryData.SHA512);
                //if (path.Count > 0)
                //{
                //    for (int i = 0; i < path.Count; i++)
                //    {
                //        if (File.Exists(path[i]))
                //        {
                //            Image selectedImage = Image.FromFile(path[i]);
                //            if (VerifyImageSHA512Hash(selectedImage, SHA512[i]))
                //            {
                //                selectedImages.Add(selectedImage);
                //            }
                //            else
                //            {
                //                selectedImages.Add(Properties.Resources.corruptedfile);
                //            }
                //        }
                //        else
                //        {
                //            selectedImages.Add(Properties.Resources.filemissing);
                //        }
                //    }
                //    CheckImageButtonBehavior();
                //    ChangePicture(0);
                //    pictureBox1.Refresh();
                //}
                //else
                //{
                //    CheckImageButtonBehavior();
                //    ChangePicture(null);
                //    pictureBox1.Refresh();
                //}
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

        public void InitializePage()
        {
            Borrow_BarcodeIDChecker Search = MainMenu.initializedForms.Find(f => f is Borrow_BarcodeIDChecker) as Borrow_BarcodeIDChecker;
            if (Search != null)
            {
                Search.SoftReset();
            }
            ////////////////////////////////////////////
            this.ActiveControl = null;
            BarcodeID_TXT.Text = defaultBarcode;
            Product_Name_TXT.Text = defaultProductName;
            Borrower_TXT.Text = defaultBorrowerName;
            EST_Borrow_Date_TXT.Text = defaultBorrowDate;
            EST_Return_Date_TXT.Text = defaultESTReturnDate;
            Return_Date_TXT.Text = defaultACTUAlReturnDate;
            Contact_TXT.Text = defaultcontact;
            Note_TXT.Text = defaultnote;
            Note_TXT.ForeColor = Color.Gray;
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
            //Choose whether if you want to delete your old data in database, or update not dumplicate barcode data to database.
            DialogResult result2 = MessageBox.Show
            ("ต้องการคืนครุภัณฑ์หรือไม่?\n"
            , "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result2 == DialogResult.Yes)
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

                    //if (selectedImages.Count <= 0)
                    //{
                    //    warningMessage += "ต้องใส่ภาพยืนยัน ก่อนที่จะทำการคืนครุภัณฑ์\n";
                    //}
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
            else
            {

            }
            
        }

        private void EditItemToDB()
        {
            //EmbedImage
            //Create reference for image we used.
            bool isdumplicated = false;
            // Use the user's application data folder for saving images
            string applicationDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MDT_Inventory");
            string DataFolder = GlobalVariable.FilePath;
            string TemporaryDataFolder = Path.Combine(applicationDataFolder, "TemporaryPictureData");
            //string saveDirectory = @"C:\Program Files\MDT_Inventory\DBImages";
            List<string> newSHA512hashes = new List<string>();

            if (!Directory.Exists(TemporaryDataFolder))
            {
                // Create the subfolder if it doesn't exist
                Directory.CreateDirectory(TemporaryDataFolder);
            }
            if (!Directory.Exists(DataFolder))
            {
                // Create the subfolder if it doesn't exist
                Directory.CreateDirectory(DataFolder);
            }

            List<string> savedFilePaths = new List<string>();

            if (selectedImages.Count > 0)
            {
                for (int i = 0; i < selectedImages.Count; i++)
                {
                    // Calculate SHA-512 checksum for the current image
                    string sha512Checksum = CalculateSHA512Checksum1pic(selectedImages[i]);

                    // Check if the checksum already exists in the newSHA512hashes
                    if (newSHA512hashes.Contains(sha512Checksum))
                    {
                        // Find the index of the duplicate in the newSHA512hashes
                        int duplicateIndex = newSHA512hashes.IndexOf(sha512Checksum);
                        isdumplicated = true;
                        // Console.WriteLine($"Duplicate file found and not saved: {selectedImages[i].Tag.ToString()}");

                        // Optionally, perform some action for duplicate (e.g., show a message)

                        // Skip saving the duplicate file
                        continue;
                    }

                    // Save the file if it's not a duplicate
                    string uniqueFileName = $"Image_{Guid.NewGuid()}.jpg"; // Generate a unique file name
                    string outputPath = Path.Combine(DataFolder, uniqueFileName);
                    // Check if the file already exists and generate a unique name if needed
                    //while (File.Exists(Path.Combine(temporarySaveDirectory, fileName)))
                    //{
                    //    fileName = $"{Path.GetFileNameWithoutExtension(baseFileName)}_{fileCounter}{Path.GetExtension(baseFileName)}";
                    //    fileCounter++;
                    //}

                    string filePath = outputPath;
                    selectedImages[i].Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                    // Add the saved file path and SHA-512 hash to the lists
                    savedFilePaths.Add(filePath);
                    newSHA512hashes.Add(sha512Checksum);
                }
            }

            string jsonmd5Data = JsonConvert.SerializeObject(newSHA512hashes, Formatting.Indented);
            Console.WriteLine(jsonmd5Data);
            string jsonPicData = JsonConvert.SerializeObject(savedFilePaths, Formatting.Indented);
            Console.WriteLine(jsonPicData);

            //Assign data
            if (TemporaryData == null) return;

            TemporaryData.ActualReturnDate = DateTime.Now; 
            TemporaryData.Status = 2;

            RentHistory newrent = new RentHistory();
            newrent.InitialBorrowDate = TemporaryData.InitialBorrowDate.Value;
            newrent.Borrower_Contact = TemporaryData.Borrower_Contact;
            newrent.Borrower_Name = TemporaryData.Borrower_Name;
            newrent.EstReturnDate = TemporaryData.EstReturnDate.Value;
            newrent.ActualReturnDate = TemporaryData.ActualReturnDate.Value;
            newrent.Note = TemporaryData.Note;
            newrent.ImageData = jsonPicData;
            newrent.SHA512 = jsonmd5Data;

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
                        if (isdumplicated)
                        {
                            MessageBox.Show("การคืนครุภัณฑ์สำเร็จ ภาพที่ซ้ำกันจะหายไป!");
                        }
                        else
                        {
                            MessageBox.Show("การคืนครุภัณฑ์สำเร็จ!");
                        }
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

        private void Return_Item_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
            }
        }

        private void Add_Return_Pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files (*.*)|*.*";
            openFileDialog.Title = "Select Image(s) to Upload";
            openFileDialog.Multiselect = true; // Allow multiple file selection

            // Use the user's application data folder for saving images
            string applicationDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MDT_Inventory");

            // Append a subfolder named "TemporaryPictureData"
            string temporaryDataFolder = Path.Combine(applicationDataFolder, "TemporaryPictureData");

            //MessageBox.Show(temporaryDataFolder);

            if (!Directory.Exists(temporaryDataFolder))
            {
                // Create the subfolder if it doesn't exist
                Directory.CreateDirectory(temporaryDataFolder);
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string selectedFilePath in openFileDialog.FileNames)
                {
                    Image selectedImage = Image.FromFile(selectedFilePath);
                    //MessageBox.Show(CalculateSHA512Checksum1pic(selectedImage));
                    string uniqueFileName = $"Image_{Guid.NewGuid()}.jpg"; // Generate a unique file name
                    string outputPath = Path.Combine(temporaryDataFolder, uniqueFileName);

                    selectedImage.Save(outputPath, ImageFormat.Jpeg);

                    // Add the saved image to the list
                    selectedImage = Image.FromFile(outputPath);

                    //MessageBox.Show(CalculateSHA512Checksum1pic(selectedImage));
                    selectedImages.Add(selectedImage);

                    // Optionally, you can display each image in a separate PictureBox

                }

                CheckImageButtonBehavior();
                ChangePicture(0);
            }
        }

        private System.Drawing.Image ConvertToJpeg(System.Drawing.Image image)
        {
            // Convert the image to JPEG format
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return System.Drawing.Image.FromStream(memoryStream);
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
                    image.Save(stream, ImageFormat.Jpeg); // You can choose the appropriate format
                    stream.Seek(0, SeekOrigin.Begin); // Reset stream position

                    byte[] sha512ChecksumBytes = sha512.ComputeHash(stream);
                    string sha512Checksum = BitConverter.ToString(sha512ChecksumBytes).Replace("-", "").ToLower();
                    sha512Values = sha512Checksum;
                }
            }
            return sha512Values;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Before we delete picture.
            //Delete existing picture in picture box
            //
            //Your custom logic when the button is clicked
            //Confirmation Box
            if (selectedImages.Count <= 0) return;
            DialogResult result = MessageBox.Show
            ("ต้องการลบรูปภาพนี้หรือไม่?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // User clicked "Yes," perform the action
                bool isremovingsuccessful = false;
                if (selectedImages.Count > 0)
                {
                    //if (selectedImages[(int)selectingImage] == Properties.Resources.corruptedfile)
                    //{

                    //}
                    selectedImages.Remove(selectedImages[(int)selectingImage]);
                    isremovingsuccessful = true;
                }
                if (isremovingsuccessful)
                {
                    CheckImageButtonBehavior();
                    if (selectedImages.Count <= 0)
                    {
                        ChangePicture(null);
                    }
                    else if (selectingImage + 1 > selectedImages.Count)
                    {
                        ChangePicture(selectedImages.Count - 1);
                    }
                    else
                    {
                        ChangePicture(selectingImage);
                    }
                }
                else
                {
                    ChangePicture(null);
                    CheckImageButtonBehavior();
                }
            }
            else
            {
                // User clicked "No" or closed the dialog, do nothing or handle as needed
            }
            ////////////////////////////////////////////////////////////////
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (selectedImages.Count <= 0)
            {
                return;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.Delete_Picture;
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (selectedImages.Count <= 0)
            {
                ChangePicture(null);
            }
            else
            {
                ChangePicture((int)selectingImage);
            }
        }

        private void Note_TXT_Enter(object sender, EventArgs e)
        {
            if (Note_TXT.Text == defaultnote)
            {
                Note_TXT.Text = "";
                Note_TXT.ForeColor = Color.Black;
            }
        }

        private void Note_TXT_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Note_TXT.Text) || Note_TXT.Text == defaultnote)
            {
                Note_TXT.Text = defaultnote;
                Note_TXT.ForeColor = Color.Gray;
            }
        }
    }
}
