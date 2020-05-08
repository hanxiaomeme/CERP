using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Common
{
    /// <summary>
    /// 时间类工具
    /// </summary>
    public class DateTimeTools
    {
        /// <summary>
        /// JS 时间戳 转 DataTime 
        /// </summary>
        /// <param name="timespan"></param>
        /// <returns></returns>
        public static DateTime JsTimespanToDateTime(string timespan)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            if (timespan.Length == 13)
            {
                timespan += "0000";
            }
            else if (timespan.Length == 10)
            {
                timespan += "0000000";
            }

            long lTime = long.Parse(timespan);  //说明下，时间格式为13位后面补加4个"0"，如果时间格式为10位则后面补加7个"0",
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow); //得到转换后的时间

        }
        /// <summary>
        /// 日期转换成unix时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long DateTimeToUnixTimestamp(DateTime dateTime)
        {
            DateTime timeStamp = new DateTime(1970, 1, 1); //得到1970年的时间戳

            return (dateTime.ToUniversalTime().Ticks - timeStamp.Ticks) / 10000000; //注意这里有时区问题，用now就要减掉8个小时
        }
    }
}
