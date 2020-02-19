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
    /// <summary>
    /// 비가동현황 DAC
    /// </summary>
    public class DowntimeDAC : ConnectionInfo
    {
        SqlConnection conn;
        public DowntimeDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        /// <summary>
        /// 모든 비가동현황을 가져오는 메서드
        /// </summary>
        /// <returns></returns>
        public List<DowntimeVO> GetAllDowntime()
        {
            try
            {
                List<DowntimeVO> list = new List<DowntimeVO>();
                string sql = "KJH_GetAllDowntime";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    list = Helper.DataReaderMapToList<DowntimeVO>(cmd.ExecuteReader());
                    conn.Close();
                }
                return list;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 공정별 비가동현황을 가져오는 메서드
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetDowntimeByLine(string date)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "KJH_GetDowntimeByLine";
                using (SqlDataAdapter adpt = new SqlDataAdapter(sql,conn))
                {
                    adpt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adpt.SelectCommand.Parameters.AddWithValue("@Date", date);
                    conn.Open();
                    adpt.Fill(ds);
                    conn.Close();
                }
                return ds;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 비가동유형별 비가동현황을 가져오는 메서드
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DataSet GetDowntimeByType(string date)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "KJH_GetDowntimeByType";
                using (SqlDataAdapter adpt = new SqlDataAdapter(sql, conn))
                {
                    adpt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adpt.SelectCommand.Parameters.AddWithValue("@Date", date);
                    conn.Open();
                    adpt.Fill(ds);
                    conn.Close();
                }
                return ds;
            }
            catch
            {
                throw;
            }
        }
    }
}
