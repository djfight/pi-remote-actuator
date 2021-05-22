using NUnit.Framework;

using RemoteActuator.Core.Networking.Packets;
using RemoteActuator.Models;

namespace RemoteActuator.Core.Tests.Networking.Packets
{
    [TestFixture]
    internal class ACommandPacketFragment
    {
        [Test]
        public void ShouldSerialize()
        {
            // arrange

            const string expectedPacketFragment = "0 ";

            var sut = new CommandPacketFragment(MessageType.DeviceCommand);

            // act

            var actualPacketFragment = sut.Serialize();

            // assert

            Assert.AreEqual(expectedPacketFragment, actualPacketFragment, "Packet Fragment");
        }
    }
}