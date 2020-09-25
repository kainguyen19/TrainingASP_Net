using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab_MemberShip.Startup))]
namespace Lab_MemberShip
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
