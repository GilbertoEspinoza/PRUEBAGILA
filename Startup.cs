using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PRUEBAGILA.Startup))]
namespace PRUEBAGILA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}