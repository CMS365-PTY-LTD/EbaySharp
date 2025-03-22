namespace EbaySharp.Entities.Develop.SellingApps.AccountManagement.Finances.Payout
{
    public class PayoutList
    {
        public string Href { get; set; }
        public int? Limit { get; set; }
        public string Next { get; set; }
        public int? Offset { get; set; }
        public List<Payout> Payouts { get; set; }
        public string Prev { get; set; }
        public int? Total { get; set; }
    }
}
