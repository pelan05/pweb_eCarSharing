using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pweb_eCarSharing.Startup))]
namespace pweb_eCarSharing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
