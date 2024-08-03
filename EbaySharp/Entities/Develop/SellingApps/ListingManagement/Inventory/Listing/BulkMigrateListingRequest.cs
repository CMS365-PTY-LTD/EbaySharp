using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Listing
{
    public class BulkMigrateListingRequest
    {
        [JsonPropertyName("requests")]
        public BulkMigrateListingRequestItem[] Requests { get; set; }
    }
}
