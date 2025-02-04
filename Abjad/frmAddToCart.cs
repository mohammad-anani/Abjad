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
    public partial class frmAddToCart : Form
    {
        public clsItem Item =new clsItem();
        public frmAddToCart(clsItem item,bool isloggedin)
        {
            InitializeComponent();
            pnlclient.Visible = true;
            Item=item;
            if(isloggedin)
            {
                panel1.Visible = true;
                pnlclient.Visible = true;
                ctrlItemDetails1.Item = item;
                ctrlItemDetails1.FillCbcategories();
                ctrlItemDetails1.FillReadUpdateInfo();
            }
            else
                panel1.Visible=false;
        }

        public frmAddToCart(clsItem item,int quty)
        {
            InitializeComponent();
            Item = item;
            panel1.Visible = true;
            pnlclient.Visible=true;
            ctrlItemDetails1.Item = item;
            ctrlItemDetails1.FillCbcategories();
            ctrlItemDetails1.FillReadUpdateInfo();
            nudquty.Value = quty;
            

        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlGuestSignIn1_Load(object sender, EventArgs e)
        {

        }

        public delegate void OnSignIn(clsClient client);
        public event OnSignIn Signin;

        void FillInfoOnSignIn(clsClient client)
        {
            panel1.Visible = true;
            ctrlItemDetails1.Item = Item;
            ctrlItemDetails1.FillCbcategories();
            ctrlItemDetails1.FillReadUpdateInfo();
            Signin?.Invoke(client);
        }

        private void ctrlGuestSignIn1_OnSignIn(AbjadBusiness.clsClient obj)
        {
            FillInfoOnSignIn(obj);
        }

        private void frmAddToCart_Load(object sender, EventArgs e)
        {
            nudquty.Maximum = Item.Stock;
        }

        private void nudquty_ValueChanged(object sender, EventArgs e)
        {
            lbltotal.Text = "Total:" + ((Item.Price * (1 - Item.Discount)) * (double)nudquty.Value) + "$";
        }


        public delegate void OnAddToCart(clsItem item, int quty);
        public event OnAddToCart AddtoCart;

        private void btnadd_Click(object sender, EventArgs e)
        {
            if(nudquty.Value==0)
            {
                MessageBox.Show("Please Select A Quantity","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddtoCart?.Invoke(Item, (int)nudquty.Value);
            MessageBox.Show("Item Successfully Added To Cart.","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }
    }
}
