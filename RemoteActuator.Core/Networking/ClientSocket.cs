using System;
using System.Net;

using RemoteActuator.Core.Networking.Packets;
using RemoteActuator.Core.Networking.Proxies;
using RemoteActuator.Models;

namespace RemoteActuator.Core.Networking
{
    public class ClientSocket : IClientSocket, IPacketSender, IDisposable
    {
        public IPEndPoint IpEndpoint { get; }
        public ISocketProxy Socket { get; }

        public ClientSocket(IPEndPoint endpoint, ISocketProxy socket)
        {
            IpEndpoint = endpoint;
            Socket = socket;
        }

        /// <summary>
        /// pre-condition: packet is not null
        /// </summary>
        public void Send(IPacket packet)
        {
            if (!Socket.Connected)
            {
                Socket.Connect(IpEndpoint);
            }

            Socket.Send(packet.Serialize());
        }

        public void Dispose()
        {
            Socket?.Dispose();
        }
    }
}