using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using QWF.Framework.ExtendUtils;

namespace QWF.Framework.Common
{

    internal class LogQueue
    {
        private static object o = new object();
        private static LogQueue logQueue = null;
        private Queue<LogInfo> queue = new Queue<LogInfo>();

        private LogQueue()
        {
            Thread read = new Thread(new ThreadStart(ReadQueue));
            read.IsBackground = true;
            read.Name = "read log queue thread";
            read.Start();
        }

        public static LogQueue GetInstance()
        {
            if (logQueue == null)
            {
                lock (o)
                {
                    logQueue = new LogQueue();
                }
            }
            return logQueue;
        }

        public void WriterQueue(LogTypeEnum logType, string directory, string message)
        {
            lock (queue)
            {

                queue.Enqueue(new LogInfo { Type = logType, Message = message,Directory = directory });
            }
        }

        private void ReadQueue()
        {
            for (; ; )
            {
                try
                {
                    lock (queue)
                    {
                        int queueCount = queue.Count;

                        if (queueCount > 0)
                        {
                            //写日志
                            Writer(queue.Dequeue());

                        }
                    }
                }
                catch (Exception e) 
                {
                    Console.Write(e.Message);
                }

                //每隔5秒扫描一次
                Thread.Sleep(1000 * 1);
            }

        }

        private void Writer(LogInfo info)
        {
            bool debug = ConfigHelper.GetParameterValue(GlobalConst.APP_Core_ConfigName, "Debug").SafeConvert().ToBool();

            if(info.Type == LogTypeEnum.Debug && !debug)
            {
                //不写日志
                return;
            }
            string path = ConfigHelper.GetParameterValue(GlobalConst.APP_Core_ConfigName, "LogPath");
            string directory = System.IO.Path.Combine(path, info.Directory);

            //目录
            if(!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }
            //文件路径
            path = System.IO.Path.Combine(path, info.Directory, info.Type.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd") + ".log");

            

            using(System.IO.StreamWriter sw = new System.IO.StreamWriter(path,true))
            {
                sw.WriteLine(DateTime.Now.ToString() + "\t[" + info.Type + "]"  + info.Message);
                sw.Close();
            }
        }

    }



}
