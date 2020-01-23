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
    public class LoginDAC :ConnectionInfo
    {
        public static Dictionary<string, string> menulist = new Dictionary<string, string>
        {
            {"UserAuth","사용자권한설정" },
            {"Work","작업대기현황" },
            {"Produce","생산실적현황" },
            {"DowntimeType","비가동유형" },
            {"Downtime","비가동현황" },
            {"DefectiveType","불량유형" },
            {"DefectiveHandle","불량처리유형" },
            {"Defective","불량현황" },
            {"StockStatus","재고현황" },
            {"InOutList_MaterialWarehouse","자재수불현황" },
            {"InOutList_SemiProductWarehouse","반제품수불현황" },
            {"BaljuList","발주현황" },
            {"BaljuList_Completed","발주완료현황" },
            {"OrderMainForm","주문현황" },
            {"OrderCompleteForm","주문처리완료현황" },
            {"ShipmentMainForm","출하현황" },
            {"ShipmentCompleteForm","출하완료현황" },
            {"SalesMainForm","매출현황" },
            {"Department","부서관리" },
            {"Employees","사원관리" },
            {"Company","거래처관리" },
            {"Customer","고객관리" },
            {"Category","카테고리관리" },
            {"Factory","공장&공정관리" },
            {"Resource","원자재관리" },
            {"Warehouse","창고 관리" },
            {"BOM","BOM 관리" },
        };
        SqlConnection conn;
        public LoginDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        public LoginVO DoLogin(int id, string pwd)
        {
            try
            {
                List<LoginVO> list = new List<LoginVO>();
                string sql = "Login";
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Pwd", pwd);
                    conn.Open();
                    list = Helper.DataReaderMapToList<LoginVO>(cmd.ExecuteReader());
                    conn.Close();
                }
                return (list[0].Employee_ID==0)? null:list[0];
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public bool ChangePwd(LoginVO login,string newpwd)
        {
            try
            {
                string sql = "ChangePWD";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", login.Employee_ID);
                    cmd.Parameters.AddWithValue("@Pwd", login.Employee_PWD);
                    cmd.Parameters.AddWithValue("@newPwd", newpwd);
                    conn.Open();
                    int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                    conn.Close();
                    return result>0;
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public bool InsertAuth(int id)
        {
            try
            {
                string sql = "InsertUserAuth";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    int result = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    foreach (string name in menulist.Keys)
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@Form", name);
                        cmd.Parameters.AddWithValue("@FormDescribtion", menulist[name]);
                        result=Convert.ToInt32(cmd.ExecuteNonQuery());
                        cmd.Parameters.Clear();
                    }
                    conn.Close();
                    return result > 0;
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}
