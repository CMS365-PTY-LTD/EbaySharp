using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.BuyingApps.InventoryDiscoveryRefresh.Browse.Item
{
    public class MarketingPrice
    {
        public Amount DiscountAmount { get; set; }
        public string DiscountPercentage { get; set; }
        public Amount OriginalPrice { get; set; }
        public PriceTreatmentEnum? PriceTreatment { get; set; }
    }
}