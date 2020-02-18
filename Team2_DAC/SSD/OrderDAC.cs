using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Team2_VO;

namespace Team2_DAC
{
    public class OrderDAC : ConnectionInfo
    {
        SqlConnection conn = null;
        public OrderDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        public List<Order> GetOrderList()  // 뷰 사용
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT Order_ID, Customer_UserID, Customer_Name, Order_Date, Order_Address1, Order_Address2,                             Order_DeletedYN, Order_State, TotalPrice ");
                    sb.Append("FROM   Order_top ");
                    sb.Append("ORDER BY Order_ID DESC ");

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString(); 
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
         

        public List<OrderDetail> GetOrderDetailList(string sb)  // 뷰사용
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SSD_GetOrderDetail_List";
                    cmd.Parameters.AddWithValue("@Search", sb);

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
        
        public List<Order> GetOrderCompletedList()  // 뷰 사용
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT Order_ID, Customer_UserID, Customer_Name, Order_Date, OrderCompleted_Date, Order_Address1,                        Order_Address2, TotalPrice ");
                    sb.Append("FROM   OrderCompleted_top ");
                    sb.Append("ORDER BY Order_ID DESC ");

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();

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

        public List<Sales> GetSalesStatus()  // 뷰 사용
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT Order_ID, Customer_UserID, Customer_Name, Order_Date, Shipment_DoneDate, TotalPrice ");
                    sb.Append("FROM   SalesStatus");
                    
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();
                    conn.Open();
                    List<Sales> list = Helper.DataReaderMapToList<Sales>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool UpOrder_InsShipment(List<string> orderID, int employeeID)  // 주문 처리
        {
            int check = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SSD_UpOrder_InsShipment2";

                    conn.Open();
                    for (int i = 0; i < orderID.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Order_ID", orderID[i]);
                        cmd.Parameters.AddWithValue("@Employee_ID", employeeID);
                        check += cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                return check > 0;
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show(err.Message);
                return false;
            }
        }

        public bool DeleteOrder(List<string> order_ID)  // 주문 삭제
        {
            int check = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SSD_DeleteOrder";

                    conn.Open();
                    for (int i = 0; i < order_ID.Count; i++)
                    {
                        cmd.Parameters.AddWithValue("@Order_ID", order_ID[i]);
                        check += cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                return check > 0;
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show(err.Message);
                return false;
            }
        }
    }
}
