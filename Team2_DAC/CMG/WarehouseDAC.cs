using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_VO;

namespace Team2_DAC
{
    public class WarehouseDAC : ConnectionInfo
    {
        SqlConnection conn = null;

        public WarehouseDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.ConnectionString;
        }

        public List<WarehouseVO> GetAllWarehouse()
        {
            string sql = "select Warehouse_ID, Warehouse_Name, (Warehouse_Address1 + '　' + Warehouse_Address2) as Warehouse_Address, Warehouse_Number, Warehouse_Fax, Warehouse_DeletedYN, Warehouse_Division from Warehouse ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    List<WarehouseVO> list = Helper.DataReaderMapToList<WarehouseVO>(cmd.ExecuteReader());
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
