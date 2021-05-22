using System.Net;

namespace RemoteActuator.Core.Networking.AddressResolution
{
    internal class Address : IAddress
    {
        public IPAddress IpAddress { get; }
        public int Port { get; }

        /// <summary>
        /// pre-condition IPAddress is not null
        /// pre-condition: port number between 0 and 65535
        /// </summary>
        public Address(IPAddress ipAddress, int port)
        {
            IpAddress = ipAddress;
            Port = port;
        }
    }
}