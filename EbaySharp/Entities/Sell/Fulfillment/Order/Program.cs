namespace EbaySharp.Entities.Sell.Fulfillment.Order
{
    public class Program
    {
        public AuthenticityVerification AuthenticityVerification { get; set; }
        public EbayShipping EbayShipping { get; set; }
        public EbayVault EbayVault { get; set; }
        public EbayInternationalShipping EbayInternationalShipping { get; set; }
        public FulfillmentProgram FulfillmentProgram { get; set; }
    }
}