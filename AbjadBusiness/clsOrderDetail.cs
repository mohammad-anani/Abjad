using AbjadData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbjadBusiness
{
    public class clsOrderDetail
    {
        public int ID { get; set; }

        public int OrderID { get; set; }

        public int ItemID { get; set; }

        public int Quantity { get; set; }

       public clsOrderDetail()
        {
            this.ID = -1;
            this.OrderID = -1;
            this.ItemID = -1;
        }

        public static bool AddOrderDetail(DataTable cart,int orderid)
        {
            return clsOrderDetailData.AddOrderDetail(cart,orderid);
           
        }

        public static DataTable GetOrderDetailsList(int orderid)
        {
            return clsOrderDetailData.ListOrderDetails(orderid);
        }

    }
}
