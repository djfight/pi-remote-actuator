using System.Collections.Generic;

namespace RemoteActuator.Models
{
    public interface IPacket
    {
        IEnumerable<IPacketFragment> PacketFragments { get; }
        byte[] Serialize();
    }
}