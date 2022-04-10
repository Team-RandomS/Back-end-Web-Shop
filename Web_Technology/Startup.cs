using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_Technology.Startup))]
namespace Web_Technology
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
