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
            catch (Exception err)
            {
                throw new Exception(err.Message);
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

        public bool UpdateResource(ResourceVO item)
        {
            string sql = "Update Product set Product_Name = @Product_Name, Warehouse_ID = @Warehouse_ID, Product_Price = @Product_Price, Product_Qty = @Product_Qty, Product_Safety = @Product_Safety, Product_Category = @Product_Category, Product_Image = @Product_Image where Product_ID = @Product_ID ";

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
                    cmd.Parameters.AddWithValue("@Product_Image", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Product_ID", item.Product_ID);

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

        public bool DeleteResource(string code)
        {
            string sql = $"Update Product set Product_DeletedYN = {1} where Product_ID = @Product_ID ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Product_ID", code);

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
            catch (Exception err)
            {
                throw new Exception(err.Message);
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
                string sql = "GetInfo";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@div", "CategoryM");

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
    }
}
