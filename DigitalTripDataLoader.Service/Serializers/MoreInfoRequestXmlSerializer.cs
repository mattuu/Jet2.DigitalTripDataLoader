using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using DigitalTripDataLoader.Models.Request;

namespace DigitalTripDataLoader.Service.Serializers
{
    public class MoreInfoRequestXmlSerializer : XmlSerializer
    {
        public string GetXml(int id, Guid guid)
        {
            var model = new MoreInfoRequest
            {
                Id = id,
                Guid = guid
            };

            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            var serializer = new XmlSerializer(typeof(MoreInfoRequest));
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
                {
                    serializer.Serialize(xmlWriter, model, emptyNamepsaces);
                }
                return stringWriter.ToString();
            }
        }
    }
}   
