namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class ShippingCostOverride
    {
        public Amount AdditionalShippingCost { get; set; }
        public int Priority { get; set; }
        public Amount ShippingCost { get; set; }
        public ShippingServiceTypeEnum ShippingServiceType { get; set; }
        public Amount Surcharge { get; set; }
    }
}