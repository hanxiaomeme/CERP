using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWF.CRM.Utils
{
    /// <summary>
    /// CRM 配置文件类
    /// </summary>
    public class ConfigUtils
    {
        public static ConfigUtils Instance
        {
            get { return QWF.Framework.Common.Singleton<ConfigUtils>.Instance; }
        }
        
        public  List<QWF.Framework.Web.BaseItemKeyValue> GetCustomerTabs()
        {
            var tabConfig = QWF.Framework.Common.ConfigHelper.GetConfigXml("qwf.crm").SelectNodes("/ConfigPool/CustomerTab/Item");
            var tabs = new List<QWF.Framework.Web.BaseItemKeyValue>();

            foreach (var tab in tabConfig)
            {
                var xe = (System.Xml.XmlElement)tab;
                tabs.Add(new Framework.Web.BaseItemKeyValue { Key = xe.GetAttribute("Code"), Value = xe.GetAttribute("Name") });
            }

            return tabs;
        }

        public List<Models.ProductServerTimeField> GetServerTimeList()
        {
            var list = new List<Models.ProductServerTimeField>();
            list.Add(new Models.ProductServerTimeField { VirtualFieldCode = "TB_Customer_ProductBeginTime", FieldName = "业务开始时间", FileCode = "BeginTime" });
            list.Add(new Models.ProductServerTimeField { VirtualFieldCode = "TB_Customer_ProductEndTime", FieldName = "业务结束时间", FileCode = "EndTime" });

            return list;
        }

    }
}
