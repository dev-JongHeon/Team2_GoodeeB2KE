using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP.Service.CMG
{
    public class CodeTableService
    {
        public List<CodeTableVO> GetAllCodeTable()
        {
            CodeTableDAC dac = new CodeTableDAC();
            return dac.GetAllCodeTable();
        }

        public bool InsertCategory(CodeTableVO category)
        {
            CodeTableDAC dac = new CodeTableDAC();
            return dac.InsertCategory(category);
        }

        public bool InsertDepart(CodeTableVO dept)
        {
            CodeTableDAC dac = new CodeTableDAC();
            return dac.InsertDepart(dept);
        }

        public bool DeleteCodeTable(string code)
        {
            CodeTableDAC dac = new CodeTableDAC();
            return dac.DeleteCodeTable(code);
        }
    }
}
