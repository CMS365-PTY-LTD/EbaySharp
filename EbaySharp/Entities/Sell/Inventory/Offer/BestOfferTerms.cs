namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class BestOfferTerms
    {
        public Amount AutoAcceptPrice { get; set; }
        public Amount AutoDeclinePrice { get; set; }
        public string BestOfferEnabled { get; set; }
    }
}