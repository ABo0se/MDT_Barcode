using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp.Borrow_Return
{
    public partial class ManageBorrowedItem : Form
    {
        List<RentResults> TemporaryData;
        DateTime? BorrowingDate = null, ReturningDate = null;
        public ManageBorrowedItem()
        {
            InitializeComponent();
            //InitializePage();
        }

        public void SearchDatainDB()
        {
            SearchDatabase(out List<RentResults> data2);
            TemporaryData = data2;
            PopulateDataGridView(TemporaryData);
        }
        private void ManageBorrowedItem_Load(object sender, EventArgs e)
        {
            InitializePage();
        }
        private bool SearchDatabase(out List<RentResults> mysearchresults)
        {
            mysearchresults = new List<RentResults>();
            string connectionString = "server=127.0.0.1; user=root; database=borrow_returning_system; password=";
            string query = "SELECT * FROM borrowing_info WHERE " +
                "(BarcodeNumber LIKE @BarcodesearchCriteria OR @BarcodesearchCriteria = 'ค้นหารหัสครุภัณฑ์' OR @BarcodesearchCriteria = '') " +
                "AND (Product_Name LIKE @Product_Name OR @Product_Name = '') " +
                "AND (Borrower_Name LIKE @Borrower_Name OR @Borrower_Name = '') " +
                "AND (Initial_Borrow_Time = COALESCE(@Initial_Borrow_Time, Initial_Borrow_Time) OR @Initial_Borrow_Time IS NULL) " +
                "AND (EST_Return_Date = COALESCE(@EST_Return_Date, EST_Return_Date) OR @EST_Return_Date IS NULL) " +
                "AND (Status = @StatussearchCriteria OR @StatussearchCriteria = -1 OR @StatussearchCriteria = -2)";
            ////////////////////////////////////////////////////
            //MessageBox.Show(BarcodeSearchBox.Text);
            //MessageBox.Show(Product_Name_SearchBox.Text);
            //MessageBox.Show((BorrowingDate.HasValue ? (object)BorrowingDate.Value.Date : DBNull.Value).ToString());
            //MessageBox.Show((ReturningDate.HasValue ? (object)ReturningDate.Value.Date : DBNull.Value).ToString());
            //MessageBox.Show((StatusBox.SelectedIndex - 1).ToString());
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Assuming you have parameters, add them here
                    command.Parameters.AddWithValue("@BarcodesearchCriteria", BarcodeSearchBox.Text);
                    command.Parameters.AddWithValue("@Product_Name", Product_Name_SearchBox.Text);
                    command.Parameters.AddWithValue("@Borrower_Name", Borrower_Name.Text);
                    command.Parameters.AddWithValue("@Initial_Borrow_Time", BorrowingDate.HasValue ? (object)BorrowingDate.Value.Date : DBNull.Value);
                    command.Parameters.AddWithValue("@EST_Return_Date", ReturningDate.HasValue ? (object)ReturningDate.Value.Date : DBNull.Value);
                    command.Parameters.AddWithValue("@StatussearchCriteria", (StatusBox.SelectedIndex - 1));

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RentResults myrentdata = new RentResults
                            {
                                Date = reader.IsDBNull(reader.GetOrdinal("Time")) ? (DateTime?)null : reader.GetDateTime("Time"),
                                InitialBorrowDate = reader.IsDBNull(reader.GetOrdinal("Initial_Borrow_Time")) ? (DateTime?)null : reader.GetDateTime("Initial_Borrow_Time"),
                                EstReturnDate = reader.IsDBNull(reader.GetOrdinal("EST_Return_Date")) ? (DateTime?)null : reader.GetDateTime("EST_Return_Date"),
                                ActualReturnDate = reader.IsDBNull(reader.GetOrdinal("ACTUAL_Return_Date")) ? (DateTime?)null : reader.GetDateTime("ACTUAL_Return_Date"),
                                BarcodeNumber = reader["BarcodeNumber"].ToString(),
                                Product_Name = reader["Product_Name"].ToString(),
                                Borrower_Name = reader["Borrower_Name"].ToString(),
                                FilePath = reader["ImageData"].ToString(),
                                SHA512 = reader["MD5_ImageValidityChecksum"].ToString(),
                                BarcodeHistoryListSerialized = reader["HistoryTextlog"].ToString(),
                                Borrower_Contact = reader["Contact"].ToString(),
                                Note = reader["Note"].ToString(),
                                Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? (int?)null : reader.GetInt16("Status")
                            };
                            mysearchresults.Add(myrentdata);
                        }
                    }
                }
            }
            if (mysearchresults.Count != 0)
            {
                return true;
            }
            else
            {
                mysearchresults = null;
                return false;
            }
        }
        private void PopulateDataGridView(List<RentResults> data)
        {
            BorrowGridView.Rows.Clear();
            if (data == null) return;
            int numberofsortedItem = 1;
            foreach (RentResults result in data)
            {
                string tempstatus = DecodingStatus(result.Status);
                string BorrowDate = result.InitialBorrowDate.Value.ToString("dd MMMM yyyy");
                string ReturnDate = result.EstReturnDate.Value.ToString("dd MMMM yyyy");
                BorrowGridView.Rows.Add(numberofsortedItem, result.BarcodeNumber, result.Product_Name, BorrowDate, 
                                        ReturnDate, result.Borrower_Name, result.Borrower_Contact, tempstatus);
                numberofsortedItem++;
            }
            FontUtility.ApplyEmbeddedFont(BorrowGridView);
        }
        public void InitializePage()
        {
            //Initial blank search value;
            ResetDateTime();
            SearchDatainDB();
        }
        private void BorrowTime_ValueChanged(object sender, EventArgs e)
        {
            BorrowTime.Format = DateTimePickerFormat.Long;
            BorrowingDate = BorrowTime.Value;
            SearchDatainDB();
        }

        private void ReturnTime_ValueChanged(object sender, EventArgs e)
        {
            ReturnTime.Format = DateTimePickerFormat.Long;
            ReturningDate = ReturnTime.Value;
            SearchDatainDB();
        }
        private void ResetDateTime()
        {
            BorrowTime.Format = DateTimePickerFormat.Custom;
            ReturnTime.Format = DateTimePickerFormat.Custom;
            BorrowTime.CustomFormat = " "; //a string with one whitespace
            ReturnTime.CustomFormat = " ";
            BorrowingDate = null;
            ReturningDate = null;
        }

        private void BorrowTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && e.KeyCode == Keys.Delete)
            {
                BorrowTime.Format = DateTimePickerFormat.Custom;
                BorrowTime.CustomFormat = " ";
                BorrowingDate = null;
            }
        }
        private string DecodingStatus(int? status)
        {
            switch (status)
            {
                case 0:
                    {
                        return "ถูกยืม";
                    }
                case 1:
                    {
                        return "เลยกำหนด";
                    }
                case 2:
                    {
                        return "พร้อมให้ยืม";
                    }
                case 3:
                    {
                        return "ไม่พบข้อมูล";
                    }
                case null:
                    {
                        return "พร้อมให้ยืม";
                    }
                default:
                    {
                        return "ไม่พบข้อมูล";
                    }
            }
        }
        private int? EncodingStatus(string stringstatus)
        {
            switch (stringstatus) 
            {
                case "ถูกยืม":
                    {
                        return 0;
                    }
                case "เลยกำหนด":
                    {
                        return 1;
                    }
                case "พร้อมให้ยืม [มีประวัติ]":
                    {
                        return 2;
                    }
                case "ไม่พบข้อมูล":
                    {
                        return 3;
                    }
                case "พร้อมให้ยืม":
                    {
                        return null;
                    }
                default:
                    {
                        return 3;
                    }
            }
        }

        private void BarcodeSearchBox_TextChanged(object sender, EventArgs e)
        {
            SearchDatainDB();
        }

        private void Borrower_Name_TextChanged(object sender, EventArgs e)
        {
            SearchDatainDB();
        }

        private void Product_Name_SearchBox_TextChanged(object sender, EventArgs e)
        {
            SearchDatainDB();
        }

        private void StatusBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchDatainDB();
        }

        private void ManageBorrowedItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
            }
        }

        private void ReturnTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && e.KeyCode == Keys.Delete)
            {
                ReturnTime.Format = DateTimePickerFormat.Custom;
                ReturnTime.CustomFormat = " ";
                ReturningDate = null;
            }
        }
    }
}
