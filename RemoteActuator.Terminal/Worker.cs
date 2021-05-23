using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;

using RemoteActuator.Core.Clients;
using RemoteActuator.Models;

namespace RemoteActuator.Terminal
{
    public class Worker : IHostedService
    {
        private readonly IActuationClient _actuationClient;

        public Worker(IActuationClient actuationClient)
        {
            _actuationClient = actuationClient;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _actuationClient.SendCommand(MessageType.DeviceCommand, 0, false);

            _actuationClient.Dispose();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}