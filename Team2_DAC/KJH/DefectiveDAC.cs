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
                string sql = "KJH_GetAllDefective";
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

        public DataSet GetDefectiveByLine(string date)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "KJH_GetDefectiveByLine";
                using (SqlDataAdapter adpt = new SqlDataAdapter(sql, conn))
                {
                    adpt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adpt.SelectCommand.Parameters.AddWithValue("@Date", date);
                    conn.Open();
                    adpt.Fill(ds);
                    conn.Close();
                }
                return ds;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public DataSet GetDefectiveByDeftiveType(string date)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "KJH_GetDefectiveByDeftiveType";
                using (SqlDataAdapter adpt = new SqlDataAdapter(sql, conn))
                {
                    adpt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adpt.SelectCommand.Parameters.AddWithValue("@Date", date);
                    conn.Open();
                    adpt.Fill(ds);
                    conn.Close();
                }
                return ds;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public DataSet GetDefectiveByDeftiveHandleType(string date)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "KJH_GetDefectiveByDeftiveHandleType";
                using (SqlDataAdapter adpt = new SqlDataAdapter(sql, conn))
                {
                    adpt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adpt.SelectCommand.Parameters.AddWithValue("@Date", date);
                    conn.Open();
                    adpt.Fill(ds);
                    conn.Close();
                }
                return ds;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}
