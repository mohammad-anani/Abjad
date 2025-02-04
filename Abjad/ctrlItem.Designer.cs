namespace Abjad
{
    partial class ctrlItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlItem));
            this.pbimage = new System.Windows.Forms.PictureBox();
            this.lblname = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblprice = new System.Windows.Forms.Label();
            this.lbldiscountedprice = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblpoutofstock = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pbimage
            // 
            this.pbimage.Location = new System.Drawing.Point(3, 3);
            this.pbimage.Name = "pbimage";
            this.pbimage.Size = new System.Drawing.Size(194, 150);
            this.pbimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbimage.TabIndex = 0;
            this.pbimage.TabStop = false;
            this.pbimage.Click += new System.EventHandler(this.pbimage_Click);
            // 
            // lblname
            // 
            this.lblname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(3, 156);
            this.lblname.MaximumSize = new System.Drawing.Size(194, 50);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(145, 50);
            this.lblname.TabIndex = 1;
            this.lblname.Text = "Item\r\nName";
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // lblprice
            // 
            this.lblprice.AutoSize = true;
            this.lblprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblprice.Location = new System.Drawing.Point(-2, 215);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(104, 29);
            this.lblprice.TabIndex = 2;
            this.lblprice.Text = "000.00$";
            // 
            // lbldiscountedprice
            // 
            this.lbldiscountedprice.AutoSize = true;
            this.lbldiscountedprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lbldiscountedprice.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbldiscountedprice.Location = new System.Drawing.Point(100, 215);
            this.lbldiscountedprice.Name = "lbldiscountedprice";
            this.lbldiscountedprice.Size = new System.Drawing.Size(104, 29);
            this.lbldiscountedprice.TabIndex = 3;
            this.lbldiscountedprice.Text = "000.00$";
            this.lbldiscountedprice.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(154, 155);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 51);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // lblpoutofstock
            // 
            this.lblpoutofstock.Font = new System.Drawing.Font("Microsoft Tai Le", 15F);
            this.lblpoutofstock.Location = new System.Drawing.Point(3, 209);
            this.lblpoutofstock.Name = "lblpoutofstock";
            this.lblpoutofstock.Size = new System.Drawing.Size(194, 45);
            this.lblpoutofstock.TabIndex = 5;
            this.lblpoutofstock.Text = "Out Of Stock!";
            this.lblpoutofstock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblpoutofstock.Visible = false;
            // 
            // ctrlItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblpoutofstock);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbldiscountedprice);
            this.Controls.Add(this.lblprice);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.pbimage);
            this.Name = "ctrlItem";
            this.Size = new System.Drawing.Size(200, 254);
            this.Load += new System.EventHandler(this.ctrlItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbimage;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblprice;
        private System.Windows.Forms.Label lbldiscountedprice;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblpoutofstock;
    }
}
