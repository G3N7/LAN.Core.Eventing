using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RailsSharp.Example.Startup))]
namespace RailsSharp.Example
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
			app.MapSignalR();
        }
    }
}
