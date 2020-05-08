using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QWF.CRM.WebApp.Areas.Sales.Models
{
    public class UI_SalesMainForm
    {
        /// <summary>
        /// 对应的列表
        /// </summary>
        public string ListType { get; set; }
        /// <summary>
        /// 自定义的表单代码
        /// </summary>
        public string Code { get; set; }
        public string Name { get; set; }
        public string ActionType { get; set; }
        public string ActionName { get; set; }
        public UI_SalesMainFormActionType ActionStyle { get; set; }
        public int StyleColums { get; set; }
        public int WindowsWidth { get; set; }
        public string ButtonStyle { get; set; }
        public string ButtonIcon { get; set; }
        /// <summary>
        /// 表单的组件名称
        /// </summary>
        public string PkName { get; set; }

        /// <summary>
        /// 按钮排序ID
        /// </summary>
        public int ButtonSortId { get; set; }

    }

    public enum UI_SalesMainFormActionType
    {
        /// <summary>
        /// 弹窗
        /// </summary>
        Dialog = 10,
        /// <summary>
        /// 对话框
        /// </summary>
        Confirm = 20
    }
}