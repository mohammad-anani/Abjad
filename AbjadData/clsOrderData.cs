using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AbjadData
{
    public class clsOrderData
    {
        public static int AddOrder(int clientid)
        {
            int NewID = -1;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_AddOrder", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClientID", clientid);
                   

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

        public static DataTable ListOrders(int pagenumber,int clientid)
        {

            DataTable dtorders = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ListOrders", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClientID", clientid);
                    cmd.Parameters.AddWithValue("@PageNumber", pagenumber);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dtorders.Load(reader);
                        }


                    }
                    catch
                    {
                        dtorders.Clear();
                    }
                }
            }
            return dtorders;
        }

        public static int GetOrdersTotal(int ClientID)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("FCT_GetOrdersTotal", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ClientID", ClientID);

                    SqlParameter returned = new SqlParameter();
                    returned.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returned);

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
