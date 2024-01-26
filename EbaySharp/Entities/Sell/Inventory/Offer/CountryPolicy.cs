using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class CountryPolicy
    {
        public CountryCodeEnum Country { get; set; }
        public List<string> PolicyIDs { get; set; }
    }
}