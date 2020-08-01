using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Aionys.Configurations
{
    /// <summary>
    /// Interface IInstaller
    /// </summary>
    public interface IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
