using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abjad
{
    public partial class CategoryButton : Guna2Button
    {
        public CategoryButton()
        {
            InitializeComponent();
            this.Animated=true;
            this.AutoRoundedCorners=true;
            this.BorderRadius = 15;
            this.FillColor = SystemColors.Control;
            this.BorderColor = Color.ForestGreen;
            this.BorderThickness = 2;
            this.Font=new Font("Segoe UI",12,FontStyle.Bold);
            this.AutoSize = true;
            this.ForeColor = Color.ForestGreen;
            this.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.CheckedChanged += CategoryButton_CheckedChanged;
            this.CheckedState.ForeColor = SystemColors.Control;
            this.CheckedState.FillColor = Color.ForestGreen;
            this.Click += CategoryButton_Click;
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel flowLayoutPanel=this.Parent as FlowLayoutPanel;
            foreach(Control c in flowLayoutPanel.Controls)
            {
                CategoryButton categoryButton=c as CategoryButton;
                if(categoryButton != this)
                {
                    categoryButton.Checked= false;
                }
            }
        }

        private void CategoryButton_CheckedChanged(object sender, EventArgs e)
        {
           if(this.Checked)
            {
                this.CheckedState.ForeColor = SystemColors.Control;
                this.CheckedState.FillColor = Color.ForestGreen;
            }
            else
            {
                this.FillColor = SystemColors.Control;
                this.ForeColor = Color.ForestGreen;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

      
    }
}
