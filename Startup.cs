using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Microzayim.Startup))]
namespace Microzayim
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
