using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class ShowItem : Form
    {
        private MySqlConnection mySqlConnection;

        private class SRResults
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

        public ShowItem()
        {
            InitializeComponent();
            mySqlConnection = new MySqlConnection("server=127.0.0.1; user=root; database=barcodedatacollector; password=");
        }

        private void ShowItem_Load(object sender, EventArgs e)
        {
            InitializePage();
        }

        private void ShowForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public void ShowItemDetail(string barcodeText)
        {
            AssignBarcodeText(barcodeText);
        }

        public void AssignBarcodeText(string barcodeText)
        {
            if (TryFetchDataBySerialCode(barcodeText, out SRResults data))
            {
                DisplayData(data);
            }
        }

        private bool TryFetchDataBySerialCode(string serialCode, out SRResults data)
        {
            data = null;

            try
            {
                mySqlConnection.Open();
                string selectQuery = "SELECT * FROM information WHERE BarcodeNumber = @BarcodeNumber";

                using (MySqlCommand command = new MySqlCommand(selectQuery, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@BarcodeNumber", serialCode);

                    using (MySqlDataReader reader = command.ExecuteReader())
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
                            };
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                // MessageBox.Show(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
            return false;
        }

        private void DisplayData(SRResults data)
        {
            BarcodeID_TXT.Text = data.BarcodeNumber;
            ModelName_TXT.Text = data.ModelNumber;
            Brand_TXT.Text = data.Brand;
            SN_TXT.Text = data.SerialNum;
            Price_TXT.Text = data.Price;
            Stay_TXT.Text = data.Room;
            Note_TXT.Text = data.Description;

            // Dispose of previous image (if any)
            //pictureBox1.Image?.Dispose();

            // Load and display the new image
            if (data.FilePath != null)
            {
                pictureBox1.Image = Image.FromFile(data.FilePath);
                MessageBox.Show("FileShowed");
            }
            else
            {
                pictureBox1.Image = Properties.Resources.NoImage;
                MessageBox.Show("NoFileShowed");
            }
            pictureBox1.Refresh();
        }

        public void InitializePage()
        {
            BarcodeID_TXT.Text = ModelName_TXT.Text = Brand_TXT.Text = SN_TXT.Text = Price_TXT.Text = Stay_TXT.Text = Note_TXT.Text = string.Empty;

            // Dispose of previous image (if any)
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = null;
        }

        // Other event handler methods...

        private void BarcodeID_TXT_Click(object sender, EventArgs e)
        {
            // You can add logic here if needed
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
