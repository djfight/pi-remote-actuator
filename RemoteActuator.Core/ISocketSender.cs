using RemoteActuator.Models;

namespace RemoteActuator.Core
{
    public interface ISocketSender
    {
        void Send(IPacket packet);
    }
}