using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbjadData
{
    public class clsItemData
    {
        public static int AddItem(int catid, string name, string desc, string imagepath, double price, int stock, double discount)
        {
            int NewID = -1;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_AddItem", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@description", desc);
                    cmd.Parameters.AddWithValue("@imagepath", imagepath);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@Stock", stock);
                    cmd.Parameters.AddWithValue("@discount", discount);
                    cmd.Parameters.AddWithValue("@CategoryID", catid);


                    SqlParameter output = new SqlParameter("@NewID", SqlDbType.Int);
                    output.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(output);


                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        NewID = Convert.ToInt32(output.Value);

                    }
                    catch
                    {
                        NewID = -1;
                    }
                }
            }
            return NewID;
        }


        public static bool UpdateItem(int itemid,int catid, string name, string desc, string imagepath, double price, int stock, double discount)
        {
            
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_UpdateItem", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@description", desc);
                    cmd.Parameters.AddWithValue("@imagepath", imagepath);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@Stock", stock);
                    cmd.Parameters.AddWithValue("@discount", discount);
                    cmd.Parameters.AddWithValue("@itemId", itemid);

                    SqlParameter returned = new SqlParameter();
                    returned.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returned);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        return Convert.ToInt32(returned.Value) == 1;

                    }
                    catch
                    {
                        return false;
                    }

                }
            }
         
        }

        public static bool FindItemByID(int itemID, ref int catid, ref string name, ref string desc, ref string imagepath
, ref int stock, ref double price, ref double discount)
        {
            bool found = false;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_FindItemByID", conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter optcatid = new SqlParameter("@categoryid", SqlDbType.Int),
                                     optname = new SqlParameter("@name", SqlDbType.NVarChar, 50),
                                     optdesc = new SqlParameter("@description", SqlDbType.NVarChar, -1),
                                     optdiscount = new SqlParameter("@discount", SqlDbType.Decimal),
                                     optstock = new SqlParameter("@stock", SqlDbType.Int),
                                     optimagepath = new SqlParameter("@imagepath", SqlDbType.NVarChar, -1),
                                     optprice = new SqlParameter("@price", SqlDbType.SmallMoney);
                        optcatid.Direction = ParameterDirection.Output;
                        optname.Direction = ParameterDirection.Output;
                        optdesc.Direction = ParameterDirection.Output;
                        optdiscount.Direction = ParameterDirection.Output;
                        optstock.Direction = ParameterDirection.Output;
                       optimagepath.Direction = ParameterDirection.Output;
                        optprice.Direction = ParameterDirection.Output;

                        optdiscount.Precision = 3;
                        optdiscount.Scale = 2;

                        cmd.Parameters.Add(optcatid);
                        cmd.Parameters.Add(optname);
                        cmd.Parameters.Add(optdesc);
                        cmd.Parameters.Add(optimagepath);
                        cmd.Parameters.Add(optstock);
                        cmd.Parameters.Add(optdiscount);
                        cmd.Parameters.Add(optprice);


                        SqlParameter returned = new SqlParameter();
                        returned.Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(returned);


                        cmd.Parameters.AddWithValue("@ItemID",itemID);




                        conn.Open();
                        cmd.ExecuteNonQuery();

                        found = Convert.ToInt32(returned.Value) == 1;

                        if (found)
                        {
                            catid = Convert.ToInt32(optcatid.Value);
                            name = (string)optname.Value;
                            desc = (string)optdesc.Value;
                           discount = Convert.ToDouble(optdiscount.Value);
                            stock = Convert.ToInt32(optstock.Value);
                            price = (double)Convert.ToDecimal(optprice.Value);
                            imagepath = (string)optimagepath.Value;
                        }



                    }
                    catch
                    {
                        found = false;
                    }
                }
            }
            return found;
        }

        public static DataTable ListItems(int pagenumber,string category,string name)
        {

            DataTable dtitems = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ListItems", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PageNumber", pagenumber);
                    cmd.Parameters.AddWithValue ("@categoryname", category);
                    cmd.Parameters.AddWithValue ("@name", name);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dtitems.Load(reader);
                        }


                    }
                    catch
                    {
                        dtitems.Clear();
                    }
                }
            }
            return dtitems;
        }

        public static DataTable ListHomeItems()
        {

            DataTable dtitems = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[FCT_ListLatestAndTopSellingItems] ()", conn))
                {
                   

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dtitems.Load(reader);
                        }


                    }
                    catch
                    {
                        dtitems.Clear();
                    }
                }
            }
            return dtitems;
        }

        public static int GetItemsTotal(int categoryid,string name)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("FCT_GetItemsTotal", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter returned = new SqlParameter();
                    returned.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returned);

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@categoryid", categoryid);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        if (returned.Value != null)
                        {
                            return Convert.ToInt32(returned.Value);
                        }


                    }
                    catch
                    {
                        return -1;
                    }
                }
            }
            return -1;
        }

    }
}
