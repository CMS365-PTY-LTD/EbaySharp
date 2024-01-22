namespace EbaySharp.Entities.Sell.Inventory.Listing
{
    public class BulkMigrateListingResponseItem
    {
        public List<BulkMigrateListingError> Errors { get; set; }
        public string InventoryItemGroupKey { get; set; }
        public List<BulkMigrateListingInventoryItem> InventoryItems { get; set; }
        public string ListingID { get; set; }
        public string MarketplaceID { get; set; }
        public string StatusCode { get; set; }
        public List<BulkMigrateListingWarning> Warnings { get; set; }
    }
}
