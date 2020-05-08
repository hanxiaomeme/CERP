using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.ExtendUtils
{
    public static class ObjectExtend
    {
        public static ObjectConvert SafeConvert(this object data)
        {
            return new ObjectConvert(data);
        }
    }

    /// <summary>
    /// Object转换
    /// </summary>
    public class ObjectConvert
    {
        internal ObjectConvert(object data)
        {
            this.data = data;
        }

        private object data;

        /// <summary>
        /// 转化为字符串值
        /// </summary>
        public string ToStr(string defaultValue = "")
        {
            return SafeConvert.ToStr(this.data, defaultValue).Trim();
        }

        /// <summary>
        /// 转化为默认的时间格式yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <returns></returns>
        public string ToTimeStrDefault()
        {
            if (this.data == null)
                return string.Empty;

            return SafeConvert.ToDateTime(this.data).ToString("yyyy-MM-dd HH:mm:ss");
        }


        /// <summary>
        /// 转化为整型值
        /// </summary>
        public int ToInt32(int defaultValue = default(int))
        {
            return SafeConvert.ToInt32(this.data, defaultValue);
        }

        /// <summary>
        /// 转化为浮点值
        /// </summary>
        public decimal ToDecimal(decimal defaultValue = default(decimal))
        {
            return SafeConvert.ToDecimal(this.data, defaultValue);
        }

        /// <summary>
        /// 转化为日期时间值
        /// </summary>
        public DateTime ToDateTime(DateTime defaultValue = default(DateTime))
        {
            return SafeConvert.ToDateTime(this.data, defaultValue);
        }

        /// <summary>
        /// 转化为布尔值
        /// </summary>
        public bool ToBool(bool defaultValue = default(bool))
        {
            return SafeConvert.ToBool(this.data, defaultValue);
        }

        /// <summary>
        /// 转化为指定类型
        /// </summary>
        public T To<T>() where T : class
        {
            return SafeConvert.To<T>(this.data);
        }

        /// <summary>
        /// 转化为字典
        /// </summary>
        public Dictionary<string, object> ToAnonymousDict()
        {
            return SafeConvert.ToAnonymousDict(this.data);
        }


    }


}
