using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class ItemLocation
    {
        public CountryCodeEnum? CountryCode { get; set; }
        public string Location { get; set; }
        public string PostalCode { get; set; }
    }
}