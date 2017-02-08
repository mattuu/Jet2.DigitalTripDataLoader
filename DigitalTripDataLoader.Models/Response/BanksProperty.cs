using System.Xml.Serialization;

namespace DigitalTripDataLoader.Models.Response
{
    public class BanksProperty
    {
        [XmlElement("PropertyID")]
        public int PropertyId { get; set; }

        public string PropertyName { get; set; }
    }
}