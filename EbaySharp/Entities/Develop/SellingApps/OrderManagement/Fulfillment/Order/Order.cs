using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order
{
    public class Order
    {
        public Buyer Buyer { get; set; }
        public string BuyerCheckoutNotes { get; set; }
        public CancelStatus CancelStatus { get; set; }
        public string CreationDate { get; set; }
        public bool? EbayCollectAndRemitTax { get; set; }
        public List<string> FulfillmentHrefs { get; set; }
        public List<FulfillmentStartInstruction> FulfillmentStartInstructions { get; set; }
        public string LastModifiedDate { get; set; }
        public List<LineItem> LineItems { get; set; }
        public OrderFulfillmentStatus? OrderFulfillmentStatus { get; set; }
        public string OrderId { get; set; }
        public OrderPaymentStatusEnum? OrderPaymentStatus { get; set; }
        public PaymentSummary PaymentSummary { get; set; }
        public PricingSummary PricingSummary { get; set; }
        public Program Program { get; set; }
        public string SalesRecordReference { get; set; }
        public string SellerId { get; set; }
        public Amount TotalFeeBasisAmount { get; set; }
        public Amount TotalMarketplaceFee { get; set; }
    }
}
