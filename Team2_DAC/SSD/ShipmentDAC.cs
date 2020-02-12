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
    public class ShipmentDAC : ConnectionInfo
    {
        SqlConnection conn = null;
        public ShipmentDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        public List<Shipment> GetShipmentList() // 뷰 사용
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT Shipment_ID, Order_ID, Order_Date, OrderCompleted_Date, Customer_userID, Customer_Name,                           Shipment_RequiredDate, Employees_Name, Shipment_DoneDate ");
                    sb.Append("FROM   Shipment_top ");
                    sb.Append("ORDER BY Shipment_ID DESC ");

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();
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
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT Shipment_ID, Order_ID, Order_Date, OrderCompleted_Date, Customer_userID, Customer_Name,                           Shipment_RequiredDate, Employees_Name, Shipment_DoneDate ");
                    sb.Append("FROM   ShipmentCompleted_top");
                    sb.Append("ORDER BY Shipment_ID DESC ");

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();
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

        public List<ShipmentDetail> GetShipmentDetailList(string sb)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SSD_GetShipmentDetail_List";
                    cmd.Parameters.AddWithValue("@Search", sb);

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
