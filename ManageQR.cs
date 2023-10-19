using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using USB_Barcode_Scanner;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class ManageQR : Form
    {
        private BarcodeScanner2 _barcodeScanner;

        public ManageQR()
        {
            InitializeComponent();
            //InitializeDataGridView();
            _barcodeScanner = new BarcodeScanner2(BarcodeSearchBox);
            /////////////////////////////////////////////////////////////////
            _barcodeScanner.BarcodeScanned += BarcodeScanner_BarcodeScanned2;
        }

        private void BarcodeScanner_BarcodeScanned2(object sender, BarcodeScannerEventArgs e)
        {
            if (sender == BarcodeSearchBox)
            {
                BarcodeSearchBox.Text = e.Barcode;
            }
        }

        private void InitializeApplication()
        {
            SearchDatainDB();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeApplication();
        }

        private void BarcodeSearchBox_TextChanged(object sender, EventArgs e)
        {
            SearchDatainDB();
        }

        public void SearchDatainDB()
        {
            List<SRResults> ResultDataList = new List<SRResults>();

            string connectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";

            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    mySqlConnection.Open();

                    string query = "SELECT * FROM information WHERE BarcodeNumber LIKE @searchCriteria " +
                                    "OR Model_Name LIKE @searchCriteria " +
                                    "OR Serial_Number LIKE @searchCriteria";

                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@searchCriteria", BarcodeSearchBox.Text + "%");

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SRResults data2 = new SRResults
                                {
                                    Date = reader.GetDateTime("Time"),
                                    BarcodeNumber = reader["BarcodeNumber"].ToString(),
                                    ModelNumber = reader["Model_Name"].ToString(),
                                    Brand = reader["Brand"].ToString(),
                                    SerialNum = reader["Serial_Number"].ToString(),
                                    Price = reader["Price"].ToString(),
                                    Room = reader["Room"].ToString(),
                                    Description = reader["Note"].ToString(),
                                    Status = int.Parse(reader["Status"].ToString()),
                                    Condition = int.Parse(reader["ITEM_CONDITION"].ToString())
                                };
                                ResultDataList.Add(data2);
                            }
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
                }
            }

            PopulateDataGridView(ResultDataList);
        }

        private void PopulateDataGridView(List<SRResults> data)
        {
            BarcodenumberCollector.Rows.Clear();

            int numberofsortedItem = 0;
            string tempstatus = "";
            string tempcondition = "";
            foreach (SRResults result in data)
            {
                
                /////////////
                switch (result.Status)
                {
                    case -1:
                        {
                            tempstatus = "ไม่สามารถทราบได้";
                            break;
                        }
                    case 0:
                        {
                            tempstatus = "มีให้ตรวจสอบ";
                            break;
                        }
                    case 1:
                        {
                            tempstatus = "มีให้ตรวจสอบ";
                            break;
                        }
                }
                switch (result.Condition)
                {
                    case -1:
                        {
                            tempcondition = "ไม่สามารถทราบได้";
                            break;
                        }
                    case 0:
                        {
                            tempcondition = "ใช้งานได้";
                            break;
                        }
                    case 1:
                        {
                            tempcondition = "ชำรุดรอซ่อม";
                            break;
                        }
                    case 2:
                        {
                            tempcondition = "สิ้นสภาพ";
                            break;
                        }
                    case 3:
                        {
                            tempcondition = "สูญหาย";
                            break;
                        }
                    case 4:
                        {
                            tempcondition = "จำหน่ายแล้ว";
                            break;
                        }
                    case 5:
                        {
                            tempcondition = "โอนแล้ว";
                            break;
                        }
                    case 6:
                        {
                            tempcondition = "อื่นๆ";
                            break;
                        }
                }
                /////////////
                BarcodenumberCollector.Rows.Add
                (numberofsortedItem, result.Date, result.BarcodeNumber, result.ModelNumber,
                 result.Brand, result.SerialNum, result.Price, result.Room,
                 result.Description, tempstatus, tempcondition);
                numberofsortedItem++;
            }
            FontUtility.ApplyEmbeddedFont(BarcodenumberCollector);
        }

        private void BarcodenumberCollector_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11 && e.RowIndex >= 0)
            {
                // Your custom logic when the button is clicked
                string barcodevalue = BarcodenumberCollector.Rows[e.RowIndex].Cells[2].Value.ToString();
                SearchBarcode(barcodevalue);
            }
            if (e.ColumnIndex == 12 && e.RowIndex >= 0)
            {
                // Your custom logic when the button is clicked
                string barcodevalue = BarcodenumberCollector.Rows[e.RowIndex].Cells[2].Value.ToString();
                EditBarcode(barcodevalue);
            }
            if (e.ColumnIndex == 13 && e.RowIndex >= 0)
            {
                //Your custom logic when the button is clicked
                //Confirmation Box
                DialogResult result = MessageBox.Show
                ("Are you sure to delete this product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check the user's response
                if (result == DialogResult.Yes)
                {
                    // User clicked "Yes," perform the action
                    string barcodevalue = BarcodenumberCollector.Rows[e.RowIndex].Cells[2].Value.ToString();
                    DeleteBarcode(barcodevalue);
                }
                else
                {
                    // User clicked "No" or closed the dialog, do nothing or handle as needed
                }
            }
        }

        private void SearchBarcode(string barcode)
        {
            List<string> dbData = new List<string>();
            string dbConnectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";

            using (MySqlConnection mySqlConnection = new MySqlConnection(dbConnectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    string selectQuery = "SELECT BarcodeNumber FROM information";

                    MySqlCommand command = new MySqlCommand(selectQuery, mySqlConnection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string rowData = reader["BarcodeNumber"].ToString();
                        dbData.Add(rowData);
                    }

                    bool isDataSame = dbData.Contains(barcode);

                    if (isDataSame)
                    {
                        ShowmyBarcodeItem(barcode);
                    }
                    else
                    {
                        MessageBox.Show("ไม่ค้นพบครุภัณฑ์ที่บันทึกไว้ในฐานข้อมูล");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
        }

        private void ShowmyBarcodeItem(string barcode)
        {
            ShowItem ShowItemForm = MainMenu.initializedForms.Find(f => f is ShowItem) as ShowItem;
            if (ShowItemForm != null)
            {
                ShowItemForm.Show();
                ShowItemForm.InitializePage();
                ShowItemForm.AssignBarcodeText(barcode);
            }
        }

        private void EditmyBarcodeItem(string barcode)
        {
            EditItem EditForm = MainMenu.initializedForms.Find(f => f is EditItem) as EditItem;
            if (EditForm != null)
            {
                EditForm.Show();
                EditForm.InitializePage();
                EditForm.AssignBarcodeText(barcode);
            }
        }

        private void EditBarcode(string barcode)
        {
            List<string> dbData = new List<string>();
            string dbConnectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";

            using (MySqlConnection mySqlConnection = new MySqlConnection(dbConnectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    string selectQuery = "SELECT BarcodeNumber FROM information";

                    MySqlCommand command = new MySqlCommand(selectQuery, mySqlConnection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string rowData = reader["BarcodeNumber"].ToString();
                        dbData.Add(rowData);
                    }

                    bool isDataSame = dbData.Contains(barcode);

                    if (isDataSame)
                    {
                        EditmyBarcodeItem(barcode);
                    }
                    else
                    {
                        MessageBox.Show("ไม่ค้นพบครุภัณฑ์ที่บันทึกไว้ในฐานข้อมูล");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeleteBarcode(string barcode)
        {
            if (barcode == null && barcode == "")
            {
                return;
            }
            string dbConnectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";

            using (MySqlConnection mySqlConnection = new MySqlConnection(dbConnectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    string selectQuery = "DELETE FROM information WHERE BarcodeNumber = @BarcodeNumber";

                    MySqlCommand command = new MySqlCommand(selectQuery, mySqlConnection);
                    command.Parameters.AddWithValue("@BarcodeNumber", barcode);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        //MessageBox.Show("Data deleted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("No rows were deleted. Verify the condition.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
            //BarcodenumberCollector.Rows.RemoveAt(rowindex);
            //BarcodenumberCollector.Rows.Clear();
            SearchDatainDB();
        }

        private void BarcodenumberCollector_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }


        //public class SRResults2
        //{

        //    public string BarcodeNumber { get; set; }
        //    public string ModelNumber { get; set; }
        //    public string Brand { get; set; }
        //    public string SerialNum { get; set; }
        //    public string Price { get; set; }
        //    public string Room { get; set; }
        //    public string Description { get; set; }


        private void ManageQR_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
            }
        }

        private void BarcodenumberCollector_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 11 && e.RowIndex >= 0)
            {
                e.Value = Properties.Resources.search;
                e.FormattingApplied = true; // Add this line
            }
            if (e.ColumnIndex == 12 && e.RowIndex >= 0)
            {
                e.Value = Properties.Resources.EditIcon;
                e.FormattingApplied = true; // Add this line
            }
            if (e.ColumnIndex == 13 && e.RowIndex >= 0)
            {
                e.Value = Properties.Resources.DeleteIcon;
                e.FormattingApplied = true; // Add this line
            }
        }
    }
}