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
    public class DowntimeDAC : ConnectionInfo
    {
        SqlConnection conn;
        public DowntimeDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        public List<DowntimeVO> GetAllDowntime()
        {
            try
            {
                List<DowntimeVO> list = new List<DowntimeVO>();
                string sql = "GetAllDowntime";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    list = Helper.DataReaderMapToList<DowntimeVO>(cmd.ExecuteReader());
                    conn.Close();
                }
                return list;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public DataSet GetDowntimeByLine(string date)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "GetDowntimeByLine";
                using (SqlDataAdapter adpt = new SqlDataAdapter(sql,conn))
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

        public DataSet GetDowntimeByLine2(string line)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "GetDowntimeByLine2";
                using (SqlDataAdapter adpt = new SqlDataAdapter(sql, conn))
                {
                    adpt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adpt.SelectCommand.Parameters.AddWithValue("@line", line);
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


        public DataSet GetDowntimeByType(string date)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = "GetDowntimeByType";
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
