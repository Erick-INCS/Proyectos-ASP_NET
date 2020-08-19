using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoffeStreet.Startup))]
namespace CoffeStreet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
