using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlatShop.Startup))]
namespace FlatShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
