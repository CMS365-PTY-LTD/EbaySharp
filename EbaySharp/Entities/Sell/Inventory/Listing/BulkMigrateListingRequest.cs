using Newtonsoft.Json;

namespace EbaySharp.Entities.Sell.Inventory.Listing
{
    public class BulkMigrateListingRequest
    {
        [JsonProperty("requests")]
        public BulkMigrateListingRequestItem[] Requests { get; set; }
    }
}
