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
using USB_Barcode_Scanner_Tutorial___C_Sharp.Properties;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class EditItem : Form
    {
        int checkstate = -1;
        int conditionstate = -1;
        List<System.Drawing.Image> selectedImages = new List<System.Drawing.Image>();
        int? selectingImage = null;
        SRResults TemporaryData = null;
        ////////////////////////////////////////////////////
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
                Model_TB.Text = TemporaryData.ModelNumber;
                Brand_TB.Text = TemporaryData.Brand;
                Serial_TB.Text = TemporaryData.SerialNum;
                Price_TB.Text = TemporaryData.Price;
                Room_TB.Text = TemporaryData.Room;
                Note_TB.Text = TemporaryData.Description;
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

        private void BarcodeID_TB_TextChanged(object sender, EventArgs e)
        {

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
                //Create reference for image we used.
                string saveDirectory = @"C:\BarcodeDatabaseImage";
                Directory.CreateDirectory(saveDirectory);

                List<string> savedFilePaths = new List<string>();

                if (selectedImages.Count > 0)
                {
                    for (int i = 0; i < selectedImages.Count; i++)
                    {
                        if (!(selectedImages[i] == Resources.corruptedfile || selectedImages[i] == Resources.filemissing))
                        {
                            string baseFileName = "image.jpg"; // Base file name
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

                            // Add the saved file path to the list
                            savedFilePaths.Add(filePath);
                        }
                    }
                }

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
                bool isDataSame2 = dbData.Contains(BarcodeID_TB.Text);
                mySqlConnection.Close();
                ///////////////////////////////////
                string warningMessage = "";
                if (BarcodeID_TB.Text == "" || Model_TB.Text == "" || Brand_TB.Text == "" ||
                         Serial_TB.Text == "" || Price_TB.Text == "" || Room_TB.Text == "" ||
                         Room_TB.Text == "" || Note_TB.Text == "" || conditionstate == -1 || checkstate == -1)
                {
                    warningMessage += "กรุณากรอกรายละเอียดของครุภัณฑ์ให้ครบถ้วน ก่อนทำการเพิ่มเข้ามา\n";
                }
                if (!isDataSame)
                {
                    warningMessage += "กรุณาตรวจสอบรหัสครุภัณฑ์ในฐานข้อมูลที่ต้องการจะแก้ไข\n";
                }
                if (BarcodeID_TB.Text.Length > 50)
                {
                    warningMessage += "ความยาว Barcode ห้ามเกิน 50 ตัวอักษร\n";
                }

                if (Model_TB.Text.Length > 100 || Brand_TB.Text.Length > 100 || Serial_TB.Text.Length > 100 || Room_TB.Text.Length > 100)
                {
                    warningMessage += "ความยาวของข้อมูลผลิตภัณฑ์ห้ามเกิน 100 ตัวอักษร\n";
                }
                if (Note_TB.Text.Length > 200)
                {
                    warningMessage += "ความยาวของหมายเหตุห้ามเกิน 200 ตัวอักษร\n";
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
            //Create reference for image we used.
            string saveDirectory = @"C:\BarcodeDatabaseImage";
            Directory.CreateDirectory(saveDirectory);

            List<string> savedFilePaths = new List<string>();

            if (selectedImages.Count > 0)
            {
                for (int i = 0; i < selectedImages.Count; i++)
                {
                    if (!(selectedImages[i] == Resources.filemissing || selectedImages[i] == Resources.corruptedfile))
                    {
                        string baseFileName = "image.jpg"; // Base file name
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

                        // Add the saved file path to the list
                        savedFilePaths.Add(filePath);
                    }
                }
            }

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
               "Model_Name = @Model_Name, " +
               "Brand = @Brand, " +
               "Serial_Number = @Serial_Number, " +
               "Price = @Price, " +
               "Room = @Room, " +
               "ImageData = @ImageData, " +
               "Note = @Note, " + // Add a comma here
               "ImageData = @ImageData, " +
               "Status = @Status, " + // Add a comma here
               "ITEM_CONDITION = @ITEM_CONDITION " + // Add a space here

               "WHERE BarcodeNumber = @BarcodeNumberReplacement";


                //if (PicFilePath == null)
                //{
                //    PicFilePath = "";
                //}

                using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection2))
                {
                    cmd.Parameters.AddWithValue("@Model_Name", Model_TB.Text);
                    cmd.Parameters.AddWithValue("@Brand", Brand_TB.Text);
                    cmd.Parameters.AddWithValue("@Serial_Number", Serial_TB.Text);
                    cmd.Parameters.AddWithValue("@Price", Price_TB.Text);
                    cmd.Parameters.AddWithValue("@Room", Room_TB.Text);
                    cmd.Parameters.AddWithValue("@ImageData", jsonPicData);
                    cmd.Parameters.AddWithValue("@Note", Note_TB.Text);
                    cmd.Parameters.AddWithValue("@Status", checkstate);
                    cmd.Parameters.AddWithValue("@ITEM_CONDITION", conditionstate);
                    //////////
                    cmd.Parameters.AddWithValue("@BarcodeNumberReplacement", TemporaryData.BarcodeNumber);
                    cmd.Parameters.AddWithValue("@BarcodeNumber", BarcodeID_TB.Text);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Barcode Data updated successfully!");
                        //PullDataFromDB();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update data.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                mySqlConnection2.Close();
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
            BarcodeScanner2 barcodeScanner2 = new BarcodeScanner2(Model_TB);
            BarcodeScanner2 barcodeScanner3 = new BarcodeScanner2(Brand_TB);
            BarcodeScanner2 barcodeScanner4 = new BarcodeScanner2(Serial_TB);
            BarcodeScanner2 barcodeScanner5 = new BarcodeScanner2(Price_TB);
            BarcodeScanner2 barcodeScanner6 = new BarcodeScanner2(Room_TB);
            BarcodeScanner2 barcodeScanner7 = new BarcodeScanner2(Note_TB);
            barcodeScanner2.BarcodeScanned += BarcodeScanner_BarcodeScanned;
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

            //PicFilePath = "";
            //pictureBox1.Image = Properties.Resources.NoImage;
            BarcodeID_TB.Text = "";
            Model_TB.Text = "";
            Brand_TB.Text = "";
            Serial_TB.Text = "";
            Price_TB.Text = "";
            Room_TB.Text = "";
            Note_TB.Text = "";

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
                        Model_TB.Text = "";
                        Brand_TB.Text = "";
                        Serial_TB.Text = "";
                        Price_TB.Text = "";
                        Room_TB.Text = "";
                        Note_TB.Text = "";
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

        private void Model_TB_TextChanged(object sender, EventArgs e)
        {

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
    }

    public class SRResults
    {
        public DateTime Date { get; set; }
        public string FormattedDate { get; set; }
        public string BarcodeNumber { get; set; }
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
