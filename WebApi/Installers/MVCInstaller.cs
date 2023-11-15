using Application;
using Infrastructure;

namespace WebApi.Installers
{
    public class MVCInstaller : IInstaller
    {
        public void InstalServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();
            services.AddInfrastructure();
            services.AddControllers();
        }
    }
}
