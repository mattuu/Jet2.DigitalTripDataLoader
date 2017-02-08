using System;
using System.Xml.Serialization;

namespace DigitalTripDataLoader.Models.Request
{
    [XmlRoot]
    public class MoreInfoRequest
    {
        [XmlElement("GUID")]
        public Guid Guid { get; set; }

        [XmlElement("ID")]
        public int Id { get; set; }
    }
}