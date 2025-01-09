using EbaySharp.Entities.Common;
using EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order;

namespace EbaySharp.Entities.Develop.SellingApps.AccountManagement.Finances.Transaction
{
    public class Transaction
    {
        public Amount Amount { get; set; }
        public BookingEntryEnum? BookingEntry { get; set; }
        public Buyer Buyer { get; set; }
        public Amount EBayCollectedTaxAmount { get; set; }
        public FeeJurisdiction FeeJurisdiction { get; set; }
        public FeeTypeEnum? FeeType { get; set; }
        public string OrderId { get; set; }
        public List<OrderLineItem> OrderLineItems { get; set; }
        public string PaymentsEntity { get; set; }
        public PayoutDetails PayoutDetails { get; set; }
        public string PayoutId { get; set; }
        public List<Reference> References { get; set; }
        public string SalesRecordReference { get; set; }
        public List<Taxis> Taxes { get; set; }
        public Amount TotalFeeAmount { get; set; }
        public Amount TotalFeeBasisAmount { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionId { get; set; }
        public string TransactionMemo { get; set; }
        public TransactionStatusEnum? TransactionStatus { get; set; }
        public TransactionTypeEnum? TransactionType { get; set; }
    }
}
