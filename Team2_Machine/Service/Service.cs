using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC;

namespace Team2_Machine
{
    public class Service
    {
        // 생산 진행
        public void Producing(string performanceID, int success, int bad)
        {
            new POPDAC().InProduction(performanceID, success, bad);
        }

        // 생산 종료
        public void EndProduce(string performanceID)
        {
            new POPDAC().EndProduce(performanceID);
        }
    }
}
