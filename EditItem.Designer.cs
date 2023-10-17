namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    partial class EditItem
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Barcode_ID = new System.Windows.Forms.Label();
            this.Product_Name = new System.Windows.Forms.Label();
            this.Created_Time = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.Attendant = new System.Windows.Forms.Label();
            this.Room = new System.Windows.Forms.Label();
            this.Add_Pic = new System.Windows.Forms.Button();
            this.BarcodeID_TB = new System.Windows.Forms.TextBox();
            this.Model_TB = new System.Windows.Forms.TextBox();
            this.Brand_TB = new System.Windows.Forms.TextBox();
            this.Serial_TB = new System.Windows.Forms.TextBox();
            this.Price_TB = new System.Windows.Forms.TextBox();
            this.Room_TB = new System.Windows.Forms.TextBox();
            this.Edit_Item_toDB = new System.Windows.Forms.Button();
            this.Note_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.S_Donthave = new System.Windows.Forms.RadioButton();
            this.S_Have = new System.Windows.Forms.RadioButton();
            this.ConditionBoxEdit = new System.Windows.Forms.ComboBox();
            this.Quality = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.StatsPanel = new System.Windows.Forms.Panel();
            this.S_DonthaveEdit = new System.Windows.Forms.RadioButton();
            this.S_HaveEdit = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.StatsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(92, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(375, 255);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Barcode_ID
            // 
            this.Barcode_ID.AutoSize = true;
            this.Barcode_ID.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Barcode_ID.Location = new System.Drawing.Point(13, 276);
            this.Barcode_ID.Name = "Barcode_ID";
            this.Barcode_ID.Size = new System.Drawing.Size(120, 27);
            this.Barcode_ID.TabIndex = 1;
            this.Barcode_ID.Text = "หมายเลขครุภัณฑ์ : ";
            this.Barcode_ID.Click += new System.EventHandler(this.label1_Click);
            // 
            // Product_Name
            // 
            this.Product_Name.AutoSize = true;
            this.Product_Name.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Product_Name.Location = new System.Drawing.Point(13, 319);
            this.Product_Name.Name = "Product_Name";
            this.Product_Name.Size = new System.Drawing.Size(48, 27);
            this.Product_Name.TabIndex = 2;
            this.Product_Name.Text = "ยี่ห้อ : ";
            // 
            // Created_Time
            // 
            this.Created_Time.AutoSize = true;
            this.Created_Time.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Created_Time.Location = new System.Drawing.Point(13, 362);
            this.Created_Time.Name = "Created_Time";
            this.Created_Time.Size = new System.Drawing.Size(39, 27);
            this.Created_Time.TabIndex = 3;
            this.Created_Time.Text = "รุ่น : ";
            this.Created_Time.Click += new System.EventHandler(this.Created_Time_Click);
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price.Location = new System.Drawing.Point(13, 405);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(110, 27);
            this.Price.TabIndex = 4;
            this.Price.Text = "Serial Number : ";
            // 
            // Attendant
            // 
            this.Attendant.AutoSize = true;
            this.Attendant.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Attendant.Location = new System.Drawing.Point(13, 448);
            this.Attendant.Name = "Attendant";
            this.Attendant.Size = new System.Drawing.Size(50, 27);
            this.Attendant.TabIndex = 5;
            this.Attendant.Text = "ราคา : ";
            // 
            // Room
            // 
            this.Room.AutoSize = true;
            this.Room.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Room.Location = new System.Drawing.Point(13, 491);
            this.Room.Name = "Room";
            this.Room.Size = new System.Drawing.Size(84, 27);
            this.Room.TabIndex = 6;
            this.Room.Text = "ประจำอยู่ที่ : ";
            this.Room.Click += new System.EventHandler(this.Room_Click);
            // 
            // Add_Pic
            // 
            this.Add_Pic.Font = new System.Drawing.Font("TH Sarabun New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Add_Pic.Location = new System.Drawing.Point(12, 660);
            this.Add_Pic.Name = "Add_Pic";
            this.Add_Pic.Size = new System.Drawing.Size(115, 35);
            this.Add_Pic.TabIndex = 7;
            this.Add_Pic.Text = "+ อัพโหลดรูปภาพ";
            this.Add_Pic.UseVisualStyleBackColor = true;
            this.Add_Pic.Click += new System.EventHandler(this.Add_Pic_Click);
            // 
            // BarcodeID_TB
            // 
            this.BarcodeID_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BarcodeID_TB.Location = new System.Drawing.Point(129, 273);
            this.BarcodeID_TB.Name = "BarcodeID_TB";
            this.BarcodeID_TB.ReadOnly = true;
            this.BarcodeID_TB.Size = new System.Drawing.Size(416, 34);
            this.BarcodeID_TB.TabIndex = 8;
            this.BarcodeID_TB.TabStop = false;
            this.BarcodeID_TB.TextChanged += new System.EventHandler(this.BarcodeID_TB_TextChanged);
            // 
            // Model_TB
            // 
            this.Model_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Model_TB.Location = new System.Drawing.Point(55, 316);
            this.Model_TB.Name = "Model_TB";
            this.Model_TB.Size = new System.Drawing.Size(490, 34);
            this.Model_TB.TabIndex = 1;
            this.Model_TB.TextChanged += new System.EventHandler(this.Model_TB_TextChanged);
            // 
            // Brand_TB
            // 
            this.Brand_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Brand_TB.Location = new System.Drawing.Point(45, 359);
            this.Brand_TB.Name = "Brand_TB";
            this.Brand_TB.Size = new System.Drawing.Size(500, 34);
            this.Brand_TB.TabIndex = 2;
            // 
            // Serial_TB
            // 
            this.Serial_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Serial_TB.Location = new System.Drawing.Point(117, 402);
            this.Serial_TB.Name = "Serial_TB";
            this.Serial_TB.Size = new System.Drawing.Size(428, 34);
            this.Serial_TB.TabIndex = 3;
            // 
            // Price_TB
            // 
            this.Price_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Price_TB.Location = new System.Drawing.Point(59, 445);
            this.Price_TB.Name = "Price_TB";
            this.Price_TB.Size = new System.Drawing.Size(486, 34);
            this.Price_TB.TabIndex = 4;
            // 
            // Room_TB
            // 
            this.Room_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Room_TB.Location = new System.Drawing.Point(92, 488);
            this.Room_TB.Name = "Room_TB";
            this.Room_TB.Size = new System.Drawing.Size(453, 34);
            this.Room_TB.TabIndex = 5;
            // 
            // Edit_Item_toDB
            // 
            this.Edit_Item_toDB.Font = new System.Drawing.Font("TH Sarabun New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Edit_Item_toDB.Location = new System.Drawing.Point(430, 660);
            this.Edit_Item_toDB.Name = "Edit_Item_toDB";
            this.Edit_Item_toDB.Size = new System.Drawing.Size(115, 35);
            this.Edit_Item_toDB.TabIndex = 14;
            this.Edit_Item_toDB.Text = "แก้ไขสิ่งของ";
            this.Edit_Item_toDB.UseVisualStyleBackColor = true;
            this.Edit_Item_toDB.Click += new System.EventHandler(this.Add_Item_toDB_Click);
            // 
            // Note_TB
            // 
            this.Note_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Note_TB.Location = new System.Drawing.Point(83, 531);
            this.Note_TB.Name = "Note_TB";
            this.Note_TB.Size = new System.Drawing.Size(462, 34);
            this.Note_TB.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 534);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 27);
            this.label1.TabIndex = 15;
            this.label1.Text = "หมายเหตุ : ";
            // 
            // S_Donthave
            // 
            this.S_Donthave.AutoSize = true;
            this.S_Donthave.Font = new System.Drawing.Font("TH Sarabun New", 12F);
            this.S_Donthave.Location = new System.Drawing.Point(135, -73);
            this.S_Donthave.Name = "S_Donthave";
            this.S_Donthave.Size = new System.Drawing.Size(126, 31);
            this.S_Donthave.TabIndex = 23;
            this.S_Donthave.TabStop = true;
            this.S_Donthave.Text = "ไม่มีให้ตรวจสอบ";
            this.S_Donthave.UseVisualStyleBackColor = true;
            // 
            // S_Have
            // 
            this.S_Have.AutoSize = true;
            this.S_Have.Font = new System.Drawing.Font("TH Sarabun New", 12F);
            this.S_Have.Location = new System.Drawing.Point(18, -73);
            this.S_Have.Name = "S_Have";
            this.S_Have.Size = new System.Drawing.Size(111, 31);
            this.S_Have.TabIndex = 22;
            this.S_Have.TabStop = true;
            this.S_Have.Text = "มีให้ตรวจสอบ";
            this.S_Have.UseVisualStyleBackColor = true;
            // 
            // ConditionBoxEdit
            // 
            this.ConditionBoxEdit.Font = new System.Drawing.Font("TH Sarabun New", 12F);
            this.ConditionBoxEdit.FormattingEnabled = true;
            this.ConditionBoxEdit.Items.AddRange(new object[] {
            "ใช้งานได้",
            "ชำรุดรอซ่อม",
            "สิ้นสภาพ",
            "สูญหาย",
            "จำหน่ายแล้ว",
            "โอนแล้ว",
            "อื่นๆ"});
            this.ConditionBoxEdit.Location = new System.Drawing.Point(76, 615);
            this.ConditionBoxEdit.Name = "ConditionBoxEdit";
            this.ConditionBoxEdit.Size = new System.Drawing.Size(267, 35);
            this.ConditionBoxEdit.TabIndex = 25;
            this.ConditionBoxEdit.SelectedIndexChanged += new System.EventHandler(this.ConditionBox_SelectedIndexChanged);
            // 
            // Quality
            // 
            this.Quality.AutoSize = true;
            this.Quality.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quality.Location = new System.Drawing.Point(16, 618);
            this.Quality.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Quality.Name = "Quality";
            this.Quality.Size = new System.Drawing.Size(55, 27);
            this.Quality.TabIndex = 24;
            this.Quality.Text = "สภาพ : ";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Location = new System.Drawing.Point(16, 576);
            this.Status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(61, 27);
            this.Status.TabIndex = 21;
            this.Status.Text = "สถานะ : ";
            // 
            // StatsPanel
            // 
            this.StatsPanel.Controls.Add(this.S_DonthaveEdit);
            this.StatsPanel.Controls.Add(this.S_HaveEdit);
            this.StatsPanel.Location = new System.Drawing.Point(76, 571);
            this.StatsPanel.Name = "StatsPanel";
            this.StatsPanel.Size = new System.Drawing.Size(262, 38);
            this.StatsPanel.TabIndex = 26;
            // 
            // S_DonthaveEdit
            // 
            this.S_DonthaveEdit.AutoSize = true;
            this.S_DonthaveEdit.Font = new System.Drawing.Font("TH Sarabun New", 12F);
            this.S_DonthaveEdit.Location = new System.Drawing.Point(130, 3);
            this.S_DonthaveEdit.Name = "S_DonthaveEdit";
            this.S_DonthaveEdit.Size = new System.Drawing.Size(126, 31);
            this.S_DonthaveEdit.TabIndex = 18;
            this.S_DonthaveEdit.TabStop = true;
            this.S_DonthaveEdit.Text = "ไม่มีให้ตรวจสอบ";
            this.S_DonthaveEdit.UseVisualStyleBackColor = true;
            this.S_DonthaveEdit.CheckedChanged += new System.EventHandler(this.S_Donthave_CheckedChanged);
            // 
            // S_HaveEdit
            // 
            this.S_HaveEdit.AutoSize = true;
            this.S_HaveEdit.Font = new System.Drawing.Font("TH Sarabun New", 12F);
            this.S_HaveEdit.Location = new System.Drawing.Point(13, 3);
            this.S_HaveEdit.Name = "S_HaveEdit";
            this.S_HaveEdit.Size = new System.Drawing.Size(111, 31);
            this.S_HaveEdit.TabIndex = 17;
            this.S_HaveEdit.TabStop = true;
            this.S_HaveEdit.Text = "มีให้ตรวจสอบ";
            this.S_HaveEdit.UseVisualStyleBackColor = true;
            this.S_HaveEdit.CheckedChanged += new System.EventHandler(this.S_Have_CheckedChanged);
            // 
            // EditItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(557, 703);
            this.Controls.Add(this.StatsPanel);
            this.Controls.Add(this.S_Donthave);
            this.Controls.Add(this.S_Have);
            this.Controls.Add(this.ConditionBoxEdit);
            this.Controls.Add(this.Quality);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Note_TB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Edit_Item_toDB);
            this.Controls.Add(this.Room_TB);
            this.Controls.Add(this.Price_TB);
            this.Controls.Add(this.Serial_TB);
            this.Controls.Add(this.Brand_TB);
            this.Controls.Add(this.Model_TB);
            this.Controls.Add(this.BarcodeID_TB);
            this.Controls.Add(this.Add_Pic);
            this.Controls.Add(this.Room);
            this.Controls.Add(this.Attendant);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.Created_Time);
            this.Controls.Add(this.Product_Name);
            this.Controls.Add(this.Barcode_ID);
            this.Controls.Add(this.pictureBox1);
            this.Name = "EditItem";
            this.Text = "Edit barcode Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing3);
            this.Load += new System.EventHandler(this.AddItemP2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.StatsPanel.ResumeLayout(false);
            this.StatsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Barcode_ID;
        private System.Windows.Forms.Label Product_Name;
        private System.Windows.Forms.Label Created_Time;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label Attendant;
        private System.Windows.Forms.Label Room;
        private System.Windows.Forms.Button Add_Pic;
        private System.Windows.Forms.TextBox BarcodeID_TB;
        private System.Windows.Forms.TextBox Model_TB;
        private System.Windows.Forms.TextBox Brand_TB;
        private System.Windows.Forms.TextBox Serial_TB;
        private System.Windows.Forms.TextBox Price_TB;
        private System.Windows.Forms.TextBox Room_TB;
        private System.Windows.Forms.Button Edit_Item_toDB;
        private System.Windows.Forms.TextBox Note_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton S_Donthave;
        private System.Windows.Forms.RadioButton S_Have;
        private System.Windows.Forms.ComboBox ConditionBoxEdit;
        private System.Windows.Forms.Label Quality;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Panel StatsPanel;
        private System.Windows.Forms.RadioButton S_DonthaveEdit;
        private System.Windows.Forms.RadioButton S_HaveEdit;
    }
}