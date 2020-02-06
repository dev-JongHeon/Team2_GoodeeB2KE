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
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT Balju_ID, Company_ID, Company_Name, Balju_Date, Employees_Name, Balju_DeletedYN ");
                    sb.Append("FROM   BaljuList ");
                    
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();

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
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT Balju_ID, Company_ID, Company_Name, Balju_Date,                                                                   Balju_ReceiptDate, Employees_Name, Balju_DeletedYN ");
                    sb.Append("FROM   BaljuList_Completed_Top");
                    
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();
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
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT Balju_ID, Product_ID, Product_Name, BaljuDetail_Qty ");
                    sb.Append("FROM   BaljuList_Detail ");
                    //sb.Append("WHERE  Balju_ID IN (@Balju_ID)");

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sb.ToString();
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

        public void UpdateBalju_Processed(string balju_ID)
        {
            int check = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UpdateBalju_Processed";
                    cmd.Parameters.AddWithValue("@Balju_ID", balju_ID);
                    conn.Open();
                    check = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show(err.Message);
            }
            finally
            {
                if (check >= 1)
                {
                    System.Windows.Forms.MessageBox.Show("발주처리완료!");
                }
            }
        }

        public void DeleteBalju(string balju_ID)
        {
            int check = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteBalju";
                    cmd.Parameters.AddWithValue("@Balju_ID", balju_ID);
                    conn.Open();
                    check = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show(err.Message);
            }
            finally
            {
                if (check > 0)
                {
                    System.Windows.Forms.MessageBox.Show("삭제완료!");
                }
            }

        }
    }

    public static class ExtensionParams
    {
        public static SqlParameter[] AddArrayParameters<T>(this SqlCommand cmd, string paramNameRoot, IEnumerable<T> values, SqlDbType? dbType = null, int? size = null)
        {
            var parameters = new List<SqlParameter>();
            var parameterNames = new List<string>();
            var paramNbr = 1;
            foreach (var value in values)
            {
                var paramName = string.Format("@{0}{1}", paramNameRoot, paramNbr++);
                parameterNames.Add(paramName);
                SqlParameter p = new SqlParameter(paramName, value);
                if (dbType.HasValue)
                    p.SqlDbType = dbType.Value;
                if (size.HasValue)
                    p.Size = size.Value;
                cmd.Parameters.Add(p);
                parameters.Add(p);
            }

            cmd.CommandText = cmd.CommandText.Replace("{" + paramNameRoot + "}", string.Join(",", parameterNames));

            return parameters.ToArray();
        }
    }
}
