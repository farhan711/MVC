using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieMix.Startup))]
namespace MovieMix
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
