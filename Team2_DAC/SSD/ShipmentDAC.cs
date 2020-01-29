using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_VO;

namespace Team2_DAC
{
    public class ShipmentDAC
    {
        SqlConnection conn = null;
        public ShipmentDAC()
        {
            string ConnectionStr = "Server = whyfi8888.ddns.net,11433; uid = team2; pwd = 1234; database = team2";
            conn = new SqlConnection(ConnectionStr);
        }

        public List<Shipment> GetShipmentList() // 뷰 사용
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Shipment_top";
                    conn.Open();
                    List<Shipment> list = Helper.DataReaderMapToList<Shipment>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Shipment> GetShipmentCompletedList() // 뷰 사용
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from ShipmentCompleted_top";
                    conn.Open();
                    List<Shipment> list = Helper.DataReaderMapToList<Shipment>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<ShipmentDetail> GetShipmentDetailList()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT Shipment_ID, c.Product_ID, Product_Name, OrderDetail_Qty " +
                                      "FROM Shipment a JOIN Orders b ON a.Order_ID = b.Order_ID " +
                                                      "JOIN OrderDetail c ON b.Order_ID = c.Order_ID " +
                                                      "JOIN Product d ON c.Product_ID = d.Product_ID ";

                    conn.Open();
                    List<ShipmentDetail> list = Helper.DataReaderMapToList<ShipmentDetail>(cmd.ExecuteReader());
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
