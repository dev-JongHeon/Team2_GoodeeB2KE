using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Team2_Machine
{
    static class Program
    {
        /// 0225 최종커밋
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Machine()
            };
            ServiceBase.Run(ServicesToRun);
        }

        private static LoggingUtility _logging = LoggingUtility.GetLoggingUtility("TEAM2_Server", Level.Debug);

        internal static LoggingUtility Log { get { return _logging; } }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception err = (Exception)e.ExceptionObject;
            Log.WriteError(err.Message, err);
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Log.WriteError(e.Exception.Message, e.Exception);
        }
    }
}
