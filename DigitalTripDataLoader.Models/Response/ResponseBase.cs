namespace DigitalTripDataLoader.Models.Response
{
    public abstract class ResponseBase
    {
        public bool IsSuccess { get; set; }

        public bool IsComplete { get; set; }
    }
}