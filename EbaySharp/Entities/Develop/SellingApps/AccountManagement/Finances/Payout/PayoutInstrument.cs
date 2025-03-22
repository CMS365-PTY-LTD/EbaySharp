namespace EbaySharp.Entities.Develop.SellingApps.AccountManagement.Finances.Payout
{
    public class PayoutInstrument
    {
        public string AccountLastFourDigits { get; set; }
        public string InstrumentType { get; set; }
        public string Nickname { get; set; }
        public string PayoutPercentage { get; set; }
    }
}