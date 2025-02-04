using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Abjad
{
    public partial class StatefulButton : Guna2Button
    {
        public StatefulButton()
        {
            InitializeComponent();
            this.BackColor = Color.Transparent;
            this.FillColor = Color.ForestGreen;
            this.Font = new Font("Segoe UI", 20);
            this.ForeColor = Color.Black;
            this.Size = new Size(330, 100);
            this.AutoRoundedCorners = true;
            this.ButtonMode = ButtonMode.ToogleButton;
            this.BorderRadius = 15;
            this.CheckedState.FillColor = Color.LimeGreen;
            this.Animated = true;
            this.PressedColor = Color.LimeGreen;
            this.CheckedChanged += StatefulButton_CheckedChanged;
            this.ImageSize = new Size(40, 40);
            this.Cursor = Cursors.Hand;
            
           
        }

        
        private void StatefulButton_CheckedChanged(object sender, EventArgs e)
        {
           if(this.Checked)
            {
                this.FillColor = Color.LimeGreen;
            }
           else
            {
                
                    this.FillColor = Color.ForestGreen;
                
                    
            }
        }


        
    }
}
