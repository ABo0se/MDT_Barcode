﻿namespace USB_Barcode_Scanner_Tutorial___C_Sharp
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
            this.Add_Pic = new System.Windows.Forms.Button();
            this.Edit_Item_toDB = new System.Windows.Forms.Button();
            this.S_Donthave = new System.Windows.Forms.RadioButton();
            this.S_Have = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.ConditionBoxEdit = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.StatsPanel = new System.Windows.Forms.Panel();
            this.S_DonthaveEdit = new System.Windows.Forms.RadioButton();
            this.S_HaveEdit = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.Note_TB = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.Room_TB = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.Price_TB = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.BarcodeID_TB = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.Model_TB = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.Serial_TB = new System.Windows.Forms.TextBox();
            this.PicInformation = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.Brand_TB = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ProductName_TB = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Nextpic = new System.Windows.Forms.Button();
            this.Prevpic = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.StatsPanel.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // Add_Pic
            // 
            this.Add_Pic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Add_Pic.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.Add_Pic.Location = new System.Drawing.Point(0, 3);
            this.Add_Pic.Margin = new System.Windows.Forms.Padding(0);
            this.Add_Pic.Name = "Add_Pic";
            this.Add_Pic.Size = new System.Drawing.Size(170, 40);
            this.Add_Pic.TabIndex = 3;
            this.Add_Pic.Text = "+ อัพโหลดรูป";
            this.Add_Pic.UseVisualStyleBackColor = true;
            this.Add_Pic.Click += new System.EventHandler(this.Add_Pic_Click);
            // 
            // Edit_Item_toDB
            // 
            this.Edit_Item_toDB.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Edit_Item_toDB.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.Edit_Item_toDB.Location = new System.Drawing.Point(452, 3);
            this.Edit_Item_toDB.Margin = new System.Windows.Forms.Padding(0);
            this.Edit_Item_toDB.Name = "Edit_Item_toDB";
            this.Edit_Item_toDB.Size = new System.Drawing.Size(147, 40);
            this.Edit_Item_toDB.TabIndex = 4;
            this.Edit_Item_toDB.Text = "แก้ไขสิ่งของ";
            this.Edit_Item_toDB.UseVisualStyleBackColor = true;
            this.Edit_Item_toDB.Click += new System.EventHandler(this.Add_Item_toDB_Click);
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
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.ConditionBoxEdit, 1, 0);
            this.tableLayoutPanel12.Location = new System.Drawing.Point(0, 480);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(602, 48);
            this.tableLayoutPanel12.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(0, 6);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 36);
            this.label11.TabIndex = 0;
            this.label11.Text = "สภาพ * :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConditionBoxEdit
            // 
            this.ConditionBoxEdit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ConditionBoxEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConditionBoxEdit.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.ConditionBoxEdit.FormattingEnabled = true;
            this.ConditionBoxEdit.Items.AddRange(new object[] {
            "ใช้งานได้",
            "ชำรุดรอซ่อม",
            "สิ้นสภาพ",
            "สูญหาย",
            "จำหน่ายแล้ว",
            "โอนแล้ว",
            "อื่นๆ"});
            this.ConditionBoxEdit.Location = new System.Drawing.Point(91, 2);
            this.ConditionBoxEdit.Margin = new System.Windows.Forms.Padding(0);
            this.ConditionBoxEdit.Name = "ConditionBoxEdit";
            this.ConditionBoxEdit.Size = new System.Drawing.Size(267, 44);
            this.ConditionBoxEdit.TabIndex = 1;
            this.ConditionBoxEdit.SelectedIndexChanged += new System.EventHandler(this.ConditionBox_SelectedIndexChanged);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel9.AutoSize = true;
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.StatsPanel, 1, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 437);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(605, 37);
            this.tableLayoutPanel9.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 36);
            this.label10.TabIndex = 0;
            this.label10.Text = "สถานะ * :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatsPanel
            // 
            this.StatsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StatsPanel.Controls.Add(this.S_DonthaveEdit);
            this.StatsPanel.Controls.Add(this.S_HaveEdit);
            this.StatsPanel.Location = new System.Drawing.Point(101, 3);
            this.StatsPanel.Name = "StatsPanel";
            this.StatsPanel.Size = new System.Drawing.Size(501, 31);
            this.StatsPanel.TabIndex = 1;
            this.StatsPanel.TabStop = true;
            // 
            // S_DonthaveEdit
            // 
            this.S_DonthaveEdit.AutoSize = true;
            this.S_DonthaveEdit.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.S_DonthaveEdit.Location = new System.Drawing.Point(143, -5);
            this.S_DonthaveEdit.Margin = new System.Windows.Forms.Padding(0);
            this.S_DonthaveEdit.Name = "S_DonthaveEdit";
            this.S_DonthaveEdit.Size = new System.Drawing.Size(155, 40);
            this.S_DonthaveEdit.TabIndex = 1;
            this.S_DonthaveEdit.Text = "ไม่มีให้ตรวจสอบ";
            this.S_DonthaveEdit.UseVisualStyleBackColor = true;
            this.S_DonthaveEdit.CheckedChanged += new System.EventHandler(this.S_Donthave_CheckedChanged);
            // 
            // S_HaveEdit
            // 
            this.S_HaveEdit.AutoSize = true;
            this.S_HaveEdit.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.S_HaveEdit.Location = new System.Drawing.Point(0, -5);
            this.S_HaveEdit.Margin = new System.Windows.Forms.Padding(0);
            this.S_HaveEdit.Name = "S_HaveEdit";
            this.S_HaveEdit.Size = new System.Drawing.Size(137, 40);
            this.S_HaveEdit.TabIndex = 0;
            this.S_HaveEdit.Text = "มีให้ตรวจสอบ";
            this.S_HaveEdit.UseVisualStyleBackColor = true;
            this.S_HaveEdit.CheckedChanged += new System.EventHandler(this.S_Have_CheckedChanged);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.Note_TB, 1, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 386);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(605, 43);
            this.tableLayoutPanel8.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(0, 3);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 36);
            this.label9.TabIndex = 0;
            this.label9.Text = "หมายเหตุ :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Note_TB
            // 
            this.Note_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Note_TB.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Note_TB.Location = new System.Drawing.Point(108, 0);
            this.Note_TB.Margin = new System.Windows.Forms.Padding(0);
            this.Note_TB.Name = "Note_TB";
            this.Note_TB.Size = new System.Drawing.Size(497, 43);
            this.Note_TB.TabIndex = 1;
            this.Note_TB.Enter += new System.EventHandler(this.Note_TB_Enter);
            this.Note_TB.Leave += new System.EventHandler(this.Note_TB_Leave);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.Room_TB, 1, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 338);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(605, 43);
            this.tableLayoutPanel7.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(0, 3);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 36);
            this.label8.TabIndex = 0;
            this.label8.Text = "ประจำอยู่ที่ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Room_TB
            // 
            this.Room_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Room_TB.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Room_TB.Location = new System.Drawing.Point(120, 0);
            this.Room_TB.Margin = new System.Windows.Forms.Padding(0);
            this.Room_TB.Name = "Room_TB";
            this.Room_TB.Size = new System.Drawing.Size(485, 43);
            this.Room_TB.TabIndex = 1;
            this.Room_TB.Enter += new System.EventHandler(this.Room_TB_Enter);
            this.Room_TB.Leave += new System.EventHandler(this.Room_TB_Leave);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.Price_TB, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 290);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(605, 43);
            this.tableLayoutPanel6.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(0, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 36);
            this.label7.TabIndex = 0;
            this.label7.Text = "ราคา :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Price_TB
            // 
            this.Price_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Price_TB.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Price_TB.Location = new System.Drawing.Point(69, 0);
            this.Price_TB.Margin = new System.Windows.Forms.Padding(0);
            this.Price_TB.Name = "Price_TB";
            this.Price_TB.Size = new System.Drawing.Size(536, 43);
            this.Price_TB.TabIndex = 1;
            this.Price_TB.Enter += new System.EventHandler(this.Price_TB_Enter);
            this.Price_TB.Leave += new System.EventHandler(this.Price_TB_Leave);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BarcodeID_TB, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(605, 43);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(0, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 36);
            this.label6.TabIndex = 0;
            this.label6.Text = "หมายเลขครุภัณฑ์ * :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BarcodeID_TB
            // 
            this.BarcodeID_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BarcodeID_TB.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.BarcodeID_TB.Location = new System.Drawing.Point(188, 0);
            this.BarcodeID_TB.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeID_TB.Name = "BarcodeID_TB";
            this.BarcodeID_TB.Size = new System.Drawing.Size(417, 43);
            this.BarcodeID_TB.TabIndex = 1;
            this.BarcodeID_TB.Enter += new System.EventHandler(this.BarcodeID_TB_Enter);
            this.BarcodeID_TB.Leave += new System.EventHandler(this.BarcodeID_TB_Leave);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Model_TB, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 194);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(605, 43);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(0, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 36);
            this.label3.TabIndex = 0;
            this.label3.Text = "รุ่น :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Model_TB
            // 
            this.Model_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Model_TB.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Model_TB.Location = new System.Drawing.Point(49, 0);
            this.Model_TB.Margin = new System.Windows.Forms.Padding(0);
            this.Model_TB.Name = "Model_TB";
            this.Model_TB.Size = new System.Drawing.Size(556, 43);
            this.Model_TB.TabIndex = 1;
            this.Model_TB.Enter += new System.EventHandler(this.Model_TB_Enter);
            this.Model_TB.Leave += new System.EventHandler(this.Model_TB_Leave);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.Serial_TB, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 242);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(605, 43);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(0, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 36);
            this.label4.TabIndex = 0;
            this.label4.Text = "Serial Number :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Serial_TB
            // 
            this.Serial_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Serial_TB.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Serial_TB.Location = new System.Drawing.Point(151, 0);
            this.Serial_TB.Margin = new System.Windows.Forms.Padding(0);
            this.Serial_TB.Name = "Serial_TB";
            this.Serial_TB.Size = new System.Drawing.Size(454, 43);
            this.Serial_TB.TabIndex = 1;
            this.Serial_TB.Enter += new System.EventHandler(this.Serial_TB_Enter);
            this.Serial_TB.Leave += new System.EventHandler(this.Serial_TB_Leave);
            // 
            // PicInformation
            // 
            this.PicInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PicInformation.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.PicInformation.Location = new System.Drawing.Point(0, 9);
            this.PicInformation.Margin = new System.Windows.Forms.Padding(0);
            this.PicInformation.Name = "PicInformation";
            this.PicInformation.Size = new System.Drawing.Size(605, 30);
            this.PicInformation.TabIndex = 0;
            this.PicInformation.Text = "-";
            this.PicInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.Brand_TB, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 146);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(605, 43);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(0, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 36);
            this.label5.TabIndex = 0;
            this.label5.Text = "ยี่ห้อ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Brand_TB
            // 
            this.Brand_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Brand_TB.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Brand_TB.Location = new System.Drawing.Point(64, 0);
            this.Brand_TB.Margin = new System.Windows.Forms.Padding(0);
            this.Brand_TB.Name = "Brand_TB";
            this.Brand_TB.Size = new System.Drawing.Size(541, 43);
            this.Brand_TB.TabIndex = 1;
            this.Brand_TB.Enter += new System.EventHandler(this.Brand_TB_Enter);
            this.Brand_TB.Leave += new System.EventHandler(this.Brand_TB_Leave);
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel10.AutoSize = true;
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.ProductName_TB, 1, 0);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 98);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(605, 43);
            this.tableLayoutPanel10.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "ชื่อครุภัณฑ์ * :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProductName_TB
            // 
            this.ProductName_TB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductName_TB.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.ProductName_TB.Location = new System.Drawing.Point(132, 0);
            this.ProductName_TB.Margin = new System.Windows.Forms.Padding(0);
            this.ProductName_TB.Name = "ProductName_TB";
            this.ProductName_TB.Size = new System.Drawing.Size(473, 43);
            this.ProductName_TB.TabIndex = 1;
            this.ProductName_TB.Enter += new System.EventHandler(this.ProductName_TB_Enter);
            this.ProductName_TB.Leave += new System.EventHandler(this.ProductName_TB_Leave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel11, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel10, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.PicInformation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel8, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel9, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel12, 0, 10);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 265);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(605, 580);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // Nextpic
            // 
            this.Nextpic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Nextpic.BackColor = System.Drawing.SystemColors.Control;
            this.Nextpic.BackgroundImage = global::USB_Barcode_Scanner_Tutorial___C_Sharp.Properties.Resources.Next;
            this.Nextpic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Nextpic.Location = new System.Drawing.Point(555, 90);
            this.Nextpic.Name = "Nextpic";
            this.Nextpic.Size = new System.Drawing.Size(65, 90);
            this.Nextpic.TabIndex = 1;
            this.Nextpic.TabStop = false;
            this.Nextpic.UseVisualStyleBackColor = false;
            this.Nextpic.Click += new System.EventHandler(this.Nextpic_Click);
            // 
            // Prevpic
            // 
            this.Prevpic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Prevpic.BackColor = System.Drawing.SystemColors.Control;
            this.Prevpic.BackgroundImage = global::USB_Barcode_Scanner_Tutorial___C_Sharp.Properties.Resources.Previous;
            this.Prevpic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Prevpic.Location = new System.Drawing.Point(15, 90);
            this.Prevpic.Name = "Prevpic";
            this.Prevpic.Size = new System.Drawing.Size(65, 90);
            this.Prevpic.TabIndex = 0;
            this.Prevpic.TabStop = false;
            this.Prevpic.UseVisualStyleBackColor = false;
            this.Prevpic.Click += new System.EventHandler(this.Prevpic_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(92, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.EditPic_Enter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.EditPic_Leave);
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Controls.Add(this.Edit_Item_toDB, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.Add_Pic, 0, 0);
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 531);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(599, 46);
            this.tableLayoutPanel11.TabIndex = 24;
            // 
            // EditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(632, 853);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Nextpic);
            this.Controls.Add(this.Prevpic);
            this.Controls.Add(this.S_Donthave);
            this.Controls.Add(this.S_Have);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(650, 900);
            this.Name = "EditItem";
            this.Text = "แก้ไขรายละเอียดครุภัณฑ์";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing3);
            this.Load += new System.EventHandler(this.AddItemP2_Load);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.StatsPanel.ResumeLayout(false);
            this.StatsPanel.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Add_Pic;
        private System.Windows.Forms.Button Edit_Item_toDB;
        private System.Windows.Forms.RadioButton S_Donthave;
        private System.Windows.Forms.RadioButton S_Have;
        private System.Windows.Forms.Button Nextpic;
        private System.Windows.Forms.Button Prevpic;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ConditionBoxEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel StatsPanel;
        private System.Windows.Forms.RadioButton S_DonthaveEdit;
        private System.Windows.Forms.RadioButton S_HaveEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Note_TB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Room_TB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Price_TB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox BarcodeID_TB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Model_TB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Serial_TB;
        private System.Windows.Forms.Label PicInformation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Brand_TB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ProductName_TB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
    }
}