using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_DAC
{
    public class POPDAC
    {
        SqlConnection conn = null;
        public POPDAC()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Server = whyfi8888.ddns.net,11433; uid = team2; pwd = 1234; database = team2";
        }
        

        // 작업조회 (날짜 Default = 오늘 날짜)

        // 생산목록 조회 (작업 아이디)

        // 생산실적 조회 (생산 아이디)



    }
}
