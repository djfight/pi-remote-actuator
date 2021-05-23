using Microsoft.Extensions.DependencyInjection;

using RemoteActuator.Core.Clients;
using RemoteActuator.Core.Networking;

namespace RemoteActuator.Core
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCore(this IServiceCollection services)
        {
            services.AddNetworking();

            services.AddTransient<IActuationClient, ActuationClient>(provider =>
            {
                var clientSocket = provider.GetRequiredService<IClientSocket>();

                return new ActuationClient(clientSocket);
            });
        }
    }
}