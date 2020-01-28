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
    public class DefectiveTypeDAC : ConnectionInfo
    {
        SqlConnection conn;
        public DefectiveTypeDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        public List<DefectiveTypeVO> GetAllDefectiveTypes()
        {
            try
            {
                List<DefectiveTypeVO> list = new List<DefectiveTypeVO>();
                string sql = "GetAllDefectiveType";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    list = Helper.DataReaderMapToList<DefectiveTypeVO>(cmd.ExecuteReader());
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
