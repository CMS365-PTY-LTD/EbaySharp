using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order
{
    public class ItemLocation
    {
        public CountryCodeEnum? CountryCode { get; set; }
        public string Location { get; set; }
        public string PostalCode { get; set; }
    }
}