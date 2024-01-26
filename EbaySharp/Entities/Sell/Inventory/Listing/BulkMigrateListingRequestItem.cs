using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Sell.Inventory.Listing
{
    public class BulkMigrateListingRequestItem
    {
        [JsonPropertyName("listingID")]
        public string ListingID { get; set; }
    }
}
