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
    /// 유저권한 DAC
    /// </summary>
    public class AuthDAC :ConnectionInfo
    {
        /// <summary>
        /// 0225 최종커밋
        /// </summary>
        SqlConnection conn;
        public AuthDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        /// <summary>
        /// id를 이용해서 user권한목록 가져오는 메서드
        /// </summary>
        /// <param name="id">유저id</param>
        /// <returns></returns>
        public List<AuthVO> GetAuthByID(int id)
        {
            try
            {
                List<AuthVO> list = new List<AuthVO>();
                string sql = "KJH_GetAuth";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    list  = Helper.DataReaderMapToList<AuthVO>(cmd.ExecuteReader());
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
        /// id와 권한리스트를 받아서 유저권한 업데이트 메서드
        /// </summary>
        /// <param name="id">유저id</param>
        /// <param name="list">권한리스트</param>
        /// <returns></returns>
        public bool UpdateAuth(int id,List<AuthVO> list)
        {
            try
            {
                string sql = "KJH_UpdateAuth";
                int result = 0;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    foreach (AuthVO item in list)
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@Form", item.Form);
                        cmd.Parameters.AddWithValue("@Auth", item.Auth);

                        result= cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    conn.Close();
                }
                return result > 0;
            }
            catch
            {
                throw;
            }
        }
    }
}
