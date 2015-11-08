using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrimTailor.Startup))]
namespace TrimTailor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
