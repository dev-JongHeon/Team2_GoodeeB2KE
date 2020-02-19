using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP
{
    public class DowntimeTypeService
    {
        public List<DowntimeTypeVO> GetAllDowntimeType()
        {
            DowntimeTypeDAC dac = new DowntimeTypeDAC();
            return dac.GetAllDowntimeType();
        }

        public bool UpdateDowntimeType(DowntimeTypeVO item)
        {
            DowntimeTypeDAC dac = new DowntimeTypeDAC();
            return dac.UpdateDowntimeType(item);
        }

        public bool DeleteDowntimeType(string id)
        {
            DowntimeTypeDAC dac = new DowntimeTypeDAC();
            return dac.DeleteDowntimeType(id);
        }
    }
}
