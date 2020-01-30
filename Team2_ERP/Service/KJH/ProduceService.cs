using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP
{
    public class ProduceService
    {
        public List<ProduceVO> GetAllProduce()
        {
            ProduceDAC dac = new ProduceDAC();
            return dac.GetAllProduce();
        }

        public List<ProduceVO> GetProduceByWorkID(string id)
        {
            ProduceDAC dac = new ProduceDAC();
            return dac.GetProduceByWorkID(id);
        }

        public List<PerformanceVO> GetPerformanceByProduceID(string id)
        {
            ProduceDAC dac = new ProduceDAC();
            return dac.GetPerformanceByProduceID(id);
        }
    }
}
