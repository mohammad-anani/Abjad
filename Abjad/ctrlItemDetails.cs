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
    public partial class ctrlItemDetails : UserControl
    {
        public ctrlItemDetails()
        {
            InitializeComponent();
        }

        public clsItem Item=new clsItem();

        public enum enMode { Read,Update,Add};

        private enMode _Mode=enMode.Read;
        public enMode Mode
        {
            get { return _Mode; }
            set
            {
                _Mode = value;
                switch (_Mode)
                {

                    case enMode.Read:
                        lblname.Visible = true;
                        lbldesc.Visible = true;
                        lblcat.Visible = true;
                        lbldiscount.Visible = true;
                        lblprice.Visible = true;
                        txtname.Visible = false;
                        txtdesc.Visible = false;
                        txtprice.Visible = false;
                        cbcat.Visible = false;
                        numericUpDown1.Visible = false;
                        llimage.Visible = false;
                        break;
                    case enMode.Add:
                    case enMode.Update:
                        lblname.Visible = false;
                        lbldesc.Visible = false;
                        lblcat.Visible = false;
                        lbldiscount.Visible = false;
                        lblprice.Visible = false;
                        txtname.Visible = true;
                        txtdesc.Visible = true;
                        txtprice.Visible = true;
                        cbcat.Visible = true;
                        numericUpDown1.Visible = true;
                        llimage.Visible = true;
                        break;
                }
                
            }

        } 

        public void FillCbcategories()
        {
            foreach (DataRow row in clsCategory.ListCategories().Rows)
            {
                cbcat.Items.Add(row[0].ToString());
            }
            cbcat.SelectedIndex = 0;
        }
        public void FillReadUpdateInfo()
        {

            lblname.Text = Item.Name;
            lbldesc.Text = Item.Description;
            lblcat.Text = Item.Category.Name;
            lbldiscount.Text = (Item.Discount * 100).ToString()+"%";
            lblprice.Text = Item.Price + "$";
            lblfinalprice.Text = Item.Price - Item.Price * Item.Discount + "$";
            pbimage.ImageLocation = Item.ImagePath;

            txtname.Text = Item.Name;
            txtdesc.Text = Item.Description;
            cbcat.SelectedIndex = cbcat.Items.IndexOf(Item.Category.Name);
            numericUpDown1.Value = (decimal)Item.Discount *100;
            txtprice.Text = Item.Price + "$";
        }

        private void lbldesc_Click(object sender, EventArgs e)
        {

        }
    }
}
