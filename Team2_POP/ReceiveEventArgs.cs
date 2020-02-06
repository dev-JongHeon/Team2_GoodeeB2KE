using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_POP
{
    public class ReceiveEventArgs : EventArgs
    {       
        public int LineID { get; set; }
        public string Message { get; set; }
        public bool IsCompleted { get; set; }
        public string PerformanceID { get; set; }
        public int QtyImport { get; set; }
    }
}
