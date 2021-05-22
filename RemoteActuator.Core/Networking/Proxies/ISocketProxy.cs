using System;
using System.Net;
using System.Net.Sockets;

namespace RemoteActuator.Core.Networking.Proxies
{
    public interface ISocketProxy : IDisposable
    {
        bool Connected { get; }
        SocketType SocketType { get; }
        ProtocolType ProtocolType { get; }
        AddressFamily AddressFamily { get; }

        void Connect(IPEndPoint remoteEP);
        void Close();
        int Send(byte[] buffer);
    }
}