using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class AddItemP2 : Form
    {
        //string PicFilePath = null;
        int checkstate = -1;
        int conditionstate = -1;
        List<System.Drawing.Image> selectedImages = new List<System.Drawing.Image>();
        int? selectingImage = null;
        /// ///////////////////////////////////////////
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
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Delete existing picture in picture box
            bool isremovingsuccessful = false;
            if (selectedImages.Count > 1)
            {
                selectedImages.Remove(pictureBox1.Image);
                isremovingsuccessful = true;
            }
            if (isremovingsuccessful)
            {
                CheckImageButtonBehavior();
                ChangePicture(selectedImages.Count - 1);
            }
            else
            {
                MessageBox.Show("Fail to remove picture");
            }
        }
        private void BarcodeID_TB_TextChanged(object sender, EventArgs e)
        {

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

                if (isDataSame)
                {
                    MessageBox.Show("ไม่สามารถเพิ่มข้อมูลลงในระบบได้ เนื่องจากมีรหัสครุภัณฑ์นี้อยู่แล้ว");
                }
                else if (BarcodeID_TB.Text == "" || Model_TB.Text == "" || Brand_TB.Text == "" ||
                         Serial_TB.Text == "" || Price_TB.Text == "" || Room_TB.Text == "" ||
                         Room_TB.Text == "" || Note_TB.Text == "" || conditionstate == -1 || checkstate == -1)
                {
                    MessageBox.Show("กรุณากรอกรายละเอียดของครุภัณฑ์ให้ครบถ้วน ก่อนทำการเพิ่มเข้ามา");
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
            /////////////////////////////////////////////////////////////////////////////////////////////////////
        }
        private void AddItemToDB()
        {
            //List<byte[]> ImageList = new List<byte[]>();
            string connectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";
            MySqlConnection mySqlConnection2 = new MySqlConnection(connectionString);

            try
            {
                //Create reference for image we used.
                string saveDirectory = @"C:\BarcodeDatabaseImage";
                Directory.CreateDirectory(saveDirectory);

                List<string> savedFilePaths = new List<string>();

                // Loop through the selectedImages list and save each image
                if (selectedImages.Count > 0)
                {
                    for (int i = 0; i < selectedImages.Count; i++)
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
                
                string jsonPicData = JsonConvert.SerializeObject(savedFilePaths, Formatting.Indented);
                Console.WriteLine(jsonPicData);
                MessageBox.Show(jsonPicData);

                //TryAddittoDATABASE
                mySqlConnection2.Open();

                string query = "INSERT INTO information (BarcodeNumber, Model_Name, Brand, Serial_Number, Price, Room, Note, ImageData, Status, ITEM_CONDITION) " +
               "VALUES (@BarcodeNumber, @Model_Name, @Brand, @Serial_Number, @Price, @Room, @Note, @ImageData, @Status, @ITEM_CONDITION)";


                using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection2))
                {
                    cmd.Parameters.AddWithValue("@BarcodeNumber", BarcodeID_TB.Text);
                    cmd.Parameters.AddWithValue("@Model_Name", Model_TB.Text);
                    cmd.Parameters.AddWithValue("@Brand", Brand_TB.Text);
                    cmd.Parameters.AddWithValue("@Serial_Number", Serial_TB.Text);
                    cmd.Parameters.AddWithValue("@Price", Price_TB.Text);
                    cmd.Parameters.AddWithValue("@Room", Room_TB.Text);
                    cmd.Parameters.AddWithValue("@ImageData", jsonPicData);
                    cmd.Parameters.AddWithValue("@Note", Note_TB.Text);
                    cmd.Parameters.AddWithValue("@Status", checkstate);
                    cmd.Parameters.AddWithValue("@ITEM_CONDITION", conditionstate);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Barcode Data inserted successfully!");
                        //PullDataFromDB();
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert data.");
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
                    MessageBox.Show("ไม่สามารถเพิ่มข้อมูลลงในระบบได้ เนื่องจากมีรหัสครุภัณฑ์นี้อยู่แล้ว");
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
                            selectedImages = new List<System.Drawing.Image>();
                        }
                        selectingImage = null;

                        Model_TB.Text = "";
                        Brand_TB.Text = "";
                        Serial_TB.Text = "";
                        Price_TB.Text = "";
                        Room_TB.Text = "";
                        Note_TB.Text = "";
                        S_Have.Checked = false;
                        S_Donthave.Checked = false;
                        ConditionBox.DataSource = null;
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
            pictureBox1.Image = Properties.Resources.NoImage;
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
            }
            else
            {
                Prevpic.Enabled = false;
                Nextpic.Enabled = false;
            }
        }
        private void ChangePicture(int? pictureindex)
        {
            selectingImage = pictureindex;
            if (selectingImage != null)
            {
                pictureBox1.Image = selectedImages[(int)selectingImage];
            }
            else
            {
                pictureBox1.Image = null;
            }
        }
        //private byte[] ImageToByteArray(System.Drawing.Image image)
        //{
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg); // Change the format as needed
        //        return stream.ToArray();
        //    }
        //}
    }
}
