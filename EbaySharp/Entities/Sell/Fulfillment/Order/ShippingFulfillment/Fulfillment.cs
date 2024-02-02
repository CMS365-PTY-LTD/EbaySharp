using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Fulfillment.Order.ShippingFulfillment
{
    public class Fulfillment: Shipment
    {
        public string FulfillmentId { get; set; }
        public List<LineItem> LineItems { get; set; }
        public string ShippedDate { get; set; }
    }
}
