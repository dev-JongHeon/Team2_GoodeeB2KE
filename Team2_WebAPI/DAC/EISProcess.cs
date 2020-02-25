using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Team2_WebAPI.DAC
{
    public class EISProcess
    {
        /// 0225 최종커밋
        SqlConnection conn = null;
        public EISProcess()
        {
            conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["Team2"].ConnectionString;
        }

        /// <summary>
        /// EIS에 필요한 모든정보를 DataSet으로 가져옴
        /// </summary>
        /// <param name="ds">EIS정보를 담을 DataSet</param>
        /// <returns></returns>
        public DataSet GetEIS(DataSet ds)
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

                    sql = "KJH_EIS_RecentOrder";
                    adpt.SelectCommand.CommandText = sql;
                    adpt.Fill(ds, "bottomorder");

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