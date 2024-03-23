namespace EbaySharp.Entities.Sell.Inventory.InventoryItem
{
    public class PackageWeightAndSize
    {
        public Dimensions Dimensions { get; set; }
        public PackageTypeEnum? PackageType { get; set; }
        public bool ShippingIrregular { get; set; }
        public Weight Weight { get; set; }
    }
}