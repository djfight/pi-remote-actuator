using System;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RemoteActuator.Core;
using RemoteActuator.Models;

namespace RemoteActuator.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Remote Actuator Startup...");

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false);
                    config.AddEnvironmentVariables();
                })
                .ConfigureServices((context, services) =>
                {
                    services.Configure<ClientConfiguration>(context.Configuration.GetSection("ClientConfiguration"));

                    services.AddCore();

                    services.AddHostedService<Worker>();
                });

            host.Build().Run();
        }
    }
}
