namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.InventoryItem
{
    public class AvailabilityDistribution
    {
        public FulfillmentTime FulfillmentTime { get; set; }
        public string MerchantLocationKey { get; set; }
        public int Quantity { get; set; }
    }
}