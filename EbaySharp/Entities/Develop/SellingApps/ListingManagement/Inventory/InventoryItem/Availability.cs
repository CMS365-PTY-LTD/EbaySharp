namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.InventoryItem
{
    public class Availability
    {
        public List<PickupAtLocationAvailability> PickupAtLocationAvailability { get; set; }
        public ShipToLocationAvailability ShipToLocationAvailability { get; set; }
    }
}
