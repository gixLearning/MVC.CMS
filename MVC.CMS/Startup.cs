using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC.CMS.Startup))]
namespace MVC.CMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
