using Microsoft.Extensions.DependencyInjection;

using RemoteActuator.Core.Networking.AddressResolution;
using RemoteActuator.Core.Networking.Factories;

namespace RemoteActuator.Core.Networking
{
    internal static class ServiceCollectionExtensions
    {
        public static void AddNetworking(this IServiceCollection services)
        {
            services.AddSingleton<IAddressResolver, HostnameAddressResolver>();

            services.AddTransient<ISocketFactory, ClientSocketFactory>();

            services.AddTransient<IClientSocket>(provider =>
            {
                var clientSocketFactory = provider.GetRequiredService<ISocketFactory>();

                return clientSocketFactory.CreateClientSocket();
            });
        }
    }
}