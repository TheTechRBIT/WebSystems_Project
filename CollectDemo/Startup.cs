using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CollectDemo.Startup))]
namespace CollectDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
