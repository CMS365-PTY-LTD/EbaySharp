using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order
{
    public class EbayCollectAndRemitTaxis
    {
        public Amount Amount { get; set; }
        public Parameter EbayReference { get; set; }
        public TaxTypeEnum? TaxType { get; set; }
        public CollectionMethodEnum? CollectionMethod { get; set; }
    }
}