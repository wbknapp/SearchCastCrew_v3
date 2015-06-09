using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SearchCastCrew.Startup))]
namespace SearchCastCrew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
