namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class Regulatory
    {
        public EconomicOperator EconomicOperator { get; set; }
        public EnergyEfficiencyLabel EnergyEfficiencyLabel { get; set; }
        public Hazmat Hazmat { get; set; }
        public int RepairScore { get; set; }
    }
}