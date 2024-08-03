using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Location
{
    public class Location
    {
        public Address Address { get; set; }
        public GeoCoordinates GeoCoordinates { get; set; }
        public string LocationId { get; set; }
    }
}
