using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class ShowItem : Form
    {
        public ShowItem()
        {
            InitializeComponent();
        }
        public void AssignBarcodeText(string barcodetext)
        {
            if (TryFetchDataBySerialCode(barcodetext, out SRResults data))
            {
                //DisplayData
                BarcodeID_TXT.Text = data.BarcodeNumber;
                ModelName_TXT.Text = data.ModelNumber;
                Brand_TXT.Text = data.Brand;
                SN_TXT.Text = data.SerialNum;
                Price_TXT.Text = data.Price;
                Stay_TXT.Text = data.Room;
                Note_TXT.Text = data.Description;
                Image selectedImage = Image.FromFile(data.FilePath);

                pictureBox1.Image = selectedImage;
                pictureBox1.Refresh();
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
                MessageBox.Show(e.Message);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Created_Time_Click(object sender, EventArgs e)
        {

        }

        private void Room_Click(object sender, EventArgs e)
        {

        }
        public void InitializePage()
        {
            BarcodeID_TXT.Text = string.Empty;
            ModelName_TXT.Text = string.Empty;
            Brand_TXT.Text = string.Empty;
            SN_TXT.Text = string.Empty;
            Price_TXT.Text = string.Empty;
            Stay_TXT.Text = string.Empty;
            Note_TXT.Text = string.Empty;
            pictureBox1.Image = null;
        }

        public void ShowItemDetail(string Barcodetext)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void ShowItem_Load(object sender, EventArgs e)
        {
            InitializePage();
        }

        private void ShowForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
            }
        }

        private void BarcodeID_TXT_Click(object sender, EventArgs e)
        {

        }
    }
}
