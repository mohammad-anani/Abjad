namespace Abjad
{
    partial class frmAddUpdateClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdateClient));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2CirclePictureBox3 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pbimage = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.llimage = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlUpdate = new System.Windows.Forms.Panel();
            this.llcredit = new System.Windows.Forms.LinkLabel();
            this.llpassword = new System.Windows.Forms.LinkLabel();
            this.btnsave = new Abjad.StatefulButton();
            this.chkautologin = new System.Windows.Forms.CheckBox();
            this.pnlAdd = new System.Windows.Forms.Panel();
            this.txtcreditcard = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtconfirm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbimage)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlUpdate.SuspendLayout();
            this.pnlAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimationInterval = 100;
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2CirclePictureBox3
            // 
            this.guna2CirclePictureBox3.BackColor = System.Drawing.SystemColors.Control;
            this.guna2CirclePictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2CirclePictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox3.Image")));
            this.guna2CirclePictureBox3.ImageRotate = 0F;
            this.guna2CirclePictureBox3.Location = new System.Drawing.Point(3, 3);
            this.guna2CirclePictureBox3.Name = "guna2CirclePictureBox3";
            this.guna2CirclePictureBox3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox3.Size = new System.Drawing.Size(61, 55);
            this.guna2CirclePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox3.TabIndex = 3;
            this.guna2CirclePictureBox3.TabStop = false;
            this.guna2CirclePictureBox3.Click += new System.EventHandler(this.guna2CirclePictureBox3_Click);
            // 
            // pbimage
            // 
            this.pbimage.ImageRotate = 0F;
            this.pbimage.Location = new System.Drawing.Point(519, 19);
            this.pbimage.Name = "pbimage";
            this.pbimage.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbimage.Size = new System.Drawing.Size(100, 100);
            this.pbimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbimage.TabIndex = 4;
            this.pbimage.TabStop = false;
            // 
            // llimage
            // 
            this.llimage.AutoSize = true;
            this.llimage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.llimage.LinkColor = System.Drawing.Color.ForestGreen;
            this.llimage.Location = new System.Drawing.Point(503, 135);
            this.llimage.Name = "llimage";
            this.llimage.Size = new System.Drawing.Size(128, 29);
            this.llimage.TabIndex = 12;
            this.llimage.TabStop = true;
            this.llimage.Text = "Set Image";
            this.llimage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llimage_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(2, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Full Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(25, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(1, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 29);
            this.label3.TabIndex = 15;
            this.label3.Text = "Username:";
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtname.Location = new System.Drawing.Point(144, 24);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(360, 36);
            this.txtname.TabIndex = 16;
            this.txtname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // txtusername
            // 
            this.txtusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtusername.Location = new System.Drawing.Point(144, 87);
            this.txtusername.MaxLength = 30;
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(360, 36);
            this.txtusername.TabIndex = 17;
            this.txtusername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // txtaddress
            // 
            this.txtaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtaddress.Location = new System.Drawing.Point(144, 159);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(360, 231);
            this.txtaddress.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlUpdate);
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Controls.Add(this.chkautologin);
            this.panel1.Controls.Add(this.txtaddress);
            this.panel1.Controls.Add(this.txtusername);
            this.panel1.Controls.Add(this.pbimage);
            this.panel1.Controls.Add(this.txtname);
            this.panel1.Controls.Add(this.llimage);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pnlAdd);
            this.panel1.Location = new System.Drawing.Point(3, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 733);
            this.panel1.TabIndex = 19;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pnlUpdate
            // 
            this.pnlUpdate.Controls.Add(this.llcredit);
            this.pnlUpdate.Controls.Add(this.llpassword);
            this.pnlUpdate.Location = new System.Drawing.Point(3, 405);
            this.pnlUpdate.Name = "pnlUpdate";
            this.pnlUpdate.Size = new System.Drawing.Size(621, 182);
            this.pnlUpdate.TabIndex = 23;
            // 
            // llcredit
            // 
            this.llcredit.AutoSize = true;
            this.llcredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.llcredit.LinkColor = System.Drawing.Color.ForestGreen;
            this.llcredit.Location = new System.Drawing.Point(246, 36);
            this.llcredit.Name = "llcredit";
            this.llcredit.Size = new System.Drawing.Size(333, 29);
            this.llcredit.TabIndex = 22;
            this.llcredit.TabStop = true;
            this.llcredit.Text = "Change Credit Card Number";
            this.llcredit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llcredit_LinkClicked);
            // 
            // llpassword
            // 
            this.llpassword.AutoSize = true;
            this.llpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.llpassword.LinkColor = System.Drawing.Color.ForestGreen;
            this.llpassword.Location = new System.Drawing.Point(8, 36);
            this.llpassword.Name = "llpassword";
            this.llpassword.Size = new System.Drawing.Size(219, 29);
            this.llpassword.TabIndex = 21;
            this.llpassword.TabStop = true;
            this.llpassword.Text = "Change Password";
            this.llpassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llpassword_LinkClicked);
            // 
            // btnsave
            // 
            this.btnsave.Animated = true;
            this.btnsave.AutoRoundedCorners = true;
            this.btnsave.BackColor = System.Drawing.Color.Transparent;
            this.btnsave.BorderRadius = 39;
            this.btnsave.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnsave.CheckedState.FillColor = System.Drawing.Color.LimeGreen;
            this.btnsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnsave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnsave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnsave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnsave.FillColor = System.Drawing.Color.ForestGreen;
            this.btnsave.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.btnsave.ForeColor = System.Drawing.Color.Black;
            this.btnsave.ImageSize = new System.Drawing.Size(40, 40);
            this.btnsave.Location = new System.Drawing.Point(389, 631);
            this.btnsave.Name = "btnsave";
            this.btnsave.PressedColor = System.Drawing.Color.LimeGreen;
            this.btnsave.Size = new System.Drawing.Size(241, 80);
            this.btnsave.TabIndex = 22;
            this.btnsave.Text = "Save";
            this.btnsave.Click += new System.EventHandler(this.statefulButton1_Click);
            // 
            // chkautologin
            // 
            this.chkautologin.AutoSize = true;
            this.chkautologin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.chkautologin.Location = new System.Drawing.Point(16, 640);
            this.chkautologin.Name = "chkautologin";
            this.chkautologin.Size = new System.Drawing.Size(156, 33);
            this.chkautologin.TabIndex = 21;
            this.chkautologin.Text = "Auto Login";
            this.chkautologin.UseVisualStyleBackColor = true;
            this.chkautologin.CheckedChanged += new System.EventHandler(this.chkautologin_CheckedChanged);
            // 
            // pnlAdd
            // 
            this.pnlAdd.Controls.Add(this.txtcreditcard);
            this.pnlAdd.Controls.Add(this.label6);
            this.pnlAdd.Controls.Add(this.txtconfirm);
            this.pnlAdd.Controls.Add(this.label5);
            this.pnlAdd.Controls.Add(this.txtpassword);
            this.pnlAdd.Controls.Add(this.label4);
            this.pnlAdd.Location = new System.Drawing.Point(3, 396);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(621, 210);
            this.pnlAdd.TabIndex = 24;
            // 
            // txtcreditcard
            // 
            this.txtcreditcard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtcreditcard.Location = new System.Drawing.Point(183, 148);
            this.txtcreditcard.Mask = "0000-0000-0000-0000";
            this.txtcreditcard.Name = "txtcreditcard";
            this.txtcreditcard.PasswordChar = '*';
            this.txtcreditcard.Size = new System.Drawing.Size(261, 36);
            this.txtcreditcard.TabIndex = 23;
            this.txtcreditcard.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label6.Location = new System.Drawing.Point(6, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 58);
            this.label6.TabIndex = 21;
            this.label6.Text = "Credit\r\nCard Number:";
            // 
            // txtconfirm
            // 
            this.txtconfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtconfirm.Location = new System.Drawing.Point(183, 77);
            this.txtconfirm.MaxLength = 30;
            this.txtconfirm.Name = "txtconfirm";
            this.txtconfirm.PasswordChar = '*';
            this.txtconfirm.Size = new System.Drawing.Size(360, 36);
            this.txtconfirm.TabIndex = 20;
            this.txtconfirm.TextChanged += new System.EventHandler(this.txtconfirm_TextChanged);
            this.txtconfirm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtconfirm_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label5.Location = new System.Drawing.Point(9, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 58);
            this.label5.TabIndex = 19;
            this.label5.Text = "Confirm\r\nPassword:";
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtpassword.Location = new System.Drawing.Point(183, 13);
            this.txtpassword.MaxLength = 30;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(360, 36);
            this.txtpassword.TabIndex = 18;
            this.txtpassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpassword_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(9, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 29);
            this.label4.TabIndex = 17;
            this.label4.Text = "Password:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmAddUpdateClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(660, 450);
            this.Controls.Add(this.guna2CirclePictureBox3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddUpdateClient";
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbimage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlUpdate.ResumeLayout(false);
            this.pnlUpdate.PerformLayout();
            this.pnlAdd.ResumeLayout(false);
            this.pnlAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox3;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbimage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel llimage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label3;
        private StatefulButton btnsave;
        private System.Windows.Forms.CheckBox chkautologin;
        private System.Windows.Forms.Panel pnlUpdate;
        private System.Windows.Forms.LinkLabel llcredit;
        private System.Windows.Forms.LinkLabel llpassword;
        private System.Windows.Forms.Panel pnlAdd;
        private System.Windows.Forms.TextBox txtconfirm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MaskedTextBox txtcreditcard;
    }
}