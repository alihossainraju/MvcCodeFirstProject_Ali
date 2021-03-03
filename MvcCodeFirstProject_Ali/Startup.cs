using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcCodeFirstProject_Ali.Startup))]
namespace MvcCodeFirstProject_Ali
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
