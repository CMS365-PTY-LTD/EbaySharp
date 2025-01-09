using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order
{
    public class PricingSummary
    {
        public Amount Adjustment { get; set; }
        public Amount DeliveryCost { get; set; }
        public Amount DeliveryDiscount { get; set; }
        public Amount Fee { get; set; }
        public Amount PriceDiscount { get; set; }
        public Amount PriceSubtotal { get; set; }
        public Amount Tax { get; set; }
        public Amount Total { get; set; }
    }
}
