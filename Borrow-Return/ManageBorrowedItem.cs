using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using OfficeOpenXml.Drawing.Chart.ChartEx;

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
        private bool FindBarcodeInItemDatabase(string serialCode, out string data)
        {
            data = null;
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
                            if (data == null) 
                                data = reader["BarcodeNumber"].ToString();
                        }
                    }
                }

                // If data is still null, no matching record was found
                if (data == null)
                {
                    return false;
                }

                // Data found
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                mySqlConnection.Close();
            }

            // Return false if an exception occurred
            return false;
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
            try
            {
                string connectionString = "server=127.0.0.1; user=root; database=borrow_returning_system; password=";
                string query = "SELECT * FROM borrowing_info WHERE " +
    "(BarcodeNumber LIKE @BarcodesearchCriteria OR @BarcodesearchCriteria = 'ค้นหารหัสครุภัณฑ์' OR @BarcodesearchCriteria = '') " +
    "AND (Product_Name LIKE @Product_Name OR @Product_Name = '') " +
    "AND (Borrower_Name LIKE @Borrower_Name OR @Borrower_Name = '') " +
    "AND (DATE(Initial_Borrow_Time) = COALESCE(DATE(@Initial_Borrow_Time), DATE(Initial_Borrow_Time)) OR @Initial_Borrow_Time IS NULL) " +
    "AND (DATE(EST_Return_Date) = COALESCE(DATE(@EST_Return_Date), DATE(EST_Return_Date)) OR @EST_Return_Date IS NULL) " +
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
                        command.Parameters.AddWithValue("@BarcodesearchCriteria", "%" + BarcodeSearchBox.Text + "%");
                        command.Parameters.AddWithValue("@Product_Name", "%" + Product_Name_SearchBox.Text + "%");
                        command.Parameters.AddWithValue("@Borrower_Name", "%" + Borrower_Name.Text + "%");
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
                                    BarcodeNumber = !string.IsNullOrEmpty(reader["BarcodeNumber"]?.ToString()) ? reader["BarcodeNumber"].ToString() : "-",
                                    Product_Name = !string.IsNullOrEmpty(reader["Product_Name"]?.ToString()) ? reader["Product_Name"].ToString() : "-",
                                    Borrower_Name = !string.IsNullOrEmpty(reader["Borrower_Name"]?.ToString()) ? reader["Borrower_Name"].ToString() : "-",
                                    FilePath = !string.IsNullOrEmpty(reader["ImageData"]?.ToString()) ? reader["ImageData"].ToString() : "[]",
                                    SHA512 = !string.IsNullOrEmpty(reader["MD5_ImageValidityChecksum"]?.ToString()) ? reader["MD5_ImageValidityChecksum"].ToString() : "[]",
                                    BarcodeHistoryListSerialized = !string.IsNullOrEmpty(reader["HistoryTextlog"]?.ToString()) ? reader["HistoryTextlog"].ToString() : "[]",
                                    Borrower_Contact = !string.IsNullOrEmpty(reader["Contact"]?.ToString()) ? reader["Contact"].ToString() : "-",
                                    Note = !string.IsNullOrEmpty(reader["Note"]?.ToString()) ? reader["Note"].ToString() : "-",
                                    Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? 3 : reader.GetInt16("Status")
                                };
                                mysearchresults.Add(myrentdata);
                            }
                        }
                    }
                    connection.Close();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                
            }
            return false;
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
            this.ActiveControl = null;
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
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                BorrowTime.Format = DateTimePickerFormat.Custom;
                BorrowTime.CustomFormat = " ";
                BorrowingDate = null;
                SearchDatainDB();
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

        private void BorrowGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex >= 0)
            {
                // Your custom logic when the button is clicked
                // Search
                ShowBorrowDetail Search = MainMenu.initializedForms.Find(f => f is ShowBorrowDetail) as ShowBorrowDetail;
                if (Search != null && TemporaryData[e.RowIndex] != null)
                {
                    FindBarcodeInItemDatabase(TemporaryData[e.RowIndex].BarcodeNumber, out string data);
                    if (data != null)
                    {
                        Search.Show();
                        Search.AssignBarcodeText(TemporaryData[e.RowIndex]);
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบรายละเอียดของครุภัณฑ์ในฐานข้อมูล");
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบหน้าต่างที่แสดงผลรายละเอียดการยืม หรือ ไม่มีรายละเอียดของครุภัณฑ์");
                }
            }
            //if (e.ColumnIndex == 9 && e.RowIndex >= 0)
            //{
            //    // Your custom logic when the button is clicked
            //    // Edit
            //    EditBorrowedItems Edit = MainMenu.initializedForms.Find(f => f is EditBorrowedItems) as EditBorrowedItems;
            //    if (Edit != null && TemporaryData[e.RowIndex] != null)
            //    {
            //        //if (TemporaryData[e.RowIndex].Status == 2)
            //        //{
            //        //    MessageBox.Show("ไม่สามารถปรับเปลี่ยนรายละเอียดครุภัณฑ์ที่คืนแล้วได้");
            //        //    return;
            //        //}
            //        Edit.Show();
            //        Edit.AssignBarcodeText(TemporaryData[e.RowIndex]);
            //    }
            //}
            if (e.ColumnIndex == 9 && e.RowIndex >= 0)
            {
                //Your custom logic when the button is clicked
                Return_Item Return = MainMenu.initializedForms.Find(f => f is Return_Item) as Return_Item;
                if (Return != null && TemporaryData[e.RowIndex] != null)
                {
                    FindBarcodeInItemDatabase(TemporaryData[e.RowIndex].BarcodeNumber, out string data);
                    if (data != null)
                    {
                        if (TemporaryData[e.RowIndex].Status == 2)
                        {
                            //MessageBox.Show("ไม่สามารถคืนครุภัณฑ์ที่ไม่ถูกยืมได้");
                            return;
                        }
                        Return.Show();
                        Return.AssignBarcodeText(TemporaryData[e.RowIndex]);
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบรายละเอียดของครุภัณฑ์ในฐานข้อมูล");
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบหน้าต่างที่แสดงผลรายละเอียดการยืม หรือ ไม่มีรายละเอียดของครุภัณฑ์");
                }
            }
            if (e.ColumnIndex == 10 && e.RowIndex >= 0)
            {
                //Delete
                DialogResult result = MessageBox.Show
                ("ต้องการจะลบข้อมูลการยืม/คืนของครุภัณฑ์นี้หรือไม่??", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check the user's response
                if (result == DialogResult.Yes)
                {
                    if (TemporaryData[e.RowIndex] != null)
                    {
                        DeleteBarcode(TemporaryData[e.RowIndex].BarcodeNumber);
                    }
                    else
                    {
                        MessageBox.Show("ไม่มีข้อมูลที่ถูกลบ โปรดตรวจสอบข้อมูลอีกครั้ง");
                    }
                }
                else
                {
                    // User clicked "No" or closed the dialog, do nothing or handle as needed
                }
            }
        }
        private void DeleteBarcode(string barcode)
        {
            if (barcode == null && barcode == "")
            {
                return;
            }
            string dbConnectionString = "server=127.0.0.1; user=root; database=borrow_returning_system; password=";

            using (MySqlConnection mySqlConnection = new MySqlConnection(dbConnectionString))
            {
                try
                {
                    mySqlConnection.Open();
                    string selectQuery = "DELETE FROM borrowing_info WHERE BarcodeNumber = @BarcodeNumber";

                    MySqlCommand command = new MySqlCommand(selectQuery, mySqlConnection);
                    command.Parameters.AddWithValue("@BarcodeNumber", barcode);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("การลบข้อมูลสำเร็จ.");
                        //MessageBox.Show("Data deleted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("ไม่มีข้อมูลที่ถูกลบ โปรดตรวจสอบข้อมูลอีกครั้ง.");
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

        private void BorrowGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex >= 0)
            {
                e.Value = Properties.Resources.search;
                //e.FormattingApplied = true; // Add this line
            }
            //if (e.ColumnIndex == 9 && e.RowIndex >= 0)
            //{
            //    e.Value = Properties.Resources.EditIcon;
            //    //e.FormattingApplied = true; // Add this line
            //}
            if (e.ColumnIndex == 9 && e.RowIndex >= 0)
            {
                e.Value = Properties.Resources.Return_Product;
                //e.FormattingApplied = true; // Add this line
            }
            if (e.ColumnIndex == 10 && e.RowIndex >= 0)
            {
                e.Value = Properties.Resources.DeleteIcon;
                //e.FormattingApplied = true; // Add this line
            }
        }

        private void Export_Excel_Click(object sender, EventArgs e)
        {
            string filePath = "";

            try
            {
                string saveDirectory = @"C:\ExcelBarcodeDatabase";
                Directory.CreateDirectory(saveDirectory);
                string baseFileName = "รายละเอียดการยืมคืนครุภัณฑ์_" + DateTime.Now.Date.ToString("dd MMMM yyyy") + ".xlsx"; // Base file name
                string fileName = baseFileName;
                int fileCounter = 1;
                while (File.Exists(Path.Combine(saveDirectory, fileName)))
                {
                    fileName = $"{Path.GetFileNameWithoutExtension(baseFileName)}_{fileCounter}{Path.GetExtension(baseFileName)}";
                    fileCounter++;
                }
                filePath = Path.Combine(saveDirectory, fileName);

                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet1 = package.Workbook.Worksheets.Add("Data");

                    int rowCount = TemporaryData.Count; // Use TemporaryData count
                    int colCount = 13; // Set the number of columns based on your SRResults object

                    // Set the font properties for the entire worksheet
                    worksheet1.Cells.Style.Font.Name = "TH Sarabun New";
                    worksheet1.Cells.Style.Font.Size = 12.0f;

                    // Header row
                    for (int col = 1; col <= colCount; col++)
                    {
                        var headerCell1 = worksheet1.Cells[1, col];
                        // Map the header cell to the SRResults properties
                        switch (col)
                        {
                            case 1:
                                headerCell1.Value = "ลำดับที่";
                                break;
                            case 2:
                                headerCell1.Value = "วันที่บันทึกในฐานข้อมูล";
                                break;
                            case 3:
                                headerCell1.Value = "หมายเลขครุภัณฑ์";
                                break;
                            case 4:
                                headerCell1.Value = "ชื่อผลิตภัณฑ์";
                                break;
                            case 5:
                                headerCell1.Value = "ชื่อผู้ยืมครุภัณฑ์";
                                break;
                            case 6:
                                headerCell1.Value = "สถานะการคืนครุภัณฑ์";
                                break;
                            case 7:
                                headerCell1.Value = "วันที่ยืมครุภัณฑ์";
                                break;
                            case 8:
                                headerCell1.Value = "วันที่คาดว่าจะคืนครุภัณฑ์";
                                break;
                            case 9:
                                headerCell1.Value = "วันที่คืนครุภัณฑ์จริง";
                                break;
                            case 10:
                                headerCell1.Value = "ช่องทางการติดต่อ";
                                break;
                            case 11:
                                headerCell1.Value = "หมายเหตุ";
                                break;
                        }
                        headerCell1.Style.Font.Bold = true;
                        headerCell1.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        headerCell1.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        headerCell1.Style.Font.Size = 14.0f;
                    }

                    // Data rows for worksheet1 (Data)
                    for (int row = 0; row < rowCount; row++)
                    {
                        for (int col = 0; col < colCount; col++)
                        {
                            var cell1 = worksheet1.Cells[row + 2, col + 1];
                            // Map the cell to the corresponding SRResults property
                            switch (col)
                            {
                                case 0:
                                    cell1.Value = row + 1;
                                    break;
                                case 1:
                                    cell1.Value = TemporaryData[row].Date;
                                    break;
                                case 2:
                                    cell1.Value = TemporaryData[row].BarcodeNumber;
                                    break;
                                case 3:
                                    cell1.Value = TemporaryData[row].Product_Name;
                                    break;
                                case 4:
                                    cell1.Value = TemporaryData[row].Borrower_Name;
                                    break;
                                case 5:
                                    cell1.Value = DecodingStatus(TemporaryData[row].Status);
                                    break;
                                case 6:
                                    cell1.Value = TemporaryData[row].InitialBorrowDate.Value.ToString("dd MMMM yyyy HH:mm:ss");
                                    break;
                                case 7:
                                    cell1.Value = TemporaryData[row].EstReturnDate.Value.ToString("dd MMMM yyyy HH:mm:ss");
                                    break;
                                case 8:
                                    cell1.Value = TemporaryData[row].ActualReturnDate.Value.ToString("dd MMMM yyyy HH:mm:ss");
                                    break;
                                case 9:
                                    cell1.Value = TemporaryData[row].Borrower_Contact;
                                    break;
                                case 10:
                                    cell1.Value = TemporaryData[row].Note;
                                    break;
                            }
                            // Align the first column to the middle
                            if (col == 0 || col == 1)
                            {
                                cell1.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                cell1.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            }
                            else
                            {
                                cell1.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                MessageBox.Show("นำข้อมูลออกเป็นไฟล์ Excel สำเร็จ! Output at " + filePath);
            }
        }

        private void Del_Database_Click(object sender, EventArgs e)
        {
            //Choose whether if you want to delete your old data in database, or update not dumplicate barcode data to database.
            DialogResult result2 = MessageBox.Show
            ("ต้องการที่จะลบบันทึกการยืม/คืนในฐานข้อมูลหรือไม่?\n"
            , "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result2 == DialogResult.Yes)
            {
                DialogResult result3 = MessageBox.Show
                ("แน่ใจหรือไม่ที่จะลบข้อมูลทั้งหมดในฐานข้อมูล?"
                 , "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result3 == DialogResult.Yes)
                {
                    DeleteDataInDB();
                    SearchDatainDB();
                }
            }
            else
            {

            }
        }

        private void DeleteDataInDB()
        {
            string connectionString = "server=127.0.0.1; user=root; database=borrow_returning_systemv; password=";
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    mySqlConnection.Open();

                    string query = "DELETE FROM borrowing_info";

                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected >= 0)
                        {
                            Console.WriteLine("ข้อมูลถูกลบเรียบร้อยแล้ว!");
                        }
                        else
                        {
                            Console.WriteLine("เกิดข้อผิดพลาดในการลบข้อมูล");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ข้อผิดพลาด : " + ex.Message);
                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
        }

        private void ReturnTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                ReturnTime.Format = DateTimePickerFormat.Custom;
                ReturnTime.CustomFormat = " ";
                ReturningDate = null;
                SearchDatainDB();
            }
        }
    }
}
