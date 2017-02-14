using System;
using System.Configuration;

namespace DigitalTripDataLoader.Utils
{
    public class AppConfigProvider : IAppConfigProvider
    {
        private readonly Lazy<Uri> _eCommercePropertyMappingEndpointLazy;
        private readonly Lazy<string[]> _roomTypesECommerceMappingPrefixesLazy;
        private readonly Func<string, string> _valueAccessor;
        private Uri _eCommercePropertyMappingEndpoint;
        private string[] _roomTypesECommerceMappingPrefixes;


        public AppConfigProvider(Func<string, string> valueAccessor = null)
        {
            if (valueAccessor == null)
            {
                valueAccessor = key => ConfigurationManager.AppSettings[key];
            }

            _valueAccessor = valueAccessor;

            _roomTypesECommerceMappingPrefixesLazy = new Lazy<string[]>(() => _valueAccessor(nameof(RoomTypeECommerceMappingPrefixes)).Split(','));
            _eCommercePropertyMappingEndpointLazy = new Lazy<Uri>(() => new Uri(_valueAccessor(nameof(ECommercePropertyMappingEndpoint))));
        }

        public AppConfigProvider()
            : this(null)
        {
        }

        public string[] RoomTypeECommerceMappingPrefixes => _roomTypesECommerceMappingPrefixes ?? (_roomTypesECommerceMappingPrefixes = _roomTypesECommerceMappingPrefixesLazy.Value);

        public Uri ECommercePropertyMappingEndpoint => _eCommercePropertyMappingEndpoint ?? (_eCommercePropertyMappingEndpoint = _eCommercePropertyMappingEndpointLazy.Value);
    }
}