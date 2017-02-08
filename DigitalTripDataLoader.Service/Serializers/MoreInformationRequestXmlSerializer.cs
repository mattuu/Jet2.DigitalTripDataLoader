using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using DigitalTripDataLoader.Models.Request;

namespace DigitalTripDataLoader.Service.Serializers
{
    public class MoreInformationRequestXmlSerializer : RequestXmlSerializerBase<MoreInformationRequest>
    {
        public string Serialize()
        {
            throw new NotImplementedException();
        }
    }
}