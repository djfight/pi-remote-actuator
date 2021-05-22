using System.Net;

namespace RemoteActuator.Core.Networking.AddressResolution
{
    public interface IAddressResolver
    {
        /// <summary>
        /// Address interface that contains the endpoint information.
        /// </summary>
        /// <returns>
        /// Post-condition: Should never return null.
        /// </returns>
        IPEndPoint GetEndpoint();
    }
}