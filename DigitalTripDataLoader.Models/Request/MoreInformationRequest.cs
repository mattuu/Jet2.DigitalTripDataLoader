using System.Xml.Serialization;

namespace DigitalTripDataLoader.Models.Request
{
    [XmlRoot]
    public class MoreInformationRequest
    {
        [XmlElement("ID")]
        public int Id { get; set; }
    }
}