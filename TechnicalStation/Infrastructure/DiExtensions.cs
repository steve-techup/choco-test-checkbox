using System.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechnicalStation.Configuration;
using TechnicalStation.Services;

namespace TechnicalStation.Infrastructure
{
    public static class DiExtensions
    {
        public static IServiceCollection AddTechnicalStation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new ResourceManager("TechnicalStation.WinFormStrings",
                typeof(DiExtensions).Assembly));
            services.AddSingleton<EPCService>();
            return services.AddSingleton(m => configuration.Get<TechnicalStationAppSettings>());
        }
    }
}
