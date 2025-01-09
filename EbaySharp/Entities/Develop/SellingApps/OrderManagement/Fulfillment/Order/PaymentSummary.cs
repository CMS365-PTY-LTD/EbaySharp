using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order
{
    public class PaymentSummary
    {
        public List<Payment> Payments { get; set; }
        public List<Refund> Refunds { get; set; }
        public Amount TotalDueSeller { get; set; }
    }
}