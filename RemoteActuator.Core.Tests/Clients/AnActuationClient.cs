using Moq;

using NUnit.Framework;

using RemoteActuator.Core.Clients;
using RemoteActuator.Core.Networking;
using RemoteActuator.Models;

namespace RemoteActuator.Core.Tests.Clients
{
    [TestFixture]
    internal class AnActuationClient
    {
        [Test]
        public void ShouldSendACommand()
        {
            // arrange

            var mockClientSocket = new Mock<IClientSocket>();
            mockClientSocket.Setup(clientSocket => clientSocket.Send(It.IsAny<IPacket>()));

            var sut = new ActuationClient(mockClientSocket.Object);

            // act

            sut.SendCommand(MessageType.DeviceCommand, 0, true);

            // assert

            Assert.NotNull(sut);
            mockClientSocket.Verify(clientSocket => clientSocket.Send(It.IsAny<IPacket>()), Times.Once);
        }
    }
}