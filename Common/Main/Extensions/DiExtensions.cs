using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Resources;
using System.Windows.Forms;
using Caretag_Class.Configuration;
using Caretag_Class.EventReporting;
using Caretag_Class.Model;
using Caretag_Class.ReactiveUI;
using Caretag_Class.ReactiveUI.Services;
using Caretag_Class.Repositories;
using Caretag_Class.Services;
using Caretag_Class.Logging;
using Main.ReactiveUI.Interactions;
using Main.Repositories.UnitOfWork;
using Main.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReactiveUI;
using RFIDAbstractionLayer;
using Serilog;
using Surgical_Admin.Interactions;

namespace Caretag_Class.Extensions
{
    public static class DiExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.Get<AppSettingsBase>());
            services.AddSingleton<ILogger>(new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger());
            services.AddSingleton<ConfigurationWriter>();
            services.AddSingleton<EventReporter>();
            services.AddSingleton<IPortCache, AppsettingsPortCache>();
            services.AddSingleton<CaretagModelFactory>();
            services.AddSingleton<LoginUnitOfWorkFactory>();
            services.AddSingleton<ExcelExportService>();
            services.AddSingleton<ReactiveCommandService>();
            services.AddSingleton(s => new CommonInteractionsFactory(s.GetRequiredService<ILogger>(),
                new ResourceManager("Main.WinFormStrings", typeof(DiExtensions).Assembly),
                s.GetRequiredService<LoginUnitOfWorkFactory>()));
            services.AddSingleton<PackingListRepository>();
            services.AddSingleton<DefaultExceptionHandler>();
            services.AddSingleton<ZebraPrintService>();
            return services;
        }

        public static IServiceCollection AddForms<TFromAssemblyType>(this IServiceCollection services)
        {
            return services.Scan(scan =>
                scan.FromAssemblyOf<TFromAssemblyType>()
                    .AddClasses(c => c.AssignableTo<Form>())
                    .AsSelf()
                    .WithTransientLifetime());
        }


        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<CaretagModelFactory>();
            return services.AddTransient(provider => new CaretagModel(provider.GetService<AppSettingsBase>()?.ConnectionStrings.SQLServer));
        }

        public static IServiceCollection AddDatabaseSingleton(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddSingleton(provider => new CaretagModel(provider.GetService<AppSettingsBase>()?.ConnectionStrings.SQLServer));
        }

        public static IHost InitializeDatabase(this IHost host)
        {
            var applySqlMigrations = host.Services.GetService<AppSettingsBase>()?.ApplySqlMigrations ?? false;

            if (applySqlMigrations)
            {
                var logger = host.Services.GetRequiredService<ILogger>();
                try
                {
                    Database.SetInitializer(new MigrateDatabaseToLatestVersion<CaretagModel, Migrations.Configuration>(true));
                    var context = host.Services.GetRequiredService<CaretagModel>();
                    context.Database.Log = Console.Write;
                    context.Database.Initialize(false);
                }
                catch (Exception e)
                {
                    logger.Fatal(e, e.Message);
                    throw;
                }
            }
            else
            {
                //if init strategy is null then EF do not run migrations
                Database.SetInitializer(default(IDatabaseInitializer<CaretagModel>));
            }

            return host;
        }

        public static IServiceCollection AddVerboseLogging(this IServiceCollection services)
        {
            return services.AddSingleton<VerboseLogger>();
        }
    }
}