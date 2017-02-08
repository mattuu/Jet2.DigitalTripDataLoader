using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using DigitalTripDataLoader.Models.Request;

namespace DigitalTripDataLoader.Service.Serializers
{
    public class MoreInformationRequestXmlSerializer : XmlSerializer, IMoreInformationRequestXmlSerializer
    {
        public string GetXml(int id)
        {
            var model = new MoreInformationRequest
            {
                Id = id
            };

            var emptyNamepsaces = new XmlSerializerNamespaces(new[] {XmlQualifiedName.Empty});

            var serializer = new XmlSerializer(typeof(MoreInformationRequest));
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

        public string Serialize(MoreInformationRequest model)
        {
            throw new NotImplementedException();
        }

        public string Serialize()
        {
            throw new NotImplementedException();
        }
    }
}