using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Inventory.Offer
{
    public class CountryPolicy
    {
        public CountryCodeEnum Country { get; set; }
        public string[] PolicyIDs { get; set; }
    }
}