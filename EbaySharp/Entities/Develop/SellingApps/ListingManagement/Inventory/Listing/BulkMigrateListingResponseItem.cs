using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Listing
{
    public class BulkMigrateListingResponseItem
    {
        public List<BulkMigrateListingError> Errors { get; set; }
        public string InventoryItemGroupKey { get; set; }
        public List<BulkMigrateListingInventoryItem> InventoryItems { get; set; }
        public string ListingId { get; set; }
        public MarketplaceEnum MarketplaceId { get; set; }
        public int StatusCode { get; set; }
        public List<BulkMigrateListingWarning> Warnings { get; set; }
    }
}
