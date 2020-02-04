using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class FieldNameAttribute:Attribute
    {
        public string FieldName;
        public FieldNameAttribute(string fieldname)
        {
            this.FieldName = fieldname;
        }
    }
}
