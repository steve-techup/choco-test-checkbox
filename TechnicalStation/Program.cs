using System;
using System.Windows.Forms;
using Caretag_Class.Configuration;
using Caretag_Class.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RFIDAbstractionLayer;
using TechnicalStation.Forms;
using TechnicalStation.Infrastructure;
using Main.Extensions;
using OnScreenKeyboard.DiExtensions;
using Main.Services;
using System.Threading;
using System.Globalization;

namespace TechnicalStation
{
    internal class Program
    {
        public static IServiceProvider Kernel;

        [STAThread]
        public static void Main()
        {
            try
            {
                var host = Host.CreateDefaultBuilder()
                    .ConfigureAppConfiguration((context, builder)
                        => builder.AddConfiguration()
                    )
                    .AddLogging()
                    .ConfigureServices((context, services)
                        => services
                            .AddCore(context.Configuration)
                            .AddTechnicalStation(context.Configuration)
                            .AddRfIdReader(context.Configuration.Get<AppSettingsBase>().RFID)
                            .AddOnScreenKeyboard(context.Configuration.Get<AppSettingsBase>().OnScreenKeyboardConfig, context.Configuration.Get<AppSettingsBase>().UILanguage)
                            .AddForms<Program>())
                    .Build()
                    .InitializeDatabase();

                Kernel = host.Services;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var The_UI_Language = Kernel.GetRequiredService<AppSettingsBase>().UILanguage;
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(The_UI_Language);

                if (Kernel.GetRequiredService<AppSettingsBase>().UseApi)
                {
                    var loginService = Kernel.GetRequiredService<LoginService>();

                    if(!loginService.Login())
                    {
                        Environment.Exit(0);
                    }
                }

                var mainForm = Kernel.GetRequiredService<ProgramInstrument>();
                Application.Run(mainForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected exception during startup: {ex.Message}\n\n{ex.StackTrace}");
            }
        }
    }
}
