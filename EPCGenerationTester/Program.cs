using System.Net.Mime;
using Caretag_Class.Configuration;
using Caretag_Class.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RFIDAbstractionLayer;
using TechnicalStation.Forms;
using TechnicalStation.Infrastructure;
using TechnicalStation.Services;

public class MainClass
{
    public static IServiceProvider Kernel;
    
    public static void Main(string[] args)
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
                        .AddDatabase(context.Configuration)
                        .AddSingleton<EPCService>())
                
                .Build()
                .InitializeDatabase();

            Kernel = host.Services;
            

            Console.WriteLine("Hello World!");

            var epcService = Kernel.GetService<EPCService>();

            var epc = epcService.CreateNewUncommittedEpc();

            Console.WriteLine("Epc generated was: " + epc.ToString());
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            
        }
    }
}