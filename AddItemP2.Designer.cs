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
            this.Product_Name = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.Attendant = new System.Windows.Forms.Label();
            this.Room = new System.Windows.Forms.Label();
            this.Add_Pic = new System.Windows.Forms.Button();
            this.Model_TB = new System.Windows.Forms.TextBox();
            this.Serial_TB = new System.Windows.Forms.TextBox();
            this.Price_TB = new System.Windows.Forms.TextBox();
            this.Room_TB = new System.Windows.Forms.TextBox();
            this.Note_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.ConditionBox = new System.Windows.Forms.ComboBox();
            this.S_Have = new System.Windows.Forms.RadioButton();
            this.S_Donthave = new System.Windows.Forms.RadioButton();
            this.StatsPanel = new System.Windows.Forms.Panel();
            this.Prevpic = new System.Windows.Forms.Button();
            this.Nextpic = new System.Windows.Forms.Button();
            this.PicInformation = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Created_Time = new System.Windows.Forms.Label();
            this.Brand_TB = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BarcodeID_TB = new System.Windows.Forms.TextBox();
            this.Barcode_ID = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.Quality = new System.Windows.Forms.Label();
            this.Add_Item_toDB = new System.Windows.Forms.Button();
            this.ProductNameTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ProductName_TB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.StatsPanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.ProductNameTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(91, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 270);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.Pic1_Enter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.Pic1_Leave);
            // 
            // Product_Name
            // 
            this.Product_Name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Product_Name.AutoSize = true;
            this.Product_Name.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Product_Name.Location = new System.Drawing.Point(0, 5);
            this.Product_Name.Margin = new System.Windows.Forms.Padding(0);
            this.Product_Name.Name = "Product_Name";
            this.Product_Name.Size = new System.Drawing.Size(57, 36);
            this.Product_Name.TabIndex = 1;
            this.Product_Name.Text = "ยี่ห้อ :";
            this.Product_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Price
            // 
            this.Price.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Price.AutoSize = true;
            this.Price.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Price.Location = new System.Drawing.Point(0, 5);
            this.Price.Margin = new System.Windows.Forms.Padding(0);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(141, 36);
            this.Price.TabIndex = 0;
            this.Price.Text = "Serial Number :";
            this.Price.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Attendant
            // 
            this.Attendant.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Attendant.AutoSize = true;
            this.Attendant.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Attendant.Location = new System.Drawing.Point(0, 5);
            this.Attendant.Margin = new System.Windows.Forms.Padding(0);
            this.Attendant.Name = "Attendant";
            this.Attendant.Size = new System.Drawing.Size(63, 36);
            this.Attendant.TabIndex = 1;
            this.Attendant.Text = "ราคา :";
            this.Attendant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Room
            // 
            this.Room.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Room.AutoSize = true;
            this.Room.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Room.Location = new System.Drawing.Point(0, 5);
            this.Room.Margin = new System.Windows.Forms.Padding(0);
            this.Room.Name = "Room";
            this.Room.Size = new System.Drawing.Size(107, 36);
            this.Room.TabIndex = 1;
            this.Room.Text = "ประจำอยู่ที่ :";
            this.Room.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Room.Click += new System.EventHandler(this.Room_Click);
            // 
            // Add_Pic
            // 
            this.Add_Pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Add_Pic.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Add_Pic.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Add_Pic.Location = new System.Drawing.Point(14, 850);
            this.Add_Pic.Margin = new System.Windows.Forms.Padding(2);
            this.Add_Pic.Name = "Add_Pic";
            this.Add_Pic.Size = new System.Drawing.Size(170, 40);
            this.Add_Pic.TabIndex = 1;
            this.Add_Pic.Text = "+ อัพโหลดรูปภาพ";
            this.Add_Pic.UseVisualStyleBackColor = true;
            this.Add_Pic.Click += new System.EventHandler(this.Add_Pic_Click);
            // 
            // Model_TB
            // 
            this.Model_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Model_TB.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Model_TB.Location = new System.Drawing.Point(59, 2);
            this.Model_TB.Margin = new System.Windows.Forms.Padding(2);
            this.Model_TB.Name = "Model_TB";
            this.Model_TB.Size = new System.Drawing.Size(544, 43);
            this.Model_TB.TabIndex = 3;
            this.Model_TB.Enter += new System.EventHandler(this.Model_TB_Enter);
            this.Model_TB.Leave += new System.EventHandler(this.Model_TB_Leave);
            // 
            // Serial_TB
            // 
            this.Serial_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Serial_TB.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Serial_TB.Location = new System.Drawing.Point(143, 2);
            this.Serial_TB.Margin = new System.Windows.Forms.Padding(2);
            this.Serial_TB.Name = "Serial_TB";
            this.Serial_TB.Size = new System.Drawing.Size(460, 43);
            this.Serial_TB.TabIndex = 5;
            this.Serial_TB.Enter += new System.EventHandler(this.Serial_TB_Enter);
            this.Serial_TB.Leave += new System.EventHandler(this.Serial_TB_Leave);
            // 
            // Price_TB
            // 
            this.Price_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Price_TB.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Price_TB.Location = new System.Drawing.Point(65, 2);
            this.Price_TB.Margin = new System.Windows.Forms.Padding(2);
            this.Price_TB.Name = "Price_TB";
            this.Price_TB.Size = new System.Drawing.Size(538, 43);
            this.Price_TB.TabIndex = 6;
            this.Price_TB.Enter += new System.EventHandler(this.Price_TB_Enter);
            this.Price_TB.Leave += new System.EventHandler(this.Price_TB_Leave);
            // 
            // Room_TB
            // 
            this.Room_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Room_TB.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Room_TB.Location = new System.Drawing.Point(109, 2);
            this.Room_TB.Margin = new System.Windows.Forms.Padding(2);
            this.Room_TB.Name = "Room_TB";
            this.Room_TB.Size = new System.Drawing.Size(494, 43);
            this.Room_TB.TabIndex = 7;
            this.Room_TB.Enter += new System.EventHandler(this.Room_TB_Enter);
            this.Room_TB.Leave += new System.EventHandler(this.Room_TB_Leave);
            // 
            // Note_TB
            // 
            this.Note_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Note_TB.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Note_TB.Location = new System.Drawing.Point(97, 2);
            this.Note_TB.Margin = new System.Windows.Forms.Padding(2);
            this.Note_TB.Name = "Note_TB";
            this.Note_TB.Size = new System.Drawing.Size(506, 43);
            this.Note_TB.TabIndex = 8;
            this.Note_TB.Enter += new System.EventHandler(this.Note_TB_Enter);
            this.Note_TB.Leave += new System.EventHandler(this.Note_TB_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "หมายเหตุ :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Status
            // 
            this.Status.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Status.Location = new System.Drawing.Point(0, 0);
            this.Status.Margin = new System.Windows.Forms.Padding(0);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(89, 36);
            this.Status.TabIndex = 1;
            this.Status.Text = "* สถานะ :";
            this.Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConditionBox
            // 
            this.ConditionBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ConditionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConditionBox.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.ConditionBox.FormattingEnabled = true;
            this.ConditionBox.Items.AddRange(new object[] {
            "ใช้งานได้",
            "ชำรุดรอซ่อม",
            "สิ้นสภาพ",
            "สูญหาย",
            "จำหน่ายแล้ว",
            "โอนแล้ว",
            "อื่นๆ"});
            this.ConditionBox.Location = new System.Drawing.Point(83, 4);
            this.ConditionBox.Margin = new System.Windows.Forms.Padding(2);
            this.ConditionBox.Name = "ConditionBox";
            this.ConditionBox.Size = new System.Drawing.Size(252, 44);
            this.ConditionBox.TabIndex = 11;
            this.ConditionBox.SelectedIndexChanged += new System.EventHandler(this.ConditionBox_SelectedIndexChanged);
            // 
            // S_Have
            // 
            this.S_Have.AutoSize = true;
            this.S_Have.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.S_Have.Location = new System.Drawing.Point(1, -4);
            this.S_Have.Margin = new System.Windows.Forms.Padding(2);
            this.S_Have.Name = "S_Have";
            this.S_Have.Size = new System.Drawing.Size(137, 40);
            this.S_Have.TabIndex = 9;
            this.S_Have.TabStop = true;
            this.S_Have.Text = "มีให้ตรวจสอบ";
            this.S_Have.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.S_Have.UseVisualStyleBackColor = true;
            this.S_Have.CheckedChanged += new System.EventHandler(this.S_Have_CheckedChanged);
            // 
            // S_Donthave
            // 
            this.S_Donthave.AutoSize = true;
            this.S_Donthave.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.S_Donthave.Location = new System.Drawing.Point(142, -4);
            this.S_Donthave.Margin = new System.Windows.Forms.Padding(2);
            this.S_Donthave.Name = "S_Donthave";
            this.S_Donthave.Size = new System.Drawing.Size(155, 40);
            this.S_Donthave.TabIndex = 10;
            this.S_Donthave.TabStop = true;
            this.S_Donthave.Text = "ไม่มีให้ตรวจสอบ";
            this.S_Donthave.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.S_Donthave.UseVisualStyleBackColor = true;
            this.S_Donthave.CheckedChanged += new System.EventHandler(this.S_Donthave_CheckedChanged);
            // 
            // StatsPanel
            // 
            this.StatsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StatsPanel.Controls.Add(this.S_Donthave);
            this.StatsPanel.Controls.Add(this.S_Have);
            this.StatsPanel.Location = new System.Drawing.Point(89, 2);
            this.StatsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.StatsPanel.Name = "StatsPanel";
            this.StatsPanel.Size = new System.Drawing.Size(516, 31);
            this.StatsPanel.TabIndex = 1;
            this.StatsPanel.TabStop = true;
            // 
            // Prevpic
            // 
            this.Prevpic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Prevpic.BackColor = System.Drawing.SystemColors.Control;
            this.Prevpic.BackgroundImage = global::USB_Barcode_Scanner_Tutorial___C_Sharp.Properties.Resources.Previous;
            this.Prevpic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Prevpic.Location = new System.Drawing.Point(15, 90);
            this.Prevpic.Margin = new System.Windows.Forms.Padding(2);
            this.Prevpic.Name = "Prevpic";
            this.Prevpic.Size = new System.Drawing.Size(65, 120);
            this.Prevpic.TabIndex = 0;
            this.Prevpic.TabStop = false;
            this.Prevpic.UseVisualStyleBackColor = false;
            this.Prevpic.Click += new System.EventHandler(this.Prevpic_Click);
            // 
            // Nextpic
            // 
            this.Nextpic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Nextpic.BackColor = System.Drawing.SystemColors.Control;
            this.Nextpic.BackgroundImage = global::USB_Barcode_Scanner_Tutorial___C_Sharp.Properties.Resources.Next;
            this.Nextpic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Nextpic.Location = new System.Drawing.Point(555, 90);
            this.Nextpic.Margin = new System.Windows.Forms.Padding(2);
            this.Nextpic.Name = "Nextpic";
            this.Nextpic.Size = new System.Drawing.Size(65, 120);
            this.Nextpic.TabIndex = 0;
            this.Nextpic.TabStop = false;
            this.Nextpic.UseVisualStyleBackColor = false;
            this.Nextpic.Click += new System.EventHandler(this.Nextpic_Click);
            // 
            // PicInformation
            // 
            this.PicInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PicInformation.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.PicInformation.Location = new System.Drawing.Point(0, 9);
            this.PicInformation.Margin = new System.Windows.Forms.Padding(0);
            this.PicInformation.Name = "PicInformation";
            this.PicInformation.Size = new System.Drawing.Size(605, 31);
            this.PicInformation.TabIndex = 0;
            this.PicInformation.Text = "-";
            this.PicInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.Created_Time, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Brand_TB, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 197);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(605, 47);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // Created_Time
            // 
            this.Created_Time.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Created_Time.AutoSize = true;
            this.Created_Time.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Created_Time.Location = new System.Drawing.Point(0, 5);
            this.Created_Time.Margin = new System.Windows.Forms.Padding(0);
            this.Created_Time.Name = "Created_Time";
            this.Created_Time.Size = new System.Drawing.Size(45, 36);
            this.Created_Time.TabIndex = 0;
            this.Created_Time.Text = "รุ่น :";
            this.Created_Time.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Created_Time.Click += new System.EventHandler(this.Created_Time_Click);
            // 
            // Brand_TB
            // 
            this.Brand_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Brand_TB.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Brand_TB.Location = new System.Drawing.Point(47, 2);
            this.Brand_TB.Margin = new System.Windows.Forms.Padding(2);
            this.Brand_TB.Name = "Brand_TB";
            this.Brand_TB.Size = new System.Drawing.Size(556, 43);
            this.Brand_TB.TabIndex = 4;
            this.Brand_TB.Enter += new System.EventHandler(this.Brand_TB_Enter);
            this.Brand_TB.Leave += new System.EventHandler(this.Brand_TB_Leave);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.Serial_TB, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.Price, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 246);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(605, 47);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ProductNameTableLayout, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.PicInformation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel8, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel9, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel12, 0, 10);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 294);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(605, 545);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.Product_Name, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.Model_TB, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 148);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(605, 47);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.BarcodeID_TB, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Barcode_ID, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(605, 47);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // BarcodeID_TB
            // 
            this.BarcodeID_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BarcodeID_TB.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BarcodeID_TB.Location = new System.Drawing.Point(166, 2);
            this.BarcodeID_TB.Margin = new System.Windows.Forms.Padding(2);
            this.BarcodeID_TB.Name = "BarcodeID_TB";
            this.BarcodeID_TB.Size = new System.Drawing.Size(437, 43);
            this.BarcodeID_TB.TabIndex = 1;
            this.BarcodeID_TB.Enter += new System.EventHandler(this.BarcodeID_TB_Enter);
            this.BarcodeID_TB.Leave += new System.EventHandler(this.BarcodeID_TB_Leave);
            // 
            // Barcode_ID
            // 
            this.Barcode_ID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Barcode_ID.AutoSize = true;
            this.Barcode_ID.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Barcode_ID.Location = new System.Drawing.Point(0, 5);
            this.Barcode_ID.Margin = new System.Windows.Forms.Padding(0);
            this.Barcode_ID.Name = "Barcode_ID";
            this.Barcode_ID.Size = new System.Drawing.Size(164, 36);
            this.Barcode_ID.TabIndex = 0;
            this.Barcode_ID.Text = "* หมายเลขครุภัณฑ์ :";
            this.Barcode_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Barcode_ID.Click += new System.EventHandler(this.label1_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.Attendant, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.Price_TB, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 295);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(605, 47);
            this.tableLayoutPanel6.TabIndex = 6;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.Room, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.Room_TB, 1, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 344);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(605, 47);
            this.tableLayoutPanel7.TabIndex = 7;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.Note_TB, 1, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 393);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(605, 47);
            this.tableLayoutPanel8.TabIndex = 8;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel9.AutoSize = true;
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.StatsPanel, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.Status, 0, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 447);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(605, 36);
            this.tableLayoutPanel9.TabIndex = 9;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Controls.Add(this.Quality, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.ConditionBox, 1, 0);
            this.tableLayoutPanel12.Location = new System.Drawing.Point(0, 490);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(340, 54);
            this.tableLayoutPanel12.TabIndex = 10;
            // 
            // Quality
            // 
            this.Quality.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Quality.AutoSize = true;
            this.Quality.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Quality.Location = new System.Drawing.Point(0, 9);
            this.Quality.Margin = new System.Windows.Forms.Padding(0);
            this.Quality.Name = "Quality";
            this.Quality.Size = new System.Drawing.Size(81, 36);
            this.Quality.TabIndex = 1;
            this.Quality.Text = "* สภาพ :";
            this.Quality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Add_Item_toDB
            // 
            this.Add_Item_toDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_Item_toDB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Add_Item_toDB.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Add_Item_toDB.Location = new System.Drawing.Point(502, 850);
            this.Add_Item_toDB.Margin = new System.Windows.Forms.Padding(2);
            this.Add_Item_toDB.Name = "Add_Item_toDB";
            this.Add_Item_toDB.Size = new System.Drawing.Size(120, 40);
            this.Add_Item_toDB.TabIndex = 2;
            this.Add_Item_toDB.Text = "เพิ่มสิ่งของ";
            this.Add_Item_toDB.UseVisualStyleBackColor = true;
            this.Add_Item_toDB.Click += new System.EventHandler(this.Add_Item_toDB_Click);
            // 
            // ProductNameTableLayout
            // 
            this.ProductNameTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductNameTableLayout.AutoSize = true;
            this.ProductNameTableLayout.ColumnCount = 2;
            this.ProductNameTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ProductNameTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProductNameTableLayout.Controls.Add(this.ProductName_TB, 1, 0);
            this.ProductNameTableLayout.Controls.Add(this.label2, 0, 0);
            this.ProductNameTableLayout.Location = new System.Drawing.Point(0, 99);
            this.ProductNameTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.ProductNameTableLayout.Name = "ProductNameTableLayout";
            this.ProductNameTableLayout.RowCount = 1;
            this.ProductNameTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProductNameTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.ProductNameTableLayout.Size = new System.Drawing.Size(605, 47);
            this.ProductNameTableLayout.TabIndex = 2;
            // 
            // ProductName_TB
            // 
            this.ProductName_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductName_TB.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ProductName_TB.Location = new System.Drawing.Point(119, 2);
            this.ProductName_TB.Margin = new System.Windows.Forms.Padding(2);
            this.ProductName_TB.Name = "ProductName_TB";
            this.ProductName_TB.Size = new System.Drawing.Size(484, 43);
            this.ProductName_TB.TabIndex = 2;
            this.ProductName_TB.Enter += new System.EventHandler(this.ProductName_TB_Enter);
            this.ProductName_TB.Leave += new System.EventHandler(this.ProductName_TB_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.label2.Location = new System.Drawing.Point(0, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "* ชื่อครุภัณฑ์ :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddItemP2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(632, 903);
            this.Controls.Add(this.Add_Item_toDB);
            this.Controls.Add(this.Add_Pic);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Nextpic);
            this.Controls.Add(this.Prevpic);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(650, 950);
            this.Name = "AddItemP2";
            this.Text = "Add barcode Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing3);
            this.Load += new System.EventHandler(this.AddItemP2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.StatsPanel.ResumeLayout(false);
            this.StatsPanel.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.ProductNameTableLayout.ResumeLayout(false);
            this.ProductNameTableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Product_Name;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label Attendant;
        private System.Windows.Forms.Label Room;
        private System.Windows.Forms.Button Add_Pic;
        private System.Windows.Forms.TextBox Model_TB;
        private System.Windows.Forms.TextBox Serial_TB;
        private System.Windows.Forms.TextBox Price_TB;
        private System.Windows.Forms.TextBox Room_TB;
        private System.Windows.Forms.TextBox Note_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.RadioButton S_Have;
        private System.Windows.Forms.RadioButton S_Donthave;
        private System.Windows.Forms.Panel StatsPanel;
        private System.Windows.Forms.ComboBox ConditionBox;
        private System.Windows.Forms.Button Prevpic;
        private System.Windows.Forms.Button Nextpic;
        private System.Windows.Forms.Label PicInformation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox Brand_TB;
        private System.Windows.Forms.Label Created_Time;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Label Quality;
        private System.Windows.Forms.Button Add_Item_toDB;
        private System.Windows.Forms.TextBox BarcodeID_TB;
        private System.Windows.Forms.Label Barcode_ID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel ProductNameTableLayout;
        private System.Windows.Forms.TextBox ProductName_TB;
        private System.Windows.Forms.Label label2;
    }
}