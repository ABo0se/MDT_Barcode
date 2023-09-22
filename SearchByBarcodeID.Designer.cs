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
            this.BarcodeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BarcodeID.Location = new System.Drawing.Point(9, 18);
            this.BarcodeID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BarcodeID.Name = "BarcodeID";
            this.BarcodeID.Size = new System.Drawing.Size(127, 25);
            this.BarcodeID.TabIndex = 0;
            this.BarcodeID.Text = "Barcode-ID : ";
            // 
            // BarcodeText
            // 
            this.BarcodeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BarcodeText.Location = new System.Drawing.Point(97, 15);
            this.BarcodeText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BarcodeText.Name = "BarcodeText";
            this.BarcodeText.Size = new System.Drawing.Size(267, 30);
            this.BarcodeText.TabIndex = 1;
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.SearchButton.Location = new System.Drawing.Point(366, 16);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(68, 34);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // Search
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(441, 66);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.BarcodeText);
            this.Controls.Add(this.BarcodeID);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Search";
            this.Text = "Search barcode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.Search_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BarcodeID;
        private System.Windows.Forms.TextBox BarcodeText;
        private System.Windows.Forms.Button SearchButton;
    }
}