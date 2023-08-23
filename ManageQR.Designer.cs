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
            this.BarcodeSearchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BarcodenumberCollector = new System.Windows.Forms.DataGridView();
            this.Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BCNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BarcodenumberCollector)).BeginInit();
            this.SuspendLayout();
            // 
            // BarcodeSearchBox
            // 
            this.BarcodeSearchBox.Location = new System.Drawing.Point(118, 6);
            this.BarcodeSearchBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BarcodeSearchBox.Name = "BarcodeSearchBox";
            this.BarcodeSearchBox.Size = new System.Drawing.Size(822, 23);
            this.BarcodeSearchBox.TabIndex = 3;
            this.BarcodeSearchBox.TextChanged += new System.EventHandler(this.BarcodeSearchBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Barcode :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Historical Scanned Barcode";
            // 
            // BarcodenumberCollector
            // 
            this.BarcodenumberCollector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BarcodenumberCollector.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tag,
            this.Time,
            this.BCNumber});
            this.BarcodenumberCollector.Location = new System.Drawing.Point(17, 71);
            this.BarcodenumberCollector.Name = "BarcodenumberCollector";
            this.BarcodenumberCollector.ReadOnly = true;
            this.BarcodenumberCollector.RowHeadersVisible = false;
            this.BarcodenumberCollector.RowHeadersWidth = 51;
            this.BarcodenumberCollector.RowTemplate.Height = 25;
            this.BarcodenumberCollector.Size = new System.Drawing.Size(1023, 399);
            this.BarcodenumberCollector.TabIndex = 5;
            // 
            // Tag
            // 
            this.Tag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tag.FillWeight = 32.43243F;
            this.Tag.HeaderText = "#";
            this.Tag.MinimumWidth = 6;
            this.Tag.Name = "Tag";
            this.Tag.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 150;
            // 
            // BCNumber
            // 
            this.BCNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BCNumber.FillWeight = 167.5676F;
            this.BCNumber.HeaderText = "BarcodeNumber";
            this.BCNumber.MinimumWidth = 6;
            this.BCNumber.Name = "BCNumber";
            this.BCNumber.ReadOnly = true;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(948, 7);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(92, 23);
            this.Search.TabIndex = 6;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Func);
            // 
            // ManageQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 482);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.BarcodenumberCollector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BarcodeSearchBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ManageQR";
            this.Text = "USB Barcode Scanner Tutorial";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn BCNumber;
        private System.Windows.Forms.Button Search;
    }
}

