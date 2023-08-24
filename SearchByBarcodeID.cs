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
using USB_Barcode_Scanner;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            InitializeApplication();
        }
        private void BarcodeScanner_BarcodeScanned(object sender, BarcodeScannerEventArgs e)
        {
            BarcodeText.Text = e.Barcode;
            SearchBarcodeData(BarcodeText.Text);
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchBarcodeData(BarcodeText.Text);
        }
        private void SearchBarcodeData(string barcode)
        {
            List<string> dbData = new List<string>();
            string dbConnectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(dbConnectionString);

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

                // Compare the data
                bool isDataSame = dbData.Contains(barcode); // Check if the barcode is already in the database

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
                mySqlConnection.Close(); // Make sure to close the connection when done
            }
        }
        private void ShowmyBarcodeItem(string barcode)
        {
            Search SearchForm = MainMenu.initializedForms.Find(f => f is Search) as Search;
            ShowItem ShowItemForm = MainMenu.initializedForms.Find(f => f is ShowItem) as ShowItem;
            if (ShowItemForm != null)
            {
                SearchForm.Hide();
                ShowItemForm.Show();
                ShowItemForm.InitializePage();
                ShowItemForm.AssignBarcodeText(barcode);
            }
        }
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
            }
        }
        public void InitializeApplication()
        {
            //InitializeBarcode
            BarcodeScanner barcodeScanner = new BarcodeScanner(BarcodeText);
            barcodeScanner.BarcodeScanned += BarcodeScanner_BarcodeScanned;
            //QRText.Text = "กรุณาสแกน Barcode ครุภัณฑ์ของท่าน.";
            BarcodeText.Text = "";
        }
    }
}
