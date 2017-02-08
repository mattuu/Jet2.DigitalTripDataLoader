using DigitalTripDataLoader.Models.Request;
using DigitalTripDataLoader.Models.Response;
using DigitalTripDataLoader.Service.Serializers;

namespace DigitalTripDataLoader.Service.Callers
{
    public class GetPropertiesCaller : CallerBase<GetPropertiesResponse, EmptyRequestXmlSerializer, EmptyRequest>
    {
        public GetPropertiesCaller(EmptyRequestXmlSerializer requestSerializer)
            : base(requestSerializer, "GetProperties")
        {
        }
    }
}