using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP
{
    public class WorkService
    {
        public List<WorkVO> GetAllWork()
        {
            WorkDAC dac = new WorkDAC();
            return dac.GetAllWork();
        }
    }
}
