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
            this.BarcodeID = new System.Windows.Forms.Label();
            this.Product_Name = new System.Windows.Forms.Label();
            this.Created_Time = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.Attendant = new System.Windows.Forms.Label();
            this.Room = new System.Windows.Forms.Label();
            this.Add_Pic = new System.Windows.Forms.Button();
            this.BarcodeID_TB = new System.Windows.Forms.TextBox();
            this.Product_Name_TB = new System.Windows.Forms.TextBox();
            this.Created_Time_TB = new System.Windows.Forms.TextBox();
            this.Price_TB = new System.Windows.Forms.TextBox();
            this.Attendant_TB = new System.Windows.Forms.TextBox();
            this.Room_TB = new System.Windows.Forms.TextBox();
            this.Add_Item_toDB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(125, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 225);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BarcodeID
            // 
            this.BarcodeID.AutoSize = true;
            this.BarcodeID.Location = new System.Drawing.Point(13, 255);
            this.BarcodeID.Name = "BarcodeID";
            this.BarcodeID.Size = new System.Drawing.Size(81, 15);
            this.BarcodeID.TabIndex = 1;
            this.BarcodeID.Text = "Barcode-ID : ";
            this.BarcodeID.Click += new System.EventHandler(this.label1_Click);
            // 
            // Product_Name
            // 
            this.Product_Name.AutoSize = true;
            this.Product_Name.Location = new System.Drawing.Point(13, 280);
            this.Product_Name.Name = "Product_Name";
            this.Product_Name.Size = new System.Drawing.Size(94, 15);
            this.Product_Name.TabIndex = 2;
            this.Product_Name.Text = "Product name : ";
            // 
            // Created_Time
            // 
            this.Created_Time.AutoSize = true;
            this.Created_Time.Location = new System.Drawing.Point(13, 305);
            this.Created_Time.Name = "Created_Time";
            this.Created_Time.Size = new System.Drawing.Size(86, 15);
            this.Created_Time.TabIndex = 3;
            this.Created_Time.Text = "Created time : ";
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Location = new System.Drawing.Point(13, 330);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(43, 15);
            this.Price.TabIndex = 4;
            this.Price.Text = "Price : ";
            // 
            // Attendant
            // 
            this.Attendant.AutoSize = true;
            this.Attendant.Location = new System.Drawing.Point(13, 355);
            this.Attendant.Name = "Attendant";
            this.Attendant.Size = new System.Drawing.Size(71, 15);
            this.Attendant.TabIndex = 5;
            this.Attendant.Text = "Attendant : ";
            // 
            // Room
            // 
            this.Room.AutoSize = true;
            this.Room.Location = new System.Drawing.Point(13, 380);
            this.Room.Name = "Room";
            this.Room.Size = new System.Drawing.Size(49, 15);
            this.Room.TabIndex = 6;
            this.Room.Text = "Room : ";
            // 
            // Add_Pic
            // 
            this.Add_Pic.Location = new System.Drawing.Point(12, 406);
            this.Add_Pic.Name = "Add_Pic";
            this.Add_Pic.Size = new System.Drawing.Size(115, 25);
            this.Add_Pic.TabIndex = 7;
            this.Add_Pic.Text = "+ Upload picture";
            this.Add_Pic.UseVisualStyleBackColor = true;
            // 
            // BarcodeID_TB
            // 
            this.BarcodeID_TB.Location = new System.Drawing.Point(100, 252);
            this.BarcodeID_TB.Name = "BarcodeID_TB";
            this.BarcodeID_TB.ReadOnly = true;
            this.BarcodeID_TB.Size = new System.Drawing.Size(445, 23);
            this.BarcodeID_TB.TabIndex = 8;
            // 
            // Product_Name_TB
            // 
            this.Product_Name_TB.Location = new System.Drawing.Point(113, 277);
            this.Product_Name_TB.Name = "Product_Name_TB";
            this.Product_Name_TB.Size = new System.Drawing.Size(432, 23);
            this.Product_Name_TB.TabIndex = 9;
            // 
            // Created_Time_TB
            // 
            this.Created_Time_TB.Location = new System.Drawing.Point(100, 302);
            this.Created_Time_TB.Name = "Created_Time_TB";
            this.Created_Time_TB.Size = new System.Drawing.Size(445, 23);
            this.Created_Time_TB.TabIndex = 10;
            // 
            // Price_TB
            // 
            this.Price_TB.Location = new System.Drawing.Point(62, 327);
            this.Price_TB.Name = "Price_TB";
            this.Price_TB.Size = new System.Drawing.Size(483, 23);
            this.Price_TB.TabIndex = 11;
            // 
            // Attendant_TB
            // 
            this.Attendant_TB.Location = new System.Drawing.Point(90, 352);
            this.Attendant_TB.Name = "Attendant_TB";
            this.Attendant_TB.Size = new System.Drawing.Size(455, 23);
            this.Attendant_TB.TabIndex = 12;
            // 
            // Room_TB
            // 
            this.Room_TB.Location = new System.Drawing.Point(62, 377);
            this.Room_TB.Name = "Room_TB";
            this.Room_TB.Size = new System.Drawing.Size(483, 23);
            this.Room_TB.TabIndex = 13;
            // 
            // Add_Item_toDB
            // 
            this.Add_Item_toDB.Location = new System.Drawing.Point(430, 406);
            this.Add_Item_toDB.Name = "Add_Item_toDB";
            this.Add_Item_toDB.Size = new System.Drawing.Size(115, 25);
            this.Add_Item_toDB.TabIndex = 14;
            this.Add_Item_toDB.Text = "Add item";
            this.Add_Item_toDB.UseVisualStyleBackColor = true;
            // 
            // AddItemP2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 438);
            this.Controls.Add(this.Add_Item_toDB);
            this.Controls.Add(this.Room_TB);
            this.Controls.Add(this.Attendant_TB);
            this.Controls.Add(this.Price_TB);
            this.Controls.Add(this.Created_Time_TB);
            this.Controls.Add(this.Product_Name_TB);
            this.Controls.Add(this.BarcodeID_TB);
            this.Controls.Add(this.Add_Pic);
            this.Controls.Add(this.Room);
            this.Controls.Add(this.Attendant);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.Created_Time);
            this.Controls.Add(this.Product_Name);
            this.Controls.Add(this.BarcodeID);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AddItemP2";
            this.Text = "Add barcode Item";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label BarcodeID;
        private System.Windows.Forms.Label Product_Name;
        private System.Windows.Forms.Label Created_Time;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label Attendant;
        private System.Windows.Forms.Label Room;
        private System.Windows.Forms.Button Add_Pic;
        private System.Windows.Forms.TextBox BarcodeID_TB;
        private System.Windows.Forms.TextBox Product_Name_TB;
        private System.Windows.Forms.TextBox Created_Time_TB;
        private System.Windows.Forms.TextBox Price_TB;
        private System.Windows.Forms.TextBox Attendant_TB;
        private System.Windows.Forms.TextBox Room_TB;
        private System.Windows.Forms.Button Add_Item_toDB;
    }
}