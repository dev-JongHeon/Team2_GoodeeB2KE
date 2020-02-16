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
    public class MonitorDAC : ConnectionInfo
    {
        SqlConnection conn = null;
        public MonitorDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.ConnectionString;
        }

        // 오류가 난경우 로그를 기록하는 메서드
        private void WriteErrorLog(Exception ex)
        {
            string sss = ex.Message;
        }

        #region 파라미터 대입

        // 파라미터 넣는 함수 Null이 있는경우 ==> Null값을 전달
        private void FillParameter(SqlCommand cmd, string[] paramArr, object[] valueArr)
        {
            for (int i = 0; i < paramArr.Length; i++)
            {
                if (valueArr[i] != null)
                    cmd.Parameters.AddWithValue(paramArr[i], valueArr[i]);
                else
                    cmd.Parameters.AddWithValue(paramArr[i], DBNull.Value);
            }
        }

        private SqlParameter OutParameter(SqlCommand cmd, string p)
        {
            SqlParameter param = new SqlParameter(p, SqlDbType.NVarChar, 8);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            return param;
        }

        public List<LineMonitor> GetLineInfo()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Line_ID, Factory_ID, Line_Name FROM Line";                  

                    conn.Open();
                    List<LineMonitor> list = Helper.DataReaderMapToList<LineMonitor>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }



        #endregion
    }
}
