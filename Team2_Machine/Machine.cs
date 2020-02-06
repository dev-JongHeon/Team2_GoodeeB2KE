using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Team2_Machine
{
    public partial class Machine : ServiceBase
    {
        ServerMachine serverM;        
        public Machine()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {            
            serverM = new ServerMachine();
        }

        public void Start()
        {
            OnStart(null);
        }

        protected override void OnStop()
        {
            serverM.ServerDown();
        }
        public void Pause()
        {
            OnStop();
        }
    }
}
