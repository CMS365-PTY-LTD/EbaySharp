using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class Offers
    {
        public string Href { get; set; }
        public string Limit { get; set; }
        public string Next { get; set; }
        [JsonPropertyName("offers")]
        public List<Offer> OffersList { get; set; }
        public string Prev { get; set; }
        public string Size { get; set; }
        public string Total { get; set; }
    }
}
