namespace EbaySharp.Entities.Sell.Inventory.InventoryItem
{
    public class InventoryItemsResponse
    {
        public string Href { get; set; }
        public List<InventoryItem> InventoryItems { get; set; }
        public string Limit { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
        public string Size { get; set; }
        public string Total { get; set; }
    }
}
