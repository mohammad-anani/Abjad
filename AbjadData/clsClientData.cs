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
    public class clsClientData
    {
      public static int AddClient(string fullname,string address,string username,string password
          , string creditcardnumber,string imagepath)
        {
            int NewID = -1;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_AddClient", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FullName", fullname);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@imagepath", imagepath);
                    cmd.Parameters.AddWithValue("@creditcardnumber", creditcardnumber);


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

        public static bool UpdateClient(int ClientID,string fullname, string address, string username, string password
       , string creditcardnumber, string imagepath,bool isactive)
        {
            
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_UpdateClient", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FullName", fullname);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@imagepath", imagepath);
                    cmd.Parameters.AddWithValue("@creditcardnumber", creditcardnumber);
                    cmd.Parameters.AddWithValue("@ClientID", ClientID);
                    cmd.Parameters.AddWithValue("@ISactive", isactive);


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

        public static bool FindClientByID(int ClientID,ref string fullname,ref string address, ref string username,ref string password
       , ref string creditcardnumber,ref string imagepath,ref bool isactive)
        {
            bool found = false;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_FindClientByID", conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter optfullname = new SqlParameter("@FullName", SqlDbType.NVarChar, 50),
                                     optaddress = new SqlParameter("@Address", SqlDbType.NVarChar,-1),
                                     optusername = new SqlParameter("@username", SqlDbType.NVarChar, 50),
                                     optpassword = new SqlParameter("@password", SqlDbType.NVarChar, -1),
                                     optcreditcardnumber = new SqlParameter("@creditcardnumber", SqlDbType.NVarChar, -1),
                                     optimagepath = new SqlParameter("@imagepath", SqlDbType.NVarChar, -1),
                                     optisactive = new SqlParameter("@isactive", SqlDbType.Bit);
                        optfullname.Direction = ParameterDirection.Output;
                        optaddress.Direction = ParameterDirection.Output;
                        optusername.Direction= ParameterDirection.Output;
                        optpassword.Direction= ParameterDirection.Output;
                        optcreditcardnumber.Direction= ParameterDirection.Output;
                        optimagepath.Direction= ParameterDirection.Output;
                        optisactive.Direction= ParameterDirection.Output;

                        cmd.Parameters.Add(optfullname);
                        cmd.Parameters.Add(optaddress);
                        cmd.Parameters.Add(optusername);
                        cmd.Parameters.Add(optpassword);
                        cmd.Parameters.Add(optcreditcardnumber);
                        cmd.Parameters.Add(optimagepath);
                        cmd.Parameters.Add(optisactive);


                        SqlParameter returned = new SqlParameter();
                        returned.Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(returned);


                        cmd.Parameters.AddWithValue("@ClientID", ClientID);




                        conn.Open();
                        cmd.ExecuteNonQuery();

                        found = Convert.ToInt32(returned.Value) == 1;

                        if (found)
                        {
                          fullname=(string)optfullname.Value;
                            address=(string)optaddress.Value;
                            username=(string)optusername.Value;
                            password=(string)optpassword.Value;
                            creditcardnumber=(string)optcreditcardnumber.Value;
                            isactive=Convert.ToBoolean(optisactive.Value);
                            imagepath=(string)optimagepath.Value;
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

        public static bool FindClientByUsernameAndPassword(ref int ClientID, ref string fullname, ref string address,string username, string password
 , ref string creditcardnumber, ref string imagepath, ref bool isactive)
        {
            bool found = false;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_FindClientByUsernameAndPassword", conn))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter optfullname = new SqlParameter("@FullName", SqlDbType.NVarChar, 50),
                                     optaddress = new SqlParameter("@Address", SqlDbType.NVarChar,-1),
                                     optclientid=new SqlParameter("@ClientID",SqlDbType.Int),
                                     optcreditcardnumber = new SqlParameter("@creditcardnumber", SqlDbType.NVarChar, -1),
                                     optimagepath = new SqlParameter("@imagepath", SqlDbType.NVarChar, -1),
                                     optisactive = new SqlParameter("@isactive", SqlDbType.Bit);
                        optfullname.Direction = ParameterDirection.Output;
                        optaddress.Direction = ParameterDirection.Output;
                        optclientid.Direction = ParameterDirection.Output;
                        optcreditcardnumber.Direction = ParameterDirection.Output;
                        optimagepath.Direction = ParameterDirection.Output;
                        optisactive.Direction = ParameterDirection.Output;

                        cmd.Parameters.Add(optfullname);
                        cmd.Parameters.Add(optaddress);
                        cmd.Parameters.Add(optclientid);
                        cmd.Parameters.Add(optcreditcardnumber);
                        cmd.Parameters.Add(optimagepath);
                        cmd.Parameters.Add(optisactive);


                        SqlParameter returned = new SqlParameter();
                        returned.Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(returned);


                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);




                        conn.Open();
                        cmd.ExecuteNonQuery();

                        found = Convert.ToInt32(returned.Value) == 1;

                        if (found)
                        {
                            fullname = (string)optfullname.Value;
                            address = (string)optaddress.Value;
                            ClientID = Convert.ToInt32(optclientid.Value);
                            creditcardnumber = (string)optcreditcardnumber.Value;
                            isactive = Convert.ToBoolean(optisactive.Value);
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

        public static DataTable ListClients(int pagenumber)
        {

            DataTable dtclients = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_ListClients", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PageNumber", pagenumber);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dtclients.Load(reader);
                        }


                    }
                    catch
                    {
                        dtclients.Clear();
                    }
                }
            }
            return dtclients;
        }

        public static int GetClientsTotal()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("FCT_GetClientsTotal", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter returned = new SqlParameter();
                    returned.Direction = ParameterDirection.ReturnValue;

                    try
                    {
                        conn.Open();
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

        public static bool UsernameExists(string username)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("FCT_UsernameExists", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);


                    SqlParameter returned = new SqlParameter();
                    returned.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returned);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        if (returned.Value != null)
                        {
                            return Convert.ToBoolean(returned.Value);
                        }


                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public static bool DeleteClient(int clientID)
        {
            using (SqlConnection conn=new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteClient", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ClientID", clientID);

                    SqlParameter returned = new SqlParameter();
                    returned.Direction = ParameterDirection.ReturnValue;
                    command.Parameters.Add(returned);

                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                        return Convert.ToInt32(returned.Value) == 1;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
                    

        }
              
    }
}
