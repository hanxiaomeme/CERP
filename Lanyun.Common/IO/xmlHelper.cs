using System.Xml;

namespace Lanyun.Common
{
    public class XMLHelper
    {    
        public static XmlDocument GetXmlFile(string filepath)
        {
            XmlDocument xfile = new XmlDocument();
            xfile.Load(filepath);
            return xfile;
        }

        public static void SetInnerText(string filepath, string nodeName, string value)
        {
            XmlDocument xfile = GetXmlFile(filepath);
            xfile.SelectSingleNode(nodeName).InnerText = value;
            xfile.Save(filepath);
        }

        public static string GetInnerText(string filepath, string nodeName)
        {
            XmlDocument xfile = GetXmlFile(filepath);
            XmlNode node = xfile.SelectSingleNode(nodeName);
            return node.InnerText;
        }
    }
}
