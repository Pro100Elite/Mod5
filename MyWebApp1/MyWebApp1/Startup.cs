using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyWebApp1.Startup))]
namespace MyWebApp1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
