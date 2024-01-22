using Newtonsoft.Json.Linq;

namespace EbaySharp.Entities.Sell.Inventory.InventoryItem
{
    public class Product
    {
        public JObject Aspects { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public List<string> Ean { get; set; }
        public string EpID { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<string> Isbn { get; set; }
        public string Mpn { get; set; }
        public string Subtitle { get; set; }
        public string Title { get; set; }
        public List<string> Upc { get; set; }
        public List<string> VIDeoIDs { get; set; }
    }
}