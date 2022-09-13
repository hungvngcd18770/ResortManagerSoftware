using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ResortManagerSoftware.Startup))]
namespace ResortManagerSoftware
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
