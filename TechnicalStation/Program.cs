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
                    .ConfigureServices((context, services) 
                        => services
                            .AddCore(context.Configuration)
                            .AddTechnicalStation(context.Configuration)
                            .AddRfIdReader(context.Configuration.Get<AppSettingsBase>().RFID)
                            .AddForms<Program>()
                            .AddDatabase(context.Configuration))
                    .Build()
                    .InitializeDatabase();

                Kernel = host.Services;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
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
