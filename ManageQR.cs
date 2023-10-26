using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using USB_Barcode_Scanner;
using OfficeOpenXml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using OfficeOpenXml.Style;
using PdfSharp.Pdf.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;
using PdfReader = iTextSharp.text.pdf.PdfReader;
using System.Drawing;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class ManageQR : Form
    {
        private BarcodeScanner2 _barcodeScanner;

        public ManageQR()
        {
            InitializeComponent();
            ////////////////////////////////////////////////////////
            _barcodeScanner = new BarcodeScanner2(BarcodeSearchBox);
            _barcodeScanner.BarcodeScanned += BarcodeScanner_BarcodeScanned2;
            ////////////////////////////////////////////////////////
            StatusSearchBox.SelectedIndex = 0;
            ConditionBox.SelectedIndex = 0;
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
            int statusbox = StatusSearchBox.SelectedIndex - 1;
            int conditionbox = ConditionBox.SelectedIndex - 1;
            List<SRResults> ResultDataList = new List<SRResults>();
            string connectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";

            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    mySqlConnection.Open();

                    string query = "SELECT * FROM information WHERE (BarcodeNumber LIKE @BarcodesearchCriteria OR @BarcodesearchCriteria = 'ค้นหารหัสครุภัณฑ์' OR @BarcodesearchCriteria = '') " +
                                    "AND (Room LIKE @RoomsearchCriteria OR @RoomsearchCriteria = 'ค้นหาห้อง' OR @RoomsearchCriteria = '') " +
                                    "AND (Status = @StatussearchCriteria OR @StatussearchCriteria = -1) " +
                                    "AND (ITEM_CONDITION = @ConditionsearchCriteria OR @ConditionsearchCriteria = -1)";


                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@BarcodesearchCriteria", BarcodeSearchBox.Text + "%");
                        command.Parameters.AddWithValue("@RoomsearchCriteria", RoomSearchBox.Text + "%");
                        command.Parameters.AddWithValue("@StatussearchCriteria", statusbox);
                        command.Parameters.AddWithValue("@ConditionsearchCriteria", conditionbox);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SRResults data2 = new SRResults
                                {
                                    Date = reader.GetDateTime("Time"),
                                    FormattedDate = reader.GetDateTime("Time").ToString("dd-MM-yyyy HH:mm:ss"),
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

            int numberofsortedItem = 1;
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
                            tempstatus = "ไม่มีให้ตรวจสอบ";
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
                (numberofsortedItem, result.FormattedDate, result.BarcodeNumber, result.ModelNumber,
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

        private void Export_Excel_Click(object sender, EventArgs e)
        {
            string filePath = "";

            try
            {
                string saveDirectory = @"C:\ExcelBarcodeDatabase";
                Directory.CreateDirectory(saveDirectory);
                string baseFileName = "Database.xlsx"; // Base file name
                string fileName = baseFileName;
                int fileCounter = 1;
                while (File.Exists(Path.Combine(saveDirectory, fileName)))
                {
                    fileName = $"{Path.GetFileNameWithoutExtension(baseFileName)}_{fileCounter}{Path.GetExtension(baseFileName)}";
                    fileCounter++;
                }
                filePath = Path.Combine(saveDirectory, fileName);

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    int rowCount = BarcodenumberCollector.Rows.Count;
                    int colCount = BarcodenumberCollector.Columns.Count;

                    // Set the font properties for the entire worksheet
                    worksheet.Cells.Style.Font.Name = "TH Sarabun New";
                    worksheet.Cells.Style.Font.Size = 12.0f;

                    // Header row
                    for (int col = 1; col <= colCount; col++)
                    {
                        var headerCell = worksheet.Cells[1, col];
                        headerCell.Value = BarcodenumberCollector.Columns[col - 1].HeaderText;
                        headerCell.Style.Font.Bold = true;
                        headerCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        headerCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        // Increase font size for the first row (header)
                        if (col == 1)
                        {
                            headerCell.Style.Font.Size = 14.0f;
                        }
                    }

                    // Data rows
                    for (int row = 0; row < rowCount; row++)
                    {
                        for (int col = 0; col < colCount; col++)
                        {
                            var cell = worksheet.Cells[row + 2, col + 1];
                            cell.Value = BarcodenumberCollector.Rows[row].Cells[col].Value;

                            // Align the first column to the middle
                            if (col == 0)
                            {
                                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            }
                        }
                    }

                    // Auto-size columns based on the content
                    for (int col = 1; col <= colCount; col++)
                    {
                        worksheet.Column(col).AutoFit();
                    }

                    package.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                 MessageBox.Show("Export to Excel completed. Output at " + filePath);
            }
        }

        private void Export_PDF_Click(object sender, EventArgs e)
        {
            string excelFilePath = "YourExcelFile.xlsx"; // Replace with your Excel file path
            string pdfFilePath = "YourOutput.pdf"; // Specify the output PDF file path

            ConvertExcelToPDF(excelFilePath, pdfFilePath);

            MessageBox.Show("Export to PDF completed. Output at " + pdfFilePath);
        }
        private void ConvertExcelToPDF(string excelFilePath, string pdfFilePath)
        {
            try
            {
                using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    // Your existing Excel export code goes here

                    package.Save();
                }

                using (var excelStream = File.OpenRead(excelFilePath))
                using (var pdfStream = new FileStream(pdfFilePath, FileMode.Create, FileAccess.Write))
                {
                    var document = new Document();
                    var writer = PdfWriter.GetInstance(document, pdfStream);
                    document.Open();
                    var reader = new PdfReader(excelStream);
                    for (int page = 1; page <= reader.NumberOfPages; page++)
                    {
                        document.NewPage();
                        PdfImportedPage importedPage = writer.GetImportedPage(reader, page);
                        writer.DirectContent.AddTemplate(importedPage, 0, 0);
                    }
                    document.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            SearchDatainDB();
        }

        private void RoomSearchBox_TextChanged(object sender, EventArgs e)
        {
            SearchDatainDB();
        }

        private void StatusSearchBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchDatainDB();
        }

        private void ConditionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchDatainDB();
        }
    }
}