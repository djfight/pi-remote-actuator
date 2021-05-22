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

            var addressMock = new Mock<IAddress>();
            addressMock.SetupGet((address) => address.IpAddress).Returns(IPAddress.Parse("127.0.0.1"));
            addressMock.SetupGet(address => address.Port).Returns(8080);

            var addressResolverMock = new Mock<IAddressResolver>();
            addressResolverMock.Setup(addressResolver => addressResolver.GetAddress()).Returns(addressMock.Object);

            var sut = new ClientSocketFactory(addressResolverMock.Object);

            // act

            var socket = sut.CreateSocket();

            // assert

            Assert.NotNull(socket);
            Assert.AreEqual(SocketType.Stream, socket.SocketType, "Socket Type");
            Assert.AreEqual(ProtocolType.Tcp, socket.ProtocolType, "Protocol Type");
            Assert.AreEqual(AddressFamily.InterNetwork, socket.AddressFamily, "Address Family IPV4");
        }

        // todo: write test for IPV6 address family
    }
}