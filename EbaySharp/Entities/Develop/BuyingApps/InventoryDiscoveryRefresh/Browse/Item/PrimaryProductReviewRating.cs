namespace EbaySharp.Entities.Develop.BuyingApps.InventoryDiscoveryRefresh.Browse.Item
{
    public class PrimaryProductReviewRating
    {
        public string AverageRating { get; set; }
        public List<RatingHistogram> RatingHistograms { get; set; }
        public int? ReviewCount { get; set; }
    }
}