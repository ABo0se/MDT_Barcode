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
            this.SuspendLayout();
            // 
            // QRText
            // 
            this.QRText.AutoSize = true;
            this.QRText.Font = new System.Drawing.Font("Garena_Onmyoji_UI1", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.QRText.Location = new System.Drawing.Point(18, 22);
            this.QRText.Name = "QRText";
            this.QRText.Size = new System.Drawing.Size(318, 17);
            this.QRText.TabIndex = 0;
            this.QRText.Text = "Please kindly scan barcode on your desired product.";
            this.QRText.Click += new System.EventHandler(this.QRText_Click);
            // 
            // AddItemP1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 55);
            this.Controls.Add(this.QRText);
            this.Name = "AddItemP1";
            this.Text = "Add your item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label QRText;
    }
}