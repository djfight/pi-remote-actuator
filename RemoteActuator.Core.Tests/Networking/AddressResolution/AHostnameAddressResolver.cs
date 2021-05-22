using System.Net.Sockets;

using NUnit.Framework;

using RemoteActuator.Core.Networking.AddressResolution;

namespace RemoteActuator.Core.Tests.Networking.AddressResolution
{
    [TestFixture]
    internal class AHostnameAddressResolver
    {
        private const string Hostname = "localhost";
        private const int Port = 8080;
        
        [Test]
        public void ShouldGetIpv4Address()
        {
            // arrange

            const string expectedIpv4Address = "127.0.0.1";

            var sut = new HostnameAddressResolver(Hostname, Port, AddressFamily.InterNetwork);

            // act

            var endpoint = sut.GetEndpoint();

            // assert

            Assert.NotNull(endpoint);
            Assert.AreEqual(endpoint.Address.ToString(), expectedIpv4Address, "IPV4 Address");
            Assert.AreEqual(endpoint.Port, Port, "Port Number");
        }

        [Test]
        public void ShouldGetIpv6Address()
        {
            // arrange

            const string expectedIpv6Address = "::1";

            var sut = new HostnameAddressResolver(Hostname, Port, AddressFamily.InterNetworkV6);

            // act

            var endpoint = sut.GetEndpoint();

            // assert

            Assert.NotNull(endpoint);
            Assert.AreEqual(endpoint.Address.ToString(), expectedIpv6Address, "IPV6 Address");
            Assert.AreEqual(endpoint.Port, Port, "Port Number");
        }
    }
}