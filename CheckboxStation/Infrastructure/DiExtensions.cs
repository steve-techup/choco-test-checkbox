using System.Resources;
using Caretag_Class.ReactiveUI;
using CheckboxStation.Configuration;
using CheckboxStation.Services;
using CheckboxStation.ViewModels;
using CheckboxStation.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Splat;
using Splat.Serilog;
using Surgical_Admin.Interactions;
using ILogger = Serilog.ILogger;

namespace CheckboxStation.Infrastructure
{
    public static class DiExtensions
    {
        public static IServiceCollection AddCheckboxStation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(new ResourceManager("CheckboxStation.WinFormStrings",
                typeof(DiExtensions).Assembly));
            services.AddServices();
            services.AddSingleton<CheckboxViewModel>();
            services.AddScoped<CheckInViewModel>();
            services.AddSingleton<CheckboxInteractions>();
            services.AddSingleton<CheckInViewModelFactory>();
            services.AddSingleton<PackingListValidationService>();
            services.AddSingleton<DefaultExceptionHandler>();
            
            return services.AddSingleton(m => configuration.Get<CheckboxStationAppSettings>());
        }
        
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<CheckStateService>()
                .AddScoped<InstrumentService, InstrumentService>()
                .AddScoped<ScanEventService, ScanEventService>()
                .AddScoped<CheckboxService>()
                .AddScoped<ReportingService>();
        }
        
    }
}
