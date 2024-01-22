namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class ShippingCostOverride
    {
        public Amount AdditionalShippingCost { get; set; }
        public string Priority { get; set; }
        public Amount ShippingCost { get; set; }
        public string ShippingServiceType { get; set; }
        public Amount Surcharge { get; set; }
    }
}