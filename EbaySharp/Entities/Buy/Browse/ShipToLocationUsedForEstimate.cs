using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Buy.Browse
{
    public class ShipToLocationUsedForEstimate
    {
        public CountryCodeEnum? Country { get; set; }
        public string PostalCode { get; set; }
    }
}