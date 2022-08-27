using System.Net;
using Microsoft.Extensions.Options;
using RemoteActuator.Models;

namespace RemoteActuator.Core.Networking.AddressResolution
{
    /// <inheritdoc cref="IAddressResolver"/>
    public class IpAddressResolver : IAddressResolver
    {
        private readonly EndpointConfiguration _endpointConfiguration;

        public IpAddressResolver(IOptions<EndpointConfiguration> options)
        {
            _endpointConfiguration = options.Value;
        }

        public IPEndPoint GetEndpoint()
        {
            var ipAddress = IPAddress.Parse(_endpointConfiguration.IpAddress);
            return new IPEndPoint(ipAddress, _endpointConfiguration.Port);
        }
    }
}