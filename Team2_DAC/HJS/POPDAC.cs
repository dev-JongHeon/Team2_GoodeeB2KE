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

        #region 조회 (작업 - 생산 - 생산 실적)

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
        public List<Produce> GetProduces(string workID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_GetProducesPOP";

                    FillParameter(cmd, new string[] { "@ProduceID" }, new object[] { workID });

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
        public List<Performance> GetPerformance(string produceID)
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
                    List<Performance> list = Helper.DataReaderMapToList<Performance>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region 삽입

        // 작업자 설정
        // 생산 실적을 봄 ==> 생산실적개수가 없는 경우 삽입
        // 생산 실적을 봄 ==> 생산실적이 있는경우 생산실적에 생산데이터가 있는지 없는지 확인 없는경우 ==> 작업자명 변경

        // 비가동 처리

        // 불량 처리

        #endregion
    }
}
