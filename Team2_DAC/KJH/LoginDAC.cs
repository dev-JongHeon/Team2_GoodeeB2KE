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
    /// 로그인DAC
    /// </summary>
    public class LoginDAC :ConnectionInfo
    {
        SqlConnection conn;
        public LoginDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        /// <summary>
        /// 로그인 유저유효성검사와 권한을 가져옴
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public LoginVO DoLogin(int id, string pwd)
        {
            try
            {
                List<LoginVO> list = new List<LoginVO>();
                string sql = "KJH_Login";
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
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 비밀번호 변경하는 메서드
        /// </summary>
        /// <param name="login"></param>
        /// <param name="newpwd"></param>
        /// <returns></returns>
        public bool ChangePwd(LoginVO login,string newpwd)
        {
            try
            {
                string sql = "KJH_ChangePWD";
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
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 배송상태를 배송완료로 바꾸는 메서드
        /// </summary>
        /// <returns></returns>
        public bool OrderProcess()
        {
            try
            {
                string sql = "KJH_OrderProcess";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    int result = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    result = Convert.ToInt32(cmd.ExecuteNonQuery());                  
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
