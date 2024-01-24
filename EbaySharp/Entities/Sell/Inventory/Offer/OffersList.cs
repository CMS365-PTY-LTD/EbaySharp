namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class OffersList
    {
        public string Href { get; set; }
        public string Limit { get; set; }
        public string Next { get; set; }
        public List<Offer> Offers { get; set; }
        public string Prev { get; set; }
        public string Size { get; set; }
        public string Total { get; set; }
    }
}
