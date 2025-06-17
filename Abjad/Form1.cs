using Abjad.Properties;
using AbjadBusiness;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abjad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        clsClient CurrentClient = new clsClient();

        DataTable MyCart = new DataTable();

        int historypage = 0;
        int totalhistorypages = 0;
        double totalprice = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
           


            ctrlListItems1.FillCategories();
            ctrlListItems1.FillItems();
            statefulButton6.Checked = true;
            MyCart.Columns.Add("ItemID", typeof(int));
            MyCart.Columns.Add("Name", typeof(string));
            MyCart.Columns.Add("Qty", typeof(int));
            MyCart.Columns.Add("Price", typeof(double));

            string username = Registry.GetValue("HKEY_Current_User\\SOFTWARE\\Abjad", "Username", null) as string;
            string password = Registry.GetValue("HKEY_Current_User\\SOFTWARE\\Abjad", "Password", null) as string;

            if (username != null && password != null)
            {
                CurrentClient = clsClient.FindClientByUsernameAndPassword(username, password);
                FillSignedInClientInfo(CurrentClient);
            }


            List<clsItem> Items = clsItem.GetHomeItemsList();
            List<ctrlItem> ctrlItems = new List<ctrlItem>();
            ctrlItems.Add(ctrlItem1);ctrlItems.Add(ctrlItem2);ctrlItems.Add(ctrlItem3);
            ctrlItems.Add(ctrlItem4);ctrlItems.Add(ctrlItem5);ctrlItems.Add(ctrlItem6);
       

            for(int i=0;i<Items.Count;i++)
            {
                ctrlItems[i].Item = Items[i];
                ctrlItems[i].FillItem();
                ctrlItems[i].OnClickToPurchase += ctrlListItems1_OnClickToPurchase;
            }
            ctrlPictures1.timer1.Enabled = true;
            tabControl1.SelectedIndex = 3;
            statefulButton5.PerformClick();
        }




        private void statefulButton5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            statefulButton6.Checked = false;
            statefulButton7.Checked = false;
            statefulButton8.Checked = false;
        }

        private void statefulButton6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            statefulButton5.Checked = false;
            statefulButton7.Checked = false;
            statefulButton8.Checked = false;
        }

        private void statefulButton7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            statefulButton5.Checked = false;
            statefulButton6.Checked = false;
            statefulButton8.Checked = false;
        }

        private void statefulButton8_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedIndex = 2;
            statefulButton5.Checked = false;
            statefulButton7.Checked = false;
            statefulButton6.Checked = false;
        }

        //private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        //{

        //}

        private async void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            if(MyCart.Rows.Count>0)
            {
                if (MessageBox.Show("You Still Have Items In Your Cart.Confirm Exit?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }
            guna2CirclePictureBox3.BackColor = SystemColors.Control;
            await Task.Delay(50);
            this.Close();

        }


       

        void Fillcdgvhistory()
        {
            cdgvhistory.DataSource = null;
            cdgvhistory.Columns.Clear();

            cdgvhistory.CellContentClick -= cdgvhistory_CellContentClick;

            if (totalhistorypages == historypage)
            {
                pbforward.Enabled = false;

            }
            else
                pbforward.Enabled = true;

            if (historypage <= 1)
            {
                pbbackward.Enabled = false;
            }
            else
            { pbbackward.Enabled = true; }

            lblpage.Text = historypage.ToString();
            lbltotalpages.Text = totalhistorypages.ToString();

            cdgvhistory.DataSource = clsOrder.GetOrdersList(historypage, CurrentClient.ID).DefaultView.ToTable(false, "OrderID", "Date", "TotalPrice");

            DataGridViewImageColumn newcolumn3 = new DataGridViewImageColumn();
            newcolumn3.ImageLayout = DataGridViewImageCellLayout.Zoom;
            newcolumn3.Image = Properties.Resources.Minimalist_info_Icon;
            newcolumn3.Width = 20;
            cdgvhistory.Columns.Add(newcolumn3);


            cdgvhistory.CellContentClick += cdgvhistory_CellContentClick;
            

        }

    

        void FillSignedInClientInfo(clsClient client)
        {
            CurrentClient = client;
            lblusername.Text = client.Username;
            pbmyimage.ImageLocation = "./Pictures/"+client.ImagePath;
            lleditinfo.Text = "Edit Info";

            panel1.Visible = true;
            panel2.Visible = true;

            totalhistorypages=(int)Math.Ceiling((double)clsOrder.GetOrdersTotal(CurrentClient.ID)/10.00);

            if (totalhistorypages >= 1)
            {
                historypage = 1;
                lblnorders.Visible = false;
            }
            else
                historypage = 0;

            Fillcdgvhistory();

            cdgvcart.DataSource = MyCart;

            DataGridViewImageColumn newcolumn2 = new DataGridViewImageColumn();
            newcolumn2.ImageLayout = DataGridViewImageCellLayout.Zoom;
            newcolumn2.Image = Resources.Pencil_37;
            newcolumn2.Width = 20;
            cdgvcart.Columns.Add(newcolumn2);



            DataGridViewImageColumn newcolumn1 = new DataGridViewImageColumn();
            newcolumn1.ImageLayout = DataGridViewImageCellLayout.Zoom;
            newcolumn1.Image = Resources.trash_bin_3;
            newcolumn1.Width = 20;
            cdgvcart.Columns.Add(newcolumn1);

            

        }
        private void ctrlGuestSignIn1_OnSignIn(clsClient obj)
        {
            FillSignedInClientInfo(obj);
        }

        private void ctrlListItems1_OnClickToPurchase(clsItem obj)
        {
            int index = ItemExists(obj.ID);
            if (index == -1)
            {
                frmAddToCart frm = new frmAddToCart(obj, CurrentClient.ID != -1);
                frm.Signin += ctrlGuestSignIn1_OnSignIn;
                frm.AddtoCart += Frm_AddtoCart;
                frm.ShowDialog();
            }
            else
            {

                frmAddToCart frm = new frmAddToCart(obj, Convert.ToInt32(MyCart.Rows[index][2]));
                frm.AddtoCart += Frm_AddtoCart;
                frm.Signin += ctrlGuestSignIn1_OnSignIn;
                frm.ShowDialog();
            }
            
        }

    

        int ItemExists(int id)
        {
            foreach (DataRow row in MyCart.Rows)
            {
                if (Convert.ToInt32(row[0]) == id)
                {
                    return MyCart.Rows.IndexOf(row);
                }
            }
            return -1;
        }

        private void Frm_AddtoCart(clsItem item, int quty)
        {
            int index = ItemExists(item.ID);
            if (index == -1)
            {
                MyCart.Rows.Add(item.ID, item.Name, quty, ((item.Price * (1 - item.Discount)) * (double)quty));
            }
            else
            {

                MyCart.Rows[index][2] = quty;
                MyCart.Rows[index][3] = ((item.Price * (1 - item.Discount)) * (double)quty);
            }

            UpdateTotal();
        }

        public void UpdateTotal()
        {
            totalprice = 0;
            foreach (DataRow row in MyCart.Rows)
            {
                totalprice += Convert.ToDouble(row[3]);
            }
            lbltotal.Text = "Total:" + totalprice.ToString() + "$";
        }

        bool PerformTransaction(double total,string creditcardnumber)
        {
            //simulating bank transaction
            return true;
        }

        private void pbmyimage_Click(object sender, EventArgs e)
        {
            if (!pnlprofile.Visible)
            {
                pbmyimage.BackColor = Color.Gainsboro;
               
                guna2Transition1.ShowSync(pnlprofile);
            }
            else
            {
                pbmyimage.BackColor = SystemColors.Control;
          
                guna2Transition1.HideSync(pnlprofile);
            }
           
        }

        private void lleditinfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentClient.ID == -1)
            {
                frmClientLogin frm = new frmClientLogin();
                frm.Signin += ctrlGuestSignIn1_OnSignIn;
                frm.ShowDialog();
            }
            else
            {
                frmAddUpdateClient frm=new frmAddUpdateClient(CurrentClient,false);
                frm.Updating += Frm_Update;
                frm.ShowDialog();
            }
        }

        private void Frm_Update(clsClient client)
        {
            CurrentClient= client;
            lblusername.Text= client.Username;
            pbmyimage.ImageLocation = client.ImagePath;
        }

        private void pbforward_Click(object sender, EventArgs e)
        {
            historypage++;
            Fillcdgvhistory();
        }

        private void pbbackward_Click(object sender, EventArgs e)
        {
            historypage--;
            Fillcdgvhistory();
        }

        private void cdgvhistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cdgvhistory.Columns[e.ColumnIndex] is DataGridViewImageColumn)
            {
                pbinfoimage.Location = new Point(393, 30 + 50 * e.RowIndex);
                cdgvorderdetails.DataSource = clsOrderDetail.GetOrderDetailsList(Convert.ToInt32(cdgvhistory.Rows[e.RowIndex].Cells[e.ColumnIndex==0?1:0].Value));
                guna2Transition1.ShowSync(pnlListItems);

            }
        }

        private void cdgvcart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                frmAddToCart frm = new frmAddToCart(clsItem.FindItemByID(Convert.ToInt32(MyCart.Rows[e.RowIndex][0])), Convert.ToInt32(MyCart.Rows[e.RowIndex][2]));
                frm.AddtoCart += Frm_AddtoCart;
                frm.ShowDialog();
            }
            else if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Are you Sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                MyCart.Rows.RemoveAt(e.RowIndex);
                UpdateTotal();
            }
        }

        private void cdgvcart_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==0 || e.ColumnIndex==1)
            {
                cdgvcart.Cursor = Cursors.Hand;
            }
            else
                cdgvcart.Cursor = Cursors.Default;
        }

        private void cdgvcart_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            cdgvcart.Cursor=Cursors.Default;
        }

        private void cdgvhistory_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(cdgvhistory.Columns[e.ColumnIndex] is DataGridViewImageColumn)
            {
                cdgvhistory.Cursor = Cursors.Hand;
            }
            else
                cdgvhistory.Cursor=Cursors.Default;
        }

        private void cdgvhistory_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            cdgvhistory.Cursor = Cursors.Default;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (MyCart.Rows.Count == 0)
            {
                MessageBox.Show("Cart Is Empty","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(MessageBox.Show("Confirm Payment?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
                { return; }

            if(!PerformTransaction(totalprice,clsClient.SymmetricDecryption(CurrentClient.CreditCardNumber)))
            {
                MessageBox.Show("Error in Transaction:Purchase Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsOrder order = new clsOrder();
            order.ClientID = CurrentClient.ID;
            if(!order.AddOrder())
            {
                MessageBox.Show("Error in Adding Order:Purchase Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!clsOrderDetail.AddOrderDetail(MyCart.DefaultView.ToTable(false,"ItemID","Qty","Price"),order.ID))
            {
                MessageBox.Show("Error in Adding Items:Purchase Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Purchase Done Successfully.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            MyCart.Rows.Clear();
            UpdateTotal();

            totalhistorypages = (int)Math.Ceiling(clsOrder.GetOrdersTotal(CurrentClient.ID) / 10.00);


            if (totalhistorypages > 0)
            {
                historypage = 1;

                lblnorders.Visible = false;
            }
            else
            {
                historypage = 0;
                lblnorders.Visible = true;
            }
            Fillcdgvhistory();
            ctrlListItems1.FillItems();
        }

        private void pbinfoimage_Click(object sender, EventArgs e)
        {
            guna2Transition1.HideSync(pnlListItems);
        }

        private void ctrlPictures1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlListItems1_Load(object sender, EventArgs e)
        {

        }
    }
}