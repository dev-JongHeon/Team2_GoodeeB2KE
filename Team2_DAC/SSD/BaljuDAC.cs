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
    public class BaljuDAC : ConnectionInfo
    {
        SqlConnection conn = null;
        public BaljuDAC() 
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        // 발주조회
        public List<Balju> GetBaljuList()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT Balju_ID, Company_ID, Company_Name, Balju_Date, Employees_Name, Total, Balju_DeletedYN ");
                    sb.Append("FROM BaljuList ");
                    sb.Append("ORDER BY Balju_ID DESC ");
                    
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();

                    conn.Open();
                    List<Balju> list = Helper.DataReaderMapToList<Balju>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                throw;
            }
        }

        public List<Balju> GetBalju_CompletedList()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT Balju_ID, Company_ID, Company_Name, Balju_Date,                                                                        Balju_ReceiptDate, Employees_Name, Total, Balju_DeletedYN ");
                    sb.Append("FROM   BaljuList_Completed_Top ");
                    sb.Append("ORDER BY Balju_ID DESC ");

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();
                    conn.Open();
                    List<Balju> list = Helper.DataReaderMapToList<Balju>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                throw;
            }
        }

        public List<BaljuDetail> GetBalju_DetailList(string sb)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SSD_GetBaljuDetail_List";
                    cmd.Parameters.AddWithValue("@Search", sb);

                    conn.Open();
                    List<BaljuDetail> list = Helper.DataReaderMapToList<BaljuDetail>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                throw;
            }
        }

        public bool UpdateBalju_Processed(List<string> baljuID, int employeeID)
        {
            int check = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SSD_UpdateBalju_Processed";

                    conn.Open();
                    for (int i = 0; i < baljuID.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Balju_ID", baljuID[i]);
                        cmd.Parameters.AddWithValue("@employee_ID", employeeID);
                        check += cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                return check > 0;
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteBalju(List<string> balju_ID)
        {
            int check = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SSD_DeleteBalju";

                    conn.Open();
                    for (int i = 0; i < balju_ID.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Balju_ID", balju_ID[i]);
                        check += cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                return check > 0;
            }
            catch
            {
                throw;
            }
        }
    }
}
