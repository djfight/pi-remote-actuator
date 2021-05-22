using System.Collections.Generic;

using RemoteActuator.Core.Networking;
using RemoteActuator.Core.Networking.Packets;
using RemoteActuator.Models;

namespace RemoteActuator.Core.Clients
{
    internal class ActuationClient : IActuationClient
    {
        private readonly IClientSocket _clientSocket;

        public ActuationClient(IClientSocket clientSocket)
        {
            _clientSocket = clientSocket;
        }

        public void SendCommand(MessageType messageType, int pinNumber, bool signal)
        {
            // Note: potentially abstract this later
            var packetFragments = new List<IPacketFragment>()
            {
                new CommandPacketFragment(messageType),
                new PinNumberPacketFragment(pinNumber),
                new SignalPacketFragment(signal)
            };

            var packet = new ActuationPacket(packetFragments);

            _clientSocket.Send(packet);
        }

        public void Dispose()
        {
            _clientSocket?.Dispose();
        }
    }
}