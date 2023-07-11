using System;
using System.Windows.Forms;
using Caretag_Class.Configuration;
using Caretag_Class.Extensions;
using Caretag_Class.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service_Station.CARETAG_Main;
using RFIDAbstractionLayer;
using Service_Station.Infrastructure;


namespace Service_Station
{
    internal class Program
    {
        public static IServiceProvider Kernel;

        [STAThread]
        public static void Main()
        {
            var host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, builder) 
                    => builder.AddConfiguration()
                )
                .ConfigureServices((context, services) 
                    => services
                        .AddCore(context.Configuration)
                        .AddServiceStation(context.Configuration)
                        .AddRfIdReader(context.Configuration.Get<AppSettingsBase>().RFID)
                        .AddDatabase(context.Configuration)
                        .AddForms<Program>())
                .Build()
                .InitializeDatabase();

            Kernel = host.Services;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = Kernel.GetRequiredService<FrmMain>();
            Application.Run(mainForm);
        }
    }
}

