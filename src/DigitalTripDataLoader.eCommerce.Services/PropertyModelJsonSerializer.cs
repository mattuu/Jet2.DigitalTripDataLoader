using System.IO;
using System.Text;
using DigitalTripDataLoader.eCommerce.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DigitalTripDataLoader.eCommerce.Services
{
    public class PropertyModelJsonSerializer : IPropertyModelJsonSerializer
    {
        private readonly JsonSerializer _serializer;

        public PropertyModelJsonSerializer()
        {
            _serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public string Serialize(PropertyModel propertyModel)
        {
            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                using (JsonWriter writer = new JsonTextWriter(stringWriter))
                {
                    _serializer.Serialize(writer, propertyModel);
                }
            }

            return stringBuilder.ToString();
        }
    }
}