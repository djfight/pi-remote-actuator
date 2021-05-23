using System.Net.Sockets;

namespace RemoteActuator.Models
{
    public class ClientConfiguration
    {
        public string Hostname { get; set; }
        public int Port { get; set; }
        public AddressFamily AddressFamily { get; set; }
    }
}