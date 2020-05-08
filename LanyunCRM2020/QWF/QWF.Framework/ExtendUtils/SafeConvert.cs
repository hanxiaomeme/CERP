using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QWF.Framework.ExtendUtils
{    /// <summary>
    /// 安全转化工具类
    /// </summary>
    public static class SafeConvert
    {
        /// <summary>
        /// 对象转化为字符串值
        /// </summary>
        public static string ToStr(object data, string defaultValue = "")
        {
            string result = string.Empty;

            if (data != null)
            {
                result = data.ToString();
            }

            result = !string.IsNullOrWhiteSpace(result) ? result : defaultValue;

            return result;
        }

        /// <summary>
        /// 对象转化为整型值
        /// </summary>
        public static int ToInt32(object data, int defaultValue = default(int))
        {
            int result = defaultValue;

            if (data != null)
            {
                if (!int.TryParse(data.ToString(), out result))
                {
                    result = defaultValue;
                }
            }

            return result;
        }

        /// <summary>
        /// 对象转化为浮点值
        /// </summary>
        public static decimal ToDecimal(object data, decimal defaultValue = default(decimal))
        {
            decimal result = defaultValue;

            if (data != null)
            {
                if (!decimal.TryParse(data.ToString(), out result))
                {
                    result = defaultValue;
                }
            }

            return result;
        }

        /// <summary>
        /// 对象转化为日期时间值
        /// </summary>
        public static DateTime ToDateTime(object data, DateTime defaultValue = default(DateTime))
        {
            DateTime result = defaultValue;

            if (data != null)
            {
                if (!DateTime.TryParse(data.ToString(), out result))
                {
                    result = defaultValue;
                }
            }

            return result;
        }

        /// <summary>
        /// 对象转化为布尔值
        /// </summary>
        public static bool ToBool(object data, bool defaultValue = default(bool))
        {
            bool result = defaultValue;

            if (data != null)
            {
                if (data.ToString() == "1"
                    || data.ToString().ToLower() == "true"
                    || data.ToString().ToLower() == "on"
                    || data.ToString().ToLower() == "checked")
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// 对象转化为字典
        /// </summary>
        public static Dictionary<string, object> ToAnonymousDict(object data)
        {
            Dictionary<string, object> dict = null;

            if (data != null)
            {
                dict = new Dictionary<string, object>();

                System.ComponentModel.PropertyDescriptorCollection pds = System.ComponentModel.TypeDescriptor.GetProperties(data);

                foreach (System.ComponentModel.PropertyDescriptor pd in pds)
                {
                    dict.Add(pd.Name, pd.GetValue(data));
                }
            }

            return dict;
        }

        /// <summary>
        /// 对象转化为指定类型
        /// </summary>
        public static T To<T>(object data) where T : class
        {
            T result = default(T);

            if (data != null)
            {
                try
                {
                    result = (T)data;
                }
                catch
                { }
            }

            return result;
        }


        /// <summary>
        /// 返回指定分隔符之后的内容
        /// </summary>
        public static string GetAfter(string data, string speater = ",")
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return data;
            }

            string str = data;

            int pos = str.IndexOf(speater);
            if (pos >= 0)
            {
                str = str.Substring(pos + speater.Length);
            }

            return str;
        }

        /// <summary>
        /// 返回指定分隔符之前的内容
        /// </summary>
        public static string GetBefore(string data, string speater = ",")
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return data;
            }

            string str = data;

            int pos = str.IndexOf(speater);
            if (pos >= 0)
            {
                str = str.Substring(0, pos);
            }

            return str;
        }

        /// <summary>
        /// 返回最后一个分隔符之后的内容
        /// </summary>
        public static string GetLastAfter(string data, string speater = ",")
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return data;
            }

            string str = data;

            int pos = str.LastIndexOf(speater);
            if (pos >= 0)
            {
                str = str.Substring(pos + speater.Length);
            }

            return str;
        }

        /// <summary>
        /// 返回最后一个分隔符之前的内容
        /// </summary>
        public static string GetLastBefore(string data, string speater = ",")
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return data;
            }

            string str = data;

            int pos = str.LastIndexOf(speater);
            if (pos >= 0)
            {
                str = str.Substring(0, pos);
            }

            return str;
        }

        /// <summary>
        /// 增加前缀，若已经以指定前缀开始则不添加
        /// </summary>
        public static string AppendPrefix(string data, string prefix)
        {
            if (data == null)
            {
                return data;
            }

            string s = data;

            if (!s.StartsWith(prefix))
            {
                s = prefix + s;
            }

            return s;
        }

        /// <summary>
        /// 增加后缀，若已经以指定后缀结尾则不添加
        /// </summary>
        public static string AppendSuffix(string data, string suffix)
        {
            if (data == null)
            {
                return data;
            }

            string s = data;

            if (!s.EndsWith(suffix))
            {
                s = s + suffix;
            }

            return s;
        }

        /// <summary>
        /// 移除前缀，若前缀不存在则返回原字符串
        /// </summary>
        public static string DeletePrefix(string data, string prefix)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return data;
            }

            string s = data;

            if (s.StartsWith(prefix))
            {
                s = s.Remove(0, prefix.Length);
            }

            return s;
        }

        /// <summary>
        /// 移除后缀，若后缀不存在则返回原字符串
        /// </summary>
        public static string DeleteSuffix(string data, string suffix)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return data;
            }

            string s = data;

            if (s.EndsWith(suffix))
            {
                s = s.Remove(s.Length - suffix.Length, suffix.Length);
            }

            return s;
        }


        /// <summary>
        /// SQL编码
        /// </summary>
        public static string EncodeSql(string data, bool isLike = false)
        {
            if (isLike)
            {
                return "'%" + data.Replace("'", "''") + "%'";
            }
            else
            {
                return "'" + data.Replace("'", "''") + "'";
            }
        }

        /// <summary>
        /// JSON编码
        /// </summary>
        public static string EncodeJson(string data)
        {
            data = data.Replace("\"", "\\\"");
            data = data.Replace("\'", "\\\'");

            return "\"" + data + "\"";
        }

        /// <summary>
        /// XML编码
        /// </summary>
        public static string EncodeXML(string data)
        {
            data = data.Replace("&", "&amp;");
            data = data.Replace("<", "&lt;");
            data = data.Replace(">", "&gt;");
            data = data.Replace("\"", "&quot;");
            data = data.Replace("\'", "&apos;");

            return data;
        }

        /// <summary>
        /// URI编码
        /// </summary>
        public static string EncodeUri(string data, Encoding e)
        {
            data = HttpUtility.UrlEncode(data, e);
            data = data.Replace(".", "%2E");
            data = data.Replace("#", "%23");
            data = data.Replace("&", "%26");
            data = data.Replace("=", "%3D");
            data = data.Replace("/", "%2F");
            data = data.Replace("+", "%2B");
            data = data.Replace("?", "%3F");
            return data;
        }

        /// <summary>
        /// URI编码
        /// </summary>
        public static string EncodeUri(string data)
        {
            return EncodeUri(data, Encoding.Default);
        }

        /// <summary>
        /// 64位编码
        /// </summary>
        public static string EncodeBase64String(string data, System.Text.Encoding e)
        {
            string result = data;

            if (!string.IsNullOrWhiteSpace(data))
            {
                result = Convert.ToBase64String(e.GetBytes(data));
            }

            return result;
        }

        /// <summary>
        /// 64位编码
        /// </summary>
        public static string EncodeBase64String(string data)
        {
            return EncodeBase64String(data, Encoding.Default);
        }

        /// <summary>
        /// MD5编码
        /// </summary>
        public static string EncodeMD5(string data, bool replace = true)
        {
            string result = data;

            if (!string.IsNullOrWhiteSpace(data))
            {
                //获取加密服务  
                System.Security.Cryptography.MD5CryptoServiceProvider md5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();

                //获取要加密的字段，并转化为Byte[]数组  
                byte[] oEncrypt = System.Text.Encoding.UTF8.GetBytes(result);

                //加密Byte[]数组  
                byte[] rEncrypt = md5CSP.ComputeHash(oEncrypt);

                //将加密后的数组转化为字段(普通加密)  
                result = BitConverter.ToString(rEncrypt);

                if (replace)
                {
                    result = result.Replace("-", "").ToLower();
                }
            }

            return result;
        }

        /// <summary>
        /// XML解码
        /// </summary>
        public static string DecodeXML(string data)
        {
            data = data.Replace("&amp;", "&");
            data = data.Replace("&lt;", "<");
            data = data.Replace("&gt;", ">");
            data = data.Replace("&quot;", "\"");
            data = data.Replace("&apos;", "\'");

            return data;
        }

        /// <summary>
        /// URI解码
        /// </summary>
        public static string DecodeUri(string data, Encoding e)
        {
            return HttpUtility.UrlDecode(data, e);
        }

        /// <summary>
        /// URI解码
        /// </summary>
        public static string DecodeUri(string data)
        {
            return DecodeUri(data, Encoding.Default);
        }

        /// <summary>
        /// 64位解码
        /// </summary>
        public static string DecodeBase64String(string data, System.Text.Encoding e)
        {
            string result = data;

            if (!string.IsNullOrWhiteSpace(data))
            {
                byte[] buffer = Convert.FromBase64String(data);
                result = e.GetString(buffer);
            }

            return result;
        }

        /// <summary>
        /// 64位解码
        /// </summary>
        public static string DecodeBase64String(string data)
        {
            return DecodeBase64String(data, Encoding.Default);
        }


        /// <summary>
        /// 字符串数组转化为字符串
        /// </summary>
        public static string Join(string[] data, string speater = ",")
        {
            string[] array = data;

            if (array == null || array.Length <= 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                sb.Append(ToStr(array[i]));

                if (i < array.Length - 1)
                {
                    sb.Append(speater);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 字符串集合转换为字符串
        /// </summary>
        public static string Join(List<string> data, string speater = ",")
        {
            List<string> list = data;

            if (list == null || list.Count <= 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < list.Count; i++)
            {
                sb.Append(ToStr(list[i]));

                if (i < list.Count - 1)
                {
                    sb.Append(speater);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 字典转化为字符串
        /// </summary>
        public static string Join(Dictionary<string, string> data, string speater1 = ";", string speater2 = ",")
        {
            StringBuilder sb = new StringBuilder();

            foreach (string key in data.Keys)
            {
                sb.Append(key + speater2 + ToStr(data[key]) + speater1);
            }

            return DeleteSuffix(sb.ToString(), speater1);
        }


        /// <summary>
        /// 字符串转化为字符串数组
        /// </summary>
        public static string[] SplitToArray(string data, string speater = ",", StringSplitOptions options = StringSplitOptions.None)
        {
            string str = data;

            if (str == null)
            {
                return null;
            }

            return str.Split(new string[] { speater }, options);
        }

        /// <summary>
        /// 字符串转化为字符串集合
        /// </summary>
        public static List<string> SplitToList(string data, string speater = ",", StringSplitOptions options = StringSplitOptions.None)
        {
            string str = data;

            if (str == null)
            {
                return null;
            }

            var list = new List<string>();

            var array = str.Split(new string[] { speater }, options);

            foreach (var s in array)
            {
                list.Add(s);
            }

            return list;
        }

        /// <summary>
        /// 字符串转化为字典
        /// </summary>
        public static Dictionary<string, string> SplitToDict(string data, string speater1 = ";", string speater2 = ",")
        {
            if (data == null)
            {
                return null;
            }

            Dictionary<string, string> dict = new Dictionary<string, string>();

            string[] strs1 = data.Split(new string[] { speater1 }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in strs1)
            {
                string[] strs2 = s.Split(new string[] { speater2 }, StringSplitOptions.None);

                if (!dict.ContainsKey(strs2[0]))
                {
                    if (strs2.Length > 1)
                    {
                        dict.Add(strs2[0].Trim(), strs2[1].Trim());
                    }
                    else
                    {
                        dict.Add(strs2[0].Trim(), string.Empty);
                    }
                }
            }

            return dict;
        }



        /// <summary>
        /// 将对象序列化为XML格式的字符串
        /// </summary>
        public static string SerializeToXml(object obj)
        {
            string xml = string.Empty;

            if (obj != null)
            {
                StringBuilder sb = new StringBuilder();

                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(obj.GetType());

                using (System.IO.StringWriter sw = new System.IO.StringWriter(sb))
                {
                    xs.Serialize(sw, obj);
                }
                xml = sb.ToString();
            }

            return xml;
        }

        /// <summary>
        /// 将XML格式的字符串反序列化为对象实例
        /// </summary>
        public static T DeserializeFromXml<T>(string xml)
        {
            object obj = null;

            if (!string.IsNullOrEmpty(xml))
            {
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));

                using (System.IO.StringReader sr = new System.IO.StringReader(xml))
                {
                    obj = xs.Deserialize(sr);
                }
            }
            return (T)obj;
        }

        /// <summary>
        /// 将对象序列化为二进制数组
        /// </summary>
        public static byte[] SerializeToByte(object obj)
        {
            byte[] buffer = null;

            if (obj != null)
            {
                System.Runtime.Serialization.IFormatter fmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    fmt.Serialize(ms, obj);
                    buffer = ms.ToArray();
                }
            }

            return buffer;
        }

        /// <summary>
        /// 将二进制数组反序列化为对象实例
        /// </summary>
        public static object DeserializeFromByte(byte[] buffer)
        {
            object obj = null;

            if (buffer != null)
            {
                System.Runtime.Serialization.IFormatter fmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer))
                {
                    obj = fmt.Deserialize(ms);
                }
            }

            return obj;
        }

        /// <summary>
        /// 将二进制数组反序列化为对象实例
        /// </summary>
        public static T DeserializeFromByte<T>(byte[] buffer)
        {
            object obj = DeserializeFromByte(buffer);

            if (obj == null)
            {
                return default(T);
            }
            else
            {
                return (T)obj;
            }
        }

        /// <summary>
        /// 将对象序列化为base64String
        /// </summary>
        public static string SerializeToBase64String(object obj)
        {
            string base64String = string.Empty;

            if (obj != null)
            {
                byte[] buffer = SerializeToByte(obj);
                base64String = Convert.ToBase64String(buffer);
            }

            return base64String;
        }

        /// <summary>
        /// 将base64String反序列化为对象实例
        /// </summary>
        public static T DeserializeFromBase64String<T>(string base64String)
        {
            T obj = default(T);

            if (!string.IsNullOrEmpty(base64String))
            {
                byte[] buffer = Convert.FromBase64String(base64String);
                obj = DeserializeFromByte<T>(buffer);
            }

            return obj;
        }

        /// <summary>
        /// 获取XML对象的属性值
        /// 属性未定义则返回默认值
        /// </summary>
        public static string GetXmlAttributeValue(System.Xml.Linq.XElement xe, string attrName, string defaultValue = "")
        {
            string attrValue = defaultValue;

            var xattr = xe.Attribute(attrName);
            if (xattr != null && xattr.Value != null)
            {
                attrValue = xattr.Value;
            }

            return attrValue;
        }

        /// <summary> 
        /// 浮点转化为字符串(人民币大写形式)
        /// </summary> 
        public static string ToRMB(decimal data)
        {
            decimal num = data;

            string str1 = "零壹贰叁肆伍陆柒捌玖";            //0-9所对应的汉字 
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字 
            string str3 = "";    //从原num值中取出的值 
            string str4 = "";    //数字的字符串形式 
            string str5 = "";  //人民币大写金额形式 
            int i;    //循环变量 
            int j;    //num的值乘以100的字符串长度 
            string ch1 = "";    //数字的汉语读法 
            string ch2 = "";    //数字位的汉字读法 
            int nzero = 0;  //用来计算连续的零值是几个 
            int temp;            //从原num值中取出的值 

            num = Math.Round(Math.Abs(num), 2);    //将num取绝对值并四舍五入取2位小数 
            str4 = ((long)(num * 100)).ToString();        //将num乘100并转换成字符串形式 
            j = str4.Length;      //找出最高位 
            if (j > 15) { return "溢出"; }
            str2 = str2.Substring(15 - j);   //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分 

            //循环取出每一位需要转换的值 
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);          //取出需转换的某一位的值 
                temp = Convert.ToInt32(str3);      //转换为数字 
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时 
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位 
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上 
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整” 
                    str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }

        /// <summary>
        /// 转全角
        /// </summary>
        public static string ToSBC(string data)
        {
            string input = data;

            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary> 
        /// 转半角
        /// </summary>
        public static string ToDBC(string data)
        {
            string input = data;

            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }


        #region 农历参数

        //天干 
        private static string[] LunarCalendarTianGan = { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };
        //地支 
        private static string[] LunarCalendarDiZhi = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };
        //十二生肖 
        private static string[] LunarCalendarShengXiao = { "鼠", "牛", "虎", "兔", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };
        //农历日期 
        private static string[] LunarCalendarDayName = {"*","初一","初二","初三","初四","初五","初六","初七","初八","初九","初十", 
                                           "十一","十二","十三","十四","十五","十六","十七","十八","十九","二十", 
                                           "廿一","廿二","廿三","廿四","廿五","廿六","廿七","廿八","廿九","三十"};
        //农历月份 
        private static string[] LunarCalendarMonthName = { "*", "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "腊" };
        //公历月计数天 
        private static int[] LunarCalendarMonthAdd = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
        //农历数据 
        private static int[] LunarCalendarData = {2635,333387,1701,1748,267701,694,2391,133423,1175,396438 
                                        ,3402,3749,331177,1453,694,201326,2350,465197,3221,3402 
                                        ,400202,2901,1386,267611,605,2349,137515,2709,464533,1738 
                                        ,2901,330421,1242,2651,199255,1323,529706,3733,1706,398762 
                                        ,2741,1206,267438,2647,1318,204070,3477,461653,1386,2413 
                                        ,330077,1197,2637,268877,3365,531109,2900,2922,398042,2395 
                                        ,1179,267415,2635,661067,1701,1748,398772,2742,2391,330031 
                                        ,1175,1611,200010,3749,527717,1452,2742,332397,2350,3222 
                                        ,268949,3402,3493,133973,1386,464219,605,2349,334123,2709 
                                        ,2890,267946,2773,592565,1210,2651,395863,1323,2707,265877};

        #endregion

        /// <summary>
        ///  获取对应日期的农历,包括天干地支生肖 
        /// </summary>
        public static string GetLunarCalendarWithSX(DateTime data)
        {
            string sYear = data.Year.ToString();
            string sMonth = data.Month.ToString();
            string sDay = data.Day.ToString();

            int year = data.Year;
            int month = data.Month;
            int day = data.Day;

            int nTheDate;
            int nIsEnd;
            int k, m, n, nBit, i;

            string calendar = string.Empty;
            string sx = string.Empty;
            string td = string.Empty;

            //计算到初始时间1921年2月8日的天数：1921-2-8(正月初一) 
            nTheDate = (year - 1921) * 365 + (year - 1921) / 4 + day + LunarCalendarMonthAdd[month - 1] - 38;
            if ((year % 4 == 0) && (month > 2))
            {
                nTheDate += 1;
            }

            //计算天干，地支，月，日 
            nIsEnd = 0;
            m = 0;
            k = 0;
            n = 0;
            while (nIsEnd != 1)
            {
                if (LunarCalendarData[m] < 4095)
                    k = 11;
                else
                    k = 12;
                n = k;

                while (n >= 0)
                {
                    //获取LunarData[m]的第n个二进制位的值 
                    nBit = LunarCalendarData[m];
                    for (i = 1; i < n + 1; i++)
                        nBit = nBit / 2;
                    nBit = nBit % 2;
                    if (nTheDate <= (29 + nBit))
                    {
                        nIsEnd = 1;
                        break;
                    }
                    nTheDate = nTheDate - 29 - nBit;
                    n = n - 1;
                }

                if (nIsEnd == 1)
                    break;
                m = m + 1;
            }

            year = 1921 + m;
            month = k - n + 1;
            day = nTheDate;
            // return year + "-" + month + "-" + day;

            // #region 格式化日期显示为三月廿四 

            if (k == 12)
            {
                if (month == LunarCalendarData[m] / 65536 + 1)
                    month = 1 - month;
                else if (month > LunarCalendarData[m] / 65536 + 1)
                    month = month - 1;
            }
            //生肖 
            sx = LunarCalendarShengXiao[(year - 4) % 60 % 12].ToString() + "年 ";

            // //天干地支
            td = LunarCalendarTianGan[(year - 4) % 60 % 10].ToString() + LunarCalendarDiZhi[(year - 4) % 60 % 12].ToString();

            //农历月 
            if (month < 1)
                calendar += "闰" + LunarCalendarMonthName[-1 * month].ToString() + "月";
            else
                calendar += LunarCalendarMonthName[month].ToString() + "月";
            //农历日 
            calendar += LunarCalendarDayName[day].ToString() + "日";

            return string.Format("{0} - {1} - {2}", calendar, td, sx);

            // #endregion 

        }

        /// <summary> 
        /// 获取对应日期的农历
        /// </summary> 
        public static string GetLunarCalendar(DateTime data)
        {
            string sYear = data.Year.ToString();
            string sMonth = data.Month.ToString();
            string sDay = data.Day.ToString();

            int year = data.Year;
            int month = data.Month;
            int day = data.Day;

            int nTheDate;
            int nIsEnd;
            int k, m, n, nBit, i;
            string calendar = string.Empty;

            //计算到初始时间1921年2月8日的天数：1921-2-8(正月初一) 
            nTheDate = (year - 1921) * 365 + (year - 1921) / 4 + day + LunarCalendarMonthAdd[month - 1] - 38;
            if ((year % 4 == 0) && (month > 2))
            {
                nTheDate += 1;
            }

            //计算天干，地支，月，日 
            nIsEnd = 0;
            m = 0;
            k = 0;
            n = 0;
            while (nIsEnd != 1)
            {
                if (LunarCalendarData[m] < 4095)
                    k = 11;
                else
                    k = 12;
                n = k;

                while (n >= 0)
                {
                    //获取LunarData[m]的第n个二进制位的值 
                    nBit = LunarCalendarData[m];
                    for (i = 1; i < n + 1; i++)
                        nBit = nBit / 2;
                    nBit = nBit % 2;
                    if (nTheDate <= (29 + nBit))
                    {
                        nIsEnd = 1;
                        break;
                    }
                    nTheDate = nTheDate - 29 - nBit;
                    n = n - 1;
                }

                if (nIsEnd == 1)
                    break;
                m = m + 1;
            }

            year = 1921 + m;
            month = k - n + 1;
            day = nTheDate;

            if (k == 12)
            {
                if (month == LunarCalendarData[m] / 65536 + 1)
                    month = 1 - month;
                else if (month > LunarCalendarData[m] / 65536 + 1)
                    month = month - 1;
            }
            //农历月 
            if (month < 1)
                calendar += "闰" + LunarCalendarMonthName[-1 * month].ToString() + "月";
            else
                calendar += LunarCalendarMonthName[month].ToString() + "月";
            //农历日 
            calendar += LunarCalendarDayName[day].ToString() + "日";
            return calendar;
        }

    }
}
