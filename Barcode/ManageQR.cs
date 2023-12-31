﻿using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;



namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class ManageQR : Form
    {
        private BarcodeScanner2 _barcodeScanner;
        List<SRResults> TemporaryData;
        

        public ManageQR()
        {
            InitializeComponent();
            ////////////////////////////////////////////////////////
            _barcodeScanner = new BarcodeScanner2(BarcodeSearchBox);
            _barcodeScanner.BarcodeScanned += BarcodeScanner_BarcodeScanned2;
            ////////////////////////////////////////////////////////
            TemporaryData = new List<SRResults>();
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
            this.ActiveControl = null;
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

                    string query;
                    bool ifcheckunknownstatus = statusbox == StatusSearchBox.Items.Count - 2;
                    bool ifcheckunknowncondition = conditionbox == ConditionBox.Items.Count - 2;

                    //MessageBox.Show("Count : " + (StatusSearchBox.Items.Count - 2).ToString() + " " + (ConditionBox.Items.Count - 2).ToString());
                    //MessageBox.Show("Selecting : " + (StatusSearchBox.SelectedIndex - 1).ToString() + " " + (ConditionBox.SelectedIndex - 1).ToString());
                    //MessageBox.Show(ifcheckunknownstatus.ToString() + " " + ifcheckunknowncondition.ToString());
                    if (!(ifcheckunknowncondition || ifcheckunknownstatus))
                    {
                        query = "SELECT * FROM information WHERE (BarcodeNumber LIKE @BarcodesearchCriteria OR @BarcodesearchCriteria = 'ค้นหารหัสครุภัณฑ์' OR @BarcodesearchCriteria = '') " +
                                    "AND (Room LIKE @RoomsearchCriteria OR @RoomsearchCriteria = 'ค้นหาห้อง' OR @RoomsearchCriteria = '') " +
                                    "AND (Status = @StatussearchCriteria OR @StatussearchCriteria = -1) " +
                                    "AND (ITEM_CONDITION = @ConditionsearchCriteria OR @ConditionsearchCriteria = -1)";
                    }
                    else if (ifcheckunknowncondition && !ifcheckunknownstatus)
                    {
                        query = "SELECT * FROM information WHERE (BarcodeNumber LIKE @BarcodesearchCriteria OR @BarcodesearchCriteria = 'ค้นหารหัสครุภัณฑ์' OR @BarcodesearchCriteria = '') " +
                                    "AND (Room LIKE @RoomsearchCriteria OR @RoomsearchCriteria = 'ค้นหาห้อง' OR @RoomsearchCriteria = '') " +
                                    "AND (Status = @StatussearchCriteria OR @StatussearchCriteria = -1) " +
                                    "AND (ITEM_CONDITION = -1)";
                    }
                    else if (!ifcheckunknowncondition && ifcheckunknownstatus)
                    {
                        query = "SELECT * FROM information WHERE (BarcodeNumber LIKE @BarcodesearchCriteria OR @BarcodesearchCriteria = 'ค้นหารหัสครุภัณฑ์' OR @BarcodesearchCriteria = '') " +
                                    "AND (Room LIKE @RoomsearchCriteria OR @RoomsearchCriteria = 'ค้นหาห้อง' OR @RoomsearchCriteria = '') " +
                                    "AND (Status = -1) " +
                                    "AND (ITEM_CONDITION = @ConditionsearchCriteria OR @ConditionsearchCriteria = -1)";
                    }
                    else
                    {
                        query = "SELECT * FROM information WHERE " +
                        "(BarcodeNumber LIKE @BarcodesearchCriteria OR @BarcodesearchCriteria = 'ค้นหารหัสครุภัณฑ์' OR @BarcodesearchCriteria = '') " +
                        "AND (Room LIKE @RoomsearchCriteria OR @RoomsearchCriteria = 'ค้นหาห้อง' OR @RoomsearchCriteria = '') " +
                        "AND (Status = -1) " +
                        "AND (ITEM_CONDITION = -1)";
                    }

                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        command.Parameters.AddWithValue("@BarcodesearchCriteria", "%" + BarcodeSearchBox.Text + "%");
                        command.Parameters.AddWithValue("@RoomsearchCriteria", "%" + RoomSearchBox.Text + "%");
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
                                    Product_Name = reader["Product_Name"].ToString(),
                                    BarcodeNumber = reader["BarcodeNumber"].ToString(),
                                    ModelNumber = reader["Model_Name"].ToString(),
                                    Brand = reader["Brand"].ToString(),
                                    SerialNum = reader["Serial_Number"].ToString(),
                                    Price = reader["Price"].ToString(),
                                    Room = reader["Room"].ToString(),
                                    Description = reader["Note"].ToString(),
                                    FilePath = reader["ImageData"].ToString(),
                                    SHA512 = reader["MD5_ImageValidityChecksum"].ToString(),
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
            TemporaryData = ResultDataList;
            PopulateDataGridView(TemporaryData);
        }


        private void PopulateDataGridView(List<SRResults> data)
        {
            BarcodenumberCollector.Rows.Clear();

            int numberofsortedItem = 1;
            string tempstatus = "";
            string tempcondition = "";
            foreach (SRResults result in data)
            {
                switch (result.Status)
                {
                    case -1:
                        {
                            tempstatus = "ไม่พบข้อมูล";
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
                            tempcondition = "ไม่พบข้อมูล";
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
                (numberofsortedItem, result.BarcodeNumber, result.Product_Name, result.ModelNumber,
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
                SearchBarcode(TemporaryData[e.RowIndex].BarcodeNumber);
            }
            if (e.ColumnIndex == 12 && e.RowIndex >= 0)
            {
                // Your custom logic when the button is clicked
                EditBarcode(TemporaryData[e.RowIndex].BarcodeNumber);
            }
            if (e.ColumnIndex == 13 && e.RowIndex >= 0)
            {
                //Your custom logic when the button is clicked
                //Confirmation Box
                DialogResult result = MessageBox.Show
                ("ต้องการจะลบข้อมูลครุภัณฑ์นี้หรือไม่??", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check the user's response
                if (result == DialogResult.Yes)
                {
                    // User clicked "Yes," perform the action
                    DeleteBarcode(TemporaryData[e.RowIndex].BarcodeNumber);
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

        private void BarcodenumberCollector_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

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
                //e.FormattingApplied = true; // Add this line
            }
            if (e.ColumnIndex == 12 && e.RowIndex >= 0)
            {
                e.Value = Properties.Resources.EditIcon;
                //e.FormattingApplied = true; // Add this line
            }
            if (e.ColumnIndex == 13 && e.RowIndex >= 0)
            {
                e.Value = Properties.Resources.DeleteIcon;
               //e.FormattingApplied = true; // Add this line
            }
        }

        private void Export_Excel_Click(object sender, EventArgs e)
        {
            string filePath = "";
            bool successful = true;
            // Use a SaveFileDialog to prompt the user for the save location
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Save File",
                Filter = "All Files|*.*", // You can set specific file filters here
                FileName = "รายละเอียดครุภัณฑ์_" + DateTime.Now.Date.ToString("dd MMMM yyyy") + ".xlsx"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filePath = saveFileDialog.FileName;

                    if (!filePath.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                    {
                        filePath += ".xlsx";
                    }

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

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
                                    headerCell1.Value = "ยี่ห้อ";
                                    break;
                                case 6:
                                    headerCell1.Value = "หมายเลขรุ่น";
                                    break;
                                case 7:
                                    headerCell1.Value = "S/N";
                                    break;
                                case 8:
                                    headerCell1.Value = "ราคา";
                                    break;
                                case 9:
                                    headerCell1.Value = "ประจำอยู่ที่";
                                    break;
                                case 10:
                                    headerCell1.Value = "รายละเอียด";
                                    break;
                                case 11:
                                    headerCell1.Value = "สถานะ";
                                    break;
                                case 12:
                                    headerCell1.Value = "สภาพ";
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
                                        cell1.Value = TemporaryData[row].FormattedDate;
                                        break;
                                    case 2:
                                        cell1.Value = TemporaryData[row].BarcodeNumber;
                                        break;
                                    case 3:
                                        cell1.Value = TemporaryData[row].Product_Name;
                                        break;
                                    case 4:
                                        cell1.Value = TemporaryData[row].ModelNumber;
                                        break;
                                    case 5:
                                        cell1.Value = TemporaryData[row].Brand;
                                        break;
                                    case 6:
                                        cell1.Value = TemporaryData[row].SerialNum;
                                        break;
                                    case 7:
                                        cell1.Value = TemporaryData[row].Price;
                                        break;
                                    case 8:
                                        cell1.Value = TemporaryData[row].Room;
                                        break;
                                    case 9:
                                        cell1.Value = TemporaryData[row].Description;
                                        break;
                                    case 10:
                                        {
                                            string tempstatus;
                                            switch (TemporaryData[row].Status)
                                            {
                                                case -1:
                                                    {
                                                        tempstatus = "ไม่พบข้อมูล";
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
                                                default:
                                                    {
                                                        tempstatus = "ไม่พบข้อมูล";
                                                        break;
                                                    }
                                            }
                                            cell1.Value = tempstatus;
                                            break;
                                        }
                                    case 11:
                                        {
                                            string tempcondition;
                                            switch (TemporaryData[row].Condition)
                                            {
                                                case -1:
                                                    {
                                                        tempcondition = "ไม่พบข้อมูล";
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
                                                default:
                                                    {
                                                        tempcondition = "ไม่พบข้อมูล";
                                                        break;
                                                    }
                                            }
                                            cell1.Value = tempcondition;
                                            break;
                                        }
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

                        // Auto-size columns based on the content for worksheet1 (Data)
                        for (int col = 1; col <= colCount; col++)
                        {
                            worksheet1.Column(col).AutoFit();
                        }

                        // Create a new worksheet2 named "ImageData"
                        var worksheet2 = package.Workbook.Worksheets.Add("ImageData");

                        // Set the font properties for the entire worksheet2
                        worksheet2.Cells.Style.Font.Name = "TH Sarabun New";
                        worksheet2.Cells.Style.Font.Size = 12.0f;

                        // Header row for worksheet2
                        var headerCell2 = worksheet2.Cells[1, 1];
                        headerCell2.Value = "FilePath";
                        headerCell2.Style.Font.Bold = true;
                        headerCell2.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        headerCell2.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        headerCell2.Style.Font.Size = 14.0f;

                        var headerCell3 = worksheet2.Cells[1, 2];
                        headerCell3.Value = "SHA512";
                        headerCell3.Style.Font.Bold = true;
                        headerCell3.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        headerCell3.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        headerCell3.Style.Font.Size = 14.0f;

                        // Data rows for worksheet2 (ImageData)
                        for (int i = 0; i < TemporaryData.Count; i++)
                        {
                            var cell2 = worksheet2.Cells[i + 2, 1];
                            cell2.Value = TemporaryData[i].FilePath;
                            var cell3 = worksheet2.Cells[i + 2, 2];
                            cell3.Value = TemporaryData[i].SHA512;
                        }

                        // Auto-size columns based on the content for worksheet2 (ImageData)
                        worksheet2.Column(1).AutoFit();

                        package.Save();
                        //MessageBox.Show(filePath);
                    }
                }
                catch (Exception ex)
                {
                    successful = false;
                    MessageBox.Show("ข้อผิดพลาด : " + ex.Message);
                    return;
                }
                finally
                {
                    if (successful)
                    MessageBox.Show("นำข้อมูลออกเป็นไฟล์ Excel สำเร็จ! ที่อยู่ของไฟล์คุณอยู่ที่ " + filePath);
                }
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

        private void Import_Excel_Click(object sender, EventArgs e)
        {

        }
        private void Add_Data(OpenFileDialog openFileDialog)
        {
            List<SRResults> myexcelresult = new List<SRResults>();
            // User selected a file, you can now get the file path:
            string excelFilePath = openFileDialog.FileName;

            // Call your data import method here, passing the excelFilePath as a parameter:
            try
            {
                //myexcelresult = ImportDataFromExcel(excelFilePath, "Add");
                ////CurrentProblemLOL
                //if (myexcelresult == null)
                //{
                //    return;
                //}
                ////Your custom logic when the button is clicked
                ////Confirmation Box
                //DialogResult result = MessageBox.Show
                //("ต้องการจะนำข้อมููลเข้ามาในฐานข้อมูลหรือไม่?"
                //, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //// Check the user's response
                //if (result == DialogResult.Yes)
                //{
                //    //Choose whether if you want to delete your old data in database, or update not dumplicate barcode data to database.
                //    DialogResult result2 = MessageBox.Show
                //    ("ต้องการจะแทนที่ข้อมูลด้วยไฟล์ที่นำเข้ามาหรือไม่?" + Environment.NewLine +
                //    "Yes : แทนที่ข้อมูลด้วยไฟล์ที่นำเข้ามา" + Environment.NewLine +
                //    "No : เพิ่มข้อมูลและยังคงเก็บข้อมูลเดิมเอาไว้"
                //    , "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //    // Check the user's response
                //    if (result2 == DialogResult.Yes)
                //    {
                //        ////////////////////////////////////////////////////
                //        //Choose whether if you want to delete your old data in database, or update not dumplicate barcode data to database.
                //        DialogResult result4 = MessageBox.Show
                //        ("ต้องการที่จะลบฐานข้อมูลเก่าและแทนที่ด้วยข้อมูลที่นำเข้ามาหรือไม่?\n"
                //        , "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //        // Check the user's response
                //        if (result4 == DialogResult.Yes)
                //        {
                //            //Replace all data in the database.
                //            DeleteDataInDB();
                //            ImportExcelInDatabase(myexcelresult);
                //            SearchDatainDB();
                //        }
                //    }
                //    else
                //    {
                //        //Add and update data in database.
                //        ImportExcelInDatabase(myexcelresult);
                //        SearchDatainDB();
                //    }
                //}
                //else
                //{
                //    //No action
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {

            }
        }

        private void DeleteDataInDB()
        {
            string connectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    mySqlConnection.Open();

                    string query = "DELETE FROM information";

                    using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected >= 0)
                        {
                            Console.WriteLine("ข้อมูลถูกลบเรียบร้อยแล้ว!.");
                        }
                        else
                        {
                            Console.WriteLine("เกิดข้อผิดพลาดในการลบข้อมูล.");
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
        private void ImportExcelInDatabase(List<SRResults> resultlist, string action)
        {
            //bool importfile;
            bool isimportsuccess = true;
            if (resultlist == null)
            {
                return;
            }
            ////////
            //DialogResult result2 = MessageBox.Show
            //            ("ต้องการที่จะนำเข้าข้อมูลที่อยู่ไฟล์ภาพหรือไม่?\n"
            //            , "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //// Check the user's response
            //if (result2 == DialogResult.Yes)
            //{
            //    importfile = true;
            //}
            //else
            //{
            //    importfile = false;
            //}
            //////////////////////////////////////////////
            List<string> dbData = new List<string>();
            string connectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            try
            {
                mySqlConnection.Open();
                
                    string selectQuery = "SELECT BarcodeNumber FROM information";

                    // Use MySqlCommand instead of SqlCommand for MySQL
                    MySqlCommand command = new MySqlCommand(selectQuery, mySqlConnection);

                    // SqlDataReader is for SQL Server, use MySqlDataReader for MySQL
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string rowData = reader["BarcodeNumber"].ToString();
                        dbData.Add(rowData);
                    }
                // AdjustFromHere
                if (action == "Add")
                {
                    foreach (SRResults result in resultlist)
                    {
                        bool isDataSame = dbData.Contains(result.BarcodeNumber); // Check if the barcode is already in the database

                        if (!isDataSame)
                        {
                            AddBarcodeNumber(result);
                        }
                    }
                }
                else if (action == "Update")
                {
                    foreach (SRResults result in resultlist)
                    {
                        bool isDataSame = dbData.Contains(result.BarcodeNumber); // Check if the barcode is already in the database

                        if (isDataSame)
                        {
                            UpdateBarcodeNumber(result);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("คำสั่งไม่ถูกต้อง");
                }
            }
            catch (Exception ex)
            {
                isimportsuccess = false;
                MessageBox.Show("ข้อผิดพลาด : " + ex.Message);
            }
            finally
            {
                if (isimportsuccess)
                MessageBox.Show("การนำเข้าข้อมูลสำเร็จ!");
                mySqlConnection.Close(); // Make sure to close the connection when done
            }
        }

        private void AddBarcodeNumber(SRResults result)
        {
            string connectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";
            string importedfilepath, SHA512;
            //if (filepathreplacement)
            //{
                importedfilepath = result.FilePath;
                SHA512 = result.SHA512;
            //}
            //else
            //{
            //    importedfilepath = "[]";
            //    SHA512 = "[]";
            //}
            try
            {
                using (MySqlConnection mySqlConnection2 = new MySqlConnection(connectionString))
                {
                    mySqlConnection2.Open();

                    // Record with BarcodeNumber doesn't exist; perform an insert
                    string insertQuery = "INSERT INTO information (BarcodeNumber, Time, Product_Name, Model_Name, Brand, Serial_Number, Price, Room, Note, ImageData, MD5_ImageValidityChecksum, Status, ITEM_CONDITION) " +
                    "VALUES (@BarcodeNumber, @Time, @Product_Name, @Model_Name, @Brand, @Serial_Number, @Price, @Room, @Note, @ImageData, @MD5_ImageValidityChecksum, @Status, @ITEM_CONDITION)";

                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, mySqlConnection2))
                    {
                        insertCommand.Parameters.AddWithValue("@BarcodeNumber", result.BarcodeNumber);
                        insertCommand.Parameters.AddWithValue("@Time", DateTime.Now); // Or use the appropriate date value.
                        insertCommand.Parameters.AddWithValue("@Product_Name", result.Product_Name);
                        insertCommand.Parameters.AddWithValue("@Model_Name", result.ModelNumber);
                        insertCommand.Parameters.AddWithValue("@Brand", result.Brand);
                        insertCommand.Parameters.AddWithValue("@Serial_Number", result.SerialNum);
                        insertCommand.Parameters.AddWithValue("@Price", result.Price);
                        insertCommand.Parameters.AddWithValue("@Room", result.Room);
                        insertCommand.Parameters.AddWithValue("@Note", result.Description);
                        insertCommand.Parameters.AddWithValue("@ImageData", importedfilepath);
                        insertCommand.Parameters.AddWithValue("@MD5_ImageValidityChecksum", SHA512);
                        insertCommand.Parameters.AddWithValue("@Status", result.Status);
                        insertCommand.Parameters.AddWithValue("@ITEM_CONDITION", result.Condition);

                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            //MessageBox.Show("Barcode Data inserted successfully!");
                        }
                        else
                        {
                            //MessageBox.Show("Barcode Data insertion failed!");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    private void UpdateBarcodeNumber(SRResults result)
    {
            string connectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";
            string importedfilepath, SHA512;
            //if (filepathreplacement)
            //{
                importedfilepath = result.FilePath;
                SHA512 = result.SHA512;
            //}
            //else
            //{
            //    importedfilepath = "[]";
            //    SHA512 = "[]";
            //}
            try
    {
        using (MySqlConnection mySqlConnection2 = new MySqlConnection(connectionString))
        {
            mySqlConnection2.Open();

            string query = "UPDATE information SET " +
               "Product_Name = @Product_Name, " +
               "Model_Name = @Model_Name, " +
               "Brand = @Brand, " +
               "Serial_Number = @Serial_Number, " +
               "Price = @Price, " +
               "Room = @Room, " +
               "Note = @Note, " +
               "ImageData = @ImageData, " +
               "MD5_ImageValidityChecksum = @MD5_ImageValidityChecksum," +
               "Status = @Status, " +
               "ITEM_CONDITION = @ITEM_CONDITION " +
               "WHERE BarcodeNumber = @BarcodeNumber";

            using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection2))
            {
                cmd.Parameters.AddWithValue("@Product_Name", result.Product_Name);
                cmd.Parameters.AddWithValue("@Model_Name", result.ModelNumber);
                cmd.Parameters.AddWithValue("@Brand", result.Brand);
                cmd.Parameters.AddWithValue("@Serial_Number", result.SerialNum);
                cmd.Parameters.AddWithValue("@Price", result.Price);
                cmd.Parameters.AddWithValue("@Room", result.Room);
                cmd.Parameters.AddWithValue("@Note", result.Description);
                cmd.Parameters.AddWithValue("@ImageData", importedfilepath);
                cmd.Parameters.AddWithValue("@MD5_ImageValidityChecksum", SHA512);
                cmd.Parameters.AddWithValue("@Status", result.Status);
                cmd.Parameters.AddWithValue("@ITEM_CONDITION", result.Condition);
                cmd.Parameters.AddWithValue("@BarcodeNumber", result.BarcodeNumber);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    //MessageBox.Show("Barcode Data updated successfully!");
                }
                else
                {
                    MessageBox.Show("การเปลี่ยนแปลงข้อมูลล้มเหลว");
                }
            }
        }
    }
    catch (MySqlException ex)
    {
        MessageBox.Show(ex.ToString());
    }
}


        private List<SRResults> ImportDataFromExcel(string excelFilePath)
        {
            List<SRResults> excelDataList = new List<SRResults>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            bool hasWarnings = false;
            string warningmessage = "";

            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                var worksheet1 = package.Workbook.Worksheets["Data"]; // Assuming data is on the first worksheet
                var worksheet2 = package.Workbook.Worksheets["ImageData"];
                bool isformcorrect = true;
                for (int col = 1; col <= worksheet1.Dimension.End.Column; col++)
                {
                    switch (col)
                    {
                        case 1:
                            {
                                if (worksheet1.Cells[1, col].Text != "ลำดับที่")
                                    isformcorrect = false;
                                break;
                            }
                        case 2:
                            {
                                if (worksheet1.Cells[1, col].Text != "วันที่บันทึกในฐานข้อมูล")
                                    isformcorrect = false;
                                break;
                            }
                        case 3:
                            {
                                if (worksheet1.Cells[1, col].Text != "หมายเลขครุภัณฑ์")
                                    isformcorrect = false;
                                break;
                            }
                        case 4:
                            {
                                if (worksheet1.Cells[1, col].Text != "ชื่อผลิตภัณฑ์")
                                    isformcorrect = false;
                                break;
                            }
                        case 5:
                            {
                                //MessageBox.Show(worksheet1.Cells[1, col].Text);
                                if (worksheet1.Cells[1, col].Text != "ยี่ห้อ")
                                    isformcorrect = false;
                                break;
                            }
                        case 6:
                            {
                                if (worksheet1.Cells[1, col].Text != "หมายเลขรุ่น")
                                    isformcorrect = false;
                                break;
                            }
                        case 7:
                            {
                                if (worksheet1.Cells[1, col].Text != "S/N")
                                    isformcorrect = false;
                                break;
                            }
                        case 8:
                            {
                                if (worksheet1.Cells[1, col].Text != "ราคา")
                                    isformcorrect = false;
                                break;
                            }
                        case 9:
                            {
                                if (worksheet1.Cells[1, col].Text != "ประจำอยู่ที่")
                                    isformcorrect = false;
                                break;
                            }
                        case 10:
                            {
                                if (worksheet1.Cells[1, col].Text != "รายละเอียด")
                                    isformcorrect = false;
                                break;
                            }
                        case 11:
                            {
                                if (worksheet1.Cells[1, col].Text != "สถานะ")
                                    isformcorrect = false;
                                break;
                            }
                        case 12:
                            {
                                if (worksheet1.Cells[1, col].Text != "สภาพ")
                                    isformcorrect = false;
                                break;
                            }
                    }
                }
                //MessageBox.Show(isformcorrect.ToString());
                if (isformcorrect)
                {
                    int myrow = 0;
                    for (int row = 2; row <= worksheet1.Dimension.End.Row; row++) // Assuming the first row contains headers
                    {
                        int tempstatus = -1;
                        int tempcondition = -1;
                        switch (worksheet1.Cells[row, 11].Text)
                        {
                            case "ไม่พบข้อมูล":
                                tempstatus = -1;
                                break;
                            case "มีให้ตรวจสอบ":
                                tempstatus = 0;
                                break;
                            case "ไม่มีให้ตรวจสอบ":
                                tempstatus = 1;
                                break;
                            default:
                                tempstatus = -1;
                                break;
                        }
                        switch (worksheet1.Cells[row, 12].Text)
                        {
                            case "ไม่พบข้อมูล":
                                tempcondition = -1;
                                break;
                            case "ใช้งานได้":
                                tempcondition = 0;
                                break;
                            case "ชำรุดรอซ่อม":
                                tempcondition = 1;
                                break;
                            case "สิ้นสภาพ":
                                tempcondition = 2;
                                break;
                            case "สูญหาย":
                                tempcondition = 3;
                                break;
                            case "จำหน่ายแล้ว":
                                tempcondition = 4;
                                break;
                            case "โอนแล้ว":
                                tempcondition = 5;
                                break;
                            case "อื่นๆ":
                                tempcondition = 6;
                                break;
                            default:
                                tempcondition = -1;
                                break;
                        }

                        // Convert the formatted date string to DateTime
                        string formattedDateStr = worksheet1.Cells[row, 2].Text; // Assuming the date is in column 10
                        DateTime formattedDate;

                        if (DateTime.TryParseExact(formattedDateStr, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out formattedDate))
                        {
                            // The value was successfully parsed
                        }
                        else
                        {
                            // Parsing failed, use DateTime.Now as a fallback
                            formattedDate = DateTime.Now;
                        }

                        string formattedDateStrForDisplay = formattedDate.ToString("dd-MM-yyyy HH:mm:ss"); // Format for display

                        SRResults excelData = new SRResults
                        {
                            BarcodeNumber = string.IsNullOrEmpty(worksheet1.Cells[row, 3].Text) ? "-" : worksheet1.Cells[row, 3].Text.Replace(" ", ""),
                            Product_Name = string.IsNullOrEmpty(worksheet1.Cells[row, 4].Text) ? "-" : worksheet1.Cells[row, 4].Text,
                            ModelNumber = string.IsNullOrEmpty(worksheet1.Cells[row, 5].Text) ? "-" : worksheet1.Cells[row, 5].Text,
                            Brand = string.IsNullOrEmpty(worksheet1.Cells[row, 6].Text) ? "-" : worksheet1.Cells[row, 6].Text,
                            SerialNum = string.IsNullOrEmpty(worksheet1.Cells[row, 7].Text) ? "-" : worksheet1.Cells[row, 7].Text,
                            Price = string.IsNullOrEmpty(worksheet1.Cells[row, 8].Text) ? "0" : worksheet1.Cells[row, 8].Text,
                            Room = string.IsNullOrEmpty(worksheet1.Cells[row, 9].Text) ? "-" : worksheet1.Cells[row, 9].Text,
                            Description = string.IsNullOrEmpty(worksheet1.Cells[row, 10].Text) ? "-" : worksheet1.Cells[row, 10].Text,
                            FilePath = string.IsNullOrEmpty(worksheet2.Cells[row, 1].Text) ? "[]" : worksheet2.Cells[row, 1].Text,
                            SHA512 = string.IsNullOrEmpty(worksheet2.Cells[row, 2].Text) ? "[]" : worksheet2.Cells[row, 2].Text,
                            Status = tempstatus,
                            Condition = tempcondition,
                            Date = formattedDate,
                            FormattedDate = formattedDateStrForDisplay
                        };
                        //MessageBox.Show((row-1).ToString() + "/" + excelData.BarcodeNumber + "/" + excelData.Product_Name);
                        

                        if (excelData.BarcodeNumber == "-" || excelData.Product_Name == "-")
                        {
                            excelData = null;
                            continue;
                            //warningmessage += "ข้อมูลของหมายเลขครุภัณฑ์ และ ชื่อผลิตภัณฑ์ ต้องถูกบันทึกไว้ในข้อมูลที่จะนำเข้ามา\n";
                        }
                        if (excelData.BarcodeNumber.Length > 50)
                        {
                            warningmessage += "ความยาวหมายเลขครุภัณฑ์ห้ามเกิน 50 ตัวอักษร\n";
                        }
                        if (excelData.Product_Name.Length > 100 || excelData.ModelNumber.Length > 100 || excelData.Brand.Length > 100 ||
                            excelData.SerialNum.Length > 100 || excelData.Room.Length > 100)
                        {
                            warningmessage += "ความยาวข้อมูลครุภัณฑ์ห้ามเกิน 100 ตัวอักษร\n";
                        }
                        if (excelData.Price.Length > 30)
                        {
                            warningmessage += "ความยาวข้อมูลราคาห้ามเกิน 30 ตัวอักษร\n";
                        }
                        if (excelData.Description.Length > 200)
                        {
                            warningmessage += "ความยาวรายละเอียดครุภัณฑ์ห้ามเกิน 200 ตัวอักษร\n";
                        }
                        if (!int.TryParse(excelData.Price, out int result))
                        {
                            warningmessage += "กรุณากรอกราคาเป็นตัวเลขเท่านั้น\n";
                        }
                        if (warningmessage != "")
                        {
                            MessageBox.Show(warningmessage);
                            excelDataList.Clear();
                            hasWarnings = true;
                            break; // Exit the loop immediately when a warning is encountered
                        }
                        else
                        {
                            excelDataList.Add(excelData);
                        }
                        //myrow = row;
                    }
                }
                else
                {
                    warningmessage += "แบบฟอร์ม Excel ไม่ถูกต้อง\n";
                    MessageBox.Show(warningmessage);
                    excelDataList.Clear();
                    hasWarnings = true;
                    //break; // Exit the loop immediately when a warning is encountered
                }
            }


            if (hasWarnings)
            {
                return null; // Return null if any warnings were encountered
            }
            else
            {
                return excelDataList; // Return the list if no warnings
            }
        }


        private void Del_Database_Click(object sender, EventArgs e)
        {
            //Choose whether if you want to delete your old data in database, or update not dumplicate barcode data to database.
            DialogResult result2 = MessageBox.Show
            ("ต้องการที่จะลบหมายเลขครุภัณฑ์ในฐานข้อมูลหรือไม่?\n"
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
                    MessageBox.Show("ลบข้อมูลสำเร็จ!");
                    SearchDatainDB();
                }
            }
            else
            {

            }
        }
        private void Download_Template_Click(object sender, EventArgs e)
        {
            // Get the resource bytes
            byte[] resourceBytes = Properties.Resources.MDT_Stock_Import_Example;

            if (resourceBytes != null)
            {
                // Use a SaveFileDialog to prompt the user for the save location
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Title = "Save File",
                    Filter = "All Files|*.*", // You can set specific file filters here
                    FileName = "MDT_Stock_Import_Example_file.xlsx", // Default file name
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = saveFileDialog.FileName + ".xlsx";

                    // Create a memory stream from the resource bytes
                    using (MemoryStream resourceStream = new MemoryStream(resourceBytes))
                    {
                        // Copy the memory stream to the selected file
                        using (var fileStream = File.Create(selectedFilePath))
                        {
                            resourceStream.CopyTo(fileStream);
                        }
                    }

                    // Notify the user that the download is complete
                    MessageBox.Show("การดาวน์โหลดไฟล์เสร็จเรียบร้อย");
                }
            }
            else
            {
                MessageBox.Show("ไม่พบไฟล์ที่จะดาวน์โหลด");
            }
        }

        private void Add_Excel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DialogResult result = MessageBox.Show
                        ("ต้องการเพิ่มข้อมูลครุภัณฑ์ที่ไม่มีในฐานข้อมูลหรือไม่?\n"
                        , "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check the user's response
                if (result == DialogResult.Yes)
                {
                    //Add excel data in the database.
                    ImportExcelInDatabase(ImportDataFromExcel(openFileDialog.FileName),"Add");
                    SearchDatainDB();
                }
            }
        }

        private void Update_Excel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DialogResult result = MessageBox.Show
                        ("ต้องการอัพเดทข้อมูลครุภัณฑ์ที่มีอยู่ในฐานข้อมูลหรือไม่?\n"
                        , "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check the user's response
                if (result == DialogResult.Yes)
                {
                    DialogResult result2 = MessageBox.Show
                       ("คำเตือน! ข้อมูลในฐานข้อมูลจะถูกแทนที่ด้วยข้อมูลที่นำมาจาก Excel\n"
                       , "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Check the user's response
                    if (result2 == DialogResult.Yes)
                    {
                        //Add excel data in the database.
                        ImportExcelInDatabase(ImportDataFromExcel(openFileDialog.FileName), "Update");
                        SearchDatainDB();
                    }
                }
            }
        }
    }
}