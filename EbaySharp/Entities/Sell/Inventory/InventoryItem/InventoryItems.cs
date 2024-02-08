using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Sell.Inventory.InventoryItem
{
    public class InventoryItems
    {
        public string Href { get; set; }
        [JsonPropertyName("inventoryItems")]
        public List<InventoryItem> InventoryItemList { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
    }
}
