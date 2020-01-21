﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_VO;

namespace Team2_DAC
{

    public class StockDAC
    {
        SqlConnection conn = null;
        public StockDAC()
        {
            string ConnectionStr = "Server = whyfi8888.ddns.net,11433; uid = team2; pwd = 1234; database = team2";
            conn = new SqlConnection(ConnectionStr);
        }

        public List<StockReceipt> GetStockReceipts() // 뷰 사용
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from StockReceipt_List";
                    conn.Open();
                    List<StockReceipt> list = Helper.DataReaderMapToList<StockReceipt>(cmd.ExecuteReader());
                    conn.Close();
                    
                    return list;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<StockStatus> GetStockStatus() // 뷰 사용
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from StockStatus_List";
                    conn.Open();
                    List<StockStatus> list = Helper.DataReaderMapToList<StockStatus>(cmd.ExecuteReader());
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
