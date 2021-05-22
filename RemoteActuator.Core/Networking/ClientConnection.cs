using System.Net.Sockets;

using RemoteActuator.Models;

namespace RemoteActuator.Core.Networking
{
    internal class ClientConnection : IPacketSender
    {
        private readonly Socket _clientSocket;

        public ClientConnection(Socket clientSocket)
        {
            _clientSocket = clientSocket;
        }

        public void Send(IPacket packet)
        {
            throw new System.NotImplementedException();
        }
    }
}
