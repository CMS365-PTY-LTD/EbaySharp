using EbaySharp.Entities.Common;
using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order.ShippingFulfillment
{
    public class Fulfillments
    {
        [JsonPropertyName("fulfillments")]
        public List<Fulfillment> FulfillmentItemList { get; set; }
        public int? Total { get; set; }
        public List<Warning> Warnings { get; set; }
    }
}
