using AbjadData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbjadBusiness
{
    public class clsCategory
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public clsCategory()
        {
            this.ID = -1;
            this.Name = "Name";
        }

        public clsCategory(int ID,string name)
        {
            this.ID = ID;
            this.Name = name;
        }

        public bool AddCategory()
        {

            this.ID = clsCategoryData.AddCategory(this.Name);
            return this.ID != -1;
         }

        public static DataTable ListCategories()
        {
            return clsCategoryData.ListCategories();
        }

        public static clsCategory FindCategory(int ID)
        {
            string name = "name";

            if(clsCategoryData.FindCategory(ID,ref name))
            {
                return new clsCategory(ID, name);
            }
            return new clsCategory();
        }
    }
}
