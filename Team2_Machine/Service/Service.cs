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
        public void Producing(string performanceID, int success, int bad)
        {
            new POPDAC().InProduction(performanceID, success, bad);
        }

        public void EndProduce(string performanceID)
        {
            new POPDAC().EndProduce(performanceID);
        }
    }
}
