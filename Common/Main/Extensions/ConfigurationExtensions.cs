using System.IO;
using Microsoft.Extensions.Configuration;

namespace Caretag_Class.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IConfigurationBuilder AddConfiguration(this IConfigurationBuilder configurationBuilder)
        {
            return configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.user.json", true, true);
        }
    }
}