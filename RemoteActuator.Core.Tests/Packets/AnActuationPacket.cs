using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using RemoteActuator.Core.Packets;
using RemoteActuator.Models;

namespace RemoteActuator.Core.Tests.Packets
{
    public class AnActuationPacket
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldSerializeAPacket()
        {
            // arrange

            var expectedRawPacket = "0 01 1\0";
            var expectedPacket = Encoding.ASCII.GetBytes(expectedRawPacket);

            var packetFragments = new List<IPacketFragment>()
            {
                new CommandPacketFragment(MessageType.DeviceCommand),
                new PinNumberPacketFragment(1),
                new SignalPacketFragment(true)
            };

            var sut = new ActuationPacket(packetFragments);

            Assert.NotNull(sut);

            // act

            var actualPacket = sut.Serialize();

            // assert

            Assert.NotNull(actualPacket);
            Assert.AreEqual(expectedPacket, actualPacket, "Packet");
        }
    }
}