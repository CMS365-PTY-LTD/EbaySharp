using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order
{
    public class Charges
    {
        public Amount Amount { get; set; }
        public ChargeTypeEnum? ChargeType { get; set; }
    }
}