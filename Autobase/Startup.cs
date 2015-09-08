using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Autobase.Startup))]
namespace Autobase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
