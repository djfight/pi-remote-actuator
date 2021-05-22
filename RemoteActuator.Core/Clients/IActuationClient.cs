using System;

using RemoteActuator.Models;

namespace RemoteActuator.Core.Clients
{
    public interface IActuationClient : IDisposable
    {
        void SendCommand(MessageType messageType, int pinNumber, bool signal);
    }
}