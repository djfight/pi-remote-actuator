using System.Net;
using System.Net.Sockets;

namespace RemoteActuator.Core.Networking.Proxies
{
    internal class SocketProxy : ISocketProxy
    {
        private readonly Socket _socket;

        public bool Connected => _socket.Connected;
        public SocketType SocketType => _socket.SocketType;
        public ProtocolType ProtocolType => _socket.ProtocolType;
        public AddressFamily AddressFamily => _socket.AddressFamily;

        public SocketProxy(Socket socket)
        {
            _socket = socket;
        }

        public void Connect(IPEndPoint remoteEP)
        {
            _socket.Connect(remoteEP);
        }

        public void Close()
        {
            _socket.Close();
        }

        public int Send(byte[] buffer)
        {
            return _socket.Send(buffer);
        }

        public void Dispose()
        {
            _socket?.Dispose();
        }
    }
}