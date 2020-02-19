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
    public class CompanyDAC : ConnectionInfo
    {
        SqlConnection conn = null;

        public CompanyDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.ConnectionString;
        }

        public List<CompanyVO> GetAllCompany()
        {
            string sql = "CMG_GetAllCompany";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<CompanyVO> list = Helper.DataReaderMapToList<CompanyVO>(cmd.ExecuteReader());
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

        public bool InsertCompany(CompanyVO item)
        {
            string sql = "insert into Company(Company_Name, Company_AddrNumber, Company_Address1, Company_Address2, Company_Number, Company_Fax, CodeTable_CodeID, Company_Owner) values (@Company_Name, @Company_AddrNumber, @Company_Address1, @Company_Address2, @Company_Number, @Company_Fax, @CodeTable_CodeID, @Company_Owner) ";

            string[] str = item.Company_Address.Split('　');
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Company_Name", item.Company_Name);
                    cmd.Parameters.AddWithValue("@Company_AddrNumber", item.Company_AddrNumber);
                    cmd.Parameters.AddWithValue("@Company_Address1", str[0]);
                    cmd.Parameters.AddWithValue("@Company_Address2", str[1]);
                    cmd.Parameters.AddWithValue("@Company_Number", item.Company_Number);
                    if (item.Company_Fax == null)
                        cmd.Parameters.AddWithValue("@Company_Fax", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Company_Fax", item.Company_Fax);
                    cmd.Parameters.AddWithValue("@CodeTable_CodeID", item.CodeTable_CodeID);
                    cmd.Parameters.AddWithValue("@Company_Owner", item.Company_Owner);

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

        public bool UpdateCompany(CompanyVO item)
        {
            string sql = "Update Company set Company_Name = @Company_Name, Company_Address1 = @Company_Address1, Company_Address2 = @Company_Address2, Company_Number = @Company_Number, Company_Fax = @Company_Fax, CodeTable_CodeID = @CodeTable_CodeID, Company_Owner = @Company_Owner where Company_ID = @Company_ID ";

            string[] str = item.Company_Address.Split('　');
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Company_Name", item.Company_Name);
                    cmd.Parameters.AddWithValue("@Company_Address1", str[0]);
                    cmd.Parameters.AddWithValue("@Company_Address2", str[1]);
                    cmd.Parameters.AddWithValue("@Company_Number", item.Company_Number);
                    if (item.Company_Fax == null)
                        cmd.Parameters.AddWithValue("@Company_Fax", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Company_Fax", item.Company_Fax);
                    cmd.Parameters.AddWithValue("@CodeTable_CodeID", item.CodeTable_CodeID);
                    cmd.Parameters.AddWithValue("@Company_Owner", item.Company_Owner);
                    cmd.Parameters.AddWithValue("@Company_ID", item.Company_ID);

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

        public bool DeleteCompany(int code)
        {
            string sql = $"Update Company set Company_DeletedYN = {1} where Company_ID = @Company_ID ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Company_ID", code);

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

        public List<ComboItemVO> GetComboSector()
        {
            List<ComboItemVO> list = null;

            try
            {
                string sql = "KJH_GetInfo";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@div", "Sector");

                    conn.Open();
                    list = Helper.DataReaderMapToList<ComboItemVO>(cmd.ExecuteReader());

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
    }
}
