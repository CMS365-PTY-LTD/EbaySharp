using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Inventory.Location
{
    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public CountryCodeEnum? Country { get; set; }
        public string County { get; set; }
        public string PostalCode { get; set; }
        public string StateOrProvince { get; set; }
    }
}
