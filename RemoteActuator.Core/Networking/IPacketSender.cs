using RemoteActuator.Models;

namespace RemoteActuator.Core.Networking
{
    public interface IPacketSender
    {
        void Send(IPacket packet);
    }
}