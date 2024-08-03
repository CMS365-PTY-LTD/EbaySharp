namespace EbaySharp.Entities.Buy.Browse
{
    public class Seller
    {
        public string FeedbackPercentage { get; set; }
        public int? FeedbackScore { get; set; }
        public string SellerAccountType { get; set; }
        public SellerLegalInfo SellerLegalInfo { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
    }
}