using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IoC_Demo.Startup))]
namespace IoC_Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
