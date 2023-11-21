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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp.Borrow_Return
{
    public partial class Borrow_History : Form
    {
        //ThisPageTempData
        List<Image> selectedImages = new List<Image>();
        int? selectingImage = null;
        //
        string defaulttext = "-";
        List<RentHistory> TemporaryData = null;
        int? selectedHistory = null;
        public Borrow_History()
        {
            InitializeComponent();
        }
        public void InitializeForm()
        {
            CheckImageButtonBehavior();
            TemporaryData = null;
            selectedHistory = null;
            PageInformation.Text = "0 of 0";
            Borrower_Name_TXT.Text = defaulttext;
            Borrower_Contact_TXT.Text = defaulttext;
            Borrow_Date_TXT.Text = defaulttext;
            EST_Time_Return_TXT.Text = defaulttext;
            ACTUAL_Return_Date_TXT.Text = defaulttext;
            Note_TXT.Text = defaulttext;
        }

        public void AssignText(List<RentHistory> History) 
        {
            if (History != null)
            {
                if (History.Count > 0)
                {
                    TemporaryData = History;
                    CheckPageButtonBehavior();
                    ChangeHistory(0);
                }
                else
                {
                    TemporaryData = null;
                    MessageBox.Show("ไม่ค้นพบประวัติการยืม");
                    this.Hide();
                }
            }
            else
            {
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
                //
                ////////////////////////////////////
                selectedImages.Clear();
                List<string> path = JsonConvert.DeserializeObject<List<string>>(TemporaryData[myselectedHistory].ImageData);
                List<string> SHA512 = JsonConvert.DeserializeObject<List<string>>(TemporaryData[myselectedHistory].SHA512);
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
    }
}
