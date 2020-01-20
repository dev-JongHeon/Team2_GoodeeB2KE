using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_DAC.KJH
{
    public class LoginDAC :ConnectionInfo
    {
        SqlConnection conn;
        public LoginDAC()
        {
            conn = new SqlConnection(this.ConnectionString);
        }


    }
}
