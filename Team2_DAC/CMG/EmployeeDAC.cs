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
    public class EmployeeDAC : ConnectionInfo
    {
        SqlConnection conn = null;

        public EmployeeDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.ConnectionString;
        }

        public List<EmployeeVO> GetAllEmployee()
        {
            string sql = "GetAllEmployee";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<EmployeeVO> list = Helper.DataReaderMapToList<EmployeeVO>(cmd.ExecuteReader());
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

        public List<ComboItemVO> GetComboEmployee()
        {
            List<ComboItemVO> list = null;

            try
            {
                string sql = "GetInfo";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@div", "Department");

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

        public bool InsertEmployee(EmployeeVO item)
        {
            string sql = "Insert Into Employee(Employees_Name, CodeTable_CodeID, Employees_Hiredate, Employees_Resigndate, Employees_PWD, Employees_Phone, Employees_Birth) values(@Employees_Name, @CodeTable_CodeID, @Employees_Hiredate, @Employees_Resigndate, @Employees_PWD, @Employees_Phone, @Employees_Birth) ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Employees_Name", item.Employees_Name);
                    cmd.Parameters.AddWithValue("@CodeTable_CodeID", item.CodeTable_CodeID);
                    cmd.Parameters.AddWithValue("@Employees_Hiredate", item.Employees_Hiredate);
                    cmd.Parameters.AddWithValue("@Employees_PWD", item.Employees_PWD);
                    cmd.Parameters.AddWithValue("@Employees_Phone", item.Employees_Phone);
                    cmd.Parameters.AddWithValue("@Employees_Birth", item.Employees_Birth);

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

        public bool UpdateEmployee(EmployeeVO item)
        {
            string sql = "Update Employee set Employees_Name = @Employees_Name, CodeTable_CodeID = @CodeTable_CodeID, Employees_Resigndate = @Employees_Resigndate, Employees_PWD = @Employees_PWD, Employees_Phone = @Employees_Phone, Employees_Birth = @Employees_Birth where Employees_ID = @Employees_ID ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Employees_Name", item.Employees_Name);
                    cmd.Parameters.AddWithValue("@CodeTable_CodeID", item.CodeTable_CodeID);
                    cmd.Parameters.AddWithValue("@Employees_Resigndate", item.Employees_Resigndate);
                    cmd.Parameters.AddWithValue("@Employees_PWD", item.Employees_PWD);
                    cmd.Parameters.AddWithValue("@Employees_Phone", item.Employees_Phone);
                    cmd.Parameters.AddWithValue("@Employees_Birth", item.Employees_Birth);
                    cmd.Parameters.AddWithValue("@Employees_ID", item.Employees_ID);

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
