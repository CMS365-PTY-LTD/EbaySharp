namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.InventoryItem
{
    public class ShipToLocationAvailability
    {
        public AllocationByFormat AllocationByFormat { get; set; }
        public List<AvailabilityDistribution> AvailabilityDistributions { get; set; }
        public int Quantity { get; set; }
    }
}