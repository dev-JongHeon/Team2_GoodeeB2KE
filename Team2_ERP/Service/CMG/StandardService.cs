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

        public bool InsertResource(ResourceVO item)
        {
            StandardDAC dac = new StandardDAC();
            return dac.InsertResource(item);
        }

        public bool UpdateResource(ResourceVO item)
        {
            StandardDAC dac = new StandardDAC();
            return dac.UpdateResource(item);
        }

        public bool DeleteResource(string code)
        {
            StandardDAC dac = new StandardDAC();
            return dac.DeleteResource(code);
        }

        public List<ComboItemVO> GetComboWarehouse()
        {
            StandardDAC dac = new StandardDAC();
            return dac.GetComboWarehouse();
        }

        public List<ComboItemVO> GetComboMeterial()
        {
            StandardDAC dac = new StandardDAC();
            return dac.GetComboMeterial();
        }
    }
}
