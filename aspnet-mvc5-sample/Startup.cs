using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aspnet_mvc5_sample.Startup))]
namespace aspnet_mvc5_sample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
