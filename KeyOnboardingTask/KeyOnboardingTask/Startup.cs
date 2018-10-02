using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KeyOnboardingTask.Startup))]
namespace KeyOnboardingTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
