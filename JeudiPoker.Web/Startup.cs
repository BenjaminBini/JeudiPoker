using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(JeudiPoker.Web.Startup))]

namespace JeudiPoker.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}