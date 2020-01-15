using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class ComboItemVO
    {
        public int Code { get; set; }
        public string CodeNm { get; set; }
        public string CodeType { get; set; }

        public ComboItemVO()
        {

        }

        public ComboItemVO(string blankText)
        {
            CodeNm = blankText;
        }

    }
}
