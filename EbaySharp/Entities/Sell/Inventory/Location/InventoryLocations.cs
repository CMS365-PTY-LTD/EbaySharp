namespace EbaySharp.Entities.Sell.Inventory.Location
{
    public class InventoryLocations
    {
        public string Href { get; set; }
        public string Limit { get; set; }
        public string Next { get; set; }
        public string Offset { get; set; }
        public string Prev { get; set; }
        public string Total { get; set; }
        public List<InventoryLocation> Locations { get; set; }
    }
}
