using RemoteActuator.Models;

namespace RemoteActuator.Core.Clients
{
    public interface IActuationClient
    {
        void SendCommand(MessageType messageType, int pinNumber, bool signal);
    }
}