namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    partial class MainMenu
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
            this.AddItem = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.Manage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddItem
            // 
            this.AddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddItem.AutoSize = true;
            this.AddItem.Font = new System.Drawing.Font("Garena_Onmyoji_UI1", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.AddItem.Location = new System.Drawing.Point(12, 12);
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(777, 110);
            this.AddItem.TabIndex = 0;
            this.AddItem.Text = "Add Item";
            this.AddItem.UseVisualStyleBackColor = true;
            this.AddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // Search
            // 
            this.Search.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Search.AutoSize = true;
            this.Search.Font = new System.Drawing.Font("Garena_Onmyoji_UI1", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Search.Location = new System.Drawing.Point(13, 128);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(777, 110);
            this.Search.TabIndex = 1;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Manage
            // 
            this.Manage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Manage.AutoSize = true;
            this.Manage.Font = new System.Drawing.Font("Garena_Onmyoji_UI1", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Manage.Location = new System.Drawing.Point(13, 244);
            this.Manage.Name = "Manage";
            this.Manage.Size = new System.Drawing.Size(777, 110);
            this.Manage.TabIndex = 2;
            this.Manage.Text = "Manage";
            this.Manage.UseVisualStyleBackColor = true;
            this.Manage.Click += new System.EventHandler(this.Manage_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 368);
            this.Controls.Add(this.Manage);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.AddItem);
            this.Name = "MainMenu";
            this.Text = "MDT Inventory";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Exit_Application);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddItem;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button Manage;
    }
}