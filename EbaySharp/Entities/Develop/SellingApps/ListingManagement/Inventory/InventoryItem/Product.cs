namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.InventoryItem
{
    public class Product
    {
        public Dictionary<string, string[]> Aspects { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string[] EAN { get; set; }
        public string EPID { get; set; }
        public string[] ImageUrls { get; set; }
        public string[] ISBN { get; set; }
        public string MPN { get; set; }
        public string Subtitle { get; set; }
        public string Title { get; set; }
        public string[] UPC { get; set; }
        public string[] VideoIds { get; set; }
    }
}