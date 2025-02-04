using AbjadBusiness;
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
    public partial class ctrlItem : UserControl
    {
        public clsItem Item=new clsItem();
        public ctrlItem()
        {
            InitializeComponent();
        }

        private void ctrlItem_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(lblname, lblname.Text);
        }

        public void FillItem()
        {
            if(Item.Stock==0)
            {
                lblpoutofstock.Visible = true;
                pictureBox2.Visible = false;
            }
            pbimage.ImageLocation = Item.ImagePath;
            lblname.Text = Item.Name;
            lblprice.Text = Item.Price.ToString("0.00")+"$";

            if(Item.Discount>0)
            {
                lblprice.Font = new Font("Segou UI", 15, FontStyle.Strikeout);
                lblprice.Text = Item.Price.ToString("0.00")+"$";
                lbldiscountedprice.Visible = true;
                lbldiscountedprice.Text = (Item.Price - Item.Price * Item.Discount).ToString("0.00")+"$";
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
           
        }

        public event Action<clsItem> OnClickToPurchase;
        protected virtual void ClickToPurchase(clsItem item)
        {
            OnClickToPurchase?.Invoke(item);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ClickToPurchase(Item);
        }

        private void pbimage_Click(object sender, EventArgs e)
        {

        }
    }
}
