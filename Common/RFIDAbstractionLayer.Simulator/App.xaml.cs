using Microsoft.Extensions.DependencyInjection;
using RFIDAbstractionLayer.Simulator.Model;
using RFIDAbstractionLayer.Simulator.Resources;
using RFIDAbstractionLayer.Simulator.Windows;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Caretag_Class;
using Caretag_Class.Extensions;
using Caretag_Class.Model;
using RFIDAbstractionLayer.Simulator.Extensions;
using RFIDAbstractionLayer.Simulator.Repositories;
using WPFLocalizeExtension.Engine;


namespace RFIDAbstractionLayer.Simulator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly List<SimulatorItem> _dbItems = new();
        public static SplashWindow SplashScreen = new();
        private MainWindow mainWindow;

        public static IServiceProvider Kernel;

        public App()
        {
        }

        public static void DoEvents()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Render,
                new Action(delegate { }));
        }

        public static void ShowNewProgress(string message)
        {
            SplashScreen.UpdateProgress(message);
            DoEvents();
        }

        public static string Translate(string msg)
        {
            return LocalizedStrings.Instance[msg];
        }

        public void Application_Startup(object sender, StartupEventArgs e)
        {
            SplashScreen.Show();
            ShowNewProgress(Translate("LoadingSettings"));
            LocalizeDictionary.Instance.Culture = CultureInfo.CurrentCulture;

            ShowNewProgress(Translate("ConfiguringServices"));
            using var host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, builder)
                    => builder.AddConfiguration()
                )
                .ConfigureServices((context, services)
                    => services
                        .AddCore(context.Configuration)
                        .AddSimulator(context.Configuration)
                        .AddDatabase(context.Configuration))
                .Build()
                .InitializeDatabase();

            Kernel = host.Services;

            ShowNewProgress(Translate("LoadingAPIItems"));

            using var uow = new SimulatorUnitOfWork(Kernel.GetService<CaretagModelFactory>());


            _dbItems.AddRange(uow.InstrumentRepository.Get(take: 100).ToList().ConvertAll(i => new SimulatorItem(i)));
            _dbItems.AddRange(uow.ContainerRepository.Get().ToList().ConvertAll(c => new SimulatorItem(c)));
            _dbItems.AddRange(uow.TrayRepository.Get().ToList().ConvertAll(t => new SimulatorItem(t)));

            mainWindow = Kernel.GetService<MainWindow>();
            mainWindow.InitWindow(_dbItems);

            SplashScreen.Hide();
            mainWindow.Show();
        }
        
    }
}
