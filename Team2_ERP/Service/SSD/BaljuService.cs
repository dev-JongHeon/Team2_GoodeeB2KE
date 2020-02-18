using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP.Service
{
    public class BaljuService
    {
        public List<Balju> GetBaljuList()
        {
            BaljuDAC dac = new BaljuDAC();
            return dac.GetBaljuList();
        }

        public List<Balju> GetBalju_CompletedList()
        {
            BaljuDAC dac = new BaljuDAC();
            return dac.GetBalju_CompletedList();
        }

        public List<BaljuDetail> GetBalju_DetailList(string sb)
        {
            BaljuDAC dac = new BaljuDAC();
            return dac.GetBalju_DetailList(sb);
        }

        public bool UpdateBalju_Processed(List<string> baljuID, int employeeID)
        {
            BaljuDAC dac = new BaljuDAC();
            return dac.UpdateBalju_Processed(baljuID, employeeID);
        }

        public bool DeleteBalju(List<string> balju_ID)
        {
            BaljuDAC dac = new BaljuDAC();
            return dac.DeleteBalju(balju_ID);
        }
    }
}
