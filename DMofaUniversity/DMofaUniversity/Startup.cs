using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DMofaUniversity.Startup))]
namespace DMofaUniversity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
