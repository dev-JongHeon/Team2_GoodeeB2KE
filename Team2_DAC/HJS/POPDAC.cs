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

        private SqlParameter OutParameter(SqlCommand cmd, string p)
        {
            SqlParameter param = new SqlParameter(p ,SqlDbType.NVarChar,8);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            return param;
        }

        #region 조회 (작업 - 생산 - 생산 실적)

        // 작업조회 (날짜 Default = 오늘 날짜)
        public List<Work> GetWorks(string workDate, int lineID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_GetWorksPOP";

                    FillParameter(cmd, new string[] { "@WorkDate", "@Line_ID" }, new object[] { workDate, lineID });

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

                    FillParameter(cmd, new string[] { "@Work_ID" }, new object[] { workID });

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
            catch (Exception err)
            {
                string sss = err.Message;
                return null;
            }
        }

        #endregion

        #region 공정 조회 (가동 비가동)

        #endregion

        #region 정보 조회 (공장, 공정)

        //공장 조회
        public List<ComboItemVO> GetFactory()
        {
            List<ComboItemVO> list = null;

            StringBuilder qrySelect = new StringBuilder();
            qrySelect.Append(" SELECT CONVERT(NVARCHAR(2), Factory_ID) AS ID, Factory_Name AS Name ");
            qrySelect.Append(" ,CONVERT(NVARCHAR(1), Factory_Division) AS CodeType ");
            qrySelect.Append(" FROM Factory ");


            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = qrySelect.ToString();

                    conn.Open();
                    list = Helper.DataReaderMapToList<ComboItemVO>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                return null;
            }
        }

        //공정조회
        public List<ComboItemVO> GetLine(int factoryID)
        {
            List<ComboItemVO> list = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    StringBuilder qryString = new StringBuilder();
                    qryString.Append(" SELECT CONVERT(NVARCHAR(5), Line_ID) AS ID, Line_Name AS Name  ");
                    qryString.Append(" FROM Line ");
                    qryString.Append(" WHERE Factory_ID = @Factory_ID ");

                    cmd.CommandText = qryString.ToString();

                    FillParameter(cmd, new string[] { "@Factory_ID" }, new object[] { factoryID });

                    conn.Open();
                    list = Helper.DataReaderMapToList<ComboItemVO>(cmd.ExecuteReader());
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


        //작업자 불러오기
        public List<ComboItemVO> GetWorker(int factoryDivision)
        {
            List<ComboItemVO> list = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetInfo";

                    string div = factoryDivision == 0 ? "DepProd1" : "DepProd2";

                    FillParameter(cmd, new string[] { "@div" }, new object[] { div });

                    conn.Open();
                    list = Helper.DataReaderMapToList<ComboItemVO>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                return null;
            }
        }

        #region 생산

        // 생산시작
        public string[] StartProduce(string produceID)
        {
            string[] list = new string[2];
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_StartProduction";

                    FillParameter(cmd, new string[] { "@ProduceID" }, new object[] { produceID });
                    
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    while(reader.Read())
                    {
                        list[0] = reader["Performance_ID"].ToString();  // 생산실적번호 
                        list[1] = reader["Qty"].ToString();  // 생산 수량                       
                    }
                    reader.Close();
                    conn.Close();

                    return list;
                }
            }
            catch(Exception err)
            {
                string sss = err.Message;
                return list;
            }

        }

        // 생산중
        public async void InProduction(string performanceID, int success, int bad)
        {
            string[] param = new string[] { "@PerformanceID", "@Success", "@Bad" };            

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_Operation";
                    
                    FillParameter(cmd, param, new object[] { performanceID, success, bad });

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    conn.Close();
                  
                }
            }
            catch(Exception err)
            {
                string msg = err.Message;
            }
        }

        // 생산 완료
        public void EndProduce(string performanceID, string produceID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_EndProduction";

                    FillParameter(cmd, new string[] { "@Performance_ID", "@Produce_ID" }, new object[] { performanceID, produceID });
                    
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch(Exception err)
            {
                string sss = err.Message;
            }
        }

        #endregion


        #region 삽입 - 작업자설정, 비가동처리

        // 작업자 설정
        public bool SetWorkerForPerformance(string produceID, int empID)
        {
            int iResult = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_SetPerformance";

                    FillParameter(cmd, new string[] { "@ProduceID", "@EmployeeID" }, new object[] { produceID, empID });

                    conn.Open();
                    iResult = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return iResult > 0;
            }

            catch
            {
                return false;
            }
        }


        // 비가동 처리 - 미구현
        public void ToggleDowntime(DowntimePOP downtime, bool isDowntime)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_SetWorkerForPerformancePOP";

                    FillParameter(cmd, new string[] { "@LineID" }, new object[] { isDowntime });

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


        #region POP창 - 불량처리 & 불량 유형

        #region Select 

            // 불량유형 & 처리코드
        public DataTable GetDefectiveCode()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;                    
                    cmd.CommandText = "SELECT ID, Name, DIV FROM View_SearchInfo WHERE Div in ('Defective','handle')";

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    conn.Open();
                    adapter.Fill(dt);
                    conn.Close();
                    adapter.Dispose();
                }

                return dt;
            }
            catch
            {
                return dt;
            }
        }

        //해당하는 생산실적중 불량 코드 가져오기
        public List<string> GetDefective(string performanceID)
        {
            List<string> list = new List<string>();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Defective_ID FROM Defective WHERE Performance_ID = @Performance_ID AND Defective_HandleDate IS NULL";

                    FillParameter(cmd, new string[] { "Performance_ID" }, new object[] { performanceID });

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                      list.Add(reader.GetString(0));
                    }
                    reader.Close();
                    conn.Close();
                }

                return list;
            }
            catch
            {
                return list;
            }
        }

        #endregion

        #region Update - 불량등록
        public bool SetDefective(string defectiveID, string handleCode, string defecCode)
        {
            StringBuilder qryUpdate = new StringBuilder();
            qryUpdate.Append(" UPDATE Defective SET Defective_HandleDate = GETDATE() ");
            qryUpdate.Append(" ,Defective_handle = @HandleCode, Defective_Code = @DefectiveCode ");
            qryUpdate.Append(" WHERE Defective_ID = @defectiveID ");

            int iResult = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = qryUpdate.ToString();

                    FillParameter(cmd, new string[] { "@HandleCode, DefectiveCode, defectiveID" },
                                       new object[] { handleCode, defecCode, defectiveID });

                    conn.Open();
                    iResult = cmd.ExecuteNonQuery();
                    conn.Close();

                    return iResult > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #endregion


        public List<ComboItemVO> GetDowntimeCode()
        {
            List<ComboItemVO> list = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetInfo";

                    FillParameter(cmd, new string[] { "@div" }, new object[] { "Downtime" });

                    conn.Open();
                    list = Helper.DataReaderMapToList<ComboItemVO>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                return null;
            }
        }

        public void SetDowntime(int lineID, string downtimeCode)
        {

        }
    }
}
