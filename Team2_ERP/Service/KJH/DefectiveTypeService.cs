using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP
{
    public class DefectiveTypeService
    {
        public List<DefectiveTypeVO> GetAllDefectiveTypes()
        {
            DefectiveTypeDAC dac = new DefectiveTypeDAC();
            return dac.GetAllDefectiveTypes();
        }

        public bool UpdateDefectiveType(DefectiveTypeVO item)
        {
            DefectiveTypeDAC dac = new DefectiveTypeDAC();
            return dac.UpdateDefectiveType(item);
        }

        public bool DeleteDefectiveType(string id)
        {
            DefectiveTypeDAC dac = new DefectiveTypeDAC();
            return dac.DeleteDefectiveType(id);
        }
    }
}
