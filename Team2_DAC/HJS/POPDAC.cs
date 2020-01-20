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
    public class POPDAC : ConnectionInfo
    {
        SqlConnection conn = null;
        public POPDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.ConnectionString;
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

        #region 공정 조회 (가동 비가동)

        #endregion




        #region 삽입

        // 작업자 설정
        public void SetWorkerForPerformance(string produceID , int empID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_SetWorkerForPerformancePOP";

                    FillParameter(cmd, new string[] { "@ProduceID", "@Employee_ID" }, new object[] { produceID, empID });

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch
            {
                
            }
        }

        
        // 비가동 처리
        public void ToggleDowntime(DowntimePOP downtime, bool isDowntime)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_SetWorkerForPerformancePOP";

                    FillParameter(cmd, new string[] { "@LineID" }, new object[] {  });

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch
            {

            }
        }

        // 불량 처리

        #endregion
    }
}
