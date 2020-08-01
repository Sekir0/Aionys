using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Aionys.Configurations
{
    /// <summary>
    /// mvc and swagger configurations
    /// </summary>
    public class MvcConfig : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Aionys", Version = "v1" });
            });
        }
    }
}
