using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Develop.SellingApps.ListingManagement.Inventory.Offer
{
    public class Offers
    {
        public string Href { get; set; }
        [JsonPropertyName("offers")]
        public List<Offer> OfferList { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
    }
}
