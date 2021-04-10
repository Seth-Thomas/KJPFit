using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KJPFit.WebMVC.Startup))]
namespace KJPFit.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
