namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.InventoryItem
{
    public class PackageWeightAndSize
    {
        public Dimensions Dimensions { get; set; }
        public PackageTypeEnum? PackageType { get; set; }
        public bool ShippingIrregular { get; set; }
        public Weight Weight { get; set; }
    }
}