using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Sell.Inventory.InventoryItem
{
    public class InventoryItems
    {
        public string Href { get; set; }
        [JsonPropertyName("inventoryItems")]
        public List<InventoryItem> InventoryItemsList { get; set; }
        public string Limit { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
        public string Size { get; set; }
        public string Total { get; set; }
    }
}
