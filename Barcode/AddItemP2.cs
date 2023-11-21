﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Drawing.Imaging;
using System.Web;
using MySqlX.XDevAPI.Common;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class AddItemP2 : Form
    {
        //string PicFilePath = null;
        int checkstate = -1;
        int conditionstate = -1;
        List<Image> selectedImages = new List<Image>();
        int? selectingImage = null;
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
        public AddItemP2()
        {
            InitializeComponent();
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

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string selectedFilePath in openFileDialog.FileNames)
                {
                    // Load the selected image into the PictureBox
                    System.Drawing.Image selectedImage = System.Drawing.Image.FromFile(selectedFilePath);

                    // You can add the selected image to a list to store multiple images
                    selectedImages.Add(selectedImage);

                    // Optionally, you can display each image in a separate PictureBox
                }
                CheckImageButtonBehavior();
                ChangePicture(0);
            }
        }
        private void BarcodeScanner_BarcodeScanned(object sender, BarcodeScannerEventArgs e)
        {
            SearchBarcodeData(e.Barcode, sender);
        }

        private void Add_Item_toDB_Click(object sender, EventArgs e)
        {
            //Serach before we do something.
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
                bool isDataSame = dbData.Contains(BarcodeID_TB.Text); // Check if the barcode is already in the database

                string warningMessage = "";

                if (isDataSame)
                {
                    warningMessage += "ไม่สามารถเพิ่มข้อมูลลงในระบบได้ เนื่องจากมีรหัสครุภัณฑ์นี้อยู่แล้ว\n";
                }

                if (BarcodeID_TB.Text == "" || ProductName_TB.Text == ""  ||
                    ProductName_TB.Text == ProductNameDF || checkstate == -1 || BarcodeID_TB.Text == BarcodeIDDF)
                {
                    warningMessage += "กรุณากรอกรายละเอียดของครุภัณฑ์ให้ครบถ้วน ก่อนทำการเพิ่่มเข้ามา\n";
                }

                if (BarcodeID_TB.Text.Length > 50)
                {
                    warningMessage += "ความยาว Barcode ห้ามเกิน 50 ตัวอักษร\n";
                }

                if (Model_TB.Text.Length > 100 || ProductName_TB.Text.Length > 100 || Brand_TB.Text.Length > 100 
                    || Serial_TB.Text.Length > 100 ||  Room_TB.Text.Length > 100)
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
                    AddItemToDB();
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
        private void AddItemToDB()
        {
            //List<byte[]> ImageList = new List<byte[]>();
            string connectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";
            MySqlConnection mySqlConnection2 = new MySqlConnection(connectionString);
            bool isdumplicated = false;
            try
            {
                //Create reference for image we used.
                string saveDirectory = @"C:\BarcodeDatabaseImage";
                List<string> newSHA512hashes = new List<string>();
                Directory.CreateDirectory(saveDirectory);
                
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
                        string baseFileName = "image.jpeg"; // Base file name
                        string fileName = baseFileName;
                        int fileCounter = 1;

                        // Check if the file already exists and generate a unique name if needed
                        while (File.Exists(Path.Combine(saveDirectory, fileName)))
                        {
                            fileName = $"{Path.GetFileNameWithoutExtension(baseFileName)}_{fileCounter}{Path.GetExtension(baseFileName)}";
                            fileCounter++;
                        }

                        string filePath = Path.Combine(saveDirectory, fileName);
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

                //TryAddittoDATABASE
                mySqlConnection2.Open();

                string query = "INSERT INTO information (BarcodeNumber, Product_Name, Model_Name, Brand, Serial_Number, Price, Room, Note, ImageData, MD5_ImageValidityChecksum, Status, ITEM_CONDITION) " +
               "VALUES (@BarcodeNumber, @Product_Name, @Model_Name, @Brand, @Serial_Number, @Price, @Room, @Note, @ImageData, @MD5_ImageValidityChecksum, @Status, @ITEM_CONDITION)";


                using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection2))
                {
                    cmd.Parameters.AddWithValue("@BarcodeNumber", BarcodeID_TB.Text);
                    cmd.Parameters.AddWithValue("@Product_Name", ProductName_TB.Text);
                    cmd.Parameters.AddWithValue("@Model_Name", Model_TB.Text);
                    cmd.Parameters.AddWithValue("@Brand", Brand_TB.Text);
                    cmd.Parameters.AddWithValue("@Serial_Number", Serial_TB.Text);
                    cmd.Parameters.AddWithValue("@Price", int.Parse(Price_TB.Text));
                    cmd.Parameters.AddWithValue("@Room", Room_TB.Text);
                    cmd.Parameters.AddWithValue("@ImageData", jsonPicData);
                    cmd.Parameters.AddWithValue("@MD5_ImageValidityChecksum", jsonmd5Data);
                    cmd.Parameters.AddWithValue("@Note", Note_TB.Text);
                    cmd.Parameters.AddWithValue("@Status", checkstate);
                    cmd.Parameters.AddWithValue("@ITEM_CONDITION", conditionstate);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        if (!isdumplicated)
                        {
                            MessageBox.Show("การนำเข้าข้อมูลครุภัณฑ์สำเร็จ!");
                        }
                        else
                        {
                            MessageBox.Show("การนำเข้าข้อมูลครุภัณฑ์สำเร็จ ภาพที่ซ้ำกันจะถูกลบออก!");
                        }
                        //PullDataFromDB();
                    }
                    else
                    {
                        MessageBox.Show("การนำเข้าข้อมูลครุภัณฑ์ล้มเหลว.");
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
                AddItemP2 AddItemForm = MainMenu.initializedForms.Find(f => f is AddItemP2) as AddItemP2;
                ManageQR ManageQRForm = MainMenu.initializedForms.Find(f => f is ManageQR) as ManageQR;
                if (AddItemForm != null)
                {
                    AddItemForm.Hide();
                }
                if (ManageQRForm != null)
                {
                    ManageQRForm.SearchDatainDB();
                }
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
                mySqlConnection.Close();
                if (isDataSame)
                {
                    MessageBox.Show("ไม่สามารถเพิ่มข้อมูลลงในระบบได้ เนื่องจากมี Barcode นี้อยู่แล้ว");
                    this.Hide();
                }
                else
                {
                    //
                    if (sender == BarcodeID_TB)
                    {
                        BarcodeID_TB.Text = barcode;
                    }
                    else
                    {
                        BarcodeID_TB.Text = barcode;
                        ///
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

                        BarcodeID_TB.Text = barcode;
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
                        ConditionBox.SelectedIndex = -1;
                        checkstate = -1;
                        conditionstate = -1;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

            //PicFilePath = "";
            //pictureBox1.Image = Properties.Resources.NoImage;
            this.ActiveControl = null;
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
            ConditionBox.SelectedIndex = conditionstate;
        }

        private void Form_Closing3(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
            }
        }

        private void S_Have_CheckedChanged(object sender, EventArgs e)
        {
            if (S_Have.Checked || !S_Donthave.Checked)
            {
                checkstate = 0; //มี
            }
            else
            {
                checkstate = 1; //ไม่มี
            }
            //MessageBox.Show(S_Have.Checked.ToString() + " " + conditionstate);
        }

        private void S_Donthave_CheckedChanged(object sender, EventArgs e)
        {
            if (S_Have.Checked || !S_Donthave.Checked)
            {
                checkstate = 0; //มี
            }
            else
            {
                checkstate = 1; //ไม่มี
            }
            //MessageBox.Show(S_Have.Checked.ToString() + " " + conditionstate);
        }

        private void ConditionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            conditionstate = ConditionBox.SelectedIndex;
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
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Before we delete picture.
            //Delete existing picture in picture box
            //
            //Your custom logic when the button is clicked
            //Confirmation Box
            if (selectedImages.Count <= 0) return;
            DialogResult result = MessageBox.Show
            ("Are you sure to delete this image?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // User clicked "Yes," perform the action
                bool isremovingsuccessful = false;
                if (selectedImages.Count > 0)
                {
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

        private void Pic1_Enter(object sender, EventArgs e)
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

        private void Pic1_Leave(object sender, EventArgs e)
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
    }
}
