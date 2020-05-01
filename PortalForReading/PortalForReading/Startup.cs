using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PortalForReading.Startup))]
namespace PortalForReading
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
