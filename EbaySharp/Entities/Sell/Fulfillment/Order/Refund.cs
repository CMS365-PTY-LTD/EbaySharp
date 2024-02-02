using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class Refund
    {
        public Amount Amount { get; set; }
        public string RefundDate { get; set; }
        public string RefundId { get; set; }
        public string RefundReferenceId { get; set; }
        public RefundStatusEnum? RefundStatus { get; set; }
    }
}