namespace RemoteActuator.Core.Networking.AddressResolution
{
    public interface IAddressResolver
    {
        /// <summary>
        /// Address interface that contains the IPAddress and Port.
        /// </summary>
        /// <returns>
        /// Post-condition: Should never return null.
        /// </returns>
        IAddress GetAddress();
    }
}