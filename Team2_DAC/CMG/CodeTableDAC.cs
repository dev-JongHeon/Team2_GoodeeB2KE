using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_VO;
using System.Data;

namespace Team2_DAC
{
    public class CodeTableDAC : ConnectionInfo
    {
        SqlConnection conn = null;

        public CodeTableDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.ConnectionString;
        }

        public List<CodeTableVO> GetAllCodeTable()
        {
            string sql = "select CodeTable_CodeID, CodeTable_CodeName, CodeTable_CodeExplain, CodeTable_DeletedYN from CodeTable where CodeTable_DeletedYN = 0 ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    List<CodeTableVO> list = Helper.DataReaderMapToList<CodeTableVO>(cmd.ExecuteReader());
                    return list;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool InsertCategory(CodeTableVO category)
        {
            string sql = "CMG_InsertCategory";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CodeTable_CodeName", category.CodeTable_CodeName);
                    cmd.Parameters.AddWithValue("@CodeTable_CodeExplain", category.CodeTable_CodeExplain);

                    conn.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool InsertDepart(CodeTableVO category)
        {
            string sql = "CMG_InsertDepart";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CodeTable_CodeName", category.CodeTable_CodeName);
                    cmd.Parameters.AddWithValue("@CodeTable_CodeExplain", category.CodeTable_CodeExplain);

                    conn.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool UpdateCodeTable(CodeTableVO code)
        {
            string sql = "Update CodeTable set CodeTable_CodeName = @CodeTable_CodeName, CodeTable_CodeExplain = @CodeTable_CodeExplain where CodeTable_CodeID = @CodeTable_CodeID ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CodeTable_CodeName", code.CodeTable_CodeName);
                    cmd.Parameters.AddWithValue("@CodeTable_CodeExplain", code.CodeTable_CodeExplain);
                    cmd.Parameters.AddWithValue("@CodeTable_CodeID", code.CodeTable_CodeID);

                    conn.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool DeleteCodeTable(string code)
        {
            if (code.Contains("Depart"))
            {
                string sql = "CMG_DeleteDepart";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodeTable_CodeID", code);
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        var rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                string sql = $"Update CodeTable set CodeTable_DeletedYN = {1} where CodeTable_CodeID = @CodeTable_CodeID ";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CodeTable_CodeID", code);

                        conn.Open();
                        var rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
