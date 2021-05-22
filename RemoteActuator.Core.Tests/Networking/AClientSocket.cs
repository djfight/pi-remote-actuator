using System.Collections.Generic;
using System.Net;

using Moq;
using NUnit.Framework;

using RemoteActuator.Core.Networking;
using RemoteActuator.Core.Networking.Packets;
using RemoteActuator.Core.Networking.Proxies;
using RemoteActuator.Models;

namespace RemoteActuator.Core.Tests.Networking
{
    [TestFixture]
    public class AClientSocket
    {
        [Test]
        public void ShouldSendAPacket()
        {
            // arrange

            const int expectedPacketSize = 7;

            var packetFragments = new List<IPacketFragment>()
            {
                new CommandPacketFragment(MessageType.DeviceCommand),
                new PinNumberPacketFragment(0),
                new SignalPacketFragment(true)
            };

            var packet = new ActuationPacket(packetFragments);

            var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            
            var mockSocketProxy = new Mock<ISocketProxy>();
            mockSocketProxy.Setup(socketProxy =>
                    socketProxy.Send(It.IsAny<byte[]>()))
                .Returns(expectedPacketSize);

            var sut = new ClientSocket(endpoint, mockSocketProxy.Object);

            // act

            sut.Send(packet);

            // assert

            mockSocketProxy.Verify(socketProxy => socketProxy.Send(It.IsAny<byte[]>()), Times.Once);
        }
    }
}