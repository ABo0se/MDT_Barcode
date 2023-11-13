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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp.Borrow_Return
{
    public partial class Borrow_BarcodeIDChecker : Form
    {
        string defaultText = "[สแกน หรือ กรอกหมายเลขครุภัณฑ์]";
        RentResults temporarydata = null;
        public Borrow_BarcodeIDChecker()
        {
            InitializeComponent();
        }

        private void Borrow_BarcodeIDChecker_Load(object sender, EventArgs e)
        {
            InitializePage();
        }
        private void InitializePage()
        {
            ResetButtonState();
            ResetTextState();
        }
        private void ResetButtonState()
        {
            ChangeButtonState(false, false, false);
        }
        private void ResetTextState()
        {
            BarcodeText.Text = defaultText;
            BarcodeText.ForeColor = Color.Gray;
        }
        private void BeginNewTextState()
        {
            BarcodeText.Text = "";
            BarcodeText.ForeColor = Color.Black;
        }

        private void BarcodeText_Enter(object sender, EventArgs e)
        {
            if (BarcodeText.Text == defaultText)
            {
                BeginNewTextState();
            }
        }
        private void BarcodeText_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(BarcodeText.Text))
            {
                ResetButtonState();
                ResetTextState();
            }
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(BarcodeText.Text);
            FindBarcodeInItemDatabase(BarcodeText.Text, out RentResults data);
            temporarydata = data;
            if (temporarydata == null)
            {

                MessageBox.Show("ไม่พบครุภัณฑ์ที่บันทึกไว้ในฐานข้อมูลครุภัณฑ์");
                ResetButtonState();
                ResetTextState();
            }
            else
            {
                Status_TXT.Text = DecodingStatus(data.Status);
                if (temporarydata.Status == null)
                {
                    ChangeButtonState(false, false, true);
                }
                if (temporarydata.Status == 0 || temporarydata.Status == 1 || temporarydata.Status == 2)
                {
                    ChangeButtonState(true, true, true);
                }
            }
        }
        private RentResults FindBarcodeInItemDatabase(string serialCode, out RentResults data)
        {
            data = new RentResults();
            MySqlConnection mySqlConnection = new MySqlConnection("server=127.0.0.1; user=root; database=barcodedatacollector; password=");
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
                            data.Product_Name = reader["Product_Name"].ToString();
                            data.BarcodeNumber = reader["BarcodeNumber"].ToString();
                            data.FilePath = reader["ImageData"].ToString();
                            data.SHA512 = reader["MD5_ImageValidityChecksum"].ToString();
                        }
                    }
                }
                if (data == null)
                {
                    return null;
                }
                else
                {
                    FindBarcodeInBorrowNReturn(data, out RentResults data2);
                    data = data2;
                    return data;
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
            return null;
        }
        private RentResults FindBarcodeInBorrowNReturn(RentResults data2, out RentResults data)
        {
            data = data2;
            MySqlConnection mySqlConnection = new MySqlConnection("server=127.0.0.1; user=root; database=borrow_returning_system; password=");
            try
            {
                mySqlConnection.Open();
                string selectQuery = "SELECT * FROM borrowing_info WHERE BarcodeNumber = @BarcodeNumber";

                using (MySqlCommand command = new MySqlCommand(selectQuery, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@BarcodeNumber", data.BarcodeNumber);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data.InitialBorrowDate = reader.GetDateTime("Initial_Borrow_Date");
                            data.EstReturnDate = reader.GetDateTime("EST_Return_Date");
                            data.ActualReturnDate = reader.GetDateTime("ACTUAL_Return_Date");
                            //data.Product_Name = reader["Product_Name"].ToString();
                            data.Borrower_Name = reader["Borrower_Name"].ToString();
                            //data.BarcodeNumber = reader["BarcodeNumber"].ToString();
                            //data.FilePath = reader["ImageData"].ToString();
                            //data.SHA512 = reader["MD5_ImageValidityChecksum"].ToString();
                            data.Borrower_Contact = reader["Contact"].ToString();
                            data.Note = reader["Note"].ToString();
                            data.Status = int.Parse(reader["Status"].ToString());
                            return data;
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
            ///////////////////////////////////////////
            //Don't found data in new DB, fallback to assign one by one.
            return data;
        }

        /////////////////////////////////////////////////////////////////////
        private void ChangeButtonState(bool a, bool b, bool c)
        {
            ShowDetail_B.Enabled = a;
            AdjustDetail_B.Enabled = b;
            Borrow_Return_Management_B.Enabled = c;
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
                        return "คืนเรียบร้อย (พร้อมให้ยืม)";
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

        private void Borrow_BarcodeIDChecker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
            }
        }

        private void Borrow_Return_Management_B_Click(object sender, EventArgs e)
        {
            if (temporarydata == null) return;
            AddBorrowItem AddBForm = MainMenu.initializedForms.Find(f => f is AddBorrowItem) as AddBorrowItem;
            if (AddBForm != null)
            {
                AddBForm.Show();
                AddBForm.InitializePage();
                AddBForm.AssignBarcodeText(temporarydata);
            }
        }
    }

    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public class RentResults
    {
        public DateTime InitialBorrowDate { get; set; }
        public DateTime EstReturnDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public string BarcodeNumber { get; set; }
        public List<RentHistory> BarcodeHistoryList { get; set; }
        public string BarcodeHistoryListSerialized { get; set; }
        public string Product_Name { get; set; }
        public string Borrower_Name { get; set; }
        public string FilePath { get; set; }
        public string SHA512 { get; set; }
        public string Borrower_Contact { get; set; }
        public string Note { get; set; }
        public int? Status { get; set; }
    }
    public class RentHistory
    {
        public string Borrower_Name { get; set; }
        public DateTime InitialBorrowDate { get; set; }
        public DateTime EstReturnDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public string Borrower_Contact { get; set; }
        public string Note { get; set; }
    }
}