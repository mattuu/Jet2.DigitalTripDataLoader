using System.Xml.Serialization;

namespace DigitalTripDataLoader.Models.Response
{
    [XmlRoot("PropertiesResponse")]
    public class GetPropertiesResponse : ResponseBase
    {
        public BanksProperty[] Properties { get; set; }

    }
}