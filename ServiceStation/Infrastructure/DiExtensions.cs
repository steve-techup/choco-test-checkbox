using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service_Station.Cofiguration;

namespace Service_Station.Infrastructure
{
    public static class DiExtensions
    {
        public static IServiceCollection AddServiceStation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new ResourceManager("Service_Station.WinFormStrings",
                typeof(DiExtensions).Assembly));
            return services.AddSingleton(m => configuration.Get<ServiceStationAppSettings>());
        }
    }
}