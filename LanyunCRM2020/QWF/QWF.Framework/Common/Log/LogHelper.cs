using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QWF.Framework.Common
{
    public class LogHelper
    {

        /// <summary>
        /// 写入消息
        /// </summary>
        /// <param name="message">消息</param>
        public static void Info(string message)
        {
            Info(string.Empty, message);
        }

        public static void Info(string directory, string message)
        {
            LogQueue.GetInstance().WriterQueue(LogTypeEnum.Info, directory, message);
        }

        public static void Debug(string message)
        {
            LogQueue.GetInstance().WriterQueue(LogTypeEnum.Debug, string.Empty, message);
        }
        public static void Debug(string directory, string message)
        {
            LogQueue.GetInstance().WriterQueue(LogTypeEnum.Debug, directory, message);
        }

        public static void Debug(string message, Exception ex)
        {
            LogQueue.GetInstance().WriterQueue(LogTypeEnum.Debug, string.Empty, ConvertToString(ex));
        }
        public static void Debug(string directory, string message, Exception ex)
        {
            LogQueue.GetInstance().WriterQueue(LogTypeEnum.Debug, directory, ConvertToString(ex, message));
        }

        public static void Error(string message)
        {
            LogQueue.GetInstance().WriterQueue(LogTypeEnum.Error, string.Empty, message);
        }
        public static void Error(string directory, string message)
        {
            LogQueue.GetInstance().WriterQueue(LogTypeEnum.Error, directory, message);
        }
        public static void Error(Exception ex)
        {
            LogQueue.GetInstance().WriterQueue(LogTypeEnum.Error, string.Empty, ConvertToString(ex));
        }
        public static void Error(string directory,string message, Exception ex)
        {
            LogQueue.GetInstance().WriterQueue(LogTypeEnum.Error, string.Empty, ConvertToString(ex));

        }

        public static void Warning(string message)
        {
            LogQueue.GetInstance().WriterQueue(LogTypeEnum.Warning, string.Empty, message);
        }
        public static void Warning(string directory, string message)
        {
            LogQueue.GetInstance().WriterQueue(LogTypeEnum.Warning, directory, message);
        }


        private static string ConvertToString(Exception ex, string message = null)
        {
            if (message == null)
            {
                return ex.Message + "\r\n" + ex.StackTrace;
            }
            else
            {
                return "【" + message + "】错误信息：" + ex.Message + "\r\n" + ex.StackTrace;
            }


        }

    }


}
