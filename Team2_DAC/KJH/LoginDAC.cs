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

        public List<SearchedInfoVO> GetInfo(string div)
        {
            try
            {
                List<SearchedInfoVO> list = new List<SearchedInfoVO>();
                string sql = "GetInfo";
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@div", div);
                    conn.Open();
                    list = Helper.DataReaderMapToList<SearchedInfoVO>(cmd.ExecuteReader());
                    conn.Close();
                }
                return list;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}
