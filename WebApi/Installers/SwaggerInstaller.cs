namespace WebApi.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstalServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
            });
        }
    }
}
