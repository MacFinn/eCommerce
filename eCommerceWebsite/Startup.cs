using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eCommerceWebsite.Startup))]
namespace eCommerceWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
