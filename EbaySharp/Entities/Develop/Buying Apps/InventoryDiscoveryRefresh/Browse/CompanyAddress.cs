using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Buy.Browse
{
    public class CompanyAddress
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }
        public CountryCodeEnum? Country { get; set; }
        public string CountryName { get; set; }
        public string County { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string StateOrProvince { get; set; }
    }
}
