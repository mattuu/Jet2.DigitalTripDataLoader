using DigitalTripDataLoader.eCommerce.Models;

namespace DigitalTripDataLoader.eCommerce.Services
{
    public interface IPropertyModelJsonSerializer
    {
        string Serialize(PropertyModel propertyModel);
    }
}