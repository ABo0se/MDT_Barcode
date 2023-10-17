using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class ShowItem : Form
    {
        private MySqlConnection mySqlConnection;

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
                //DisplayData
                BarcodeID_TXT.Text = data.BarcodeNumber;
                ModelName_TXT.Text = data.ModelNumber;
                Brand_TXT.Text = data.Brand;
                SN_TXT.Text = data.SerialNum;
                Price_TXT.Text = data.Price;
                Stay_TXT.Text = data.Room;
                Note_TXT.Text = data.Description;
                ////////////////////////////////////
                int statusX, conditionX;
                statusX = data.Status;
                conditionX = data.Condition;
                switch (statusX)
                {
                    case -1:
                    {
                        Status_TXT.Text = "ไม่สามารถทราบได้";
                        break;
                    }
                    case 0:
                    {
                        Status_TXT.Text = "มีให้ตรวจสอบ";
                        break;
                    }
                    case 1:
                    {
                        Status_TXT.Text = "มีให้ตรวจสอบ";
                        break;
                    }
                }
                switch (conditionX)
                {
                    case -1:
                        {
                            Condition_TXT.Text = "ไม่สามารถทราบได้";
                            break;
                        }
                    case 0:
                        {
                            Condition_TXT.Text = "ใช้งานได้";
                            break;
                        }
                    case 1:
                        {
                            Condition_TXT.Text = "ชำรุดรอซ่อม";
                            break;
                        }
                    case 2:
                        {
                            Condition_TXT.Text = "สิ้นสภาพ";
                            break;
                        }
                    case 3:
                        {
                            Condition_TXT.Text = "สูญหาย";
                            break;
                        }
                    case 4:
                        {
                            Condition_TXT.Text = "จำหน่ายแล้ว";
                            break;
                        }
                    case 5:
                        {
                            Condition_TXT.Text = "โอนแล้ว";
                            break;
                        }
                    case 6:
                        {
                            Condition_TXT.Text = "อื่นๆ";
                            break;
                        }
                }
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
                            MessageBox.Show(reader["Status"].ToString());
                            MessageBox.Show(reader["ITEM_CONDITION"].ToString());
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

    

        public void InitializePage()
        {
            BarcodeID_TXT.Text = ModelName_TXT.Text = Brand_TXT.Text = 
            SN_TXT.Text = Price_TXT.Text = Stay_TXT.Text = Note_TXT.Text = Status_TXT.Text = Condition_TXT.Text = string.Empty;
            pictureBox1.Image = Properties.Resources.NoImage;
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
