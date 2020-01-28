using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_DAC
{
    public class LineDAC : ConnectionInfo
    {
        SqlConnection conn = null;

        public LineDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = this.ConnectionString;
        }
    }
}
