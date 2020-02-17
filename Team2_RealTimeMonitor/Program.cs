using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team2_RealTimeMonitor
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RealTimeLineState());
        }

        private static LoggingUtility _logging = LoggingUtility.GetLoggingUtility("TEAM2_RealTimeMonitor", Level.Debug);

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
