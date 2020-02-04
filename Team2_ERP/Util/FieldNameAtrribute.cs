using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_ERP.Util
{
    public class FieldNameAtrribute:Attribute
    {
        public string FieldName;
        public FieldNameAtrribute(string fieldname)
        {
            this.FieldName = fieldname;
        }

    }
}
