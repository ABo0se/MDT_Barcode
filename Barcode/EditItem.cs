using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using USB_Barcode_Scanner_Tutorial___C_Sharp.Properties;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class EditItem : Form
    {
        int checkstate = -1;
        int conditionstate = -1;
        List<Image> selectedImages = new List<Image>();
        List<string> TemporaryPathData = new List<string>();
        int? selectingImage = null;
        SRResults TemporaryData = null;
        /////////////////////////////////////////////
        string BarcodeIDDF = "[ตัวอย่าง : 460650003296]";
        string ProductNameDF = "[ตัวอย่าง : Occulus Quest 2023]";
        string ModelDF = "[ตัวอย่าง : KD-43X8000H]";
        string BrandDF = "[ตัวอย่าง : Google]";
        string SerialDF = "[ตัวอย่าง : ABC12345XYZ]";
        string PriceDF = "[ตัวอย่าง : 1000]";
        string RoomDF = "[ตัวอย่าง : 516]";
        string NoteDF = "[ตัวอย่าง : วัสดุนี้ได้ซื้อในราคาพิเศษ]";
        ////////////////////////////////////////////
        public EditItem()
        {
            InitializeComponent();
        }
        public void AssignBarcodeText(string barcodetext)
        {
            if (TryFetchDataBySerialCode(barcodetext, out SRResults data))
            {
                //DisplayData
                TemporaryData = data;
                BarcodeID_TB.Text = TemporaryData.BarcodeNumber;
                ProductName_TB.Text = TemporaryData.Product_Name;
                Model_TB.Text = TemporaryData.ModelNumber;
                Brand_TB.Text = TemporaryData.Brand;
                Serial_TB.Text = TemporaryData.SerialNum;
                Price_TB.Text = TemporaryData.Price;
                Room_TB.Text = TemporaryData.Room;
                Note_TB.Text = TemporaryData.Description;

                BarcodeID_TB.ForeColor = Color.Black;
                ProductName_TB.ForeColor = Color.Black;
                Model_TB.ForeColor = Color.Black;
                Brand_TB.ForeColor = Color.Black;
                Serial_TB.ForeColor = Color.Black;
                Price_TB.ForeColor = Color.Black;
                Room_TB.ForeColor = Color.Black;
                Note_TB.ForeColor = Color.Black;
                ////////////////////////////////////
                selectedImages.Clear();
                List<string> path = JsonConvert.DeserializeObject<List<string>>(data.FilePath);
                List<string> SHA512 = JsonConvert.DeserializeObject<List<string>>(data.SHA512);
                if (path.Count > 0)
                {
                    for (int i = 0; i < path.Count; i++)
                    {
                        if (File.Exists(path[i]))
                        {
                            Image selectedImage = Image.FromFile(path[i]);
                            //MessageBox.Show(path[i]);
                            //MessageBox.Show(SHA512[i]);
                            //MessageBox.Show(CalculateSHA512Checksum1pic(Image.FromFile(path[i])));
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
                checkstate = TemporaryData.Status;
                conditionstate = TemporaryData.Condition;
                switch (checkstate)
                {
                    case -1:
                        {
                            S_HaveEdit.Checked = false;
                            S_DonthaveEdit.Checked = false;
                            break;
                        }
                    case 0:
                        {
                            S_HaveEdit.Checked = true;
                            S_DonthaveEdit.Checked = false;
                            break;
                        }
                    case 1:
                        {
                            S_HaveEdit.Checked = false;
                            S_DonthaveEdit.Checked = true;
                            break;
                        }
                }
                ConditionBoxEdit.SelectedIndex = conditionstate;
                ///
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddItemP2_Load(object sender, EventArgs e)
        {
              InitializePage();
        }

        private void Created_Time_Click(object sender, EventArgs e)
        {

        }

        private void Room_Click(object sender, EventArgs e)
        {

        }

        private void Add_Pic_Click(object sender, EventArgs e)
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
                    selectedImage.Tag = "NormalFile";
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
        private void Add_Item_toDB_Click(object sender, EventArgs e)
        {
            //Check if we own data beforehand.
            if (TemporaryData == null)
            {
                MessageBox.Show("ไม่มีข้อมูลที่เก็บไว้ชั่วคราว");
                this.Hide();
                return;
            }
            ////////////////////////////////////////////////////////////
            ///Serach before we do something.
            List<string> dbData = new List<string>();
            string dbConnectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(dbConnectionString);

            try
            {
                mySqlConnection.Open();
                string selectQuery = "SELECT BarcodeNumber FROM information";

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
                    warningMessage += "ไม่สามารถเพิ่มข้อมูลลงในระบบได้ เนื่องจากไม่ได้บันทึกรหัสครุภัณฑ์เดิมไว้\n";
                }

                if (BarcodeID_TB.Text == "" || ProductName_TB.Text == "" ||
                    ProductName_TB.Text == ProductNameDF || checkstate == -1 || BarcodeID_TB.Text == BarcodeIDDF)
                {
                    warningMessage += "กรุณากรอกรายละเอียดของครุภัณฑ์ให้ครบถ้วน ก่อนทำการเพิ่่มเข้ามา\n";
                }

                if (BarcodeID_TB.Text.Length > 50)
                {
                    warningMessage += "ความยาว Barcode ห้ามเกิน 50 ตัวอักษร\n";
                }

                if (Model_TB.Text.Length > 100 || ProductName_TB.Text.Length > 100 || Brand_TB.Text.Length > 100
                    || Serial_TB.Text.Length > 100 || Room_TB.Text.Length > 100)
                {
                    warningMessage += "ความยาวของข้อมูลผลิตภัณฑ์ ห้ามเกิน 100 ตัวอักษร\n";
                }
                if (Price_TB.Text.Length > 30)
                {
                    warningMessage += "ความยาวของราคา ห้ามเกิน 30 ตัวอักษร\n";
                }
                if (Note_TB.Text.Length > 200)
                {
                    warningMessage += "ความยาวของหมายเหตุห้ามเกิน 200 ตัวอักษร\n";
                }
                //////////////////////////////////////////////
                if (Model_TB.Text == ModelDF || Model_TB.Text == "")
                {
                    Model_TB.Text = "-";
                }
                if (Brand_TB.Text == BrandDF || Brand_TB.Text == "")
                {
                    Brand_TB.Text = "-";
                }
                if (Serial_TB.Text == SerialDF || Serial_TB.Text == "")
                {
                    Serial_TB.Text = "-";
                }
                if (Room_TB.Text == RoomDF || Room_TB.Text == "")
                {
                    Room_TB.Text = "-";
                }
                if (Note_TB.Text == NoteDF || Note_TB.Text == "")
                {
                    Note_TB.Text = "-";
                }
                if (Price_TB.Text == PriceDF || Price_TB.Text == "")
                {
                    Price_TB.Text = "0";
                }
                //////////////////////////////////////////////
                if (!int.TryParse(Price_TB.Text, out int result))
                {
                    warningMessage += "กรุณากรอกราคาเป็นตัวเลขเท่านั้น\n";
                }
                if (!string.IsNullOrEmpty(warningMessage))
                {
                    MessageBox.Show(warningMessage);
                }
                else
                {
                    EditmyDataBase();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EditmyDataBase()
        {
            // Create reference for image we used.
            string applicationDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MDT_Inventory");
            string DataFolder = GlobalVariable.FilePath;
            string TemporaryDataFolder = Path.Combine(applicationDataFolder, "TemporaryPictureData");

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

            List<string> oldsavedFilePaths = new List<string>();
            List<string> oldSHA512hash = new List<string>();

            List<string> savedFilePaths = new List<string>();
            List<string> SHA512hash = new List<string>();

            // Retrieve existing SHA-512 checksums from the database (you need to implement this)

            /////////////////
            if (TemporaryData != null)
            {
                oldsavedFilePaths = JsonConvert.DeserializeObject<List<string>>(TemporaryData.FilePath);
                oldSHA512hash = JsonConvert.DeserializeObject<List<string>>(TemporaryData.SHA512);
            }
            /////////////////
            bool isDuplicated = false;

            if (selectedImages.Count > 0)
            {
                for (int i = 0; i < selectedImages.Count; i++)
                {
                    if (!(selectedImages[i].Tag.ToString() == "FileCorrupt" || selectedImages[i].Tag.ToString() == "FileMissing"))
                    {
                        bool isdup = false;
                        //string baseFileName = "image.jpg"; // Base file name
                        //string fileName = baseFileName;

                        // Calculate the SHA-512 checksum for the newly saved image
                        string checksum = CalculateSHA512Checksum1pic(selectedImages[i]);
                        //MessageBox.Show(checksum);
                        // Check if the checksum exists in the currently processed data
                        for (int j = 0; j < i; j++)
                        {
                            if (checksum == CalculateSHA512Checksum1pic(selectedImages[j]))
                            {
                                // Set isDuplicated to true if the SHA-512 already exists
                                isDuplicated = true;
                                isdup = true;

                                // Optionally, perform some action for duplicates (e.g., show a message)
                                // Console.WriteLine($"Duplicate file found: {selectedImages[i].Tag.ToString()}");

                                // Continue to the next iteration of the loop
                                continue;
                            }
                        }

                        // If it's not a duplicate or if duplicates are allowed
                        if (!isdup)
                        {
                            string uniqueFileName = $"Image_{Guid.NewGuid()}.jpg"; // Generate a unique file name
                            string outputPath = Path.Combine(DataFolder, uniqueFileName);
                            //int fileCounter = 1;
                            //// Check if the file already exists and generate a unique name if needed
                            //while (File.Exists(Path.Combine(saveDirectory, fileName)))
                            //{
                            //    fileName = $"{Path.GetFileNameWithoutExtension(baseFileName)}_{fileCounter}{Path.GetExtension(baseFileName)}";
                            //    fileCounter++;
                            //}
                            ///////////////////
                            string filePath = outputPath;
                            // MessageBox.Show(CalculateSHA512Checksum1pic(selectedImages[i]));
                            // Save the file
                            selectedImages[i].Save(filePath);
                            savedFilePaths.Add(filePath);
                            SHA512hash.Add(checksum);
                        }
                    }
                }
            }

            else
            {
                SHA512hash = CalculateSHA512Checksum(new List<Image>());
            }

            string jsonmd5Data = JsonConvert.SerializeObject(SHA512hash, Formatting.Indented);
            Console.WriteLine(jsonmd5Data);

            string jsonPicData = JsonConvert.SerializeObject(savedFilePaths, Formatting.Indented);
            Console.WriteLine(jsonPicData);


            ////////////
            string connectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";
            MySqlConnection mySqlConnection2 = new MySqlConnection(connectionString);

            try
            {
                mySqlConnection2.Open();

                string query = "UPDATE information SET " +
               "BarcodeNumber = @BarcodeNumber, " +
               "Product_Name = @Product_Name, " +
               "Model_Name = @Model_Name, " +
               "Brand = @Brand, " +
               "Serial_Number = @Serial_Number, " +
               "Price = @Price, " +
               "Room = @Room, " +
               "ImageData = @ImageData, " +
               "MD5_ImageValidityChecksum = @MD5_ImageValidityChecksum, " +
               "Note = @Note, " + // Add a comma here
               "Status = @Status, " + // Add a comma here
               "ITEM_CONDITION = @ITEM_CONDITION " + // Add a space here

               "WHERE BarcodeNumber = @BarcodeNumberReplacement";


                //if (PicFilePath == null)
                //{
                //    PicFilePath = "";
                //}

                using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection2))
                {
                    cmd.Parameters.AddWithValue("@Product_Name", ProductName_TB.Text);
                    cmd.Parameters.AddWithValue("@Model_Name", Model_TB.Text);
                    cmd.Parameters.AddWithValue("@Brand", Brand_TB.Text);
                    cmd.Parameters.AddWithValue("@Serial_Number", Serial_TB.Text);
                    cmd.Parameters.AddWithValue("@Price", Price_TB.Text);
                    cmd.Parameters.AddWithValue("@Room", Room_TB.Text);
                    cmd.Parameters.AddWithValue("@ImageData", jsonPicData);
                    cmd.Parameters.AddWithValue("@MD5_ImageValidityChecksum", jsonmd5Data);
                    cmd.Parameters.AddWithValue("@Note", Note_TB.Text);
                    cmd.Parameters.AddWithValue("@Status", checkstate);
                    cmd.Parameters.AddWithValue("@ITEM_CONDITION", conditionstate);
                    //////////
                    cmd.Parameters.AddWithValue("@BarcodeNumberReplacement", TemporaryData.BarcodeNumber);
                    cmd.Parameters.AddWithValue("@BarcodeNumber", BarcodeID_TB.Text);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        if (!isDuplicated)
                        {
                            MessageBox.Show("การปรับเปลี่ยนข้อมูลสำเร็จ!");
                        }
                        else
                        {
                            MessageBox.Show("การนำเข้าข้อมูลครุภัณฑ์สำเร็จ ภาพที่ซ้ำกันจะถูกลบออก!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("การปรับเปลี่ยนข้อมูลล้มเหลว");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด : " + ex);
            }
            finally
            {
                mySqlConnection2.Close();
                DeleteAllPictures(TemporaryDataFolder);
                EditItem EditItemForm = MainMenu.initializedForms.Find(f => f is EditItem) as EditItem;
                if (EditItemForm != null)
                {
                    EditItemForm.Hide();
                }
                ManageQR QRForm = MainMenu.initializedForms.Find(f => f is ManageQR) as ManageQR;
                if (QRForm != null)
                {
                    QRForm.SearchDatainDB();
                }
            }
        }


        public void InitializePage()
        {
            BarcodeScanner2 barcodeScanner1 = new BarcodeScanner2(BarcodeID_TB);
            BarcodeScanner2 barcodeScanner2 = new BarcodeScanner2(ProductName_TB);
            BarcodeScanner2 barcodeScanner3 = new BarcodeScanner2(Model_TB);
            BarcodeScanner2 barcodeScanner4 = new BarcodeScanner2(Brand_TB);
            BarcodeScanner2 barcodeScanner5 = new BarcodeScanner2(Serial_TB);
            BarcodeScanner2 barcodeScanner6 = new BarcodeScanner2(Price_TB);
            BarcodeScanner2 barcodeScanner7 = new BarcodeScanner2(Room_TB);
            BarcodeScanner2 barcodeScanner8 = new BarcodeScanner2(Note_TB);
            barcodeScanner1.BarcodeScanned += BarcodeScanner_BarcodeScanned;
            barcodeScanner2.BarcodeScanned += BarcodeScanner_BarcodeScanned;
            barcodeScanner3.BarcodeScanned += BarcodeScanner_BarcodeScanned;
            barcodeScanner4.BarcodeScanned += BarcodeScanner_BarcodeScanned;
            barcodeScanner5.BarcodeScanned += BarcodeScanner_BarcodeScanned;
            barcodeScanner6.BarcodeScanned += BarcodeScanner_BarcodeScanned;
            barcodeScanner7.BarcodeScanned += BarcodeScanner_BarcodeScanned;
            barcodeScanner8.BarcodeScanned += BarcodeScanner_BarcodeScanned;
            /////////////////////////////////
            this.ActiveControl = null;
            if (selectedImages != null || TemporaryPathData != null)
            {
                selectedImages.Clear();
                TemporaryPathData.Clear();
            }
            else
            {
                selectedImages = new List<System.Drawing.Image>();
                TemporaryPathData = new List<string>();
            }

            ChangePicture(null);
            CheckImageButtonBehavior();

            //PicFilePath = "";
            //pictureBox1.Image = Properties.Resources.NoImage;
            BarcodeID_TB.Text = BarcodeIDDF;
            ProductName_TB.Text = ProductNameDF;
            Model_TB.Text = ModelDF;
            Brand_TB.Text = BrandDF;
            Serial_TB.Text = SerialDF;
            Price_TB.Text = PriceDF;
            Room_TB.Text = RoomDF;
            Note_TB.Text = NoteDF;

            BarcodeID_TB.ForeColor = Color.Gray;
            ProductName_TB.ForeColor = Color.Gray;
            Model_TB.ForeColor = Color.Gray;
            Brand_TB.ForeColor = Color.Gray;
            Serial_TB.ForeColor = Color.Gray;
            Price_TB.ForeColor = Color.Gray;
            Room_TB.ForeColor = Color.Gray;
            Note_TB.ForeColor = Color.Gray;

            checkstate = -1;
            conditionstate = -1;

            S_Have.Checked = false;
            S_Donthave.Checked = false;
            ConditionBoxEdit.SelectedIndex = conditionstate;
        }

        private void BarcodeScanner_BarcodeScanned(object sender, BarcodeScannerEventArgs e)
        {
            SearchBarcodeData(e.Barcode, sender);
        }

        private void SearchBarcodeData(string barcode, object sender)
        {
            List<string> dbData = new List<string>();
            string dbConnectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(dbConnectionString);

            try
            {
                mySqlConnection.Open();
                string selectQuery = "SELECT BarcodeNumber FROM information";

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
                bool isDataSame = dbData.Contains(barcode); // Check if the barcode is already in the database

                if (isDataSame)
                {
                    MessageBox.Show("ไม่สามารถเพิ่มข้อมูลลงในระบบได้ เนื่องจากมีรหัสครุภัณฑ์นี้อยู่แล้ว");
                    this.Hide();
                }
                else
                {
                    //
                    if (sender == BarcodeID_TB)
                    {
                        BarcodeID_TB.Text = barcode;
                        //MessageBox.Show("Matched");
                    }
                    else
                    {
                        BarcodeID_TB.Text = barcode;
                        ///
                        ProductName_TB.Text = ProductNameDF;
                        Model_TB.Text = ModelDF;
                        Brand_TB.Text = BrandDF;
                        Serial_TB.Text = SerialDF;
                        Price_TB.Text = PriceDF;
                        Room_TB.Text = RoomDF;
                        Note_TB.Text = NoteDF;

                        BarcodeID_TB.ForeColor = Color.Black;
                        ProductName_TB.ForeColor = Color.Gray;
                        Model_TB.ForeColor = Color.Gray;
                        Brand_TB.ForeColor = Color.Gray;
                        Serial_TB.ForeColor = Color.Gray;
                        Price_TB.ForeColor = Color.Gray;
                        Room_TB.ForeColor = Color.Gray;
                        Note_TB.ForeColor = Color.Gray;

                        S_Have.Checked = false;
                        S_Donthave.Checked = false;
                        ConditionBoxEdit.SelectedIndex = -1;
                        checkstate = -1;
                        conditionstate = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mySqlConnection.Close(); // Make sure to close the connection when done
            }
        }

        private void Form_Closing3(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
            }
        }

        private bool TryFetchDataBySerialCode(string serialCode, out SRResults data)
        {
            data = null;
            string dbConnectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(dbConnectionString);
            try
            {
                mySqlConnection.Open();
                string selectQuery = "SELECT * FROM information WHERE BarcodeNumber = @BarcodeNumber";

                MySqlCommand command = new MySqlCommand(selectQuery, mySqlConnection);
                {
                    command.Parameters.AddWithValue("@BarcodeNumber", serialCode);
                    MySqlDataReader reader = command.ExecuteReader();
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
            catch (Exception e)
            {
                MessageBox.Show("Error : " + e.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
            if (data != null)
                return true;
            else
                return false;
        }

        private void S_Have_CheckedChanged(object sender, EventArgs e)
        {
            if (S_HaveEdit.Checked || !S_DonthaveEdit.Checked)
            {
                checkstate = 0; //มี
            }
            else
            {
                checkstate = 1; //ไม่มี
            }
        }

        private void S_Donthave_CheckedChanged(object sender, EventArgs e)
        {
            if (S_HaveEdit.Checked || !S_DonthaveEdit.Checked)
            {
                checkstate = 0; //มี
            }
            else
            {
                checkstate = 1; //ไม่มี
            }
        }

        private void ConditionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            conditionstate = ConditionBoxEdit.SelectedIndex;
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

        private void EditPic_Enter(object sender, EventArgs e)
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

        private void EditPic_Leave(object sender, EventArgs e)
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

        private void BarcodeID_TB_Enter(object sender, EventArgs e)
        {
            if (BarcodeID_TB.Text == BarcodeIDDF)
            {
                BarcodeID_TB.Text = "";
                BarcodeID_TB.ForeColor = Color.Black;
            }
        }

        private void Model_TB_Enter(object sender, EventArgs e)
        {
            if (Model_TB.Text == ModelDF)
            {
                Model_TB.Text = "";
                Model_TB.ForeColor = Color.Black;
            }
        }

        private void Brand_TB_Enter(object sender, EventArgs e)
        {
            if (Brand_TB.Text == BrandDF)
            {
                Brand_TB.Text = "";
                Brand_TB.ForeColor = Color.Black;
            }
        }

        private void Serial_TB_Enter(object sender, EventArgs e)
        {
            if (Serial_TB.Text == SerialDF)
            {
                Serial_TB.Text = "";
                Serial_TB.ForeColor = Color.Black;
            }
        }

        private void Price_TB_Enter(object sender, EventArgs e)
        {
            if (Price_TB.Text == PriceDF)
            {
                Price_TB.Text = "";
                Price_TB.ForeColor = Color.Black;
            }
        }

        private void Room_TB_Enter(object sender, EventArgs e)
        {
            if (Room_TB.Text == RoomDF)
            {
                Room_TB.Text = "";
                Room_TB.ForeColor = Color.Black;
            }
        }

        private void Note_TB_Enter(object sender, EventArgs e)
        {
            if (Note_TB.Text == NoteDF)
            {
                Note_TB.Text = "";
                Note_TB.ForeColor = Color.Black;
            }
        }

        private void BarcodeID_TB_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(BarcodeID_TB.Text) || BarcodeID_TB.Text == BarcodeIDDF)
            {
                BarcodeID_TB.Text = BarcodeIDDF;
                BarcodeID_TB.ForeColor = Color.Gray;
            }
            else
            {
                BarcodeID_TB.ForeColor = Color.Black;
            }
        }

        private void Model_TB_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Model_TB.Text) || Model_TB.Text == ModelDF)
            {
                Model_TB.Text = ModelDF;
                Model_TB.ForeColor = Color.Gray;
            }
            else
            {
                Model_TB.ForeColor = Color.Black;
            }
        }

        private void Brand_TB_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Brand_TB.Text) || Brand_TB.Text == BrandDF)
            {
                Brand_TB.Text = BrandDF;
                Brand_TB.ForeColor = Color.Gray;
            }
            else
            {
                Brand_TB.ForeColor = Color.Black;
            }
        }

        private void Serial_TB_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Serial_TB.Text) || Serial_TB.Text == SerialDF)
            {
                Serial_TB.Text = SerialDF;
                Serial_TB.ForeColor = Color.Gray;
            }
            else
            {
                Serial_TB.ForeColor = Color.Black;
            }
        }

        private void Price_TB_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Price_TB.Text) || Price_TB.Text == PriceDF)
            {
                Price_TB.Text = PriceDF;
                Price_TB.ForeColor = Color.Gray;
            }
            else
            {
                Price_TB.ForeColor = Color.Black;
            }
        }

        private void Room_TB_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Room_TB.Text) || Room_TB.Text == RoomDF)
            {
                Room_TB.Text = RoomDF;
                Room_TB.ForeColor = Color.Gray;
            }
            else
            {
                Room_TB.ForeColor = Color.Black;
            }
        }

        private void Note_TB_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Note_TB.Text) || Note_TB.Text == NoteDF)
            {
                Note_TB.Text = NoteDF;
                Note_TB.ForeColor = Color.Gray;
            }
            else
            {
                Note_TB.ForeColor = Color.Black;
            }
        }
        private void ProductName_TB_Enter(object sender, EventArgs e)
        {
            if (ProductName_TB.Text == ProductNameDF)
            {
                ProductName_TB.Text = "";
                ProductName_TB.ForeColor = Color.Black;
            }
        }

        private void ProductName_TB_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ProductName_TB.Text) || ProductName_TB.Text == ProductNameDF)
            {
                ProductName_TB.Text = ProductNameDF;
                ProductName_TB.ForeColor = Color.Gray;
            }
            else
            {
                ProductName_TB.ForeColor = Color.Black;
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

    public class SRResults
    {
        public DateTime Date { get; set; }
        public string FormattedDate { get; set; }
        public string BarcodeNumber { get; set; }
        public string Product_Name { get; set; }
        public string ModelNumber { get; set; }
        public string Brand { get; set; }
        public string SerialNum { get; set; }
        public string Price { get; set; }
        public string Room { get; set; }
        public string FilePath { get; set; }
        public string SHA512 { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Condition { get; set; }
    }
}
