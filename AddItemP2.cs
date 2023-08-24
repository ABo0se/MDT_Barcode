using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class AddItemP2 : Form
    {
        string PicFilePath = null;
        /// ///////////////////////////////////////////
        public AddItemP2()
        {
            InitializeComponent();
        }
        public void AssignBarcodeText(string barcodetext)
        {
            BarcodeID_TB.Text = barcodetext;
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

                string query = "INSERT INTO information (BarcodeNumber, Model_Name, Brand, Serial_Number, Price, Room, Pic, Note) " +
                               "VALUES (@BarcodeNumber, @Model_Name, @Brand, @Serial_Number, @Price, @Room, @Pic, @Note)";
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
                mySqlConnection.Close();
                AddItemP2 AddItemForm = MainMenu.initializedForms.Find(f => f is AddItemP2) as AddItemP2;
                if (AddItemForm != null)
                {
                    AddItemForm.Hide();
                }
            }
        }
        public void InitializePage()
        {
            PicFilePath = null;
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
    }
}
