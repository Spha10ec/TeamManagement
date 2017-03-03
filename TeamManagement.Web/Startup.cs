using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamManagement.Web.Startup))]
namespace TeamManagement.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
