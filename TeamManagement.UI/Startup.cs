using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamManagement.UI.Startup))]
namespace TeamManagement.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
