using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FashionIA.Startup))]
namespace FashionIA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
