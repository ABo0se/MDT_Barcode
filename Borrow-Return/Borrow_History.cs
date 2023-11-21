using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp.Borrow_Return
{
    public partial class Borrow_History : Form
    {
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
            PicInformation.Text = "0 of 0";
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
                    CheckImageButtonBehavior();
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
        private void CheckImageButtonBehavior()
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
                PicInformation.Text = (myselectedHistory + 1) + " of " + TemporaryData.Count;
                Borrower_Name_TXT.Text = TemporaryData[myselectedHistory].Borrower_Name;
                Borrower_Contact_TXT.Text = TemporaryData[myselectedHistory].Borrower_Contact;
                Borrow_Date_TXT.Text = TemporaryData[myselectedHistory].InitialBorrowDate.ToString("dd MMMM yyyy HH:mm:ss");
                EST_Time_Return_TXT.Text = TemporaryData[myselectedHistory].EstReturnDate.ToString("dd MMMM yyyy");
                ACTUAL_Return_Date_TXT.Text = TemporaryData[myselectedHistory].ActualReturnDate.ToString("dd MMMM yyyy HH:mm:ss");
                Note_TXT.Text = TemporaryData[myselectedHistory].Note;
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
    }
}
