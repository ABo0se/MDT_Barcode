namespace USB_Barcode_Scanner_Tutorial___C_Sharp.Borrow_Return
{
    partial class ManageBorrowedItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TitlePanel = new System.Windows.Forms.TableLayoutPanel();
            this.Borrower_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BarcodeSearchBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Product_Name_SearchBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.StatusBox = new System.Windows.Forms.ComboBox();
            this.ReturnTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BorrowTime = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Del_Database = new System.Windows.Forms.Button();
            this.ExportPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Import_Excel = new System.Windows.Forms.Button();
            this.Download_Template = new System.Windows.Forms.Button();
            this.Export_Excel = new System.Windows.Forms.Button();
            this.BorrowGridView = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarcodeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Borrow_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Est_Return_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Borrwerer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action_1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Action_2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Action_3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Action_4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.TitlePanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.ExportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BorrowGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitlePanel.AutoSize = true;
            this.TitlePanel.ColumnCount = 6;
            this.TitlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TitlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.TitlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TitlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.TitlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TitlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.TitlePanel.Controls.Add(this.Borrower_Name, 5, 0);
            this.TitlePanel.Controls.Add(this.label2, 4, 0);
            this.TitlePanel.Controls.Add(this.label1, 0, 0);
            this.TitlePanel.Controls.Add(this.BarcodeSearchBox, 1, 0);
            this.TitlePanel.Controls.Add(this.label3, 2, 0);
            this.TitlePanel.Controls.Add(this.Product_Name_SearchBox, 3, 0);
            this.TitlePanel.Location = new System.Drawing.Point(3, 3);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.RowCount = 1;
            this.TitlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TitlePanel.Size = new System.Drawing.Size(1552, 49);
            this.TitlePanel.TabIndex = 17;
            // 
            // Borrower_Name
            // 
            this.Borrower_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Borrower_Name.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Borrower_Name.Location = new System.Drawing.Point(1195, 3);
            this.Borrower_Name.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Borrower_Name.Name = "Borrower_Name";
            this.Borrower_Name.Size = new System.Drawing.Size(353, 43);
            this.Borrower_Name.TabIndex = 19;
            this.Borrower_Name.TextChanged += new System.EventHandler(this.Borrower_Name_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(1050, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 49);
            this.label2.TabIndex = 18;
            this.label2.Text = "ค้นหาชื่อผู้ยืม :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 49);
            this.label1.TabIndex = 2;
            this.label1.Text = "ค้นหาครุภัณฑ์ :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BarcodeSearchBox
            // 
            this.BarcodeSearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BarcodeSearchBox.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.BarcodeSearchBox.Location = new System.Drawing.Point(155, 3);
            this.BarcodeSearchBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BarcodeSearchBox.Name = "BarcodeSearchBox";
            this.BarcodeSearchBox.Size = new System.Drawing.Size(352, 43);
            this.BarcodeSearchBox.TabIndex = 3;
            this.BarcodeSearchBox.TextChanged += new System.EventHandler(this.BarcodeSearchBox_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(515, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 49);
            this.label3.TabIndex = 13;
            this.label3.Text = "ค้นหาชื่อครุภัณฑ์ :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Product_Name_SearchBox
            // 
            this.Product_Name_SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Product_Name_SearchBox.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Product_Name_SearchBox.Location = new System.Drawing.Point(690, 3);
            this.Product_Name_SearchBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Product_Name_SearchBox.Name = "Product_Name_SearchBox";
            this.Product_Name_SearchBox.Size = new System.Drawing.Size(352, 43);
            this.Product_Name_SearchBox.TabIndex = 12;
            this.Product_Name_SearchBox.TextChanged += new System.EventHandler(this.Product_Name_SearchBox_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.StatusBox, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.ReturnTime, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BorrowTime, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 58);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1552, 50);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // StatusBox
            // 
            this.StatusBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusBox.DropDownWidth = 179;
            this.StatusBox.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.StatusBox.FormattingEnabled = true;
            this.StatusBox.Items.AddRange(new object[] {
            "[เลือกสถานะทั้งหมด]",
            "ถูกยืม",
            "เลยกำหนด",
            "พร้อมให้ยืม [มีประวัติ]",
            "ไม่พบข้อมูล"});
            this.StatusBox.Location = new System.Drawing.Point(1143, 3);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(406, 44);
            this.StatusBox.TabIndex = 21;
            this.StatusBox.SelectedIndexChanged += new System.EventHandler(this.StatusBox_SelectedIndexChanged);
            // 
            // ReturnTime
            // 
            this.ReturnTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReturnTime.CalendarFont = new System.Drawing.Font("TH Sarabun New", 16F);
            this.ReturnTime.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.ReturnTime.Location = new System.Drawing.Point(731, 3);
            this.ReturnTime.Name = "ReturnTime";
            this.ReturnTime.Size = new System.Drawing.Size(406, 43);
            this.ReturnTime.TabIndex = 21;
            this.ReturnTime.ValueChanged += new System.EventHandler(this.ReturnTime_ValueChanged);
            this.ReturnTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReturnTime_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(534, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 50);
            this.label4.TabIndex = 21;
            this.label4.Text = "เวลาที่คาดว่าจะคืน  :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(4, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 50);
            this.label5.TabIndex = 2;
            this.label5.Text = "เวลาที่ยืม  :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BorrowTime
            // 
            this.BorrowTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BorrowTime.CalendarFont = new System.Drawing.Font("TH Sarabun New", 16F);
            this.BorrowTime.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.BorrowTime.Location = new System.Drawing.Point(121, 3);
            this.BorrowTime.Name = "BorrowTime";
            this.BorrowTime.Size = new System.Drawing.Size(406, 43);
            this.BorrowTime.TabIndex = 14;
            this.BorrowTime.ValueChanged += new System.EventHandler(this.BorrowTime_ValueChanged);
            this.BorrowTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BorrowTime_KeyDown);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.TitlePanel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1558, 111);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // Del_Database
            // 
            this.Del_Database.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Del_Database.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.Del_Database.ForeColor = System.Drawing.Color.Red;
            this.Del_Database.Location = new System.Drawing.Point(1393, 643);
            this.Del_Database.Name = "Del_Database";
            this.Del_Database.Size = new System.Drawing.Size(177, 50);
            this.Del_Database.TabIndex = 23;
            this.Del_Database.Text = "ลบข้อมูลทั้งหมด";
            this.Del_Database.UseVisualStyleBackColor = true;
            // 
            // ExportPanel
            // 
            this.ExportPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportPanel.AutoSize = true;
            this.ExportPanel.ColumnCount = 3;
            this.ExportPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ExportPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ExportPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ExportPanel.Controls.Add(this.Import_Excel, 1, 0);
            this.ExportPanel.Controls.Add(this.Download_Template, 2, 0);
            this.ExportPanel.Controls.Add(this.Export_Excel, 0, 0);
            this.ExportPanel.Location = new System.Drawing.Point(12, 643);
            this.ExportPanel.Name = "ExportPanel";
            this.ExportPanel.RowCount = 1;
            this.ExportPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ExportPanel.Size = new System.Drawing.Size(858, 56);
            this.ExportPanel.TabIndex = 24;
            // 
            // Import_Excel
            // 
            this.Import_Excel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Import_Excel.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.Import_Excel.Location = new System.Drawing.Point(289, 3);
            this.Import_Excel.Name = "Import_Excel";
            this.Import_Excel.Size = new System.Drawing.Size(280, 50);
            this.Import_Excel.TabIndex = 8;
            this.Import_Excel.Text = "นำข้อมูลเข้าจาก Excel";
            this.Import_Excel.UseVisualStyleBackColor = true;
            // 
            // Download_Template
            // 
            this.Download_Template.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Download_Template.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.Download_Template.Location = new System.Drawing.Point(575, 3);
            this.Download_Template.Name = "Download_Template";
            this.Download_Template.Size = new System.Drawing.Size(280, 50);
            this.Download_Template.TabIndex = 18;
            this.Download_Template.Text = "โหลดตัวอย่างฟอร์ม";
            this.Download_Template.UseVisualStyleBackColor = true;
            // 
            // Export_Excel
            // 
            this.Export_Excel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Export_Excel.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.Export_Excel.Location = new System.Drawing.Point(3, 3);
            this.Export_Excel.Name = "Export_Excel";
            this.Export_Excel.Size = new System.Drawing.Size(280, 50);
            this.Export_Excel.TabIndex = 7;
            this.Export_Excel.Text = "นำข้อมูลออกเป็น Excel";
            this.Export_Excel.UseVisualStyleBackColor = true;
            // 
            // BorrowGridView
            // 
            this.BorrowGridView.AllowUserToAddRows = false;
            this.BorrowGridView.AllowUserToDeleteRows = false;
            this.BorrowGridView.AllowUserToResizeColumns = false;
            this.BorrowGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.BorrowGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BorrowGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.BorrowGridView.ColumnHeadersHeight = 41;
            this.BorrowGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.BorrowGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.BarcodeID,
            this.Product_Name,
            this.Borrow_Date,
            this.Est_Return_Date,
            this.Borrwerer_Name,
            this.Contact,
            this.Status,
            this.Action_1,
            this.Action_2,
            this.Action_3,
            this.Action_4});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BorrowGridView.DefaultCellStyle = dataGridViewCellStyle13;
            this.BorrowGridView.Location = new System.Drawing.Point(12, 127);
            this.BorrowGridView.Name = "BorrowGridView";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BorrowGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.BorrowGridView.RowHeadersVisible = false;
            this.BorrowGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.BorrowGridView.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.BorrowGridView.RowTemplate.Height = 35;
            this.BorrowGridView.Size = new System.Drawing.Size(1558, 510);
            this.BorrowGridView.TabIndex = 25;
            this.BorrowGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BorrowGridView_CellContentClick);
            this.BorrowGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.BorrowGridView_CellFormatting);
            // 
            // Index
            // 
            this.Index.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Index.HeaderText = "ลำดับ";
            this.Index.MinimumWidth = 65;
            this.Index.Name = "Index";
            this.Index.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Index.Width = 65;
            // 
            // BarcodeID
            // 
            this.BarcodeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BarcodeID.HeaderText = "หมายเลขครุภัณฑ์";
            this.BarcodeID.MinimumWidth = 175;
            this.BarcodeID.Name = "BarcodeID";
            this.BarcodeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BarcodeID.Width = 175;
            // 
            // Product_Name
            // 
            this.Product_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product_Name.HeaderText = "ชื่อครุภัณฑ์";
            this.Product_Name.MinimumWidth = 225;
            this.Product_Name.Name = "Product_Name";
            this.Product_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Borrow_Date
            // 
            this.Borrow_Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Borrow_Date.HeaderText = "วันที่ยืมครุภัณฑ์";
            this.Borrow_Date.MinimumWidth = 200;
            this.Borrow_Date.Name = "Borrow_Date";
            this.Borrow_Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Borrow_Date.Width = 200;
            // 
            // Est_Return_Date
            // 
            this.Est_Return_Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Est_Return_Date.HeaderText = "วันที่คาดว่าจะคืนครุภัณฑ์";
            this.Est_Return_Date.MinimumWidth = 200;
            this.Est_Return_Date.Name = "Est_Return_Date";
            this.Est_Return_Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Est_Return_Date.Width = 200;
            // 
            // Borrwerer_Name
            // 
            this.Borrwerer_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Borrwerer_Name.HeaderText = "ชื่อผู้ยืม";
            this.Borrwerer_Name.MinimumWidth = 200;
            this.Borrwerer_Name.Name = "Borrwerer_Name";
            this.Borrwerer_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Borrwerer_Name.Width = 200;
            // 
            // Contact
            // 
            this.Contact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Contact.HeaderText = "ช่องทางการติดต่อ";
            this.Contact.MinimumWidth = 200;
            this.Contact.Name = "Contact";
            this.Contact.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Contact.Width = 200;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Status.HeaderText = "สถานะ";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Status.Width = 125;
            // 
            // Action_1
            // 
            this.Action_1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Action_1.HeaderText = "";
            this.Action_1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Action_1.MinimumWidth = 40;
            this.Action_1.Name = "Action_1";
            this.Action_1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Action_1.Width = 40;
            // 
            // Action_2
            // 
            this.Action_2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Action_2.HeaderText = "";
            this.Action_2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Action_2.MinimumWidth = 40;
            this.Action_2.Name = "Action_2";
            this.Action_2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Action_2.Width = 40;
            // 
            // Action_3
            // 
            this.Action_3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Action_3.HeaderText = "";
            this.Action_3.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Action_3.MinimumWidth = 40;
            this.Action_3.Name = "Action_3";
            this.Action_3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Action_3.Width = 40;
            // 
            // Action_4
            // 
            this.Action_4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Action_4.HeaderText = "";
            this.Action_4.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Action_4.MinimumWidth = 40;
            this.Action_4.Name = "Action_4";
            this.Action_4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Action_4.Width = 40;
            // 
            // ManageBorrowedItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1582, 703);
            this.Controls.Add(this.BorrowGridView);
            this.Controls.Add(this.ExportPanel);
            this.Controls.Add(this.Del_Database);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "ManageBorrowedItem";
            this.Text = "ManageBorrowedItem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageBorrowedItem_FormClosing);
            this.Load += new System.EventHandler(this.ManageBorrowedItem_Load);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ExportPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BorrowGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TitlePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BarcodeSearchBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Product_Name_SearchBox;
        private System.Windows.Forms.TextBox Borrower_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker BorrowTime;
        private System.Windows.Forms.DateTimePicker ReturnTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox StatusBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Del_Database;
        private System.Windows.Forms.TableLayoutPanel ExportPanel;
        private System.Windows.Forms.Button Import_Excel;
        private System.Windows.Forms.Button Download_Template;
        private System.Windows.Forms.Button Export_Excel;
        private System.Windows.Forms.DataGridView BorrowGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarcodeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Borrow_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Est_Return_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Borrwerer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewImageColumn Action_1;
        private System.Windows.Forms.DataGridViewImageColumn Action_2;
        private System.Windows.Forms.DataGridViewImageColumn Action_3;
        private System.Windows.Forms.DataGridViewImageColumn Action_4;
    }
}