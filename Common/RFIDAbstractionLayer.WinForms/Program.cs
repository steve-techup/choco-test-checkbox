using System;
using System.IO;
using System.Windows.Forms;
using Caretag_Class.Configuration;
using Caretag_Class.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace RFIDAbstractionLayer.WinForms
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, builder) 
                    => builder.AddConfiguration()
                )
                .ConfigureServices((context, services) 
                    => services
                        .AddCore(context.Configuration)
                        .AddRfIdReader(context.Configuration.Get<AppSettingsBase>().RFID)
                        .AddForms<Program>())
                .Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(host.Services.GetRequiredService<MainForm>());
        }
    }
}
