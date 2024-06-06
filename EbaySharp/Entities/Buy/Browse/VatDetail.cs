using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Buy.Browse
{
    public class VatDetail
    {
        public CountryCodeEnum? IssuingCountry { get; set; }
        public string VatId { get; set; }
    }
}