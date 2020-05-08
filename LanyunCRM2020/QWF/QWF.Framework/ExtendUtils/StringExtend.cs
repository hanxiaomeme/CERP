using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QWF.Framework.ExtendUtils
{
    public static class StringExtend
    {
        public static StringUtils StringHelper(this string data)
        {
            return new StringUtils(data);
        }
    }

    /// <summary>
    /// 扩展方法的工具类
    /// </summary>
    public class StringUtils
    {
        internal StringUtils(string data)
        {
            this.data = data;
        }

        private string data;

        /// <summary>
        /// 返回指定分隔符之后的内容
        /// </summary>
        public string GetAfter(string speater)
        {
            return SafeConvert.GetAfter(this.data, speater);
        }

        /// <summary>
        /// 返回指定分隔符之前的内容
        /// </summary>
        public string GetBefore(string speater)
        {
            return SafeConvert.GetBefore(this.data, speater);
        }

        /// <summary>
        /// 返回最后一个分隔符之后的内容
        /// </summary>
        public string GetLastAfter(string speater)
        {
            return SafeConvert.GetLastAfter(this.data, speater);
        }

        /// <summary>
        /// 返回最后一个分隔符之前的内容
        /// </summary>
        public string GetLastBefore(string speater)
        {
            return SafeConvert.GetLastBefore(this.data, speater);
        }

        /// <summary>
        /// 增加前缀，若已经以指定前缀开始则不添加
        /// </summary>
        public string AppendPrefix(string prefix)
        {
            return SafeConvert.AppendPrefix(this.data, prefix);
        }

        /// <summary>
        /// 增加后缀，若已经以指定后缀结尾则不添加
        /// </summary>
        public string AppendSuffix(string suffix)
        {
            return SafeConvert.AppendSuffix(this.data, suffix);
        }

        /// <summary>
        /// 移除前缀，若前缀不存在则返回原字符串
        /// </summary>
        public string DeletePrefix(string prefix)
        {
            return SafeConvert.DeletePrefix(this.data, prefix);
        }

        /// <summary>
        /// 移除后缀，若后缀不存在则返回原字符串
        /// </summary>
        public string DeleteSuffix(string suffix)
        {
            return SafeConvert.DeleteSuffix(this.data, suffix);
        }

        /// <summary>
        /// SQL编码
        /// </summary>
        public string EncodeSql(bool isLike = false)
        {
            return SafeConvert.EncodeSql(this.data, isLike);
        }

        /// <summary>
        /// JSON编码
        /// </summary>
        public string EncodeJson()
        {
            return SafeConvert.EncodeJson(this.data);
        }

        /// <summary>
        /// XML编码
        /// </summary>
        public string EncodeXML()
        {
            return SafeConvert.EncodeXML(this.data);
        }

        /// <summary>
        /// XML解码
        /// </summary>
        public string DecodeXML()
        {
            return SafeConvert.DecodeXML(this.data);
        }

        /// <summary>
        /// URI编码
        /// </summary>
        public string EncodeUri(Encoding e)
        {
            return SafeConvert.EncodeUri(this.data, e);
        }

        /// <summary>
        /// URI编码
        /// </summary>
        public string EncodeUri()
        {
            return SafeConvert.EncodeUri(this.data, Encoding.Default);
        }

        /// <summary>
        /// URI解码
        /// </summary>
        public string DecodeUri(Encoding e)
        {
            return SafeConvert.DecodeUri(this.data, e);
        }

        /// <summary>
        /// URI解码
        /// </summary>
        public string DecodeUri()
        {
            return SafeConvert.DecodeUri(this.data, Encoding.Default);
        }

        /// <summary>
        /// 64位编码
        /// </summary>
        public string EncodeBase64String(System.Text.Encoding e)
        {
            return SafeConvert.EncodeBase64String(this.data, e);
        }

        /// <summary>
        /// 64位编码
        /// </summary>
        public string EncodeBase64String()
        {
            return SafeConvert.EncodeBase64String(this.data, Encoding.Default);
        }

        /// <summary>
        /// 64位解码
        /// </summary>
        public string DecodeBase64String(System.Text.Encoding e)
        {
            return SafeConvert.DecodeBase64String(this.data, e);
        }

        /// <summary>
        /// 64位解码
        /// </summary>
        public string DecodeBase64String()
        {
            return SafeConvert.DecodeBase64String(this.data, Encoding.Default);
        }

        /// <summary>
        /// MD5编码
        /// </summary>
        public string EncodeMD5(bool replace = true)
        {
            return SafeConvert.EncodeMD5(this.data, replace);
        }

        /// <summary>
        /// 字符串转化为字符串数组
        /// </summary>
        public string[] SplitToArray(string speater = ",", StringSplitOptions options = StringSplitOptions.None)
        {
            return SafeConvert.SplitToArray(this.data, speater, options);
        }

        /// <summary>
        /// 字符串转化为字符串集合
        /// </summary>
        public List<string> SplitToList(string speater = ",", StringSplitOptions options = StringSplitOptions.None)
        {
            return SafeConvert.SplitToList(this.data, speater, options);
        }

        /// <summary>
        /// 字符串转化为字典
        /// </summary>
        public Dictionary<string, string> SplitToDict(string speater1 = ";", string speater2 = ",")
        {
            return SafeConvert.SplitToDict(this.data, speater1, speater2);
        }

        public  bool IsIP()
        {
            return Regex.IsMatch(this.data, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

    }
}
