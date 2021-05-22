using System;

using RemoteActuator.Models;

namespace RemoteActuator.Core.Networking.Packets
{
    internal class PinNumberPacketFragment : IPacketFragment
    {
        private const int MinPinNumber = 0;
        private const int MaxPinNumber = 2;
        
        private readonly int _pinNumber;

        public PinNumberPacketFragment(int pinNumber)
        {
            if (pinNumber < MinPinNumber)
            {
                throw new ArgumentException($"Pin number must be greater than {MinPinNumber}", nameof(pinNumber));
            }

            if (pinNumber > MaxPinNumber)
            {
                throw new ArgumentException($"Pin number must be less than {MaxPinNumber}", nameof(pinNumber));
            }

            _pinNumber = pinNumber;
        }

        public string Serialize()
        {
            return $"0{_pinNumber}";
        }
    }
}