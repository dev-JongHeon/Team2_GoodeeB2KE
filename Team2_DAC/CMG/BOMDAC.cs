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
    public class BOMDAC : ConnectionInfo
    {
        SqlConnection conn = null;

        public BOMDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.ConnectionString;
        }

        public List<ProductVO> GetAllProduct()
        {
            string sql = "GetAllProduct";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<ProductVO> list = Helper.DataReaderMapToList<ProductVO>(cmd.ExecuteReader());
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

        public List<BOMVO> GetAllCombination(string code)
        {
            string sql = "GetAllCombination";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@ProductID", code);
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<BOMVO> list = Helper.DataReaderMapToList<BOMVO>(cmd.ExecuteReader());
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

        public List<ComboItemVO> GetComboProductCategory()
        {
            List<ComboItemVO> list = null;

            try
            {
                string sql = "GetInfo";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@div", "ProductCategory");

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

        public List<ComboItemVO> GetComboResourceCategory(string div)
        {
            List<ComboItemVO> list = null;

            try
            {
                string sql = "GetComboResourceCategory";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@div", div);

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

        public void InsertSemiProduct(ProductVO Pitem, List<CombinationVO> citemList, int count)
        {
            conn.Open();

            SqlTransaction trans = conn.BeginTransaction();

            string productID = string.Empty;

            try
            {
                string productSql = "InsertSemiProduct";

                SqlCommand cmd = new SqlCommand(productSql, conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Product_Name", Pitem.Product_Name);
                cmd.Parameters.AddWithValue("@Product_Price", Pitem.Product_Price);
                cmd.Parameters.AddWithValue("@Product_Qty", Pitem.Product_Qty);
                cmd.Parameters.AddWithValue("@Product_Category", Pitem.Product_Category);
                object obj = cmd.ExecuteScalar();

                productID = obj.ToString();

                string combiSql = "insert into Combination(Product_ID, Combination_Product_ID, Combination_RequiredQty) values (@Product_ID, @Combination_Product_ID, @Combination_RequiredQty) ";

                SqlCommand dcmd = new SqlCommand(combiSql, conn);
                for (int i = 0; i < count; i++)
                {
                    dcmd.Transaction = trans;
                    dcmd.Parameters.AddWithValue("@Product_ID", productID);
                    dcmd.Parameters.AddWithValue("@Combination_Product_ID", citemList[i].Combination_Product_ID);
                    dcmd.Parameters.AddWithValue("@Combination_RequiredQty", citemList[i].Combination_RequiredQty);
                    dcmd.ExecuteNonQuery();
                    dcmd.Parameters.Clear();
                }

                trans.Commit();
            }
            catch (Exception err)
            {
                trans.Rollback();
                throw new Exception(err.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
