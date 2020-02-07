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
            string sql = "CMG_GetAllProduct";

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

        public List<ProductVO> GetProductList(string type)
        {
            string sql = "CMG_GetProductList";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", type);
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
            string sql = "CMG_GetAllCombination";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", code);
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
        public List<BOMVO> GetAllCombination1(string code)
        {
            try
            {
                List<BOMVO> list = new List<BOMVO>();
                DataSet ds = new DataSet();
                string sql = "CMG_GetAllCombination1";
                using (SqlDataAdapter adpt = new SqlDataAdapter(sql, conn))
                {
                    adpt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adpt.SelectCommand.Parameters.AddWithValue("@id", code);
                    conn.Open();
                    adpt.Fill(ds);
                    conn.Close();
                    list=Helper.ConvertDataTableToList<BOMVO>(ds.Tables[0]);
                }
                return list;
                
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

        public List<BOMVO> GetAllCombinationReverse(string type)
        {
            string sql = "CMG_GetAllCombinationReverse";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", type);
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
                string sql = "KJH_GetInfo";

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
                string sql = "CMG_GetComboResourceCategory";

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
                string productSql = "CMG_InsertSemiProduct";

                SqlCommand cmd = new SqlCommand(productSql, conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Product_Name", Pitem.Product_Name);
                cmd.Parameters.AddWithValue("@Product_Price", Pitem.Product_Price);
                cmd.Parameters.AddWithValue("@Product_Qty", Pitem.Product_Qty);
                cmd.Parameters.AddWithValue("@Warehouse_ID", Pitem.Warehouse_ID);
                cmd.Parameters.AddWithValue("@Product_Safety", Pitem.Product_Safety);
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

        public void UpdateSemiProduct(ProductVO Pitem, List<CombinationVO> citemList, int count)
        {
            conn.Open();

            SqlTransaction trans = conn.BeginTransaction();

            List<CombinationVO> list = null;

            try
            {
                string productSql = "CMG_UpdateSemiProduct";

                SqlCommand cmd = new SqlCommand(productSql, conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Product_Name", Pitem.Product_Name);
                cmd.Parameters.AddWithValue("@Product_Price", Pitem.Product_Price);
                cmd.Parameters.AddWithValue("@Product_Qty", Pitem.Product_Qty);
                cmd.Parameters.AddWithValue("@Product_Category", Pitem.Product_Category);
                cmd.Parameters.AddWithValue("@Warehouse_ID", Pitem.Warehouse_ID);
                cmd.Parameters.AddWithValue("@Product_Safety", Pitem.Product_Safety);
                cmd.Parameters.AddWithValue("@Product_ID", Pitem.Product_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<CombinationVO>(reader);

                string combiSql = "Update Combination Set Combination_Product_ID = @Combination_Product_ID, Combination_RequiredQty = @Combination_RequiredQty Where Combination_ID = @Combination_ID ";

                SqlCommand dcmd = new SqlCommand(combiSql, conn);
                for (int i = 0; i < count; i++)
                {
                    dcmd.Transaction = trans;
                    dcmd.Parameters.AddWithValue("@Combination_Product_ID", citemList[i].Combination_Product_ID);
                    dcmd.Parameters.AddWithValue("@Combination_RequiredQty", citemList[i].Combination_RequiredQty);
                    dcmd.Parameters.AddWithValue("@Combination_ID", list[i].Combination_ID);
                    reader.Close();
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

        public void DeleteSemiProduct(ProductVO Pitem)
        {
            conn.Open();

            SqlTransaction trans = conn.BeginTransaction();

            List<CombinationVO> list = null;

            try
            {
                string productSql = "CMG_DeleteSemiProduct";

                SqlCommand cmd = new SqlCommand(productSql, conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Product_ID", Pitem.Product_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<CombinationVO>(reader);

                string combiSql = "Update Combination Set Combination_DeletedYN = 1 Where Combination_ID = @Combination_ID ";

                SqlCommand dcmd = new SqlCommand(combiSql, conn);
                for (int i = 0; i < list.Count; i++)
                {
                    dcmd.Transaction = trans;
                    dcmd.Parameters.AddWithValue("@Combination_ID", list[i].Combination_ID);
                    reader.Close();
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

        public void InsertProduct(ProductVO Pitem, List<CombinationVO> citemList, int count)
        {
            conn.Open();

            SqlTransaction trans = conn.BeginTransaction();

            string productID = string.Empty;

            try
            {
                string productSql = "CMG_InsertProduct";

                SqlCommand cmd = new SqlCommand(productSql, conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Product_Name", Pitem.Product_Name);
                cmd.Parameters.AddWithValue("@Product_Price", Pitem.Product_Price);
                cmd.Parameters.AddWithValue("@Product_Qty", Pitem.Product_Qty);
                cmd.Parameters.AddWithValue("@Product_Image", Pitem.Product_Image);
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

        public void UpdateProduct(ProductVO Pitem, List<CombinationVO> citemList, int count)
        {
            conn.Open();

            SqlTransaction trans = conn.BeginTransaction();

            List<CombinationVO> list = null;

            try
            {
                string productSql = "CMG_UpdateProduct";

                SqlCommand cmd = new SqlCommand(productSql, conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Product_Name", Pitem.Product_Name);
                cmd.Parameters.AddWithValue("@Product_Price", Pitem.Product_Price);
                cmd.Parameters.AddWithValue("@Product_Qty", Pitem.Product_Qty);
                cmd.Parameters.AddWithValue("@Product_ID", Pitem.Product_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<CombinationVO>(reader);

                string combiSql = "Update Combination Set Combination_Product_ID = @Combination_Product_ID, Combination_RequiredQty = @Combination_RequiredQty Where Combination_ID = @Combination_ID ";

                SqlCommand dcmd = new SqlCommand(combiSql, conn);
                for (int i = 0; i < count; i++)
                {
                    dcmd.Transaction = trans;
                    dcmd.Parameters.AddWithValue("@Combination_Product_ID", citemList[i].Combination_Product_ID);
                    dcmd.Parameters.AddWithValue("@Combination_RequiredQty", citemList[i].Combination_RequiredQty);
                    dcmd.Parameters.AddWithValue("@Combination_ID", list[i].Combination_ID);
                    reader.Close();
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

        public void DeleteProduct(ProductVO Pitem)
        {
            conn.Open();

            SqlTransaction trans = conn.BeginTransaction();

            List<CombinationVO> list = null;

            try
            {
                string productSql = "CMG_DeleteProduct";

                SqlCommand cmd = new SqlCommand(productSql, conn);
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Product_ID", Pitem.Product_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<CombinationVO>(reader);

                string combiSql = "Update Combination Set Combination_DeletedYN = 1 Where Combination_ID = @Combination_ID ";

                SqlCommand dcmd = new SqlCommand(combiSql, conn);
                for (int i = 0; i < list.Count; i++)
                {
                    dcmd.Transaction = trans;
                    dcmd.Parameters.AddWithValue("@Combination_ID", list[i].Combination_ID);
                    reader.Close();
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

        public List<ProductVO> GetImage(string code)
        {
            string sql = "select Product_Image from Product where Product_ID = @Product_ID";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Product_ID", code);
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
    }
}