using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_VO;

namespace Team2_DAC
{
    public class CustomerDAC : ConnectionInfo
    {
        SqlConnection conn = null;

        public CustomerDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.ConnectionString;
        }

        public List<CustomerVO> GetAllCustomer()
        {
            string sql = "select Customer_ID, Customer_UserID, Customer_PWD, Customer_Name, Customer_Phone, Customer_Email, Customer_Birth, (Customer_Address1 + '　' + Customer_Address2) as Customer_Address, Customer_DeletedYN from Customer where Customer_DeletedYN = 0 ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    List<CustomerVO> list = Helper.DataReaderMapToList<CustomerVO>(cmd.ExecuteReader());
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
