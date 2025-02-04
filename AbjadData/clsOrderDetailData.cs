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
    public class clsOrderDetailData
    {
        public static bool AddOrderDetail(DataTable dtItems,int orderid)
        {
         
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_AddOrderDetail", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (DataRow row in dtItems.Rows)
                    {

                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@itemID", row[0]);
                        cmd.Parameters.AddWithValue("@orderid", orderid);
                        cmd.Parameters.AddWithValue("@Quantity", row[1]);
                        cmd.Parameters.AddWithValue("@TotalPrice",row[2]);

                       


                        try
                        {
                          
                            cmd.ExecuteNonQuery();


                        }
                        catch
                        {

                            return false;
                        }
                    }
                    return true;
                }
            }

        }

        public static DataTable ListOrderDetails( int orderid)
        {

            DataTable dtorderdetails = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ListOrderDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@orderID", orderid);
                   

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dtorderdetails.Load(reader);
                        }


                    }
                    catch
                    {
                        dtorderdetails.Clear();
                    }
                }
            }
            return dtorderdetails;
        }



    }
}
