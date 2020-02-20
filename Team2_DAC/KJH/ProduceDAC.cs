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
    /// 생산실적 DAC
    /// </summary>
    public class ProduceDAC : ConnectionInfo
    {
        SqlConnection conn;
        public ProduceDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        /// <summary>
        /// 모든 생산목록을 가져오는 메서드
        /// </summary>
        /// <returns></returns>
        public List<ProduceVO> GetAllProduce()
        {
            try
            {
                List<ProduceVO> list = new List<ProduceVO>();
                string sql = "KJH_GetAllProduce";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    list = Helper.DataReaderMapToList<ProduceVO>(cmd.ExecuteReader());
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
        /// 작업ID로 생산목록을 조회하는 메서드
        /// </summary>
        /// <param name="id">작업ID</param>
        /// <returns></returns>
        public List<ProduceVO> GetProduceByWorkID(string id)
        {
            try
            {
                List<ProduceVO> list = new List<ProduceVO>();
                string sql = "KJH_GetProduceByWorkIDtest";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    list = Helper.DataReaderMapToList<ProduceVO>(cmd.ExecuteReader());
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
        /// 생산ID로 생산실적을 가져오는 메서드
        /// </summary>
        /// <param name="id">생산ID</param>
        /// <returns></returns>
        public List<PerformanceVO> GetPerformanceByProduceID(string id)
        {
            try
            {
                List<PerformanceVO> list = new List<PerformanceVO>();
                string sql = "KJH_GetPerformanceByProduceID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    list = Helper.DataReaderMapToList<PerformanceVO>(cmd.ExecuteReader());
                    conn.Close();
                }
                return list;
            }
            catch
            {
                throw;
            }
        }
    }
}
