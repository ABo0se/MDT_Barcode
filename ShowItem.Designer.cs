namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    partial class ShowItem
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
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.BarcodeID = new System.Windows.Forms.Label();
            this.Product_Name = new System.Windows.Forms.Label();
            this.Created_Time = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.Attendant = new System.Windows.Forms.Label();
            this.Room = new System.Windows.Forms.Label();
            this.BarcodeID_TXT = new System.Windows.Forms.Label();
            this.ProductName_TXT = new System.Windows.Forms.Label();
            this.CreatedTime_TXT = new System.Windows.Forms.Label();
            this.Price_TXT = new System.Windows.Forms.Label();
            this.Attentdant_TXT = new System.Windows.Forms.Label();
            this.Room_TXT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBox.Location = new System.Drawing.Point(125, 15);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(300, 225);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
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
            // BarcodeID_TXT
            // 
            this.BarcodeID_TXT.AutoSize = true;
            this.BarcodeID_TXT.Location = new System.Drawing.Point(95, 255);
            this.BarcodeID_TXT.Name = "BarcodeID_TXT";
            this.BarcodeID_TXT.Size = new System.Drawing.Size(12, 15);
            this.BarcodeID_TXT.TabIndex = 7;
            this.BarcodeID_TXT.Text = "-";
            // 
            // ProductName_TXT
            // 
            this.ProductName_TXT.AutoSize = true;
            this.ProductName_TXT.Location = new System.Drawing.Point(108, 280);
            this.ProductName_TXT.Name = "ProductName_TXT";
            this.ProductName_TXT.Size = new System.Drawing.Size(12, 15);
            this.ProductName_TXT.TabIndex = 8;
            this.ProductName_TXT.Text = "-";
            // 
            // CreatedTime_TXT
            // 
            this.CreatedTime_TXT.AutoSize = true;
            this.CreatedTime_TXT.Location = new System.Drawing.Point(95, 305);
            this.CreatedTime_TXT.Name = "CreatedTime_TXT";
            this.CreatedTime_TXT.Size = new System.Drawing.Size(12, 15);
            this.CreatedTime_TXT.TabIndex = 9;
            this.CreatedTime_TXT.Text = "-";
            // 
            // Price_TXT
            // 
            this.Price_TXT.AutoSize = true;
            this.Price_TXT.Location = new System.Drawing.Point(53, 330);
            this.Price_TXT.Name = "Price_TXT";
            this.Price_TXT.Size = new System.Drawing.Size(12, 15);
            this.Price_TXT.TabIndex = 10;
            this.Price_TXT.Text = "-";
            // 
            // Attentdant_TXT
            // 
            this.Attentdant_TXT.AutoSize = true;
            this.Attentdant_TXT.Location = new System.Drawing.Point(85, 355);
            this.Attentdant_TXT.Name = "Attentdant_TXT";
            this.Attentdant_TXT.Size = new System.Drawing.Size(12, 15);
            this.Attentdant_TXT.TabIndex = 11;
            this.Attentdant_TXT.Text = "-";
            // 
            // Room_TXT
            // 
            this.Room_TXT.AutoSize = true;
            this.Room_TXT.Location = new System.Drawing.Point(63, 380);
            this.Room_TXT.Name = "Room_TXT";
            this.Room_TXT.Size = new System.Drawing.Size(12, 15);
            this.Room_TXT.TabIndex = 12;
            this.Room_TXT.Text = "-";
            // 
            // ShowItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 408);
            this.Controls.Add(this.Room_TXT);
            this.Controls.Add(this.Attentdant_TXT);
            this.Controls.Add(this.Price_TXT);
            this.Controls.Add(this.CreatedTime_TXT);
            this.Controls.Add(this.ProductName_TXT);
            this.Controls.Add(this.BarcodeID_TXT);
            this.Controls.Add(this.Room);
            this.Controls.Add(this.Attendant);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.Created_Time);
            this.Controls.Add(this.Product_Name);
            this.Controls.Add(this.BarcodeID);
            this.Controls.Add(this.PictureBox);
            this.Name = "ShowItem";
            this.Text = "Add barcode Item";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Label BarcodeID;
        private System.Windows.Forms.Label Product_Name;
        private System.Windows.Forms.Label Created_Time;
        private System.Windows.Forms.Label Price;
        private System.Windows.Forms.Label Attendant;
        private System.Windows.Forms.Label Room;
        private System.Windows.Forms.Label BarcodeID_TXT;
        private System.Windows.Forms.Label ProductName_TXT;
        private System.Windows.Forms.Label CreatedTime_TXT;
        private System.Windows.Forms.Label Price_TXT;
        private System.Windows.Forms.Label Attentdant_TXT;
        private System.Windows.Forms.Label Room_TXT;
    }
}