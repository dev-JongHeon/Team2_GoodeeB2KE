using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP
{
    public class DowntimeService
    {
        public List<DowntimeVO> GetAllDowntime()
        {
            DowntimeDAC dac = new DowntimeDAC();
            return dac.GetAllDowntime();
        }

        public DataSet GetDowntimeByLine(string date)
        {
            DowntimeDAC dac = new DowntimeDAC();
            return dac.GetDowntimeByLine(date);
        }

        public DataSet GetDowntimeByType(string date)
        {
            DowntimeDAC dac = new DowntimeDAC();
            return dac.GetDowntimeByType(date);
        }
    }
}
