using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP
{
    public class AuthService
    {
        public List<AuthVO> GetAuthByID(int id)
        {
            AuthDAC dac = new AuthDAC();
            return dac.GetAuthByID(id);
        }

        public bool UpdateAuth(int id, List<AuthVO> list)
        {
            AuthDAC dac = new AuthDAC();
            return dac.UpdateAuth(id, list);
        }
    }
}
