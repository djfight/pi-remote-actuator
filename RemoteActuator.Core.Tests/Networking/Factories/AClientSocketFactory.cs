using System.Net;
using System.Net.Sockets;

using Moq;

using NUnit.Framework;

using RemoteActuator.Core.Networking.AddressResolution;
using RemoteActuator.Core.Networking.Factories;

namespace RemoteActuator.Core.Tests.Networking.Factories
{
    [TestFixture]
    public class AClientSocketFactory
    {
        [Test]
        public void ShouldCreateASocket()
        {
            // arrange

            var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);

            var addressResolverMock = new Mock<IAddressResolver>();
            addressResolverMock.Setup(addressResolver => addressResolver.GetEndpoint()).Returns(endpoint);

            var sut = new ClientSocketFactory(addressResolverMock.Object);

            // act

            var clientSocket = sut.CreateClientSocket();

            // assert

            Assert.NotNull(clientSocket);
            Assert.AreEqual(SocketType.Stream, clientSocket.Socket.SocketType, "Socket Type");
            Assert.AreEqual(ProtocolType.Tcp, clientSocket.Socket.ProtocolType, "Protocol Type");
            Assert.AreEqual(AddressFamily.InterNetwork, clientSocket.Socket.AddressFamily, "Address Family IPV4");
        }

        // todo: write test for IPV6 address family
    }
}