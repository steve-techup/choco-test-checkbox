using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using AdminStation.Infrastructure;
using Caretag_Class.Configuration;
using Caretag_Class.Extensions;
using Caretag_Class.ReactiveUI;
using DevExpress.Xpo.DB.Exceptions;
using Main.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NurApiDotNet;
using ReactiveUI;
using Splat.Microsoft.Extensions.DependencyInjection;

namespace AdminStation;

internal sealed class Program
{
    public static IServiceProvider Kernel;

    /// <summary>
    ///     ''' The main entry point for the application.
    ///     '''
    /// </summary>
    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        try
        {

            
            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, builder)
                    => builder.AddConfiguration()
                )
                .ConfigureServices((context, services)
                    =>
                {
                    services
                        .AddCore(context.Configuration)
                        .AddAdminStation(context.Configuration)
                        .AddDatabase(context.Configuration);
                    services.UseMicrosoftDependencyResolver();
                    services.AddSingleton<IViewLocator, ViewModelProvidingViewLocator>();
                })
                .Build()
                .InitializeDatabase();

            Kernel = host.Services;
            // Run application
            var appSettingsBase = Kernel.GetRequiredService<AppSettingsBase>();

            // Setup DevExpress datalayer
            var mainViewModel = Kernel.GetRequiredService<IScreen>();

            // Resolve view for MainViewModel
            var view = ViewLocator.Current.ResolveView(mainViewModel);
            view.ViewModel = mainViewModel;
            
            AppDomain.CurrentDomain.FirstChanceException += (sender, args) =>
            {
                if (args.Exception is OperationCanceledException || args.Exception is NurApiException || 
                    args.Exception is IOException || args.Exception is TypeLoadException || args.Exception is FormatException)
                    return;

                if (Debugger.IsAttached)
                    Debugger.Break();

                string userMessage = "An unexpected error happened. ";
                string logMessage = "An unexpected error happened. ";

                if (args.Exception is SchemaCorrectionNeededException)
                {
                    userMessage = "An error occurred while querying the database ";
                    logMessage = "An error occurred while querying the database - schema did not match model. ";
                }

                MessageBox.Show(userMessage + "Please contact support.\n" + logMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            RxApp.DefaultExceptionHandler = Kernel.GetRequiredService<DefaultExceptionHandler>();

            Application.Run((Form) view);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Unexpected exception during startup: {ex.Message}\n\n{ex.StackTrace}");
        }
    }
}