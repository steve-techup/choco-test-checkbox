using Caretag_Class.Rules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackingStation.Configuration;
using System.Resources;
using Caretag_Class;
using Caretag_Class.Repositories;
using PackingStation.Repositories;
using PackingStation.Services;
using PackingStation.Views;

namespace PackingStation.Infrastructure
{
    public static class DiExtensions
    {
        public static IServiceCollection AddPackingStation(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddSingleton(m => configuration.Get<PackingStationAppSettings>())
                .AddSingleton<InstrumentServiceChecker>()
                .AddSingleton<PackingStationUnitOfWorkFactory>()
                .AddSingleton<PackingListRepository>()
                .AddSingleton<PackedTrayReportService>()
                .AddSingleton(new ResourceManager("PackingStation.WinFormStrings", typeof(FrmMain).Assembly));
        }
    }
}