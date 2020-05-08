using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWF.CRM.WebApp.Areas.Sales.Models
{

    public class UI_SalesMain
    {
        /// <summary>
        /// 列表集合
        /// </summary>
        public List<DbAccess.T_QCRM_ListType> TableList { get; set; }
        /// <summary>
        /// 用户列表显示的字段配置
        /// </summary>
        public List<UI_UserField> UserFields { get; set; }
        /// <summary>
        /// CRD 的表单集合
        /// </summary>
        public List<UI_SalesMainForm> FormList { get; set; }
        /// <summary>
        /// 客户列表代码
        /// </summary>
        public string CustomerListCode { get; set; }
        /// <summary>
        /// 客户列表的表单集合
        /// </summary>
        public string[] CustomerFormList { get; set; }
        /// <summary>
        /// 与客户列表关联的tab的集合
        /// </summary>
        public string[] SublevelCode { get; set; }
        /// <summary>
        /// 表单集合
        /// </summary>
        public List<UI_Input> FormInputs { get; set; }
        /// <summary>
        /// 表单元素项集合(数据字典)
        /// </summary>
        public List<DbAccess.T_QCRM_Dictionary> Dictionarys { get; set; }

        /// <summary>
        /// 客户信息的tab分类集合
        /// </summary>
        public List<DbAccess.T_QCRM_Tabs> CustomerTabs { get; set; }

        public List<Models.UI_Product> Products { get; set; }
        public List<Models.UI_ProductItem> ProductItem { get; set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public List<QWF.Framework.Web.BaseItemKeyValue> SortFields { get; set; }

    }
}