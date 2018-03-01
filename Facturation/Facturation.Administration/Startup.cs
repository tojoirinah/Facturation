using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Facturation.Administration.Startup))]
namespace Facturation.Administration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
