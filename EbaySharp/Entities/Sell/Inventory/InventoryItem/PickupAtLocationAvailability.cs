namespace EbaySharp.Entities.Sell.Inventory.InventoryItem
{
    public class PickupAtLocationAvailability
    {
        public AvailabilityTypeEnum AvailabilityType { get; set; }
        public FulfillmentTime FulfillmentTime { get; set; }
        public string MerchantLocationKey { get; set; }
        public int Quantity { get; set; }
    }
}
