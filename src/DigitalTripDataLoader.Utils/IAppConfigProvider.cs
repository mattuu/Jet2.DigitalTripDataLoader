using System;

namespace DigitalTripDataLoader.Utils
{
    public interface IAppConfigProvider
    {
        string[] RoomTypeECommerceMappingPrefixes { get; }

        Uri ECommercePropertyMappingEndpoint { get; }
    }
}