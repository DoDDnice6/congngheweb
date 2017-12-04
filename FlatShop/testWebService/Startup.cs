using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testWebService.Startup))]
namespace testWebService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
