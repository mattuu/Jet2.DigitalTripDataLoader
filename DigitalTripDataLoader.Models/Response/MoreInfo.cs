using System.Collections.Generic;

namespace DigitalTripDataLoader.Models.Response
{
    public class MoreInfo
    {
        public Image[] Images { get; set; }

        public InfoItem[] Information { get; set; }
    }
}