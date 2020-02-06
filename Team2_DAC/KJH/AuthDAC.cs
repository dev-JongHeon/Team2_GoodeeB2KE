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
    public class AuthDAC :ConnectionInfo
    {
        SqlConnection conn;
        public AuthDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        public List<AuthVO> GetAuthByID(int id)
        {
            try
            {
                List<AuthVO> list = new List<AuthVO>();
                string sql = "KJH_GetAuth";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    list  = Helper.DataReaderMapToList<AuthVO>(cmd.ExecuteReader());
                    conn.Close();
                }
                return list;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public bool UpdateAuth(int id,List<AuthVO> list)
        {
            try
            {
                string sql = "KJH_UpdateAuth";
                int result = 0;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    foreach (AuthVO item in list)
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@Form", item.Form);
                        cmd.Parameters.AddWithValue("@Auth", item.Auth);

                        result= cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    conn.Close();
                }
                return result > 0;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}
