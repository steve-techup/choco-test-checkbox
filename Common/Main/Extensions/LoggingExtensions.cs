using Destructurama;
using LanguageExt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Linq;

namespace Main.Extensions
{
    public static class LoggingExtensions
    {
        public static LoggerConfiguration FromAppSettings(this LoggerConfiguration loggerConfiguration, IConfiguration configuration)
        {
            return BuildLogging(loggerConfiguration, configuration);
        }

        public static IHostBuilder AddLogging(this IHostBuilder builder)
        {
            builder.UseSerilog((context, configuration) => BuildLogging(configuration, context.Configuration, context));
            return builder;
        }

        private static LoggerConfiguration BuildLogging(this LoggerConfiguration loggerConfiguration, IConfiguration configuration, HostBuilderContext? context = null)
        {
            var minimumLevel = configuration.GetSection("Serilog").GetValue<string>("MinimumLevel");
            LogEventLevel minimumLogLevel = LogEventLevel.Debug;

            if (string.IsNullOrWhiteSpace(minimumLevel) || !Enum.TryParse(minimumLevel, out minimumLogLevel))
            {
                minimumLogLevel = LogEventLevel.Debug;
            }



            var appInstanceId = configuration.GetSection("AppData")?.GetValue<string>("AppInstanceId");
            var elasticsearchConfig = configuration
                .GetSection("Serilog:WriteTo")
                .GetChildren()
                .FirstOrDefault(x => x.GetValue<string>("Name") == "Elasticsearch")
                ?.GetSection("Args");

            loggerConfiguration
                .Destructure.UsingAttributes()
                .Enrich.FromLogContext()
                .Destructure.ToMaximumDepth(1)
                .Enrich.WithMachineName()
                .Apply(cfg =>
                {
                    var tenant = elasticsearchConfig?.GetValue<string>("tenant");
                    tenant?.Apply(t => cfg.Enrich.WithProperty("Tenant", t));
                    return cfg;
                })
                .Enrich.WithProperty("Environment", context?.HostingEnvironment.EnvironmentName)
                .Apply(cfg =>
                {
                    var tenant = elasticsearchConfig?.GetValue<string>("context");
                    tenant?.Apply(t => cfg.Enrich.WithProperty("Application", t));
                    return cfg;
                })
                .Enrich.WithProperty("AppInstanceId", appInstanceId!)
                .WriteTo.Console();

            var fileConfig = configuration
                .GetSection("Serilog:WriteTo")
                .GetChildren()
                .FirstOrDefault(x => x.GetValue<string>("Name") == "File")
                ?.GetSection("Args");

            var logFilePath = fileConfig.GetValue<string>("path");

            if (!string.IsNullOrWhiteSpace(logFilePath))
            {
                loggerConfiguration.WriteTo.File(logFilePath, minimumLogLevel);
            }

            var elasticSearchUrl = elasticsearchConfig.GetValue<string>("nodeUris");
            if (!string.IsNullOrWhiteSpace(elasticSearchUrl))
            {
                loggerConfiguration.WriteTo.Elasticsearch(
                    new ElasticsearchSinkOptions(new Uri(elasticSearchUrl))
                    {
                        AutoRegisterTemplate = true,
                        MinimumLogEventLevel = minimumLogLevel,
                        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                        IndexFormat = elasticsearchConfig.GetValue<string>("indexFormat"),
                        ModifyConnectionSettings = cfg =>
                        {
                            var userName = elasticsearchConfig.GetValue<string>("userName");
                            var password = elasticsearchConfig.GetValue<string>("password");
                            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
                            {
                                cfg = cfg.BasicAuthentication(userName, password);
                            }

                            return cfg;
                        }
                    });
            }

            var appLevelSwitch = new LoggingLevelSwitch(minimumLogLevel);
            loggerConfiguration.MinimumLevel.ControlledBy(appLevelSwitch);
            return loggerConfiguration;
        }

    }
}