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
    public class BOMDAC : ConnectionInfo
    {
        SqlConnection conn = null;

        public BOMDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.ConnectionString;
        }

        public List<BOMVO> GetAllProduct()
        {
            string sql = "GetAllProduct";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<BOMVO> list = Helper.DataReaderMapToList<BOMVO>(cmd.ExecuteReader());
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