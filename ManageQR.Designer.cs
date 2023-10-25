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
            this.BarcodeSearchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BarcodenumberCollector = new System.Windows.Forms.DataGridView();
            this.Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BCNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Search = new System.Windows.Forms.Button();
            this.Export_Excel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BarcodenumberCollector)).BeginInit();
            this.SuspendLayout();
            // 
            // BarcodeSearchBox
            // 
            this.BarcodeSearchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BarcodeSearchBox.Location = new System.Drawing.Point(131, 6);
            this.BarcodeSearchBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BarcodeSearchBox.Name = "BarcodeSearchBox";
            this.BarcodeSearchBox.Size = new System.Drawing.Size(1240, 30);
            this.BarcodeSearchBox.TabIndex = 3;
            this.BarcodeSearchBox.TextChanged += new System.EventHandler(this.BarcodeSearchBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Barcode :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Barcode list";
            // 
            // BarcodenumberCollector
            // 
            this.BarcodenumberCollector.AllowUserToAddRows = false;
            this.BarcodenumberCollector.AllowUserToDeleteRows = false;
            this.BarcodenumberCollector.AllowUserToResizeColumns = false;
            this.BarcodenumberCollector.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("TH Sarabun New", 12F);
            this.BarcodenumberCollector.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.BarcodenumberCollector.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.BarcodenumberCollector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BarcodenumberCollector.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tag,
            this.Time,
            this.BCNumber,
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
            dataGridViewCellStyle3.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BarcodenumberCollector.DefaultCellStyle = dataGridViewCellStyle3;
            this.BarcodenumberCollector.Location = new System.Drawing.Point(12, 73);
            this.BarcodenumberCollector.Name = "BarcodenumberCollector";
            this.BarcodenumberCollector.ReadOnly = true;
            this.BarcodenumberCollector.RowHeadersVisible = false;
            this.BarcodenumberCollector.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("TH Sarabun New", 12F);
            this.BarcodenumberCollector.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.BarcodenumberCollector.RowTemplate.Height = 25;
            this.BarcodenumberCollector.Size = new System.Drawing.Size(1458, 418);
            this.BarcodenumberCollector.TabIndex = 5;
            this.BarcodenumberCollector.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BarcodenumberCollector_CellContentClick);
            this.BarcodenumberCollector.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.BarcodenumberCollector_CellFormatting);
            this.BarcodenumberCollector.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.BarcodenumberCollector_CellPainting);
            // 
            // Tag
            // 
            this.Tag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Tag.HeaderText = "#";
            this.Tag.MinimumWidth = 40;
            this.Tag.Name = "Tag";
            this.Tag.ReadOnly = true;
            this.Tag.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Tag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tag.Width = 40;
            // 
            // Time
            // 
            this.Time.HeaderText = "เวลาที่เพิ่มข้อมูล";
            this.Time.MinimumWidth = 140;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Time.Width = 140;
            // 
            // BCNumber
            // 
            this.BCNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BCNumber.HeaderText = "หมายเลขครุภัณฑ์";
            this.BCNumber.MinimumWidth = 125;
            this.BCNumber.Name = "BCNumber";
            this.BCNumber.ReadOnly = true;
            this.BCNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BCNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Model
            // 
            this.Model.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Model.HeaderText = "ยี่ห้อ";
            this.Model.MinimumWidth = 6;
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            this.Model.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Model.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Brand
            // 
            this.Brand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Brand.HeaderText = "รุ่น";
            this.Brand.MinimumWidth = 6;
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            this.Brand.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Brand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Serial_Number
            // 
            this.Serial_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Serial_Number.HeaderText = "Serial Number";
            this.Serial_Number.MinimumWidth = 6;
            this.Serial_Number.Name = "Serial_Number";
            this.Serial_Number.ReadOnly = true;
            this.Serial_Number.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Serial_Number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price.HeaderText = "ราคา";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Stay_At
            // 
            this.Stay_At.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Stay_At.HeaderText = "ประจำอยู่ที่";
            this.Stay_At.MinimumWidth = 6;
            this.Stay_At.Name = "Stay_At";
            this.Stay_At.ReadOnly = true;
            this.Stay_At.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Stay_At.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Note
            // 
            this.Note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Note.HeaderText = "หมายเหตุ";
            this.Note.MinimumWidth = 6;
            this.Note.Name = "Note";
            this.Note.ReadOnly = true;
            this.Note.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Note.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Status
            // 
            this.Status.HeaderText = "สถานะ";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Status.Width = 125;
            // 
            // Condition
            // 
            this.Condition.HeaderText = "สภาพ";
            this.Condition.MinimumWidth = 6;
            this.Condition.Name = "Condition";
            this.Condition.ReadOnly = true;
            this.Condition.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Condition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Condition.Width = 125;
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
            // Search
            // 
            this.Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Search.Location = new System.Drawing.Point(1378, 6);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(92, 34);
            this.Search.TabIndex = 6;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            // 
            // Export_Excel
            // 
            this.Export_Excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Export_Excel.Location = new System.Drawing.Point(12, 507);
            this.Export_Excel.Name = "Export_Excel";
            this.Export_Excel.Size = new System.Drawing.Size(222, 34);
            this.Export_Excel.TabIndex = 7;
            this.Export_Excel.Text = "Export to excel";
            this.Export_Excel.UseVisualStyleBackColor = true;
            this.Export_Excel.Click += new System.EventHandler(this.Export_Excel_Click);
            // 
            // ManageQR
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1482, 553);
            this.Controls.Add(this.Export_Excel);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.BarcodenumberCollector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BarcodeSearchBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ManageQR";
            this.Text = "Manage your barcode data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageQR_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BarcodenumberCollector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox BarcodeSearchBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView BarcodenumberCollector;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn BCNumber;
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
        private System.Windows.Forms.Button Export_Excel;
    }
}

