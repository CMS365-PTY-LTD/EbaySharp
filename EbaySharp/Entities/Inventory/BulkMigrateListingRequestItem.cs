using Newtonsoft.Json;

namespace EbaySharp.Entities.Inventory
{
    public class BulkMigrateListingRequestItem
    {
        [JsonProperty("listingId")]
        public string ListingID { get; set; }
    }
}
