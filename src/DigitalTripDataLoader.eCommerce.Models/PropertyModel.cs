using Newtonsoft.Json;

namespace DigitalTripDataLoader.eCommerce.Models
{
    public class PropertyModel
    {
        [JsonProperty("digitalTripPropertyId")]
        public int PropertyId { get; set; }

        [JsonProperty("digitalTripLocationId")]
        public int LocationId { get; set; }

        public string Description { get; set; }

        public RoomModel[] Rooms { get; set; }
    }
}