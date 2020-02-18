using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_ERP
{
    public static class Log
    {
        #region log4net용
        /// <summary>
        /// log4net 디버그정보 작성
        /// </summary>
        /// <param name="msg">디버그정보내용</param>
        public static void WriteDebug(string msg)
        {
            Program.Log.WriteDebug(msg);
        }
        /// <summary>
        /// log4net 디버그정보 작성
        /// </summary>
        /// <param name="msg">디버그정보 내용</param>
        /// <param name="err">예외 Exception</param>
        public static void WriteDebug(string msg, Exception err)
        {
            Program.Log.WriteDebug(msg, err);
        }
        /// <summary>
        /// log4net 에러정보 작성
        /// </summary>
        /// <param name="msg">에러정보 내용</param>
        public static void WriteError(string msg)
        {
            Program.Log.WriteError(msg);
        }
        /// <summary>
        /// log4net 에러정보 작성
        /// </summary>
        /// <param name="msg">에러정보 내용</param>
        /// <param name="err">예외 Exception</param>
        public static void WriteError(string msg, Exception err)
        {
            Program.Log.WriteError(msg, err);
        }
        /// <summary>
        /// log4net 치명적인 에러정보 작성
        /// </summary>
        /// <param name="msg">치명적인 에러정보 내용</param>
        public static void WriteFatal(string msg)
        {
            Program.Log.WriteFatal(msg);
        }
        /// <summary>
        /// log4net 치명적인 에러정보 작성
        /// </summary>
        /// <param name="msg">치명적인 에러정보 내용</param>
        /// <param name="err">예외 Exception</param>
        public static void WriteFatal(string msg, Exception err)
        {
            Program.Log.WriteFatal(msg, err);
        }
        /// <summary>
        /// log4net 실행정보 작성
        /// </summary>
        /// <param name="msg">실행정보 내용</param>
        public static void WriteInfo(string msg)
        {
            Program.Log.WriteInfo(msg);
        }
        /// <summary>
        /// log4net 실행정보 작성
        /// </summary>
        /// <param name="msg">실행 정보 내용</param>
        /// <param name="err">예외 Exception</param>
        public static void WriteInfo(string msg, Exception err)
        {
            Program.Log.WriteInfo(msg, err);
        }
        /// <summary>
        /// log4net 경고정보 작성
        /// </summary>
        /// <param name="msg">경고정보 내용</param>
        public static void WriteWarn(string msg)
        {
            Program.Log.WriteWarn(msg);
        }
        /// <summary>
        /// log4net 경고정보 작성
        /// </summary>
        /// <param name="msg">경고정보 내용</param>
        /// <param name="err">예외 Exception</param>
        public static void WriteWarn(string msg, Exception err)
        {
            Program.Log.WriteWarn(msg, err);
        }
        #endregion
    }
}
