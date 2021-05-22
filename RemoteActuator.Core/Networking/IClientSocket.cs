using System;
using System.Net;

using RemoteActuator.Core.Networking.Proxies;
using RemoteActuator.Models;

namespace RemoteActuator.Core.Networking
{
    public interface IClientSocket : IDisposable
    {
        IPEndPoint IpEndpoint { get; }
        ISocketProxy Socket { get; }

        void Send(IPacket packet);
    }
}