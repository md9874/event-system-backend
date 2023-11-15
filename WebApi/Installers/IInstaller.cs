namespace WebApi.Installers
{
    public interface IInstaller
    {
        void InstalServices(IServiceCollection services, IConfiguration configuration);
    }
}
