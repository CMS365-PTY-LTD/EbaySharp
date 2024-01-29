namespace EbaySharp.Entities.Sell.Inventory.Listing
{
    public class BulkMigrateListingError
    {
        public string Category { get; set; }
        public string Domain { get; set; }
        public int ErrorId { get; set; }
        public string[] InputRefIDs { get; set; }
        public string LongMessage { get; set; }
        public string Message { get; set; }
        public string[] OutputRefIDs { get; set; }
        public List<KeyValuePair<string, string>> Parameters { get; set; }
        public string Subdomain { get; set; }
    }
}
