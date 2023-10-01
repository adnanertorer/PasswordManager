using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PasswordManager.Startup))]
namespace PasswordManager
{
    public partial class Startup
    {
        
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
