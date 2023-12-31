﻿namespace USB_Barcode_Scanner_Tutorial___C_Sharp
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BarcodeID
            // 
            this.BarcodeID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BarcodeID.AutoSize = true;
            this.BarcodeID.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.BarcodeID.Location = new System.Drawing.Point(2, 12);
            this.BarcodeID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BarcodeID.Name = "BarcodeID";
            this.BarcodeID.Size = new System.Drawing.Size(173, 36);
            this.BarcodeID.TabIndex = 0;
            this.BarcodeID.Text = "หมายเลขครุภัณฑ์ :";
            // 
            // BarcodeText
            // 
            this.BarcodeText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BarcodeText.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.BarcodeText.Location = new System.Drawing.Point(179, 8);
            this.BarcodeText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BarcodeText.Name = "BarcodeText";
            this.BarcodeText.Size = new System.Drawing.Size(315, 43);
            this.BarcodeText.TabIndex = 1;
            this.BarcodeText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BarcodeText_KeyDown);
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.SearchButton.Location = new System.Drawing.Point(498, 9);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(108, 41);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "ค้นหา";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(608, 60);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(632, 73);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Search";
            this.Text = "ค้นหาครุภัณฑ์";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.Search_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label BarcodeID;
        private System.Windows.Forms.TextBox BarcodeText;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}