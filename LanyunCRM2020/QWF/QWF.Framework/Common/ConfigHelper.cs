using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace QWF.Framework.Common
{

    public sealed class ConfigHelper
    {

        /// <summary>
        /// 同步锁
        /// </summary>
        private static object _lockObj = new object();

        /// <summary>
        /// 取~/Config/Common.config中某个参数名对应的参数值
        /// </summary>
        /// <param name="ParameterName">参数名</param>
        /// <returns>参数值</returns>
        public static string GetParameterValue(string ParameterName)
        {
            return GetParameterValue("Common", ParameterName);
        }

        /// <summary>
        /// 取某个参数配置文件中某个参数名对应的参数值
        /// 参数配置文件
        ///		1、必须存放于"~/Config/"目录下面，以.config为后缀
        ///		2、配置格式参见~/Config/Common.config
        /// </summary>
        /// <param name="ConfigName">配置文件的文件名，不要后缀</param>
        /// <param name="ParameterName">参数名</param>
        /// <returns>参数值</returns>
        public static string GetParameterValue(string ConfigName, string ParameterName)
        {
            Hashtable CommonConfig = GetConfigCache(ConfigName);

            if (CommonConfig.ContainsKey(ParameterName))
                return CommonConfig[ParameterName].ToString();
            else
                throw new Exception("参数(" + ParameterName + ")没有定义，请检查配置文件！");
        }

        /// <summary>
        /// ~/Config/Common.config中某个参数名是否存在
        /// </summary>
        /// <param name="ParameterName">参数名</param>
        /// <returns></returns>
        public static bool ContainsParameter(string ParameterName)
        {
            return ContainsParameter("Common", ParameterName);
        }

        /// <summary>
        /// 某个参数配置文件中某个参数名是否存在
        /// </summary>
        /// <param name="ConfigName">配置文件的文件名，不要后缀</param>
        /// <param name="ParameterName">参数名</param>
        /// <returns></returns>
        public static bool ContainsParameter(string ConfigName, string ParameterName)
        {
            Hashtable CommonConfig = GetConfigCache(ConfigName);

            if (CommonConfig.ContainsKey(ParameterName))
                return true;

            return false;
        }

        /// <summary>
        /// 将配置的参数转换成Hashtable并存入缓存，配置文件修改后自动更新缓存
        /// </summary>
        /// <param name="ConfigName">配置文件的文件名，不要后缀</param>
        /// <returns>参数hash table</returns>
        public static Hashtable GetConfigCache(string ConfigName)
        {
            string CacheName = "Config_" + ConfigName;

            Hashtable CommonConfig = new Hashtable();

            if (HttpRuntime.Cache[CacheName] == null)
            {
                string ConfigFile = Path.Combine(GetAppRootPath(), "Config", ConfigName + ".config");

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigFile);

                XmlNode oNode = xmlDoc.DocumentElement;

                if (oNode.HasChildNodes)
                {
                    XmlNodeList oList = oNode.ChildNodes;

                    for (int i = 0; i < oList.Count; i++)
                    {
                        XmlNamedNodeMap oMap = oList[i].Attributes;

                        //避开注释行
                        if (oMap != null && oMap.GetNamedItem("Name") != null && !CommonConfig.Contains(oMap.GetNamedItem("Name").Value))
                            CommonConfig.Add(oMap.GetNamedItem("Name").Value, oMap.GetNamedItem("Value").Value);
                    }
                }

                lock (_lockObj)
                {
                    if (HttpRuntime.Cache[CacheName] == null)
                    {
                        HttpRuntime.Cache.Insert(CacheName, CommonConfig, new System.Web.Caching.CacheDependency(ConfigFile));
                    }
                }
            }
            else
                CommonConfig = (Hashtable)HttpRuntime.Cache[CacheName];

            return CommonConfig;
        }

        /// <summary>
        /// 获取 xml 对象
        /// </summary>
        /// <param name="ConfigName"></param>
        /// <returns></returns>
        public static XmlDocument GetConfigXml(string ConfigName)
        {
            string CacheName = "Config_XML_" + ConfigName;

            XmlDocument xml = null;

            if (HttpRuntime.Cache[CacheName] == null)
            {
                string ConfigFile = Path.Combine(GetAppRootPath(), "Config", ConfigName + ".config");

                xml = new XmlDocument();
                xml.Load(ConfigFile);

                lock (_lockObj)
                {
                    if (HttpRuntime.Cache[CacheName] == null)
                    {
                        HttpRuntime.Cache.Insert(CacheName, xml, new System.Web.Caching.CacheDependency(ConfigFile));
                    }
                }
            }
            else
                xml = (XmlDocument)HttpRuntime.Cache[CacheName];

            return xml;
        }

        /// <summary>
        /// 设置参数值
        /// </summary>
        /// <param name="ParameterName"></param>
        /// <param name="ParameterValue"></param>
        public static void SetParameterValue(string ParameterName, string ParameterValue)
        {
            SetParameterValue("Common", ParameterName, ParameterValue);
        }

        /// <summary>
        /// 设置参数值
        /// </summary>
        /// <param name="ConfigName"></param>
        /// <param name="ParameterName"></param>
        /// <param name="ParameterValue"></param>
        public static void SetParameterValue(string ConfigName, string ParameterName, string ParameterValue)
        {
            string ConfigFile = Path.Combine(GetAppRootPath(), "Config", ConfigName + ".config");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigFile);

            XmlElement xmlRoot = xmlDoc.DocumentElement;

            if (ContainsParameter(ConfigName, ParameterName))
            {
                XmlElement xmlNode = xmlRoot.SelectSingleNode(string.Format("Parameter[@Name='{0}']", ParameterName)) as XmlElement;
                if (xmlNode != null) xmlNode.SetAttribute("Value", ParameterValue);
            }
            else
            {
                XmlElement xmlNode = xmlDoc.CreateElement("Parameter");
                xmlNode.SetAttribute("Name", ParameterName);
                xmlNode.SetAttribute("Value", ParameterValue);
                xmlRoot.AppendChild(xmlNode);
            }

            xmlDoc.Save(ConfigFile);
        }

        /// <summary>
        /// 取应用程序根物理路径
        /// </summary>
        public static string GetAppRootPath()
        {
            string path;

            //先取Web应用程序的，若为空，则改取Windows应用程序的，若也为空，抛出异常
            try
            {
                path = HttpRuntime.AppDomainAppPath;
            }
            catch (System.ArgumentException)
            {
                path = Application.StartupPath;
            }

            if (string.IsNullOrEmpty(path)) throw new Exception("获取不到应用程序所在根物理路径！");

            return path;
        }
    }
}
