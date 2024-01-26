using System.Text.Json.Serialization;

namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class Offers
    {
        public string Href { get; set; }
        [JsonPropertyName("offers")]
        public List<Offer> OffersList { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
    }
}
