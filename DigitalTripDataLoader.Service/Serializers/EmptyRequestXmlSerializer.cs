using System.Xml.Serialization;
using DigitalTripDataLoader.Models.Request;

namespace DigitalTripDataLoader.Service.Serializers
{
    public class EmptyRequestXmlSerializer : RequestXmlSerializerBase<EmptyRequest>
    {
        public string Serialize()
        {
            return string.Empty;
        }
    }

    //public abstract class GenericRequestXmlSerializer<TRequest, TModel, TMapper> : RequestXmlSerializerBase<TRequest>, IRequestXmlSerializer
    //{
    //    protected GenericRequestXmlSerializer(TMapper mapper)
    //    {
            
    //    }

    //    public virtual string Serialize()
    //    {
    //        return Serialize(new TModel());
    //    }
    //}
}