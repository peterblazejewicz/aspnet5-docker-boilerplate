using Microsoft.AspNet.Builder;

namespace AspNetDockerBoilerplate
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940

        public void Configure(IApplicationBuilder app)
        {
            app.UseWelcomePage();
        }
    }
}
