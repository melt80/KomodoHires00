using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KomodoHires.WebMVC.Startup))]
namespace KomodoHires.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
