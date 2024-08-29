using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Finances.Transaction
{
    public class Donation
    {
        public Amount Amount { get; set; }
        public FeeJurisdiction FeeJurisdiction { get; set; }
        public string FeeMemo { get; set; }
        public FeeTypeEnum? FeeType { get; set; }
    }
}
