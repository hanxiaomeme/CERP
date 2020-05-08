using System.Web.Mvc;

namespace QWF.Framework.Sites.Areas.QWebFramework
{
    public class QWebFrameworkAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "QWebFramework";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "QWebFramework_default",
                "QWebFramework/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}