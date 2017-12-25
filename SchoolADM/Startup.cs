using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolADM.Startup))]
namespace SchoolADM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
