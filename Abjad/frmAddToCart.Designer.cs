namespace Abjad
{
    partial class frmAddToCart
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddToCart));
            this.ctrlGuestSignIn1 = new Abjad.ctrlGuestSignIn();
            this.guna2CirclePictureBox3 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlclient = new System.Windows.Forms.Panel();
            this.btnadd = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudquty = new System.Windows.Forms.NumericUpDown();
            this.lbltotal = new System.Windows.Forms.Label();
            this.ctrlItemDetails1 = new Abjad.ctrlItemDetails();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlclient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudquty)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlGuestSignIn1
            // 
            this.ctrlGuestSignIn1.Location = new System.Drawing.Point(40, 65);
            this.ctrlGuestSignIn1.Name = "ctrlGuestSignIn1";
            this.ctrlGuestSignIn1.Size = new System.Drawing.Size(629, 427);
            this.ctrlGuestSignIn1.TabIndex = 0;
            this.ctrlGuestSignIn1.OnSignIn += new System.Action<AbjadBusiness.clsClient>(this.ctrlGuestSignIn1_OnSignIn);
            this.ctrlGuestSignIn1.Load += new System.EventHandler(this.ctrlGuestSignIn1_Load);
            // 
            // guna2CirclePictureBox3
            // 
            this.guna2CirclePictureBox3.BackColor = System.Drawing.SystemColors.Control;
            this.guna2CirclePictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2CirclePictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox3.Image")));
            this.guna2CirclePictureBox3.ImageRotate = 0F;
            this.guna2CirclePictureBox3.Location = new System.Drawing.Point(0, 1);
            this.guna2CirclePictureBox3.Name = "guna2CirclePictureBox3";
            this.guna2CirclePictureBox3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox3.Size = new System.Drawing.Size(61, 55);
            this.guna2CirclePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox3.TabIndex = 3;
            this.guna2CirclePictureBox3.TabStop = false;
            this.guna2CirclePictureBox3.Click += new System.EventHandler(this.guna2CirclePictureBox3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlclient);
            this.panel1.Controls.Add(this.ctrlItemDetails1);
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 430);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // pnlclient
            // 
            this.pnlclient.Controls.Add(this.btnadd);
            this.pnlclient.Controls.Add(this.label1);
            this.pnlclient.Controls.Add(this.nudquty);
            this.pnlclient.Controls.Add(this.lbltotal);
            this.pnlclient.Location = new System.Drawing.Point(3, 263);
            this.pnlclient.Name = "pnlclient";
            this.pnlclient.Size = new System.Drawing.Size(726, 155);
            this.pnlclient.TabIndex = 5;
            // 
            // btnadd
            // 
            this.btnadd.Animated = true;
            this.btnadd.AutoRoundedCorners = true;
            this.btnadd.BorderRadius = 33;
            this.btnadd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnadd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnadd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnadd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnadd.FillColor = System.Drawing.Color.ForestGreen;
            this.btnadd.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnadd.ForeColor = System.Drawing.Color.Black;
            this.btnadd.Location = new System.Drawing.Point(486, 84);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(218, 68);
            this.btnadd.TabIndex = 1;
            this.btnadd.Text = "Add To Cart";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Quantity:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nudquty
            // 
            this.nudquty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.nudquty.Location = new System.Drawing.Point(144, 16);
            this.nudquty.Name = "nudquty";
            this.nudquty.Size = new System.Drawing.Size(120, 36);
            this.nudquty.TabIndex = 2;
            this.nudquty.ValueChanged += new System.EventHandler(this.nudquty_ValueChanged);
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lbltotal.Location = new System.Drawing.Point(14, 86);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(139, 29);
            this.lbltotal.TabIndex = 3;
            this.lbltotal.Text = "Total:00.00";
            this.lbltotal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ctrlItemDetails1
            // 
            this.ctrlItemDetails1.Location = new System.Drawing.Point(0, 3);
            this.ctrlItemDetails1.Mode = Abjad.ctrlItemDetails.enMode.Read;
            this.ctrlItemDetails1.Name = "ctrlItemDetails1";
            this.ctrlItemDetails1.Size = new System.Drawing.Size(707, 270);
            this.ctrlItemDetails1.TabIndex = 0;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimationInterval = 100;
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // frmAddToCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 492);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2CirclePictureBox3);
            this.Controls.Add(this.ctrlGuestSignIn1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddToCart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddToCart";
            this.Load += new System.EventHandler(this.frmAddToCart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlclient.ResumeLayout(false);
            this.pnlclient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudquty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlGuestSignIn ctrlGuestSignIn1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox3;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private ctrlItemDetails ctrlItemDetails1;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.NumericUpDown nudquty;
        private Guna.UI2.WinForms.Guna2Button btnadd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlclient;
    }
}