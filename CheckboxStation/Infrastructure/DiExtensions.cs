using System;
using System.Resources;
using Caretag.Contracts;
using System.Windows.Forms;
using Caretag_Class.Configuration;
using Caretag_Class.Extensions;
using Caretag_Class.ReactiveUI;
using CheckboxStation.Configuration;
using CheckboxStation.Services;
using CheckboxStation.ViewModels;
using CheckboxStation.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Crypto;
using Serilog;
using Splat;
using Splat.Serilog;
using Surgical_Admin.Interactions;
using ILogger = Serilog.ILogger;
using CheckboxStation.Services.Bridge;
using CheckboxStation.Services.Bridge.Imlementations;
using CheckboxStation.Services.Bridge.Imlementations.CheckIn;

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

            if (configuration.Get<AppSettingsBase>().UseApi)
            {
                //Check if the AppInstanceId is configured (it's required for some of the API methods)
                if (configuration.Get<AppSettingsBase>().AppData == null || string.IsNullOrEmpty(configuration.Get<AppSettingsBase>().AppData.AppInstanceId))
                {
                    MessageBox.Show("AppInstanceId is missing. Please ensure that the configuration contains an AppData section containing the AppInstanceId and restart the application.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
                else
                {
                    // New implementation and API
                    services.AddSingleton<IScanService, ScanServiceApi>()
                            .AddSingleton<ICheckInService, CheckInServiceApi>()
                            .AddApi(configuration.Get<AppSettingsBase>().ApiUrl);
                            
                    //services.AddDatabaseSingleton(configuration); // Remove !!!
                }
            }
            else
            {
                // Old imlementation and database
                services.AddSingleton<IScanService, ScanServiceDb>()
                        .AddSingleton<ICheckInService, CheckInServiceDb>()
                        .AddDatabaseSingleton(configuration);
            }

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
