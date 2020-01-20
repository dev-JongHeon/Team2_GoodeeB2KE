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
    public class BaljuDAC
    {
        SqlConnection conn = null;
        public BaljuDAC()
        {
            string ConnectionStr = "Server = whyfi8888.ddns.net,11433; uid = team2; pwd = 1234; database = team2";
            conn = new SqlConnection(ConnectionStr);
        }

        // 발주조회
        public List<Balju> GetBaljuList()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from BaljuList";
                    conn.Open();
                    List<Balju> list = Helper.DataReaderMapToList<Balju>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Balju> GetBalju_CompletedList()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from BaljuList_Completed_Top";
                    conn.Open();
                    List<Balju> list = Helper.DataReaderMapToList<Balju>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<BaljuDetail> GetBalju_DetailList()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from BaljuList_Detail";
                    conn.Open();
                    List<BaljuDetail> list = Helper.DataReaderMapToList<BaljuDetail>(cmd.ExecuteReader());
                    conn.Close();

                    return list;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
