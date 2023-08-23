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
            PullDataFromDB();
            ////////////////////////////////////
            //PullDataFromDatabase
        }
        private void PullDataFromDB()
        {
            string mysqlCon = "server=127.0.0.1; user=root; database=barcodedatacollector; password =";
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon);
            try
            {
                string query = "SELECT Time, BarcodeNumber FROM information";
                mySqlConnection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Clear any existing rows
                        BarcodenumberCollector.Rows.Clear();
                        int numberofsortedItem = 1;
                        // Read and load data into DataGridView
                        while (reader.Read())
                        {
                            DateTime time = reader.GetDateTime("Time");
                            string qrCodeText = reader.GetString("BarcodeNumber");

                            // Add a new row to the DataGridView
                            BarcodenumberCollector.Rows.Add(numberofsortedItem, time, qrCodeText);
                            numberofsortedItem++;
                        }
                    }
                }
                //MessageBox.Show("Connection succeed.");
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
        private void AddDataToDatabase(string barcodetext)
        {
            string connectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);

            try
            {
                mySqlConnection.Open();

                string query = "INSERT INTO information (BarcodeNumber) " +
                               "VALUES (@BarcodeNumber)";

                using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                {
                    cmd.Parameters.AddWithValue("@BarcodeNumber", barcodetext);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Barcode Data inserted successfully!");
                        PullDataFromDB();
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert data.");
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

        }
    }
}
