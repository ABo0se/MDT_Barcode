namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    partial class Search
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
            this.BarcodeID = new System.Windows.Forms.Label();
            this.BarcodeText = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BarcodeID
            // 
            this.BarcodeID.AutoSize = true;
            this.BarcodeID.Font = new System.Drawing.Font("TH Sarabun New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BarcodeID.Location = new System.Drawing.Point(12, 16);
            this.BarcodeID.Name = "BarcodeID";
            this.BarcodeID.Size = new System.Drawing.Size(89, 27);
            this.BarcodeID.TabIndex = 0;
            this.BarcodeID.Text = "Barcode-ID : ";
            // 
            // BarcodeText
            // 
            this.BarcodeText.Location = new System.Drawing.Point(99, 18);
            this.BarcodeText.Name = "BarcodeText";
            this.BarcodeText.Size = new System.Drawing.Size(408, 23);
            this.BarcodeText.TabIndex = 1;
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("TH Sarabun New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.SearchButton.Location = new System.Drawing.Point(513, 17);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(94, 26);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 53);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.BarcodeText);
            this.Controls.Add(this.BarcodeID);
            this.Name = "Search";
            this.Text = "Search barcode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BarcodeID;
        private System.Windows.Forms.TextBox BarcodeText;
        private System.Windows.Forms.Button SearchButton;
    }
}