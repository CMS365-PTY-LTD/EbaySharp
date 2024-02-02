using EbaySharp.Entities.Sell.Inventory.Offer;

namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class PricingSummary
    {
        public OrderAmount Adjustment { get; set; }
        public OrderAmount DeliveryCost { get; set; }
        public OrderAmount DeliveryDiscount { get; set; }
        public OrderAmount Fee { get; set; }
        public OrderAmount PriceDiscount { get; set; }
        public OrderAmount PriceSubtotal { get; set; }
        public OrderAmount Tax { get; set; }
        public OrderAmount Total { get; set; }
    }
}
