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
using System.Threading;
using System.Threading.Tasks;

namespace Team2_Machine
{
    public partial class Machine : ServiceBase
    {
        ServerMachine serverM = null;
        public Machine()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {            
            serverM = new ServerMachine();
            new Thread(new ThreadStart(serverM.Start)).Start();
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
