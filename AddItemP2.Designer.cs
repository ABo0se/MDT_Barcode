﻿namespace USB_Barcode_Scanner_Tutorial___C_Sharp
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(89, 17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(373, 255);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Barcode_ID
            // 
            this.Barcode_ID.AutoSize = true;
            this.Barcode_ID.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Barcode_ID.Location = new System.Drawing.Point(9, 289);
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
            this.Product_Name.Location = new System.Drawing.Point(9, 338);
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
            this.Created_Time.Location = new System.Drawing.Point(9, 386);
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
            this.Price.Location = new System.Drawing.Point(9, 435);
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
            this.Attendant.Location = new System.Drawing.Point(9, 484);
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
            this.Room.Location = new System.Drawing.Point(9, 533);
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
            this.Add_Pic.Location = new System.Drawing.Point(13, 623);
            this.Add_Pic.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Add_Pic.Name = "Add_Pic";
            this.Add_Pic.Size = new System.Drawing.Size(116, 40);
            this.Add_Pic.TabIndex = 7;
            this.Add_Pic.Text = "+ อัพโหลดรูปภาพ";
            this.Add_Pic.UseVisualStyleBackColor = true;
            this.Add_Pic.Click += new System.EventHandler(this.Add_Pic_Click);
            // 
            // BarcodeID_TB
            // 
            this.BarcodeID_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BarcodeID_TB.Location = new System.Drawing.Point(124, 286);
            this.BarcodeID_TB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BarcodeID_TB.Name = "BarcodeID_TB";
            this.BarcodeID_TB.Size = new System.Drawing.Size(422, 34);
            this.BarcodeID_TB.TabIndex = 8;
            this.BarcodeID_TB.TabStop = false;
            this.BarcodeID_TB.TextChanged += new System.EventHandler(this.BarcodeID_TB_TextChanged);
            // 
            // Model_TB
            // 
            this.Model_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Model_TB.Location = new System.Drawing.Point(53, 334);
            this.Model_TB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Model_TB.Name = "Model_TB";
            this.Model_TB.Size = new System.Drawing.Size(493, 34);
            this.Model_TB.TabIndex = 1;
            // 
            // Brand_TB
            // 
            this.Brand_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Brand_TB.Location = new System.Drawing.Point(44, 383);
            this.Brand_TB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Brand_TB.Name = "Brand_TB";
            this.Brand_TB.Size = new System.Drawing.Size(503, 34);
            this.Brand_TB.TabIndex = 2;
            // 
            // Serial_TB
            // 
            this.Serial_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Serial_TB.Location = new System.Drawing.Point(116, 432);
            this.Serial_TB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Serial_TB.Name = "Serial_TB";
            this.Serial_TB.Size = new System.Drawing.Size(431, 34);
            this.Serial_TB.TabIndex = 3;
            // 
            // Price_TB
            // 
            this.Price_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Price_TB.Location = new System.Drawing.Point(53, 481);
            this.Price_TB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Price_TB.Name = "Price_TB";
            this.Price_TB.Size = new System.Drawing.Size(494, 34);
            this.Price_TB.TabIndex = 4;
            // 
            // Room_TB
            // 
            this.Room_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Room_TB.Location = new System.Drawing.Point(89, 529);
            this.Room_TB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Room_TB.Name = "Room_TB";
            this.Room_TB.Size = new System.Drawing.Size(458, 34);
            this.Room_TB.TabIndex = 5;
            // 
            // Add_Item_toDB
            // 
            this.Add_Item_toDB.Font = new System.Drawing.Font("TH Sarabun New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Add_Item_toDB.Location = new System.Drawing.Point(430, 623);
            this.Add_Item_toDB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Add_Item_toDB.Name = "Add_Item_toDB";
            this.Add_Item_toDB.Size = new System.Drawing.Size(117, 40);
            this.Add_Item_toDB.TabIndex = 14;
            this.Add_Item_toDB.Text = "เพิ่มสิ่งของ";
            this.Add_Item_toDB.UseVisualStyleBackColor = true;
            this.Add_Item_toDB.Click += new System.EventHandler(this.Add_Item_toDB_Click);
            // 
            // Note_TB
            // 
            this.Note_TB.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Note_TB.Location = new System.Drawing.Point(82, 578);
            this.Note_TB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Note_TB.Name = "Note_TB";
            this.Note_TB.Size = new System.Drawing.Size(464, 34);
            this.Note_TB.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 581);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 27);
            this.label1.TabIndex = 15;
            this.label1.Text = "หมายเหตุ : ";
            // 
            // AddItemP2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(557, 673);
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
    }
}