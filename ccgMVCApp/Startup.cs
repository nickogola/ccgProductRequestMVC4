using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ccgMVCApp.Startup))]
namespace ccgMVCApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
