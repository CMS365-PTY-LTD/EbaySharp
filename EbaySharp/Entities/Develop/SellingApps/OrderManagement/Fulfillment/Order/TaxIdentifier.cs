using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order
{
    public class TaxIdentifier
    {
        public string TaxpayerId { get; set; }
        public TaxIdentifierTypeEnum? TaxIdentifierType { get; set; }
        public CountryCodeEnum? IssuingCountry { get; set; }
    }
}
