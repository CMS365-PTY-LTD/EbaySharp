using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Inventory.Location
{
    public class Location
    {
        public Address Address { get; set; }
        public GeoCoordinates GeoCoordinates { get; set; }
        public string LocationId { get; set; }
    }
}
