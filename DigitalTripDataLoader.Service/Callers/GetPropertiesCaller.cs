using DigitalTripDataLoader.Models.Response;
using DigitalTripDataLoader.Service.Serializers;

namespace DigitalTripDataLoader.Service.Callers
{
    public class GetPropertiesCaller : CallerBase<GetPropertiesResponse, EmptyRequestSeriazlier>
    {
        public GetPropertiesCaller(EmptyRequestSeriazlier requestSerializer)
            : base(requestSerializer, "GetProperties")
        {
        }
    }
}