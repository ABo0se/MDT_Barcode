using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp.Borrow_Return
{
    public partial class Edit_Borrow_History : Form
    {
        //ThisPageTempData
        Dictionary<int, List<Image>> selectedImages = null;
        int? selectingImage = null;
        int? selectedHistory = null;
        string Barcode = null;
        //
        string defaulttext = "-";
        List<RentHistory> TemporaryData = null;
        public Edit_Borrow_History()
        {
            InitializeComponent();
        }
        public void InitializeForm()
        {
            CheckImageButtonBehavior();
            Barcode = null;
            selectedHistory = null;
            selectingImage = null;
            selectedImages = null;
            TemporaryData = null;
            PageInformation.Text = "0 of 0";
            Borrower_Name_TXT.Text = defaulttext;
            Borrower_Contact_TXT.Text = defaulttext;
            Borrow_Date_TXT.Text = defaulttext;
            EST_Time_Return_TXT.Text = defaulttext;
            ACTUAL_Return_Date_TXT.Text = defaulttext;
            Note_TXT.Text = defaulttext;
        }

        public void AssignText(List<RentHistory> History, string BarcodeNumber) 
        {
            if (History != null)
            {
                if (History.Count > 0)
                {
                    Barcode = BarcodeNumber;
                    selectedImages = new Dictionary<int, List<Image>>();
                    TemporaryData = History;
                    AssignPicture(TemporaryData);
                    CheckPageButtonBehavior();
                    ChangeHistory(0);

                }
                else
                {
                    Barcode = null;
                    TemporaryData = null;
                    MessageBox.Show("ไม่ค้นพบประวัติการยืม");
                    this.Hide();
                }
            }
            else
            {
                Barcode = null;
                TemporaryData = null;
                MessageBox.Show("ไม่ค้นพบประวัติการยืม");
                this.Hide();
            }
        }

        private void Borrow_History_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void Borrow_History_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Prevent the form from closing
                this.Hide();      // Hide the form instead
            }
        }
        private void CheckPageButtonBehavior()
        {
            if (TemporaryData == null)
            {
                Prev.Enabled = false;
                Next.Enabled = false;
                Prev.Hide();
                Next.Hide();
            }
            else if (TemporaryData.Count > 1)
            {
                Prev.Enabled = true;
                Next.Enabled = true;
                Prev.Show();
                Next.Show();
            }
            else
            {
                Prev.Enabled = false;
                Next.Enabled = false;
                Prev.Hide();
                Next.Hide();
            }
        }
        private void CheckImageButtonBehavior()
        {
            if (selectedImages == null)
            {
                Prevpic.Enabled = false;
                Nextpic.Enabled = false;
                Prevpic.Hide();
                Nextpic.Hide();
                return;
            }
            if (selectingImage == null)
            {
                Prevpic.Enabled = false;
                Nextpic.Enabled = false;
                Prevpic.Hide();
                Nextpic.Hide();
                return;
            }
            if (selectedImages[(int)selectedHistory].Count > 1)
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

        private void Next_Click(object sender, EventArgs e)
        {
            if (TemporaryData.Count < 2 || TemporaryData == null) return;
            if ((selectedHistory + 1) < (TemporaryData.Count))
            {
                selectedHistory++;

            }
            else
            {
                selectedHistory = 0;
            }
            ChangeHistory((int)selectedHistory);
        }

        private void ChangeHistory(int myselectedHistory)
        {
            if (TemporaryData != null)
            {
                selectedHistory = myselectedHistory;
                PageInformation.Text = "ครั้งที่ " + (myselectedHistory + 1) + "/" + TemporaryData.Count;
                Borrower_Name_TXT.Text = TemporaryData[myselectedHistory].Borrower_Name;
                Borrower_Contact_TXT.Text = TemporaryData[myselectedHistory].Borrower_Contact;
                Borrow_Date_TXT.Text = TemporaryData[myselectedHistory].InitialBorrowDate.ToString("dd MMMM yyyy HH:mm:ss");
                EST_Time_Return_TXT.Text = TemporaryData[myselectedHistory].EstReturnDate.ToString("dd MMMM yyyy");
                ACTUAL_Return_Date_TXT.Text = TemporaryData[myselectedHistory].ActualReturnDate.ToString("dd MMMM yyyy HH:mm:ss");
                Note_TXT.Text = TemporaryData[myselectedHistory].Note;

                //////////////////////////////////
                if (selectedImages[myselectedHistory] == null)
                {
                    //MessageBox.Show("Null/Nopic");
                    selectingImage = null;
                    CheckImageButtonBehavior();
                    ChangePicture(myselectedHistory, selectingImage);
                    return;
                }
                if (selectedImages[myselectedHistory].Count > 0)
                {
                    //MessageBox.Show("Normal");
                    selectingImage = 0;
                    CheckImageButtonBehavior();
                    ChangePicture(myselectedHistory , selectingImage);
                    pictureBox1.Refresh();
                }
                else
                {
                    //MessageBox.Show("Nopic");
                    selectingImage = null;
                    CheckImageButtonBehavior();
                    ChangePicture(myselectedHistory, selectingImage);
                }
                //////////////////////////////////
            }
        }
        private void AssignPicture(List<RentHistory> Data)
        {
            //SetupImage
            for (int j = 0; j < Data.Count; j++)
            {
                List<string> path = JsonConvert.DeserializeObject<List<string>>(Data[j].ImageData);
                List<string> SHA512 = JsonConvert.DeserializeObject<List<string>>(Data[j].SHA512);
                List<Image> mydecenimage = new List<Image>();
                if (path.Count > 0)
                {
                    for (int i = 0; i < path.Count; i++)
                    {
                        
                        if (File.Exists(path[i]))
                        {
                            Image selectedImage = Image.FromFile(path[i]);
                            if (VerifyImageSHA512Hash(selectedImage, SHA512[i]))
                            {
                                mydecenimage.Add(selectedImage);
                                mydecenimage[i].Tag = "NormalFile";
                                //selectedImages.Add(selectedImage);
                            }
                            else
                            {
                                mydecenimage.Add(Properties.Resources.corruptedfile);
                                mydecenimage[i].Tag = "FileCorrupt";
                                //selectedImages.Add(Properties.Resources.corruptedfile);
                            }
                        }
                        else
                        {
                            mydecenimage.Add(Properties.Resources.corruptedfile);
                            mydecenimage[i].Tag = "FileMissing";
                            //selectedImages.Add(Properties.Resources.filemissing);
                        }
                    }
                    selectedImages.Add(j, mydecenimage);
                }
                else
                {
                    selectedImages.Add(j, mydecenimage);
                }
            }
        }

        private void Prev_Click(object sender, EventArgs e)
        {
            if (TemporaryData.Count < 2 || TemporaryData == null) return;
            if ((selectedHistory - 1) >= 0)
            {
                selectedHistory--;
            }
            else
            {
                selectedHistory = TemporaryData.Count - 1;
            }
            ChangeHistory((int)selectedHistory);
        }
        public bool VerifyImageSHA512Hash(Image image, string storedHash)
        {
            using (SHA512 sha512 = SHA512.Create())
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Jpeg); // You can choose the appropriate format
                stream.Seek(0, SeekOrigin.Begin); // Reset stream position

                byte[] imageBytes = stream.ToArray();
                byte[] computedHash = sha512.ComputeHash(imageBytes);

                // Convert the computed hash to a hexadecimal string
                string computedHashString = BitConverter.ToString(computedHash).Replace("-", "").ToLower();

                // Compare the computed hash with the stored hash
                return computedHashString.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
            }
        }
        private void ChangePicture(int? picperiod, int? pictureindex)
        {
            if (selectingImage != null && picperiod != null && pictureindex != null)
            {
                int picturelist = (int)picperiod;
                int picturepos = (int)pictureindex;
                List<Image> myimage = selectedImages[picturelist];
                pictureBox1.Image = myimage[picturepos];
                PicInformation.Text = (int)(picturepos + 1) + " of " + myimage.Count;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.NoImage;
                PicInformation.Text = "0 of 0";
            }
        }

        private void Nextpic_Click(object sender, EventArgs e)
        {
            if (selectedImages == null || selectingImage == null)
            {
                return;
            }
            if (selectedImages[(int)selectedHistory] == null)
            {
                return;
            }
            if (selectedImages[(int)selectedHistory].Count < 2)
            {
                return;
            }
            if ((selectingImage + 1) < selectedImages[(int)selectedHistory].Count)
            {
                selectingImage++;

            }
            else
            {
                selectingImage = 0;
            }
            ChangePicture(selectedHistory ,selectingImage);
        }

        private void Prevpic_Click(object sender, EventArgs e)
        {
            if (selectedImages == null || selectingImage == null)
            {
               
                return;
            }
            if (selectedImages[(int)selectedHistory] == null)
            {
                
                return;
            }
            if (selectedImages[(int)selectedHistory].Count < 2)
            {
                return;
            }
            if ((selectingImage - 1) >= 0)
            {
                selectingImage--;
            }
            else
            {
                selectingImage = selectedImages[(int)selectedHistory].Count - 1;
            }
            ChangePicture(selectedHistory, selectingImage);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Before we delete picture.
            //Delete existing picture in picture box
            //
            //Your custom logic when the button is clicked
            //Confirmation Box
            if (selectedImages[(int)selectedHistory].Count <= 0) return;
            DialogResult result = MessageBox.Show
            ("ต้องการจะลบภาพนี้หรือไม่?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                // User clicked "Yes," perform the action
                bool isremovingsuccessful = false;
                
                if (selectedImages[(int)selectedHistory].Count > 0)
                {
                    selectedImages[(int)selectedHistory].Remove(selectedImages[(int)selectedHistory][(int)selectingImage]);
                    isremovingsuccessful = true;
                }
                if (isremovingsuccessful)
                {
                    if (selectedImages[(int)selectedHistory].Count <= 0)
                    {
                        //MessageBox.Show("Working");
                        selectingImage = null;
                        ChangePicture((int)selectedHistory ,null);
                    }
                    else if (selectingImage + 1 > selectedImages[(int)selectedHistory].Count)
                    {
                        selectingImage = selectedImages[(int)selectedHistory].Count - 1;
                        ChangePicture((int)selectedHistory, selectingImage);
                    }
                    else
                    {
                        selectingImage = 0;
                        ChangePicture((int)selectedHistory, selectingImage);
                    }
                    CheckImageButtonBehavior();
                }
                else
                {
                    selectingImage = 0;
                    CheckImageButtonBehavior();
                    ChangePicture((int)selectedHistory, 0);
                }
            }
            else
            {
                // User clicked "No" or closed the dialog, do nothing or handle as needed
            }
            ////////////////////////////////////////////////////////////////

        }

        private void Adjust_Picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files (*.*)|*.*";
            openFileDialog.Title = "Select Image(s) to Upload";
            openFileDialog.Multiselect = true; // Allow multiple file selection

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string selectedFilePath in openFileDialog.FileNames)
                {
                    // Load the selected image into the PictureBox
                    System.Drawing.Image selectedImage = System.Drawing.Image.FromFile(selectedFilePath);

                    string outputPath = Path.ChangeExtension(selectedFilePath, "jpg");

                    if (!File.Exists(outputPath))
                    {
                        selectedImage.Save(outputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        // You can add the selected image to a list to store multiple images
                        selectedImage = System.Drawing.Image.FromFile(outputPath);
                    }

                    selectedImages[(int)selectedHistory].Add(selectedImage);
                    selectedImages[(int)selectedHistory][selectedImages[(int)selectedHistory].Count - 1].Tag = "NormalFile";
                    // Optionally, you can display each image in a separate PictureBox
                }
                
                //MessageBox.Show(((int)selectedHistory).ToString() + " " + (selectedImages[(int)selectedHistory].Count - 1).ToString());
                selectingImage = selectedImages[(int)selectedHistory].Count - 1;

                CheckImageButtonBehavior();
                ChangePicture((int)selectedHistory, selectingImage);
            }
        }
        private void Adjust_History_Click(object sender, EventArgs e)
        {
            if (TemporaryData == null)
            {
                MessageBox.Show("ไม่พบประวัติของการยืมครุภัณฑ์นี้");
                return;
            }
            if (selectedImages == null)
            {
                MessageBox.Show("ไม่พบประวัติการเก็บภาพของครุภัณฑ์นี้");
                return;
            }
            if (String.IsNullOrEmpty(Barcode))
            {
                MessageBox.Show("ไม่พบข้อมูลของหมายเลขครุภัณฑ์นี้");
                return;
            }
            // Create reference for image we used.
            string saveDirectory = @"C:\BarcodeDatabaseImage";
            Directory.CreateDirectory(saveDirectory);

            //List<string> oldsavedFilePaths = new List<string>();
            //List<string> oldSHA512hash = new List<string>();



            // Retrieve existing SHA-512 checksums from the database (you need to implement this)

            ////////////////


            /////////////////
            bool isDuplicated = false;

            //List<List<string>> savedFilePaths = new List<List<string>>();
            //List<List<string>> SHA512hash = new List<List<string>>();

            if (selectedImages[(int)selectedHistory] != null)
            {
                //MessageBox.Show(selectedImages.Count.ToString());
                for (int i = 0; i < selectedImages.Count; i++)
                {
                    List<string> paths = new List<string>();
                    List<string> hashs = new List<string>();
                    //MessageBox.Show(selectedImages[i].Count.ToString());
                    if (selectedImages[i].Count <= 0)
                    {
                        TemporaryData[i].ImageData = "[]";
                        TemporaryData[i].SHA512 = "[]";
                        continue;
                    }
                    // Check if the checksum exists in the currently processed data
                    for (int j = 0; j < selectedImages[i].Count; j++)
                    {
                        if (!(selectedImages[i][j].Tag.ToString() == "FileCorrupt" ||
                          selectedImages[i][j].Tag.ToString() == "FileMissing"))
                        {
                            string baseFileName = "image.jpg"; // Base file name
                            string fileName = baseFileName;

                            // Calculate the SHA-512 checksum for the newly saved image
                            string checksum = CalculateSHA512Checksum1pic(selectedImages[i][j]);


                            foreach (string myhash in hashs)
                            {
                                if (checksum == myhash)
                                {
                                    // Set isDuplicated to true if the SHA-512 already exists
                                    isDuplicated = true;

                                    // Optionally, perform some action for duplicates (e.g., show a message)
                                    // Console.WriteLine($"Duplicate file found: {selectedImages[i].Tag.ToString()}");

                                    // Continue to the next iteration of the loop
                                    continue;
                                }
                            }


                            // If it's not a duplicate
                            if (!isDuplicated)
                            {
                                int fileCounter = 1;
                                // Check if the file already exists and generate a unique name if needed
                                while (File.Exists(Path.Combine(saveDirectory, fileName)))
                                {
                                    fileName = $"{Path.GetFileNameWithoutExtension(baseFileName)}_{fileCounter}{Path.GetExtension(baseFileName)}";
                                    fileCounter++;
                                }
                                ///////////////////
                                string filePath = Path.Combine(saveDirectory, fileName);

                                // Save the file
                                selectedImages[i][j].Save(filePath, ImageFormat.Jpeg);
                                paths.Add(filePath);
                                hashs.Add(checksum);
                            }
                        }
                    }
                    string jsonmd5Data = JsonConvert.SerializeObject(hashs, Formatting.Indented);
                    Console.WriteLine(jsonmd5Data);

                    string jsonPicData = JsonConvert.SerializeObject(paths, Formatting.Indented);
                    Console.WriteLine(jsonPicData);

                    TemporaryData[i].ImageData = jsonPicData;
                    TemporaryData[i].SHA512 = jsonmd5Data;
                }
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูลรูปภาพ");
                return;
            }

            string AllData = JsonConvert.SerializeObject(TemporaryData, Formatting.Indented);

            ////////////


            ////////////
            string connectionString = "server=127.0.0.1; user=root; database=borrow_returning_system; password=";
            MySqlConnection mySqlConnection2 = new MySqlConnection(connectionString);

            try
            {
                mySqlConnection2.Open();

                string query = "UPDATE borrowing_info SET " +
               "HistoryTextlog = @HistoryTextlog " +

               "WHERE BarcodeNumber = @BarcodeNumberReplacement";


                //if (PicFilePath == null)
                //{
                //    PicFilePath = "";
                //}

                using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection2))
                {
                    cmd.Parameters.AddWithValue("@HistoryTextlog", AllData);
                    //////////
                    cmd.Parameters.AddWithValue("@BarcodeNumberReplacement", Barcode);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        if (!isDuplicated)
                        {
                            MessageBox.Show("การปรับเปลี่ยนข้อมูลสำเร็จ!");
                        }
                        else
                        {
                            MessageBox.Show("การนำเข้าข้อมูลครุภัณฑ์สำเร็จ ภาพที่ซ้ำกันจะถูกลบออก!");
                        }
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("การปรับเปลี่ยนข้อมูลล้มเหลว");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด : " + ex);
            }
            finally
            {
                mySqlConnection2.Close();
                EditItem EditItemForm = MainMenu.initializedForms.Find(f => f is EditItem) as EditItem;
                if (EditItemForm != null)
                {
                    EditItemForm.Hide();
                }
                ManageQR QRForm = MainMenu.initializedForms.Find(f => f is ManageQR) as ManageQR;
                if (QRForm != null)
                {
                    QRForm.SearchDatainDB();
                }
            }
        }
        List<string> CalculateSHA512Checksum(List<Image> myImages)
        {
            List<string> sha512Values = new List<string>();
            foreach (Image image in myImages)
            {
                if (image != null)
                {
                    using (var sha512 = SHA512.Create())
                    using (var stream = new MemoryStream())
                    {
                        image.Save(stream, ImageFormat.Jpeg); // You can choose the appropriate format
                        stream.Seek(0, SeekOrigin.Begin); // Reset stream position

                        byte[] sha512ChecksumBytes = sha512.ComputeHash(stream);
                        string sha512Checksum = BitConverter.ToString(sha512ChecksumBytes).Replace("-", "").ToLower();
                        sha512Values.Add(sha512Checksum);
                    }
                }
            }
            return sha512Values;
        }
        string CalculateSHA512Checksum1pic(Image image)
        {
            string sha512Values = string.Empty;
            if (image != null)
            {
                using (var sha512 = SHA512.Create())
                using (var stream = new MemoryStream())
                {
                    image.Save(stream, ImageFormat.Jpeg); // You can choose the appropriate format
                    stream.Seek(0, SeekOrigin.Begin); // Reset stream position

                    byte[] sha512ChecksumBytes = sha512.ComputeHash(stream);
                    string sha512Checksum = BitConverter.ToString(sha512ChecksumBytes).Replace("-", "").ToLower();
                    sha512Values = sha512Checksum;
                }
            }
            return sha512Values;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (selectedImages[(int)selectedHistory].Count <= 0)
            {
                return;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.Delete_Picture;
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (selectedImages[(int)selectedHistory].Count <= 0)
            {
                ChangePicture((int)selectedHistory ,null);
            }
            else
            {
                ChangePicture((int)selectedHistory, (int)selectingImage);
            }
        }
    }
}
