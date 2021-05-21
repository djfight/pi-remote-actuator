﻿using NUnit.Framework;
using RemoteActuator.Core.Packets;

namespace RemoteActuator.Core.Tests.Packets
{
    [TestFixture]
    internal class APinNumberPacketFragment
    {
        [Test]
        public void ShouldSerialize()
        {
            // arrange

            const int pinNumber = 1;
            const string expectedPacketFragment = "01";

            var sut = new PinNumberPacketFragment(pinNumber);

            // act

            var actualPacketFragment = sut.Serialize();

            // assert

            Assert.AreEqual(expectedPacketFragment, actualPacketFragment, "Packet Fragment");
        }
    }
}