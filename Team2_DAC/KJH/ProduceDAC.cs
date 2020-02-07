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
    public class ProduceDAC : ConnectionInfo
    {
        SqlConnection conn;
        public ProduceDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        public List<ProduceVO> GetAllProduce()
        {
            try
            {
                List<ProduceVO> list = new List<ProduceVO>();
                string sql = "KJH_GetAllProduce";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    list = Helper.DataReaderMapToList<ProduceVO>(cmd.ExecuteReader());
                    conn.Close();
                }
                return list;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

        }

        public List<ProduceVO> GetProduceByWorkID(string id)
        {
            try
            {
                List<ProduceVO> list = new List<ProduceVO>();
                string sql = "KJH_GetProduceByWorkIDtest";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    list = Helper.DataReaderMapToList<ProduceVO>(cmd.ExecuteReader());
                    conn.Close();
                }
                return list;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public List<PerformanceVO> GetPerformanceByProduceID(string id)
        {
            try
            {
                List<PerformanceVO> list = new List<PerformanceVO>();
                string sql = "KJH_GetPerformanceByProduceID";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    conn.Open();
                    list = Helper.DataReaderMapToList<PerformanceVO>(cmd.ExecuteReader());
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
