using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team2_ERP
{
    public partial class WarehouseInsUp : BasePopup
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public WarehouseInsUp()
        {
            InitializeComponent();
        }
    }
}
