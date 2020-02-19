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
    public class ResourceDAC : ConnectionInfo
    {
        SqlConnection conn = null;

        public ResourceDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.ConnectionString;
        }

        public List<ResourceVO> GetAllResource()
        {
            string sql = "CMG_GetAllResource";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<ResourceVO> list = Helper.DataReaderMapToList<ResourceVO>(cmd.ExecuteReader());
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

        public bool InsertResource(ResourceVO item)
        {
            string sql = "CMG_InsertResource";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Product_Name", item.Product_Name);
                    cmd.Parameters.AddWithValue("@Warehouse_ID", item.Warehouse_ID);
                    cmd.Parameters.AddWithValue("@Product_Price", item.Product_Price);
                    cmd.Parameters.AddWithValue("@Product_Qty", item.Product_Qty);
                    cmd.Parameters.AddWithValue("@Product_Safety", item.Product_Safety);
                    cmd.Parameters.AddWithValue("@Product_Category", item.Product_Category);
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

        public bool UpdateResource(ResourceVO item)
        {
            string sql = "CMG_UpdateResource";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Product_Name", item.Product_Name);
                    cmd.Parameters.AddWithValue("@Warehouse_ID", item.Warehouse_ID);
                    cmd.Parameters.AddWithValue("@Product_Price", item.Product_Price);
                    cmd.Parameters.AddWithValue("@Product_Qty", item.Product_Qty);
                    cmd.Parameters.AddWithValue("@Product_Safety", item.Product_Safety);
                    cmd.Parameters.AddWithValue("@Product_Category", item.Product_Category);
                    cmd.Parameters.AddWithValue("@Company_ID", item.Company_ID);
                    cmd.Parameters.AddWithValue("@Product_ID", item.Product_ID);
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

        public bool DeleteResource(string code)
        {
            string sql = "CMG_DeleteResource";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Product_ID", code);
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


        public List<ComboItemVO> GetComboWarehouse(int division)
        {
            List<ComboItemVO> list = null;

            try
            {
                string sql = "CMG_GetComboWarehouse";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Warehouse_Division", division);

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

        public List<ComboItemVO> GetComboMeterial()
        {
            List<ComboItemVO> list = null;

            try
            {
                string sql = "KJH_GetInfo";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@div", "CategoryM");

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

        public List<ComboItemVO> GetComboCompany()
        {
            List<ComboItemVO> list = null;

            try
            {
                string sql = "KJH_GetInfo";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@div", "Company");

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
