using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(oopRestaurant.Startup))]
namespace oopRestaurant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
