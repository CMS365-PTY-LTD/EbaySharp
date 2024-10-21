namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Offer
{
    public class Regulatory
    {
        public Document[] Documents { get; set; }
        public EnergyEfficiencyLabel EnergyEfficiencyLabel { get; set; }
        public Hazmat Hazmat { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public ProductSafety ProductSafety { get; set; }
        public int RepairScore { get; set; }
        public ResponsiblePerson[] ResponsiblePerson { get; set; }

    }
}