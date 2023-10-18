using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class EditItem : Form
    {
        string PicFilePath = null;
        int checkstate = -1;
        int conditionstate = -1;
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
                ////////////////////////////////////
                try
                {
                    if (data.FilePath != null || data.FilePath != "")
                    {
                        pictureBox1.Image = Image.FromFile(data.FilePath);
                    }
                    else
                    {
                        pictureBox1.Image = Properties.Resources.NoImage;
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    pictureBox1.Refresh();
                }
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
            openFileDialog.Filter = "All Files (*.*)|*.*"; // Set the file filter if needed
            openFileDialog.Title = "Select a File to Upload";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                // Handle the selected file path (e.g., upload it or process it)
                // You can call a method to process the file with the selectedFilePath
                // Load the selected image into the PictureBox
                Image selectedImage = Image.FromFile(selectedFilePath);

                pictureBox1.Image = selectedImage;
                PicFilePath = selectedFilePath;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
                if (isDataSame)
                {
                    EditmyDataBase();
                }
                else
                {
                    MessageBox.Show("ไม่สามารถเพิ่มข้อมูลลงในระบบได้ เนื่องจากไม่สามารถดึงรหัสครุภัณฑ์เก่าได้");
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EditmyDataBase()
        {
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
               "Pic = @Pic, " +
               "Note = @Note, " + // Add a comma here
               "Status = @Status, " + // Add a comma here
               "ITEM_CONDITION = @ITEM_CONDITION " + // Add a space here

               "WHERE BarcodeNumber = @BarcodeNumberReplacement";


                if (PicFilePath == null)
                {
                    PicFilePath = "";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection2))
                {
                    cmd.Parameters.AddWithValue("@Model_Name", Model_TB.Text);
                    cmd.Parameters.AddWithValue("@Brand", Brand_TB.Text);
                    cmd.Parameters.AddWithValue("@Serial_Number", Serial_TB.Text);
                    cmd.Parameters.AddWithValue("@Price", Price_TB.Text);
                    cmd.Parameters.AddWithValue("@Room", Room_TB.Text);
                    cmd.Parameters.AddWithValue("@Pic", PicFilePath);
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
            PicFilePath = "";
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

            S_HaveEdit.Checked = false;
            S_DonthaveEdit.Checked = false;
            ConditionBoxEdit.SelectedIndex = conditionstate;

            TemporaryData = null;
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
                                FilePath = reader["Pic"].ToString(),
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
    }
    public class SRResults
    {
        public DateTime Date { get; set; }
        public string BarcodeNumber { get; set; }
        public string ModelNumber { get; set; }
        public string Brand { get; set; }
        public string SerialNum { get; set; }
        public string Price { get; set; }
        public string Room { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Condition { get; set; }
    }
}
