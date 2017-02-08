
namespace DigitalTripDataLoader.Models.Response
{
    public class Property
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Resort { get; set; }

        public string Area { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }

        public int Beds { get; set; }

        public int Baths { get; set; }

        public int Sleeps { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string[] Images { get; set; }

        public Attribute[] Attributes { get; set; }
    }
}