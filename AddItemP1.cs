using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using USB_Barcode_Scanner;
using MySql.Data.MySqlClient;
using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI.Relational;
using System.Collections;
using Org.BouncyCastle.Utilities;
using System.Data.SqlClient;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class AddItemP1 : Form
    {
        public AddItemP1()
        {
            InitializeComponent();
        }

        private void BarcodeScanner_BarcodeScanned2(object sender, BarcodeScannerEventArgs e)
        {
            QRText.Text = "Retrieving barcode product data.";
            BarcodeText.Text = e.Barcode;
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
                bool isDataSame = dbData.Contains(e.Barcode); // Check if the barcode is already in the database

                if (isDataSame)
                {
                    MessageBox.Show("การเพิ่มครุภัณฑ์ล้มเหลว! เนื่องจากซ้ำกับข้อมูลที่มีอยู่ในฐานข้อมูล");
                }
                else
                {
                    AddItem2(e.Barcode);
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



        private void AddItem2(string barcode)
        {
            AddItemP1 AddItemForm1 = MainMenu.initializedForms.Find(f => f is AddItemP1) as AddItemP1;
            AddItemP2 AddItemForm2 = MainMenu.initializedForms.Find(f => f is AddItemP2) as AddItemP2;
            if (AddItemForm2 != null && AddItemForm1 != null)
            {
                AddItemForm1.Hide();
                AddItemForm2.Show();
                AddItemForm2.InitializePage();
                AddItemForm2.AssignBarcodeText(barcode);
            }
        }

        private void QRText_Click(object sender, EventArgs e)
        {

        }
        public void InitializeApplication()
        {
            //InitializeBarcode
            BarcodeScanner barcodeScanner = new BarcodeScanner(BarcodeText);
            barcodeScanner.BarcodeScanned += BarcodeScanner_BarcodeScanned2;
            QRText.Text = "กรุณาสแกน Barcode ครุภัณฑ์ของท่าน.";
            BarcodeText.Text = "";
        }
        private void AddItemP1_Load(object sender, EventArgs e)
        {
            InitializeApplication();
        }

        private void BarcodeText_TextChanged(object sender, EventArgs e)
        {

        }


        private void AddItemFormClosed(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
            }
        }
    }
}
