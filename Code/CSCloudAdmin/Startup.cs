using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSCloudAdmin.Startup))]
namespace CSCloudAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
