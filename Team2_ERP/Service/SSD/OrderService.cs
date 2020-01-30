using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP.Service
{
    public class OrderService
    {
        public List<Order> GetOrderList()
        {
            OrderDAC dac = new OrderDAC();
            return dac.GetOrderList();
        }


        public List<OrderDetail> GetOrderDetailList()
        {
            OrderDAC dac = new OrderDAC();
            return dac.GetOrderDetailList();
        }

        public List<Order> GetOrderCompletedList()
        {
            OrderDAC dac = new OrderDAC();
            return dac.GetOrderCompletedList();
        }

        public List<Sales> GetSalesStatus()  // 뷰 사용
        {
            OrderDAC dac = new OrderDAC();
            return dac.GetSalesStatus();
        }

        public void UpOrder_InsShipment(string orderID, int employeeID)
        {
            OrderDAC dac = new OrderDAC();
            dac.UpOrder_InsShipment(orderID, employeeID);
        }
    }
}
