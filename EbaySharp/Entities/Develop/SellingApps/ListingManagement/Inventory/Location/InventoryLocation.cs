namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Location
{
    public class InventoryLocation
    {
        public Location Location { get; set; }
        public string LocationAdditionalInformation { get; set; }
        public string LocationInstructions { get; set; }
        public List<StoreTypeEnum> LocationTypes { get; set; }
        public string LocationWebUrl { get; set; }
        public string MerchantLocationKey { get; set; }
        public StatusEnum? MerchantLocationStatus { get; set; }
        public string Name { get; set; }
        public List<OperatingHour> OperatingHours { get; set; }
        public string Phone { get; set; }
        public List<SpecialHour> SpecialHours { get; set; }
    }
}
