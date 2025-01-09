using EbaySharp.Entities.Common;
using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order
{
    public class Orders
    {
        public required string Href { get; set; }
        public int Limit { get; set; }
        public string? Next { get; set; }
        public int Offset { get; set; }
        [JsonPropertyName("orders")]
        public required List<Order> OrderList { get; set; }
        public string? Prev { get; set; }
        public int Total { get; set; }
        public List<Warning>? Warnings { get; set; }
    }
}
