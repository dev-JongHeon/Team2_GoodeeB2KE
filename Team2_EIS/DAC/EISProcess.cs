using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Team2_EIS.DAC
{
    public class EISProcess
    {
        SqlConnection conn = null;
        public EISProcess()
        {
            conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["Team2"].ConnectionString;
        }

        public DataSet GetTop(DataSet ds)
        {
            try
            {
                string sql = "KJH_EIS";
                using (SqlDataAdapter adpt = new SqlDataAdapter(sql, conn))
                {
                    conn.Open();
                    adpt.Fill(ds, "top");

                    sql = "KJH_EIS_Line";
                    adpt.SelectCommand.CommandText = sql;
                    adpt.Fill(ds, "midline");

                    sql = "KJH_EIS_TOP5";
                    adpt.SelectCommand.CommandText = sql;
                    adpt.Fill(ds, "midtop5");

                    sql = "KJH_EIS_TotalSales";
                    adpt.SelectCommand.CommandText = sql;
                    adpt.Fill(ds, "midsales");

                    conn.Close();
                }
                
                return ds;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        
    }
}