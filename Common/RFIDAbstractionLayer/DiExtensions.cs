using Microsoft.Extensions.DependencyInjection;
using RFIDAbstractionLayer.Readers;

namespace RFIDAbstractionLayer
{
    public static class DiExtensions
    {
        public static IServiceCollection AddRfIdReader(this IServiceCollection services, RfIdConfig config)
        {
            return services.AddSingleton<RFIDReaderCollection>()
                .AddSingleton<RFIDReaderFactory>()
                .AddSingleton<CAENReaderFactory>()
                .AddSingleton<RFIDReaderCommon>()
                .AddSingleton(config);
        }
    }
}