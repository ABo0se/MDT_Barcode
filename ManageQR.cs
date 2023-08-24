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
using System.Management;
using System.Data.SqlClient;
using static USB_Barcode_Scanner_Tutorial___C_Sharp.ShowItem;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class ManageQR : Form
    {

        public ManageQR()
        {
            InitializeComponent();
        }
        public List<string> barcodedata = new List<string>();
        /////////////////////////////////////////////////////////////
        private void BarcodeScanner_BarcodeScanned2(object sender, BarcodeScannerEventArgs e)
        {
            BarcodeSearchBox.Text = e.Barcode;
            //AddDataToDatabase(e.Barcode);
            //StoreData(e.Barcode);
        }
        private void InitializeApplication()
        {
            //barcodedata.Clear();
            BarcodenumberCollector.Rows.Clear();
            SearchDatainDB();
            //PullDataFromDB();
            ////////////////////////////////////
            //PullDataFromDatabase
        }
        //private void PullDataFromDB()
        //{
        //    string mysqlCon = "server=127.0.0.1; user=root; database=barcodedatacollector; password =";
        //    MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon);
        //    try
        //    {
        //        string query = "SELECT Time, BarcodeNumber FROM information";
        //        mySqlConnection.Open();
        //        using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
        //        {
        //            using (MySqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                // Clear any existing rows
        //                BarcodenumberCollector.Rows.Clear();
        //                int numberofsortedItem = 1;
        //                // Read and load data into DataGridView
        //                while (reader.Read())
        //                {
        //                    DateTime time = reader.GetDateTime("Time");
        //                    string qrCodeText = reader.GetString("BarcodeNumber");

        //                    // Add a new row to the DataGridView
        //                    BarcodenumberCollector.Rows.Add(numberofsortedItem, time, qrCodeText);
        //                    numberofsortedItem++;
        //                }
        //            }
        //        }
        //        //MessageBox.Show("Connection succeed.");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        mySqlConnection.Close();
        //    }
        //}
        private void AddDataToDatabase(string barcodetext)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeApplication();
            BarcodeScanner barcodeScanner = new BarcodeScanner(BarcodeSearchBox);
            barcodeScanner.BarcodeScanned += BarcodeScanner_BarcodeScanned2;
        }

        private void Search_Func(object sender, EventArgs e)
        {

        }
        private void BarcodeSearchBox_TextChanged(object sender, EventArgs e)
        {
            SearchDatainDB();
        }
        private void SearchDatainDB()
        {
            List<SRResults2> ResultDataList = new List<SRResults2>();
            ResultDataList.Clear();
            /////////////////
            string connectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            try
            {
                mySqlConnection.Open();

                string query = "SELECT * FROM information WHERE BarcodeNumber LIKE @searchCriteria";

                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@searchCriteria", BarcodeSearchBox.Text + "%");
                    MySqlDataReader reader = command.ExecuteReader();
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
                //AddDataToGridView
                BarcodenumberCollector.Rows.Clear();
                int numberofsortedItem = 0;
                foreach (SRResults2 result in ResultDataList)
                {
                    BarcodenumberCollector.Rows.Add
                    (numberofsortedItem, result.Date, result.BarcodeNumber, result.ModelNumber,
                     result.Brand, result.SerialNum, result.Price, result.Room,
                     result.Description);
                    numberofsortedItem++;
                }

                // Add a new row to the DataGridView

                ///////////////////////////
                mySqlConnection.Close();
            }
        }
        private void Manage_Close(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
            }
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
}
