using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using QWF.Framework.ExtendUtils;

namespace QWF.Framework.Web.Filter
{
    public class AllowCrossAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var origin = filterContext.HttpContext.Request.Headers.Get("Origin");
            //获取跨域的列表
            var allowOrigins = Common.ConfigHelper.GetParameterValue(GlobalConst.APP_Core_ConfigName, "Origins").StringHelper().SplitToArray();

            if (allowOrigins.Contains(origin))
            {
                filterContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", origin);

            }

            filterContext.HttpContext.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type,Content-Length,Authorization,Accept,X-Requested-With,QWF-User-Token,QWF-AppID");
            filterContext.HttpContext.Response.AddHeader("Access-Control-Expose-Headers", "QWF-User-Token,QWF-AppID");
            filterContext.HttpContext.Response.AddHeader("Access-Control-Allow-Methods", "GET,POST,PUT,DELETE,OPTIONS");

           // base.OnAuthorization(filterContext);
        }

    }
}
