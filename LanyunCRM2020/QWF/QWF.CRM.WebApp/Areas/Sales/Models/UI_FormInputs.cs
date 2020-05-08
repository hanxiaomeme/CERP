using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWF.CRM.WebApp.Areas.Sales.Models
{
    public class UI_FormInputs
    {
        
        /// <summary>
        /// Input项集合
        /// </summary>
        public List<UI_Input> Inputs { get; set; }
        /// <summary>
        /// 表单信息
        /// </summary>
        public UI_SalesMainForm Form { get; set; }
        /// <summary>
        /// 表单子项集合（数据字典）
        /// </summary>
        public List<DbAccess.T_QCRM_Dictionary> Dictionarys { get; set; }

    }
}