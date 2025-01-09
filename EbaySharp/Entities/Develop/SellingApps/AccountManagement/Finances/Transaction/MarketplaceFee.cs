using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.AccountManagement.Finances.Transaction
{
    public class MarketplaceFee
    {
        public Amount Amount { get; set; }
        public FeeJurisdiction FeeJurisdiction { get; set; }
        public string FeeMemo { get; set; }
        public FeeTypeEnum? FeeType { get; set; }
    }
}
