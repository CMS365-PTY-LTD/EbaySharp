namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.InventoryItem
{
    public class InventoryItem
    {
        public Availability Availability { get; set; }
        public ConditionEnum? Condition { get; set; }
        public string ConditionDescription { get; set; }
        public List<ConditionDescriptor> ConditionDescriptors { get; set; }
        public string[] GroupIds { get; set; }
        public string[] InventoryItemGroupKeys { get; set; }
        public string Locale { get; set; }
        public PackageWeightAndSize PackageWeightAndSize { get; set; }
        public Product Product { get; set; }
        public string SKU { get; set; }
    }
}
