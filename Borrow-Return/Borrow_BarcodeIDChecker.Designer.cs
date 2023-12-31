﻿namespace USB_Barcode_Scanner_Tutorial___C_Sharp.Borrow_Return
{
    partial class Borrow_BarcodeIDChecker
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SearchButton = new System.Windows.Forms.Button();
            this.BarcodeID = new System.Windows.Forms.Label();
            this.BarcodeText = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ShowDetail_B = new System.Windows.Forms.Button();
            this.Borrow_Management_B = new System.Windows.Forms.Button();
            this.Return_Management_B = new System.Windows.Forms.Button();
            this.Status_TXT = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.SearchButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.BarcodeID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BarcodeText, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(552, 50);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.SearchButton.Location = new System.Drawing.Point(442, 4);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(108, 41);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "ค้นหา";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // BarcodeID
            // 
            this.BarcodeID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BarcodeID.AutoSize = true;
            this.BarcodeID.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.BarcodeID.Location = new System.Drawing.Point(2, 7);
            this.BarcodeID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BarcodeID.Name = "BarcodeID";
            this.BarcodeID.Size = new System.Drawing.Size(173, 36);
            this.BarcodeID.TabIndex = 0;
            this.BarcodeID.Text = "หมายเลขครุภัณฑ์ :";
            // 
            // BarcodeText
            // 
            this.BarcodeText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BarcodeText.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.BarcodeText.Location = new System.Drawing.Point(179, 3);
            this.BarcodeText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BarcodeText.Name = "BarcodeText";
            this.BarcodeText.Size = new System.Drawing.Size(259, 43);
            this.BarcodeText.TabIndex = 1;
            this.BarcodeText.TextChanged += new System.EventHandler(this.BarcodeText_TextChanged);
            this.BarcodeText.Enter += new System.EventHandler(this.BarcodeText_Enter);
            this.BarcodeText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BarcodeText_KeyDown);
            this.BarcodeText.Leave += new System.EventHandler(this.BarcodeText_Leave);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.Status_TXT, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(558, 168);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.ShowDetail_B, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Borrow_Management_B, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.Return_Management_B, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 115);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(552, 50);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // ShowDetail_B
            // 
            this.ShowDetail_B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowDetail_B.Enabled = false;
            this.ShowDetail_B.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.ShowDetail_B.Location = new System.Drawing.Point(5, 4);
            this.ShowDetail_B.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ShowDetail_B.Name = "ShowDetail_B";
            this.ShowDetail_B.Size = new System.Drawing.Size(174, 41);
            this.ShowDetail_B.TabIndex = 0;
            this.ShowDetail_B.Text = "ดูรายละเอียด";
            this.ShowDetail_B.UseVisualStyleBackColor = true;
            this.ShowDetail_B.Click += new System.EventHandler(this.ShowDetail_B_Click);
            // 
            // Borrow_Management_B
            // 
            this.Borrow_Management_B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Borrow_Management_B.Enabled = false;
            this.Borrow_Management_B.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.Borrow_Management_B.Location = new System.Drawing.Point(189, 4);
            this.Borrow_Management_B.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Borrow_Management_B.Name = "Borrow_Management_B";
            this.Borrow_Management_B.Size = new System.Drawing.Size(174, 41);
            this.Borrow_Management_B.TabIndex = 2;
            this.Borrow_Management_B.Text = "ยืมครุภัณฑ์";
            this.Borrow_Management_B.UseVisualStyleBackColor = true;
            this.Borrow_Management_B.Click += new System.EventHandler(this.Borrow_Management_B_Click);
            // 
            // Return_Management_B
            // 
            this.Return_Management_B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Return_Management_B.Enabled = false;
            this.Return_Management_B.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.Return_Management_B.Location = new System.Drawing.Point(373, 4);
            this.Return_Management_B.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Return_Management_B.Name = "Return_Management_B";
            this.Return_Management_B.Size = new System.Drawing.Size(174, 41);
            this.Return_Management_B.TabIndex = 6;
            this.Return_Management_B.Text = "คืนครุภัณฑ์";
            this.Return_Management_B.UseVisualStyleBackColor = true;
            this.Return_Management_B.Click += new System.EventHandler(this.Return_Management_B_Click);
            // 
            // Status_TXT
            // 
            this.Status_TXT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Status_TXT.AutoSize = true;
            this.Status_TXT.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.Status_TXT.Location = new System.Drawing.Point(231, 56);
            this.Status_TXT.Margin = new System.Windows.Forms.Padding(0);
            this.Status_TXT.Name = "Status_TXT";
            this.Status_TXT.Size = new System.Drawing.Size(95, 56);
            this.Status_TXT.TabIndex = 6;
            this.Status_TXT.Text = "สถานะ : -";
            this.Status_TXT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Borrow_BarcodeIDChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(582, 193);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Font = new System.Drawing.Font("TH Sarabun New", 16F);
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "Borrow_BarcodeIDChecker";
            this.Text = "ค้นหาครุภัณฑ์ที่ต้องการ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Borrow_BarcodeIDChecker_FormClosing);
            this.Load += new System.EventHandler(this.Borrow_BarcodeIDChecker_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label BarcodeID;
        private System.Windows.Forms.TextBox BarcodeText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label Status_TXT;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button ShowDetail_B;
        private System.Windows.Forms.Button Borrow_Management_B;
        private System.Windows.Forms.Button Return_Management_B;
    }
}