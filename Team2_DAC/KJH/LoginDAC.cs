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
    }
}
