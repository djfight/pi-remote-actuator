using System;

using RemoteActuator.Models;

namespace RemoteActuator.Core.Packets
{
    internal class SignalPacketFragment : IPacketFragment
    {
        private readonly bool _signal;

        public SignalPacketFragment(bool signal)
        {
            _signal = signal;
        }

        public string Serialize()
        {
            return $" {Convert.ToInt32(_signal)}";
        }
    }
}