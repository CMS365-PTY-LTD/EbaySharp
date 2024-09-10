using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.TraditionalSelling.Trading
{
    public class LegacyItem
    {
        public string Title { get; set; }
        public string ItemID { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public SellingStatus SellingStatus { get; set; }
        public CountryCodeEnum Country { get; set; }
        public ListingDetails ListingDetails { get; set; }
        public PrimaryCategory PrimaryCategory { get; set; }
    }
}
