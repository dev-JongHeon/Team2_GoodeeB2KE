using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC;
using Team2_VO;

namespace Team2_RealTimeMonitor
{
    public class Service
    {
        public List<LineMonitor> GetLineInfo()
        {
            return new MonitorDAC().GetLineInfo();
        }
    }
}

