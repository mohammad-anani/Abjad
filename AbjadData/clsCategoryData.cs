using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AbjadData
{
    public class clsCategoryData
    {
        public static int AddCategory(string name)
        {
            int NewID = -1;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd=new SqlCommand("SP_AddCategory",conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", name);
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

        public static DataTable ListCategories()
        {
            DataTable dtcat= new DataTable();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ListCategories", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                  

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader= cmd.ExecuteReader())
                        {
                            dtcat.Load(reader);
                        }
                       

                    }
                    catch
                    {
                        dtcat.Clear();
                    }
                }
            }
            return dtcat;
        }


        public static bool FindCategory(int ID,ref string name)
        {
            bool found = false;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_FindCategoryByID", conn))
                {
                    try
                    {
                        cmd.CommandType= CommandType.StoredProcedure;

                        SqlParameter output = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
                        output.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(output);

                        SqlParameter returned = new SqlParameter();
                        returned.Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(returned);

                      
                        cmd.Parameters.AddWithValue("@CategoryID", ID);
                        



                        conn.Open();
                        cmd.ExecuteNonQuery();

                        found = Convert.ToInt32(returned.Value)==1;

                        if(found)
                        {
                            name = output.Value.ToString();
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
    }
}
