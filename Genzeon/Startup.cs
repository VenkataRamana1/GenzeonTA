using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Genzeon.Startup))]
namespace Genzeon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
