using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(css.web.FormSheet.Startup))]
namespace css.web.FormSheet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
