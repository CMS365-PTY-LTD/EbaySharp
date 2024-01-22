using Newtonsoft.Json;

namespace EbaySharp.Entities.Sell.Inventory.Listing
{
    public class BulkMigrateListingRequestItem
    {
        [JsonProperty("listingId")]
        public string ListingID { get; set; }
    }
}
