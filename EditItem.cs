using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class EditItem : Form
    {
        string PicFilePath = null;
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
                BarcodeID_TB.Text = data.BarcodeNumber;
                Model_TB.Text = data.ModelNumber;
                Brand_TB.Text = data.Brand;
                Serial_TB.Text = data.SerialNum;
                Price_TB.Text = data.Price;
                Room_TB.Text = data.Room;
                Note_TB.Text = data.Description;
                Image selectedImage = Image.FromFile(data.FilePath);

                if (data.FilePath != null || data.FilePath != "")
                {
                    pictureBox1.Image = selectedImage;
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.NoImage;
                }
                pictureBox1.Refresh();
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
            string connectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            try
            {
                mySqlConnection.Open();

                string query = "UPDATE information " +
               "SET Model_Name = @Model_Name, " +
                   "Brand = @Brand, " +
                   "Serial_Number = @Serial_Number, " +
                   "Price = @Price, " +
                   "Room = @Room, " +
                   "Pic = @Pic, " +
                   "Note = @Note " +
               "WHERE BarcodeNumber = @BarcodeNumber";
                using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                {
                    cmd.Parameters.AddWithValue("@BarcodeNumber", BarcodeID_TB.Text);
                    cmd.Parameters.AddWithValue("@Model_Name", Model_TB.Text);
                    cmd.Parameters.AddWithValue("@Brand", Brand_TB.Text);
                    cmd.Parameters.AddWithValue("@Serial_Number", Serial_TB.Text);
                    cmd.Parameters.AddWithValue("@Price", Price_TB.Text);
                    cmd.Parameters.AddWithValue("@Room", Room_TB.Text);
                    cmd.Parameters.AddWithValue("@Pic", PicFilePath);
                    cmd.Parameters.AddWithValue("@Note", Note_TB.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Barcode Data edited successfully!");
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
                mySqlConnection.Close();
                EditItem EditItemForm = MainMenu.initializedForms.Find(f => f is EditItem) as EditItem;
                ManageQR ManageQRForm = MainMenu.initializedForms.Find(f => f is ManageQR) as ManageQR;
                if (EditItemForm != null && ManageQRForm != null)
                {
                    EditItemForm.Hide();
                    ManageQRForm.SearchDatainDB();
                }
            }
        }
        public void InitializePage()
        {
            PicFilePath = null;
            pictureBox1.Image = Properties.Resources.NoImage;
            BarcodeID_TB.Text = "";
            Model_TB.Text = "";
            Brand_TB.Text = "";
            Serial_TB.Text = "";
            Price_TB.Text = "";
            Room_TB.Text = "";
            Note_TB.Text = "";
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
                                BarcodeNumber = reader["BarcodeNumber"].ToString(),
                                ModelNumber = reader["Model_Name"].ToString(),
                                Brand = reader["Brand"].ToString(),
                                SerialNum = reader["Serial_Number"].ToString(),
                                Price = reader["Price"].ToString(),
                                Room = reader["Room"].ToString(),
                                FilePath = reader["Pic"].ToString(),
                                Description = reader["Note"].ToString(),
                                // ... and so on for other properties
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
    }
    public class SRResults
    {
        public string BarcodeNumber { get; set; }
        public string ModelNumber { get; set; }
        public string Brand { get; set; }
        public string SerialNum { get; set; }
        public string Price { get; set; }
        public string Room { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
    }
}
