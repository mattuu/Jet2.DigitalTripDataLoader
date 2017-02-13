namespace DigitalTripDataLoader.eCommerce.Models
{
    public class PropertyModel
    {
        public int PropertyId { get; set; }

        public int LocationId { get; set; }

        public string Description { get; set; }

        public RoomModel[] Rooms { get; set; }
    }
}