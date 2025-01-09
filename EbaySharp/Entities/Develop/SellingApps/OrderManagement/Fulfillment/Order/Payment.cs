using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order
{
    public class Payment
    {
        public Amount Amount { get; set; }
        public string PaymentDate { get; set; }
        public List<PaymentHold> PaymentHolds { get; set; }
        public PaymentMethodTypeEnum? PaymentMethod { get; set; }
        public string PaymentReferenceId { get; set; }
        public PaymentStatusEnum? PaymentStatus { get; set; }
    }
}