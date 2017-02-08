using DigitalTripDataLoader.Models.Request;

namespace DigitalTripDataLoader.Service.Serializers
{
    public interface IMoreInformationRequestXmlSerializer : IRequestXmlSerializer<MoreInformationRequest>, IRequestXmlSerializer
    {
        string GetXml(int id);
    }
}