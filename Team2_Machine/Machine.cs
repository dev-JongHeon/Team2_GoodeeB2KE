using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Team2_Machine
{
    public partial class Machine : ServiceBase
    {
        public Machine()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }
        public void Start()
        {
            OnStart(null);
        }

        protected override void OnStop()
        {
        }
        public void Pause()
        {
            OnStop();
        }
    }
}
