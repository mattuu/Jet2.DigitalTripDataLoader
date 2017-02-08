namespace DigitalTripDataLoader.Service.Serializers
{
    public interface IRequestXmlSerializer<in TModel>
    {
        string Serialize(TModel model);
    }

    public interface IRequestXmlSerializer
    {
        string Serialize();
    }
}