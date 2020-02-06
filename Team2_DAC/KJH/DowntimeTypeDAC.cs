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
    public class DowntimeTypeDAC : ConnectionInfo
    {
        SqlConnection conn;
        public DowntimeTypeDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        public List<DowntimeTypeVO> GetAllDowntimeType()
        {
            try
            {
                List<DowntimeTypeVO> list = new List<DowntimeTypeVO>();
                string sql = "KJH_GetAllDowntimeType";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    list = Helper.DataReaderMapToList<DowntimeTypeVO>(cmd.ExecuteReader());
                    conn.Close();
                }
                return list;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public bool UpdateDowntimeType(DowntimeTypeVO item)
        {
            try
            {
                string sql = "KJH_UpdateDowntimeType";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@DownID", item.DownID);
                    cmd.Parameters.AddWithValue("@DownName", item.DownName);
                    cmd.Parameters.AddWithValue("@DownExplain", item.DownExplain);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result > 0;
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public bool DeleteDowntimeType(string id)
        {
            try
            {
                string sql = "KJH_DeleteDowntimeType";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DownID", id);
                    
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result > 0;
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}
