using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using USB_Barcode_Scanner;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class ManageQR : Form
    {
        private BarcodeScanner _barcodeScanner;

        public ManageQR()
        {
            InitializeComponent();
            InitializeDataGridView();
            _barcodeScanner = new BarcodeScanner(BarcodeSearchBox);
            _barcodeScanner.BarcodeScanned += BarcodeScanner_BarcodeScanned2;
        }

        private void BarcodeScanner_BarcodeScanned2(object sender, BarcodeScannerEventArgs e)
        {
            BarcodeSearchBox.Text = e.Barcode;
        }

        private void InitializeApplication()
        {
            SearchDatainDB();
        }

        private void InitializeDataGridView()
        {
            BarcodenumberCollector.CellPainting += BarcodenumberCollector_CellPainting;
            BarcodenumberCollector.CellContentClick += BarcodenumberCollector_CellContentClick;
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
            List<SRResults2> ResultDataList = new List<SRResults2>();

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
                                SRResults2 data2 = new SRResults2
                                {
                                    Date = reader.GetDateTime("Time"),
                                    BarcodeNumber = reader["BarcodeNumber"].ToString(),
                                    ModelNumber = reader["Model_Name"].ToString(),
                                    Brand = reader["Brand"].ToString(),
                                    SerialNum = reader["Serial_Number"].ToString(),
                                    Price = reader["Price"].ToString(),
                                    Room = reader["Room"].ToString(),
                                    Description = reader["Note"].ToString(),
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

        private void PopulateDataGridView(List<SRResults2> data)
        {
            BarcodenumberCollector.Rows.Clear();

            int numberofsortedItem = 0;
            foreach (SRResults2 result in data)
            {
                BarcodenumberCollector.Rows.Add
                (numberofsortedItem, result.Date, result.BarcodeNumber, result.ModelNumber,
                 result.Brand, result.SerialNum, result.Price, result.Room,
                 result.Description);
                numberofsortedItem++;
            }
        }

        private void BarcodenumberCollector_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 9)
            {
                int buttonWidth = BarcodenumberCollector.Columns[e.ColumnIndex].Width / 3;
                int relativeX = MousePosition.X - BarcodenumberCollector.PointToScreen
                    (BarcodenumberCollector.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location).X;

                int clickedButtonIndex = relativeX / buttonWidth;

                switch (clickedButtonIndex)
                {
                    case 0:
                        if (BarcodenumberCollector.Rows[e.RowIndex].Cells[2].Value != null)
                        {
                            string barcodevalue = BarcodenumberCollector.Rows[e.RowIndex].Cells[2].Value.ToString();
                            EditBarcode(barcodevalue);
                        }
                        break;
                    case 1:
                        if (BarcodenumberCollector.Rows[e.RowIndex].Cells[2].Value != null)
                        {
                            string barcodevalue = BarcodenumberCollector.Rows[e.RowIndex].Cells[2].Value.ToString();
                            EditBarcode(barcodevalue);
                        }
                        break;
                    case 2:
                        if (BarcodenumberCollector.Rows[e.RowIndex].Cells[2].Value != null)
                        {
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
                            ///////////
                        }
                        break;
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
            if (e.RowIndex >= 0 && e.ColumnIndex == 9)
            {
                e.Handled = true;

                Bitmap buffer = new Bitmap(e.CellBounds.Width, e.CellBounds.Height);
                Graphics g = Graphics.FromImage(buffer);

                int buttonWidth = e.CellBounds.Width / 3;
                int buttonHeight = e.CellBounds.Height;

                for (int i = 0; i < 3; i++)
                {
                    Rectangle buttonRect = new Rectangle(i * buttonWidth, 0, buttonWidth, buttonHeight);
                    Image buttonImage = null;

                    if (i == 0) buttonImage = Properties.Resources.search;
                    else if (i == 1) buttonImage = Properties.Resources.EditIcon;
                    else if (i == 2) buttonImage = Properties.Resources.DeleteIcon;

                    if (buttonImage != null)
                    {
                        g.DrawImage(buttonImage, buttonRect);
                        ControlPaint.DrawButton(g, buttonRect, ButtonState.Flat);
                    }
                }

                g.Dispose();
                e.Graphics.DrawImage(buffer, e.CellBounds.Location);
                buffer.Dispose();
            }
        }

        public class SRResults2
        {
            public DateTime Date { get; set; }
            public string BarcodeNumber { get; set; }
            public string ModelNumber { get; set; }
            public string Brand { get; set; }
            public string SerialNum { get; set; }
            public string Price { get; set; }
            public string Room { get; set; }
            public string Description { get; set; }
        }

        private void ManageQR_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
            }
        }
    }
}
