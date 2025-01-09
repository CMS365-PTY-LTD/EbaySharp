using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.BuyingApps.InventoryDiscoveryRefresh.Browse.Item
{
    public class AddonService
    {
        public AddonServiceSelectionEnum? Selection { get; set; }
        public Amount ServiceFee { get; set; }
        public string ServiceId { get; set; }
        public AddonServiceTypeEnum? ServiceType { get; set; }
    }
}
