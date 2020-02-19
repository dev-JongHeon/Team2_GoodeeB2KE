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
    /// 공통검색 DAC
    /// </summary>
    public class SearchDAC :ConnectionInfo
    {
        SqlConnection conn;
        public SearchDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        /// <summary>
        /// 공통검색폼용 정보를 가져오는 메서드
        /// </summary>
        /// <param name="div">구분자</param>
        /// <returns></returns>
        public List<SearchedInfoVO> GetInfo(string div)
        {
            try
            {
                List<SearchedInfoVO> list = new List<SearchedInfoVO>();
                string sql = "KJH_GetInfo";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Div", div);
                    conn.Open();
                    list = Helper.DataReaderMapToList<SearchedInfoVO>(cmd.ExecuteReader());
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
