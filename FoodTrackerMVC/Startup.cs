using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodTrackerMVC.Startup))]
namespace FoodTrackerMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
