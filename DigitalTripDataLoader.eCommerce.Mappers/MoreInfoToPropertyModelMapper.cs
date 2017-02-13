using System;
using System.Linq;
using DigitalTripDataLoader.eCommerce.Models;
using DigitalTripDataLoader.Models.Response;
using DigitalTripDataLoader.Utils;

namespace DigitalTripDataLoader.eCommerce.Mappers
{
    public class MoreInfoToPropertyModelMapper : IMapper<MoreInfo, PropertyModel>
    {
        private readonly IAppConfigProvider _appConfigProvider;
        public const string PropertyIdInfoName = "PropertyID";
        public const string LocationIdInfoName = "LocationID";
        public const string DescriptionInfoName = "Description";
        public const string RoomTypeInfoNamePrefixes = "Bedroom,Kitchen,Bathroom,Shower,Utility,Lounge,Dining";

        public MoreInfoToPropertyModelMapper(IAppConfigProvider appConfigProvider)
        {
            if (appConfigProvider == null) throw new ArgumentNullException(nameof(appConfigProvider));
            _appConfigProvider = appConfigProvider;
        }

        public PropertyModel Map(MoreInfo source)
        {
            var propertyModel = new PropertyModel();

            var propertyIdInfoItem = source.Information.SingleOrDefault(i => i.InfoName == PropertyIdInfoName);
            if (propertyIdInfoItem != null)
            {
                propertyModel.PropertyId = int.Parse(propertyIdInfoItem.InfoValue);
            }

            var descriptionInfoItem = source.Information.SingleOrDefault(i => i.InfoName == DescriptionInfoName);
            propertyModel.Description = descriptionInfoItem?.InfoValue;

            var locationIdInfoItem = source.Information.SingleOrDefault(i => i.InfoName == LocationIdInfoName);
            if (locationIdInfoItem != null)
            {
                propertyModel.LocationId = int.Parse(locationIdInfoItem.InfoValue);
            }

            var roomTypeMappingPrefixes = _appConfigProvider.RoomTypeECommerceMappingPrefixes;
            var matchedRoomInfoItems = source.Information.Where(i => roomTypeMappingPrefixes.Any(p => i.InfoName.Contains(p)));

            propertyModel.Rooms = matchedRoomInfoItems.Select(i => new RoomModel
            {
                Description = i.InfoName
            }).ToArray();

            return propertyModel;
        }
    }
}