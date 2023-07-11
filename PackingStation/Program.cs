using System;
using System.Globalization;
using System.Windows.Forms;
using Caretag_Class.Configuration;
using Caretag_Class.Extensions;
using Caretag_Class.ReactiveUI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PackingStation.Configuration;
using PackingStation.Infrastructure;
using PackingStation.Views;
using ReactiveUI;
using RFIDAbstractionLayer;
using RFIDAbstractionLayer.Readers;
using static System.Windows.Forms.Application;

namespace PackingStation
{
    internal class Program
    {
        public static IServiceProvider Kernel;

        [STAThread]
        public static void Main()
        {
            
            try
            {

                using var host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                    .ConfigureAppConfiguration((context, builder)
                        => builder.AddConfiguration()
                    )
                    .ConfigureServices((context, services)
                        => services
                            .AddCore(context.Configuration)
                            .AddVerboseLogging()
                            .AddPackingStation(context.Configuration)
                            .AddRfIdReader(context.Configuration.Get<AppSettingsBase>().RFID)
                            .AddForms<Program>()
                            .AddDatabase(context.Configuration))
                    .Build()
                    .InitializeDatabase();

                Kernel = host.Services;

                var configuration = Kernel.GetRequiredService<AppSettingsBase>();

                CurrentCulture = new CultureInfo(configuration.UILanguage);
                CultureInfo.CurrentUICulture = new CultureInfo(configuration.UILanguage);

                EnableVisualStyles();
                SetCompatibleTextRenderingDefault(false);

                RxApp.DefaultExceptionHandler = Kernel.GetRequiredService<DefaultExceptionHandler>();

                var mainForm = Kernel.GetRequiredService<FrmMain>();
                Run(mainForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected exception during startup: {ex.Message}\n\n{ex.StackTrace}");
            }
        }
    }
}