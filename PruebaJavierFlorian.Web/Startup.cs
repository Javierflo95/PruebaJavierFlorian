using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PruebaJavierFlorian.Web.Startup))]
namespace PruebaJavierFlorian.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
