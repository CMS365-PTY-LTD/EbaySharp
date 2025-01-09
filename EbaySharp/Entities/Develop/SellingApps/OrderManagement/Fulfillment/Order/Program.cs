using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order
{
    public class Program
    {
        public AuthenticityVerification AuthenticityVerification { get; set; }
        public Amount EbayShipping { get; set; }
        public EbayVault EbayVault { get; set; }
        public EbayInternationalShipping EbayInternationalShipping { get; set; }
        public FulfillmentProgram FulfillmentProgram { get; set; }
    }
}