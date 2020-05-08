using System.Web;
using System.Web.Mvc;

namespace QWF.Framework.Sites
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //跨域设置
            filters.Add(new QWF.Framework.Web.Filter.AllowCrossAttribute());
            //权限过滤
            filters.Add(new QWF.Framework.Web.Filter.PermissionUrlAttribute());
            //异常过滤
            filters.Add(new QWF.Framework.Web.Filter.ExceptionAttribute());
        }
    }
}
