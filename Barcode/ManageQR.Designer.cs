namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    partial class ManageQR
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BarcodeSearchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Export_Excel = new System.Windows.Forms.Button();
            this.Import_Excel = new System.Windows.Forms.Button();
            this.StatusSearchBox = new System.Windows.Forms.ComboBox();
            this.RoomSearchBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Del_Database = new System.Windows.Forms.Button();
            this.ExportPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Download_Template = new System.Windows.Forms.Button();
            this.TitlePanel = new System.Windows.Forms.TableLayoutPanel();
            this.ConditionBox = new System.Windows.Forms.ComboBox();
            this.BarcodenumberCollector = new System.Windows.Forms.DataGridView();
            this.Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stay_At = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action_Search = new System.Windows.Forms.DataGridViewImageColumn();
            this.Action_Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Action_Remove = new System.Windows.Forms.DataGridViewImageColumn();
            this.ExportPanel.SuspendLayout();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarcodenumberCollector)).BeginInit();
            this.SuspendLayout();
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
            this.BarcodeSearchBox.Size = new System.Drawing.Size(621, 43);
            this.BarcodeSearchBox.TabIndex = 3;
            this.BarcodeSearchBox.TextChanged += new System.EventHandler(this.BarcodeSearchBox_TextChanged);
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
            this.label1.Size = new System.Drawing.Size(143, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "ค้นหาครุภัณฑ์ :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(10, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 36);
            this.label2.TabIndex = 4;
            this.label2.Text = "รายการครุภัณฑ์";
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
            this.Export_Excel.Click += new System.EventHandler(this.Export_Excel_Click);
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
            this.Import_Excel.Click += new System.EventHandler(this.Import_Excel_Click);
            // 
            // StatusSearchBox
            // 
            this.StatusSearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusSearchBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusSearchBox.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.StatusSearchBox.FormattingEnabled = true;
            this.StatusSearchBox.Items.AddRange(new object[] {
            "[เลือกสถานะทั้งหมด]",
            "มีให้ตรวจสอบ",
            "ไม่มีให้ตรวจสอบ",
            "ไม่พบข้อมูล"});
            this.StatusSearchBox.Location = new System.Drawing.Point(1151, 3);
            this.StatusSearchBox.Name = "StatusSearchBox";
            this.StatusSearchBox.Size = new System.Drawing.Size(201, 44);
            this.StatusSearchBox.TabIndex = 11;
            this.StatusSearchBox.SelectedIndexChanged += new System.EventHandler(this.StatusSearchBox_SelectedIndexChanged);
            // 
            // RoomSearchBox
            // 
            this.RoomSearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RoomSearchBox.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.RoomSearchBox.Location = new System.Drawing.Point(904, 3);
            this.RoomSearchBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RoomSearchBox.Name = "RoomSearchBox";
            this.RoomSearchBox.Size = new System.Drawing.Size(240, 43);
            this.RoomSearchBox.TabIndex = 12;
            this.RoomSearchBox.TextChanged += new System.EventHandler(this.RoomSearchBox_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(784, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 50);
            this.label3.TabIndex = 13;
            this.label3.Text = "ค้นหาห้อง :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Del_Database
            // 
            this.Del_Database.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Del_Database.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.Del_Database.ForeColor = System.Drawing.Color.Red;
            this.Del_Database.Location = new System.Drawing.Point(1393, 492);
            this.Del_Database.Name = "Del_Database";
            this.Del_Database.Size = new System.Drawing.Size(177, 50);
            this.Del_Database.TabIndex = 14;
            this.Del_Database.Text = "ลบข้อมูลทั้งหมด";
            this.Del_Database.UseVisualStyleBackColor = true;
            this.Del_Database.Click += new System.EventHandler(this.Del_Database_Click);
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
            this.ExportPanel.Location = new System.Drawing.Point(16, 489);
            this.ExportPanel.Name = "ExportPanel";
            this.ExportPanel.RowCount = 1;
            this.ExportPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ExportPanel.Size = new System.Drawing.Size(858, 56);
            this.ExportPanel.TabIndex = 15;
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
            this.Download_Template.Click += new System.EventHandler(this.Download_Template_Click);
            // 
            // TitlePanel
            // 
            this.TitlePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitlePanel.AutoSize = true;
            this.TitlePanel.ColumnCount = 6;
            this.TitlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TitlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.71796F));
            this.TitlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TitlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.23076F));
            this.TitlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.02564F));
            this.TitlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.02564F));
            this.TitlePanel.Controls.Add(this.label1, 0, 0);
            this.TitlePanel.Controls.Add(this.BarcodeSearchBox, 1, 0);
            this.TitlePanel.Controls.Add(this.label3, 2, 0);
            this.TitlePanel.Controls.Add(this.RoomSearchBox, 3, 0);
            this.TitlePanel.Controls.Add(this.StatusSearchBox, 4, 0);
            this.TitlePanel.Controls.Add(this.ConditionBox, 5, 0);
            this.TitlePanel.Location = new System.Drawing.Point(6, 12);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.RowCount = 1;
            this.TitlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TitlePanel.Size = new System.Drawing.Size(1564, 50);
            this.TitlePanel.TabIndex = 16;
            // 
            // ConditionBox
            // 
            this.ConditionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConditionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConditionBox.DropDownWidth = 179;
            this.ConditionBox.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.ConditionBox.FormattingEnabled = true;
            this.ConditionBox.Items.AddRange(new object[] {
            "[เลือกสภาพทั้งหมด]",
            "ใช้งานได้",
            "ชำรุดรอซ่อม",
            "สิ้นสภาพ",
            "สูญหาย",
            "จำหน่ายแล้ว",
            "โอนแล้ว",
            "อื่นๆ",
            "ไม่พบข้อมูล"});
            this.ConditionBox.Location = new System.Drawing.Point(1358, 3);
            this.ConditionBox.Name = "ConditionBox";
            this.ConditionBox.Size = new System.Drawing.Size(203, 44);
            this.ConditionBox.TabIndex = 10;
            this.ConditionBox.SelectedIndexChanged += new System.EventHandler(this.ConditionBox_SelectedIndexChanged);
            // 
            // BarcodenumberCollector
            // 
            this.BarcodenumberCollector.AllowUserToAddRows = false;
            this.BarcodenumberCollector.AllowUserToDeleteRows = false;
            this.BarcodenumberCollector.AllowUserToResizeColumns = false;
            this.BarcodenumberCollector.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.BarcodenumberCollector.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.BarcodenumberCollector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BarcodenumberCollector.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.BarcodenumberCollector.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.BarcodenumberCollector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BarcodenumberCollector.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tag,
            this.Time,
            this.ModelName,
            this.Model,
            this.Brand,
            this.Serial_Number,
            this.Price,
            this.Stay_At,
            this.Note,
            this.Status,
            this.Condition,
            this.Action_Search,
            this.Action_Edit,
            this.Action_Remove});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BarcodenumberCollector.DefaultCellStyle = dataGridViewCellStyle3;
            this.BarcodenumberCollector.EnableHeadersVisualStyles = false;
            this.BarcodenumberCollector.Location = new System.Drawing.Point(16, 95);
            this.BarcodenumberCollector.Name = "BarcodenumberCollector";
            this.BarcodenumberCollector.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BarcodenumberCollector.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.BarcodenumberCollector.RowHeadersVisible = false;
            this.BarcodenumberCollector.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.BarcodenumberCollector.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.BarcodenumberCollector.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.BarcodenumberCollector.RowTemplate.Height = 35;
            this.BarcodenumberCollector.Size = new System.Drawing.Size(1554, 387);
            this.BarcodenumberCollector.TabIndex = 5;
            this.BarcodenumberCollector.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BarcodenumberCollector_CellContentClick);
            this.BarcodenumberCollector.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.BarcodenumberCollector_CellFormatting);
            this.BarcodenumberCollector.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.BarcodenumberCollector_CellPainting);
            // 
            // Tag
            // 
            this.Tag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Tag.HeaderText = "ลำดับ";
            this.Tag.MinimumWidth = 65;
            this.Tag.Name = "Tag";
            this.Tag.ReadOnly = true;
            this.Tag.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Tag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tag.Width = 65;
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Time.HeaderText = "ชื่อครุภัณฑ์";
            this.Time.MinimumWidth = 200;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Time.Width = 200;
            // 
            // ModelName
            // 
            this.ModelName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ModelName.HeaderText = "หมายเลขครุภัณฑ์";
            this.ModelName.MinimumWidth = 130;
            this.ModelName.Name = "ModelName";
            this.ModelName.ReadOnly = true;
            this.ModelName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ModelName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Model
            // 
            this.Model.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Model.HeaderText = "ยี่ห้อ";
            this.Model.MinimumWidth = 75;
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            this.Model.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Model.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Brand
            // 
            this.Brand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Brand.HeaderText = "รุ่น";
            this.Brand.MinimumWidth = 75;
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            this.Brand.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Brand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Serial_Number
            // 
            this.Serial_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Serial_Number.HeaderText = "S/N";
            this.Serial_Number.MinimumWidth = 75;
            this.Serial_Number.Name = "Serial_Number";
            this.Serial_Number.ReadOnly = true;
            this.Serial_Number.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Serial_Number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price.HeaderText = "ราคา";
            this.Price.MinimumWidth = 75;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Stay_At
            // 
            this.Stay_At.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Stay_At.HeaderText = "ประจำอยู่ที่";
            this.Stay_At.MinimumWidth = 75;
            this.Stay_At.Name = "Stay_At";
            this.Stay_At.ReadOnly = true;
            this.Stay_At.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Stay_At.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Note
            // 
            this.Note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Note.HeaderText = "หมายเหตุ";
            this.Note.MinimumWidth = 75;
            this.Note.Name = "Note";
            this.Note.ReadOnly = true;
            this.Note.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Note.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.HeaderText = "สถานะ";
            this.Status.MinimumWidth = 75;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Condition
            // 
            this.Condition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Condition.HeaderText = "สภาพ";
            this.Condition.MinimumWidth = 75;
            this.Condition.Name = "Condition";
            this.Condition.ReadOnly = true;
            this.Condition.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Condition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Action_Search
            // 
            this.Action_Search.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Action_Search.HeaderText = "";
            this.Action_Search.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Action_Search.MinimumWidth = 45;
            this.Action_Search.Name = "Action_Search";
            this.Action_Search.ReadOnly = true;
            this.Action_Search.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Action_Search.Width = 45;
            // 
            // Action_Edit
            // 
            this.Action_Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Action_Edit.HeaderText = "";
            this.Action_Edit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Action_Edit.MinimumWidth = 45;
            this.Action_Edit.Name = "Action_Edit";
            this.Action_Edit.ReadOnly = true;
            this.Action_Edit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Action_Edit.Width = 45;
            // 
            // Action_Remove
            // 
            this.Action_Remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Action_Remove.HeaderText = "";
            this.Action_Remove.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Action_Remove.MinimumWidth = 45;
            this.Action_Remove.Name = "Action_Remove";
            this.Action_Remove.ReadOnly = true;
            this.Action_Remove.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Action_Remove.Width = 45;
            // 
            // ManageQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1582, 553);
            this.Controls.Add(this.Del_Database);
            this.Controls.Add(this.BarcodenumberCollector);
            this.Controls.Add(this.TitlePanel);
            this.Controls.Add(this.ExportPanel);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "ManageQR";
            this.Text = "จัดการครุภัณฑ์";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageQR_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ExportPanel.ResumeLayout(false);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarcodenumberCollector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox BarcodeSearchBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Export_Excel;
        private System.Windows.Forms.Button Import_Excel;
        private System.Windows.Forms.ComboBox StatusSearchBox;
        private System.Windows.Forms.TextBox RoomSearchBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Del_Database;
        private System.Windows.Forms.TableLayoutPanel ExportPanel;
        private System.Windows.Forms.TableLayoutPanel TitlePanel;
        private System.Windows.Forms.ComboBox ConditionBox;
        private System.Windows.Forms.Button Download_Template;
        private System.Windows.Forms.DataGridView BarcodenumberCollector;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stay_At;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condition;
        private System.Windows.Forms.DataGridViewImageColumn Action_Search;
        private System.Windows.Forms.DataGridViewImageColumn Action_Edit;
        private System.Windows.Forms.DataGridViewImageColumn Action_Remove;
    }
}

