using System.Net;

using RemoteActuator.Core.Networking.Proxies;

namespace RemoteActuator.Core.Networking
{
    public interface IClientSocket
    {
        IPEndPoint IpEndpoint { get; }
        ISocketProxy Socket { get; }
    }
}