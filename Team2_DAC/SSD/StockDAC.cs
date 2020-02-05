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
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT StockReceipt_ID, StockReceipt_Division, StockReceipt_Date, Warehouse_ID, Warehouse_Division,                      Warehouse_Name, Product_ID, Product_Name, StockReceipt_Quantity, Employees_Name,                                  StockReceipt_Division1 ");
                    sb.Append("FROM   StockReceipt_List ");

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();
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
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT Product_ID, Product_Name, CodeTable_CodeName, Warehouse_ID, Warehouse_Name, Product_Price,                        Product_Qty, Product_Safety, Count_Subtract, Product_DeletedYN ");
                    sb.Append("FROM   StockStatus_List ");

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();
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
