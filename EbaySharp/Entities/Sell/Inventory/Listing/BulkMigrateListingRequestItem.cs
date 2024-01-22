using Newtonsoft.Json;

namespace EbaySharp.Entities.Sell.Inventory.Listing
{
    public class BulkMigrateListingRequestItem
    {
        [JsonProperty("listingID")]
        public string ListingID { get; set; }
    }
}
