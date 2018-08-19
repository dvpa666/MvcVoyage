using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcVoyage.Startup))]
namespace MvcVoyage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
