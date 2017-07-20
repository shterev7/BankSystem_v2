using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankSystem_v2.Startup))]
namespace BankSystem_v2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
