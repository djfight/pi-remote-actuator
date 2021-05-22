namespace RemoteActuator.Core.Networking.Factories
{
    public interface ISocketFactory
    {
        IClientSocket CreateClientSocket();
    }
}