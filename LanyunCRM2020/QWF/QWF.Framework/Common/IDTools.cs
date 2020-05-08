using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Common
{
    /// <summary>
    /// ID类
    /// </summary>
    public class IDTools
    {     /// <summary>
          /// 获取64位的GUID格式
          /// </summary>
          /// <returns></returns>
        public static long GetGuidLong()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }
        /// <summary>
        /// 获取GUID
        /// </summary>
        /// <returns></returns>
        public static string GetGUID()
        {
            return Guid.NewGuid().ToString();
        }

    }
}
