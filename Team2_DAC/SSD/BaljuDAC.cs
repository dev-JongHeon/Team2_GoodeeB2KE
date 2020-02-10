using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC.SSD.DataSets;
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
                    sb.Append("SELECT Balju_ID, Company_ID, Company_Name, Balju_Date, Employees_Name, Balju_DeletedYN ");
                    sb.Append("FROM   BaljuList ");
                    
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
                return null;
            }
        }

        public List<Balju> GetBalju_CompletedList()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT Balju_ID, Company_ID, Company_Name, Balju_Date,                                                                        Balju_ReceiptDate, Employees_Name, Balju_DeletedYN ");
                    sb.Append("FROM   BaljuList_Completed_Top");
                    
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
                return null;
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
                return null;
            }
        }

        public void UpdateBalju_Processed(string balju_ID)
        {
            int check = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UpdateBalju_Processed";
                    cmd.Parameters.AddWithValue("@Balju_ID", balju_ID);
                    conn.Open();
                    check = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show(err.Message);
            }
            finally
            {
                if (check >= 1)
                {
                    System.Windows.Forms.MessageBox.Show("발주처리완료!");
                }
            }
        }

        public void DeleteBalju(string balju_ID)
        {
            int check = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteBalju";
                    cmd.Parameters.AddWithValue("@Balju_ID", balju_ID);
                    conn.Open();
                    check = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show(err.Message);
            }
            finally
            {
                if (check > 0)
                {
                    System.Windows.Forms.MessageBox.Show("삭제완료!");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("삭제실패...");
                }
            }
        }

        public DataSet GetBaljuList_DataSet(string id)
        {
            try
            {
                dsBalju ds = new dsBalju();
                StringBuilder sb = new StringBuilder();
                using (SqlConnection conn = this.conn) 
                {
                    sb.Append("SELECT Balju_ID, Company_Name, Balju_Date, Employees_Name ");
                    sb.Append("FROM   BaljuList ");
                    
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(sb.ToString(), conn);
                    da.Fill(ds, "dtBalju");
                    sb.Clear();                    

                    sb.Append("SSD_GetBaljuDetail_List");
                    da = new SqlDataAdapter(sb.ToString(), conn);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Search", id);
                    da.Fill(ds, "dtBalju_Detail");

                    conn.Close();
                    return ds;
                }
            }
            catch
            {
                return null;
            }
        }
    }


}
