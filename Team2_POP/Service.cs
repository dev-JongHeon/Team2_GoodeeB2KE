using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_VO;
using Team2_DAC;

namespace Team2_POP
{
    public class Service
    {
        public List<ComboItemVO> GetFactoryList()
        {
            return new POPDAC().GetFactory();
        }

        public List<ComboItemVO> GetLineList(int factoryID)
        {
            return new POPDAC().GetLine(factoryID);
        }

        public List<Work> GetWorks(string date, int lineID)
        {
            return new POPDAC().GetWorks(date, lineID);
        }

        public List<Produce> GetProduce(string workID)
        {
            if (!string.IsNullOrEmpty(workID))
                return new POPDAC().GetProduces(workID);
            else
                return null;
        }
    }
}
