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
    public class DefectiveService
    {
        public List<DefectiveVO> GetAllDefective()
        {
            DefectiveDAC dac = new DefectiveDAC();
            return dac.GetAllDefective();
        }

        public DataSet GetDefectiveByLine(string date)
        {
            DefectiveDAC dac = new DefectiveDAC();
            return dac.GetDefectiveByLine(date);
        }
        public DataSet GetDefectiveByDeftiveType(string date)
        {
            DefectiveDAC dac = new DefectiveDAC();
            return dac.GetDefectiveByDeftiveType(date);
        }

        public DataSet GetDefectiveByDeftiveHandleType(string date)
        {
            DefectiveDAC dac = new DefectiveDAC();
            return dac.GetDefectiveByDeftiveHandleType(date);
        }
    }
}
