using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class ComboItemVO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string CodeType { get; set; }

        public ComboItemVO()
        {

        }

        public ComboItemVO(string blankText)
        {
            Name = blankText;
        }

    }
}
