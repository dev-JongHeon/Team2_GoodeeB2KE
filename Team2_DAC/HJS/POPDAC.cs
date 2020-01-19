using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_VO;

namespace Team2_DAC
{
    public class POPDAC
    {
        SqlConnection conn = null;
        public POPDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Server = whyfi8888.ddns.net,11433; uid = team2; pwd = 1234; database = team2";
        }

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



        // 작업조회 (날짜 Default = 오늘 날짜)
        public List<Work> GetWorks(DateTime WorkDate)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_GetWorksPOP";

                    FillParameter(cmd, new string[] { "@WorkDate" }, new object[] { WorkDate });

                    conn.Open();
                    List<Work> list = Helper.DataReaderMapToList<Work>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                return null;
            }
        }

        // 생산목록 조회 (작업 아이디) -- POP화면 => 작업을 더블클릭한 경우
        public List<Produce> GetProduces(string produceID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_GetProducesPOP";

                    FillParameter(cmd, new string[] { "@ProduceID" }, new object[] { produceID });

                    conn.Open();
                    List<Produce> list = Helper.DataReaderMapToList<Produce>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                return null;
            }
        }


        // 생산실적 조회 (생산 아이디)
        public List<Produce> GetPerformance(string produceID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_GetPerformancePOP";

                    FillParameter(cmd, new string[] { "@ProduceID" }, new object[] { produceID });

                    conn.Open();
                    List<Produce> list = Helper.DataReaderMapToList<Produce>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                return null;
            }
        }


    }
}
