using System;
using System.Collections.Generic;

using RemoteActuator.Models;

namespace RemoteActuator.Core.Packets
{
    internal class CommandPacketFragment : IPacketFragment
    {
        private const int PacketSize = 2;
        private readonly MessageType _messageType;
        private readonly Dictionary<MessageType, int> _messageTypeCommandCodes;

        private int CommandCode => _messageTypeCommandCodes[_messageType];

        public CommandPacketFragment(MessageType messageType)
        {
            _messageType = messageType;

            _messageTypeCommandCodes = new Dictionary<MessageType, int>()
            {
                { MessageType.DeviceCommand, 0 },
                { MessageType.TerminateCommand, 1 }
            };
        }

        public string Serialize()
        {
            var packetFragment = $"{CommandCode} ";

            if (packetFragment.Length != PacketSize)
            {
                throw new InvalidOperationException($"Invalid command packet fragment length." +
                                                    $" Expected {PacketSize}, but was {packetFragment.Length}");
            }

            return packetFragment;
        }
    }
}