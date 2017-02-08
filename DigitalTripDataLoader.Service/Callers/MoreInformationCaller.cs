using DigitalTripDataLoader.Models.Request;
using DigitalTripDataLoader.Models.Response;
using DigitalTripDataLoader.Service.Serializers;

namespace DigitalTripDataLoader.Service.Callers
{
    public class MoreInformationCaller : CallerBase<MoreInfoResponse, MoreInformationRequestXmlSerializer, MoreInformationRequest>
    {
        public MoreInformationCaller(MoreInformationRequestXmlSerializer requestSerializer)
            : base(requestSerializer, "GetMoreInfoById")
        {
        }
    }
}