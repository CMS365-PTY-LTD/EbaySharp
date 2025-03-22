using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.AccountManagement.Finances.Payout
{
    public class TotalFeeDetail
    {
        public Amount Amount { get; set; }
        public FeeJurisdiction FeeJurisdiction { get; set; }
        public string FeeMemo { get; set; }
        public FeeTypeEnum? FeeType { get; set; }
    }
}