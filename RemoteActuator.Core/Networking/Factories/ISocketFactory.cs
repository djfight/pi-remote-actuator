using System.Net.Sockets;

namespace RemoteActuator.Core.Networking.Factories
{
    public interface ISocketFactory
    {
        //Note: create an adapter pattern around this socket to mock/stub behavior? or is that overkill?
        Socket CreateSocket();
    }
}