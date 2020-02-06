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
    public class LineDAC : ConnectionInfo
    {
        SqlConnection conn = null;

        public LineDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.ConnectionString;
        }

        public List<LineVO> GetAllLine()
        {
            string sql = "CMG_GetAllLine";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<LineVO> list = Helper.DataReaderMapToList<LineVO>(cmd.ExecuteReader());
                    return list;
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public List<ComboItemVO> GetComboFactory()
        {
            List<ComboItemVO> list = null;

            try
            {
                string sql = "GetInfo";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@div", "Factory");

                    conn.Open();
                    list = Helper.DataReaderMapToList<ComboItemVO>(cmd.ExecuteReader());

                    return list;
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public bool InsertLine(LineVO item)
        {
            string sql = "insert into Line(Line_Name, Factory_ID) values (@Line_Name, @Factory_ID) ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Line_Name", item.Line_Name);
                    cmd.Parameters.AddWithValue("@Factory_ID", item.Factory_ID);

                    conn.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public bool UpdateLine(LineVO item)
        {
            string sql = "Update Line set Line_Name = @Line_Name, Factory_ID = @Factory_ID where Line_ID = @Line_ID ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Line_Name", item.Line_Name);
                    cmd.Parameters.AddWithValue("@Factory_ID", item.Factory_ID);
                    cmd.Parameters.AddWithValue("@Line_ID", item.Line_ID);

                    conn.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public bool DeleteLine(int code)
        {
            string sql = $"Update Factory set Line_DeletedYN = {1} where Line_ID = @Line_ID ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Line_ID", code);

                    conn.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
