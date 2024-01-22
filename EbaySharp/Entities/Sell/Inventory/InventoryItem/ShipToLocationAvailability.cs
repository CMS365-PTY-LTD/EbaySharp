namespace EbaySharp.Entities.Sell.Inventory.InventoryItem
{
    public class ShipToLocationAvailability
    {
        public AllocationByFormat AllocationByFormat { get; set; }
        public List<AvailabilityDistribution> AvailabilityDistributions { get; set; }
        public string Quantity { get; set; }
    }
}