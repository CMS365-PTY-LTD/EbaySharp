using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class EbayCollectAndRemitTaxis
    {
        public OrderAmount Amount { get; set; }
        public Parameter EbayReference { get; set; }
        public TaxTypeEnum? TaxType { get; set; }
        public CollectionMethodEnum? CollectionMethod { get; set; }
    }
}