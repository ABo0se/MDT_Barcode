﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class AddItemP2 : Form
    {
        string PicFilePath = null;
        int checkstate = 0;
        int conditionstate = 0;
        /// ///////////////////////////////////////////
        public AddItemP2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddItemP2_Load(object sender, EventArgs e)
        {
            InitializePage();
        }

        private void Created_Time_Click(object sender, EventArgs e)
        {

        }

        private void Room_Click(object sender, EventArgs e)
        {

        }

        private void Add_Pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*"; // Set the file filter if needed
            openFileDialog.Title = "Select a File to Upload";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                // Handle the selected file path (e.g., upload it or process it)
                // You can call a method to process the file with the selectedFilePath
                // Load the selected image into the PictureBox
                Image selectedImage = Image.FromFile(selectedFilePath);

                pictureBox1.Image = selectedImage;
                PicFilePath = selectedFilePath;
            }
        }
        private void BarcodeScanner_BarcodeScanned(object sender, BarcodeScannerEventArgs e)
        {
            SearchBarcodeData(e.Barcode, sender);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void BarcodeID_TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Item_toDB_Click(object sender, EventArgs e)
        {
            //Serach before we do something.
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
                bool isDataSame = dbData.Contains(BarcodeID_TB.Text); // Check if the barcode is already in the database

                if (isDataSame)
                {
                    MessageBox.Show("ไม่สามารถเพิ่มข้อมูลลงในระบบได้ เนื่องจากมีรหัสครุภัณฑ์นี้อยู่แล้ว");
                }
                else if (BarcodeID_TB.Text == "" || Model_TB.Text == "" || Brand_TB.Text == "" ||
                         Serial_TB.Text == "" || Price_TB.Text == "" || Room_TB.Text == "" ||
                         Room_TB.Text == "" || Note_TB.Text == "")// ||
                         //checkstate == -1 || conditionstate == -1)
                {
                    MessageBox.Show("กรุณากรอกรายละเอียดของครุภัณฑ์ให้ครบถ้วน ก่อนทำการเพิ่มเข้ามา");
                }
                else
                {
                    AddItemToDB();
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
            /////////////////////////////////////////////////////////////////////////////////////////////////////
        }
        private void AddItemToDB()
        {
            string connectionString = "server=127.0.0.1; user=root; database=barcodedatacollector; password=";
            MySqlConnection mySqlConnection2 = new MySqlConnection(connectionString);

            try
            {
                mySqlConnection2.Open();

                string query = "INSERT INTO information (BarcodeNumber, Model_Name, Brand, Serial_Number, Price, Room, Pic, Note, Status, ITEM_CONDITION) " +
                               "VALUES (@BarcodeNumber, @Model_Name, @Brand, @Serial_Number, @Price, @Room, @Pic, @Note, @Status, @ITEM_CONDITION)";

                if (PicFilePath == null)
                {
                    PicFilePath = "";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection2))
                {
                    cmd.Parameters.AddWithValue("@BarcodeNumber", BarcodeID_TB.Text);
                    cmd.Parameters.AddWithValue("@Model_Name", Model_TB.Text);
                    cmd.Parameters.AddWithValue("@Brand", Brand_TB.Text);
                    cmd.Parameters.AddWithValue("@Serial_Number", Serial_TB.Text);
                    cmd.Parameters.AddWithValue("@Price", Price_TB.Text);
                    cmd.Parameters.AddWithValue("@Room", Room_TB.Text);
                    cmd.Parameters.AddWithValue("@Pic", PicFilePath);
                    cmd.Parameters.AddWithValue("@Note", Note_TB.Text);
                    cmd.Parameters.AddWithValue("@Status", checkstate);
                    cmd.Parameters.AddWithValue("@ITEM_CONDITION", conditionstate);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Barcode Data inserted successfully!");
                        //PullDataFromDB();
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
                mySqlConnection2.Close();
                AddItemP2 AddItemForm = MainMenu.initializedForms.Find(f => f is AddItemP2) as AddItemP2;
                if (AddItemForm != null)
                {
                    AddItemForm.Hide();
                }
            }
        }
        private void SearchBarcodeData(string barcode, object sender)
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
                mySqlConnection.Close();
                if (isDataSame)
                {
                    MessageBox.Show("ไม่สามารถเพิ่มข้อมูลลงในระบบได้ เนื่องจากมีรหัสครุภัณฑ์นี้อยู่แล้ว");
                    this.Hide();
                }
                else
                {
                    //
                    if (sender == BarcodeID_TB)
                    {
                        BarcodeID_TB.Text = barcode;
                    }
                    else
                    {
                        BarcodeID_TB.Text = barcode;
                        ///
                        Model_TB.Text = "";
                        Brand_TB.Text = "";
                        Serial_TB.Text = "";
                        Price_TB.Text = "";
                        Room_TB.Text = "";
                        Note_TB.Text = "";
                        S_Have.Checked = false;
                        S_Donthave.Checked = false;
                        checkstate = -1;
                        conditionstate = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void InitializePage()
        {
            BarcodeScanner2 barcodeScanner1 = new BarcodeScanner2(BarcodeID_TB);
            BarcodeScanner2 barcodeScanner2 = new BarcodeScanner2(Model_TB);
            BarcodeScanner2 barcodeScanner3 = new BarcodeScanner2(Brand_TB);
            BarcodeScanner2 barcodeScanner4 = new BarcodeScanner2(Serial_TB);
            BarcodeScanner2 barcodeScanner5 = new BarcodeScanner2(Price_TB);
            BarcodeScanner2 barcodeScanner6 = new BarcodeScanner2(Room_TB);
            BarcodeScanner2 barcodeScanner7 = new BarcodeScanner2(Note_TB);
            barcodeScanner2.BarcodeScanned += BarcodeScanner_BarcodeScanned;
            /////////////////////////////////
            PicFilePath = "";
            pictureBox1.Image = Properties.Resources.NoImage;
            BarcodeID_TB.Text = "";
            Model_TB.Text = "";
            Brand_TB.Text = "";
            Serial_TB.Text = "";
            Price_TB.Text = "";
            Room_TB.Text = "";
            Note_TB.Text = "";

            checkstate = -1;
            conditionstate = -1;

            S_Have.Checked = false;
            S_Donthave.Checked = false;
        }

        private void Form_Closing3(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
            }
        }

        private void S_Have_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show(S_Have.Checked.ToString());
            if (S_Have.Checked)
            {
                conditionstate = 0; //มี
            }
            else
            {
                conditionstate = 1; //ไม่มี
            }
        }

        private void S_Donthave_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show(S_Donthave.Checked.ToString());
            if (S_Donthave.Checked)
            {
                conditionstate = 1; //มี
            }
            else
            {
                conditionstate = 0; //ไม่มี
            }
        }

        private void ConditionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            conditionstate = ConditionBox.SelectedIndex;
            //switch (ConditionBox.SelectedIndex)
            //{
            //    case -1:
            //    {
            //        conditionstate = -1;
            //        break;
            //    }
            //    case 0:
            //    {
            //        conditionstate = 0;
            //        break;
            //    }
            //    case 1:
            //    {
            //        conditionstate = 1;
            //        break;
            //    }
            //    case 2:
            //    {
            //        conditionstate = 2;
            //        break;
            //    }
            //    case 3:
            //    {
            //        conditionstate = 3;
            //        break;
            //    }
            //    case 4:
            //    {
            //        conditionstate = 4;
            //        break;
            //    }
            //    case 5:
            //    {
            //        conditionstate = 5;
            //        break;
            //    }
            //}
        }
    }
}
