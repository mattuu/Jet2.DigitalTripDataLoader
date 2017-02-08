namespace DigitalTripDataLoader.Service.Serializers
{
    public interface IRequestXmlSerializer<in TData>
    {
        string Serialize(TData model);
    }
}