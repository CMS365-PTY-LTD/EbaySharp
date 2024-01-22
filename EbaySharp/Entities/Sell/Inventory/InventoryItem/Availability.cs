namespace EbaySharp.Entities.Sell.Inventory.InventoryItem
{
    public class Availability
    {
        public List<PickupAtLocationAvailability> PickupAtLocationAvailability { get; set; }
        public ShipToLocationAvailability ShipToLocationAvailability { get; set; }
    }
}
