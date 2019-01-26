using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheCollectorsCollections.Startup))]
namespace TheCollectorsCollections
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
