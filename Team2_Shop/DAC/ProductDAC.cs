using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Team2_Shop.Models;
using System.Web.Configuration;
using System.Data;

namespace Team2_Shop.DAC
{
    public class ProductDAC
    {
        SqlConnection conn = null;
        public ProductDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["WebDB"].ConnectionString;
        }

        // 오류가 난경우 로그를 기록하는 메서드
        private void WriteErrorLog(Exception ex)
        {
            string sss = ex.Message;
        }

        #region 파라미터 대입

        // 파라미터 넣는 함수 Null이 있는경우 ==> Null값을 전달
        private void FillParameter(SqlCommand cmd, string[] paramArr, object[] valueArr)
        {
            for (int i = 0; i < paramArr.Length; i++)
            {
                if (valueArr[i] != null)
                    cmd.Parameters.AddWithValue(paramArr[i], valueArr[i]);
                else
                    cmd.Parameters.AddWithValue(paramArr[i], DBNull.Value);
            }
        }

        private SqlParameter OutParameter(SqlCommand cmd, string p)
        {
            SqlParameter param = new SqlParameter(p, SqlDbType.NVarChar, 8);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            return param;
        }

        #endregion
        public List<Product> GetProducts(int page, int pageSize)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_Web_GetProductList";

                    FillParameter(cmd, new string[] { "@PAGE_NO", "@PAGE_SIZE" }, new object[] { page, pageSize });

                    conn.Open();
                    List<Product> list = Helper.DataReaderMapToList<Product>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public int GetProductTotalCount()
        {        
            try
            {
                int iResult = 0;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_Web_GetTotalProduct";

                    conn.Open();
                    iResult = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();

                    return iResult;
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        public Product GetProductInfo(string productID)
        {
            try
            {                
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_Web_GetProductInfo";

                    FillParameter(cmd, new string[] { "@ProductID" }, new object[] { productID });

                    conn.Open();
                    Product product = Helper.DataReaderMapToList<Product>(cmd.ExecuteReader())[0];
                    conn.Close();

                    return product;
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}