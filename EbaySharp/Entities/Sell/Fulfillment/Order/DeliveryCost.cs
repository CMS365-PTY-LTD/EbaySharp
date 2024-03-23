namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class DeliveryCost: OrderAmount
    {
        public double? DiscountAmount { get; set; }
        public double? HandlingCost { get; set; }
        public OrderAmount ImportCharges { get; set; }
        public OrderAmount ShippingCost { get; set; }
        public OrderAmount ShippingIntermediationFee { get; set; }
    }
}