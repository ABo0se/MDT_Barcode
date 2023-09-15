namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    partial class AddItemP1
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
            this.QRText = new System.Windows.Forms.Label();
            this.BarcodeText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // QRText
            // 
            this.QRText.AutoSize = true;
            this.QRText.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.QRText.Location = new System.Drawing.Point(14, 20);
            this.QRText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.QRText.Name = "QRText";
            this.QRText.Size = new System.Drawing.Size(313, 27);
            this.QRText.TabIndex = 0;
            this.QRText.Text = "กรุณาสแกน Barcode ครุภัณฑ์ของท่าน";
            this.QRText.Click += new System.EventHandler(this.QRText_Click);
            // 
            // BarcodeText
            // 
            this.BarcodeText.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BarcodeText.Location = new System.Drawing.Point(14, 61);
            this.BarcodeText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BarcodeText.Name = "BarcodeText";
            this.BarcodeText.ReadOnly = true;
            this.BarcodeText.Size = new System.Drawing.Size(313, 34);
            this.BarcodeText.TabIndex = 1;
            this.BarcodeText.TextChanged += new System.EventHandler(this.BarcodeText_TextChanged);
            // 
            // AddItemP1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 117);
            this.Controls.Add(this.BarcodeText);
            this.Controls.Add(this.QRText);
            this.Font = new System.Drawing.Font("TH Sarabun New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "AddItemP1";
            this.Text = "Add your item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddItemFormClosed);
            this.Load += new System.EventHandler(this.AddItemP1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label QRText;
        private System.Windows.Forms.TextBox BarcodeText;
    }
}