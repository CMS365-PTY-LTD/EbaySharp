using Newtonsoft.Json;

namespace EbaySharp.Entities.Inventory
{
    public class BulkMigrateListingRequest
    {
        [JsonProperty("requests")]
        public BulkMigrateListingRequestItem[] Requests { get; set; }
    }
}
