namespace EbaySharp.Entities.Sell.Inventory.Location
{
    public class InventoryLocations
    {
        public string Href { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
        public List<InventoryLocation> Locations { get; set; }
    }
}
