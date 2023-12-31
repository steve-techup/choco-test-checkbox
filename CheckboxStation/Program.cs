﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caretag_Class;
using Caretag_Class.Configuration;
using Caretag_Class.Extensions;
using Caretag_Class.Model;
using Caretag_Class.ReactiveUI;
using CheckboxStation.Infrastructure;
using CheckboxStation.Services;
using CheckboxStation.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using RFIDAbstractionLayer;
using Splat;
using Main.Extensions;
using OnScreenKeyboard.DiExtensions;

namespace CheckboxStation
{
    internal static class Program
    {
        public static IServiceProvider Kernel;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                    .ConfigureAppConfiguration((context, builder)
                        => builder.AddConfiguration()
                    )
                    .AddLogging()
                    .ConfigureServices((context, services)
                        => services
                            .AddCore(context.Configuration)
                            .AddVerboseLogging()
                            .AddCheckboxStation(context.Configuration)
                            .AddRfIdReader(context.Configuration.Get<AppSettingsBase>().RFID)
                            .AddOnScreenKeyboard(context.Configuration.Get<AppSettingsBase>().OnScreenKeyboardConfig, context.Configuration.Get<AppSettingsBase>().UILanguage)
                            .AddForms<MainForm>())
                    .Build();

                Kernel = host.Services;

                if (!Kernel.GetRequiredService<AppSettingsBase>().UseApi)
                {
                    host.InitializeDatabase();
                }

                //Locator.CurrentMutable.UseSerilogFullLogger(Kernel.GetRequiredService<Serilog.ILogger>());

                RxApp.DefaultExceptionHandler = Kernel.GetRequiredService<DefaultExceptionHandler>();

                var checkboxService = Kernel.GetRequiredService<CheckboxService>();
                if (checkboxService.StartupShowSplash())
                {
                    var mainForm = Kernel.GetRequiredService<MainForm>();
                    Application.Run(mainForm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected exception during startup: {ex.Message}\n\n{ex.StackTrace}");
            }
        }
    }
}
