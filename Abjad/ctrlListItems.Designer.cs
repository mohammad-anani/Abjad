namespace Abjad
{
    partial class ctrlListItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlListItems));
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.flpCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.flpItems = new System.Windows.Forms.FlowLayoutPanel();
            this.lblpage = new System.Windows.Forms.Label();
            this.lbltotalpages = new System.Windows.Forms.Label();
            this.pbforward = new System.Windows.Forms.PictureBox();
            this.pbbackward = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbforward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbbackward)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.Animated = true;
            this.guna2TextBox1.AutoRoundedCorners = true;
            this.guna2TextBox1.BorderRadius = 19;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.guna2TextBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.IconRight = ((System.Drawing.Image)(resources.GetObject("guna2TextBox1.IconRight")));
            this.guna2TextBox1.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.guna2TextBox1.IconRightOffset = new System.Drawing.Point(10, 0);
            this.guna2TextBox1.IconRightSize = new System.Drawing.Size(25, 25);
            this.guna2TextBox1.Location = new System.Drawing.Point(5, 27);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderText = "Search";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(340, 41);
            this.guna2TextBox1.TabIndex = 1;
            this.guna2TextBox1.TextOffset = new System.Drawing.Point(10, 0);
            this.guna2TextBox1.IconRightClick += new System.EventHandler(this.guna2TextBox1_IconRightClick);
            this.guna2TextBox1.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            this.guna2TextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.guna2TextBox1_KeyDown);
            // 
            // flpCategories
            // 
            this.flpCategories.AutoScroll = true;
            this.flpCategories.Location = new System.Drawing.Point(0, 78);
            this.flpCategories.Name = "flpCategories";
            this.flpCategories.Size = new System.Drawing.Size(654, 115);
            this.flpCategories.TabIndex = 2;
            this.flpCategories.Paint += new System.Windows.Forms.PaintEventHandler(this.flpCategories_Paint);
            // 
            // flpItems
            // 
            this.flpItems.AutoScroll = true;
            this.flpItems.Location = new System.Drawing.Point(3, 199);
            this.flpItems.Name = "flpItems";
            this.flpItems.Size = new System.Drawing.Size(651, 515);
            this.flpItems.TabIndex = 3;
            this.flpItems.Paint += new System.Windows.Forms.PaintEventHandler(this.flpItems_Paint);
            // 
            // lblpage
            // 
            this.lblpage.AutoSize = true;
            this.lblpage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblpage.Location = new System.Drawing.Point(417, 726);
            this.lblpage.Name = "lblpage";
            this.lblpage.Size = new System.Drawing.Size(55, 39);
            this.lblpage.TabIndex = 4;
            this.lblpage.Text = "00";
            // 
            // lbltotalpages
            // 
            this.lbltotalpages.AutoSize = true;
            this.lbltotalpages.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lbltotalpages.Location = new System.Drawing.Point(580, 726);
            this.lbltotalpages.Name = "lbltotalpages";
            this.lbltotalpages.Size = new System.Drawing.Size(55, 39);
            this.lbltotalpages.TabIndex = 5;
            this.lbltotalpages.Text = "00";
            // 
            // pbforward
            // 
            this.pbforward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbforward.Image = ((System.Drawing.Image)(resources.GetObject("pbforward.Image")));
            this.pbforward.Location = new System.Drawing.Point(529, 720);
            this.pbforward.Name = "pbforward";
            this.pbforward.Size = new System.Drawing.Size(45, 50);
            this.pbforward.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbforward.TabIndex = 6;
            this.pbforward.TabStop = false;
            this.pbforward.Click += new System.EventHandler(this.pbforward_Click);
            // 
            // pbbackward
            // 
            this.pbbackward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbbackward.Image = ((System.Drawing.Image)(resources.GetObject("pbbackward.Image")));
            this.pbbackward.Location = new System.Drawing.Point(478, 720);
            this.pbbackward.Name = "pbbackward";
            this.pbbackward.Size = new System.Drawing.Size(45, 50);
            this.pbbackward.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbbackward.TabIndex = 7;
            this.pbbackward.TabStop = false;
            this.pbbackward.Click += new System.EventHandler(this.pbbackward_Click);
            // 
            // ctrlListItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbbackward);
            this.Controls.Add(this.pbforward);
            this.Controls.Add(this.lbltotalpages);
            this.Controls.Add(this.lblpage);
            this.Controls.Add(this.flpItems);
            this.Controls.Add(this.flpCategories);
            this.Controls.Add(this.guna2TextBox1);
            this.Name = "ctrlListItems";
            this.Size = new System.Drawing.Size(654, 780);
            this.Load += new System.EventHandler(this.ctrlListItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbforward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbbackward)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private System.Windows.Forms.FlowLayoutPanel flpCategories;
        private System.Windows.Forms.FlowLayoutPanel flpItems;
        private System.Windows.Forms.Label lblpage;
        private System.Windows.Forms.Label lbltotalpages;
        private System.Windows.Forms.PictureBox pbforward;
        private System.Windows.Forms.PictureBox pbbackward;
    }
}
