using RemoteActuator.Models;

namespace RemoteActuator.Core.Networking.Packets
{
    public interface IPacketSender
    {
        void Send(IPacket packet);
    }
}