using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;

namespace QWF.Framework.Web.Filter
{
    public class AccessInfo
    {
        /// <summary>
        /// 过滤器上下文
        /// </summary>
        private ControllerContext filterContext;

        /// <summary>
        /// 用户主机IP
        /// </summary>
        public string UserHostAddress
        {
            get { return filterContext.RequestContext.HttpContext.Request.UserHostAddress; }
        }

        /// <summary>
        /// 用户主机名
        /// </summary>
        public string UserHostName
        {
            get { return filterContext.RequestContext.HttpContext.Request.UserHostName; }
        }

        /// <summary>
        /// 区域名称
        /// </summary>
        public string Area
        {
            get { return filterContext.RouteData.DataTokens["area"].SafeConvert().ToStr(); }
        }

        /// <summary>
        /// 控制器名称
        /// </summary>
        public string Controller
        {
            get { return filterContext.RouteData.Values["controller"].SafeConvert().ToStr(); }
        }

        /// <summary>
        /// 动作名称
        /// </summary>
        public string Action
        {
            get { return filterContext.RouteData.Values["action"].SafeConvert().ToStr(); }
        }

        /// <summary>
        /// 动作方法
        /// </summary>
        public string HttpMethod
        {
            get { return filterContext.RequestContext.HttpContext.Request.HttpMethod; }
        }

        /// <summary>
        /// 是否Ajax请求
        /// </summary>
        public bool IsAjaxRequest
        {
            get
            {
                return this.filterContext.RequestContext.HttpContext.Request.IsAjaxRequest();
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public AccessInfo(ControllerContext filterContext)
        {
            this.filterContext = filterContext;
        }
    }
}
