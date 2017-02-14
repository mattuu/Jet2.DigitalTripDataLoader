using Newtonsoft.Json;

namespace DigitalTripDataLoader.eCommerce.Models
{
    public class RoomModel
    {
        [JsonProperty("digitalTripRoomId")]
        public int RoomId { get; set; }

        [JsonProperty("roomDescription")]
        public string Description { get; set; }
    }
}