using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Buy.Browse
{
    public class AddonService
    {
        public AddonServiceSelectionEnum? Selection { get; set; }
        public Amount ServiceFee { get; set; }
        public string ServiceId { get; set; }
        public AddonServiceTypeEnum? ServiceType { get; set; }
    }
}
