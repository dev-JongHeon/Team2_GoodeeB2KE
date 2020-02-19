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
    /// 작업 DAC
    /// </summary>
    public class WorkDAC : ConnectionInfo
    {
        SqlConnection conn;
        public WorkDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        /// <summary>
        /// 모든 작업을 가져오는 메서드
        /// </summary>
        /// <returns></returns>
        public List<WorkVO> GetAllWork()
        {
            try
            {
                List<WorkVO> list = new List<WorkVO>();
                string sql = "KJH_GetAllWork";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    list = Helper.DataReaderMapToList<WorkVO>(cmd.ExecuteReader());
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
