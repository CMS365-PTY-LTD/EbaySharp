namespace EbaySharp.Entities.Sell.Inventory.InventoryItem
{
    public class InventoryItem
    {
        public Availability Availability { get; set; }
        public string Condition { get; set; }
        public string ConditionDescription { get; set; }
        public List<ConditionDescriptor> ConditionDescriptors { get; set; }
        public List<string> GroupIds { get; set; }
        public List<string> InventoryItemGroupKeys { get; set; }
        public string Locale { get; set; }
        public PackageWeightAndSize PackageWeightAndSize { get; set; }
        public Product Product { get; set; }
        public string Sku { get; set; }
    }
}
