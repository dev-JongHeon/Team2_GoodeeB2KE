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
    public class DefectiveDAC : ConnectionInfo
    {
        SqlConnection conn;
        public DefectiveDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        public List<DefectiveVO> GetAllDefective()
        {
            try
            {
                List<DefectiveVO> list = new List<DefectiveVO>();
                string sql = "GetAllDefective";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    list = Helper.DataReaderMapToList<DefectiveVO>(cmd.ExecuteReader());
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
