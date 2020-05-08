using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QWF.Framework.ExtendUtils
{
    public static class ValidatorExtend
    {
        /// <summary>
        /// 字符验证
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Validator StrValidatorHelper(this string data)
        {
            return new Validator(data);
        }

    }
    public  class Validator
    {
        private string data;
        internal Validator(string data)
        {
            this.data = data;
        }
        /// <summary>
        /// 字符串为NULL 或 string.Emp
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public  bool StrIsNullOrEmpty()
        {
            return string.IsNullOrEmpty(data);
        }
        /// <summary>
        /// 检测是否符合email格式
        /// </summary>
        /// <param name="input">要判断的email字符串</param>
        /// <returns>判断结果</returns>
        public  bool IsValidEmail()
        {
            return Regex.IsMatch(data, @"^[\w\.]+([-]\w+)*@[A-Za-z0-9-_]+[\.][A-Za-z0-9-_]");
        }

        /// <summary>
        /// 检测是否是正确的Url
        /// </summary>
        /// <param name="input">要验证的Url</param>
        /// <returns>判断结果</returns>
        public  bool IsURL()
        {
            return Regex.IsMatch(data, @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$");
        }

        /// <summary>
        /// 判断是否为base64字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public  bool IsBase64String()
        {
            //A-Z, a-z, 0-9, +, /, =
            return Regex.IsMatch(data, @"[A-Za-z0-9\+\/\=]");
        }
        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="input">要判断字符串</param>
        /// <returns>判断结果</returns>
        public  bool IsSafeSqlString()
        {
            return !Regex.IsMatch(data, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }
        /// <summary>
        /// 替换危险SQL字符 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public  string ReplaceUnSafeSql()
        {
            if (!string.IsNullOrEmpty(data) && data.IndexOf("'") > -1)
            {
                return data.Replace("'", "''");
            }
            return data;
        }

        /// <summary>
        /// 判断对象是否为Int32类型的数字
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public  bool IsNumeric()
        {
            if (data != null)
            {
                string str = data;
                if (str.Length > 0 && str.Length <= 11 && Regex.IsMatch(str, @"^[-]?[0-9]*[.]?[0-9]*$"))
                {
                    if ((str.Length < 10) || (str.Length == 10 && str[0] == '1') || (str.Length == 11 && str[0] == '-' && str[1] == '1'))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 是否为Double类型
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public  bool IsDouble()
        {
            if (data != null)
                return Regex.IsMatch(data.ToString(), @"^([0-9])[0-9]*(\.\w*)?$");

            return false;
        }
        /// <summary>
        /// 是否为IP格式
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public  bool IsIP()
        {
            return Regex.IsMatch(data, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 验证 26个字母、下画线、数字组成
        /// </summary>
        public bool IsLetterOrNumberCode()
        {
            return Regex.IsMatch(data, @"^[0-9a-zA-Z_]{1,}$");
        }

        /// <summary>
        /// 符合数据库、字段、表名规范的
        /// 1.长度3-128位
        /// 2.不能是数字开头
        /// 3.只能是数字、字母、下划线
        /// </summary>
        /// <returns></returns>
        public bool IsDbNameCode()
        {
            if (data.Length < 3 && data.Length > 128)
                return false;
            var c = data[0];

            if (data[0] >= 48 && data[0] <= 57)
                return false;

            return IsLetterOrNumberCode();
        }

    }
}
