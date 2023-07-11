using System;
using System.Resources;
using System.Windows.Forms;
using Caretag.Contracts;
using Caretag_Class.Configuration;
using Caretag_Class.Extensions;
using DevExpress.DashboardCommon.Native.DashboardRestfulService;
using DevExpress.Map.Native;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Crypto;
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
                    services.AddSingleton<IDataRepository, ApiWrapper>()
                            .AddApi(configuration.Get<AppSettingsBase>().ApiUrl);
                    services.AddApiLogin();
                }
            }
            else
                services.AddSingleton<IDataRepository, ClassicWrapper>()
                        .AddDatabase(configuration);

            services.AddSingleton<EPCService>();
            return services.AddSingleton(m => configuration.Get<TechnicalStationAppSettings>());
        }
    }
}
