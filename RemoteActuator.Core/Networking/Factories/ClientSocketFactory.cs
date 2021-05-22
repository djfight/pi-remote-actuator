using System.Net;
using System.Net.Sockets;

using RemoteActuator.Core.Networking.AddressResolution;

namespace RemoteActuator.Core.Networking.Factories
{
    internal class ClientSocketFactory : ISocketFactory
    {
        private readonly IAddressResolver _addressResolver;

        public ClientSocketFactory(IAddressResolver addressResolver)
        {
            _addressResolver = addressResolver;
        }

        public Socket CreateSocket()
        {
            var address = _addressResolver.GetAddress();

            var endpoint = new IPEndPoint(address.IpAddress, address.Port);

            var socket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            return socket;
        }
    }
}