using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
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
                        .AddTransient<EPCService>())

                .Build()
                .InitializeDatabase();

            Kernel = host.Services;
            
            Console.WriteLine("Hello World!");
            
            var tasks = new List<Task>();
            //Run 5 threads creating 1000 EPCs each
            for (int i = 0; i < 5; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    var epcService = Kernel.GetService<EPCService>();
                    for (int j = 0; j < 1000; j++)
                    {
                        var epc = epcService.CreateNewUncommittedEpc();
                    }
                }));
            }
            tasks.ForEach(t => t.Wait());
            
            Console.WriteLine("Generated 5x1000 committed EPCs");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.ReadKey();
            Console.WriteLine(ex);
        }
    }
}