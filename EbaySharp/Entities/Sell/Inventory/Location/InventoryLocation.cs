using Newtonsoft.Json;

namespace EbaySharp.Entities.Sell.Inventory.Location
{
    public class InventoryLocation
    {
        public Location Location { get; set; }
        public string LocationAdditionalInformation { get; set; }
        public string LocationInstructions { get; set; }
        public List<string> LocationTypes { get; set; }
        public string LocationWebUrl { get; set; }
        public string MerchantLocationKey { get; set; }
        public string MerchantLocationStatus { get; set; }
        public string Name { get; set; }
        public List<OperatingHour> OperatingHours { get; set; }
        public string Phone { get; set; }
        public List<SpecialHour> SpecialHours { get; set; }
    }
}
