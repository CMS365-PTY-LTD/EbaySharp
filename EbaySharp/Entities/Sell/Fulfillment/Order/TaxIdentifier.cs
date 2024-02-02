using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class TaxIdentifier
    {
        public string TaxpayerId { get; set; }
        public TaxIdentifierTypeEnum? TaxIdentifierType { get; set; }
        public CountryCodeEnum? IssuingCountry { get; set; }
    }
}
