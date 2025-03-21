using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.AccountManagement.Finances.Payout
{
    public class PayoutSummary
    {
        public Amount Amount { get; set; }
        public int? ProductCount { get; set; }
        public int? TransactionCount { get; set; }
    }
}
