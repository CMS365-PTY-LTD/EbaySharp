using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order
{
    public class DeliveryCost : Amount
    {
        public double? DiscountAmount { get; set; }
        public double? HandlingCost { get; set; }
        public Amount ImportCharges { get; set; }
        public Amount ShippingCost { get; set; }
        public Amount ShippingIntermediationFee { get; set; }
    }
}