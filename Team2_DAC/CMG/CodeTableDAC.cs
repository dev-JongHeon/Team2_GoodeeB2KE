using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_VO;

namespace Team2_DAC
{
    public class CodeTableDAC
    {
        SqlConnection conn = null;
        public CodeTableDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Server = whyfi8888.ddns.net,11433; uid = team2; pwd = 1234; database = team2";
        }

        public List<CodeTableVO> GetAllCodeTable()
        {
            string sql = "select CodeTable_CodeID, CodeTable_CodeName, CodeTable_CodeExplain from CodeTable ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    List<CodeTableVO> list = Helper.DataReaderMapToList<CodeTableVO>(cmd.ExecuteReader());
                    return list;
                }
            }
            catch(Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public bool InsertCategory()
        {
        }
    }
}
