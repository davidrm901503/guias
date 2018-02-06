using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventsManager.Web.Startup))]
namespace EventsManager.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureContainer(app);
            ConfigureAuth(app);

            app.MapSignalR();
        }
    }
}
