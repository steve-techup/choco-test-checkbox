using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RFIDAbstractionLayer.Simulator.Repositories;

namespace RFIDAbstractionLayer.Simulator.Extensions
{
    public static class DiExtensions
    {
        
        public static IServiceCollection AddSimulator(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<MainWindow>();
            services.AddLogging();
            return services;
        }
    }
}
