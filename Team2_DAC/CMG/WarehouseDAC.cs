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
            string sql = "CMG_GetAllWarehouse ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    List<WarehouseVO> list = Helper.DataReaderMapToList<WarehouseVO>(cmd.ExecuteReader());
                    return list;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool InsertWarehouse(WarehouseVO item)
        {
            string sql = "insert into Warehouse(Warehouse_Name, Warehouse_Address1, Warehouse_Address2, Warehouse_Number, Warehouse_Fax, Warehouse_Division, Warehouse_AddrNumber) values (@Warehouse_Name, @Warehouse_Address1, @Warehouse_Address2, @Warehouse_Number, @Warehouse_Fax, @Warehouse_Division, @Warehouse_AddrNumber) ";

            string[] str = item.Warehouse_Address.Split('　');
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Warehouse_Name", item.Warehouse_Name);
                    cmd.Parameters.AddWithValue("@Warehouse_Address1", str[0]);
                    cmd.Parameters.AddWithValue("@Warehouse_Address2", str[1]);
                    if (item.Warehouse_Number == null)
                    {
                        cmd.Parameters.AddWithValue("@Warehouse_Number", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Warehouse_Number", item.Warehouse_Number);
                    }
                    if(item.Warehouse_Fax == null)
                    {
                        cmd.Parameters.AddWithValue("@Warehouse_Fax", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Warehouse_Fax", item.Warehouse_Fax);
                    }
                    cmd.Parameters.AddWithValue("@Warehouse_Division", item.Warehouse_Division);
                    cmd.Parameters.AddWithValue("@Warehouse_AddrNumber", item.Warehouse_AddrNumber);

                    conn.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool UpdateWarehouse(WarehouseVO item)
        {
            string sql = "Update Warehouse set Warehouse_Name = @Warehouse_Name, Warehouse_Address1 = @Warehouse_Address1, Warehouse_Address2 = @Warehouse_Address2, Warehouse_Number = @Warehouse_Number, Warehouse_Fax = @Warehouse_Fax, Warehouse_Division = @Warehouse_Division, Warehouse_AddrNumber = @Warehouse_AddrNumber where Warehouse_ID = @Warehouse_ID ";

            string[] str = item.Warehouse_Address.Split('　');
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Warehouse_Name", item.Warehouse_Name);
                    cmd.Parameters.AddWithValue("@Warehouse_Address1", str[0]);
                    cmd.Parameters.AddWithValue("@Warehouse_Address2", str[1]);
                    if (item.Warehouse_Number == null)
                    {
                        cmd.Parameters.AddWithValue("@Warehouse_Number", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Warehouse_Number", item.Warehouse_Number);
                    }
                    if (item.Warehouse_Fax == null)
                    {
                        cmd.Parameters.AddWithValue("@Warehouse_Fax", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Warehouse_Fax", item.Warehouse_Fax);
                    }
                    cmd.Parameters.AddWithValue("@Warehouse_Division", item.Warehouse_Division);
                    cmd.Parameters.AddWithValue("@Warehouse_AddrNumber", item.Warehouse_AddrNumber);
                    cmd.Parameters.AddWithValue("@Warehouse_ID", item.Warehouse_ID);

                    conn.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool DeleteWarehouse(int code)
        {
            string sql = $"Update Warehouse set Warehouse_DeletedYN = {1} where Warehouse_ID = @Warehouse_ID ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Warehouse_ID", code);

                    conn.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
