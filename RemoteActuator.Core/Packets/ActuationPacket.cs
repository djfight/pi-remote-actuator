using System;
using System.Collections.Generic;
using System.Text;

using RemoteActuator.Models;

namespace RemoteActuator.Core.Packets
{
    internal class ActuationPacket : IPacket
    {
        private const int PacketSize = 7;
        public IEnumerable<IPacketFragment> PacketFragments { get; }

        public ActuationPacket(IEnumerable<IPacketFragment> packetFragments)
        {
            PacketFragments = packetFragments;
        }

        public byte[] Serialize()
        {
            const char nullTerminator = '\0';
            var stringBuilder = new StringBuilder();

            foreach (var packetFragment in PacketFragments)
            {
                stringBuilder.Append(packetFragment.Serialize());
            }

            stringBuilder.Append(nullTerminator);

            var packet = stringBuilder.ToString();

            if (packet.Length != PacketSize)
            {
                throw new InvalidOperationException($"Incorrect packet length. Expected packet length of size {PacketSize}." +
                                                    $" Received pack length of size {packet.Length}");
            }

            return getPacketBytes(packet);
        }

        private byte[] getPacketBytes(string packet)
        {
            var packetBytes = Encoding.ASCII.GetBytes(packet);

            return packetBytes;
        }
    }
}