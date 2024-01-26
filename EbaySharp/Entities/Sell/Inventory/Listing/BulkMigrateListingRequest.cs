using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Sell.Inventory.Listing
{
    public class BulkMigrateListingRequest
    {
        [JsonPropertyName("requests")]
        public BulkMigrateListingRequestItem[] Requests { get; set; }
    }
}
