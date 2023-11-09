﻿using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Security.Cryptography;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class ShowItem : Form
    {
        private MySqlConnection mySqlConnection;
        List<System.Drawing.Image> selectedImages = new List<System.Drawing.Image>();
        int? selectingImage = null;
        //////////////////////
        public ShowItem()
        {
            InitializeComponent();
            mySqlConnection = new MySqlConnection("server=127.0.0.1; user=root; database=barcodedatacollector; password=");
        }

        private void ShowItem_Load(object sender, EventArgs e)
        {
            InitializePage();
        }

        private void ShowForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public void ShowItemDetail(string barcodeText)
        {
            AssignBarcodeText(barcodeText);
        }

        public void AssignBarcodeText(string barcodeText)
        {
            if (TryFetchDataBySerialCode(barcodeText, out SRResults data))
            {
                //DisplayData
                BarcodeID_TXT.Text = data.BarcodeNumber;
                ProductName_TXT.Text = data.Product_Name;
                ModelName_TXT.Text = data.ModelNumber;
                Brand_TXT.Text = data.Brand;
                SN_TXT.Text = data.SerialNum;
                Price_TXT.Text = data.Price;
                Stay_TXT.Text = data.Room;
                Note_TXT.Text = data.Description;
                ////////////////////////////////////
                selectedImages.Clear();
                List<string> path = JsonConvert.DeserializeObject<List<string>>(data.FilePath);
                List<string> SHA512 = JsonConvert.DeserializeObject<List<string>>(data.SHA512);
                if (path.Count > 0)
                {
                    for (int i = 0; i < path.Count; i++)
                    {
                        if (File.Exists(path[i]))
                        {
                            Image selectedImage = Image.FromFile(path[i]);
                            if (VerifyImageSHA512Hash(selectedImage, SHA512[i]))
                            {
                                selectedImages.Add(selectedImage);
                            }
                            else
                            {
                                selectedImages.Add(Properties.Resources.corruptedfile);
                            }
                        }
                        else
                        {
                            selectedImages.Add(Properties.Resources.filemissing);
                        }
                    }
                    CheckImageButtonBehavior();
                    ChangePicture(0);
                    pictureBox1.Refresh();
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.NoImage;
                }
                ////////////////////////////////////
                int statusX, conditionX;
                statusX = data.Status;
                conditionX = data.Condition;
                switch (statusX)
                {
                    case -1:
                    {
                        Status_TXT.Text = "ไม่พบข้อมูล";
                        break;
                    }
                    case 0:
                    {
                        Status_TXT.Text = "มีให้ตรวจสอบ";
                        break;
                    }
                    case 1:
                    {
                        Status_TXT.Text = "มีให้ตรวจสอบ";
                        break;
                    }
                }
                switch (conditionX)
                {
                    case -1:
                        {
                            Condition_TXT.Text = "ไม่พบข้อมูล";
                            break;
                        }
                    case 0:
                        {
                            Condition_TXT.Text = "ใช้งานได้";
                            break;
                        }
                    case 1:
                        {
                            Condition_TXT.Text = "ชำรุดรอซ่อม";
                            break;
                        }
                    case 2:
                        {
                            Condition_TXT.Text = "สิ้นสภาพ";
                            break;
                        }
                    case 3:
                        {
                            Condition_TXT.Text = "สูญหาย";
                            break;
                        }
                    case 4:
                        {
                            Condition_TXT.Text = "จำหน่ายแล้ว";
                            break;
                        }
                    case 5:
                        {
                            Condition_TXT.Text = "โอนแล้ว";
                            break;
                        }
                    case 6:
                        {
                            Condition_TXT.Text = "อื่นๆ";
                            break;
                        }
                }
                ////////////////////////////////////
            }
        }

        private bool TryFetchDataBySerialCode(string serialCode, out SRResults data)
        {
            data = null;

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
                            data = new SRResults
                            {
                                Date = reader.GetDateTime("Time"),
                                Product_Name = reader["Product_Name"].ToString(),
                                BarcodeNumber = reader["BarcodeNumber"].ToString(),
                                ModelNumber = reader["Model_Name"].ToString(),
                                Brand = reader["Brand"].ToString(),
                                SerialNum = reader["Serial_Number"].ToString(),
                                Price = reader["Price"].ToString(),
                                Room = reader["Room"].ToString(),
                                FilePath = reader["ImageData"].ToString(),
                                SHA512 = reader["MD5_ImageValidityChecksum"].ToString(),
                                Description = reader["Note"].ToString(),
                                Status = int.Parse(reader["Status"].ToString()),
                                Condition = int.Parse(reader["ITEM_CONDITION"].ToString())
                            };
                            return true;
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
            return false;
        }

    

        public void InitializePage()
        {
            BarcodeID_TXT.Text = ProductName_TXT.Text = ModelName_TXT.Text = Brand_TXT.Text = 
            SN_TXT.Text = Price_TXT.Text = Stay_TXT.Text = Note_TXT.Text = Status_TXT.Text = Condition_TXT.Text = string.Empty;
            if (selectedImages != null)
            {
                selectedImages.Clear();
            }
            else
            {
                selectedImages = new List<System.Drawing.Image>();
            }
            ChangePicture(null);
            CheckImageButtonBehavior();
        }

        // Other event handler methods...

        private void BarcodeID_TXT_Click(object sender, EventArgs e)
        {
            // You can add logic here if needed
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CheckImageButtonBehavior()
        {
            if (selectedImages != null && selectedImages.Count > 1)
            {
                Prevpic.Enabled = true;
                Nextpic.Enabled = true;
                Prevpic.Show();
                Nextpic.Show();
            }
            else
            {
                Prevpic.Enabled = false;
                Nextpic.Enabled = false;
                Prevpic.Hide();
                Nextpic.Hide();
            }
        }
        private void ChangePicture(int? pictureindex)
        {
            selectingImage = pictureindex;
            if (selectingImage != null)
            {
                pictureBox1.Image = selectedImages[(int)selectingImage];
                PicInformation.Text = (int)(selectingImage + 1) + " of " + selectedImages.Count;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.NoImage;
                PicInformation.Text = "0 of 0";
            }
        }
        private void Nextpic_Click(object sender, EventArgs e)
        {
            if (selectedImages.Count < 2) return;
            if ((selectingImage + 1) < (selectedImages.Count))
            {
                selectingImage++;

            }
            else
            {
                selectingImage = 0;
            }
            ChangePicture((int)selectingImage);
        }

        private void Prevpic_Click(object sender, EventArgs e)
        {
            if (selectedImages.Count < 2) return;
            if ((selectingImage - 1) >= 0)
            {
                selectingImage--;
            }
            else
            {
                selectingImage = selectedImages.Count - 1;
            }
            ChangePicture((int)selectingImage);
        }
        public bool VerifyImageSHA512Hash(Image image, string storedHash)
        {
            using (SHA512 sha512 = SHA512.Create())
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Png); // You can choose the appropriate format
                stream.Seek(0, SeekOrigin.Begin); // Reset stream position

                byte[] imageBytes = stream.ToArray();
                byte[] computedHash = sha512.ComputeHash(imageBytes);

                // Convert the computed hash to a hexadecimal string
                string computedHashString = BitConverter.ToString(computedHash).Replace("-", "").ToLower();

                // Compare the computed hash with the stored hash
                return computedHashString.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
            }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}