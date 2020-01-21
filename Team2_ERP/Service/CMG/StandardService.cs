using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP.Service.CMG
{
    public class StandardService
    {
        public List<ResourceVO> GetAllResource()
        {
            StandardDAC dac = new StandardDAC();
            return dac.GetAllResource();
        }
    }
}
