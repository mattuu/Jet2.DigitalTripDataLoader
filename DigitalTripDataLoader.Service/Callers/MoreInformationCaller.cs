using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalTripDataLoader.Models.Request;
using DigitalTripDataLoader.Models.Response;
using DigitalTripDataLoader.Service.Serializers;

namespace DigitalTripDataLoader.Service.Callers
{
    public class MoreInformationCaller : CallerBase<MoreInfoResponse, MoreInformationRequestXmlSerializer>
    {
        public MoreInformationCaller(MoreInformationRequestXmlSerializer requestSerializer) 
            : base(requestSerializer, "GetMoreInfoById")
        {
        }
    }
}
