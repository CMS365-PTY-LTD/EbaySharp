namespace EbaySharp.Entities.Sell.Inventory.InventoryItem
{
    public class PickupAtLocationAvailability
    {
        public string AvailabilityType { get; set; }
        public FulfillmentTime FulfillmentTime { get; set; }
        public string MerchantLocationKey { get; set; }
        public string Quantity { get; set; }
    }
}
