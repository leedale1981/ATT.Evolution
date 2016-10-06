using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ATT.Evolution.Web.Startup))]
namespace ATT.Evolution.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
