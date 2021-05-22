using System.Net;

namespace RemoteActuator.Core.Networking.AddressResolution
{
    public interface IAddress
    {
        public IPAddress IpAddress { get; }
        public int Port { get; }
    }
}