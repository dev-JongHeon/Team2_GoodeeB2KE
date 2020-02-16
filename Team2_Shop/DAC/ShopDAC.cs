using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Team2_Shop.Models;

namespace Team2_Shop.DAC
{
    public class ShopDAC
    {
        SqlConnection conn = null;
        public ShopDAC()
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

        // 유저관련 -----------------------------
        // 로그인 관련 (로그인, 회원가입)
        // 프로필 관련 (주문내역, 배송조회)

        public WebCustomerModel CheckUser(WebLoginModel loginInfo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proc_Web_LoginCheck";

                    FillParameter(cmd, new string[] { "@UID", "@PWD" }, new object[] { loginInfo.UserID, loginInfo.UserPwd });

                    conn.Open();
                    List<WebCustomerModel> list = Helper.DataReaderMapToList<WebCustomerModel>(cmd.ExecuteReader());
                    conn.Close();

                    return list.Find(e => e.Customer_UserID.Equals(loginInfo.UserID, StringComparison.OrdinalIgnoreCase));
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


        // 상품관련 ----------------------------
        // 상품목록


        // 주문관련
        // 주문테이블, 주문상세 테이블 삽입하는 코드
        public bool CheckOut(Cart cart, ShipInfo shipInfo)
        {
            int iResult = 0;
            conn.Open();
            SqlTransaction sTrans = conn.BeginTransaction();

            try
            {
                // 주문을 삽입하는 코드
                using (SqlCommand orderCmd = new SqlCommand())
                {
                    orderCmd.Connection = conn;
                    orderCmd.Transaction = sTrans;
                    orderCmd.CommandText = "proc_InsertOrder";
                    orderCmd.CommandType = CommandType.StoredProcedure;

                    FillParameter(orderCmd, new string[] { "@CustomerID", "@Addr1", "@Addr2" }, new object[] { shipInfo.CustomerID, shipInfo.Addr1, shipInfo.Addr2 });

                    string orderID =  orderCmd.ExecuteScalar().ToString();

                    // 주문 상세 삽입코드
                    for (int i = 0; i < cart.Lines.Count; i++)
                    {
                        using(SqlCommand detailCmd = new SqlCommand())
                        {
                            detailCmd.Connection = conn;
                            detailCmd.Transaction = sTrans;
                            detailCmd.CommandText = "INSERT INTO OrderDetail(Order_ID, Product_ID, OrderDetail_Qty) VALUES (@OrdID, @PrdID, @Qty)";

                            FillParameter(detailCmd, new string[] { "@OrdID", "@PrdID", "@Qty" }, new object[] { orderID, cart.Lines[i].Product.Product_ID, cart.Lines[i].Qty });

                            iResult += detailCmd.ExecuteNonQuery();
                        }
                    }
                }
                sTrans.Commit();
                return iResult > 0;
            }
            catch (Exception ex)
            {
                sTrans.Rollback();
                WriteErrorLog(ex);
                return iResult > 0;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
