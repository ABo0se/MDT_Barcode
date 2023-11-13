using System;
using System.Collections;
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
    public partial class ManageBorrowedItem : Form
    {
        List<RentResults> TemporaryData;
        public ManageBorrowedItem()
        {
            InitializeComponent();
        }

        public void SearchDatainDB()
        {
            
        }

        private void ManageBorrowedItem_Load(object sender, EventArgs e)
        {

        }
        private bool SearchDatabase(out List<RentResults> mysearchresults)
        {
            string connectionString = "server=127.0.0.1; user=root; database=borrow_returning_system; password=";

            string query = "SELECT * FROM borrowing_info WHERE (BarcodeNumber LIKE @BarcodesearchCriteria OR @BarcodesearchCriteria = 'ค้นหารหัสครุภัณฑ์' OR @BarcodesearchCriteria = '') " +
                                    "AND (Product_Name LIKE @Product_Name OR @Product_Name = 'ค้นหาชื่อผลิตภัณฑ์' OR @Product_Name = '') " +
                                    "AND (Borrower_Name LIKE @Borrower_Name OR @Borrower_Name = 'ค้นหาชื่อผลิตภัณฑ์' OR @Borrower_Name = '') " +
                                    "AND (Status = @StatussearchCriteria OR @StatussearchCriteria = -1) " +
                                    "AND (ITEM_CONDITION = @ConditionsearchCriteria OR @ConditionsearchCriteria = -1)";
            ////////////////////////////////////////////////////
            mysearchresults = null;
            return false;
        }
    }
}
