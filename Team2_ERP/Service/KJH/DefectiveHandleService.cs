using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP
{
    public class DefectiveHandleService
    {
        public List<DefectiveHandleVO> GetAllDefectiveHandle()
        {
            DefectiveHandleDAC dac = new DefectiveHandleDAC();
            return dac.GetAllDefectiveHandle();
        }

        public bool UpdateDefectiveHandle(DefectiveHandleVO item)
        {
            DefectiveHandleDAC dac = new DefectiveHandleDAC();
            return dac.UpdateDefectiveHandle(item);
        }

        public bool DeleteDefectiveHandle(string id)
        {
            DefectiveHandleDAC dac = new DefectiveHandleDAC();
            return dac.DeleteDefectiveHandle(id);
        }
    }
}
