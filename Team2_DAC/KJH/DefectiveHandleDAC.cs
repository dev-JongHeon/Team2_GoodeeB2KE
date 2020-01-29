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
    public class DefectiveHandleDAC : ConnectionInfo
    {
        SqlConnection conn;
        public DefectiveHandleDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }

        public List<DefectiveHandleVO> GetAllDefectiveHandle()
        {
            try
            {
                List<DefectiveHandleVO> list = new List<DefectiveHandleVO>();
                string sql = "GetAllDefectiveHandle";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    list = Helper.DataReaderMapToList<DefectiveHandleVO>(cmd.ExecuteReader());
                    conn.Close();
                }
                return list;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public bool UpdateDefectiveHandle(DefectiveHandleVO item)
        {
            try
            {
                string sql = "UpdateDefectiveHandle";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@HandleID", item.HandleID);
                    cmd.Parameters.AddWithValue("@HandleName", item.HandleName);
                    cmd.Parameters.AddWithValue("@HandleExplain", item.HandleExplain);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result > 0;
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public bool DeleteDefectiveHandle(string id)
        {
            try
            {
                string sql = "DeleteDefectiveHandle";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@HandleID", id);
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result > 0;
                }
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}