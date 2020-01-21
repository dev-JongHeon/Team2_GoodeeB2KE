using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Team2_VO;

namespace Team2_DAC
{
    public class OrderDAC
    {
        SqlConnection conn = null;
        public OrderDAC()
        {
            string ConnectionStr = "Server = whyfi8888.ddns.net,11433; uid = team2; pwd = 1234; database = team2";
            conn = new SqlConnection(ConnectionStr);
        }

        public List<Order> GetOrderList()  // 뷰 사용
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Order_top";  
                    conn.Open();
                    List<Order> list = Helper.DataReaderMapToList<Order>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<OrderDetail> GetOrderDetailList()  // 뷰사용
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Order_bottom";
                    conn.Open();
                    List<OrderDetail> list = Helper.DataReaderMapToList<OrderDetail>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
