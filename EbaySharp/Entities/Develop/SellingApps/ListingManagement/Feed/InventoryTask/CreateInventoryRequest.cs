namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Feed.InventoryTask
{
    public class CreateInventoryRequest
    {
        public string FeedType { get; set; }
        public string SchemaVersion { get; set; }
        public FilterCritera? FilterCritera { get; set; }
    }
}
