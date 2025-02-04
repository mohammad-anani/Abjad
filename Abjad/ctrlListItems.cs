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
    public partial class ctrlListItems : UserControl
    {
        public ctrlListItems()
        {
            InitializeComponent();
        }

        string category = "All";
        int categoryid = 0;
        int page = 1;
        int totalpages = 1;
        string name = "";

        private void guna2TextBox1_IconRightClick(object sender, EventArgs e)
        {
            name = guna2TextBox1.Text;
            FillItems();
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                guna2TextBox1_IconRightClick(null, null);
        }

        private void ctrlListItems_Load(object sender, EventArgs e)
        {
            CategoryButton cbtn = new CategoryButton();
            cbtn.Text = "All";
            cbtn.Checked = true;
            cbtn.Click += Btn_Click;
            flpCategories.Controls.Add(cbtn);
            

        }

        

        public void FillCategories()
        {
            foreach (DataRow row in clsCategory.ListCategories().Rows)
            {
                CategoryButton btn = new CategoryButton();
                btn.Text = row[0].ToString();
                btn.Click += Btn_Click;
                flpCategories.Controls.Add(btn);
            }
           
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            CategoryButton cbtn = sender as CategoryButton;
            categoryid = flpCategories.Controls.IndexOf(cbtn);
            category = cbtn.Text;
            page = 1;
            FillItems();
           
        }

        public void FillItems()
        {
            flpItems.Controls.Clear();
            totalpages = (int)Math.Ceiling((float)clsItem.GetItemsTotal(categoryid, name)/9.00);
            lbltotalpages.Text = totalpages.ToString();
           

           

            clsItem Item=new clsItem();

            foreach(DataRow row in clsItem.GetItemsList(page,category,name).Rows)
            {
                Item=new clsItem();
                Item.ID = Convert.ToInt32(row[0]);
                Item.Category.Name = Convert.ToString(row[1]);
                Item.Name = Convert.ToString(row[2]);
                Item.Description = Convert.ToString(row[3]);
                Item.ImagePath = Convert.ToString(row[4]);
                Item.Price=Convert.ToDouble(row[5]);
                Item.Stock=Convert.ToInt32(row[6]);
                Item.Discount=Convert.ToDouble(row[7]);
                
                ctrlItem ctrlItem = new ctrlItem();
                ctrlItem.Item=Item;
                ctrlItem.FillItem();
                ctrlItem.OnClickToPurchase += CtrlItem_OnClickToPurchase;
                flpItems.Controls.Add(ctrlItem);
            }

            if(Item.ID==-1)
            {
                page = 0;
            }
            lblpage.Text = page.ToString();

            if (totalpages == page)
            {
                pbforward.Enabled = false;
            }
            else
                pbforward.Enabled = true;

            if (page <= 1)
            {
                pbbackward.Enabled = false;
            }
            else
                pbbackward.Enabled = true;
        }

        public event Action<clsItem> OnClickToPurchase;
        protected virtual void ClickToPurchase(clsItem item)
        {
            OnClickToPurchase?.Invoke(item);
        }

        private void CtrlItem_OnClickToPurchase(clsItem obj)
        {
            ClickToPurchase(obj);
        }

        private void flpCategories_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void pbforward_Click(object sender, EventArgs e)
        {
            page++;
            lblpage.Text =page.ToString();
            FillItems();

        }

        private void pbbackward_Click(object sender, EventArgs e)
        {
            page--;
            lblpage.Text = page.ToString();
            FillItems();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void flpItems_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
