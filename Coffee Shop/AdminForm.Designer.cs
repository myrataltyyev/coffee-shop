namespace Coffee_Shop
{
    partial class AdminForm
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
            this.btnUpload = new System.Windows.Forms.Button();
            this.pictureCoffee = new System.Windows.Forms.PictureBox();
            this.listViewMenu = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCoffee)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.BackColor = System.Drawing.Color.SaddleBrown;
            this.btnUpload.Font = new System.Drawing.Font("Monotype Corsiva", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpload.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnUpload.Location = new System.Drawing.Point(742, 273);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(187, 46);
            this.btnUpload.TabIndex = 12;
            this.btnUpload.Text = "Upload image";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // pictureCoffee
            // 
            this.pictureCoffee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureCoffee.BackColor = System.Drawing.Color.SaddleBrown;
            this.pictureCoffee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureCoffee.Location = new System.Drawing.Point(742, 51);
            this.pictureCoffee.Name = "pictureCoffee";
            this.pictureCoffee.Size = new System.Drawing.Size(187, 206);
            this.pictureCoffee.TabIndex = 11;
            this.pictureCoffee.TabStop = false;
            // 
            // listViewMenu
            // 
            this.listViewMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewMenu.BackColor = System.Drawing.Color.Bisque;
            this.listViewMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listViewMenu.FullRowSelect = true;
            this.listViewMenu.GridLines = true;
            this.listViewMenu.Location = new System.Drawing.Point(38, 51);
            this.listViewMenu.Name = "listViewMenu";
            this.listViewMenu.Size = new System.Drawing.Size(672, 268);
            this.listViewMenu.TabIndex = 10;
            this.listViewMenu.UseCompatibleStateImageBehavior = false;
            this.listViewMenu.View = System.Windows.Forms.View.Details;
            this.listViewMenu.SelectedIndexChanged += new System.EventHandler(this.ListViewMenu_SelectedIndexChanged);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(975, 377);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.pictureCoffee);
            this.Controls.Add(this.listViewMenu);
            this.Name = "AdminForm";
            this.Text = "Admin Panel";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCoffee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.PictureBox pictureCoffee;
        private System.Windows.Forms.ListView listViewMenu;
    }
}