using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.AccountManagement.Finances.Payout
{
    public class Payout
    {
        public Amount Amount { get; set; }
        public string BankReference { get; set; }
        public string LastAttemptedPayoutDate { get; set; }
        public string PayoutDate { get; set; }
        public string PayoutId { get; set; }
        public PayoutInstrument PayoutInstrument { get; set; }
        public string PayoutMemo { get; set; }
        public string PayoutReference { get; set; }
        public PayoutStatusEnum? PayoutStatus { get; set; }
        public string PayoutStatusDescription { get; set; }
        public Amount TotalAmount { get; set; }
        public Amount TotalFee { get; set; }
        public List<TotalFeeDetail> TotalFeeDetails { get; set; }
        public int? TransactionCount { get; set; }
    }
}
