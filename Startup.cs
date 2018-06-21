using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DancerWeb.Startup))]
namespace DancerWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
