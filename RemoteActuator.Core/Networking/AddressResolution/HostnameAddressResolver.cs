using System.Linq;
using System.Net;

using Microsoft.Extensions.Options;

using RemoteActuator.Models;

namespace RemoteActuator.Core.Networking.AddressResolution
{
    /// <inheritdoc cref="IAddressResolver"/>
    public class HostnameAddressResolver : IAddressResolver
    {
        private readonly ClientConfiguration _clientConfiguration;

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
        public HostnameAddressResolver(IOptions<ClientConfiguration> options)
        {
            _clientConfiguration = options.Value;
        }

        /// <summary>
        /// post-condition: hostname exists in DNS lookup
        /// post-condition: address is found for given address family
        /// </summary>
        public IPEndPoint GetEndpoint()
        {
            var hostEntry = Dns.GetHostEntry(_clientConfiguration.Hostname);
            var ipAddress =
                hostEntry.AddressList.First(address =>
                    address.AddressFamily == _clientConfiguration.AddressFamily);
            return new IPEndPoint(ipAddress, _clientConfiguration.Port);
        }
    }
}