using AbjadData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbjadBusiness
{
    public class clsOrder
    {
        public int ID { get; set; }

        public int ClientID { get; set; }

        public DateTime Date { get; set; }

        public clsOrder()
        {
            this.ID = -1;
            this.ClientID = -1;
            this.Date = DateTime.MinValue;
        }

        public bool AddOrder()
        {
            this.ID = clsOrderData.AddOrder(this.ClientID);
            return this.ID != -1;
        }

        public static DataTable GetOrdersList(int pagenumber,int clientid)
        {
            return clsOrderData.ListOrders(pagenumber,clientid);
        }

        public static int GetOrdersTotal(int clientid)
        {
            return clsOrderData.GetOrdersTotal(clientid);
        }

    }
}
