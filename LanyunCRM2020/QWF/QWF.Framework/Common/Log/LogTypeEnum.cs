using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Common
{
    internal enum LogTypeEnum
    {
        /// <summary>
        /// 应用程序必要信息。
        /// </summary>
        Info = 10,
        /// <summary>
        /// 应用程序在测试阶段或DEBUG阶段生产的日志。
        /// </summary>
        Debug = 20,
        /// <summary>
        /// 警告信息，例如用户登陆失败信息
        /// </summary>
        Warning = 30,
        /// <summary>
        /// 发生严重错误的日志
        /// </summary>
        Error = 40,

    }
}
