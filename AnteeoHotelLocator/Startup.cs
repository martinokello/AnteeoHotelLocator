using Microsoft.Owin;
using Owin;
[assembly: OwinStartupAttribute(typeof(AnteeoHotelLocator.Startup))]
namespace AnteeoHotelLocator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
