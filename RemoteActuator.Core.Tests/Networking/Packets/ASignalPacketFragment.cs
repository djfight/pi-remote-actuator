using NUnit.Framework;

using RemoteActuator.Core.Networking.Packets;

namespace RemoteActuator.Core.Tests.Networking.Packets
{
    [TestFixture]
    internal class ASignalPacketFragment
    {
        [Test]
        public void ShouldSerialize()
        {
            // arrange

            const bool signal = true;
            const string expectedPacketFragment = " 1";

            var sut = new SignalPacketFragment(signal);

            // act

            var actualPacketFragment = sut.Serialize();

            // assert

            Assert.AreEqual(expectedPacketFragment, actualPacketFragment, "Packet Fragment");
        }
    }
}