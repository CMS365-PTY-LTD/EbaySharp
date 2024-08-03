using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class PaymentSummary
    {
        public List<Payment> Payments { get; set; }
        public List<Refund> Refunds { get; set; }
        public Amount TotalDueSeller { get; set; }
    }
}