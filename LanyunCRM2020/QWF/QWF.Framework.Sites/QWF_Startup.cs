using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QWF.Framework.Sites.QWF_Startup))]
namespace QWF.Framework.Sites
{
    public partial class QWF_Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
