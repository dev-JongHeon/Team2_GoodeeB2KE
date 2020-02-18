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
    /// 불량처리현황 DAC
    /// </summary>
    public class DefectiveDAC : ConnectionInfo
    {
        SqlConnection conn;
        public DefectiveDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }
        /// <summary>
        /// 모든 불량현황을 가져오는 메서드
        /// </summary>
        /// <returns></returns>
        public List<DefectiveVO> GetAllDefective()
        {
            try
            {
                List<DefectiveVO> list = new List<DefectiveVO>();
                string sql = "KJH_GetAllDefective";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    list = Helper.DataReaderMapToList<DefectiveVO>(cmd.ExecuteReader());
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
        /// 라인별 불량현황 가져오는 메서드
        /// </summary>
        /// <param name="date">날짜리스트</param>
        /// <returns></returns>
        public DataSet GetDefectiveByLine(string date)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "KJH_GetDefectiveByLine";
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
        /// <summary>
        /// 불량유형별 불량현황을 가져오는 메서드
        /// </summary>
        /// <param name="date">날짜리스트</param>
        /// <returns></returns>
        public DataSet GetDefectiveByDeftiveType(string date)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "KJH_GetDefectiveByDeftiveType";
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

        /// <summary>
        /// 불량처리유형별 불량현황을 가져오는 메서드
        /// </summary>
        /// <param name="date">날짜리스트</param>
        /// <returns></returns>
        public DataSet GetDefectiveByDeftiveHandleType(string date)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "KJH_GetDefectiveByDeftiveHandleType";
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
