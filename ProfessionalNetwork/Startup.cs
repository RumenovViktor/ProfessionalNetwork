using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProfessionalNetwork.Startup))]
namespace ProfessionalNetwork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
