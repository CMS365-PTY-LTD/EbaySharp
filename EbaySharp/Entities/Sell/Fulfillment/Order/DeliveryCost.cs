namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class DeliveryCost: OrderAmount
    {
        public float? DiscountAmount { get; set; }
        public float? HandlingCost { get; set; }
        public OrderAmount ImportCharges { get; set; }
        public OrderAmount ShippingCost { get; set; }
        public OrderAmount ShippingIntermediationFee { get; set; }
    }
}