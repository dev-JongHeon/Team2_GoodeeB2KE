﻿using System;
using System.Collections.Generic;
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

        public List<BaljuDetail> GetBalju_DetailList()
        {
            BaljuDAC dac = new BaljuDAC();
            return dac.GetBalju_DetailList();
        }
    }
}
