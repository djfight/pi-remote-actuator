using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace RemoteActuator.Core.Networking.AddressResolution
{
    /// <inheritdoc cref="IAddressResolver"/>
    public class HostnameAddressResolver : IAddressResolver
    {
        private readonly string _hostname;
        private readonly int _port;
        private readonly AddressFamily _addressFamily;

        /// <summary>
        /// Attempts to resolve an address by its hostname via DNS.
        /// <list type="bullet">
        /// <item>
        /// <description>pre-condition: hostname is not null or empty</description>
        /// </item>
        /// <item>
        /// <description>pre-condition: hostname is less than or equal to 255 characters</description>
        /// </item>
        /// </list>
        /// </summary>
        public HostnameAddressResolver(string hostname, int port, AddressFamily addressFamily)
        {
            _hostname = hostname;
            _port = port;
            _addressFamily = addressFamily;
        }

        /// <summary>
        /// post-condition: hostname exists in DNS lookup
        /// post-condition: address is found for given address family
        /// </summary>
        public IAddress GetAddress()
        {
            var hostEntry = Dns.GetHostEntry(_hostname);

            var ipAddress = hostEntry.AddressList.First(address => address.AddressFamily == _addressFamily);

            return new Address(ipAddress, _port);
        }
    }
}