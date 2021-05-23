using System.Net.Sockets;

using Microsoft.Extensions.Options;

using Moq;

using NUnit.Framework;

using RemoteActuator.Core.Networking.AddressResolution;
using RemoteActuator.Models;

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

            var mockOptions = GetClientConfiguration(AddressFamily.InterNetwork);

            const string expectedIpv4Address = "127.0.0.1";

            var sut = new HostnameAddressResolver(mockOptions.Object);

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

            var mockOptions = GetClientConfiguration(AddressFamily.InterNetworkV6);

            const string expectedIpv6Address = "::1";

            var sut = new HostnameAddressResolver(mockOptions.Object);

            // act

            var endpoint = sut.GetEndpoint();

            // assert

            Assert.NotNull(endpoint);
            Assert.AreEqual(endpoint.Address.ToString(), expectedIpv6Address, "IPV6 Address");
            Assert.AreEqual(endpoint.Port, Port, "Port Number");
        }

        private static Mock<IOptions<ClientConfiguration>> GetClientConfiguration(AddressFamily addressFamily)
        {
            var clientConfiguration = new ClientConfiguration()
            {
                Hostname = Hostname,
                Port = Port,
                AddressFamily = addressFamily
            };

            var mockOptions = new Mock<IOptions<ClientConfiguration>>();
            mockOptions.SetupGet(options => options.Value).Returns(clientConfiguration);

            return mockOptions;
        }
    }
}