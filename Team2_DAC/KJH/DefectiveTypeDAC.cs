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
                string sql = "KJH_GetAllDefectiveType";
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

        public bool UpdateDefectiveType(DefectiveTypeVO item)
        {
            try
            {
                string sql = "KJH_UpdateDefectiveType";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@DefecID", item.DefecID);
                    cmd.Parameters.AddWithValue("@DefecName", item.DefecName);
                    cmd.Parameters.AddWithValue("@DefecExplain", item.DefecExplain);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result > 0;
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public bool DeleteDefectiveType(string id)
        {
            try
            {
                string sql = "KJH_DeleteDefectiveType";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DefecID", id);
                    
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
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
