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
    /// 불량처리유형 DAC
    /// </summary>
    public class DefectiveHandleDAC : ConnectionInfo
    {
        SqlConnection conn;
        public DefectiveHandleDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        /// <summary>
        /// 모든 불량처리유형을 가져오는 메서드
        /// </summary>
        /// <returns></returns>
        public List<DefectiveHandleVO> GetAllDefectiveHandle()
        {
            try
            {
                List<DefectiveHandleVO> list = new List<DefectiveHandleVO>();
                string sql = "KJH_GetAllDefectiveHandle";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    list = Helper.DataReaderMapToList<DefectiveHandleVO>(cmd.ExecuteReader());
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
        /// 불량처리유형을 수정하는 메서드
        /// </summary>
        /// <param name="item">불량처리유형VO</param>
        /// <returns></returns>
        public bool UpdateDefectiveHandle(DefectiveHandleVO item)
        {
            try
            {
                string sql = "KJH_UpdateDefectiveHandle";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@HandleID", item.HandleID);
                    cmd.Parameters.AddWithValue("@HandleName", item.HandleName);
                    cmd.Parameters.AddWithValue("@HandleExplain", item.HandleExplain);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result > 0;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 불량처리유형을 삭제하는 메서드
        /// </summary>
        /// <param name="id">불량처리유형id</param>
        /// <returns></returns>
        public bool DeleteDefectiveHandle(string id)
        {
            try
            {
                string sql = "KJH_DeleteDefectiveHandle";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@HandleID", id);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result > 0;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
