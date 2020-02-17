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
    public class FactoryDAC : ConnectionInfo
    {
        SqlConnection conn = null;

        public FactoryDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.ConnectionString;
        }

        public List<FactoryVO> GetAllFactory()
        {
            string sql = "CMG_GetAllFactory";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<FactoryVO> list = Helper.DataReaderMapToList<FactoryVO>(cmd.ExecuteReader());
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

        public bool InsertFactory(FactoryVO item)
        {
            string sql = "insert into Factory(Factory_Name, Factory_Division, Factory_Number, Factory_Fax, Factory_Address1, Factory_Address2) values (@Factory_Name, @Factory_Division, @Factory_Number, @Factory_Fax, @Factory_Address1, @Factory_Address2) ";

            string[] str = item.Factory_Address.Split('　');
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Factory_Name", item.Factory_Name);
                    cmd.Parameters.AddWithValue("@Factory_Address1", str[0]);
                    cmd.Parameters.AddWithValue("@Factory_Address2", str[1]);
                    cmd.Parameters.AddWithValue("@Factory_Division", item.Factory_Division);
                    cmd.Parameters.AddWithValue("@Factory_Number", item.Factory_Number);
                    if (item.Factory_Fax == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@Factory_Fax", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Factory_Fax", item.Factory_Fax);
                    }

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

        public bool UpdateFactory(FactoryVO item)
        {
            string sql = "Update Factory set Factory_Name = @Factory_Name, Factory_Address1 = @Factory_Address1, Factory_Address2 = @Factory_Address2, Factory_Division = @Factory_Division, Factory_Number = @Factory_Number, Factory_Fax = @Factory_Fax where Factory_ID = @Factory_ID ";

            string[] str = item.Factory_Address.Split('　');
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Factory_Name", item.Factory_Name);
                    cmd.Parameters.AddWithValue("@Factory_Address1", str[0]);
                    cmd.Parameters.AddWithValue("@Factory_Address2", str[1]);
                    cmd.Parameters.AddWithValue("@Factory_Number", item.Factory_Number);
                    cmd.Parameters.AddWithValue("@Factory_Fax", item.Factory_Fax);
                    cmd.Parameters.AddWithValue("@Factory_Division", item.Factory_Division);
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

        public bool DeleteFactory(int code)
        {
            string sql = "CMG_DeleteFactory";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Factory_ID", code);
                    cmd.CommandType = CommandType.StoredProcedure;

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
