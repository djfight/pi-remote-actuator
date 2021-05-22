using System.Net.Sockets;

using RemoteActuator.Core.Networking.AddressResolution;
using RemoteActuator.Core.Networking.Proxies;

namespace RemoteActuator.Core.Networking.Factories
{
    internal class ClientSocketFactory : ISocketFactory
    {
        private readonly IAddressResolver _addressResolver;

        public ClientSocketFactory(IAddressResolver addressResolver)
        {
            _addressResolver = addressResolver;
        }

        public IClientSocket CreateClientSocket()
        {
            var endpoint = _addressResolver.GetEndpoint();
            
            var socket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            return new ClientSocket(endpoint, new SocketProxy(socket));
        }
    }
}