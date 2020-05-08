using System.Web.Mvc;

namespace QWF.CRM.WebApp.Areas.QCRMSetting
{
    public class QCRMSettingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "QCRMSetting";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "QCRMSetting_default",
                "QCRMSetting/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}