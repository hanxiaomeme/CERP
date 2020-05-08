using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QWF.CRM.WebApp.Startup))]
namespace QWF.CRM.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
