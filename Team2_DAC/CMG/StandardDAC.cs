using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_VO;

namespace Team2_DAC
{
    public class StandardDAC : ConnectionInfo
    {
        SqlConnection conn = null;

        public StandardDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.ConnectionString;
        }

        public List<ResourceVO> GetAllResource()
        {
            string sql = "select Product_ID, Product_Name, Warehouse_ID, Product_Price, Product_Qty, Product_Safety, Product_DeletedYN, Product_Category from Product ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
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
    }
}
