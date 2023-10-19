namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    partial class AddItemP2
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
            this.Add_Item_toDB = new System.Windows.Forms.Button();
            this.Note_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.Quality = new System.Windows.Forms.Label();
            this.ConditionBox = new System.Windows.Forms.ComboBox();
            this.S_Have = new System.Windows.Forms.RadioButton();
            this.S_Donthave = new System.Windows.Forms.RadioButton();
            this.StatsPanel = new System.Windows.Forms.Panel();
            this.Prevpic = new System.Windows.Forms.Button();
            this.Nextpic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.StatsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(89, 17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.Barcode_ID.Location = new System.Drawing.Point(8, 285);
            this.Barcode_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.Product_Name.Location = new System.Drawing.Point(9, 325);
            this.Product_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Product_Name.Name = "Product_Name";
            this.Product_Name.Size = new System.Drawing.Size(48, 27);
            this.Product_Name.TabIndex = 2;
            this.Product_Name.Text = "ยี่ห้อ : ";
            // 
            // Created_Time
            // 
            this.Created_Time.AutoSize = true;
            this.Created_Time.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Created_Time.Location = new System.Drawing.Point(8, 365);
            this.Created_Time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
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
            this.Price.Location = new System.Drawing.Point(8, 405);
            this.Price.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(110, 27);
            this.Price.TabIndex = 4;
            this.Price.Text = "Serial Number : ";
            // 
            // Attendant
            // 
            this.Attendant.AutoSize = true;
            this.Attendant.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Attendant.Location = new System.Drawing.Point(10, 445);
            this.Attendant.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Attendant.Name = "Attendant";
            this.Attendant.Size = new System.Drawing.Size(50, 27);
            this.Attendant.TabIndex = 5;
            this.Attendant.Text = "ราคา : ";
            // 
            // Room
            // 
            this.Room.AutoSize = true;
            this.Room.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Room.Location = new System.Drawing.Point(8, 486);
            this.Room.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Room.Name = "Room";
            this.Room.Size = new System.Drawing.Size(84, 27);
            this.Room.TabIndex = 6;
            this.Room.Text = "ประจำอยู่ที่ : ";
            this.Room.Click += new System.EventHandler(this.Room_Click);
            // 
            // Add_Pic
            // 
            this.Add_Pic.Font = new System.Drawing.Font("TH Sarabun New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Add_Pic.Location = new System.Drawing.Point(17, 651);
            this.Add_Pic.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Add_Pic.Name = "Add_Pic";
            this.Add_Pic.Size = new System.Drawing.Size(116, 40);
            this.Add_Pic.TabIndex = 10;
            this.Add_Pic.Text = "+ อัพโหลดรูปภาพ";
            this.Add_Pic.UseVisualStyleBackColor = true;
            this.Add_Pic.Click += new System.EventHandler(this.Add_Pic_Click);
            // 
            // BarcodeID_TB
            // 
            this.BarcodeID_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BarcodeID_TB.Location = new System.Drawing.Point(124, 282);
            this.BarcodeID_TB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BarcodeID_TB.Name = "BarcodeID_TB";
            this.BarcodeID_TB.Size = new System.Drawing.Size(422, 34);
            this.BarcodeID_TB.TabIndex = 1;
            this.BarcodeID_TB.TextChanged += new System.EventHandler(this.BarcodeID_TB_TextChanged);
            // 
            // Model_TB
            // 
            this.Model_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Model_TB.Location = new System.Drawing.Point(54, 322);
            this.Model_TB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Model_TB.Name = "Model_TB";
            this.Model_TB.Size = new System.Drawing.Size(493, 34);
            this.Model_TB.TabIndex = 2;
            // 
            // Brand_TB
            // 
            this.Brand_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Brand_TB.Location = new System.Drawing.Point(43, 362);
            this.Brand_TB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Brand_TB.Name = "Brand_TB";
            this.Brand_TB.Size = new System.Drawing.Size(503, 34);
            this.Brand_TB.TabIndex = 3;
            // 
            // Serial_TB
            // 
            this.Serial_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Serial_TB.Location = new System.Drawing.Point(115, 402);
            this.Serial_TB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Serial_TB.Name = "Serial_TB";
            this.Serial_TB.Size = new System.Drawing.Size(431, 34);
            this.Serial_TB.TabIndex = 4;
            // 
            // Price_TB
            // 
            this.Price_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Price_TB.Location = new System.Drawing.Point(54, 442);
            this.Price_TB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Price_TB.Name = "Price_TB";
            this.Price_TB.Size = new System.Drawing.Size(494, 34);
            this.Price_TB.TabIndex = 5;
            // 
            // Room_TB
            // 
            this.Room_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Room_TB.Location = new System.Drawing.Point(88, 482);
            this.Room_TB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Room_TB.Name = "Room_TB";
            this.Room_TB.Size = new System.Drawing.Size(458, 34);
            this.Room_TB.TabIndex = 6;
            // 
            // Add_Item_toDB
            // 
            this.Add_Item_toDB.Font = new System.Drawing.Font("TH Sarabun New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Add_Item_toDB.Location = new System.Drawing.Point(431, 651);
            this.Add_Item_toDB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Add_Item_toDB.Name = "Add_Item_toDB";
            this.Add_Item_toDB.Size = new System.Drawing.Size(117, 40);
            this.Add_Item_toDB.TabIndex = 11;
            this.Add_Item_toDB.Text = "เพิ่มสิ่งของ";
            this.Add_Item_toDB.UseVisualStyleBackColor = true;
            this.Add_Item_toDB.Click += new System.EventHandler(this.Add_Item_toDB_Click);
            // 
            // Note_TB
            // 
            this.Note_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Note_TB.Location = new System.Drawing.Point(82, 522);
            this.Note_TB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Note_TB.Name = "Note_TB";
            this.Note_TB.Size = new System.Drawing.Size(464, 34);
            this.Note_TB.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 525);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 27);
            this.label1.TabIndex = 15;
            this.label1.Text = "หมายเหตุ : ";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Location = new System.Drawing.Point(9, 567);
            this.Status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(61, 27);
            this.Status.TabIndex = 16;
            this.Status.Text = "สถานะ : ";
            // 
            // Quality
            // 
            this.Quality.AutoSize = true;
            this.Quality.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quality.Location = new System.Drawing.Point(9, 609);
            this.Quality.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Quality.Name = "Quality";
            this.Quality.Size = new System.Drawing.Size(55, 27);
            this.Quality.TabIndex = 19;
            this.Quality.Text = "สภาพ : ";
            // 
            // ConditionBox
            // 
            this.ConditionBox.Font = new System.Drawing.Font("TH Sarabun New", 12F);
            this.ConditionBox.FormattingEnabled = true;
            this.ConditionBox.Items.AddRange(new object[] {
            "ใช้งานได้",
            "ชำรุดรอซ่อม",
            "สิ้นสภาพ",
            "สูญหาย",
            "จำหน่ายแล้ว",
            "โอนแล้ว",
            "อื่นๆ"});
            this.ConditionBox.Location = new System.Drawing.Point(64, 606);
            this.ConditionBox.Name = "ConditionBox";
            this.ConditionBox.Size = new System.Drawing.Size(267, 35);
            this.ConditionBox.TabIndex = 9;
            this.ConditionBox.SelectedIndexChanged += new System.EventHandler(this.ConditionBox_SelectedIndexChanged);
            // 
            // S_Have
            // 
            this.S_Have.AutoSize = true;
            this.S_Have.Font = new System.Drawing.Font("TH Sarabun New", 12F);
            this.S_Have.Location = new System.Drawing.Point(13, 4);
            this.S_Have.Name = "S_Have";
            this.S_Have.Size = new System.Drawing.Size(111, 31);
            this.S_Have.TabIndex = 17;
            this.S_Have.TabStop = true;
            this.S_Have.Text = "มีให้ตรวจสอบ";
            this.S_Have.UseVisualStyleBackColor = true;
            this.S_Have.CheckedChanged += new System.EventHandler(this.S_Have_CheckedChanged);
            // 
            // S_Donthave
            // 
            this.S_Donthave.AutoSize = true;
            this.S_Donthave.Font = new System.Drawing.Font("TH Sarabun New", 12F);
            this.S_Donthave.Location = new System.Drawing.Point(130, 4);
            this.S_Donthave.Name = "S_Donthave";
            this.S_Donthave.Size = new System.Drawing.Size(126, 31);
            this.S_Donthave.TabIndex = 18;
            this.S_Donthave.TabStop = true;
            this.S_Donthave.Text = "ไม่มีให้ตรวจสอบ";
            this.S_Donthave.UseVisualStyleBackColor = true;
            this.S_Donthave.CheckedChanged += new System.EventHandler(this.S_Donthave_CheckedChanged);
            // 
            // StatsPanel
            // 
            this.StatsPanel.Controls.Add(this.S_Donthave);
            this.StatsPanel.Controls.Add(this.S_Have);
            this.StatsPanel.Location = new System.Drawing.Point(69, 562);
            this.StatsPanel.Name = "StatsPanel";
            this.StatsPanel.Size = new System.Drawing.Size(262, 38);
            this.StatsPanel.TabIndex = 8;
            // 
            // Prevpic
            // 
            this.Prevpic.BackColor = System.Drawing.SystemColors.Control;
            this.Prevpic.BackgroundImage = global::USB_Barcode_Scanner_Tutorial___C_Sharp.Properties.Resources.Previous;
            this.Prevpic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Prevpic.Location = new System.Drawing.Point(12, 105);
            this.Prevpic.Name = "Prevpic";
            this.Prevpic.Size = new System.Drawing.Size(65, 80);
            this.Prevpic.TabIndex = 22;
            this.Prevpic.TabStop = false;
            this.Prevpic.UseVisualStyleBackColor = false;
            this.Prevpic.Click += new System.EventHandler(this.Prevpic_Click);
            // 
            // Nextpic
            // 
            this.Nextpic.BackColor = System.Drawing.SystemColors.Control;
            this.Nextpic.BackgroundImage = global::USB_Barcode_Scanner_Tutorial___C_Sharp.Properties.Resources.Next;
            this.Nextpic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Nextpic.Location = new System.Drawing.Point(480, 105);
            this.Nextpic.Name = "Nextpic";
            this.Nextpic.Size = new System.Drawing.Size(65, 80);
            this.Nextpic.TabIndex = 23;
            this.Nextpic.TabStop = false;
            this.Nextpic.UseVisualStyleBackColor = false;
            this.Nextpic.Click += new System.EventHandler(this.Nextpic_Click);
            // 
            // AddItemP2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(557, 703);
            this.Controls.Add(this.Nextpic);
            this.Controls.Add(this.Prevpic);
            this.Controls.Add(this.StatsPanel);
            this.Controls.Add(this.ConditionBox);
            this.Controls.Add(this.Quality);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Note_TB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Add_Item_toDB);
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
            this.Font = new System.Drawing.Font("TH Sarabun New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "AddItemP2";
            this.Text = "Add barcode Item";
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
        private System.Windows.Forms.Button Add_Item_toDB;
        private System.Windows.Forms.TextBox Note_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label Quality;
        private System.Windows.Forms.RadioButton S_Have;
        private System.Windows.Forms.RadioButton S_Donthave;
        private System.Windows.Forms.Panel StatsPanel;
        private System.Windows.Forms.ComboBox ConditionBox;
        private System.Windows.Forms.Button Prevpic;
        private System.Windows.Forms.Button Nextpic;
    }
}