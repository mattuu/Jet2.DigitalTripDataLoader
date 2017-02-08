using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DigitalTripDataLoader.Service.Serializers
{
    public abstract class RequestXmlSerializerBase<TRequest> : XmlSerializer, IRequestXmlSerializer<TRequest>
    {
        public string Serialize(TRequest model)
        {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] {XmlQualifiedName.Empty});

            var serializer = new XmlSerializer(typeof(TRequest));
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