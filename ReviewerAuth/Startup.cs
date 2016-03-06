using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReviewerAuth.Startup))]
namespace ReviewerAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
