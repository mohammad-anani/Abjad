using AbjadData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbjadBusiness
{
   
    public class clsItem
    {
        public int ID {  get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock {  get; set; }
        public int CategoryID { get; set; }

        public clsCategory Category { get; set; }

        public double Price { get; set; }

        public double Discount { get; set; }

        public string ImagePath { get; set; }

        public clsItem()
        {
            this.ID = -1;
            this.Stock = -1;
            this.Price = -1;
            this.Discount = -1;
            this.Name = "Name";
            this.Description = "Description";
            this.ImagePath= "ImagePath";
            this.CategoryID = -1;
            this.Category = new clsCategory();
        }

        public clsItem(int iD, string name, string description, int stock, int categoryID, double price, double discount, string imagePath)
        {
           this.ID = iD;
           this.Name = name;
           this.Description = description;
           this.Stock = stock;
           this.CategoryID = categoryID;
            this.Category=clsCategory.FindCategory(categoryID);
           this.Price = price;
           this.Discount = discount;
           this.ImagePath = imagePath;
        }

        public bool AddItem()
        {
            this.ID=clsItemData.AddItem(this.CategoryID,this.Name,this.Description,this.ImagePath,this.Price,this.Stock,this.Discount);
            return this.ID != -1;
        }

        public bool UpdateItem()
        {
            return clsItemData.UpdateItem(this.ID,this.CategoryID, this.Name, this.Description, this.ImagePath, this.Price, this.Stock, this.Discount);
            
        }

        public static DataTable GetItemsList(int pagenumber,string category,string name)
        {
            return clsItemData.ListItems(pagenumber,category,name);
        }

        public static List<clsItem> GetHomeItemsList()
        {
            DataTable dtItems = clsItemData.ListHomeItems();

            List<clsItem> items = new List<clsItem>();
            clsItem Item = new clsItem();

            foreach (DataRow row in dtItems.Rows)
            {
                Item = new clsItem();
                Item.ID = Convert.ToInt32(row[0]);
                Item.Category.Name = Convert.ToString(row[1]);
                Item.Name = Convert.ToString(row[2]);
                Item.Description = Convert.ToString(row[3]);
                Item.ImagePath = Convert.ToString(row[4]);
                Item.Price = Convert.ToDouble(row[5]);
                Item.Stock = Convert.ToInt32(row[6]);
                Item.Discount = Convert.ToDouble(row[7]);
                items.Add(Item);
            }
            return items;
        }


        public static int GetItemsTotal(int categoryid,string name)
        {
            return clsItemData.GetItemsTotal(categoryid,name);
        }

        public static clsItem FindItemByID(int ID)
        {
         
        string Name="Name";
        string Description="Desc";
        int Stock=-1;
        int CategoryID=-1;

        double Price=-1;

        double Discount = -1;

         string ImagePath="ImagePath";

            if(clsItemData.FindItemByID(ID,ref CategoryID,ref Name,ref Description,ref ImagePath,ref Stock,ref Price,ref Discount))
            {
                return new clsItem(ID, Name, Description, Stock, CategoryID, Price, Discount, ImagePath);
            }    
            return new clsItem();
    }
    }
}
