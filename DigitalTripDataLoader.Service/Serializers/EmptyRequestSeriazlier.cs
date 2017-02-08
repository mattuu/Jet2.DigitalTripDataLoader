using System.Xml.Serialization;

namespace DigitalTripDataLoader.Service.Serializers
{
    public class EmptyRequestSeriazlier : XmlSerializer, IRequestXmlSerializer
    {
        public string Serialize()
        {
            return string.Empty;
        }
    }
}