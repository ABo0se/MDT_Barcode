namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    partial class Settings
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
            this.Change_Pic_Container = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.DefaultPath = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.FilePath_TXT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Repair = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Change_Pic_Container
            // 
            this.Change_Pic_Container.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Change_Pic_Container.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.Change_Pic_Container.Location = new System.Drawing.Point(187, 3);
            this.Change_Pic_Container.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Change_Pic_Container.Name = "Change_Pic_Container";
            this.Change_Pic_Container.Size = new System.Drawing.Size(181, 38);
            this.Change_Pic_Container.TabIndex = 2;
            this.Change_Pic_Container.Text = "เปลี่ยนที่เก็บภาพ";
            this.Change_Pic_Container.UseVisualStyleBackColor = true;
            this.Change_Pic_Container.Click += new System.EventHandler(this.Change_Pic_Container_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(710, 200);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.DefaultPath, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Change_Pic_Container, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 53);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(370, 44);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // DefaultPath
            // 
            this.DefaultPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DefaultPath.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.DefaultPath.Location = new System.Drawing.Point(2, 3);
            this.DefaultPath.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DefaultPath.Name = "DefaultPath";
            this.DefaultPath.Size = new System.Drawing.Size(181, 38);
            this.DefaultPath.TabIndex = 6;
            this.DefaultPath.Text = "กลับสู่ค่าเดิม";
            this.DefaultPath.UseVisualStyleBackColor = true;
            this.DefaultPath.Click += new System.EventHandler(this.DefaultPath_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.FilePath_TXT, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(704, 44);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // FilePath_TXT
            // 
            this.FilePath_TXT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FilePath_TXT.AutoSize = true;
            this.FilePath_TXT.Font = new System.Drawing.Font("TH Sarabun New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilePath_TXT.Location = new System.Drawing.Point(131, 3);
            this.FilePath_TXT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FilePath_TXT.Name = "FilePath_TXT";
            this.FilePath_TXT.Size = new System.Drawing.Size(571, 37);
            this.FilePath_TXT.TabIndex = 4;
            this.FilePath_TXT.Text = "-";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(2, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "ที่อยู่ไฟล์ภาพ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(2, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(706, 36);
            this.label2.TabIndex = 6;
            this.label2.Text = "การจัดการข้อมูลในฐานข้อมูล";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.Repair, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 153);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(183, 44);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // Repair
            // 
            this.Repair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Repair.Font = new System.Drawing.Font("TH Sarabun New", 16F, System.Drawing.FontStyle.Bold);
            this.Repair.Location = new System.Drawing.Point(2, 3);
            this.Repair.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Repair.Name = "Repair";
            this.Repair.Size = new System.Drawing.Size(179, 38);
            this.Repair.TabIndex = 6;
            this.Repair.Text = "ซ่อมแซมข้อมูล";
            this.Repair.UseVisualStyleBackColor = true;
            this.Repair.Click += new System.EventHandler(this.Repair_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(732, 218);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Settings";
            this.Text = "การตั้งค่า";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Search_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Change_Pic_Container;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button DefaultPath;
        private System.Windows.Forms.Label FilePath_TXT;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button Repair;
        private System.Windows.Forms.Label label2;
    }
}